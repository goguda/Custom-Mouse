using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Custom_Mouse
{
    class OSController
    {
        public void OpenOnScreenKeyboard()
        {
            Process.Start("osk.exe");
        }
    }
}
