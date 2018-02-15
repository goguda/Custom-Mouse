namespace CustomMouseGUI
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
            this.btnJoystick = new System.Windows.Forms.Button();
            this.btnButton1 = new System.Windows.Forms.Button();
            this.btnButton2 = new System.Windows.Forms.Button();
            this.btnButton3 = new System.Windows.Forms.Button();
            this.btnButton4 = new System.Windows.Forms.Button();
            this.btnButton5 = new System.Windows.Forms.Button();
            this.btnButton6 = new System.Windows.Forms.Button();
            this.cxtTrayIcon.SuspendLayout();
            this.pnlInputSelection.SuspendLayout();
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
            this.cxtTrayIcon.Size = new System.Drawing.Size(279, 78);
            // 
            // mnuOpenControlCenter
            // 
            this.mnuOpenControlCenter.Name = "mnuOpenControlCenter";
            this.mnuOpenControlCenter.Size = new System.Drawing.Size(278, 34);
            this.mnuOpenControlCenter.Text = "Open Control Center";
            this.mnuOpenControlCenter.Click += new System.EventHandler(this.mnuOpenControlCenter_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(275, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(278, 34);
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
            this.pnlInputSelection.Name = "pnlInputSelection";
            this.pnlInputSelection.Size = new System.Drawing.Size(391, 693);
            this.pnlInputSelection.TabIndex = 1;
            // 
            // btnJoystick
            // 
            this.btnJoystick.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnJoystick.FlatAppearance.BorderSize = 0;
            this.btnJoystick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJoystick.Font = new System.Drawing.Font("Franklin Gothic Demi", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJoystick.ForeColor = System.Drawing.Color.White;
            this.btnJoystick.Location = new System.Drawing.Point(0, 0);
            this.btnJoystick.Name = "btnJoystick";
            this.btnJoystick.Size = new System.Drawing.Size(391, 99);
            this.btnJoystick.TabIndex = 0;
            this.btnJoystick.TabStop = false;
            this.btnJoystick.Text = "Joystick";
            this.btnJoystick.UseVisualStyleBackColor = false;
            // 
            // btnButton1
            // 
            this.btnButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnButton1.FlatAppearance.BorderSize = 0;
            this.btnButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnButton1.Font = new System.Drawing.Font("Franklin Gothic Demi", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnButton1.ForeColor = System.Drawing.Color.White;
            this.btnButton1.Location = new System.Drawing.Point(0, 99);
            this.btnButton1.Name = "btnButton1";
            this.btnButton1.Size = new System.Drawing.Size(391, 99);
            this.btnButton1.TabIndex = 0;
            this.btnButton1.TabStop = false;
            this.btnButton1.Text = "Button 1";
            this.btnButton1.UseVisualStyleBackColor = false;
            // 
            // btnButton2
            // 
            this.btnButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnButton2.FlatAppearance.BorderSize = 0;
            this.btnButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnButton2.Font = new System.Drawing.Font("Franklin Gothic Demi", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnButton2.ForeColor = System.Drawing.Color.White;
            this.btnButton2.Location = new System.Drawing.Point(0, 198);
            this.btnButton2.Name = "btnButton2";
            this.btnButton2.Size = new System.Drawing.Size(391, 99);
            this.btnButton2.TabIndex = 0;
            this.btnButton2.TabStop = false;
            this.btnButton2.Text = "Button 2";
            this.btnButton2.UseVisualStyleBackColor = false;
            // 
            // btnButton3
            // 
            this.btnButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnButton3.FlatAppearance.BorderSize = 0;
            this.btnButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnButton3.Font = new System.Drawing.Font("Franklin Gothic Demi", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnButton3.ForeColor = System.Drawing.Color.White;
            this.btnButton3.Location = new System.Drawing.Point(0, 297);
            this.btnButton3.Name = "btnButton3";
            this.btnButton3.Size = new System.Drawing.Size(391, 99);
            this.btnButton3.TabIndex = 0;
            this.btnButton3.TabStop = false;
            this.btnButton3.Text = "Button 3";
            this.btnButton3.UseVisualStyleBackColor = false;
            // 
            // btnButton4
            // 
            this.btnButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnButton4.FlatAppearance.BorderSize = 0;
            this.btnButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnButton4.Font = new System.Drawing.Font("Franklin Gothic Demi", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnButton4.ForeColor = System.Drawing.Color.White;
            this.btnButton4.Location = new System.Drawing.Point(0, 396);
            this.btnButton4.Name = "btnButton4";
            this.btnButton4.Size = new System.Drawing.Size(391, 99);
            this.btnButton4.TabIndex = 0;
            this.btnButton4.TabStop = false;
            this.btnButton4.Text = "Button 4";
            this.btnButton4.UseVisualStyleBackColor = false;
            // 
            // btnButton5
            // 
            this.btnButton5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnButton5.FlatAppearance.BorderSize = 0;
            this.btnButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnButton5.Font = new System.Drawing.Font("Franklin Gothic Demi", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnButton5.ForeColor = System.Drawing.Color.White;
            this.btnButton5.Location = new System.Drawing.Point(0, 495);
            this.btnButton5.Name = "btnButton5";
            this.btnButton5.Size = new System.Drawing.Size(391, 99);
            this.btnButton5.TabIndex = 0;
            this.btnButton5.TabStop = false;
            this.btnButton5.Text = "Button 5";
            this.btnButton5.UseVisualStyleBackColor = false;
            // 
            // btnButton6
            // 
            this.btnButton6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnButton6.FlatAppearance.BorderSize = 0;
            this.btnButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnButton6.Font = new System.Drawing.Font("Franklin Gothic Demi", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnButton6.ForeColor = System.Drawing.Color.White;
            this.btnButton6.Location = new System.Drawing.Point(0, 594);
            this.btnButton6.Name = "btnButton6";
            this.btnButton6.Size = new System.Drawing.Size(391, 99);
            this.btnButton6.TabIndex = 0;
            this.btnButton6.TabStop = false;
            this.btnButton6.Text = "Button 6";
            this.btnButton6.UseVisualStyleBackColor = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(1213, 693);
            this.Controls.Add(this.pnlInputSelection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Custom Mouse Control Center";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.cxtTrayIcon.ResumeLayout(false);
            this.pnlInputSelection.ResumeLayout(false);
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
    }
}

