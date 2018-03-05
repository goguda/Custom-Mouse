﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace CustomMouseController
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Start hardware listener before GUI on its own thread
            HardwareListener listener = new HardwareListener();
            Thread listeningThread = new Thread(new ThreadStart(listener.Start));
            listeningThread.Start();

            // Start GUI
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());

            // Close listener thread after application is closed
            listeningThread.Abort();
        }
    }
}