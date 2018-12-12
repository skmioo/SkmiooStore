#ifndef _LOGIMP_H
#define _LOGIMP_H


#include "BaseDef.h"


namespace Model_Log{

class CImplementLog
{
public:
	virtual ~CImplementLog(){}
	virtual int WriteData(const char* szMsg) = 0;	
	virtual void DeleteOneLine() = 0;
};

class CSynLog
{
public:
	enum LogLevel
	{
		L_DEBUG,
		L_WARNING,
		L_SEVERE,
		L_EMERGENCY
	};
/*
	CSynLog(auto_ptr<CImplementLog>& pLog,LogLevel = DEBUG,int nMaxLine = 10000):m_pLog(pLog),m_nMaxLine(nMaxLine),m_nCount(0)
	{
		Init();
	}
*/
	CSynLog(CImplementLog* pLog,LogLevel = L_DEBUG,int nMaxLine = 10000):m_pLog(pLog),m_nMaxLine(nMaxLine),m_nCount(0)
	{
		Init();
	}

	void operator()( const char *fmt, ... );

	inline void SetMaxLineNum( long nNewMaxLine = 10000)
	{
		m_nMaxLine = nNewMaxLine;
	}

	inline void SetLevel(LogLevel nNewLevel)
	{
		AutoLock_T lock(m_CriSec);
		m_nLevel = nNewLevel;
	}

	inline int GetLevel()
	{
		AutoLock_T lock(m_CriSec);
		return m_nLevel;
	}

	~CSynLog();
private:
	CSynLog();
	CSynLog(const CSynLog& log);

	void Init();

	int					m_nMaxLine;
	int					m_nCount;

	MyLock	m_CriSec;	
	LogLevel			m_nLevel;
	CImplementLog*		m_pLog;

};

}
#endif