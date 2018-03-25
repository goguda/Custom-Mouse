using System;
using System.Windows.Forms;

namespace CustomMouseController
{
    [Serializable]
    public class JoystickSetting
    {
        [NonSerialized]
        private Button button;

        private int speedMultiplier;
        private int sensitivityMultiplier;

        public JoystickSetting(Button uiButton)
        {
            button = uiButton;
            speedMultiplier = 6;
            sensitivityMultiplier = 6;
        }

        public int SpeedMultiplier
        {
            get
            {
                return speedMultiplier;
            }
            set
            {
                speedMultiplier = value;
            }
        }

        public int SensitivityMultiplier
        {
            get
            {
                return sensitivityMultiplier;
            }
            set
            {
                sensitivityMultiplier = value;
            }
        }

        public Button AssignedButton
        {
            get
            {
                return button;
            }
            set
            {
                button = value;
            }
        }
    }
}
