/*
 * File: ButtonSetting.cs
 * Contains: ButtonSetting class
 * 
 * This class is used to store the current configuration of each
 * of the buttons connected to the Arduino Leonardo microcontroller.
 * It is serializable so its state can be saved and restored with
 * the closing and opening of the application.
 * 
 * Author: David Goguen
 * Original release: March 26, 2018
 * 
 * Last updated: March 26, 2018
 * 
 */

using System;
using System.Windows.Forms;

namespace CustomMouseController
{
    [Serializable]
    public class ButtonSetting
    {
        /* enum to specify the current setting mode of each button */
        public enum ButtonSettingMode { None, LeftClick, RightClick, OnScreenKeyboard, TypePhrase, OpenProgram, OpenWebsite, KeyboardShortcut };

        /* stores a reference to the associated button in the UI and is updated at each application run */
        [NonSerialized]
        private Button button;

        /* stores the current mode of the button */
        private ButtonSettingMode mode;

        /* stores the phrase that is to be typed if button is in TypePhrase mode */
        private string phrase;

        /* stores the URL of the website that is to be opened if button is in OpenWebsite mode */
        private string url;

        /* stores the info about the program that is to be opened if button is in OpenProgram mode */
        private ProgramInfo program;

        /* stores the key combination in plain text that is to be performed if button is in KeyboardShortcut mode */
        private string[] keyCombination;

        /*
         * Main constructor that takes a reference to the the associated
         * UI button. All other values are initialized to empty values.
         */
        public ButtonSetting(Button button)
        {
            this.button = button;
            this.mode = ButtonSettingMode.None;
            this.phrase = String.Empty;
            this.url = String.Empty;
        }

        /*
         * Getter and setter for the button mode.
         */
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

        /*
         * Getter and setter for the phrase to type when button
         * is in TypePhrase mode.
         */
        public string Phrase
        {
            get
            {
                return phrase;
            }
            set
            {
                if (value == null) // never allow a null phrase
                    return;

                phrase = value;
            }
        }

        /*
         * Getter and setter for the URL to open when button is
         * in OpenWebsite mode.
         */
        public string WebsiteURL
        {
            get
            {
                return url;
            }
            set
            {
                if (value == null) // never allow a null website
                    return;

                url = value;
            }
        }

        /*
         * Getter and setter for associated UI button.
         */
        public Button AssignedButton
        {
            get
            {
                return button;
            }
            set
            {
                button = value;
            }
        }

        /*
         * Getter and setter for info about program to open
         * when button is in OpenProgram mode.
         */
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

        /*
         * Getter and setter for key combination that is
         * to be performed when button is in KeyboardShortcut
         * mode.
         */
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
