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
        private readonly bool loadedPreviousSession;
        private ButtonSetting[] buttonSettings;

        private DeviceSettings()
        {
            buttonSettings = new ButtonSetting[6];
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

        public bool LoadedPreviousSession
        {
            get
            {
                return loadedPreviousSession;
            }
        }
    }
}
