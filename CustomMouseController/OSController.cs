/*
 * File: OSController.cs
 * Contains: OSController class
 * 
 * This static class is used to perform OS functions such
 * as controlling the mouse, performing keyboard shortcuts,
 * and starting processes.
 * 
 * Author: David Goguen
 * Original release: March 26, 2018
 * 
 * Last updated: April 2, 2018
 * 
 */

using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Text;
using System.Linq;

namespace CustomMouseController
{
    static class OSController
    {
        /* constant values for mouse activity used with mouse_event from user32.dll */
        // Reference: https://www.codeproject.com/Articles/32556/Auto-Clicker-C
        private const int MOUSEEVENTF_MOVE =      0x0001; /* mouse move */
        private const int MOUSEEVENTF_LEFTDOWN =  0x0002; /* left button down */
        private const int MOUSEEVENTF_LEFTUP =    0x0004; /* left button up */
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008; /* right button down */
        private const int MOUSEEVENTF_RIGHTUP =   0x0010; /* right button up */
        
        /*
         * Low-level Windows method imported from user32.dll that controls
         * mouse functions.
         */
        [DllImport("user32.dll",
        CharSet = CharSet.Auto, CallingConvention= CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons,
        int dwExtraInfo);

        /*
         * Moves the cursor by x and y pixels.
         */
        public static void MoveCursor(int x, int y)
        {
            Cursor.Position = new Point(Cursor.Position.X + x, Cursor.Position.Y + y);
        }

        /*
         * Types a phrase passed as a string parameter into an active
         * text input field.
         */
        public static void TypePhrase(string phrase)
        {
            SendKeys.SendWait(phrase);
        }

        /*
         * Simulates a left-click of the mouse.
         */
        public static void SimulateLeftClick()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        /*
         * Simulates a right-click of the mouse.
         */
        public static void SimulateRightClick()
        {
            mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
        }

        /*
         * Opens the Windows On-Screen Keyboard.
         * Note: This method will throw an exception if called from a 64-bit
         * version of Windows in a 32-bit application.
         */
        public static void OpenOnScreenKeyboard()
        {
            Process.Start("osk.exe");
        }

        /*
         * Opens a process that is passed as a string argument
         * and shows a message box if the process was not started
         * successfully.
         */
        public static void OpenExecutable(string path)
        {
            try
            {
                Process.Start(path);
            }
            catch
            {
                ; // hopefully implement a top-most message box later, but for now do nothing
            }
        }

        /*
         * Opens a website in the user's default web browser
         * using the URL of the website passed as a string argument.
         */
        public static void OpenWebsite(string url)
        {
            try
            {
                if (url.Length < 7 || url.Substring(0, 7) != "http://" && url.Substring(0, 8) != "https://")
                {
                    url = "http://" + url;
                }

                Process.Start(url);
            }
            catch
            {
                ; // hopefully implement a top-most message box later, but for now do nothing            
            }
        }

        /*
         * Performs the keyboard shortcut passed as an array of
         * strings.
         * */
        public static void PerformKeyboardShortcut(string[] keys)
        {
            if (keys == null)
                return;

            StringBuilder commandKeys = new StringBuilder(); // stores CTRL, ALT, and SHIFT keys
            StringBuilder otherKeys = new StringBuilder(); // stores all other keys

            int arrLength = keys.Count(x => !string.IsNullOrEmpty(x));
            for (int i = 0; i < arrLength; i++)
            {
                switch(keys[i])
                {
                    // CTRL, ALT, and SHIFT keys
                    case "CTRL":
                        commandKeys.Append("^");
                        break;
                    case "ALT":
                        commandKeys.Append("%");
                        break;
                    case "SHIFT":
                        commandKeys.Append("+");
                        break;
                    // other control keys
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
                    // function keys
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
                    // letters and numbers
                    default:
                        otherKeys.Append("{" + keys[i].ToLower() + "}");
                        break;
                }
            }
            // combine control and other keys and perform combination
            SendKeys.SendWait(commandKeys.ToString() + "(" + otherKeys.ToString() + ")");
        }
    }
}
