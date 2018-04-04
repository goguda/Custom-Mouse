/*
 * File: FrmMain.cs
 * Contains: FrmMain class
 * 
 * This class controls the main UI and takes care of button and
 * joystick setting assignment.
 * 
 * Author: David Goguen
 * Original release: March 26, 2018
 * 
 * Last updated: April 4, 2018
 * 
 */

using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32.TaskScheduler;

namespace CustomMouseController
{
    public partial class FrmMain : Form
    {
        /* stores reference to UI buttons for quicker colour change */
        private Button[] uiButtons;

        /* stores reference to ButtonSetting instance for each of the 6 buttons */
        private ButtonSetting[] buttonSettings;

        /* stores the button number of the button that is currently being modified */
        private int currentButton;

        /* stores a reference to the ButtonSetting instance associated with the button being modified */
        private ButtonSetting currentButtonSetting;

        /* stores a reference to the settings for the joystick */
        private JoystickSetting currentJoystickSetting;

        /* stores a reference to the device settings instance */
        private DeviceSettings settings;

        /* stores whether or not the UI is currently showing the joystick settings view */
        private bool isJoystickView;

        /* stores whether or not a tray notification has already been showing saying Custom Mouse Controller is running in the background */
        private bool trayNotifShown;

        /*
         * Main constructor for main form.
         */
        public FrmMain()
        {
            InitializeComponent();
        }

        /*
         * Initializes form values upon load and loads previous settings
         * into UI, if available. If not, settings are initialized to
         * defaults.
         */
        private void FrmMain_Load(object sender, EventArgs e)
        {
            // get UI button references
            uiButtons = new Button[7];

            uiButtons[0] = btnJoystick;
            uiButtons[1] = btnButton1;
            uiButtons[2] = btnButton2;
            uiButtons[3] = btnButton3;
            uiButtons[4] = btnButton4;
            uiButtons[5] = btnButton5;
            uiButtons[6] = btnButton6;

            // scroll wheel event handlers so the scroll wheel cannot control the trackbars in joystick view
            trkJoystick.MouseWheel += new MouseEventHandler(trackBar_MouseWheel);
            trkCursor.MouseWheel += new MouseEventHandler(trackBar_MouseWheel);

            // load settings
            settings = DeviceSettings.Instance;
            buttonSettings = new ButtonSetting[6];

            // if previous settings were loaded, update the UI to reflect them
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
            else // set default values if not
            {
                currentJoystickSetting = new JoystickSetting(uiButtons[0]);
                settings.JoystickSetting = currentJoystickSetting;
                for (int i = 0; i < 6; i++)
                {
                    buttonSettings[i] = new ButtonSetting(uiButtons[i + 1]);
                    settings.SetButtonSetting(i + 1, buttonSettings[i]);
                }

                trayNotifShown = false;

                // since we don't know if the application is to run at startup
                // from device settings since a previous session was not loaded,
                // check if the task exists and update device settings accordingly
                using (TaskService scheduler = new TaskService())
                {
                    if (scheduler.GetTask("Custom Mouse Controller") == null)
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

            // start out on joystick view since it is the first button
            btnJoystick.PerformClick();
            isJoystickView = true;
        }

        /*
         * Shows a notification asking the user if they are sure they would
         * like to exit the application when the Exit tray menu item has been
         * clicked, and cleanly closes the application if yes.
         */
        private void mnuExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "Closing this application will cause the Custom Mouse to operate only as a basic" +
                " mouse without any additional features such as programmable hotkeys. Are you sure you would like to do this?", "Exiting Custom Mouse Controller",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                settings.SaveSettings();
                HardwareListener.Instance.Dispose();
                // the HardwareListener thread is exited from Program.cs after the UI thread to prevent
                // an issue where the stop signal is not sent to the Arduino
                Application.ExitThread();
            }
            else
            {
                if (Visible)
                {
                    Focus();
                }
            }
        }

        /*
         * Shows the Custom Mouse Control Center when the Open Control Center tray
         * menu item has been clicked.
         */
        private void mnuOpenControlCenter_Click(object sender, EventArgs e)
        {
            Show();
            Focus();
        }

        /*
         * Minimizes the Control Center to the system tray if the user has pressed
         * the 'X' button instead of completely closing it.
         */
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
                
                // Show running in background notification if it has never been shown
                if (!trayNotifShown)
                {
                    nfyTrayIcon.ShowBalloonTip(10000, "Custom Mouse Controller is still running in the background.", "Double-click the Custom Mouse Controller tray icon to bring up the Custom Mouse Control Center " +
                        "and change the mouse settings." , ToolTipIcon.Info);
                    trayNotifShown = true;
                }
            }

