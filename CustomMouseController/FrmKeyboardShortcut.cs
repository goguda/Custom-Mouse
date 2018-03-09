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
            int numItems = shortcut.Count(x => !string.IsNullOrEmpty(x));

            if (numItems == 4)
                return;

            string toAdd = String.Empty;

            // One of the control keys
            if (e.Control)
                toAdd = "CTRL";
            if (e.Alt)
                toAdd = "ALT";
            if (e.Shift)
                toAdd = "SHIFT";
            
            // If not, add the right key
            if (toAdd == String.Empty)
            {
                switch (e.KeyCode)
                {
                    // other control keys
                    case Keys.Escape:
                        toAdd = "ESC";
                        break;
                    case Keys.Space:
                        toAdd = "SPACE";
                        break;
                    case Keys.Tab:
                        toAdd = "TAB";
                        break;
                    case Keys.Back:
                        toAdd = "BACKSPACE";
                        break;
                    case Keys.Delete:
                        toAdd = "DELETE";
                        break;
                    // numbers
                    case Keys.D0:
                        toAdd = "0";
                        break;
                    case Keys.D1:
                        toAdd = "1";
                        break;
                    case Keys.D2:
                        toAdd = "2";
                        break;
                    case Keys.D3:
                        toAdd = "3";
                        break;
                    case Keys.D4:
                        toAdd = "4";
                        break;
                    case Keys.D5:
                        toAdd = "5";
                        break;
                    case Keys.D6:
                        toAdd = "6";
                        break;
                    case Keys.D7:
                        toAdd = "7";
                        break;
                    case Keys.D8:
                        toAdd = "8";
                        break;
                    case Keys.D9:
                        toAdd = "9";
                        break;
                    // letters
                    case Keys.A:
                        toAdd = "A";
                        break;
                    case Keys.B:
                        toAdd = "B";
                        break;
                    case Keys.C:
                        toAdd = "C";
                        break;
                    case Keys.D:
                        toAdd = "D";
                        break;
                    case Keys.E:
                        toAdd = "E";
                        break;
                    case Keys.F:
                        toAdd = "F";
                        break;
                    case Keys.G:
                        toAdd = "G";
                        break;
                    case Keys.H:
                        toAdd = "H";
                        break;
                    case Keys.I:
                        toAdd = "I";
                        break;
                    case Keys.J:
                        toAdd = "J";
                        break;
                    case Keys.K:
                        toAdd = "K";
                        break;
                    case Keys.L:
                        toAdd = "L";
                        break;
                    case Keys.M:
                        toAdd = "M";
                        break;
                    case Keys.N:
                        toAdd = "N";
                        break;
                    case Keys.O:
                        toAdd = "O";
                        break;
                    case Keys.P:
                        toAdd = "P";
                        break;
                    case Keys.Q:
                        toAdd = "Q";
                        break;
                    case Keys.R:
                        toAdd = "R";
                        break;
                    case Keys.S:
                        toAdd = "S";
                        break;
                    case Keys.T:
                        toAdd = "T";
                        break;
                    case Keys.U:
                        toAdd = "U";
                        break;
                    case Keys.V:
                        toAdd = "V";
                        break;
                    case Keys.W:
                        toAdd = "W";
                        break;
                    case Keys.X:
                        toAdd = "X";
                        break;
                    case Keys.Y:
                        toAdd = "Y";
                        break;
                    case Keys.Z:
                        toAdd = "Z";
                        break;
                    // punctuation
                    case Keys.Oemcomma:
                        toAdd = ",";
                        break;
                    case Keys.OemPeriod:
                        toAdd = ".";
                        break;
                }
            }


            if (!(toAdd == String.Empty))
            {
                if (shortcut.Contains(toAdd))
                    return;

                shortcut[numItems] = toAdd;
                UpdateUI();
            }

        }

        private void UpdateUI()
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < shortcut.Length; i++)
            {
                if (shortcut[i] == null)
                    break;

                if (i == 0)
                {
                    builder.Append(shortcut[i]);
                } else
                {
                    builder.Append("+" + shortcut[i]);
                }
            }

            lblShortcut.Text = builder.ToString();
        }

        private void FrmKeyboardShortcut_Load(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            shortcut = new string[4];
            UpdateUI();
        }
    }
}
