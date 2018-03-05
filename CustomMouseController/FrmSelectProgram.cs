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
        private string[] files;
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
            string[] files = Directory.GetFiles(@"C:\ProgramData\Microsoft\Windows\Start Menu\Programs",
                                        "*.lnk", SearchOption.AllDirectories);

            ImageList icons = new ImageList();
            icons.ImageSize = new Size(32, 32);
            icons.ColorDepth = ColorDepth.Depth32Bit;
            string[] programNames;

            int counter = 0;
            foreach (string file in files)
            {
                FileInfo info = new FileInfo(file);
                icons.Images.Add(Icon.ExtractAssociatedIcon(file));

                ListViewItem item = new ListViewItem(info.Name.Substring(0, info.Name.IndexOf(info.Extension)));
                item.ImageIndex = counter;
                counter++;
                lstPrograms.Items.Add(item);
            }

            lstPrograms.SmallImageList = icons;
        }
    }
}
