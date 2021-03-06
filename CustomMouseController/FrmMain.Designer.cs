﻿namespace CustomMouseController
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.nfyTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cxtTrayIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuOpenControlCenter = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuStartWithWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlInputSelection = new System.Windows.Forms.Panel();
            this.btnButton6 = new System.Windows.Forms.Button();
            this.btnButton5 = new System.Windows.Forms.Button();
            this.btnButton4 = new System.Windows.Forms.Button();
            this.btnButton3 = new System.Windows.Forms.Button();
            this.btnButton2 = new System.Windows.Forms.Button();
            this.btnButton1 = new System.Windows.Forms.Button();
            this.btnJoystick = new System.Windows.Forms.Button();
            this.grpSettings = new System.Windows.Forms.GroupBox();
            this.trkJoystick = new System.Windows.Forms.TrackBar();
            this.lblCursorSpeed = new System.Windows.Forms.Label();
            this.radProgram = new System.Windows.Forms.RadioButton();
            this.lblJoystickSensitivity = new System.Windows.Forms.Label();
            this.lblSlower = new System.Windows.Forms.Label();
            this.lblFaster = new System.Windows.Forms.Label();
            this.lblLessSensitive = new System.Windows.Forms.Label();
            this.lblMoreSensitive = new System.Windows.Forms.Label();
            this.txtWebsite = new System.Windows.Forms.TextBox();
            this.lblWebsite = new System.Windows.Forms.Label();
            this.radWebsite = new System.Windows.Forms.RadioButton();
            this.radRightClick = new System.Windows.Forms.RadioButton();
            this.btnKeyboardShortcutChange = new System.Windows.Forms.Button();
            this.lblShortcut = new System.Windows.Forms.Label();
            this.radShortcut = new System.Windows.Forms.RadioButton();
            this.btnProgramChange = new System.Windows.Forms.Button();
            this.lblProgramName = new System.Windows.Forms.Label();
            this.picProgramIcon = new System.Windows.Forms.PictureBox();
            this.txtPhrase = new System.Windows.Forms.TextBox();
            this.lblPhrase = new System.Windows.Forms.Label();
            this.radSentence = new System.Windows.Forms.RadioButton();
            this.radOSK = new System.Windows.Forms.RadioButton();
            this.radLeftClick = new System.Windows.Forms.RadioButton();
            this.trkCursor = new System.Windows.Forms.TrackBar();
            this.lblCursorDescription = new System.Windows.Forms.Label();
            this.lblJoystickDescription = new System.Windows.Forms.Label();
            this.cxtTrayIcon.SuspendLayout();
            this.pnlInputSelection.SuspendLayout();
            this.grpSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkJoystick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProgramIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkCursor)).BeginInit();
            this.SuspendLayout();
            // 
            // nfyTrayIcon
            // 
            this.nfyTrayIcon.ContextMenuStrip = this.cxtTrayIcon;
            this.nfyTrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("nfyTrayIcon.Icon")));
            this.nfyTrayIcon.Text = "Custom Mouse Controller";
            this.nfyTrayIcon.Visible = true;
            this.nfyTrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.nfyTrayIcon_MouseDoubleClick);
            // 
            // cxtTrayIcon
            // 
            this.cxtTrayIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpenControlCenter,
            this.toolStripSeparator2,
            this.mnuStartWithWindows,
            this.toolStripSeparator1,
            this.mnuExit});
            this.cxtTrayIcon.Name = "cxtTrayIcon";
            this.cxtTrayIcon.Size = new System.Drawing.Size(317, 104);
            // 
            // mnuOpenControlCenter
            // 
            this.mnuOpenControlCenter.Name = "mnuOpenControlCenter";
            this.mnuOpenControlCenter.Size = new System.Drawing.Size(316, 22);
            this.mnuOpenControlCenter.Text = "Open Control Center";
            this.mnuOpenControlCenter.Click += new System.EventHandler(this.mnuOpenControlCenter_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(313, 6);
            // 
            // mnuStartWithWindows
            // 
            this.mnuStartWithWindows.CheckOnClick = true;
            this.mnuStartWithWindows.Name = "mnuStartWithWindows";
            this.mnuStartWithWindows.Size = new System.Drawing.Size(316, 22);
            this.mnuStartWithWindows.Text = "Start Custom Mouse Controller with Windows";
            this.mnuStartWithWindows.CheckedChanged += new System.EventHandler(this.mnuStartWithWindows_CheckedChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(313, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(316, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // pnlInputSelection
            // 
            this.pnlInputSelection.BackColor = System.Drawing.Color.Transparent;
            this.pnlInputSelection.Controls.Add(this.btnButton6);
            this.pnlInputSelection.Controls.Add(this.btnButton5);
            this.pnlInputSelection.Controls.Add(this.btnButton4);
            this.pnlInputSelection.Controls.Add(this.btnButton3);
            this.pnlInputSelection.Controls.Add(this.btnButton2);
            this.pnlInputSelection.Controls.Add(this.btnButton1);
            this.pnlInputSelection.Controls.Add(this.btnJoystick);
            this.pnlInputSelection.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlInputSelection.Location = new System.Drawing.Point(0, 0);
            this.pnlInputSelection.Margin = new System.Windows.Forms.Padding(2);
            this.pnlInputSelection.Name = "pnlInputSelection";
            this.pnlInputSelection.Size = new System.Drawing.Size(213, 455);
            this.pnlInputSelection.TabIndex = 1;
            // 
            // btnButton6
            // 
            this.btnButton6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnButton6.FlatAppearance.BorderSize = 0;
            this.btnButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnButton6.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnButton6.ForeColor = System.Drawing.Color.White;
            this.btnButton6.Location = new System.Drawing.Point(0, 390);
            this.btnButton6.Margin = new System.Windows.Forms.Padding(2);
            this.btnButton6.Name = "btnButton6";
            this.btnButton6.Size = new System.Drawing.Size(213, 65);
            this.btnButton6.TabIndex = 0;
            this.btnButton6.TabStop = false;
            this.btnButton6.Text = "Button 6";
            this.btnButton6.UseVisualStyleBackColor = false;
            this.btnButton6.Click += new System.EventHandler(this.btnButton6_Click);
            // 
            // btnButton5
            // 
            this.btnButton5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnButton5.FlatAppearance.BorderSize = 0;
            this.btnButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnButton5.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnButton5.ForeColor = System.Drawing.Color.White;
            this.btnButton5.Location = new System.Drawing.Point(0, 325);
            this.btnButton5.Margin = new System.Windows.Forms.Padding(2);
            this.btnButton5.Name = "btnButton5";
            this.btnButton5.Size = new System.Drawing.Size(213, 65);
            this.btnButton5.TabIndex = 0;
            this.btnButton5.TabStop = false;
            this.btnButton5.Text = "Button 5";
            this.btnButton5.UseVisualStyleBackColor = false;
            this.btnButton5.Click += new System.EventHandler(this.btnButton5_Click);
            // 
            // btnButton4
            // 
            this.btnButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnButton4.FlatAppearance.BorderSize = 0;
            this.btnButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnButton4.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnButton4.ForeColor = System.Drawing.Color.White;
            this.btnButton4.Location = new System.Drawing.Point(0, 260);
            this.btnButton4.Margin = new System.Windows.Forms.Padding(2);
            this.btnButton4.Name = "btnButton4";
            this.btnButton4.Size = new System.Drawing.Size(213, 65);
            this.btnButton4.TabIndex = 0;
            this.btnButton4.TabStop = false;
            this.btnButton4.Text = "Button 4";
            this.btnButton4.UseVisualStyleBackColor = false;
            this.btnButton4.Click += new System.EventHandler(this.btnButton4_Click);
            // 
            // btnButton3
            // 
            this.btnButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnButton3.FlatAppearance.BorderSize = 0;
            this.btnButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnButton3.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnButton3.ForeColor = System.Drawing.Color.White;
            this.btnButton3.Location = new System.Drawing.Point(0, 195);
            this.btnButton3.Margin = new System.Windows.Forms.Padding(2);
            this.btnButton3.Name = "btnButton3";
            this.btnButton3.Size = new System.Drawing.Size(213, 65);
            this.btnButton3.TabIndex = 0;
            this.btnButton3.TabStop = false;
            this.btnButton3.Text = "Button 3";
            this.btnButton3.UseVisualStyleBackColor = false;
            this.btnButton3.Click += new System.EventHandler(this.btnButton3_Click);
            // 
            // btnButton2
            // 
            this.btnButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnButton2.FlatAppearance.BorderSize = 0;
            this.btnButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnButton2.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnButton2.ForeColor = System.Drawing.Color.White;
            this.btnButton2.Location = new System.Drawing.Point(0, 130);
            this.btnButton2.Margin = new System.Windows.Forms.Padding(2);
            this.btnButton2.Name = "btnButton2";
            this.btnButton2.Size = new System.Drawing.Size(213, 65);
            this.btnButton2.TabIndex = 0;
            this.btnButton2.TabStop = false;
            this.btnButton2.Text = "Button 2";
            this.btnButton2.UseVisualStyleBackColor = false;
            this.btnButton2.Click += new System.EventHandler(this.btnButton2_Click);
            // 
            // btnButton1
            // 
            this.btnButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnButton1.FlatAppearance.BorderSize = 0;
            this.btnButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnButton1.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnButton1.ForeColor = System.Drawing.Color.White;
            this.btnButton1.Location = new System.Drawing.Point(0, 65);
            this.btnButton1.Margin = new System.Windows.Forms.Padding(2);
            this.btnButton1.Name = "btnButton1";
            this.btnButton1.Size = new System.Drawing.Size(213, 65);
            this.btnButton1.TabIndex = 0;
            this.btnButton1.TabStop = false;
            this.btnButton1.Text = "Button 1";
            this.btnButton1.UseVisualStyleBackColor = false;
            this.btnButton1.Click += new System.EventHandler(this.btnButton1_Click);
            // 
            // btnJoystick
            // 
            this.btnJoystick.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnJoystick.FlatAppearance.BorderSize = 0;
            this.btnJoystick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJoystick.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJoystick.ForeColor = System.Drawing.Color.White;
            this.btnJoystick.Location = new System.Drawing.Point(0, 0);
            this.btnJoystick.Margin = new System.Windows.Forms.Padding(2);
            this.btnJoystick.Name = "btnJoystick";
            this.btnJoystick.Size = new System.Drawing.Size(213, 65);
            this.btnJoystick.TabIndex = 0;
            this.btnJoystick.TabStop = false;
            this.btnJoystick.Text = "Joystick";
            this.btnJoystick.UseVisualStyleBackColor = false;
            this.btnJoystick.Click += new System.EventHandler(this.btnJoystick_Click);
            // 
            // grpSettings
            // 
            this.grpSettings.Controls.Add(this.trkJoystick);
            this.grpSettings.Controls.Add(this.lblCursorSpeed);
            this.grpSettings.Controls.Add(this.radProgram);
            this.grpSettings.Controls.Add(this.lblJoystickSensitivity);
            this.grpSettings.Controls.Add(this.lblSlower);
            this.grpSettings.Controls.Add(this.lblFaster);
            this.grpSettings.Controls.Add(this.lblLessSensitive);
            this.grpSettings.Controls.Add(this.lblMoreSensitive);
            this.grpSettings.Controls.Add(this.txtWebsite);
            this.grpSettings.Controls.Add(this.lblWebsite);
            this.grpSettings.Controls.Add(this.radWebsite);
            this.grpSettings.Controls.Add(this.radRightClick);
            this.grpSettings.Controls.Add(this.btnKeyboardShortcutChange);
            this.grpSettings.Controls.Add(this.lblShortcut);
            this.grpSettings.Controls.Add(this.radShortcut);
            this.grpSettings.Controls.Add(this.btnProgramChange);
            this.grpSettings.Controls.Add(this.lblProgramName);
            this.grpSettings.Controls.Add(this.picProgramIcon);
            this.grpSettings.Controls.Add(this.txtPhrase);
            this.grpSettings.Controls.Add(this.lblPhrase);
            this.grpSettings.Controls.Add(this.radSentence);
            this.grpSettings.Controls.Add(this.radOSK);
            this.grpSettings.Controls.Add(this.radLeftClick);
            this.grpSettings.Controls.Add(this.trkCursor);
            this.grpSettings.Controls.Add(this.lblCursorDescription);
            this.grpSettings.Controls.Add(this.lblJoystickDescription);
            this.grpSettings.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSettings.ForeColor = System.Drawing.Color.White;
            this.grpSettings.Location = new System.Drawing.Point(226, 6);
            this.grpSettings.Name = "grpSettings";
            this.grpSettings.Size = new System.Drawing.Size(424, 435);
            this.grpSettings.TabIndex = 2;
            this.grpSettings.TabStop = false;
            this.grpSettings.Text = "Settings";
            // 
            // trkJoystick
            // 
            this.trkJoystick.Location = new System.Drawing.Point(130, 173);
            this.trkJoystick.Maximum = 11;
            this.trkJoystick.Minimum = 1;
            this.trkJoystick.Name = "trkJoystick";
            this.trkJoystick.Size = new System.Drawing.Size(164, 45);
            this.trkJoystick.TabIndex = 26;
            this.trkJoystick.TabStop = false;
            this.trkJoystick.Value = 1;
            this.trkJoystick.Visible = false;
            this.trkJoystick.ValueChanged += new System.EventHandler(this.trkJoystick_ValueChanged);
            // 
            // lblCursorSpeed
            // 
            this.lblCursorSpeed.AutoSize = true;
            this.lblCursorSpeed.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCursorSpeed.Location = new System.Drawing.Point(6, 230);
            this.lblCursorSpeed.Name = "lblCursorSpeed";
            this.lblCursorSpeed.Size = new System.Drawing.Size(125, 25);
            this.lblCursorSpeed.TabIndex = 15;
            this.lblCursorSpeed.Text = "Cursor Speed";
            this.lblCursorSpeed.Visible = false;
            // 
            // radProgram
            // 
            this.radProgram.AutoSize = true;
            this.radProgram.ForeColor = System.Drawing.Color.LightGray;
            this.radProgram.Location = new System.Drawing.Point(6, 194);
            this.radProgram.Name = "radProgram";
            this.radProgram.Size = new System.Drawing.Size(190, 34);
            this.radProgram.TabIndex = 5;
            this.radProgram.TabStop = true;
            this.radProgram.Text = "Open a Program";
            this.radProgram.UseVisualStyleBackColor = true;
            this.radProgram.Visible = false;
            this.radProgram.CheckedChanged += new System.EventHandler(this.radProgram_CheckedChanged);
            // 
            // lblJoystickSensitivity
            // 
            this.lblJoystickSensitivity.AutoSize = true;
            this.lblJoystickSensitivity.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJoystickSensitivity.Location = new System.Drawing.Point(6, 44);
            this.lblJoystickSensitivity.Name = "lblJoystickSensitivity";
            this.lblJoystickSensitivity.Size = new System.Drawing.Size(173, 25);
            this.lblJoystickSensitivity.TabIndex = 12;
            this.lblJoystickSensitivity.Text = "Joystick Sensitivity";
            this.lblJoystickSensitivity.Visible = false;
            // 
            // lblSlower
            // 
            this.lblSlower.AutoSize = true;
            this.lblSlower.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlower.Location = new System.Drawing.Point(69, 374);
            this.lblSlower.Name = "lblSlower";
            this.lblSlower.Size = new System.Drawing.Size(52, 19);
            this.lblSlower.TabIndex = 22;
            this.lblSlower.Text = "Slower";
            this.lblSlower.Visible = false;
            // 
            // lblFaster
            // 
            this.lblFaster.AutoSize = true;
            this.lblFaster.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFaster.Location = new System.Drawing.Point(297, 374);
            this.lblFaster.Name = "lblFaster";
            this.lblFaster.Size = new System.Drawing.Size(46, 19);
            this.lblFaster.TabIndex = 21;
            this.lblFaster.Text = "Faster";
            this.lblFaster.Visible = false;
            // 
            // lblLessSensitive
            // 
            this.lblLessSensitive.AutoSize = true;
            this.lblLessSensitive.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLessSensitive.Location = new System.Drawing.Point(29, 174);
            this.lblLessSensitive.Name = "lblLessSensitive";
            this.lblLessSensitive.Size = new System.Drawing.Size(95, 19);
            this.lblLessSensitive.TabIndex = 19;
            this.lblLessSensitive.Text = "Less Sensitive";
            this.lblLessSensitive.Visible = false;
            // 
            // lblMoreSensitive
            // 
            this.lblMoreSensitive.AutoSize = true;
            this.lblMoreSensitive.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoreSensitive.Location = new System.Drawing.Point(300, 174);
            this.lblMoreSensitive.Name = "lblMoreSensitive";
            this.lblMoreSensitive.Size = new System.Drawing.Size(102, 19);
            this.lblMoreSensitive.TabIndex = 18;
            this.lblMoreSensitive.Text = "More Sensitive";
            this.lblMoreSensitive.Visible = false;
            // 
            // txtWebsite
            // 
            this.txtWebsite.Enabled = false;
            this.txtWebsite.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWebsite.Location = new System.Drawing.Point(133, 319);
            this.txtWebsite.Name = "txtWebsite";
            this.txtWebsite.Size = new System.Drawing.Size(267, 29);
            this.txtWebsite.TabIndex = 8;
            this.txtWebsite.Visible = false;
            this.txtWebsite.TextChanged += new System.EventHandler(this.txtWebsite_TextChanged);
            // 
            // lblWebsite
            // 
            this.lblWebsite.AutoSize = true;
            this.lblWebsite.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWebsite.ForeColor = System.Drawing.Color.LightGray;
            this.lblWebsite.Location = new System.Drawing.Point(24, 322);
            this.lblWebsite.Name = "lblWebsite";
            this.lblWebsite.Size = new System.Drawing.Size(108, 21);
            this.lblWebsite.TabIndex = 25;
            this.lblWebsite.Text = "Website Link:";
            this.lblWebsite.Visible = false;
            // 
            // radWebsite
            // 
            this.radWebsite.AutoSize = true;
            this.radWebsite.ForeColor = System.Drawing.Color.LightGray;
            this.radWebsite.Location = new System.Drawing.Point(6, 272);
            this.radWebsite.Name = "radWebsite";
            this.radWebsite.Size = new System.Drawing.Size(182, 34);
            this.radWebsite.TabIndex = 7;
            this.radWebsite.TabStop = true;
            this.radWebsite.Text = "Open a Website";
            this.radWebsite.UseVisualStyleBackColor = true;
            this.radWebsite.Visible = false;
            this.radWebsite.CheckedChanged += new System.EventHandler(this.radWebsite_CheckedChanged);
            // 
            // radRightClick
            // 
            this.radRightClick.AutoSize = true;
            this.radRightClick.ForeColor = System.Drawing.Color.LightGray;
            this.radRightClick.Location = new System.Drawing.Point(194, 37);
            this.radRightClick.Name = "radRightClick";
            this.radRightClick.Size = new System.Drawing.Size(132, 34);
            this.radRightClick.TabIndex = 1;
            this.radRightClick.TabStop = true;
            this.radRightClick.Text = "Right Click";
            this.radRightClick.UseVisualStyleBackColor = true;
            this.radRightClick.Visible = false;
            this.radRightClick.CheckedChanged += new System.EventHandler(this.radRightClick_CheckedChanged);
            // 
            // btnKeyboardShortcutChange
            // 
            this.btnKeyboardShortcutChange.Enabled = false;
            this.btnKeyboardShortcutChange.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeyboardShortcutChange.ForeColor = System.Drawing.Color.Black;
            this.btnKeyboardShortcutChange.Location = new System.Drawing.Point(134, 393);
            this.btnKeyboardShortcutChange.Name = "btnKeyboardShortcutChange";
            this.btnKeyboardShortcutChange.Size = new System.Drawing.Size(75, 23);
            this.btnKeyboardShortcutChange.TabIndex = 10;
            this.btnKeyboardShortcutChange.Text = "Change";
            this.btnKeyboardShortcutChange.UseVisualStyleBackColor = true;
            this.btnKeyboardShortcutChange.Visible = false;
            this.btnKeyboardShortcutChange.Click += new System.EventHandler(this.btnKeyboardShortcutChange_Click);
            // 
            // lblShortcut
            // 
            this.lblShortcut.AutoEllipsis = true;
            this.lblShortcut.AutoSize = true;
            this.lblShortcut.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShortcut.ForeColor = System.Drawing.Color.LightGray;
            this.lblShortcut.Location = new System.Drawing.Point(25, 393);
            this.lblShortcut.Name = "lblShortcut";
            this.lblShortcut.Size = new System.Drawing.Size(0, 21);
            this.lblShortcut.TabIndex = 10;
            this.lblShortcut.Visible = false;
            // 
            // radShortcut
            // 
            this.radShortcut.AutoSize = true;
            this.radShortcut.ForeColor = System.Drawing.Color.LightGray;
            this.radShortcut.Location = new System.Drawing.Point(6, 353);
            this.radShortcut.Name = "radShortcut";
            this.radShortcut.Size = new System.Drawing.Size(296, 34);
            this.radShortcut.TabIndex = 9;
            this.radShortcut.TabStop = true;
            this.radShortcut.Text = "Perform Keyboard Shortcut";
            this.radShortcut.UseVisualStyleBackColor = true;
            this.radShortcut.Visible = false;
            this.radShortcut.CheckedChanged += new System.EventHandler(this.radShortcut_CheckedChanged);
            // 
            // btnProgramChange
            // 
            this.btnProgramChange.Enabled = false;
            this.btnProgramChange.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProgramChange.ForeColor = System.Drawing.Color.Black;
            this.btnProgramChange.Location = new System.Drawing.Point(176, 242);
            this.btnProgramChange.Name = "btnProgramChange";
            this.btnProgramChange.Size = new System.Drawing.Size(75, 23);
            this.btnProgramChange.TabIndex = 6;
            this.btnProgramChange.Text = "Change";
            this.btnProgramChange.UseVisualStyleBackColor = true;
            this.btnProgramChange.Visible = false;
            this.btnProgramChange.Click += new System.EventHandler(this.btnProgramChange_Click);
            // 
            // lblProgramName
            // 
            this.lblProgramName.AutoEllipsis = true;
            this.lblProgramName.AutoSize = true;
            this.lblProgramName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgramName.ForeColor = System.Drawing.Color.LightGray;
            this.lblProgramName.Location = new System.Drawing.Point(67, 242);
            this.lblProgramName.Name = "lblProgramName";
            this.lblProgramName.Size = new System.Drawing.Size(0, 21);
            this.lblProgramName.TabIndex = 7;
            this.lblProgramName.Visible = false;
            // 
            // picProgramIcon
            // 
            this.picProgramIcon.Location = new System.Drawing.Point(29, 236);
            this.picProgramIcon.Name = "picProgramIcon";
            this.picProgramIcon.Size = new System.Drawing.Size(32, 32);
            this.picProgramIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picProgramIcon.TabIndex = 6;
            this.picProgramIcon.TabStop = false;
            this.picProgramIcon.Visible = false;
            // 
            // txtPhrase
            // 
            this.txtPhrase.Enabled = false;
            this.txtPhrase.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhrase.Location = new System.Drawing.Point(92, 160);
            this.txtPhrase.Name = "txtPhrase";
            this.txtPhrase.Size = new System.Drawing.Size(308, 29);
            this.txtPhrase.TabIndex = 4;
            this.txtPhrase.Visible = false;
            this.txtPhrase.TextChanged += new System.EventHandler(this.txtPhrase_TextChanged);
            // 
            // lblPhrase
            // 
            this.lblPhrase.AutoSize = true;
            this.lblPhrase.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhrase.ForeColor = System.Drawing.Color.LightGray;
            this.lblPhrase.Location = new System.Drawing.Point(24, 163);
            this.lblPhrase.Name = "lblPhrase";
            this.lblPhrase.Size = new System.Drawing.Size(62, 21);
            this.lblPhrase.TabIndex = 3;
            this.lblPhrase.Text = "Phrase:";
            this.lblPhrase.Visible = false;
            // 
            // radSentence
            // 
            this.radSentence.AutoSize = true;
            this.radSentence.ForeColor = System.Drawing.Color.LightGray;
            this.radSentence.Location = new System.Drawing.Point(6, 114);
            this.radSentence.Name = "radSentence";
            this.radSentence.Size = new System.Drawing.Size(163, 34);
            this.radSentence.TabIndex = 3;
            this.radSentence.TabStop = true;
            this.radSentence.Text = "Type a Phrase";
            this.radSentence.UseVisualStyleBackColor = true;
            this.radSentence.Visible = false;
            this.radSentence.CheckedChanged += new System.EventHandler(this.radSentence_CheckedChanged);
            // 
            // radOSK
            // 
            this.radOSK.AutoSize = true;
            this.radOSK.ForeColor = System.Drawing.Color.LightGray;
            this.radOSK.Location = new System.Drawing.Point(6, 74);
            this.radOSK.Name = "radOSK";
            this.radOSK.Size = new System.Drawing.Size(287, 34);
            this.radOSK.TabIndex = 2;
            this.radOSK.TabStop = true;
            this.radOSK.Text = "Open On-Screen Keyboard";
            this.radOSK.UseVisualStyleBackColor = true;
            this.radOSK.Visible = false;
            this.radOSK.CheckedChanged += new System.EventHandler(this.radOSK_CheckedChanged);
            // 
            // radLeftClick
            // 
            this.radLeftClick.AutoSize = true;
            this.radLeftClick.ForeColor = System.Drawing.Color.LightGray;
            this.radLeftClick.Location = new System.Drawing.Point(6, 34);
            this.radLeftClick.Name = "radLeftClick";
            this.radLeftClick.Size = new System.Drawing.Size(117, 34);
            this.radLeftClick.TabIndex = 0;
            this.radLeftClick.TabStop = true;
            this.radLeftClick.Text = "Left Click";
            this.radLeftClick.UseVisualStyleBackColor = true;
            this.radLeftClick.Visible = false;
            this.radLeftClick.CheckedChanged += new System.EventHandler(this.radLeftClick_CheckedChanged);
            // 
            // trkCursor
            // 
            this.trkCursor.Location = new System.Drawing.Point(127, 374);
            this.trkCursor.Maximum = 11;
            this.trkCursor.Minimum = 1;
            this.trkCursor.Name = "trkCursor";
            this.trkCursor.Size = new System.Drawing.Size(164, 45);
            this.trkCursor.TabIndex = 12;
            this.trkCursor.TabStop = false;
            this.trkCursor.Value = 1;
            this.trkCursor.Visible = false;
            this.trkCursor.ValueChanged += new System.EventHandler(this.trkCursor_ValueChanged);
            // 
            // lblCursorDescription
            // 
            this.lblCursorDescription.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCursorDescription.Location = new System.Drawing.Point(9, 278);
            this.lblCursorDescription.Name = "lblCursorDescription";
            this.lblCursorDescription.Size = new System.Drawing.Size(411, 74);
            this.lblCursorDescription.TabIndex = 16;
            this.lblCursorDescription.Text = "The cursor speed determines how quickly the mouse cursor moves across the screen " +
    "with the movement of the joystick.";
            this.lblCursorDescription.Visible = false;
            // 
            // lblJoystickDescription
            // 
            this.lblJoystickDescription.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJoystickDescription.Location = new System.Drawing.Point(7, 94);
            this.lblJoystickDescription.Name = "lblJoystickDescription";
            this.lblJoystickDescription.Size = new System.Drawing.Size(411, 58);
            this.lblJoystickDescription.TabIndex = 13;
            this.lblJoystickDescription.Text = "The joystick sensitivity determines how much movement of the joystick it takes to" +
    " make the cursor start moving.";
            this.lblJoystickDescription.Visible = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(662, 455);
            this.Controls.Add(this.grpSettings);
            this.Controls.Add(this.pnlInputSelection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Custom Mouse Control Center";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.cxtTrayIcon.ResumeLayout(false);
            this.pnlInputSelection.ResumeLayout(false);
            this.grpSettings.ResumeLayout(false);
            this.grpSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkJoystick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProgramIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkCursor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon nfyTrayIcon;
        private System.Windows.Forms.ContextMenuStrip cxtTrayIcon;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenControlCenter;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel pnlInputSelection;
        private System.Windows.Forms.Button btnButton6;
        private System.Windows.Forms.Button btnButton5;
        private System.Windows.Forms.Button btnButton4;
        private System.Windows.Forms.Button btnButton3;
        private System.Windows.Forms.Button btnButton2;
        private System.Windows.Forms.Button btnButton1;
        private System.Windows.Forms.Button btnJoystick;
        private System.Windows.Forms.GroupBox grpSettings;
        private System.Windows.Forms.Button btnKeyboardShortcutChange;
        private System.Windows.Forms.Label lblShortcut;
        private System.Windows.Forms.RadioButton radShortcut;
        private System.Windows.Forms.Button btnProgramChange;
        private System.Windows.Forms.Label lblProgramName;
        private System.Windows.Forms.PictureBox picProgramIcon;
        private System.Windows.Forms.RadioButton radProgram;
        private System.Windows.Forms.TextBox txtPhrase;
        private System.Windows.Forms.Label lblPhrase;
        private System.Windows.Forms.RadioButton radSentence;
        private System.Windows.Forms.RadioButton radOSK;
        private System.Windows.Forms.RadioButton radLeftClick;
        private System.Windows.Forms.Label lblCursorDescription;
        private System.Windows.Forms.Label lblCursorSpeed;
        private System.Windows.Forms.Label lblSlower;
        private System.Windows.Forms.Label lblLessSensitive;
        private System.Windows.Forms.Label lblMoreSensitive;
        private System.Windows.Forms.Label lblJoystickDescription;
        private System.Windows.Forms.Label lblJoystickSensitivity;
        private System.Windows.Forms.RadioButton radRightClick;
        private System.Windows.Forms.Label lblFaster;
        private System.Windows.Forms.TrackBar trkCursor;
        private System.Windows.Forms.TextBox txtWebsite;
        private System.Windows.Forms.Label lblWebsite;
        private System.Windows.Forms.RadioButton radWebsite;
        private System.Windows.Forms.TrackBar trkJoystick;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuStartWithWindows;
    }
}