            // cleanly exit application if system is shutting down or application is being shut down
            // from Task Manager
            if (e.CloseReason == CloseReason.TaskManagerClosing || e.CloseReason == CloseReason.WindowsShutDown)
            {
                settings.SaveSettings();
                HardwareListener.Instance.Dispose();
                Application.ExitThread();
            }
        }

        /*
         * Shows the Custom Mouse Control Center when the system tray icon is double-clicked.
         */
        private void nfyTrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Show();
                Focus();
            }
        }

        /*
         * Loads joystick view and settings into UI when Joystick button is clicked.
         */
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

        /*
         * Loads button view and button 1 settings into UI when Button 1
         * button is clicked.
         */
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

        /*
         * Loads button view and button 2 settings into UI when Button 2
         * button is clicked.
         */
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

        /*
         * Loads button view and button 3 settings into UI when Button 3
         * button is clicked.
         */
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

        /*
         * Loads button view and button 4 settings into UI when Button 4
         * button is clicked.
         */
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

        /*
         * Loads button view and button 5 settings into UI when Button 5
         * button is clicked.
         */
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

        /*
         * Loads button view and button 6 settings into UI when Button 6
         * button is clicked.
         */
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

        /*
         * Sets all buttons to their default colour except for the selected
         * button.
         */
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

        /*
         * Sets the layout of the form to the layout for the joystick
         * settings.
         */
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

        /*
         * Sets the layout of the form to the layout for the button
         * settings.
         */
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

        /*
         * Loads the values from the ButtonSettings instance passed as an argument
         * into the UI.
         */
        private void LoadButtonSettingsIntoLayout(ButtonSetting settings)
        {
            if (isJoystickView) // don't do anything if we're not in button view
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

        /*
         * Updates current button's settings and update UI colours to reflect
         * Left Click being selected.
         */
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

        /*
         * Updates current button's settings and update UI colours to reflect
         * Right Click being selected.
         */
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

        /*
         * Updates current button's settings and update UI colours to reflect
         * On Screen Keyboard being selected.
         */
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

        /*
         * Updates current button's settings and update UI colours to reflect
         * Type a Phrase being selected.
         */
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

        /*
         * Updates current button's settings and update UI colours to reflect
         * Open a Program being selected.
         */
        private void radProgram_CheckedChanged(object sender, EventArgs e)
        {
            if (radProgram.Checked)
            {
                currentButtonSetting.Setting = ButtonSetting.ButtonSettingMode.OpenProgram;
                lblProgramName.ForeColor = Color.White;
                radProgram.ForeColor = Color.White;
                btnProgramChange.Enabled = true;

                // set program icon
                if (currentButtonSetting.ProgramInfo != null) 
                {
                    picProgramIcon.Image = currentButtonSetting.ProgramInfo.Icon.ToBitmap();
                }
                else // set not assigned icon if nothing is assigned to this button yet
                {
                    picProgramIcon.Image = Properties.Resources.notAssignedIcon;
                }
            }
            else // set gray icon and labels if not selected
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

        /*
         * Updates current button's settings and update UI colours to reflect
         * Open a Website being selected.
         */
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

        /*
         * Updates current button's settings and update UI colours to reflect
         * Perform Keyboard Shortcut being selected.
         */
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

        /*
         * Updates assigned phrase to current button's settings in real-time
         * if it has been changed.
         */
        private void txtPhrase_TextChanged(object sender, EventArgs e)
        {
            currentButtonSetting.Phrase = txtPhrase.Text;
        }

        /*
         * Updates assigned website to current button's settings in real-time
         * if it has been changed.
         */
        private void txtWebsite_TextChanged(object sender, EventArgs e)
        {
            currentButtonSetting.WebsiteURL = txtWebsite.Text;
        }

        /*
         * Shows keyboard shortcut form when button to change keyboard shortcut
         * is clicked and updates UI to reflect change afterward.
         */
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

        /*
         * Shows select program form when button to change assigned program
         * is clicked and updates UI to reflect change afterward.
         */
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

        /*
         * Updates the keyboard shortcut label in the UI from the plain text
         * shortcut array associated with the current button's settings.
         */
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


            // place change button right after label
            lblShortcut.AutoSize = true;

            Point newLocation = new Point(lblShortcut.Location.X + lblShortcut.Size.Width + 4, btnKeyboardShortcutChange.Location.Y);

            // don't allow button to be pushed off of UI by label
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

        /*
         * Updates the assigned program label and icon in the UI from the
         * ProgramInfo instance associated with the current button's settings.
         */
        private void UpdateAssignedProgram()
        {

            if (currentButtonSetting.ProgramInfo == null) // no program assigned
            {
                lblProgramName.Text = "Not Assigned";
                if (!radProgram.Checked) // Open a Program not selected radio button
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

            // place change button right after label
            lblProgramName.AutoSize = true;

            Point newLocation = new Point(lblProgramName.Location.X + lblProgramName.Size.Width + 4, btnProgramChange.Location.Y);

            // don't allow button to be pushed off of UI by label
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

        /*
         * Ignores scroll wheel movement when cursor is on trackbars in joystick
         * view so that their values don't change with the motion of the scroll
         * wheel.
         */
        private void trackBar_MouseWheel(object sender, EventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        /*
         * Updates the value of the joystick sensitivity multiplier in the device
         * settings whenever its value is changed.
         */
        private void trkJoystick_ValueChanged(object sender, EventArgs e)
        {
            currentJoystickSetting.SensitivityMultiplier = trkJoystick.Value;
        }

        /*
         * Updates the value of the cursor speed multiplier in the device
         * settings whenever its value is changed.
         */
        private void trkCursor_ValueChanged(object sender, EventArgs e)
        {
            currentJoystickSetting.SpeedMultiplier = trkCursor.Value;
        }

        /*
         * Updates the device settings and task scheduler whenever the Start with Windows
         * tray menu item is checked or unchecked. Displays a message box asking the user
         * if they are sure they would like to disable run at startup if it is currently
         * enabled and they uncheck the box.
         */
        private void mnuStartWithWindows_CheckedChanged(object sender, EventArgs e)
        {
            using (TaskService scheduler = new TaskService())
            {
                if (mnuStartWithWindows.Checked)
                {
                    if (!settings.RunAtStartup)
                    {
                        TaskDefinition def = scheduler.NewTask();
                        def.Triggers.Add(new LogonTrigger());
                        def.Principal.RunLevel = TaskRunLevel.Highest;
                        def.Actions.Add(new ExecAction(Application.ExecutablePath));
                        scheduler.RootFolder.RegisterTaskDefinition("Custom Mouse Controller", def);
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
                            scheduler.RootFolder.DeleteTask("Custom Mouse Controller", false);
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
}
