using IWshRuntimeLibrary;
using Shell32;
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
        private FileInfo[] files;
        public FrmSelectProgram()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmSelectProgram_Load(object sender, EventArgs e)
        {
            string[] filePaths = Directory.GetFiles(@"C:\ProgramData\Microsoft\Windows\Start Menu\Programs",
                                        "*.lnk", SearchOption.AllDirectories);

            files = new FileInfo[filePaths.Length];
            
            for (int i = 0; i < filePaths.Length; i++)
            {
                files[i] = new FileInfo(filePaths[i]);
            }

            Array.Sort(files, delegate(FileInfo file1, FileInfo file2)
            {
                return file1.Name.CompareTo(file2.Name);
            });

            ImageList icons = new ImageList();
            icons.ImageSize = new Size(32, 32);
            icons.ColorDepth = ColorDepth.Depth32Bit;

            int counter = 0;
            foreach (FileInfo file in files)
            {
            
                icons.Images.Add(Icon.ExtractAssociatedIcon(file.FullName));

                ListViewItem item = new ListViewItem(file.Name.Substring(0, file.Name.IndexOf(file.Extension)));
                item.ImageIndex = counter;
                counter++;
                lstPrograms.Items.Add(item);
            }

            lstPrograms.SmallImageList = icons;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }
    }
}
