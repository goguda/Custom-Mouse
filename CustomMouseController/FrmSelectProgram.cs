/*
 * File: FrmSelectProgram.cs
 * Contains: FrmSelectProgram class
 * 
 * This class controls the Select a Program UI and takes care
 * of assigning the selected program to the passed ButtonSetting
 * instance.
 * 
 * Author: David Goguen
 * Original release: March 26, 2018
 * 
 * Last updated: March 26, 2018
 * 
 */

using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomMouseController
{
    public partial class FrmSelectProgram : Form
    {
        /* stores a reference to the passed ButtonSetting instance for the current button */
        private ButtonSetting buttonSetting;

        /* stores a list of IWshShortcut of found program shortcuts */
        private List<IWshShortcut> files;

        /* delegate to update program icons from a separate thread */
        private delegate ImageList UpdateProgramIconsDelegate(ImageList icons);

        /* delegate to add a program to the list from a separate thread */
        private delegate ListViewItem AddToProgramListDelegate(ListViewItem item);

        /* delegate to hide the 'Getting list of programs...' label from a separate thread */
        private delegate void HideGettingProgramsLabel();

        /* delegate to call ListView.EndUpdate() from a separate thread */
        private delegate void EndListUpdate();

        /*
         * Main constructor for the Select a Program form. Takes a
         * reference to the ButtonSetting instance for the button that
         * is to be modified.
         */
        public FrmSelectProgram(ButtonSetting buttonSetting)
        {
            InitializeComponent();
            this.buttonSetting = buttonSetting;
        }

        /*
         * Closes form if Cancel button is clicked.
         */
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /*
         * Starts task to get list of programs when the form loads.
         */
        private void FrmSelectProgram_Load(object sender, EventArgs e)
        {
            Task t = Task.Factory.StartNew(LoadProgramList);
            lstPrograms.BeginUpdate();
        }

        /*
         * Finds all program shortcuts from Start Menu recursively and loads
         * them into the ListView on the UI. This method is run from a separate
         * task started on form load so it does not lock up the UI.
         */
        private void LoadProgramList()
        {
            string[] filePaths = null;

            filePaths = Directory.GetFiles(@"C:\ProgramData\Microsoft\Windows\Start Menu\Programs",
                            "*.lnk", SearchOption.AllDirectories);

            files = new List<IWshShortcut>();

            WshShell shell = new WshShell();

            // search for shortcuts in folders in Start Menu recursively
            for (int i = 0; i < filePaths.Length; i++)
            {
                IWshShortcut link = (IWshShortcut)shell.CreateShortcut(filePaths[i]);

                string path = link.TargetPath;

                // second check for 64-bit systems to prevent a bug where the found target path of the shortcut
                // may indicate it points to Program Files (x86), even though the executable is found in
                // Program Files and not Program Files (x86)
                if (!System.IO.File.Exists(link.TargetPath) && link.TargetPath.ToLower().Contains("program files (x86)"))
                {
                    path = path.Substring(0, path.ToLower().IndexOf("program files (x86)")) + @"Program Files" + path.Substring(path.ToLower().IndexOf("program files (x86)") + 19);
                }

                if (System.IO.File.Exists(path))
                    files.Add(link);
            }

            // sort list alphabetically
            files.Sort(delegate (IWshShortcut file1, IWshShortcut file2)
            {
                return Path.GetFileName(file1.FullName).CompareTo(Path.GetFileName(file2.FullName));
            });

            ImageList icons = new ImageList();
            icons.ImageSize = new Size(32, 32);
            icons.ColorDepth = ColorDepth.Depth32Bit;
            int counter = 0;

            // get the icon associated with each found program
            foreach (IWshShortcut file in files)
            {
                string path = file.TargetPath; // using the target path of the shortcut to get executable path and original icon

                // check for 64-bit systems to prevent same bug as described above
                if (!System.IO.File.Exists(file.TargetPath) && file.TargetPath.ToLower().Contains("program files (x86)"))
                {
                    path = path.Substring(0, path.ToLower().IndexOf("program files (x86)")) + @"Program Files" + path.Substring(path.ToLower().IndexOf("program files (x86)") + 19);
                }

                icons.Images.Add(Icon.ExtractAssociatedIcon(path));

                ListViewItem item = new ListViewItem(Path.GetFileNameWithoutExtension(file.FullName));
                item.ImageIndex = counter;
                counter++;

                // add program to list
                // using delegate and invoking because it is not known if the CLR will place this task
                // on the same thread or a separate thread, where an invoke with a delegate would be required
                // if it is placed on a separate thread
                if (lstPrograms.InvokeRequired)
                {
                    lstPrograms.Invoke(new AddToProgramListDelegate(lstPrograms.Items.Add), new object[] { item });
                }
                else
                {
                    lstPrograms.Items.Add(item);
                }
            }

            // hide 'Getting list of programs...' label
            if (lblGettingPrograms.InvokeRequired)
            {
                lblGettingPrograms.Invoke(new HideGettingProgramsLabel(() => { lblGettingPrograms.Visible = false; }));
            }
            else
            {
                lblGettingPrograms.Visible = false;
            }
            
            // add icons to ListView and end ListView update
            if (lstPrograms.InvokeRequired)
            {
                lstPrograms.Invoke(new UpdateProgramIconsDelegate(x => (lstPrograms.SmallImageList = x)), new object[] { icons });
                lstPrograms.Invoke(new EndListUpdate(lstPrograms.EndUpdate));
            }
            else
            {
                lstPrograms.SmallImageList = icons;
                lstPrograms.EndUpdate();
            }
        }

        /*
         * Creates a new ProgramInfo object with the selected program's information
         * and assigns it to the passed ButtonSetting instance, then closes the
         * Select a Program form.
         */
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lstPrograms.SelectedIndices.Count == 0)
            {
                return;
            }

            IWshShortcut selected = files[lstPrograms.SelectedIndices[0]];

            string path = selected.TargetPath;

            if (!System.IO.File.Exists(selected.TargetPath) && selected.TargetPath.ToLower().Contains("program files (x86)"))
            {
                path = path.Substring(0, path.ToLower().IndexOf("program files (x86)")) + @"Program Files" + path.Substring(path.ToLower().IndexOf("program files (x86)") + 19);
            }

            Icon programIcon = Icon.ExtractAssociatedIcon(path);

            ProgramInfo toSave = new ProgramInfo(Path.GetFileNameWithoutExtension(selected.FullName), path, programIcon);

            buttonSetting.ProgramInfo = toSave;

            DialogResult = DialogResult.OK;
            Close();
        }

        /*
         * Disables the OK button if nothing is selected, and enables it
         * otherwise.
         */
        private void lstPrograms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPrograms.SelectedIndices.Count == 0)
            {
                btnOK.Enabled = false;
            }
            else
            {
                btnOK.Enabled = true;
            }
        }
    }
}
