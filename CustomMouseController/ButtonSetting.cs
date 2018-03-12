using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomMouseController
{   
    [Serializable]
    public class ButtonSetting
    {

        public enum ButtonSettingMode { None, LeftClick, RightClick, OnScreenKeyboard, TypePhrase, OpenProgram, OpenWebsite, KeyboardShortcut };

        private readonly Button button;
        private ButtonSettingMode mode;
        private string phrase;
        private string url;
        private ProgramInfo program;
        private string[] keyCombination;

        public ButtonSetting(Button button)
        {
            this.button = button;
            this.mode = ButtonSettingMode.None;
            this.phrase = String.Empty;
        }

        public ButtonSettingMode Setting
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

        public string Phrase
        {
            get
            {
                return phrase;
            }
            set
            {
                phrase = value;
            }
        }

        public string WebsiteURL
        {
            get
            {
                return url;
            }
            set
            {
                url = value;
            }
        }

        public Button AssignedButton
        {
            get
            {
                return button;
            }
        }

        public ProgramInfo ProgramInfo
        {
            get
            {
                return program;
            }
            set
            {
                program = value;
            }
        }

        public string[] KeyCombination
        {
            get
            {
                return keyCombination;
            }
            set
            {
                keyCombination = value;
            }
        }

    }
}
