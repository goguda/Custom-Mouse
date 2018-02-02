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

        private void Form1_Load(object sender, EventArgs e)
        {

            string[] buttonNames = new string[12];
            buttonNames[0] = "Joystick";

            for (int i = 1; i < 12; i++)
            {
                buttonNames[i] = "Button " + i;
            }

            Button lastButton = null;
            for (int i = 0; i < 12; i++)
            {
                Button toAdd = new Button();

                if (i != 0)
                {
                    toAdd.Location = new Point(0, lastButton.Location.Y + lastButton.Height);
                }

                toAdd.Text = buttonNames[i];

                toAdd.Font = new Font(FontFamily.GenericSansSerif, 20);
                toAdd.ForeColor = Color.White;
                toAdd.Size = new Size(pnlInputSelection.Width, 60);
                toAdd.BackColor = Color.DarkRed;
                toAdd.FlatStyle = FlatStyle.Flat;
                toAdd.FlatAppearance.BorderSize = 0;
                toAdd.FlatAppearance.BorderColor = Color.DarkRed;

                toAdd.TabStop = false;

                toAdd.Click += new EventHandler(ConfigureButton_Click);
                pnlInputSelection.Controls.Add(toAdd);
                lastButton = toAdd;
            }

            if (pnlInputSelection.VerticalScroll.Enabled)
            {
                pnlInputSelection.Width += SystemInformation.VerticalScrollBarWidth;
            }
        }

        private void ConfigureButton_Click(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;

            foreach (Button button in pnlInputSelection.Controls)
            {
                if (button != clicked)
                {
                    button.BackColor = Color.DarkRed;
                }
            }
            clicked.BackColor = Color.Red;
        }
    }
}
