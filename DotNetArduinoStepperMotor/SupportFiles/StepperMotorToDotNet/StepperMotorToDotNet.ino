#include <Boards.h>
#include <AccelStepper.h>

byte analogPin;

// Arduino pin connected to DIR+ on the stepper motor driver. 
#define dirPin 2
// Arduino pin connected to PUL+ on the stepper motor driver. 
#define stepPin 3

#define motorInterfaceType 1
AccelStepper stepper = AccelStepper(motorInterfaceType, stepPin, dirPin);

char endMarker = '\n';
char rc;

int currentPos; 

void setup()
{
  Serial.begin(115200);
  // delay was 100, but header was occasionally garbled. Not sure if this fixed anything. ~Ed 
  delay(1400);
  
  Serial.println("Stepper Motor Controller V01 - Send r to rotate to the right, l to rotate to the left");

  stepper.setMaxSpeed(3000);
  stepper.setAcceleration(800);

  currentPos = 0;

  stepper.moveTo(100);
  stepper.runToPosition();
  stepper.moveTo(0);
  stepper.runToPosition();
     
}

void rotateStepper(char direction)
{
  if (direction == 'r')
  {
    currentPos += 100;
    stepper.moveTo(currentPos);     
  } 
  else {
    currentPos -= 100;
    stepper.moveTo(currentPos);
  }

}

void loop()
{

  
  while (Serial.available() > 0) {
    rc = Serial.read();

    // Ignore the newline character when deciding what to output.
    if (rc != endMarker) {

      if (rc == 'r' || rc == 'l') {
        rotateStepper(rc);
      }
      else{
        Serial.print("I received a char that I don't know how to respond to. The char received: ");
        Serial.println(rc);
      }
    }

  }

  Serial.println("Done");
  stepper.runToPosition();

}
