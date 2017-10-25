#include <Servo.h>
#include "Config.h"

Servo servoDriver;

int servoPinPWM;
int servoZeroPoint = 1500;   

#ifdef  DEBUG_SERVODRIVER

#ifdef DEBUG_REMOTE
#define SerialDebug(msg)  msgSend(msg)
#else
#define SerialDebug(msg)  Serial.println(msg)
#endif

#else
#define SerialDebug(msg)
#endif

bool servoInit(int pinPWM, int zeroPoint)
{
  SerialDebug("In servoInit, pinPWM = " + String(pinPWM,DEC));
  servoPinPWM = pinPWM;
  servoZeroPoint = zeroPoint;
  servoDriver.attach(servoPinPWM);
  return true;
}


void servoSpin(int spinSpeed)
{
  SerialDebug("Spin Speed = " + String(spinSpeed,DEC));
  servoDriver.writeMicroseconds(spinSpeed);
}


void servoStop()
{
  servoSpin(servoZeroPoint);
}


void servoEmergencyStop()
{
  freeTaskQueue();    // flush task queue
  servoStop();
  SerialDebug("Execute emergency stop spining"); 
}


void servoSpinClockwise(int spinSpeed)
{
  servoSpin(servoZeroPoint + spinSpeed);
}


void servoSpinCounterClockwise(int spinSpeed)
{
  servoSpin(servoZeroPoint - spinSpeed);
}


void servoSpinSetZeroPoint(int zeroSpeedPoint)
{
  servoZeroPoint = zeroSpeedPoint;
}

