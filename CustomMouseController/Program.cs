using System;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace CustomMouseController
{
    static class Program
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        private static extern IntPtr SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool newInstance = true;
            using (Mutex mutex = new Mutex(true, "Custom Mouse Controller", out newInstance))
            {
                // Start new instance of application
                if (newInstance)
                {
                    // Start hardware listener before GUI on its own thread
                    HardwareListener listener = HardwareListener.Instance;
                    Thread listeningThread = new Thread(new ThreadStart(listener.Start));
                    listeningThread.Start();

                    // Start GUI
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    if (DeviceSettings.Instance.LoadedPreviousSession)
                    {
                        frmMain form = new frmMain();
                        form.Opacity = 0;
                        form.ShowInTaskbar = false;
                        form.Show();
                        form.Hide();
                        form.ShowInTaskbar = true;
                        form.Opacity = 100;
                        Application.Run();
                    }
                    else
                    {
                        Application.Run(new frmMain());
                    }
                }
                else // Application is already loaded; show control center
                {
                    Process current = Process.GetCurrentProcess();
                    foreach (Process x in Process.GetProcessesByName(current.ProcessName))
                    {
                        if (x.Id != current.Id && current.MainModule.FileName == x.MainModule.FileName)
                        {
                            IntPtr windowHandle = FindWindow(null, "Custom Mouse Control Center");
                            ShowWindow(windowHandle, 5);
                            SetForegroundWindow(windowHandle);
                            break;
                        }
                    }
                }
            }
        }
    }
}
