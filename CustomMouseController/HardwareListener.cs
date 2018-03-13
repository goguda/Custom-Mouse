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
    public sealed class HardwareListener
    {
        private SerialPort device;
        private DeviceSettings settings;
        private bool connected;

        public HardwareListener()
        {
            settings = DeviceSettings.Instance;
        }

        public void Start()
        {
            ListenForConnectDisconnect();
        }

        private void ListenForConnectDisconnect()
        {
            while (true)
            {
                OSController.MoveCursor(5, 5);
                bool isConnected = false;
                ManagementObjectSearcher portSearcher = new ManagementObjectSearcher("Select * From Win32_SerialPort");
                ManagementObjectCollection ports = portSearcher.Get();

                foreach (ManagementObject port in ports)
                {
                    string portName = port.GetPropertyValue("Description").ToString();

                    if (portName.Contains("COM2"))
                    {
                        if (device == null)
                        {
                            device = new SerialPort(port.GetPropertyValue("DeviceID").ToString());
                            device.Open();
                            device.DataReceived += new SerialDataReceivedEventHandler(device_DataReceived);
                        }
                        isConnected = true;
                        break;
                    }
                }

                if (!isConnected && device != null)
                {
                    device.Close();
                    device.Dispose();
                }

                if (isConnected != connected)
                {
                    Console.WriteLine("test");
                }

                connected = isConnected;

                // check once every 100 milliseconds
                Thread.Sleep(100);
            }
        }

        private void device_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string command = device.ReadLine();

            if (!String.IsNullOrEmpty(command))
                Console.WriteLine(command.Substring(0, command.IndexOf("\r")));
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
    }
}
