/*
 * File: FrmKeyboardShortcut.cs
 * Contains: FrmKeyboardShortcut class
 * 
 * This class interacts with the keyboard shortcut form and saves
 * the specified shortcut to the passed ButtonSetting instance.
 * 
 * Author: David Goguen
 * Original release: March 26, 2018
 * 
 * Last updated: March 26, 2018
 * 
 */

using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomMouseController
{
    public partial class FrmKeyboardShortcut : Form
    {
        /* stores the specified key combination in plain text */
        private string[] shortcut;

        /* stores the passed reference to the ButtonSetting instance that is to be modified */
        private ButtonSetting buttonSetting;

        /*
         * Main constructor for the keyboard shortcut form. Takes a
         * reference to the ButtonSetting instance for the button that
         * is to be modified.
         */
        public FrmKeyboardShortcut(ButtonSetting buttonSetting)
        {
            InitializeComponent();

            this.shortcut = new string[4];
            this.buttonSetting = buttonSetting;
        }

        /*
         * Indicates that the assignment has been cancelled and closes
         * the form when the Cancel button is pressed.
         */
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /*
         * Detects which keys have been pressed down and saves them to
         * the shortcut array in plain text.
         */
        private void FrmKeyboardShortcut_KeyDown(object sender, KeyEventArgs e)
        {
            // get number of keys currently in array
            int numItems = shortcut.Count(x => !string.IsNullOrEmpty(x));

            // if there are already 4 (max number of keys supported for the combination), do nothing
            if (numItems == 4)
                return;

            // otherwise, detect the key that is to be added to the array and store it in plain text
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
                // this is tedious, but seems to be the best way to do this to prevent errors
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
                    case Keys.Enter:
                        toAdd = "ENTER";
                        break;
                    case Keys.End:
                        toAdd = "END";
                        break;
                    case Keys.Insert:
                        toAdd = "INSERT";
                        break;
                    case Keys.Home:
                        toAdd = "HOME";
                        break;
                    case Keys.PageUp:
                        toAdd = "PGEUP";
                        break;
                    case Keys.PageDown:
                        toAdd = "PGEDWN";
                        break;
                    // top number keys
                    case Keys.Oemtilde:
                        toAdd = "`";
                        break;
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
                    case Keys.OemMinus:
                        toAdd = "-";
                        break;
                    case Keys.Oemplus:
                        toAdd = "=";
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
                    case Keys.OemQuestion:
                        toAdd = "/";
                        break;
                    case Keys.Oem5:
                        toAdd = "\\";
                            break;
                    case Keys.OemOpenBrackets:
                        toAdd = "[";
                        break;
                    case Keys.OemCloseBrackets:
                        toAdd = "]";
                        break;
                    case Keys.OemSemicolon:
                        toAdd = ";";
                        break;
                    case Keys.OemQuotes:
                        toAdd = "'";
                        break;
                    // function keys
                    case Keys.F1:
                        toAdd = "F1";
                        break;
                    case Keys.F2:
                        toAdd = "F2";
                        break;
                    case Keys.F3:
                        toAdd = "F3";
                        break;
                    case Keys.F4:
                        toAdd = "F4";
                        break;
                    case Keys.F5:
                        toAdd = "F5";
                        break;
                    case Keys.F6:
                        toAdd = "F6";
                        break;
                    case Keys.F7:
                        toAdd = "F7";
                        break;
                    case Keys.F8:
                        toAdd = "F8";
                        break;
                    case Keys.F9:
                        toAdd = "F9";
                        break;
                    case Keys.F10:
                        toAdd = "F10";
                        break;
                    case Keys.F11:
                        toAdd = "F11";
                        break;
                    case Keys.F12:
                        toAdd = "F12";
                        break;
                }
            }
            
            if (!(toAdd == String.Empty))
            {
                // do not allow more than one of the same key in the shortcut array
                if (shortcut.Contains(toAdd))
                    return;

                shortcut[numItems] = toAdd;
                UpdateUI();
            }
        }

        /*
         * Updates the UI to display the key combination that is being assigned.
         */
        private void UpdateUI()
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < shortcut.Length; i++)
            {
                if (shortcut[i] == null) // stop the loop once we've hit the end of assigned keys
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

            // disable clear button if nothing has been assigned
            if (shortcut.Count(x => !String.IsNullOrEmpty(x)) == 0)
            {
                btnClear.Enabled = false;
            }
            else
            {
                btnClear.Enabled = true;
            }
        }

        /*
         * Clears the shortcut array for a new key combination when pressed.
         * Also clears the label indicating the shortcut on the UI.
         */
        private void btnClear_Click(object sender, EventArgs e)
        {
            shortcut = new string[4];
            UpdateUI();
            lblInstructions.Focus();
        }

        /*
         * Never allows Clear button to have focus since it may interrupt
         * assignment of key combination depending on keys pressed.
         */
        private void btnClear_MouseLeave(object sender, EventArgs e)
        {
            lblInstructions.Focus();
        }

        /*
         * Never allows Cancel button to have focus since it may interrupt
         * assignment of key combination depending on keys pressed.
         */
        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            lblInstructions.Focus();
        }
        /*
         * 
         * Never allows OK button to have focus since it may interrupt
         * assignment of key combination depending on keys pressed.
         */
        private void btnOK_MouseLeave(object sender, EventArgs e)
        {
            lblInstructions.Focus();
        }

        /*
         * Saves the key combination to the passed ButtonSetting instance
         * and closes the form when the OK button is pressed. Displays
         * a warning message box if no key combination has been assigned.
         */
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (shortcut.Count(x => !String.IsNullOrEmpty(x)) == 0)
            {
                DialogResult msg = MessageBox.Show("No keyboard combination has been assigned. Would you " +
                    "like to go back and assign one?", "No Keyboard Shortcut Assigned", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                
                if (msg == DialogResult.No) // assign null key combination if user has specified they do not want to assign one
                {
                    buttonSetting.KeyCombination = null;
                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                }
                else if (msg == DialogResult.Yes)
                {
                    return;
                }
            }

            buttonSetting.KeyCombination = shortcut;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
