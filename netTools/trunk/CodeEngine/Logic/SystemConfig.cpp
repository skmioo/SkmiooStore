#include "stdafx.h"
#include "SystemConfig.h"
std::list<ScriptActionMatch_T>  g_ScriptMatch;

using namespace std;

BOOL SystemConfig_T::InitSysEnv(STRING& err)
{
	__ENTER_FUNCTION
	typedef std::ifstream	Sysifstream;
	
	Sysifstream file(SYSTEM_SCRIPTPATH,ios::in );	
	if (!file) 
	{
		CHAR msg[128]={0};
		tsnprintf(msg,127,"LoadFile:%s....Faild!",SYSTEM_SCRIPTPATH);
		err = msg;
		return FALSE;
	}
	string line;
	
	while (getline(file,line))
	{
		if ( !line.length()) continue;
		if ( line[0] == '#') continue;
		if ( line[0] == ';') continue;
		STRINGTYPE nPos = line.find_last_of("=");
		if (nPos == STRINGEND) continue;
		STRING strList = line.substr(0,nPos);
		INT nScriptID = atoi(line.substr(nPos+1).c_str());
		ScriptActionMatch_T oScriptValue;

		oScriptValue.m_ScriptID = nScriptID;

		STRING tmpString="";
		for (INT i=0;i<strList.length();++i)
		{
			CHAR ch = strList[i];
			if (ch == '%')
			{
				if (tmpString.length()>0)
				{
					oScriptValue.m_KeyList.push_back(tmpString);
					tmpString.clear();
				}
				oScriptValue.m_KeyList.push_back("%");
			}
			else if ( ch == '|')
			{
				if (tmpString.length()>0)
				{
					oScriptValue.m_KeyList.push_back(tmpString);
					tmpString.clear();
				}

				oScriptValue.m_KeyList.push_back("|");
			}
			else 
			{
				tmpString.push_back(ch);
			}
		}
		if (tmpString.length()>0)
		{
			oScriptValue.m_KeyList.push_back(tmpString);
			tmpString.clear();
		}

		g_ScriptMatch.push_back(oScriptValue);
	}
	return TRUE;
	__LEAVE_FUNCTION
	return FALSE;
}

INT SystemConfig_T::GetScriptByMatchURL( STRING const& rURL )
{
	if (rURL.length()<=0)
	{
		return -1;
	}
	STRING::size_type nPos = rURL.find_last_of("\\");
	if (nPos == STRINGEND)
	{
		 nPos = rURL.find_last_of("/");
	}
	STRING strScript = rURL;
	if (nPos != STRINGEND)
	{
		strScript = rURL.substr(nPos+1);
	}
	STRINGTYPE nCurrentPos =0;
	for (std::list<ScriptActionMatch_T>::const_iterator it= g_ScriptMatch.begin();it!=g_ScriptMatch.end();++it)
	{
		ScriptActionMatch_T const& rMatch = *it;
		BOOL bFound = TRUE;
		for (std::list<STRING>::const_iterator subit= rMatch.m_KeyList.begin();subit!=rMatch.m_KeyList.end();++subit)
		{
			STRING const& rValues = *subit;
			//Ò»¸ö×Ö·û
			if (rValues == "|")
			{
				++nCurrentPos;
			}
			else if (rValues == "%")
			{
				continue;
			}
			else
			{
				STRINGTYPE nTmpPos = strScript.find(rValues,nCurrentPos);
				if (nTmpPos == STRINGEND)
				{
					bFound=FALSE;
					break;
				}
				nCurrentPos =nTmpPos + rValues.length();
			}
		}
		if (TRUE == bFound)
		{
			return it->m_ScriptID;
		}
	}
	return -1;
}
