#include "PacketCSharp.h"
#include "Log.h"
#include "StringFun.h"
#include "tinyxml.h"
#include "PacketCreateDefine.h"

CPacketCSharp::CPacketCSharp(void)
{
	m_File = NULL;
}


CPacketCSharp::~CPacketCSharp(void)
{
	if(m_File)
	{
		m_File->close();
		SAFE_DELETE(m_File);
	}
}

struct PacketStruct_T
{
	PacketStruct_T(){}
	PacketStruct_T(STRING const& _ref,STRING const& _real):refenceName(_ref),realName(_real){}
	STRING refenceName;
	STRING realName;
};

bool CPacketCSharp::CreatePacket( CProtoDataMethod const* pdatas ,BOOL bSkiphandler)
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
	map<STRING,PacketStruct_T> listdetail;//保存消息包和实际的包对应关系

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
			if ( FALSE == ReadTemplateXML(m_xmlTemplate,CS_PACKET_HANDLER))
			{
				Model_Log::CashLog<const char*,int,const char*>("CProtoDataMethod pdatas==%s(%d)%s",__FILE__,__LINE__,CS_PACKET_HANDLER,Model_Log::CrashLog::LOG_ERROR);
				return false;
			}

			STRING packetDefine = "PACKET_";
			packetDefine += __BB(OptionName);
			PacketStruct_T packetRef(OptionName,rValueProtocol.className);
			listdetail[packetDefine] = packetRef;
			packetDefine += "\t=\t";
			packetDefine += Numbers;
			packetDefine += ",\t//";
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

			STRING includehead =  FindXMLElement("pbbuffer_include_head");
			vector<STRING> headlist;
			AnalyRule(headlist,includehead,"|");		
			for(vector<STRING>::const_iterator it = headlist.begin();it!= headlist.end();++it)
			{				
				InsertImport(headVal,listClass,*it,OptionName);
			}

			STRING filecode = FindXMLElement("pbbuffer_filename");
			STRING filedir = FindXMLElement("pbbuffer_dir");
			Replace(filecode,"${option}",OptionName.c_str());			
			if(bSkiphandler == TRUE &&(_access(filecode.c_str(), 0 )) != -1)continue;
			if(!EnvFileStream(filecode,filedir))return false;


		

			this->Write(FindXMLElement("pbbuffer_descript"));

			STRING importContent = FindXMLElement("pbbuffer_import");
			Replace(importContent,"${option}",OptionName.c_str());
			Replace(importContent,"${Realpacket}",rValueProtocol.className.c_str());
			Write(importContent);

			STRING commonContent = FindXMLElement("pbbuffer_common");
			Replace(commonContent,"${option}",OptionName.c_str());
			Replace(commonContent,"${Realpacket}",rValueProtocol.className.c_str());		
			Write(commonContent);


		}
	}
	//////////////////////////////////////////////////////////////////////////Factory//////////////////////////////////////////////////////////////////////
	{
		if ( FALSE == ReadTemplateXML(m_xmlTemplate,CS_PACKET_FACTORYMANAGER))
		{
			Model_Log::CashLog<const char*,int,const char*>("CProtoDataMethod pdatas==%s(%d)%s",__FILE__,__LINE__,CS_PACKET_FACTORYMANAGER,Model_Log::CrashLog::LOG_ERROR);
			return false;
		}

		STRING filecode = FindXMLElement("pbbuffer_filename");		
		STRING filedir = FindXMLElement("pbbuffer_dir");	
		if(!EnvFileStream(filecode,filedir))return false;

		this->Write(FindXMLElement("pbbuffer_descript"));


		STRING importContent = FindXMLElement("pbbuffer_import");
		//STRING includeSingle =  FindXMLElement("pbbuffer_include_single");
		STRING factoryContent = FindXMLElement("pbbuffer_factory_sub");
		STRING subfactoryContent ="";
		STRING commonContent = FindXMLElement("pbbuffer_common");

	
			STRING includehead =  FindXMLElement("pbbuffer_include_head");
			vector<STRING> headlist;
			AnalyRule(headlist,includehead,"|");
			
			for(vector<STRING>::const_iterator it = headlist.begin();it!= headlist.end();++it)
			{				
				subfactoryContent +=GePacket(*it,listClass,factoryContent);
			}	
			Replace(commonContent,"${FACTORY}",subfactoryContent.c_str());	
			Write(commonContent);
		

			STRING bodyContent = FindXMLElement("pbbuffer_body");
		
				 
			for(vector<STRING>::const_iterator it = headlist.begin();it!= headlist.end();++it)
			{				
				for (map<STRING,PacketStruct_T>::const_iterator sit=listdetail.begin();sit!=listdetail.end();sit++)
				{
					if(sit->second.realName.find(*it) != STRINGEND)
					{
						STRING temps = bodyContent;
						Replace(temps,"${PACKETDEFINE}",sit->first.c_str());
						Replace(temps,"${option}",sit->second.refenceName.c_str());
						Write(temps);
					}
				}
			}	
			
			Write( FindXMLElement("pbbuffer_tail"));

	}
	//////////////////////////////////////////////////////////////////////////MessageID//////////////////////////////////////////////////////////////////////
	{
		if ( FALSE == ReadTemplateXML(m_xmlTemplate,CS_PACKET_DEFINE))
		{
			Model_Log::CashLog<const char*,int,const char*>("CProtoDataMethod pdatas==%s(%d)%s",__FILE__,__LINE__,CS_PACKET_DEFINE,Model_Log::CrashLog::LOG_ERROR);
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
	//////////////////////////////////////////////////////////////////////////PacketDistributed//////////////////////////////////////////////////////////////////////
	{
		if ( FALSE == ReadTemplateXML(m_xmlTemplate,CS_PACKET_BASEPACKET))
		{
			Model_Log::CashLog<const char*,int,const char*>("CProtoDataMethod pdatas==%s(%d)%s",__FILE__,__LINE__,CS_PACKET_BASEPACKET,Model_Log::CrashLog::LOG_ERROR);
			return false;
		}

		STRING filecode = FindXMLElement("pbbuffer_filename");		
		STRING filedir = FindXMLElement("pbbuffer_dir");	
		if(!EnvFileStream(filecode,filedir))return false;

		this->Write(FindXMLElement("pbbuffer_descript"));


		STRING importContent = FindXMLElement("pbbuffer_import");	
		this->Write(importContent);
		STRING factoryContent = FindXMLElement("pbbuffer_factory_sub");
		STRING subfactoryContent ="";
		STRING commonContent = FindXMLElement("pbbuffer_common");


		STRING includehead =  FindXMLElement("pbbuffer_include_head");
		vector<STRING> headlist;
		AnalyRule(headlist,includehead,"|");

		
		for(vector<STRING>::const_iterator it = headlist.begin();it!= headlist.end();++it)
		{				
			for (map<STRING,PacketStruct_T>::const_iterator sit=listdetail.begin();sit!=listdetail.end();sit++)
			{
				if(sit->second.realName.find(*it) != STRINGEND)
				{
					STRING temps = factoryContent;
					Replace(temps,"${PACKETID}",sit->first.c_str());
					Replace(temps,"${Realpacket}",sit->second.realName.c_str());
					subfactoryContent += temps;
				}
			}
		}	
		Replace(commonContent,"${FACTORY}",subfactoryContent.c_str());	
		Write(commonContent);
	}

	return true;
}

bool CPacketCSharp::Init()
{

	return true;
}

bool CPacketCSharp::Release()
{
	return true;
}

