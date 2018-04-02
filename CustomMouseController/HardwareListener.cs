/*
 * File: HardwareListener.cs
 * Contains: HardwareListener class
 * 
 * This class is used to communicate with the Arduino Leonardo
 * microcontroller running the Custom Mouse sketch and execute
 * the computer commands specified in the device settings based
 * on information about the sensors received from the Arduino
 * over serial. This class implements the singleton design
 * pattern to make sure that only one connection to the Arduino
 * is attempted. It is also designed to be accessed from
 * across different threads as necessary.
 * 
 * The communication should be started by calling the Start()
 * method on the instance from its own thread to prevent the
 * current thread from locking up.
 * 
 * Author: David Goguen
 * Original release: March 26, 2018
 * 
 * Last updated: March 26, 2018
 * 
 */

using System;
using System.IO.Ports;
using System.Management;

namespace CustomMouseController
{
    public sealed class HardwareListener : IDisposable
    {
        /* stores a reference to the instance of the class and declared volatile so it can be accessed by multiple threads */
        private static volatile HardwareListener instance;

        /* stores a reference to a SerialPort object used to communicate with the Arduino */
        private SerialPort device;

        /* stores a reference to the device settings instance */
        private DeviceSettings settings;

        /* stores whether or not the computer is currently connected to the Arduino */
        private bool connected;

        /* stores whether or not the Dispose() method has been called and executed successfully */
        private bool disposed;

        /* stores the number of loop iterations it should take for the next movement of the cursor to occur,
         * which controls the speed of the cursor */
        private int cursorSpeedTick;

        /*
         * Main constructor that should only be accessed from within
         * this class itself if an instance of the class has not already
         * been created. Instantiates the class and saves the reference
         * to the instance of DeviceSettings.
         */
        private HardwareListener()
        {
            settings = DeviceSettings.Instance;
        }

        /*
         * Getter for the instance of HardwareListener singleton. This
         * is read-only. If the instance does not exist, it is created
         * using the main constructor.
         */
        public static HardwareListener Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HardwareListener();
                }

