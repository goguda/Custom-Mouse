using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.ComponentModel;
using System;

namespace CustomMouseController
{
    static class OSController
    {
        // Reference: https://www.codeproject.com/Articles/32556/Auto-Clicker-C
        private const int MOUSEEVENTF_MOVE =      0x0001; /* mouse move */
        private const int MOUSEEVENTF_LEFTDOWN =  0x0002; /* left button down */
        private const int MOUSEEVENTF_LEFTUP =    0x0004; /* left button up */
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008; /* right button down */
        private const int MOUSEEVENTF_RIGHTUP =   0x0010; /* right button up */


        [DllImport("user32.dll",
        CharSet = CharSet.Auto, CallingConvention= CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons,
        int dwExtraInfo);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);


        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int Wow64DisableWow64FsRedirection(ref IntPtr ptr);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int Wow64EnableWow64FsRedirection(ref IntPtr ptr);

        public static void MoveCursor(int x, int y)
        {
            Cursor.Position = new Point(Cursor.Position.X + x, Cursor.Position.Y + y);
        }

        public static void TypePhrase(string phrase)
        {
            SendKeys.Send(phrase);
        }

        public static void SimulateLeftClick()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        public static void SimulateRightClick()
        {
            mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
        }

        public static void OpenOnScreenKeyboard()
        {
            try
            {
                Process.Start("osk.exe");
            }
            catch (Win32Exception) // Needed for Windows 10 and some other 64-bit versions of Windows when running in 32-bit mode
            {
                IntPtr wow64 = IntPtr.Zero;
                Wow64DisableWow64FsRedirection(ref wow64);
                Process.Start("osk.exe");
                Wow64EnableWow64FsRedirection(ref wow64);
            }
        }

        public static void OpenExecutable(string path)
        {
            Process.Start(path);
        }

        public static void OpenWebsite(string url)
        {
            if (url.Length < 7 || url.Substring(0, 7) != "http://" && url.Substring(0, 8) != "https://")
            {
                url = "http://" + url;
            }

            Process.Start(url);
        }

        public static void PerformKeyboardShortcut(string[] keys)
        {

        }
    }
}
