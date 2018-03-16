#include <Mouse.h>

const int NOT_CONNECTED = 0;
const int JOYSTICK_CONNECTED = 1;
const int BUTTONS_CONNECTED = 2;

int inp[4];
int button[6];
int analogPins[8];
int joystickSigX, joystickSigY;

bool isConnected;
bool mouseEnabled;
bool pressed[6];

void setup() {
  
  Serial.begin(9600);

  for (int i = 0; i < 6; i++) {
    if (i < 4) {
      inp[i] = NOT_CONNECTED;
    }
    button[i] = -1;
    pressed[i] = false;
  }

  analogPins[0] = A0;
  analogPins[1] = A1;
  analogPins[2] = A2;
  analogPins[3] = A3;
  analogPins[4] = A4;
  analogPins[5] = A5;
  analogPins[6] = A6;
  analogPins[7] = A7;

  joystickSigX, joystickSigY = -1;
  isConnected, mouseEnabled = false;
}

void loop() {
  detectModules();
  if (!isConnected) {
    isConnected = handshake();
    if (!isConnected) {
      if (!mouseEnabled) {
        Mouse.begin();
      }
      controlMouse();
    }
  } else {
    if (mouseEnabled) {
      Mouse.end();
    }
    processCommands();
  }
}

void processCommands() {
  for (int i = 0; i < 6; i++) {
    if (button[i] != -1) {
      if (digitalRead(button[i]) == 1) {
        if (!pressed[i]) {
          pressed[i] = true;
          Serial.println(i);
        }
      } else {
        pressed[i] = false;
      }
    // Stop loop early if not all buttons are assigned
    } else {
      break;
    }
  }

  if (joystickSigX != -1 && joystickSigY != -1) {
    Serial.print("X");
    Serial.print(analogRead(joystickSigX));
    Serial.print("Y");
    Serial.print(analogRead(joystickSigY));
  }
}

void detectModules() {

  int buttonCount = 0;
  for (int i = 0; i < 7; i += 2) {
    int pin1 = analogRead(analogPins[i]);
    int pin2 = analogRead(analogPins[i + 1]);

    if (i < 6) {
      button[i] = -1;
      button[i + 1] = -1;
    }
    // nothing connected
    if (pin1 == 0 && pin2 == 0) {
      if (inp[i / 2] == JOYSTICK_CONNECTED) {
        joystickSigX, joystickSigY = -1;
      }
      inp[i / 2] = NOT_CONNECTED;
    // buttons connected
    // TODO: FIX CONDITION
    } else if (pin1 > 970) {
      // failsafe, just incase another sensor reports values in this range
      if (buttonCount < 6) {
        button[buttonCount] = analogPins[i];
        button[buttonCount + 1] = analogPins[i + 1];
        buttonCount += 2;
      }
    // joystick connected
    } else {
      inp[i / 2] = JOYSTICK_CONNECTED;
      joystickSigX = analogPins[i];
      joystickSigY = analogPins[i + 1];
    }
  } 
}

void controlMouse() {

  int buttonCount = 0;
  for (int i = 0; i < 7; i += 2) {
    if (inp[i / 2] == JOYSTICK_CONNECTED && joystickSigX != -1 && joystickSigY != -1) {
      Mouse.move(analogRead(joystickSigX), analogRead(joystickSigY));
    } else if (inp[i / 2] == BUTTONS_CONNECTED) {
      if (buttonCount < 6)
      {
        if (digitalRead(analogPins[i]) == 1) {
          if (!pressed[buttonCount]) {
            Mouse.click();
            pressed[buttonCount] = true;
          }
        } else {
          pressed[buttonCount] = false;
        }
        if (digitalRead(analogPins[i+1]) == 1) {
          if (!pressed[buttonCount + 1]) {
            Mouse.click(MOUSE_RIGHT);
            pressed[buttonCount + 1] = true;
          }
        } else {
          pressed[buttonCount + 1] = false;
        }
        buttonCount += 2;
      }
    }
  }
}

bool handshake() {
  Serial.println("start");
  bool handshakeCompleted = false;
  if (Serial.available() > 0) {
    if (Serial.readString() == "start") {
      handshakeCompleted = true;
    }
  }
  return handshakeCompleted;
}
