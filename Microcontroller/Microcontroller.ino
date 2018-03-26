/*
 * File: Microcontroller.ino
 * Contains: Custom Mouse Arduino Leonardo sketch
 * 
 * This Arduino sketch is meant to interact with the Custom Mouse
 * Controller PC application to control different functions on the
 * PC. The sketch starts off by simulating a basic mouse and using
 * the connected joystick and buttons for cursor movement and
 * clicking. It disables mouse simulation and starts sending signals
 * over serial to the computer about the attached sensors once a
 * handshake with Custom Mouse Controller has been established,
 * allowing Custom Mouse Controller to take over the control of the
 * computer. The sketch will switch back to basic mouse simulation
 * if it receives a stop signal from Custom Mouse Controller.
 * 
 * Author: David Goguen
 * Original release: March 26, 2018
 * 
 * Last updated: March 26, 2018
 * 
 */

#include <Mouse.h>

/* constant integer to signify that nothing is connected to the input */
const int NOT_CONNECTED = 0;

/* constant integer to signify that a joystick is connected to the input */
const int JOYSTICK_CONNECTED = 1;

/* constant integer to signify that a button module is connected to the input */
const int BUTTONS_CONNECTED = 2;

/*
 * Input struct used to hold information about each
 * one of the four AUX inputs connected to the Arduino.
 * 
 * The inputMode variable stores what kind of module
 * is connected to the input. 
 * 
 * The xThreshold and yThreshold variables store the x
 * and y values reported by the analog inputs when the
 * joystick is centered, which are used to zero the
 * values being reported to Custom Mouse Controller.
 * They are -1 if they have not been initialized or
 * if a joystick is not connected to the input.
 * 
 * The inp1Val and inp2Val variables store the
 * readings on the input's analog pins, and are
 * -1 if nothing is connected.
 * 
 * The button1Pressed and button2Pressed variables
 * store whether or not a button on the input has
 * been pressed, and are false if nothing is connected
 * or a joystick is connected to the input.
 * 
 */
struct Input {
  int inputMode = NOT_CONNECTED;
  int xThreshold = -1;
  int yThreshold = -1;
  int inp1Val = -1;
  int inp2Val = -1;
  bool button1Pressed = false;
  bool button2Pressed = false;
};

/* stores whether or not the Arduino is connected to Custom Mouse Controller */
bool isConnected;

/* stores information about the 4 AUX inputs */
Input inputs[4];

/*
 * Sets up 8 analog pins as inputs for the 4 AUX jacks
 * and begins serial communication.
 */
void setup() {
  pinMode(A0, INPUT);
  pinMode(A1, INPUT);
  pinMode(A2, INPUT);
  pinMode(A3, INPUT);
  pinMode(A4, INPUT);
  pinMode(A5, INPUT);
  pinMode(A6, INPUT);
  pinMode(A7, INPUT);
  Serial.begin(9600);
}

/*
 * Infinite loop that runs the sketch.
 */
void loop() {
  detectModules(); // detect connected modules with each loop iteration

  // try to perform a handshake with Custom Mouse Controller if sketch
  // is in basic mouse mode
  if (!isConnected) {
    isConnected = handshake();

    if (!isConnected) {
      Mouse.begin();
      controlMouse();
    }
  } else {
    Mouse.end();

    // if handshake has been established, check for stop signal with
    // each loop iteration
    if (checkForGoodbye()) {
      isConnected = false;
      return;
    }

    // if there is no stop signal, send data to Custom Mouse Controller
    sendCommands();
  }
}

/*
 * Detects the modules connected to the AUX jacks
 * based on analog values reported by the analog
 * input pins and changes the input modes of each
 * of the 4 AUX inputs accordingly.
 */
void detectModules() {
  int readings[8];
  readings[0] = analogRead(A0);
  readings[1] = analogRead(A1);
  readings[2] = analogRead(A2);
  readings[3] = analogRead(A3);
  readings[4] = analogRead(A4);
  readings[5] = analogRead(A5);
  readings[6] = analogRead(A6);
  readings[7] = analogRead(A7);

  for (int i = 0; i < 8; i += 2) {
    // detect a joystick
    if ((readings[i] > 506 && readings[i] < 511) && (readings[i + 1] > 500 && readings[i + 1] < 505)) {
      // make sure that fluctuating readings on other analog inputs
      // do not simulate the insertion of a joystick if there is
      // already one connected
      bool onlyJoystick = true;
      for (int j = 0; j < 4; j++) {
        if (inputs[j].inputMode == JOYSTICK_CONNECTED) {
          onlyJoystick = false;
          break;
        }
      }
      if (onlyJoystick) {
        inputs[i / 2].inputMode = JOYSTICK_CONNECTED;
        // joystick was just connected, so initialize xThreshold and yThreshold
        if (inputs[i / 2].xThreshold == -1 && inputs[i / 2].yThreshold == -1) {
          // gives time for joystick module to be properly inserted
          // before reading the xThreshold and yThreshold
          delay(1000);
          inputs[i / 2].xThreshold = readings[i];
          inputs[i / 2].yThreshold = readings[i + 1];
        }
      }
    // detect a button module
    } else if (readings[i] > 1000 && readings[i + 1] > 1000 && inputs[i / 2].inputMode != JOYSTICK_CONNECTED) {
      inputs[i / 2].inputMode = BUTTONS_CONNECTED;
    // nothing is connected
    } else {
      // buttons were connected, so reset values
      if (inputs[i / 2].inputMode == BUTTONS_CONNECTED && (readings[i] < 1000 && readings[i] != 0) &&
          (readings[i + 1] < 1000 && readings[i + 1] != 0)) {
        inputs[i / 2].inputMode = NOT_CONNECTED;
        inputs[i / 2].button1Pressed = false;
        inputs[i / 2].button2Pressed = false;
      // a joystick was connected, so reset values
      } else if (inputs[i / 2].inputMode == JOYSTICK_CONNECTED && readings[i] > 1000 && inputs[i / 2].inp1Val < 1000
                 && readings[i + 1] > 1000 && inputs[i / 2].inp2Val < 1000) {
        inputs[i / 2].inputMode = NOT_CONNECTED;
        inputs[i / 2].xThreshold = -1;
        inputs[i / 2].yThreshold = -1;
      }
    }
    // failsafe to make sure that all values for input 
    // are reset if nothing is connected
    if (inputs[i / 2].inputMode == NOT_CONNECTED) {
      inputs[i / 2].inp1Val = -1;
      inputs[i / 2].inp2Val = -1;
      inputs[i / 2].xThreshold = -1;
      inputs[i / 2].yThreshold = -1;
    } else { // otherwise, store the analog pin readings
      inputs[i / 2].inp1Val = readings[i];
      inputs[i / 2].inp2Val = readings[i + 1];
    }
  }
}

