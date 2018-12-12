#include "IPacketFactory.h"
#include "Log.h"
#include "StringFun.h"
#include "tinyxml.h"
#include "WinFun.h"
#include "PacketCplus.h"
#include "PacketCSharp.h"
#include "PacketJava.h"

CPacketFactory* CPacketFactory::CreateInstance( string const& sType )
{
	if (sType == PACKET_Type::C_CSHARP)
	{
		return new CPacketCSharp();
	}
	else if (sType == PACKET_Type::C_JAVA)
	{
		return new CPacketJava();
	}
	else if (sType == PACKET_Type::C_CPLUSE)
	{
		return new CPacketCplus();
	}

	return NULL;
}

BOOL CPacketFactory::ReadTemplateXML( XMLReader_T& datas,const STRING& fileName )
{
	if (fileName.empty())
	{
		return FALSE;
	}
	TiXmlDocument doc;  
	if (doc.LoadFile(fileName.c_str()))
	{  	
		//doc.Print();  
	} else {
		Model_Log::CashLog<const char*>("Can not Open %s",fileName.c_str(),Model_Log::CrashLog::LOG_ERROR);
		return FALSE;
	}

	TiXmlElement* rootElement = doc.RootElement();  //pbbufferÔªËØ 
	if (rootElement==NULL)
	{
		Model_Log::CashLog<const char*>("Read XML %s Error!! not Root Element",fileName.c_str(),Model_Log::CrashLog::LOG_ERROR);
		return FALSE;
	}

	for (TiXmlElement* pSubElement = rootElement->FirstChildElement(); 
		pSubElement != NULL; pSubElement = pSubElement->NextSiblingElement() )
	{
		const char* pKey =  pSubElement->Value();
		const char* PContent = pSubElement->GetText();
		if(pKey ==NULL || PContent == NULL)continue;

		XMLElement oContent;
		oContent.m_Key = pKey;
		oContent.m_Content = PContent;
		datas[StringLink(rootElement->Value(),pKey,"_")] = oContent;
	}
	return TRUE;
}

void CPacketFactory::Write( STRING const& ptext )
{
	STRING lastMsg = ptext;
	Replace(lastMsg,"${N}","\n");
	Replace(lastMsg,"${L}","<");
	Replace(lastMsg,"${R}",">");
	ofstream* pFile = GetWriteHandle();
	if(!lastMsg.empty() && pFile != NULL)
	{
		*pFile  << lastMsg;
	}
}

STRING CPacketFactory::FindXMLElement( STRING const& key ) const
{
	if (IsEmptOrSpace(key))
	{
		return "";
	}
	XMLReader_T::const_iterator itincludes = GetOptCurXML().find(key);
	if (itincludes != GetOptCurXML().end())
	{
		return itincludes->second.m_Content;
	}
	return "";
}

bool CPacketFactory::EnvFileStream( const STRING& rFileName ,const STRING& rDir)
{
	if(rFileName.empty())return false;
	ofstream* _File= GetWriteHandle();
	if(_File ==NULL)
	{
		_File = new ofstream();
		if(_File == NULL)
		{
			Model_Log::CashLog<const char*,int>("m_File == NULL%s(%d)",__FILE__,__LINE__,Model_Log::CrashLog::LOG_ERROR);
			return false;
		}
		SetWriteHandle(_File);
	}
	else
	{
		_File->close();
	}
	WriteDirectory(rDir);
	STRING absfile = rDir + rFileName;
		_File->open(absfile.c_str(),ios_base::binary);
		if (!_File->is_open())
		{
			Model_Log::CashLog<const char*,int,const char*>("Out file can not write please check disk: %s(%d) %s",__FILE__,__LINE__,absfile.c_str(),Model_Log::CrashLog::LOG_ERROR);
			Realse();
			return false;
		}	
	
	return true;
}


bool CPacketFactory::InsertImport(const STRING&headVal, ImportList_T& listClass,const STRING& Key,const STRING& values)
{
	if(headVal.find(Key) != STRINGEND)
	{
		ImportList_T::iterator itfound = listClass.find(Key);
		if(itfound==listClass.end())
		{
			vector<STRING> vals;
			vals.push_back(values);
			listClass[Key] = vals;
		}
		else 
		{
			itfound->second.push_back(values);
		}
		return true;
	}
	return false;
}

STRING CPacketFactory::GetImport( const STRING&headVal, ImportList_T& listClass,const STRING& xmltempleate )
{
	STRING importInsert;
	ImportList_T::const_iterator it = listClass.find(headVal);
	if(it == listClass.end())return "";

	for(vector<STRING>::const_iterator sub = it->second.begin();sub != it->second.end();++sub)
	{
		STRING viewtemplate = xmltempleate;
		Replace(viewtemplate,"${instance}",sub->c_str());
		importInsert +=viewtemplate;	
	}
	return importInsert;
}

STRING CPacketFactory::GePacket( const STRING&headVal, ImportList_T& listClass,const STRING& rrep )
{
	STRING importInsert;
	ImportList_T::const_iterator it = listClass.find(headVal);
	if(it == listClass.end())return "";

	for(vector<STRING>::const_iterator sub = it->second.begin();sub != it->second.end();++sub)
	{
		STRING packets = rrep;
		Replace(packets,"${packet}",sub->c_str());		
		importInsert += packets;		
	}
	return importInsert;
}
