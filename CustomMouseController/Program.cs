/*
 * File: Program.cs
 * Contains: Program class
 * 
 * This class is the main entry point of the application
 * and starts the instance of HardwareListener on its own
 * thread, along with the UI on another thread.
 * 
 * Author: David Goguen
 * Original release: March 26, 2018
 * 
 * Last updated: March 26, 2018
 * 
 */

using System;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace CustomMouseController
{
    static class Program
    {
        /*
         * Low-level Windows method imported from user32.dll that shows
         * a window.
         */
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        /*
         * Low-level Windows method imported from user32.dll that sets
         * a window as the foreground window given the window's handle.
         */
        [DllImport("user32.dll")]
        private static extern IntPtr SetForegroundWindow(IntPtr hWnd);

        /*
         * Low-level Windows method imported from user32.dll that finds
         * a window based on its name.
         */
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool newInstance = true; // indicates whether or not an instance of Custom Mouse Controller is already runnning
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

                    // start in system tray without showing window if it is not the first time running the application
                    if (DeviceSettings.Instance.LoadedPreviousSession)
                    {
                        FrmMain form = new FrmMain();
                        form.Opacity = 0;
                        form.ShowInTaskbar = false;
                        form.Show();
                        form.Hide();
                        form.ShowInTaskbar = true;
                        form.Opacity = 100;
                        Application.Run();
                    }
                    else // otherwise, show the window
                    {
                        Application.Run(new FrmMain());
                    }

                    // the HardwareListener instance will already be disposed by here, so aborting this thread is safe
                    listeningThread.Abort();
                }
                else // application is already loaded; show control center
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
