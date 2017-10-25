/*
  Miscellaneous Functions used by other project modules
  
  Created 28 March 2017
  by Jonathan Liaw

 */
#include <string.h>
#include "Config.h"

#ifdef  DEBUG_MISCFUNCT

#ifdef DEBUG_REMOTE
#define SerialDebug(msg)  msgSend(msg)
#else
#define SerialDebug(msg)  Serial.println(msg)
#endif

#else
#define SerialDebug(msg)
#endif


String IntToHex(int Value, int nHexChar)
{ 
  String FormatStr = "%0"+String(nHexChar)+"X";
  char* Format = &FormatStr[0];
  char HexStr[100];

  sprintf(HexStr,Format,Value);
  return String(HexStr);
}


// check a string to see if it is numeric
bool isNumeric(String str) 
{
  for (byte i = 0; str[i]; i++)
    if ((str[i] < '0') || (str[i] > '9'))
      return false;
      
  return true;
}


int CalChksum(String dataToCalculate, int nByte) 
{
    int n = dataToCalculate.length(), checksum = 0;

    while (n-- > 0)
      checksum += dataToCalculate[n];

    checksum &= ((nByte == 1)? 0xFF : 0xFFFF);  // temporary only 1 or 2 bytes
    return checksum;
}


String CalChksumHexStr(String dataToCalculate, int nByte) 
 {
    int checksum = CalChksum(dataToCalculate, nByte);
    //String chksumStr = String(checksum,HEX);
    //String chksumStr = String((int)checksum / 16, HEX) + String((int)checksum % 16, HEX);
    String chksumStr = IntToHex(checksum,nByte*2);
    
    chksumStr.toUpperCase();    
    return chksumStr;
}


// powerful inline code for speed and thread safe to split string line
// into tokens
//
// inline void str_split(char *str, char delim) { 
//   char *p = str; 
//   while(p[0]) { 
//     if (p[0] == delim) p[0] = 0; 
//     p++; 
//   } 
// }
//
// macro equilvalent to the inline code above 
// #define str_split(str, delim) do { char *p = str; while(p[0]) { if (p[0] == delim) p[0] = delim; p++ }} while(0)
//


