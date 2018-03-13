using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomMouseController
{
    public class JoystickSetting
    {
        private int speedMultiplier;
        private int sensitivityMultiplier;

        public JoystickSetting()
        {
            speedMultiplier = 1;
            sensitivityMultiplier = 1;
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
                speedMultiplier = value;
            }
        }
    }
}
