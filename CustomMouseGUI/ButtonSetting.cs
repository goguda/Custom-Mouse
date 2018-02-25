using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomMouseGUI
{
    class ButtonSetting
    {

        public enum SettingMode { None, LeftClick, RightClick, OnScreenKeyboard, TypePhrase, OpenProgram, KeyboardShortcut };

        private readonly Button button;
        private SettingMode mode;

        public ButtonSetting(Button button)
        {
            this.button = button;
            this.mode = SettingMode.None;
        }

        public SettingMode Setting
        {
            get
            {
                return mode;
            }
            set
            {
                mode = value;
            }
        }

        public Button AssignedButton
        {
            get
            {
                return button;
            }
        }

    }
}
