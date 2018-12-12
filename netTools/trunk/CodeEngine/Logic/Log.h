
#ifndef __LOG__H_
#define __LOG__H_

#define  MAX_LOG 1024

#include "BaseDef.h"
#include "fileLog.h"


#pragma  warning (disable:4244)
#pragma  warning(disable:4996)

class TimeManager
{
public:
	static TimeManager *GetMe();
	void RefreshTime();
	INT GetYear(){return m_nYear;}
	INT GetMonth(){return m_nmonth;}
	INT GetDay(){return m_nDay;}
	CHAR* GetTime(){return m_timebuf;}
	VOID GetLogHead(CHAR* pHead,INT nSize);
	VOID  GetDateTime(STRING& sTime);
private:
	TimeManager(){RefreshTime();}
	INT m_nYear;
	INT m_nmonth;
	INT m_nDay;
	CHAR m_timebuf[64];
	static TimeManager*  m_pl;
};
class Log_TYPE_T
{
public:
	enum ID
	{
		ERROR_LOG=0,
		DEGUG_LOG,
		WARIN_LOG,
		DETAIL_LOG,
		ASSERT_LOG,
		MAX_NUM,
	};
};

extern VOID DiskLog(Log_TYPE_T::ID type,CHAR const* msg, ...);
extern VOID PrinScan(CHAR const* msg, ...);

