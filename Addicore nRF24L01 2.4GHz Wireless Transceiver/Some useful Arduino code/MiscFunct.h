/*
  Miscellaneous Functions used by other project modules
  
  Created 28 March 2017
  by Jonathan Liaw

 */
#ifndef MISC_FUNCT
#define MISC_FUNCT

String IntToHex(int Value, int nHexChar);
int CalChksum(String dataToCalculate, int nByte);
String CalChksumHexStr(String dataToCalculate, int nByte);
int chkCmdSyntax(String cmd);
bool isNumeric(String str);

#endif
