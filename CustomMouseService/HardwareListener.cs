using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Management;
using System.Threading;

namespace CustomMouseService
{
    public sealed class HardwareListener
    {

        private HardwareListener controller;
        private Thread connection;
        private SerialPort device;
        private bool connected;

        public HardwareListener()
        {
            this.connection = new Thread(new ThreadStart(ListenForConnectDisconnect));
        }

        public void Start()
        {
            connection.Start();
        }

        private void ListenForConnectDisconnect()
        {
            while (true)
            {
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


    }
}
