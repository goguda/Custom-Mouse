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
            this.pnlInputSelection = new System.Windows.Forms.Panel();
            this.cxtTrayIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuOpenControlCenter = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cxtTrayIcon.SuspendLayout();
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
            // pnlInputSelection
            // 
            this.pnlInputSelection.AutoScroll = true;
            this.pnlInputSelection.BackColor = System.Drawing.Color.Transparent;
            this.pnlInputSelection.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlInputSelection.Location = new System.Drawing.Point(0, 0);
            this.pnlInputSelection.Name = "pnlInputSelection";
            this.pnlInputSelection.Size = new System.Drawing.Size(391, 693);
            this.pnlInputSelection.TabIndex = 0;
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
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(278, 34);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(275, 6);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon nfyTrayIcon;
        private System.Windows.Forms.Panel pnlInputSelection;
        private System.Windows.Forms.ContextMenuStrip cxtTrayIcon;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenControlCenter;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