/*
 * Controls the mouse based on readings from the joystick
 * during mouse simulation mode.
 */
void controlMouse() {
  for (int i = 0; i < 4; i++) {
    if (inputs[i].inputMode == JOYSTICK_CONNECTED) {
      // move cursor
      Mouse.move((inputs[i].inp1Val - inputs[i].xThreshold) / 150,
                 (-(inputs[i].inp2Val - inputs[i].yThreshold)) / 150, 0);
      // slows down cursor movement
      delay(8);
    } else if (inputs[i].inputMode == BUTTONS_CONNECTED) {
      // detect left-click
      // for any button module that is connected,
      // the left button will act as a left-click when
      // the sketch is in mouse simulation mode
      if (inputs[i].inp1Val == 0 && !inputs[i].button1Pressed) {
        Mouse.click();
        inputs[i].button1Pressed = true;
      } else if (inputs[i].inp1Val != 0 && inputs[i].button1Pressed) {
        inputs[i].button1Pressed = false;
      }
      // detect right-click
      // for any button module that is connected,
      // the right button will act as a right-click when
      // the sketch is in mouse simulation mode
      if (inputs[i].inp2Val == 0 && !inputs[i].button2Pressed) {
        Mouse.click(MOUSE_RIGHT);
        inputs[i].button2Pressed = true;
      } else if (inputs[i].inp2Val != 0 && inputs[i].button2Pressed) {
        inputs[i].button2Pressed = false;
      }
    }
  }
}

/*
 * Sends commands over serial to Custom Mouse Controller
 * based on values reported at each input on the analog
 * pins.
 */
void sendCommands() {
  // counts number of buttons from left to right and labels
  // them from numbers 1-6
  int buttonCounter = 0;
  for (int i = 0; i < 4; i++) {
    // send joystick position
    if (inputs[i].inputMode == JOYSTICK_CONNECTED) {
      Serial.print("X");
      Serial.print(inputs[i].inp1Val - inputs[i].xThreshold);
      Serial.print("Y");
      Serial.println(-(inputs[i].inp2Val - inputs[i].yThreshold));
    } else if (inputs[i].inputMode == BUTTONS_CONNECTED) {
      // only supports up to a max of 6 buttons, but we have 8 analog
      // inputs, so this is needed
      if (buttonCounter < 6) {
        buttonCounter++;
        // send left button pressed signal
        if (inputs[i].inp1Val == 0 && !inputs[i].button1Pressed) {
          Serial.println(buttonCounter);
          inputs[i].button1Pressed = true;
        } else if (inputs[i].inp1Val != 0 && inputs[i].button1Pressed) {
          inputs[i].button1Pressed = false;
        }
        buttonCounter++;
        // send right button pressed signal
        if (inputs[i].inp2Val == 0 && !inputs[i].button2Pressed) {
          Serial.println(buttonCounter);
          inputs[i].button2Pressed = true;
        } else if (inputs[i].inp2Val != 0 && inputs[i].button2Pressed) {
          inputs[i].button2Pressed = false;
        }
      }
    }
  }
}

/*
 * Checks to see if a stop signal from Custom Mouse Controller
 * has been received. Returns true if yes, and false otherwise.
 */
bool checkForGoodbye() {
  if (Serial.available() > 0) {
    String input = Serial.readString();
    if (input == "stop\n") {
      while (Serial.available()) {
        char dispose = Serial.read();
      }
      return true;
    }
  }
  return false;
}

/*
 * Checks to see if a handshake with Custom Mouse Controller
 * has been established. Returns true if yes, and false otherwise.
 */
bool handshake() {
  if (Serial.available() > 0) {
    String input = Serial.readString();
    if (input == "start\n") {
      while (Serial.available()) {
        char dispose = Serial.read();
      }
      Serial.println("start");
      return true;
    }
  }
  return false;
}

