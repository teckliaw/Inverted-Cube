#ifndef CONFIG_H
#define CONFIG_H

// uncomment the lines if debugging needed for the modules
//#define DEBUG_INV3D
//#define DEBUG_MSGCOMM
//#define DEBUG_PARSER
//#define DEBUG_MISCFUNCT
#define DEBUG_COMMANDTASK
#define DEBUG_SERVODRIVER

// if using a remote application for debuging, STX, ETX and checksum need to
// incoporated into the sending messsages.
#define DEBUG_REMOTE

#endif