                return instance;
            }
        }

        /*
         * Starts the communcation process between the computer and
         * Arduino. This method runs a loop until Dispose() is called
         * and processes all communication to and from the Arduino.
         */
        public void Start()
        {
            if (connected) // do not start a new loop if Start() is called again
                return;

            while (!disposed)
            {
                if (!connected) // while not connected, search for Arduino on each serial port and attempt to connect if it is found
                {
                    ManagementObjectSearcher portSearcher = new ManagementObjectSearcher("Select * From Win32_SerialPort");
                    ManagementObjectCollection ports = portSearcher.Get();

                    foreach (ManagementObject port in ports)
                    {
                        string portName = port.GetPropertyValue("Description").ToString();

                        if (portName.Contains("Arduino Leonardo"))
                        {
                            if (device == null)
                            {
                                device = new SerialPort(port.GetPropertyValue("DeviceID").ToString());
                                device.BaudRate = 9600;
                                device.DtrEnable = true;
                                device.RtsEnable = true;
                                device.Handshake = Handshake.None;
                                device.Parity = Parity.None; 
                                device.StopBits = StopBits.Two;
                                device.DataBits = 8;
                                try
                                {
                                    device.Open();
                                }
                                catch
                                {
                                    continue;
                                }
                                // perform a handshake to ensure we have the right Arduino and that it is working properly
                                connected = PerformHandshake();
                            }

                            // initialize cursorSpeedTick if connected and break the loop
                            if (connected)
                            {
                                cursorSpeedTick = 12 - settings.JoystickSetting.SpeedMultiplier;
                                break;
                            }
                        }
                    }
                }
                else // connected to Arduino, so read and process data that is being sent
                {
                    string data = String.Empty;
                    try
                    {
                        data = device.ReadLine();
                    }
                    catch // if there is any error reading from the Arduino, disconnect and start search loop again
                    {
                        connected = false;
                        device.Dispose();
                        device = null;
                        continue;
                    }

                    if (data.Contains("X")) // joystick signal from Arduino
                    {
                        cursorSpeedTick--; // decrement with each iteration of loop

                        if (cursorSpeedTick == 0) // if cursorSpeedTick reaches 0, move cursor accordingly and reset cursorSpeedTick
                        {
                            MoveMouse(data.Substring(0, data.IndexOf("\r")));
                            cursorSpeedTick = 12 - settings.JoystickSetting.SpeedMultiplier;
                        }
                    }
                    else // button signal from Arduino
                    {
                        switch (data.Substring(0, data.IndexOf("\r")))
                        {
                            case "1":
                                PerformButtonAction(settings.GetButtonSetting(1));
                                break;
                            case "2":
                                PerformButtonAction(settings.GetButtonSetting(2));
                                break;
                            case "3":
                                PerformButtonAction(settings.GetButtonSetting(3));
                                break;
                            case "4":
                                PerformButtonAction(settings.GetButtonSetting(4));
                                break;
                            case "5":
                                PerformButtonAction(settings.GetButtonSetting(5));
                                break;
                            case "6":
                                PerformButtonAction(settings.GetButtonSetting(6));
                                break;
                        }
                    }
                }
            }
        }

        /*
         * Sends a start signal to the Arduino and returns true if the
         * Arduino sends a start signal back, and false otherwise.
         */
        private bool PerformHandshake()
        {
            if (device == null || !device.IsOpen)
                return false;

            device.WriteLine("start");

            return device.ReadLine() == "start\r";
        }

        /*
         * Moves the mouse cursor using a string command passed as a parameter
         * of format XaYb, where a and b are the relative movement of the joystick
         * in the X and Y direction, respectively.
         */
        private void MoveMouse(string command)
        {

            int i = command.IndexOf("Y"); // check where to split the command to get the X and Y movement values
            int x = Int32.Parse(command.Substring(1, i - 1));
            int y = Int32.Parse(command.Substring(i + 1));

            // values are divided based on the joystick sensitivity multiplier to control how reactive
            // the cursor is from the movement of the joystick
            OSController.MoveCursor(x / (221 - 15 * settings.JoystickSetting.SensitivityMultiplier), y / (221 - 15 * settings.JoystickSetting.SensitivityMultiplier));
        }

        /*
         * Executes the appropriate action from the passed ButtonSetting
         * instance.
         */
        private void PerformButtonAction(ButtonSetting button)
        {
            switch (button.Setting)
            {
                case ButtonSetting.ButtonSettingMode.LeftClick:
                    OSController.SimulateLeftClick();
                    break;
                case ButtonSetting.ButtonSettingMode.RightClick:
                    OSController.SimulateRightClick();
                    break;
                case ButtonSetting.ButtonSettingMode.OnScreenKeyboard:
                    OSController.OpenOnScreenKeyboard();
                    break;
                case ButtonSetting.ButtonSettingMode.TypePhrase:
                    if (!String.IsNullOrEmpty(button.Phrase))
                        OSController.TypePhrase(button.Phrase);
                    break;
                case ButtonSetting.ButtonSettingMode.OpenProgram:
                    if (button.ProgramInfo != null && !String.IsNullOrEmpty(button.ProgramInfo.Path))
                        OSController.OpenExecutable(button.ProgramInfo.Path);
                    break;
                case ButtonSetting.ButtonSettingMode.OpenWebsite:
                    if (!String.IsNullOrEmpty(button.WebsiteURL))
                    OSController.OpenWebsite(button.WebsiteURL);
                    break;
                case ButtonSetting.ButtonSettingMode.KeyboardShortcut:
                    if (button.KeyCombination != null)
                        OSController.PerformKeyboardShortcut(button.KeyCombination);
                    break;
            }
        }

        /*
         * Disposes of the HardwareListener instance.
         */
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /*
         * Private implementation of Dispose(bool) inherited from
         * IDisposable that disposes of the SerialPort object instance
         * and marks the HardwareListener instance as disposed.
         */
        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (device != null && device.IsOpen)
                    {
                        device.WriteLine("stop"); // send stop signal to Arduino on Dispose()
                        device.Close();
                    }
                    if (device != null)
                    {
                        device.Dispose();
                    }
                }
            }

            disposed = true;
        }

    }
}
