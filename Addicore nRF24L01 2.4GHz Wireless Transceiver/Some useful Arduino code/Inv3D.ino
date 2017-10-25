/*
  3D Inverted Pendulum 

 Created 26 April 2017
 by Jonathan Liaw

 */
#include "Config.h"

// These 2 lines MUST preceed the following lines to include <SparkFunMPU9250-DMP.h>
#include "MsgComm.h"
#include "MiscFunct.h"
#include "CommandTask.h"

// if hook up to SparkFunMPU9250, uncomment the following 2 lines
//#include <SparkFunMPU9250-DMP.h>
//#define SerialComm SerialUSB  // override the definition in SerialComm.h

#ifdef DEBUG_INV3D

#ifdef  DEBUG_REMOTE
#define SerialDebug(msg)  msgSend(msg)
#else
#define SerialDebug(msg)  Serial.println(msg)
#endif

#else
#define SerialDebug(msg)
#endif


void setup() {

#ifdef DEBUG
  SerialComm.println("application started");
#endif

  // initialize invertor module:
  if (invInit() && cmdTaskInit())
  {  
#ifndef DEBUG_REMOTE
    //int errCode = parseCheckCmdSyntax("   \n\n\t;CW:250;   CC:50;\t\n ST\t\t   ;EB;  TB ;  TS:20 \t\n;TD:1000   ;ST;  ");
    //int errCode = parseCheckCmdSyntax("ST; CW:80; TD:3000; ST;");
    //int errCode = parseCheckCmdSyntax("CC:30;TD:8000;CW:8;TD:3000;CW:5;TD:3000;CW:0;TD:3000;CC:5;TD:3000;CC:30;TD:2000;CC:80;TD:3000;CC:30;");
    int errCode = parseCheckCmdSyntax("CC:30;TD:8000;CW:5;TD:3000;CW:0;TD:3000;CC:5;TD:3000;CC:30;TD:2000;CC:75;TD:3000;CC:65;TD:3000;CC:60;TD:3000;CC:55;TD:3000;CC:50;TD:3000;CC:30;");
    if (errCode != COMMAND_OK)
      freeTaskQueue();
      
    SerialDebug("Error Code = " + String(errCode,DEC));
#endif
  }
}

void loop() {
  //msgSendAliveSignal();

  cmdNextTask();
  msgCheckMsg();  
}


bool invInit()
{
  bool Ok = true;

  // initialize communication port
  if (Ok = msgInit(false, 5000))
  {
    
  }
  return Ok;
}



