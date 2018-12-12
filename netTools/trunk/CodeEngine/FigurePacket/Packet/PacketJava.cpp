#include "PacketJava.h"
#include "Log.h"
#include "StringFun.h"
#include "tinyxml.h"
#include "PacketCreateDefine.h"

CPacketJava::CPacketJava(void)
{
	m_File = NULL;
}


CPacketJava::~CPacketJava(void)
{
	if(m_File)
	{
		m_File->close();
		SAFE_DELETE(m_File);
	}
}

bool CPacketJava::CreatePacket( CProtoDataMethod const* pdatas ,BOOL bSkiphandler)
{
	if(pdatas==NULL)
	{		
		Model_Log::CashLog<const char*,int>("CProtoDataMethod pdatas==%s(%d)",__FILE__,__LINE__,Model_Log::CrashLog::LOG_ERROR);
		return FALSE;
	}

	Protocol_Struct_T const* pProtocol = pdatas->GetData();
	if(pProtocol == NULL)
	{
		Model_Log::CashLog<const char*,int>("pProtocol == NULL%s(%d)",__FILE__,__LINE__,Model_Log::CrashLog::LOG_ERROR);
		return false;
	}
	//准备数据

	ImportList_T listClass;
	PacketDefine_T listPacketdefine;
	INT nMAXPACKET =0;
	for (Protocol_Struct_T::const_iterator it =pProtocol->begin();it != pProtocol->end();++it)
	{
		const base_protocol_T& rValueProtocol = it->first;
		if(rValueProtocol.keyVariable.empty())continue;

		STRING optionVal = rValueProtocol.keyVariable;
		STRING headVal ,Numbers;
		bool bRet = SpiltStringAndNumber(rValueProtocol.className, headVal ,Numbers);
		if(!bRet)
		{
			Model_Log::CashLog<const char*,int,const char*>("Invalid vairable you must write stringandnumber comb %s(%d) %s",__FILE__,__LINE__,rValueProtocol.className.c_str(),Model_Log::CrashLog::LOG_ERROR);
			continue;
		}



		STRING realclass = rValueProtocol.packetHandler;
		realclass +="::";
		realclass += rValueProtocol.className;
		//组织好数据开始写入文件
		//////////////////////////////////////////////////////////////////////////Handler//////////////////////////////////////////////////////////////////////

		STRING OptionName = __BB(headVal) + __B(optionVal);
		{
			if ( FALSE == ReadTemplateXML(m_xmlTemplate,JAVA_PACKET_HANDLER))
			{
				Model_Log::CashLog<const char*,int,const char*>("CProtoDataMethod pdatas==%s(%d)%s",__FILE__,__LINE__,JAVA_PACKET_HANDLER,Model_Log::CrashLog::LOG_ERROR);
				return false;
			}

			STRING packetDefine = " public static final short  PACKET_";
			packetDefine += __BB(OptionName);
			packetDefine += "\t=\t";
			packetDefine += Numbers;
			packetDefine += ";\t//";
			packetDefine += rValueProtocol.descipt;
			packetDefine += "\n";
			INT nCur = atoi(Numbers.c_str());
			if(nMAXPACKET<nCur)
			{
				nMAXPACKET = nCur;
			}
			listPacketdefine.push_back(packetDefine);

			STRING includestr=FindXMLElement("pbbuffer_include");
			if(includestr.find(headVal) == STRINGEND)continue;

			STRING filecode = FindXMLElement("pbbuffer_filename");
			STRING filedir = FindXMLElement("pbbuffer_dir");
			Replace(filecode,"${option}",OptionName.c_str());
			if(bSkiphandler == TRUE &&(_access(filecode.c_str(), 0 )) != -1)continue;
			if(!EnvFileStream(filecode,filedir))return false;


			STRING includehead =  FindXMLElement("pbbuffer_include_head");
			vector<STRING> headlist;
			AnalyRule(headlist,includehead,"|");		
			for(vector<STRING>::const_iterator it = headlist.begin();it!= headlist.end();++it)
			{				
				InsertImport(headVal,listClass,*it,OptionName);
			}

			this->Write(FindXMLElement("pbbuffer_descript"));

			STRING importContent = FindXMLElement("pbbuffer_import");
			Replace(importContent,"${option}",OptionName.c_str());
			Replace(importContent,"${Realpacket}",rValueProtocol.className.c_str());
			Write(importContent);


			


			STRING definepacket = "PACKET_";
			definepacket +=__BB(OptionName);
			STRING commonContent = FindXMLElement("pbbuffer_common");
			Replace(commonContent,"${option}",OptionName.c_str());
		    Replace(commonContent,"${Realpacket}",rValueProtocol.className.c_str());
			Replace(commonContent,"${PACKETID}",definepacket.c_str());
			Write(commonContent);
				

		}
	}
		//////////////////////////////////////////////////////////////////////////Factory//////////////////////////////////////////////////////////////////////
		{
			if ( FALSE == ReadTemplateXML(m_xmlTemplate,JAVA_PACKET_FACTORYMANAGER))
			{
				Model_Log::CashLog<const char*,int,const char*>("CProtoDataMethod pdatas==%s(%d)%s",__FILE__,__LINE__,JAVA_PACKET_FACTORYMANAGER,Model_Log::CrashLog::LOG_ERROR);
				return false;
			}

			STRING filecode = FindXMLElement("pbbuffer_filename");		
			STRING filedir = FindXMLElement("pbbuffer_dir");	
			if(!EnvFileStream(filecode,filedir))return false;

			this->Write(FindXMLElement("pbbuffer_descript"));


			STRING importContent = FindXMLElement("pbbuffer_import");
			STRING includeSingle =  FindXMLElement("pbbuffer_include_single");
			STRING factoryContent = FindXMLElement("pbbuffer_factory_sub");
			STRING subfactoryContent ="";
			STRING commonContent = FindXMLElement("pbbuffer_common");

			if(!includeSingle.empty())
			{
				STRING includehead =  FindXMLElement("pbbuffer_include_head");
				vector<STRING> headlist;
				AnalyRule(headlist,includehead,"|");
				STRING headInclude="";
				for(vector<STRING>::const_iterator it = headlist.begin();it!= headlist.end();++it)
				{
					headInclude += GetImport(*it,listClass,includeSingle);	
					subfactoryContent +=GePacket(*it,listClass,factoryContent);
				}
				Replace(importContent,"${IMPORT}",headInclude.c_str());	
				Write(importContent);

				Replace(commonContent,"${FACTORY}",subfactoryContent.c_str());	
				Write(commonContent);
			}
	 }
		//////////////////////////////////////////////////////////////////////////MessageID//////////////////////////////////////////////////////////////////////
		{
			if ( FALSE == ReadTemplateXML(m_xmlTemplate,JAVA_PACKET_DEFINE))
			{
				Model_Log::CashLog<const char*,int,const char*>("CProtoDataMethod pdatas==%s(%d)%s",__FILE__,__LINE__,JAVA_PACKET_DEFINE,Model_Log::CrashLog::LOG_ERROR);
				return false;
			}

			STRING filecode = FindXMLElement("pbbuffer_filename");	
			STRING filedir = FindXMLElement("pbbuffer_dir");	
			if(!EnvFileStream(filecode,filedir))return false;

			Write(FindXMLElement("pbbuffer_descript"));

			STRING Content = FindXMLElement("pbbuffer_common");

			STRING defineList ="";
			for (PacketDefine_T::const_iterator it =listPacketdefine.begin();it != listPacketdefine.end();++it)
			{
				defineList += *it;
			}
			Replace(Content,"${FULLDATA}",defineList.c_str());
			Replace(Content,"${maxpacket}",CovertIntToString(nMAXPACKET+1).c_str());
			Write(Content);
		}
	return true;
}

bool CPacketJava::Init()
{
	return true;
}

bool CPacketJava::Release()
{
	return true;
}

