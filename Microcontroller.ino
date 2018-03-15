#include <Mouse.h>

const int NOT_CONNECTED = 0;
const int JOYSTICK_CONNECTED = 1;
const int BUTTONS_CONNECTED = 2;

int inp[4];
int button[6];
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

  joystickSig1, joystickSig2 = =1;
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
          Serial.println(i);
          pressed[i] = true;
        }
      } else {
        pressed[i] = false;
      }
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
  
}

void controlMouse() {
  if (inp1 == JOYSTICK_CONNECTED) {
    Mouse.move(4, 4);
  } else if (inp1 == BUTTONS_CONNECTED) {
    if (digitalRead(A0) == 1) {
      Mouse.click();
    }
    if (digitalRead(A1) == 1) {
      Mouse.click(MOUSE_RIGHT);
    }
  }
  if (inp2 == JOYSTICK_CONNECTED) {
    Mouse.move(4, 4);
  } else if (inp2 == BUTTONS_CONNECTED) {
    if (digitalRead(A2) == 1) {
      Mouse.click();
    }
    if (digitalRead(A3) == 1) {
      Mouse.click(MOUSE_RIGHT);
    }
  }
  if (inp3 == JOYSTICK_CONNECTED) {
    Mouse.move(4, 4);
  } else if (inp3 == BUTTONS_CONNECTED) {
    if (digitalRead(A4) == 1) {
      Mouse.click();
    }
    if (digitalRead(A5) == 1) {
      Mouse.click(MOUSE_RIGHT);
    }
  }
  if (inp4 == JOYSTICK_CONNECTED) {
    Mouse.move(4, 4);
  } else if (inp4 == BUTTONS_CONNECTED) {
    if (digitalRead(A6) == 1) {
      Mouse.click();
    }
    if (digitalRead(A7) == 1) {
      Mouse.click(MOUSE_RIGHT);
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
