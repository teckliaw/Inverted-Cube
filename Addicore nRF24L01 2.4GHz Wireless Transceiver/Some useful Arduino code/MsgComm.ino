/*
  Serial Communication Module

 Created 30 March 2017
 by Jonathan Liaw

 */
#include "Config.h"

// These 2 lines MUST preceed the following lines to include <SparkFunMPU9250-DMP.h>
#include "MsgComm.h"
//#include "MiscFunct.h"


// if hook up to SparkFunMPU9250, uncomment the following 2 lines
//#include <SparkFunMPU9250-DMP.h>
//#define SerialComm SerialUSB  // override the definition in SerialComm.h


#ifdef  DEBUG_MSGCOMM

#ifdef DEBUG_REMOTE
#define SerialDebug(msg)  msgSend(msg)
#else
#define SerialDebug(msg)  Serial.println(msg)
#endif

#else
#define SerialDebug(msg)
#endif

/* 
 *  This modified routine is used as a companion routine for the serial port
 *  reliability test, the protocol includes two bytes check sum from the 
 *  sender.  An ACK or NAK is sent based on the validity of check sum
 */
String msgBuff;               // buffer to hold incoming msg data
bool msgComplete;             // message is completed reception if receive the ETX

bool isAliveMsg = false;
unsigned long alivePeriod = 0;
unsigned long aliveTimer = 0; // I am alive signal timer

bool msgInit(bool aliveMsgFlag, unsigned long aliveInterval)
{ 
  // reserve 400 bytes for the receiveBuff:
  msgBuff.reserve(400);
  
  msgBuff = "";
  msgComplete = false;

  if (isAliveMsg = aliveMsgFlag)
    aliveTimer = millis();
    
  alivePeriod = aliveInterval;
  SerialComm.begin(115200);
  
  return true;
}

void msgSend(String msg)
{
  String ChksumStr = CalChksumHexStr(msg, 1);
  SerialComm.print(STX + msg + ChksumStr + ETX);
  aliveTimer = millis();  // reset timer
}

void msgSendACK()
{
  msgSend(String(ACK));
}


void msgSendNAK()
{
  msgSend(String(NAK));
}

// must decoupled from msgSend()
void msgSendAliveSignal()
{ 
  if (isAliveMsg)
  {
    if ((millis() - aliveTimer) <= alivePeriod)
      return;

    String aliveMsg = "\nI am alive:" + String(millis());
    //SerialComm.print(aliveMsg);   // for testing
    msgSend(aliveMsg);
    aliveTimer = millis();
  }
}


void msgCheckMsg()
{
  msgReceiveMsg();
  if (msgComplete)
  {  
    int msgLen;
    String chksumStr, msgBody, msgChecksum;

    SerialDebug("msgCheckMsg  msgBuff = " + msgBuff);
    // msgBuff contains <original string><2 bytes checksum>
    msgLen = msgBuff.length(); 
    msgBody = msgBuff.substring(0,msgLen-2);
    msgChecksum = msgBuff.substring(msgLen-2);

    SerialDebug("msgCheckMsg  msgLen = " + String(msgLen,DEC));
    SerialDebug("msgCheckMsg  msgBody = " + msgBody);
    
    // calculate the check sum from the <message body>
    chksumStr = CalChksumHexStr(msgBody, 1);
    SerialDebug("chksumstr = " + chksumStr + "     msgChecksum = " + msgChecksum);
    if (chksumStr == msgChecksum)
    {
      //SerialComm.println("Sending ACK");
      msgSendACK();
      parseMsg(msgBody);
    }
    else
      msgSendNAK();

    msgComplete = false;
  }
  msgSendAliveSignal();
}


// protocol:  <STX><Message Body><Two Bytes Check Sum><ETX>
void msgReceiveMsg()
{
  static bool isArduinoMonitorInput = false;
  
  while (SerialComm.available()) 
  {
    // get the new byte:
    char inChar = (char)SerialComm.read();
    //SerialComm.println("Serial comm read = " + String(inChar));

    // MUST implement timeout waiting for end of text signal
    // Discard the message if timeout
    
    switch (inChar)
    {
      case STX: msgBuff = "";
                break;

      case ETX: msgComplete = true;
                break;

      // similar to STX but indicates it is from the Arduino serial monitor
      // MUST SET the monitor to "No line ending"!  (below the monotor screen)
      case '{': isArduinoMonitorInput = true;
                msgBuff = "";
                break;

      // similar to ETX but indicates it is from the Arduino serial monitor
      // MUST SET the monitor to "No line ending"! (below the monotor screen)
      case '}': if (isArduinoMonitorInput)
                {
                  msgBuff = msgBuff + CalChksumHexStr(msgBuff, 1);   // mimic received from remote
                  msgComplete = true;
                  //SerialComm.println("massage completed");
                }
                isArduinoMonitorInput = false; // always reset this flag
                break;     
      
      // add it to the receiveBuff, receiveBuff should not contains STX or ETX
      default:  msgBuff += inChar;
                break;      
    }
    
//    // if the incoming character is a STX, reset ReceiveBuff
//    if (inChar == STX)  // Start of text
//      msgBuff = "";
//      
//    // if the incoming character is a ETX, set a flag
//    // so the commProcessReceive() can do something about it:
//    else if (inChar == ETX)  // End of text
//      msgComplete = true;
//      
//    else
//      // add it to the receiveBuff, receiveBuff should not
//      // contains STX or ETX
//      msgBuff += inChar;
  }  
}

