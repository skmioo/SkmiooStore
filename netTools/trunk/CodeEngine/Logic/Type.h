#ifndef __TYPE__
#define __TYPE__
/************************************************************************/
/*    公共语言支持头文件
/************************************************************************/

#include <direct.h>
#include <stdlib.h>
#include <iostream>
#include <conio.h>
#include <stdlib.h>
#include <malloc.h>
#include <memory.h>
#include <string>
#include <stdarg.h>
#include <stdio.h>
#include <math.h>
#include <io.h>
#include <fcntl.h>
#include <time.h>
#include <limits.h>
#include <vector>

#include <winsock2.h>  
#include <windows.h>
#include <mmsystem.h>
#ifdef _DEBUG
#include <assert.h>
#else
#define  assert NULL
#endif // _DEBUG
//-----------------WIN32----------------
#pragma  
#include <map>
#define HashMap std::map 
#define FALSE 0
#define TRUE 1
#define  VOID void
#define FLOAT float
#define INT int
#define BOOL	int
#define tnsprintf  sprintf_s
#define TCHAR	char
#define  PLSTR	char* const
#define  MAXSCENE 1024
#define HEARTBEAT 2
#define HEARTBEATPACKET 20
#define  INVALOBJID -1
#define  INVALID_GUID  -1
#define INVALID_ID (-1)
#define INVALID_VALUE INVALID_ID
#define LONGLONG	unsigned long
#define CALLBACK __stdcall
#define __ENTERFUNCTION try{
#define __LEAVEFUNCTION  }catch(...){\
CHAR msg[64]={0};\
tnsprintf(msg,sizeof(msg),"\nError,%s %d break",__FILE__,__LINE__);\
MessageBox(NULL,msg,"Error",MB_OK);throw;assert(FALSE);}

#define  INDIVALID_OBJID INDIVALD_ID
#define  MAX_SCENENAME 32
typedef char CHAR;
typedef long HAND;
typedef HAND LONG;
typedef time_t Scene_time;
typedef time_t Time_t;
typedef INT SceneID_t;
typedef INT ObjID_t;
typedef std::string CSTRING;
#define SAFE_DELETE(p) delete (p);(p)=NULL
static FLOAT unitRandom()
{
	return (FLOAT)rand()/(FLOAT)0X7FFF;
}
static INT random(INT min,INT max)
{
	INT rands = static_cast<INT>((max - min)*unitRandom()+min);
	if (rands == max)
	{
		return max -1;
	}
	else
		return rands;
}
/*
#ifdef	UNICODE
typedef	std::wstring CString;
#else
typedef std::string	 CString;
#endif
*/
enum CONNECT_STATUS
{
	STATUS_CONNECT,
	STATUS_DISCONNECT,
};

#endif