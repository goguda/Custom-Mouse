using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomMouseController
{
    public partial class FrmKeyboardShortcut : Form
    {

        private string[] shortcut;
        public FrmKeyboardShortcut()
        {
            InitializeComponent();

            shortcut = new string[4];
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmKeyboardShortcut_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void UpdateUI()
        {

        }
    }
}
