/*
 * File: DeviceSettings.cs
 * Contains: DeviceSettings class
 * 
 * This class is used to store the current configuration of each
 * button and the joystick that are connected to the Arduino
 * Leonardo microcontroller. It implements the singleton design 
 * pattern and is designed to be updated and read by the UI and 
 * controller threads simultaneously. It is serialized at application
 * exit and is restored at application opening so the settings the
 * user specified last time can be restored.
 * 
 * Author: David Goguen
 * Original release: March 26, 2018
 * 
 * Last updated: March 26, 2018
 * 
 */

using System;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CustomMouseController
{
    [Serializable]
    public class DeviceSettings
    {
        /* stores a reference to the instance of the class and declared volatile so it can be accessed by multiple threads */
        private static volatile DeviceSettings instance;

        /* stores whether or not the settings have been restored from the previous session */
        [NonSerialized]
        private bool loadedPreviousSession;

        /* stores whether or not one or more programs assigned to the buttons have been moved or uninstalled since last session */
        [NonSerialized]
        private bool missingProgramsSinceLastSession;

        /* stores whether or not the application is to run automatically at user sign-in */
        private bool runAtStartup;

        /* stores the path to the current user's local AppData folder */
        private string appDataFolder;

        /* stores the path, including the file name, of the serialized device settings */
        private string saveFile;

        /* stores the assigned joystick settings */
        private JoystickSetting joystickSetting;

        /* stores the assigned button settings */
        private ButtonSetting[] buttonSettings;

        /*
         * Main constructor that should only be accessed from within
         * this class itself if there is no serialized file to restore
         * from. Settings are all initialized to unassigned values.
         */
        private DeviceSettings()
        {
            buttonSettings = new ButtonSetting[6];
            loadedPreviousSession = false;
            missingProgramsSinceLastSession = false;
            runAtStartup = true;
            appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        }

        /*
         * Getter for the instance of DeviceSettings singleton. This
         * is read-only. If the instance does not exist, it is attempted
         * to be loaded from a serialized file, and if it cannot be, a
         * default instance is created.
         */
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
                    catch // no need to catch any individual exceptions since we want the same behaviour no matter what the exception is
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

                            // check that the programs still exist and if not, display a warning
                            // also load icons into programs again since they don't serialize well
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
                        catch // same situation as above; no need to catch individual exceptions
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

        /*
         * Getter and setter for the settings of the joystick.
         */
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

        /*
         * Getter for the boolean indicating if the settings were 
         * restored from a previous session. It is read-only.
         */
        public bool LoadedPreviousSession
        {
            get
            {
                return loadedPreviousSession;
            }
        }

        /*
         * Getter for the boolean indicating if one or more programs
         * that were assigned to the buttons in the previous session
         * have been moved or uninstalled. It is read-only.
         */
        public bool NotAllProgramsLoaded
        {
            get
            {
                return missingProgramsSinceLastSession;
            }
        }

        /*
         * Getter and setter for the boolean indicating whether or
         * not the application should automatically run when the user
         * logs in.
         */
        public bool RunAtStartup
        {
            get
            {
                return runAtStartup;
            }
            set
            {
                runAtStartup = value;
            }
        }

        /*
         * Sets the settings for one of the device buttons between
         * 1-6 and takes the button number and ButtonSetting instance
         * as arguments.
         */
        public void SetButtonSetting(int buttonNumber, ButtonSetting settings)
        {
            if (buttonNumber > 6 || buttonNumber < 1 || settings == null)
            {
                return;
            }

            buttonSettings[buttonNumber - 1] = settings;
        }

        /*
         * Returns a reference to the settings for one of the device
         * buttons between 1-6 and takes the button number as an argument.
         * Returns null if the button number is invalid.
         */
        public ButtonSetting GetButtonSetting(int buttonNumber)
        {
            if (buttonNumber > 6 || buttonNumber < 1)
            {
                return null;
            }

            return buttonSettings[buttonNumber - 1];
        }

        /*
         * Saves the current state of the device settings to a serialized
         * file in the user's local AppData directory. It should be called
         * whenever the application is exiting.
         */
        public void SaveSettings()
        {
            // create directory in AppData folder if it does not exist
            if (!Directory.Exists(appDataFolder + @"\Custom Mouse Controller\"))
            {
                Directory.CreateDirectory(appDataFolder + @"\Custom Mouse Controller\");
            }

            // write serialized file to folder with name CustomMouseSettings.cms
            saveFile = appDataFolder + @"\Custom Mouse Controller\CustomMouseSettings.cms";
            FileStream output = new FileStream(saveFile, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(output, instance);
            output.Close();
        }
    }
}
