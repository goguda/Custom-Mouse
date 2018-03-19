#include <Mouse.h>

const int NOT_CONNECTED = 0;
const int JOYSTICK_CONNECTED = 1;
const int BUTTONS_CONNECTED = 2;

struct Input {
  int inputMode = NOT_CONNECTED;
  int xThreshold = -1;
  int yThreshold = -1;
  int inp1Val = -1;
  int inp2Val = -1;
  bool button1Pressed = false;
  bool button2Pressed = false;
};

bool isConnected;

Input inputs[4];

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

void loop() {
  detectModules();
  if (!isConnected) {
    isConnected = handshake();
  } else {
    int buttonCounter = 0;
    for (int i = 0; i < 3; i++) {
      if (inputs[i].inputMode == JOYSTICK_CONNECTED) {
        Serial.print("X");
        Serial.print(inputs[i].inp2Val);
        Serial.print("Y");
        Serial.println(inputs[i].inp1Val);
      } else if (inputs[i].inputMode == BUTTONS_CONNECTED) {
        if (buttonCounter < 6) {
          buttonCounter++;
          if (inputs[i].inp1Val == 0 && !inputs[i].button1Pressed) {
            Serial.println(buttonCounter);
            inputs[i].button1Pressed = true;
          } else if (inputs[i].inp1Val != 0 && inputs[i].button1Pressed) {
            inputs[i].button1Pressed = false;
          }
          buttonCounter++;
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
}

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
    if ((readings[i] > 477 && readings[i] < 489) && (readings[i + 1] > 470 && readings[i + 1] < 482)) {
      inputs[i / 2].inputMode = JOYSTICK_CONNECTED;
      inputs[i / 2].xThreshold = readings[i + 1];
      inputs[i / 2].yThreshold = readings[i];
    } else if ((readings[i] > 975 && readings[i] < 990) && (readings[i + 1] > 975 && readings[i + 1] < 990)) {
      inputs[i / 2].inputMode = BUTTONS_CONNECTED;
    } else {
      if (inputs[i / 2].inputMode == BUTTONS_CONNECTED && (readings[i] < 900 && readings[i] != 0) &&
      (readings[i + 1] < 900 && readings[i + 1] != 0)) {
        inputs[i / 2].inputMode = NOT_CONNECTED;
      } else if (inputs[i / 2].inputMode == JOYSTICK_CONNECTED && (readings[i] > 972 || readings[i + 1] > 972)) {
        inputs[i / 2].inputMode = NOT_CONNECTED;
      }
    }
    if (inputs[i / 2].inputMode == NOT_CONNECTED) {
      inputs[i / 2].inp1Val = -1;
      inputs[i / 2].inp2Val = -1;
    } else {
      inputs[i / 2].inp1Val = readings[i];
      inputs[i / 2].inp2Val = readings[i + 1];
    }
  }
}

bool handshake() {
  bool handshakeCompleted = false;
  if (Serial.available() > 0) {
    String input = Serial.readString();
    if (input == "start") {
      Serial.println("start");
      handshakeCompleted = true;
    }
  }
  return handshakeCompleted;
}
