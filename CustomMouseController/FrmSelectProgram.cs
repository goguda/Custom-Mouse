using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomMouseController
{
    public partial class FrmSelectProgram : Form
    {
        private ButtonSetting buttonSetting;
        private List<IWshShortcut> files;
        public FrmSelectProgram(ButtonSetting buttonSetting)
        {
            InitializeComponent();
            this.buttonSetting = buttonSetting;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmSelectProgram_Load(object sender, EventArgs e)
        {
            string[] filePaths = null;

            filePaths = Directory.GetFiles(@"C:\ProgramData\Microsoft\Windows\Start Menu\Programs",
                            "*.lnk", SearchOption.AllDirectories);

            files = new List<IWshShortcut>();

            WshShell shell = new WshShell();

            for (int i = 0; i < filePaths.Length; i++)
            {
                IWshShortcut link = (IWshShortcut)shell.CreateShortcut(filePaths[i]);

                string path = link.TargetPath;

                if (!System.IO.File.Exists(link.TargetPath) && link.TargetPath.ToLower().Contains("program files (x86)"))
                {
                    path = path.Substring(0, path.ToLower().IndexOf("program files (x86)")) + @"Program Files" + path.Substring(path.ToLower().IndexOf("program files (x86)") + 19);
                }

                if (System.IO.File.Exists(path))
                    files.Add(link);
            }

            files.Sort(delegate(IWshShortcut file1, IWshShortcut file2)
            {
                return Path.GetFileName(file1.FullName).CompareTo(Path.GetFileName(file2.FullName));
            });

            ImageList icons = new ImageList();
            icons.ImageSize = new Size(32, 32);
            icons.ColorDepth = ColorDepth.Depth32Bit;
            int counter = 0;
            foreach (IWshShortcut file in files)
            {
                string path = file.TargetPath;

                if (!System.IO.File.Exists(file.TargetPath) && file.TargetPath.ToLower().Contains("program files (x86)"))
                {
                    path = path.Substring(0, path.ToLower().IndexOf("program files (x86)")) + @"Program Files" + path.Substring(path.ToLower().IndexOf("program files (x86)") + 19);
                }

                icons.Images.Add(Icon.ExtractAssociatedIcon(path));

                ListViewItem item = new ListViewItem(Path.GetFileNameWithoutExtension(file.FullName));
                item.ImageIndex = counter;
                counter++;
                lstPrograms.Items.Add(item);
            }
            lstPrograms.SmallImageList = icons;
        }

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
