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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        // Store references to buttons for quicker colour change
        private Button[] uiButtons;

        private ButtonSetting[] buttonSettings;

        private int currentButton;
        private ButtonSetting currentSetting;

        private DeviceSettings settings;

        private bool isJoystickView;

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

            buttonSettings = new ButtonSetting[6];

            for (int i = 0; i < 6; i++)
            {
                buttonSettings[i] = new ButtonSetting(uiButtons[i + 1]);
            }

            btnJoystick.PerformClick();
            isJoystickView = true;

            settings = DeviceSettings.Instance;
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Closing this application will cause the Custom Mouse to operate only as a basic" +
                " mouse without additional features such as programmable hotkeys. Are you sure you would like to do this?", "Exiting Custom Mouse Controller",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
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

            if (!isJoystickView)
            {
                SetToJoystickLayout();

            }
        }

        private void btnButton1_Click(object sender, EventArgs e)
        {
            btnButton1.BackColor = Color.FromArgb(230, 0, 0);
            SetDefaultButtonColour((Button)sender);

            if (isJoystickView)
            {
                SetToButtonLayout();
            }

            currentSetting = buttonSettings[0];
            currentButton = 1;

            LoadButtonSettingsIntoLayout(currentSetting);
        }

        private void btnButton2_Click(object sender, EventArgs e)
        {
            btnButton2.BackColor = Color.FromArgb(230, 0, 0);
            SetDefaultButtonColour((Button)sender);

            if (isJoystickView)
            {
                SetToButtonLayout();
            }

            currentSetting = buttonSettings[1];
            currentButton = 2;

            LoadButtonSettingsIntoLayout(currentSetting);
        }

        private void btnButton3_Click(object sender, EventArgs e)
        {
            btnButton3.BackColor = Color.FromArgb(230, 0, 0);
            SetDefaultButtonColour((Button)sender);

            if (isJoystickView)
            {
                SetToButtonLayout();
            }

            currentSetting = buttonSettings[2];
            currentButton = 3;

            LoadButtonSettingsIntoLayout(currentSetting);
        }

        private void btnButton4_Click(object sender, EventArgs e)
        {
            btnButton4.BackColor = Color.FromArgb(230, 0, 0);
            SetDefaultButtonColour((Button)sender);

            if (isJoystickView)
            {
                SetToButtonLayout();
            }

            currentSetting = buttonSettings[3];
            currentButton = 4;

            LoadButtonSettingsIntoLayout(currentSetting);
        }

        private void btnButton5_Click(object sender, EventArgs e)
        {
            btnButton5.BackColor = Color.FromArgb(230, 0, 0);
            SetDefaultButtonColour((Button)sender);

            if (isJoystickView)
            {
                SetToButtonLayout();
            }

            currentSetting = buttonSettings[4];
            currentButton = 5;

            LoadButtonSettingsIntoLayout(currentSetting);
        }

        private void btnButton6_Click(object sender, EventArgs e)
        {
            btnButton6.BackColor = Color.FromArgb(230, 0, 0);
            SetDefaultButtonColour((Button)sender);

            if (isJoystickView)
            {
                SetToButtonLayout();
            }

            currentSetting = buttonSettings[5];
            currentButton = 6;

            LoadButtonSettingsIntoLayout(currentSetting);
        }

        private void SetDefaultButtonColour(Button selected)
        {
            foreach (Button button in uiButtons)
            {
                if (selected != button)
                {
                    button.BackColor = Color.FromArgb(170, 0, 0);
                    button.FlatAppearance.MouseOverBackColor = Color.Empty;
                    button.FlatAppearance.MouseDownBackColor = Color.FromArgb(204, 0, 0);
                }
            }

            selected.FlatAppearance.MouseOverBackColor = Color.FromArgb(230, 0, 0);
            selected.FlatAppearance.MouseDownBackColor = Color.FromArgb(230, 0, 0);
        }

        private void SetToJoystickLayout()
        {
            lblJoystickSensitivity.Visible = true;
            lblJoystickDescription.Visible = true;
            lblLessSensitive.Visible = true;
            lblMoreSensitive.Visible = true;
            lblCursorSpeed.Visible = true;
            lblCursorDescription.Visible = true;
            lblSlower.Visible = true;
            lblFaster.Visible = true;

            trkJoystick.Visible = true;
            trkCursor.Visible = true;

            radLeftClick.Visible = false;
            radRightClick.Visible = false;
            radOSK.Visible = false;
            radSentence.Visible = false;
            radProgram.Visible = false;
            radShortcut.Visible = false;

            lblPhrase.Visible = false;
            txtPhrase.Visible = false;
            picProgramIcon.Visible = false;
            lblProgramName.Visible = false;
            lblShortcut.Visible = false;

            btnProgramChange.Visible = false;
            btnKeyboardShortcutChange.Visible = false;

            isJoystickView = true;
        }

        private void SetToButtonLayout()
        {
            radLeftClick.Visible = true;
            radRightClick.Visible = true;
            radOSK.Visible = true;
            radSentence.Visible = true;
            radProgram.Visible = true;
            radShortcut.Visible = true;

            lblPhrase.Visible = true;
            txtPhrase.Visible = true;
            picProgramIcon.Visible = true;
            lblProgramName.Visible = true;
            lblShortcut.Visible = true;

            btnProgramChange.Visible = true;
            btnKeyboardShortcutChange.Visible = true;

            lblJoystickSensitivity.Visible = false;
            lblJoystickDescription.Visible = false;
            lblLessSensitive.Visible = false;
            lblMoreSensitive.Visible = false;
            lblCursorSpeed.Visible = false;
            lblCursorDescription.Visible = false;
            lblSlower.Visible = false;
            lblFaster.Visible = false;

            trkJoystick.Visible = false;
            trkCursor.Visible = false;

            isJoystickView = false;
        }

        private void LoadButtonSettingsIntoLayout(ButtonSetting settings)
        {
            if (isJoystickView)
                return;

            switch (currentSetting.Setting)
            {
                case ButtonSetting.ButtonSettingMode.None:
                    radLeftClick.Checked = false;
                    radRightClick.Checked = false;
                    radOSK.Checked = false;
                    radSentence.Checked = false;
                    radProgram.Checked = false;
                    radShortcut.Checked = false;
                    break;
                case ButtonSetting.ButtonSettingMode.LeftClick:
                    radLeftClick.Select();
                    break;
                case ButtonSetting.ButtonSettingMode.RightClick:
                    radRightClick.Select();
                    break;
                case ButtonSetting.ButtonSettingMode.OnScreenKeyboard:
                    radOSK.Select();
                    break;
                case ButtonSetting.ButtonSettingMode.TypePhrase:
                    radSentence.Select();
                    break;
                case ButtonSetting.ButtonSettingMode.OpenProgram:
                    radProgram.Select();
                    break;
                case ButtonSetting.ButtonSettingMode.KeyboardShortcut:
                    radShortcut.Select();
                    break;
            }

            txtPhrase.Text = currentSetting.Phrase;
        }

        private void radLeftClick_CheckedChanged(object sender, EventArgs e)
        {
            if (radLeftClick.Checked)
                currentSetting.Setting = ButtonSetting.ButtonSettingMode.LeftClick;
            settings.SetButtonSetting(currentButton, currentSetting);
        }

        private void radRightClick_CheckedChanged(object sender, EventArgs e)
        {
            if (radRightClick.Checked)
                currentSetting.Setting = ButtonSetting.ButtonSettingMode.RightClick;
            settings.SetButtonSetting(currentButton, currentSetting);
        }

        private void radOSK_CheckedChanged(object sender, EventArgs e)
        {
            if (radOSK.Checked)
                currentSetting.Setting = ButtonSetting.ButtonSettingMode.OnScreenKeyboard;
            settings.SetButtonSetting(currentButton, currentSetting);
        }

        private void radSentence_CheckedChanged(object sender, EventArgs e)
        {
            if (radSentence.Checked)
                currentSetting.Setting = ButtonSetting.ButtonSettingMode.TypePhrase;
            settings.SetButtonSetting(currentButton, currentSetting);
        }

        private void radProgram_CheckedChanged(object sender, EventArgs e)
        {
            if (radProgram.Checked)
                currentSetting.Setting = ButtonSetting.ButtonSettingMode.OpenProgram;
            settings.SetButtonSetting(currentButton, currentSetting);
        }

        private void radShortcut_CheckedChanged(object sender, EventArgs e)
        {
            if (radShortcut.Checked)
                currentSetting.Setting = ButtonSetting.ButtonSettingMode.KeyboardShortcut;
            settings.SetButtonSetting(currentButton, currentSetting);
        }

        private void txtPhrase_TextChanged(object sender, EventArgs e)
        {
            currentSetting.Phrase = txtPhrase.Text;
        }

        private void btnKeyboardShortcutChange_Click(object sender, EventArgs e)
        {
            FrmKeyboardShortcut dialog = new FrmKeyboardShortcut();
            dialog.ShowDialog();
        }

        private void btnProgramChange_Click(object sender, EventArgs e)
        {
            FrmSelectProgram dialog = new FrmSelectProgram();
            dialog.ShowDialog();
        }
    }
}
