using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomMouseController
{
    [Serializable]
    public class DeviceSettings
    {
        private static volatile DeviceSettings instance;

        private ButtonSetting[] buttonSettings;

        private DeviceSettings()
        {
        }

        public static DeviceSettings Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DeviceSettings();
                }
                return instance;
            }
        }
    }
}
