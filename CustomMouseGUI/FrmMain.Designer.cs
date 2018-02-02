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
            this.SuspendLayout();
            // 
            // nfyTrayIcon
            // 
            this.nfyTrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("nfyTrayIcon.Icon")));
            this.nfyTrayIcon.Text = "Custom Mouse Control Center";
            this.nfyTrayIcon.Visible = true;
            // 
            // pnlInputSelection
            // 
            this.pnlInputSelection.AutoScroll = true;
            this.pnlInputSelection.BackColor = System.Drawing.Color.Gray;
            this.pnlInputSelection.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlInputSelection.Location = new System.Drawing.Point(0, 0);
            this.pnlInputSelection.Name = "pnlInputSelection";
            this.pnlInputSelection.Size = new System.Drawing.Size(391, 693);
            this.pnlInputSelection.TabIndex = 0;
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
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon nfyTrayIcon;
        private System.Windows.Forms.Panel pnlInputSelection;
    }
}

