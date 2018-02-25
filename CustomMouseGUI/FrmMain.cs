using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomMouseGUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        // Store references to buttons for quicker colour change
        Button[] uiButtons;

        private void Form1_Load(object sender, EventArgs e)
        {
            uiButtons = new Button[7];

            uiButtons[0] = btnJoystick;
            uiButtons[1] = btnButton1;
            uiButtons[2] = btnButton2;
            uiButtons[3] = btnButton3;
            uiButtons[4] = btnButton4;
            uiButtons[5] = btnButton5;
            uiButtons[6] = btnButton6;

            btnJoystick.PerformClick();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuOpenControlCenter_Click(object sender, EventArgs e)
        {
            Show();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void nfyTrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Show();
            }
        }

        private void btnJoystick_Click(object sender, EventArgs e)
        {
            btnJoystick.BackColor = Color.FromArgb(230, 0, 0);
            SetDefaultButtonColour((Button)sender);
        }

        private void btnButton1_Click(object sender, EventArgs e)
        {
            btnButton1.BackColor = Color.FromArgb(230, 0, 0);
            SetDefaultButtonColour((Button)sender);
        }

        private void btnButton2_Click(object sender, EventArgs e)
        {
            btnButton2.BackColor = Color.FromArgb(230, 0, 0);
            SetDefaultButtonColour((Button)sender);
        }

        private void btnButton3_Click(object sender, EventArgs e)
        {
            btnButton3.BackColor = Color.FromArgb(230, 0, 0);
            SetDefaultButtonColour((Button)sender);
        }

        private void btnButton4_Click(object sender, EventArgs e)
        {
            btnButton4.BackColor = Color.FromArgb(230, 0, 0);
            SetDefaultButtonColour((Button)sender);
        }

        private void btnButton5_Click(object sender, EventArgs e)
        {
            btnButton5.BackColor = Color.FromArgb(230, 0, 0);
            SetDefaultButtonColour((Button)sender);
        }

        private void btnButton6_Click(object sender, EventArgs e)
        {
            btnButton6.BackColor = Color.FromArgb(230, 0, 0);
            SetDefaultButtonColour((Button)sender);
        }

        private void SetDefaultButtonColour(Button selected)
        {
            foreach (Button button in uiButtons)
            {
                if (selected != button)
                {
                    button.BackColor = Color.FromArgb(170, 0, 0);
                }
            }
        }

        private void radSentence_CheckedChanged(object sender, EventArgs e)
        {
            if (radSentence.Checked)
            {
                txtPhrase.Enabled = true;
                lblPhrase.Enabled = true;
            }
            else
            {
                txtPhrase.Enabled = false;
                lblPhrase.Enabled = false;
            }
        }
    }
}
