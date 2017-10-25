/*
  3D Inverted Pendulum 

 Created 26 April 2017
 by Jonathan Liaw

 */
#include "Config.h"
#include "MiscFunct.h"

#ifdef  DEBUG_PARSER

#ifdef DEBUG_REMOTE
#define SerialDebug(msg)  msgSend(msg)
#else
#define SerialDebug(msg)  Serial.println(msg)
#endif

#else
#define SerialDebug(msg)
#endif


void parseMsg(String msg)
{
  int errCode = parseCheckCmdSyntax(msg);
  if (errCode != COMMAND_OK)
    freeTaskQueue();
    
  SerialDebug("parseMsg errCode = " + String(errCode,DEC));
}


// cmd assumed contains no white space
int parseCmd(String cmdStr)
{
  // cmdList assumed to have fixed size string elements
  //int cmdListSize = sizeof(cmdList)/sizeof(cmdList[0]);
  int errCode = COMMAND_OK, i = 0;
  String cmd = cmdStr.substring(0,2);
  int cmdParam = -1;   // -1 indicates no param for the command

  SerialDebug("cmd = " + cmd);
 
  
  while (i < cmdListSize && (cmd.compareTo(cmdList[i]) != 0))
    i++;
  
  if (i < cmdListSize)
  {   
      SerialDebug("cmd found = " + String(i,DEC));
      if (cmdStr.length() > 2)    // any parameter?
      {
        SerialDebug("seperator = " + String(cmdStr[2]));
        if (cmdStr[2] == ':')
        { 
          SerialDebug("param string = " + cmdStr.substring(3));
          if (isNumeric(cmdStr.substring(3)))
          {
              cmdParam = (cmdStr.substring(3)).toInt();
              //Serial.println("param found = " + String(cmdParam,DEC));
          }
          else
            errCode = COMMAND_ERR_NOT_NUMBER;
        }
        else
          errCode = COMMAND_ERR_PARAM_SEP;
      }
  }
  else
    errCode = COMMAND_ERR_INVALID;

  if (errCode == COMMAND_OK)
  {
    // cmdTask structure & cmdTaskQueue decleared in MiscFunct.h
    
    cmdTask *aTask = new cmdTask;   // allocate memory, need to destroy at the end
    aTask->cmdID = i;
    aTask->cmdParam = cmdParam;
    
    // insert into task queue
    cmdTaskQueue.push( aTask );
  }
  return errCode;
}


int parseCheckCmdSyntax(String cmds)
{
  int errCode = COMMAND_OK;
  unsigned int cmdSize = cmds.length();
  String cmd;
  int nextIndex = 0, lastIndex = 0;

  SerialDebug("Size of cmdList = " + String(cmdListSize,DEC));
  SerialDebug("Command messge = {"+cmds+"}");
  cmds.trim();
  SerialDebug("Command messge after trimmed = {"+cmds+"}");
  if (cmds.length() > 0)  // ignore empty command message
  {
    if (cmds.endsWith(COMMAND_SEP))
    {
      nextIndex = cmds.indexOf(COMMAND_SEP,lastIndex);
      while ((nextIndex != -1) && (errCode == COMMAND_OK))
      {        
        cmd = cmds.substring(lastIndex,nextIndex);
        SerialDebug("<"+cmd+">");
        cmd.trim();
        SerialDebug("["+cmd+"]");
        if (cmd.length() > 0) // ignore empty command
        {
          // not a pretty code below, the best I can do for the moment
          if (cmd.compareTo(COMMAND_EMER_STOP) != 0)
            errCode = parseCmd(cmd);
          else
          {
            servoEmergencyStop();   // have to execute immediately
            errCode = COMMAND_ERR_EMER_STOP;    // break out of loop
          }
        }
        lastIndex = nextIndex + 1;
        nextIndex = cmds.indexOf(COMMAND_SEP,lastIndex);
      }
    }
    else
      errCode = COMMAND_ERR_TERMINATION;
  }
  return errCode;
}

