/*
  Command definition and task module 

 Created 26 April 2017
 by Jonathan Liaw

*/
#ifndef COMMAND_TASK
#define COMMAND_TASK

// Command syntax" XX[:<CP>];
// XX = 2 characters command
// [:<CP>]  optional command parameter
// COMMAND_CW, COMMAND_CCW, COMMAND_TIME_DELAY, COMMAND_TIP_ROT, COMMAND_ZERO_POINT
// require command parameter 
// : = command paramter seperator
// <CP> = command parameter, numeric integer
// ; = command seperator

#define COMMAND_SEP         ";"   // Commands seperator
#define COMMAND_PARAM_SEP   ":"   // Coommand parameter seperator

#define COMMAND_TIME_DELAY  "TD"  // Time Delay
#define COMMAND_CW          "CW"  // Clockwise rotate
#define COMMAND_CCW         "CC"  // Counter clockwise rotate
#define COMMAND_STOP        "ST"  // Stop rotating
#define COMMAND_EDGE_BLN    "EB"  // Edge balancing
#define COMMAND_TIP_BLN     "TB"  // Tip balancing
#define COMMAND_TIP_SPIN    "TS"  // Tip spin
#define COMMAND_ZERO_POINT  "ZP"  // Zero Speed Point
#define COMMAND_EMER_STOP   "ES"  // Emergency Stop rotating


typedef struct {
  int cmdID;
  int cmdParam;
} cmdTask;


// Command erroe code
#define COMMAND_OK                0     // Command no error
#define COMMAND_ERR_TERMINATION   100   // Message contains no command
#define COMMAND_ERR_INVALID       101   // Invalid command
#define COMMAND_ERR_PARAM_SEP     102   // Invalid parameter seperator character ":" 
#define COMMAND_ERR_NOT_NUMBER    103   // argument is not numeric
#define COMMAND_ERR_ZERO_POINT    104   // invalid zero speed point value
#define COMMAND_ERR_EMER_STOP     105   // Emergency Stop detected

extern String cmdList[];
//extern QueueList <cmdTask*> cmdTaskQueue;

int cmdExecTask(cmdTask* aTask);
void cmdNextTask();

#endif
