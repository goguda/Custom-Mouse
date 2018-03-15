using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Management;
using System.Threading;

namespace CustomMouseController
{
    public sealed class HardwareListener : IDisposable
    {
        private static volatile HardwareListener instance;
        private SerialPort device;
        private DeviceSettings settings;
        private bool connected;
        private bool disposed;

        private HardwareListener()
        {
            settings = DeviceSettings.Instance;
        }

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

        public void Start()
        {
            if (connected)
                return;

            while (!disposed)
            {
                if (!connected)
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
                                device.Open();
                                connected = PerformHandshake();
                                device.DataReceived += new SerialDataReceivedEventHandler(device_DataReceived);
                            }

                        if (connected)
                            break;
                        }
                    }
                }
                else
                {
                    string data = device.ReadLine();

                    if (data.Contains("X"))
                    {
                        MoveMouse(data.Substring(0, data.IndexOf("\r")));
                    }
                    else
                    {
                        switch (data)
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

        private bool PerformHandshake()
        {
            if (device == null || !device.IsOpen)
                return false;

            device.WriteLine("start");

            return device.ReadLine().Contains("start");
        }

        private void device_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string command = device.ReadLine();

            if (!String.IsNullOrEmpty(command))
                Console.WriteLine(command.Substring(0, command.IndexOf("\r")));
        }

        private void MoveMouse(string command)
        {
            int i = command.IndexOf("Y");
            int x = Int32.Parse(command.Substring(2, i));
            int y = Int32.Parse(command.Substring(i + 2));

            OSController.MoveCursor(x, y);
        }

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
                    OSController.TypePhrase(button.Phrase);
                    break;
                case ButtonSetting.ButtonSettingMode.OpenProgram:
                    OSController.OpenExecutable(button.ProgramInfo.Path);
                    break;
                case ButtonSetting.ButtonSettingMode.OpenWebsite:
                    OSController.OpenWebsite(button.WebsiteURL);
                    break;
                case ButtonSetting.ButtonSettingMode.KeyboardShortcut:
                    OSController.PerformKeyboardShortcut(button.KeyCombination);
                    break;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (device != null)
                    {
                        device.Close();
                        device.Dispose();
                    }
                }
            }

            disposed = true;
        }

    }
}
