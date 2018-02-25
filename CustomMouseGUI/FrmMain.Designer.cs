﻿namespace CustomMouseGUI
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.nfyTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cxtTrayIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuOpenControlCenter = new System.Windows.Forms.ToolStripMenuItem();
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
            this.btnKeyboardShortcutChange = new System.Windows.Forms.Button();
            this.lblShortcut = new System.Windows.Forms.Label();
            this.radShortcut = new System.Windows.Forms.RadioButton();
            this.btnProgramChange = new System.Windows.Forms.Button();
            this.lblProgramName = new System.Windows.Forms.Label();
            this.picProgramIcon = new System.Windows.Forms.PictureBox();
            this.radProgram = new System.Windows.Forms.RadioButton();
            this.txtPhrase = new System.Windows.Forms.TextBox();
            this.lblPhrase = new System.Windows.Forms.Label();
            this.radSentence = new System.Windows.Forms.RadioButton();
            this.radRightClick = new System.Windows.Forms.RadioButton();
            this.radLeftClick = new System.Windows.Forms.RadioButton();
            this.cxtTrayIcon.SuspendLayout();
            this.pnlInputSelection.SuspendLayout();
            this.grpSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProgramIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // nfyTrayIcon
            // 
            this.nfyTrayIcon.ContextMenuStrip = this.cxtTrayIcon;
            this.nfyTrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("nfyTrayIcon.Icon")));
            this.nfyTrayIcon.Text = "Custom Mouse Control Center";
            this.nfyTrayIcon.Visible = true;
            this.nfyTrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.nfyTrayIcon_MouseDoubleClick);
            // 
            // cxtTrayIcon
            // 
            this.cxtTrayIcon.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.cxtTrayIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpenControlCenter,
            this.toolStripSeparator1,
            this.mnuExit});
            this.cxtTrayIcon.Name = "cxtTrayIcon";
            this.cxtTrayIcon.Size = new System.Drawing.Size(185, 54);
            // 
            // mnuOpenControlCenter
            // 
            this.mnuOpenControlCenter.Name = "mnuOpenControlCenter";
            this.mnuOpenControlCenter.Size = new System.Drawing.Size(184, 22);
            this.mnuOpenControlCenter.Text = "Open Control Center";
            this.mnuOpenControlCenter.Click += new System.EventHandler(this.mnuOpenControlCenter_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(184, 22);
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
            this.pnlInputSelection.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlInputSelection.Name = "pnlInputSelection";
            this.pnlInputSelection.Size = new System.Drawing.Size(213, 375);
            this.pnlInputSelection.TabIndex = 1;
            // 
            // btnButton6
            // 
            this.btnButton6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnButton6.FlatAppearance.BorderSize = 0;
            this.btnButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnButton6.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnButton6.ForeColor = System.Drawing.Color.White;
            this.btnButton6.Location = new System.Drawing.Point(0, 322);
            this.btnButton6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnButton6.Name = "btnButton6";
            this.btnButton6.Size = new System.Drawing.Size(213, 54);
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
            this.btnButton5.Location = new System.Drawing.Point(0, 268);
            this.btnButton5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnButton5.Name = "btnButton5";
            this.btnButton5.Size = new System.Drawing.Size(213, 54);
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
            this.btnButton4.Location = new System.Drawing.Point(0, 215);
            this.btnButton4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnButton4.Name = "btnButton4";
            this.btnButton4.Size = new System.Drawing.Size(213, 54);
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
            this.btnButton3.Location = new System.Drawing.Point(0, 161);
            this.btnButton3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnButton3.Name = "btnButton3";
            this.btnButton3.Size = new System.Drawing.Size(213, 54);
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
            this.btnButton2.Location = new System.Drawing.Point(0, 107);
            this.btnButton2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnButton2.Name = "btnButton2";
            this.btnButton2.Size = new System.Drawing.Size(213, 54);
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
            this.btnButton1.Location = new System.Drawing.Point(0, 54);
            this.btnButton1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnButton1.Name = "btnButton1";
            this.btnButton1.Size = new System.Drawing.Size(213, 54);
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
            this.btnJoystick.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnJoystick.Name = "btnJoystick";
            this.btnJoystick.Size = new System.Drawing.Size(213, 54);
            this.btnJoystick.TabIndex = 0;
            this.btnJoystick.TabStop = false;
            this.btnJoystick.Text = "Joystick";
            this.btnJoystick.UseVisualStyleBackColor = false;
            this.btnJoystick.Click += new System.EventHandler(this.btnJoystick_Click);
            // 
            // grpSettings
            // 
            this.grpSettings.Controls.Add(this.btnKeyboardShortcutChange);
            this.grpSettings.Controls.Add(this.lblShortcut);
            this.grpSettings.Controls.Add(this.radShortcut);
            this.grpSettings.Controls.Add(this.btnProgramChange);
            this.grpSettings.Controls.Add(this.lblProgramName);
            this.grpSettings.Controls.Add(this.picProgramIcon);
            this.grpSettings.Controls.Add(this.radProgram);
            this.grpSettings.Controls.Add(this.txtPhrase);
            this.grpSettings.Controls.Add(this.lblPhrase);
            this.grpSettings.Controls.Add(this.radSentence);
            this.grpSettings.Controls.Add(this.radRightClick);
            this.grpSettings.Controls.Add(this.radLeftClick);
            this.grpSettings.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSettings.ForeColor = System.Drawing.Color.White;
            this.grpSettings.Location = new System.Drawing.Point(226, 12);
            this.grpSettings.Name = "grpSettings";
            this.grpSettings.Size = new System.Drawing.Size(424, 351);
            this.grpSettings.TabIndex = 2;
            this.grpSettings.TabStop = false;
            this.grpSettings.Text = "Settings";
            // 
            // btnKeyboardShortcutChange
            // 
            this.btnKeyboardShortcutChange.Enabled = false;
            this.btnKeyboardShortcutChange.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeyboardShortcutChange.ForeColor = System.Drawing.Color.Black;
            this.btnKeyboardShortcutChange.Location = new System.Drawing.Point(194, 313);
            this.btnKeyboardShortcutChange.Name = "btnKeyboardShortcutChange";
            this.btnKeyboardShortcutChange.Size = new System.Drawing.Size(75, 23);
            this.btnKeyboardShortcutChange.TabIndex = 11;
            this.btnKeyboardShortcutChange.Text = "Change";
            this.btnKeyboardShortcutChange.UseVisualStyleBackColor = true;
            // 
            // lblShortcut
            // 
            this.lblShortcut.AutoSize = true;
            this.lblShortcut.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShortcut.Location = new System.Drawing.Point(25, 313);
            this.lblShortcut.Name = "lblShortcut";
            this.lblShortcut.Size = new System.Drawing.Size(151, 21);
            this.lblShortcut.TabIndex = 10;
            this.lblShortcut.Text = "Assigned: CTRL + V";
            // 
            // radShortcut
            // 
            this.radShortcut.AutoSize = true;
            this.radShortcut.Location = new System.Drawing.Point(6, 273);
            this.radShortcut.Name = "radShortcut";
            this.radShortcut.Size = new System.Drawing.Size(296, 34);
            this.radShortcut.TabIndex = 9;
            this.radShortcut.TabStop = true;
            this.radShortcut.Text = "Perform Keyboard Shortcut";
            this.radShortcut.UseVisualStyleBackColor = true;
            // 
            // btnProgramChange
            // 
            this.btnProgramChange.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProgramChange.ForeColor = System.Drawing.Color.Black;
            this.btnProgramChange.Location = new System.Drawing.Point(194, 239);
            this.btnProgramChange.Name = "btnProgramChange";
            this.btnProgramChange.Size = new System.Drawing.Size(75, 23);
            this.btnProgramChange.TabIndex = 8;
            this.btnProgramChange.Text = "Change";
            this.btnProgramChange.UseVisualStyleBackColor = true;
            // 
            // lblProgramName
            // 
            this.lblProgramName.AutoSize = true;
            this.lblProgramName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgramName.Location = new System.Drawing.Point(67, 239);
            this.lblProgramName.Name = "lblProgramName";
            this.lblProgramName.Size = new System.Drawing.Size(126, 21);
            this.lblProgramName.TabIndex = 7;
            this.lblProgramName.Text = "Google Chrome";
            // 
            // picProgramIcon
            // 
            this.picProgramIcon.Image = ((System.Drawing.Image)(resources.GetObject("picProgramIcon.Image")));
            this.picProgramIcon.Location = new System.Drawing.Point(29, 233);
            this.picProgramIcon.Name = "picProgramIcon";
            this.picProgramIcon.Size = new System.Drawing.Size(32, 32);
            this.picProgramIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picProgramIcon.TabIndex = 6;
            this.picProgramIcon.TabStop = false;
            // 
            // radProgram
            // 
            this.radProgram.AutoSize = true;
            this.radProgram.Location = new System.Drawing.Point(6, 194);
            this.radProgram.Name = "radProgram";
            this.radProgram.Size = new System.Drawing.Size(190, 34);
            this.radProgram.TabIndex = 5;
            this.radProgram.TabStop = true;
            this.radProgram.Text = "Open a Program";
            this.radProgram.UseVisualStyleBackColor = true;
            // 
            // txtPhrase
            // 
            this.txtPhrase.Enabled = false;
            this.txtPhrase.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhrase.Location = new System.Drawing.Point(92, 160);
            this.txtPhrase.Name = "txtPhrase";
            this.txtPhrase.Size = new System.Drawing.Size(308, 29);
            this.txtPhrase.TabIndex = 4;
            // 
            // lblPhrase
            // 
            this.lblPhrase.AutoSize = true;
            this.lblPhrase.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhrase.Location = new System.Drawing.Point(24, 163);
            this.lblPhrase.Name = "lblPhrase";
            this.lblPhrase.Size = new System.Drawing.Size(62, 21);
            this.lblPhrase.TabIndex = 3;
            this.lblPhrase.Text = "Phrase:";
            // 
            // radSentence
            // 
            this.radSentence.AutoSize = true;
            this.radSentence.Location = new System.Drawing.Point(6, 114);
            this.radSentence.Name = "radSentence";
            this.radSentence.Size = new System.Drawing.Size(163, 34);
            this.radSentence.TabIndex = 2;
            this.radSentence.TabStop = true;
            this.radSentence.Text = "Type a Phrase";
            this.radSentence.UseVisualStyleBackColor = true;
            this.radSentence.CheckedChanged += new System.EventHandler(this.radSentence_CheckedChanged);
            // 
            // radRightClick
            // 
            this.radRightClick.AutoSize = true;
            this.radRightClick.Location = new System.Drawing.Point(6, 74);
            this.radRightClick.Name = "radRightClick";
            this.radRightClick.Size = new System.Drawing.Size(132, 34);
            this.radRightClick.TabIndex = 1;
            this.radRightClick.TabStop = true;
            this.radRightClick.Text = "Right Click";
            this.radRightClick.UseVisualStyleBackColor = true;
            // 
            // radLeftClick
            // 
            this.radLeftClick.AutoSize = true;
            this.radLeftClick.Location = new System.Drawing.Point(6, 34);
            this.radLeftClick.Name = "radLeftClick";
            this.radLeftClick.Size = new System.Drawing.Size(117, 34);
            this.radLeftClick.TabIndex = 0;
            this.radLeftClick.TabStop = true;
            this.radLeftClick.Text = "Left Click";
            this.radLeftClick.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(662, 375);
            this.Controls.Add(this.grpSettings);
            this.Controls.Add(this.pnlInputSelection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Custom Mouse Control Center";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.cxtTrayIcon.ResumeLayout(false);
            this.pnlInputSelection.ResumeLayout(false);
            this.grpSettings.ResumeLayout(false);
            this.grpSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProgramIcon)).EndInit();
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
        private System.Windows.Forms.RadioButton radRightClick;
        private System.Windows.Forms.RadioButton radLeftClick;
    }
}

