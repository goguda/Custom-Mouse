using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CustomMouseController
{
    [Serializable]
    public class DeviceSettings
    {
        private static volatile DeviceSettings instance;

        [NonSerialized]
        private bool loadedPreviousSession;
        [NonSerialized]
        private bool missingProgramsSinceLastSession;

        private string appDataFolder;
        private string saveFile;
        private JoystickSetting joystickSetting;
        private ButtonSetting[] buttonSettings;

        private DeviceSettings()
        {
            buttonSettings = new ButtonSetting[6];
            loadedPreviousSession = false;
            missingProgramsSinceLastSession = false;
            appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        }

        public static DeviceSettings Instance
        {
            get
            {
                if (instance == null)
                {
                    FileStream input = null;
                    try
                    {
                        input = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                            @"\Custom Mouse Controller\CustomMouseSettings.cms", FileMode.Open);
                    }
                    catch
                    {
                        instance = new DeviceSettings();
                    }

                    if (input != null)
                    {
                        try
                        {
                            BinaryFormatter formatter = new BinaryFormatter();
                            instance = (DeviceSettings)formatter.Deserialize(input);
                            instance.loadedPreviousSession = true;

                            // Check that the programs still exist and if not, display a warning
                            // Also load icons into programs since they don't serialize well
                            foreach (ButtonSetting setting in instance.buttonSettings)
                            {
                                if (setting.ProgramInfo != null)
                                {
                                    if (File.Exists(setting.ProgramInfo.Path))
                                    {
                                        setting.ProgramInfo.Icon = Icon.ExtractAssociatedIcon(setting.ProgramInfo.Path);
                                    }
                                    else
                                    {
                                        setting.ProgramInfo = null;
                                        instance.missingProgramsSinceLastSession = true;
                                    }
                                }
                            }
                        }
                        catch // no need to catch any individual exceptions since we want the same behaviour no matter what the exception is
                        {
                            instance = new DeviceSettings();
                        }
                        finally
                        {
                            input.Close();
                        }
                    }
                }
                return instance;
            }
        }

        public JoystickSetting JoystickSetting
        {
            get
            {
                return joystickSetting;
            }
            set
            {
                joystickSetting = value;
            }
        }

        public bool LoadedPreviousSession
        {
            get
            {
                return loadedPreviousSession;
            }
        }

        public bool NotAllProgramsLoaded
        {
            get
            {
                return missingProgramsSinceLastSession;
            }
        }

        public void SetButtonSetting(int buttonNumber, ButtonSetting settings)
        {
            if (buttonNumber > 6 || buttonNumber < 1 || settings == null)
            {
                return;
            }

            buttonSettings[buttonNumber - 1] = settings;
        }

        public void SaveSettings()
        {

            if (!Directory.Exists(appDataFolder + @"\Custom Mouse Controller\"))
            {
                Directory.CreateDirectory(appDataFolder + @"\Custom Mouse Controller\");
            }

            saveFile = appDataFolder + @"\Custom Mouse Controller\CustomMouseSettings.cms";

            FileStream output = new FileStream(saveFile, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(output, instance);
            output.Close();
        }

        public ButtonSetting GetButtonSetting(int buttonNumber)
        {
            if (buttonNumber > 6 || buttonNumber < 1)
            {
                return null;
            }

            return buttonSettings[buttonNumber - 1];
        }
    }
}
