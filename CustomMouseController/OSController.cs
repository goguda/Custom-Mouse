using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.ComponentModel;
using System;
using System.Text;
using System.Linq;

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
            SendKeys.SendWait(phrase);
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
            Process.Start("osk.exe");
        }

        public static void OpenExecutable(string path)
        {
            try
            {
                Process.Start(path);
            }
            catch
            {
                MessageBox.Show("There was an error opening the program assigned to that button.", "Custom Mouse Controller - Error Opening Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            if (keys == null)
                return;

            StringBuilder commandKeys = new StringBuilder();
            StringBuilder otherKeys = new StringBuilder();

            int arrLength = keys.Count(x => !string.IsNullOrEmpty(x));
            for (int i = 0; i < arrLength; i++)
            {
                switch(keys[i])
                {
                    case "CTRL":
                        commandKeys.Append("^");
                        break;
                    case "ALT":
                        commandKeys.Append("%");
                        break;
                    case "SHIFT":
                        commandKeys.Append("+");
                        break;
                    case "ESC":
                        otherKeys.Append("{ESC}");
                        break;
                    case "SPACE":
                        otherKeys.Append(" ");
                        break;
                    case "TAB":
                        otherKeys.Append("{TAB}");
                        break;
                    case "BACKSPACE":
                        otherKeys.Append("{BACKSPACE}");
                        break;
                    case "DELETE":
                        otherKeys.Append("{DEL}");
                        break;
                    case "ENTER":
                        otherKeys.Append("{ENTER}");
                        break;
                    case "END":
                        otherKeys.Append("{END}");
                        break;
                    case "INSERT":
                        otherKeys.Append("{INSERT}");
                        break;
                    case "HOME":
                        otherKeys.Append("{HOME}");
                        break;
                    case "PGEUP":
                        otherKeys.Append("{PGUP}");
                        break;
                    case "PGEDWN":
                        otherKeys.Append("{PGDN}");
                        break;
                    case "F1":
                        otherKeys.Append("{F1}");
                        break;
                    case "F2":
                        otherKeys.Append("{F2}");
                        break;
                    case "F3":
                        otherKeys.Append("{F3}");
                        break;
                    case "F4":
                        otherKeys.Append("{F4}");
                        break;
                    case "F5":
                        otherKeys.Append("{F5}");
                        break;
                    case "F6":
                        otherKeys.Append("{F6}");
                        break;
                    case "F7":
                        otherKeys.Append("{F7}");
                        break;
                    case "F8":
                        otherKeys.Append("{F8}");
                        break;
                    case "F9":
                        otherKeys.Append("{F9}");
                        break;
                    case "F10":
                        otherKeys.Append("{F10}");
                        break;
                    case "F11":
                        otherKeys.Append("{F11}");
                        break;
                    case "F12":
                        otherKeys.Append("{F12}");
                        break;
                    default:
                        otherKeys.Append("{" + keys[i] + "}");
                        break;
                }
            }
            SendKeys.SendWait(commandKeys.ToString() + "(" + otherKeys.ToString() + ")");
        }
    }
}
