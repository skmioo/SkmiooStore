#ifndef _SYSTEM_CONFIG__H__
#define _SYSTEM_CONFIG__H__
#include "BaseDef.h"
#define  FULLSPLIT '%'
#define  SYSTEM_SCRIPTPATH "./config/ScriptLink.txt"
struct  ScriptActionMatch_T
{
	std::list<STRING> m_KeyList;
	INT		m_ScriptID;

	VOID  clear()
	{
		m_ScriptID = -1;
		m_KeyList.clear();
	}

};

extern std::list<ScriptActionMatch_T>  g_ScriptMatch;

class SystemConfig_T
{
public:
	static BOOL		InitSysEnv(STRING& errlog);
	static  INT			GetScriptByMatchURL(STRING const& rURL);
};

 
#endif