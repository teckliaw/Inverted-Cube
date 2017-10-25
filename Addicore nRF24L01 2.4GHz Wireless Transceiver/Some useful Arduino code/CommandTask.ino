/*
  Command definition and task module 

 Created 26 April 2017
 by Jonathan Liaw

*/
#include <QueueList.h>
#include "Config.h"
#include "CommandTask.h"


#ifdef DEBUG_COMMANDTASK

#ifdef DEBUG_REMOTE
#define SerialDebug(msg)  msgSend(msg)
#else
#define SerialDebug(msg)  Serial.println(msg)
#endif

#else
#define SerialDebug(msg)
#endif

String cmdList[] = {  COMMAND_TIME_DELAY, COMMAND_CW, COMMAND_CCW, 
                      COMMAND_STOP, COMMAND_EDGE_BLN, COMMAND_TIP_BLN, 
                      COMMAND_TIP_SPIN, COMMAND_ZERO_POINT, COMMAND_EMER_STOP };
                      
// cmdList assumed to have fixed size string elements (2 chars command)
int cmdListSize = sizeof(cmdList)/sizeof(cmdList[0]);

QueueList <cmdTask*> cmdTaskQueue;  // Arduino library


void freeTaskQueue()
{
  while (! cmdTaskQueue.isEmpty())
  {
    SerialDebug("delete task");
    delete (cmdTask*)(cmdTaskQueue.pop());
  }
}

unsigned long timerDelay = 0;
unsigned long timerStart = 0;
bool inTimerDelay = false;

bool isInTimerDelay()
{
  if (inTimerDelay)
  {
    if ((millis() - timerStart) <= timerDelay)
      return true;

     inTimerDelay = false;
     timerDelay = 0;
     timerStart = 0;
  }
  return false;
}


void setTimerDelay(unsigned long delayTime)
{
  inTimerDelay = true;
  timerDelay = delayTime;
  timerStart = millis();
  //SerialDebug("setTimerDelay,     timeDealy = " + String(timerDelay,DEC) +  "     timerStart = " + String(timerStart,DEC)); 
}


bool cmdTaskInit()
{
  return servoInit(9, 1500);
}

void cmdNextTask()
{
  if (isInTimerDelay())
    return;
    
  if (cmdTaskQueue.isEmpty())
    return;

  cmdTask *aTask = (cmdTask *)(cmdTaskQueue.pop());
  execTask(aTask);
  
  // once completed the task, free the memory
  delete aTask;
}


void execTask(void *ptrTask)
{
  cmdTask *aTask = (cmdTask *) ptrTask;
  
  switch (aTask->cmdID)
  {
    // COMMAND_TIME_DELAY
    case 0: setTimerDelay(aTask->cmdParam);
            SerialDebug("Execute delay for " + String(aTask->cmdParam,DEC));
            break;
            
    // COMMAND_CW
    case 1: servoSpinClockwise(aTask->cmdParam);
            SerialDebug("Execute cloclwise spin with speed " + String(aTask->cmdParam,DEC));
            break;
            
    // COMMAND_CCW
    case 2: servoSpinCounterClockwise(aTask->cmdParam);
            SerialDebug("Execute counter cloclwise spin with speed " + String(aTask->cmdParam,DEC));    
            break;
            
    // COMMAND_STOP
    case 3: servoStop();
            SerialDebug("Execute stop spining");    
            break;
            
    // COMMAND_EDGE_BLN
    case 4: SerialDebug("Execute Edge Balancing");
            break;
            
    // COMMAND_TIP_BLN
    case 5: SerialDebug("Execute Tip Balancing");
            break;
                                                           
    // COMMAND_TIP_SPIN
    case 6: SerialDebug("Execute Tip Spining");
            break;
            
    // COMMAND_ZERO_POINT
    case 7: SerialDebug("Execute Zero Speed Point Setting " + String(aTask->cmdParam,DEC));
            servoSpinSetZeroPoint(aTask->cmdParam);
            break;
                        
    // COMMAND_EMER_STOP
    case 8: servoEmergencyStop();
            SerialDebug("Execute emergency stop spining");    
            break;
            
    // Command Error
    default: SerialDebug("Command Error");
            break;            
  }
  return;
}
