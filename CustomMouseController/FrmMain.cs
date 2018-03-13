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

            settings = DeviceSettings.Instance;
            buttonSettings = new ButtonSetting[6];

            if (settings.LoadedPreviousSession)
            {
                buttonSettings[0] = settings.GetButtonSetting(1);
                buttonSettings[1] = settings.GetButtonSetting(2);
                buttonSettings[2] = settings.GetButtonSetting(3);
                buttonSettings[3] = settings.GetButtonSetting(4);
                buttonSettings[4] = settings.GetButtonSetting(5);
                buttonSettings[5] = settings.GetButtonSetting(6);

                for (int i = 0; i < 6; i++)
                {
                    buttonSettings[i].AssignedButton = uiButtons[i + 1];
                }
            }
            else
            {
                for (int i = 0; i < 6; i++)
                {
                    buttonSettings[i] = new ButtonSetting(uiButtons[i + 1]);
                    settings.SetButtonSetting(i + 1, buttonSettings[i]);
                }
            }

            //show warning if programs assigned last session have not been found
            if (settings.NotAllProgramsLoaded)
            {
                MessageBox.Show("One or more programs that were assigned to the buttons have been uninstalled or moved since " +
                    "last run. Their assignments have been removed.", "Custom Mouse Controller - Missing Programs", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            btnJoystick.PerformClick();
            isJoystickView = true;

        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Closing this application will cause the Custom Mouse to operate only as a basic" +
                " mouse without any additional features such as programmable hotkeys. Are you sure you would like to do this?", "Exiting Custom Mouse Controller",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                settings.SaveSettings();
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

            if (e.CloseReason == CloseReason.WindowsShutDown)
            {
                settings.SaveSettings();
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
            radWebsite.Visible = false;
            radShortcut.Visible = false;

            lblPhrase.Visible = false;
            txtPhrase.Visible = false;
            picProgramIcon.Visible = false;
            lblProgramName.Visible = false;
            lblWebsite.Visible = false;
            txtWebsite.Visible = false;
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
            radWebsite.Visible = true;
            radShortcut.Visible = true;

            lblPhrase.Visible = true;
            txtPhrase.Visible = true;
            picProgramIcon.Visible = true;
            lblProgramName.Visible = true;
            lblWebsite.Visible = true;
            txtWebsite.Visible = true;
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
                    radWebsite.Checked = false;
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
                case ButtonSetting.ButtonSettingMode.OpenWebsite:
                    radWebsite.Select();
                    break;
                case ButtonSetting.ButtonSettingMode.KeyboardShortcut:
                    radShortcut.Select();
                    break;
            }

            txtPhrase.Text = currentSetting.Phrase;
            txtWebsite.Text = currentSetting.WebsiteURL;

            UpdateAssignedProgram();
            UpdateKeyboardShortcut();

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


        private void radWebsite_CheckedChanged(object sender, EventArgs e)
        {
            if (radWebsite.Checked)
                currentSetting.Setting = ButtonSetting.ButtonSettingMode.OpenWebsite;
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

        private void txtWebsite_TextChanged(object sender, EventArgs e)
        {
            currentSetting.WebsiteURL = txtWebsite.Text;
        }

        private void btnKeyboardShortcutChange_Click(object sender, EventArgs e)
        {
            using (FrmKeyboardShortcut dialog = new FrmKeyboardShortcut(currentSetting))
            {
                dialog.ShowDialog();
                if (dialog.DialogResult == DialogResult.OK)
                {
                    UpdateKeyboardShortcut();
                }
            }
        }

        private void btnProgramChange_Click(object sender, EventArgs e)
        {
            using (FrmSelectProgram dialog = new FrmSelectProgram(currentSetting))
            {
                dialog.ShowDialog();
                if (dialog.DialogResult == DialogResult.OK)
                {
                    UpdateAssignedProgram();
                }
            }
        }

        private void UpdateKeyboardShortcut()
        {
            if (currentSetting.KeyCombination == null)
            {
                lblShortcut.Text = "Not Assigned";
            }
            else
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("Assigned: ");
                string[] keys = currentSetting.KeyCombination;

                for (int i = 0; i < keys.Length; i++)
                {
                    if (keys[i] == null)
                        break;

                    if (i == 0)
                    {
                        builder.Append(keys[i]);
                    }
                    else
                    {
                        builder.Append("+" + keys[i]);
                    }
                }

                lblShortcut.Text = builder.ToString();
            }

            lblShortcut.AutoSize = true;

            Point newLocation = new Point(lblShortcut.Location.X + lblShortcut.Size.Width + 4, btnKeyboardShortcutChange.Location.Y);

            if (newLocation.X > txtPhrase.Location.X + txtPhrase.Size.Width - btnKeyboardShortcutChange.Width)
            {
                newLocation = new Point(txtPhrase.Location.X + txtPhrase.Size.Width - btnKeyboardShortcutChange.Width, newLocation.Y);
                btnKeyboardShortcutChange.Location = newLocation;
                int height = lblShortcut.Height;
                lblShortcut.AutoSize = false;
                lblShortcut.Height = height;
                lblShortcut.Width = btnKeyboardShortcutChange.Location.X - lblShortcut.Location.X;
            }
            else
            {
                btnKeyboardShortcutChange.Location = newLocation;
            }
        }

        private void UpdateAssignedProgram()
        {

            if (currentSetting.ProgramInfo == null)
            {
                lblProgramName.Text = "Not Assigned";
                picProgramIcon.Image = null;
            }
            else
            {
                lblProgramName.Text = currentSetting.ProgramInfo.Name;
                picProgramIcon.Image = currentSetting.ProgramInfo.Icon.ToBitmap();
            }

            lblProgramName.AutoSize = true;

            Point newLocation = new Point(lblProgramName.Location.X + lblProgramName.Size.Width + 4, btnProgramChange.Location.Y);

            if (newLocation.X > txtPhrase.Location.X + txtPhrase.Size.Width - btnProgramChange.Width)
            {
                newLocation = new Point(txtPhrase.Location.X + txtPhrase.Size.Width - btnProgramChange.Width, newLocation.Y);
                btnProgramChange.Location = newLocation;
                int height = lblProgramName.Height;
                lblProgramName.AutoSize = false;
                lblProgramName.Height = height;
                lblProgramName.Width = btnProgramChange.Location.X - lblProgramName.Location.X;
            }
            else
            {
                btnProgramChange.Location = newLocation;
            }
        }
    }
}
