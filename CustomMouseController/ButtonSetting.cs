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

        public enum ButtonSettingMode { None, LeftClick, RightClick, OnScreenKeyboard, TypePhrase, OpenProgram, KeyboardShortcut };

        private readonly Button button;
        private ButtonSettingMode mode;
        private string phrase;
        private string programDir;
        private string[] keyCombination;

        public ButtonSetting(Button button)
        {
            this.button = button;
            this.mode = ButtonSettingMode.None;
            this.phrase = String.Empty;
            this.programDir = String.Empty;
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

        public Button AssignedButton
        {
            get
            {
                return button;
            }
        }

        public string ProgramDirectory
        {
            get
            {
                return programDir;
            }
            set
            {
                programDir = value;
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
