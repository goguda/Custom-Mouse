using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Management;

namespace CustomMouseGUI
{
    sealed class HardwareListener
    {

        private HardwareListener controller;
        private SerialPort device;
        private bool connected;

        public HardwareListener()
        {

            connected = false;
            ManagementObjectSearcher portSearcher = new ManagementObjectSearcher("Select * From Win32_SerialPort");
            ManagementObjectCollection ports = portSearcher.Get();

            foreach (ManagementObject port in ports)
            {
                string portName = port.GetPropertyValue("Description").ToString();

                if (portName.Contains("Arduino"))
                {
                    device = new SerialPort(port.GetPropertyValue("DeviceID").ToString());
                    device.Open();
                    device.DataReceived += new SerialDataReceivedEventHandler(device_DataReceived);
                    connected = true;
                    break;
                }
            }
        }

        private void device_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string command = device.ReadLine();

            if (!String.IsNullOrEmpty(command))
                Console.WriteLine(command.Substring(0, command.IndexOf("\r")));
        }
    }
}