//下面日志主要用来缓冲用，上面提供系统直接调用，如不用C
namespace Model_Log
{

class CrashLog
{
public:
	enum LOGTYPE
	{
		INDIVAILD =0,
		PLAYER,
		SCENEMANAGER,
		LOG_ERROR,
		LOG_DEBUG,
		COUNT,
	};
};
static time_t StartServerTime()
{
	static time_t nStartTime =0;

	if (nStartTime == 0)
	{
		time(&nStartTime);
	}
	return nStartTime;
}
static VOID  CashLog(const char* pLogMsg,CrashLog::LOGTYPE eType =CrashLog::INDIVAILD )
{
	__ENTERFUNCTION
		if (NULL ==pLogMsg)
		{
			return;
		}
		CHAR szMsg[MAX_LOG]={0};
		CHAR databuf[128]={0}, timebuf[128]={0};
		_tzset();
		_strtime_s( reinterpret_cast<char*>(timebuf), 128 );			
		_strdate_s( reinterpret_cast<char*>(databuf), 128 );		
		INT nYear,nMonth,nDay;
		sscanf(databuf,"%d/%d/%d",&nMonth,&nDay,&nYear);
		tsnprintf( reinterpret_cast<char*>(szMsg),MAX_LOG,"%s(T0=%d_%d_%d_%s,T1=%ld)", 
			pLogMsg,nYear,nMonth,nDay,timebuf,clock());
		printf("%s\n",szMsg);
		if (eType == CrashLog::LOG_ERROR)
		{
			CHAR name[25] ={0};
			tsnprintf(name,24,"error_%d_%d_%d_%d.log",nYear,nMonth,nDay,clock());
			static CFileLog fileLog(name);
			fileLog.WriteData(szMsg);
		}
		else if (eType == CrashLog::LOG_DEBUG)
		{
			CHAR name[25] ={0};
			tsnprintf(name,24,"debug_%d_%d_%d_%d.log",nYear,nMonth,nDay,clock());
			static CFileLog fileLog(name);
			fileLog.WriteData(szMsg);
		}
		__LEAVEFUNCTION
}
template<class T>
static VOID  CashLog(const char* pLogMsg,T param,CrashLog::LOGTYPE eType =CrashLog::INDIVAILD )
{
	__ENTERFUNCTION
		if (NULL ==pLogMsg)
		{
			return;
		}			
		CHAR Msg[MAX_LOG]={0};
		tsnprintf(Msg,MAX_LOG,pLogMsg,param);
		CashLog(Msg,eType);
		__LEAVEFUNCTION
}
template<class T1,class T2>
static VOID  CashLog(const char* pLogMsg,T1 param1,T2 param2,CrashLog::LOGTYPE eType =CrashLog::INDIVAILD )
{
	__ENTERFUNCTION
		if (NULL ==pLogMsg)
		{
			return;
		}			
		CHAR Msg[MAX_LOG]={0};
		tsnprintf(Msg,MAX_LOG,pLogMsg,param1,param2);
		CashLog(Msg,eType);
		__LEAVEFUNCTION
}
template<class T1,class T2,class T3>
static VOID  CashLog(const char* pLogMsg,T1 param1,T2 param2,T3 param3,CrashLog::LOGTYPE eType =CrashLog::INDIVAILD )
{
	__ENTERFUNCTION
		if (NULL ==pLogMsg)
		{
			return;
		}			
		CHAR Msg[MAX_LOG]={0};
		tsnprintf(Msg,MAX_LOG,pLogMsg,param1,param2,param3);
		CashLog(Msg,eType);
		__LEAVEFUNCTION
}
template<class T1,class T2,class T3,class T4,class T5,class T6>
static VOID  CashLog(const char* pLogMsg,T1 param1,T2 param2,T3 param3,T4 param4,T5 param5,T6 param6,CrashLog::LOGTYPE eType =CrashLog::INDIVAILD )
{
	__ENTERFUNCTION
		if (NULL ==pLogMsg)
		{
			return;
		}			
		CHAR Msg[MAX_LOG]={0};
		tsnprintf(Msg,MAX_LOG,pLogMsg,param1,param2,param3,param4,param5,param6);
		CashLog(Msg,eType);
		__LEAVEFUNCTION
}
template<class T1,class T2,class T3,class T4,class T5>
static VOID  CashLog(const char* pLogMsg,T1 param1,T2 param2,T3 param3,T4 param4,T5 param5,CrashLog::LOGTYPE eType =CrashLog::INDIVAILD )
{
	__ENTERFUNCTION
		if (NULL ==pLogMsg)
		{
			return;
		}			
		CHAR Msg[MAX_LOG]={0};
		tsnprintf(Msg,MAX_LOG,pLogMsg,param1,param2,param3,param4,param5);
		CashLog(Msg,eType);
		__LEAVEFUNCTION
}
template<class T1,class T2,class T3,class T4>
static VOID  CashLog(const char* pLogMsg,T1 param1,T2 param2,T3 param3,T4 param4,CrashLog::LOGTYPE eType =CrashLog::INDIVAILD )
{
	__ENTERFUNCTION
		if (NULL ==pLogMsg)
		{
			return;
		}			
		CHAR Msg[MAX_LOG]={0};
		tsnprintf(Msg,MAX_LOG,pLogMsg,param1,param2,param3,param4);
		CashLog(Msg,eType);
		__LEAVEFUNCTION
}

static VOID	AssertExMsg(const CHAR* pLog,BOOL bAssert)
{
	if (bAssert == FALSE)
	{
		CashLog(pLog,CrashLog::LOG_ERROR);
		assert(bAssert);
	}

}
template <class T1>
static VOID	AssertExMsg(const CHAR* pLog,T1 param1,BOOL bAssert)
{
	if (bAssert == FALSE)
	{
		CashLog(pLog,param1,CrashLog::LOG_ERROR);
		assert(bAssert);
	}

}
template <class T1,class T2>
static VOID	AssertExMsg(const CHAR* pLog,T1 param1,T2 param2,BOOL bAssert)
{
	if (bAssert == FALSE)
	{
		CashLog(pLog,param1,param2,CrashLog::LOG_ERROR);
		assert(bAssert);
	}

}
template <class T1,class T2,class	T3>
static VOID	AssertExMsg(const CHAR* pLog,T1 param1,T2 param2,T3	param3,BOOL bAssert)
{
	if (bAssert == FALSE)
	{
		CashLog(pLog,param1,param2,param3,CrashLog::LOG_ERROR);
		assert(bAssert);
	}

}
static VOID	 DebugLog(const TCHAR* pLogMsg,CrashLog::LOGTYPE eType =CrashLog::INDIVAILD );
}
#endif