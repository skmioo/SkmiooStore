
#include "stdafx.h"
#include "logImp.h"

namespace Model_Log
{

using namespace std;

const char* g_unique = "LogMutex";
const char* g_lpszLevel[] = {
   "Debug",
   "Warning",
   "Severe",
   "Emergent",
   ""
};

void CSynLog::Init()
{

}

void CSynLog::operator()( const char *fmt, ... )
{	
	AutoLock_T lock(m_CriSec);

	if(m_nMaxLine <= m_nCount)
	{
		m_pLog->DeleteOneLine();
	}

	// Format string
	char buffer[1024*50];
	va_list arglist;
	va_start( arglist, fmt );
	wvsprintf( buffer, fmt, arglist );
	va_end(arglist);


	char  buf[256];

	SYSTEMTIME time;

	GetLocalTime(&time);

	
	wsprintf( buf, "%02d_%02d_%02d_%02d:%02d:%02d  Level:%s  ", 
					time.wMonth, time.wDay,    time.wYear,
					time.wHour,  time.wMinute, time.wSecond,g_lpszLevel[m_nLevel]);
	string str(buf);
	str += (string)buffer;
	
	m_pLog->WriteData(str.c_str());
	m_nCount++;
}

CSynLog::~CSynLog()
{

}

}

