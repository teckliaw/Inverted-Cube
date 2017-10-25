/*
  SerialComm header file
  
  Created 29 March 2017
  by Jonathan Liaw

 */
#ifndef MSG_COMM
#define MSG_COMM
 
#define SerialComm  Serial

#define ACK char(6)     // Acknowledge
#define NAK char(21)    // Negative acknowledge

#define STX char(2)     // Start of text  
#define ETX char(3)     // End of text

#define ESC char(27)    // Single ESC indicates "I am alive" flag


void msgSendACK();
void msgSendNAK();
void msgReceiveMsg();
void msgCheckMsg();

#endif
