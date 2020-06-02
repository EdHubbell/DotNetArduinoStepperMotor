# DotNetArduinoStepperMotor

Simple example of how to control a stepper motor with an Arduino board. 

I initially tried to implement this using a Firmata implementation, as that 
would have made it easier to deal with the message format to/from the Arduino. Unfortunately, the only C# Firmata implementation that I could find with a Nuget (https://github.com/SolidSoils/Arduino) had some pretty severe problems with connect/disconnect. Maybe there has been a pull since 6/2/2020 that fixes this. If so, you can implement that way.  

For now, it talks serial to the Arduino board, which in turn uses the AccelStepper library to talk to the Microstep driver TB6600 (about $12 on your favorite online ordering platform).

https://www.makerguides.com/tb6600-stepper-motor-driver-arduino-tutorial/

You can play with the increment, accel, etc for your specific application. 