using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

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

        private JoystickSetting currentJoystickSetting;
        private ButtonSetting currentButtonSetting;
        private DeviceSettings settings;

        private bool isJoystickView;

        private bool trayNotifShown;

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

            trkJoystick.MouseWheel += new MouseEventHandler(trackBar_MouseWheel);
            trkCursor.MouseWheel += new MouseEventHandler(trackBar_MouseWheel);

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

                currentJoystickSetting = settings.JoystickSetting;
                currentJoystickSetting.AssignedButton = uiButtons[0];

                for (int i = 0; i < 6; i++)
                {
                    buttonSettings[i].AssignedButton = uiButtons[i + 1];
                }

                mnuStartWithWindows.Checked = settings.RunAtStartup;
                trayNotifShown = true;
            }
            else
            {
                currentJoystickSetting = new JoystickSetting(uiButtons[0]);
                settings.JoystickSetting = currentJoystickSetting;
                for (int i = 0; i < 6; i++)
                {
                    buttonSettings[i] = new ButtonSetting(uiButtons[i + 1]);
                    settings.SetButtonSetting(i + 1, buttonSettings[i]);
                }

                trayNotifShown = false;

                RegistryKey startupKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                if (startupKey.GetValue(Application.ProductName) == null)
                {
                    settings.RunAtStartup = false;
                    mnuStartWithWindows.Checked = false;
                }
                else
                {
                    settings.RunAtStartup = true;
                    mnuStartWithWindows.Checked = true;
                }

            }

            //show warning if programs assigned last session have not been found
            if (settings.NotAllProgramsLoaded)
            {
                MessageBox.Show(this, "One or more programs that were assigned to the buttons have been uninstalled or moved since " +
                    "last run. Their assignments have been removed.", "Custom Mouse Controller - Missing Programs", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (Visible)
                {
                    Focus();
                }
            }

            btnJoystick.PerformClick();
            isJoystickView = true;
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "Closing this application will cause the Custom Mouse to operate only as a basic" +
                " mouse without any additional features such as programmable hotkeys. Are you sure you would like to do this?", "Exiting Custom Mouse Controller",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                settings.SaveSettings();
                HardwareListener.Instance.Dispose();
                Application.Exit();
            }
            else
            {
                if (Visible)
                {
                    Focus();
                }
            }
        }

        private void mnuOpenControlCenter_Click(object sender, EventArgs e)
        {
            Show();
            Focus();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
                if (!trayNotifShown)
                {
                    nfyTrayIcon.ShowBalloonTip(10000, "Custom Mouse Controller is still running in the background.", "Double-click the Custom Mouse Controller tray icon to bring up the Custom Mouse Control Center " +
                        "and change the mouse settings." , ToolTipIcon.Info);
                    trayNotifShown = true;
                }
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
                Focus();
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

            trkCursor.Value = currentJoystickSetting.SpeedMultiplier;
            trkJoystick.Value = currentJoystickSetting.SensitivityMultiplier;
        }

        private void btnButton1_Click(object sender, EventArgs e)
        {
            btnButton1.BackColor = Color.FromArgb(230, 0, 0);
            SetDefaultButtonColour((Button)sender);

            if (isJoystickView)
            {
                SetToButtonLayout();
            }

            currentButtonSetting = buttonSettings[0];
            currentButton = 1;

            LoadButtonSettingsIntoLayout(currentButtonSetting);
        }

        private void btnButton2_Click(object sender, EventArgs e)
        {
            btnButton2.BackColor = Color.FromArgb(230, 0, 0);
            SetDefaultButtonColour((Button)sender);

            if (isJoystickView)
            {
                SetToButtonLayout();
            }

            currentButtonSetting = buttonSettings[1];
            currentButton = 2;

            LoadButtonSettingsIntoLayout(currentButtonSetting);
        }

        private void btnButton3_Click(object sender, EventArgs e)
        {
            btnButton3.BackColor = Color.FromArgb(230, 0, 0);
            SetDefaultButtonColour((Button)sender);

            if (isJoystickView)
            {
                SetToButtonLayout();
            }

            currentButtonSetting = buttonSettings[2];
            currentButton = 3;

            LoadButtonSettingsIntoLayout(currentButtonSetting);
        }

        private void btnButton4_Click(object sender, EventArgs e)
        {
            btnButton4.BackColor = Color.FromArgb(230, 0, 0);
            SetDefaultButtonColour((Button)sender);

            if (isJoystickView)
            {
                SetToButtonLayout();
            }

            currentButtonSetting = buttonSettings[3];
            currentButton = 4;

            LoadButtonSettingsIntoLayout(currentButtonSetting);
        }

        private void btnButton5_Click(object sender, EventArgs e)
        {
            btnButton5.BackColor = Color.FromArgb(230, 0, 0);
            SetDefaultButtonColour((Button)sender);

            if (isJoystickView)
            {
                SetToButtonLayout();
            }

            currentButtonSetting = buttonSettings[4];
            currentButton = 5;

            LoadButtonSettingsIntoLayout(currentButtonSetting);
        }

        private void btnButton6_Click(object sender, EventArgs e)
        {
            btnButton6.BackColor = Color.FromArgb(230, 0, 0);
            SetDefaultButtonColour((Button)sender);

            if (isJoystickView)
            {
                SetToButtonLayout();
            }

            currentButtonSetting = buttonSettings[5];
            currentButton = 6;

            LoadButtonSettingsIntoLayout(currentButtonSetting);
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

            switch (currentButtonSetting.Setting)
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

            txtPhrase.Text = currentButtonSetting.Phrase;
            txtWebsite.Text = currentButtonSetting.WebsiteURL;

            UpdateAssignedProgram();
            UpdateKeyboardShortcut();

        }

        private void radLeftClick_CheckedChanged(object sender, EventArgs e)
        {
            if (radLeftClick.Checked)
            {
                currentButtonSetting.Setting = ButtonSetting.ButtonSettingMode.LeftClick;
                radLeftClick.ForeColor = Color.White;
            }
            else
            {
                radLeftClick.ForeColor = Color.LightGray;
            }
            settings.SetButtonSetting(currentButton, currentButtonSetting);
        }

        private void radRightClick_CheckedChanged(object sender, EventArgs e)
        {
            if (radRightClick.Checked)
            {
                currentButtonSetting.Setting = ButtonSetting.ButtonSettingMode.RightClick;
                radRightClick.ForeColor = Color.White;
            }
            else
            {
                radRightClick.ForeColor = Color.LightGray;
            }
            settings.SetButtonSetting(currentButton, currentButtonSetting);
        }

        private void radOSK_CheckedChanged(object sender, EventArgs e)
        {
            if (radOSK.Checked)
            {
                currentButtonSetting.Setting = ButtonSetting.ButtonSettingMode.OnScreenKeyboard;
                radOSK.ForeColor = Color.White;
            }
            else
            {
                radOSK.ForeColor = Color.LightGray;
            }
            settings.SetButtonSetting(currentButton, currentButtonSetting);
        }

        private void radSentence_CheckedChanged(object sender, EventArgs e)
        {
            if (radSentence.Checked)
            {
                currentButtonSetting.Setting = ButtonSetting.ButtonSettingMode.TypePhrase;
                lblPhrase.ForeColor = Color.White;
                radSentence.ForeColor = Color.White;
                txtPhrase.Enabled = true;
            }
            else
            {
                lblPhrase.ForeColor = Color.LightGray;
                radSentence.ForeColor = Color.LightGray;
                txtPhrase.Enabled = false;
            }
            settings.SetButtonSetting(currentButton, currentButtonSetting);
        }

        private void radProgram_CheckedChanged(object sender, EventArgs e)
        {
            if (radProgram.Checked)
            {
                currentButtonSetting.Setting = ButtonSetting.ButtonSettingMode.OpenProgram;
                lblProgramName.ForeColor = Color.White;
                radProgram.ForeColor = Color.White;
                btnProgramChange.Enabled = true;

                if (currentButtonSetting.ProgramInfo != null)
                {
                    picProgramIcon.Image = currentButtonSetting.ProgramInfo.Icon.ToBitmap();
                }
                else
                {
                    picProgramIcon.Image = Properties.Resources.notAssignedIcon;
                }
            }
            else
            {
                lblProgramName.ForeColor = Color.LightGray;
                radProgram.ForeColor = Color.LightGray;
                btnProgramChange.Enabled = false;

                if (currentButtonSetting.ProgramInfo != null)
                {
                    picProgramIcon.Image = currentButtonSetting.ProgramInfo.GrayscaleIcon.ToBitmap();
                }
                else
                {
                    picProgramIcon.Image = Properties.Resources.notAssignedGrayscaleIcon;
                }
            }

            settings.SetButtonSetting(currentButton, currentButtonSetting);
        }


        private void radWebsite_CheckedChanged(object sender, EventArgs e)
        {
            if (radWebsite.Checked)
            {
                currentButtonSetting.Setting = ButtonSetting.ButtonSettingMode.OpenWebsite;
                lblWebsite.ForeColor = Color.White;
                radWebsite.ForeColor = Color.White;
                txtWebsite.Enabled = true;
            }
            else
            {
                lblWebsite.ForeColor = Color.LightGray;
                radWebsite.ForeColor = Color.LightGray;
                txtWebsite.Enabled = false;
            }
            settings.SetButtonSetting(currentButton, currentButtonSetting);
        }

        private void radShortcut_CheckedChanged(object sender, EventArgs e)
        {
            if (radShortcut.Checked)
            {
                currentButtonSetting.Setting = ButtonSetting.ButtonSettingMode.KeyboardShortcut;
                lblShortcut.ForeColor = Color.White;
                radShortcut.ForeColor = Color.White;
                btnKeyboardShortcutChange.Enabled = true;
            }
            else
            {
                lblShortcut.ForeColor = Color.LightGray;
                radShortcut.ForeColor = Color.LightGray;
                btnKeyboardShortcutChange.Enabled = false;
            }
            settings.SetButtonSetting(currentButton, currentButtonSetting);
        }

        private void txtPhrase_TextChanged(object sender, EventArgs e)
        {
            currentButtonSetting.Phrase = txtPhrase.Text;
        }

        private void txtWebsite_TextChanged(object sender, EventArgs e)
        {
            currentButtonSetting.WebsiteURL = txtWebsite.Text;
        }

        private void btnKeyboardShortcutChange_Click(object sender, EventArgs e)
        {
            using (FrmKeyboardShortcut dialog = new FrmKeyboardShortcut(currentButtonSetting))
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
            using (FrmSelectProgram dialog = new FrmSelectProgram(currentButtonSetting))
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
            if (currentButtonSetting.KeyCombination == null)
            {
                lblShortcut.Text = "Not Assigned";
            }
            else
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("Assigned: ");
                string[] keys = currentButtonSetting.KeyCombination;

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

            if (currentButtonSetting.ProgramInfo == null)
            {
                lblProgramName.Text = "Not Assigned";
                if (!radProgram.Checked)
                {
                    picProgramIcon.Image = Properties.Resources.notAssignedGrayscaleIcon;
                }
                else if (radProgram.Checked &&
                  (picProgramIcon.Image == null || !picProgramIcon.Image.Equals(Properties.Resources.notAssignedIcon)))
                {
                    picProgramIcon.Image = Properties.Resources.notAssignedIcon;
                }
            }
            else
            {
                lblProgramName.Text = currentButtonSetting.ProgramInfo.Name;

                if (!radProgram.Checked)
                {
                    picProgramIcon.Image = currentButtonSetting.ProgramInfo.GrayscaleIcon.ToBitmap();
                } else if (radProgram.Checked &&
                    (picProgramIcon.Image == null || !picProgramIcon.Image.Equals(currentButtonSetting.ProgramInfo.Icon.ToBitmap())))
                {
                    picProgramIcon.Image = currentButtonSetting.ProgramInfo.Icon.ToBitmap();
                }
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

        private void trackBar_MouseWheel(object sender, EventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void trkJoystick_ValueChanged(object sender, EventArgs e)
        {
            currentJoystickSetting.SensitivityMultiplier = trkJoystick.Value;
        }

        private void trkCursor_ValueChanged(object sender, EventArgs e)
        {
            currentJoystickSetting.SpeedMultiplier = trkCursor.Value;
        }

        private void mnuStartWithWindows_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey startupKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (mnuStartWithWindows.Checked)
            {
                if (!settings.RunAtStartup)
                {
                    startupKey.SetValue(Application.ProductName, Application.ExecutablePath);
                    if (!settings.RunAtStartup)
                    {
                        settings.RunAtStartup = true;
                    }
                }
            }
            else
            {
                if (settings.RunAtStartup)
                {
                    DialogResult result = MessageBox.Show(this, "Not starting Custom Mouse Controller with Windows will result in the Custom Mouse operating " +
                        "only as a basic mouse without additional functionality such as programmable hotkeys. Custom Mouse Controller will have to be started " +
                        "manually after login to gain access to these features. Are you sure you would like to do this?", "Start Custom Mouse Controller with Windows", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button2);

                    if (result == DialogResult.Yes)
                    {
                        startupKey.DeleteValue(Application.ProductName, false);
                        settings.RunAtStartup = false;
                    }
                    else
                    {
                        mnuStartWithWindows.Checked = true;
                    }
                    if (Visible)
                    {
                        Focus();
                    }
                }
            }
        }
    }
}
