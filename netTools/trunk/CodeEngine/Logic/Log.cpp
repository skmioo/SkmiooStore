#include "Log.h"
#define  LOG_BUFF_TEMP 4096
#define  LOG_NAME_TEMP 128

MyLock g_log_lock;
#include "StringFun.h"


CHAR const* logNameHead[Log_TYPE_T::MAX_NUM]=
{
	"error","debug","warn","detail","assert"
};



VOID DiskLog( Log_TYPE_T::ID type,CHAR const* msg, ... )
{
	if (msg == NULL)
	{
		return;
	}

	CHAR szBuff[LOG_BUFF_TEMP];
	memset(szBuff, 0, LOG_BUFF_TEMP) ;
	CHAR name[25] ={0};

	va_list argptr;

		va_start(argptr, msg);
		tvsnprintf(szBuff,LOG_BUFF_TEMP-LOG_NAME_TEMP-1,msg,argptr);
		va_end(argptr);
	
		
		_MY_TRY
		{			
					
			CHAR databuf[128]={0};
			TimeManager::GetMe()->GetLogHead(databuf,sizeof(databuf));
			strncat( szBuff, databuf, LOG_NAME_TEMP-1 ) ;		
			
		   tsnprintf(name,24,"./Log/%s_%d_%d_%d.log",logNameHead[type],TimeManager::GetMe()->GetYear(),TimeManager::GetMe()->GetMonth(),TimeManager::GetMe()->GetDay());				
			
		}
		_MY_CATCH
		{
		}


	g_log_lock.Lock() ;
	_MY_TRY
	{
		FILE* f = fopen( name, "a+" ) ;
		if( f )
		{
			_MY_TRY
			{
				fwrite( szBuff, 1, strlen(szBuff), f ) ;
			}
			_MY_CATCH
			{
			}
			fclose(f) ;
		}
	}
	_MY_CATCH
	{
	}
	g_log_lock.Unlock() ;

}

extern VOID PrinScan( CHAR const* msg, ... )
{
	if (msg == NULL)
	{
		return;
	}

	CHAR szBuff[LOG_BUFF_TEMP]={0};
	memset(szBuff, 0, LOG_BUFF_TEMP) ;
	CHAR name[25] ={0};

	va_list argptr;

	va_start(argptr, msg);
	tvsnprintf(szBuff,LOG_BUFF_TEMP-LOG_NAME_TEMP-1,msg,argptr);
	va_end(argptr);

	CHAR databuf[128]={0};
	TimeManager::GetMe()->GetLogHead(databuf,sizeof(databuf));
	strncat( szBuff, databuf, LOG_NAME_TEMP-1 ) ;
	printf("%s",szBuff);		
}



TimeManager* TimeManager::m_pl=NULL;

TimeManager * TimeManager::GetMe()
{
	 if (NULL == m_pl)
	 {
		 m_pl = new TimeManager();
	 }
	 if(m_pl == NULL)
	 {
			exit(-1);
	 }
	 return m_pl;
}

void TimeManager::RefreshTime( )
{
	CHAR databuf[128]={0};
	memset(m_timebuf,0,sizeof(m_timebuf));
	_tzset();
	_strtime_s( reinterpret_cast<char*>(m_timebuf), sizeof(m_timebuf) );			
	_strdate_s( reinterpret_cast<char*>(databuf), 128 );		

	sscanf(databuf,"%d/%d/%d",&m_nmonth,&m_nDay,&m_nYear);	
}

VOID TimeManager::GetLogHead(CHAR* pHead,INT nSize )
{
	if (NULL == pHead)
	{
		return;
	}
	RefreshTime();
	tsnprintf( pHead,nSize,"(T0=%d_%d_%d_%s,T1=%ld)\n", m_nYear,
		m_nmonth,m_nDay,m_timebuf,clock());

}

VOID TimeManager::GetDateTime(STRING& sTime)
{
	CHAR buff[256]={0};
	RefreshTime();
	tsnprintf(buff,sizeof(buff),"%d_%d_%d_%s_%ld",m_nYear,
		m_nmonth,m_nDay,m_timebuf,clock());
	sTime = buff;
	Replace(sTime,":","_");
}
