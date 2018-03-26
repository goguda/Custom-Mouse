/*
 * File: JoystickSetting.cs
 * Contains: JoystickSetting class
 * 
 * This class is used to store the current settings for the
 * joystick that is connected to the Arduino Leonardo
 * microcontroller. It is serializable so its state can be 
 * saved and restored with the closing and opening of the
 * application.
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
    public class JoystickSetting
    {
        /* stores a reference to the associated button in the UI and is updated at each application run */
        [NonSerialized]
        private Button button;

        /* stores a value from 1-11 that is updated from the UI and used to determine the speed of the cursor with
         * movement of the joystick */
        private int speedMultiplier;

        /* stores a value from 1-11 that is updated from the UI and used to determine how much movement of the
         * joystick it takes before the cursor starts moving */
        private int sensitivityMultiplier;

        /*
         * Main constructor that takes a reference to the associated
         * UI button. Initializes the default value of the speedMultiplier
         * and sensitivityMultiplier to a middle value of 6.
         */
        public JoystickSetting(Button uiButton)
        {
            button = uiButton;
            speedMultiplier = 6;
            sensitivityMultiplier = 6;
        }

        /*
         * Getter and setter for the speed multiplier.
         */
        public int SpeedMultiplier
        {
            get
            {
                return speedMultiplier;
            }
            set
            {
                speedMultiplier = value;
            }
        }

        /*
         * Getter and setter for the sensitivity multiplier.
         */
        public int SensitivityMultiplier
        {
            get
            {
                return sensitivityMultiplier;
            }
            set
            {
                sensitivityMultiplier = value;
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
    }
}
