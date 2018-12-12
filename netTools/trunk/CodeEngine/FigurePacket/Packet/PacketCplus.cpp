#include "PacketCplus.h"
#include "Log.h"
#include "StringFun.h"
#include "tinyxml.h"
#include "PacketCreateDefine.h"
CPacketCplus::CPacketCplus(void)
{
	m_File = NULL;
}


CPacketCplus::~CPacketCplus(void)
{
	if(m_File)
	{
		m_File->close();
		SAFE_DELETE(m_File);
	}
}

bool CPacketCplus::CreatePacket( CProtoDataMethod const* pdatas,BOOL bSkiphandler )
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


		
		//////////////////////////////////////////////////////////////////////////H//////////////////////////////////////////////////////////////////////
		STRING OptionName = __BB(headVal) + __B(optionVal);
		{
			
			if ( FALSE == ReadTemplateXML(m_xmlTemplate,C_PACKET_H))
			{
				Model_Log::CashLog<const char*,int,const char*>("CProtoDataMethod pdatas==%s(%d)%s",__FILE__,__LINE__,C_PACKET_H,Model_Log::CrashLog::LOG_ERROR);
				return false;
			}

			STRING includehead =  FindXMLElement("pbbuffer_include");
			vector<STRING> headlist;
			AnalyRule(headlist,includehead,"|");	
			bool bNeedWrite = false;
			for(vector<STRING>::const_iterator it = headlist.begin();it!= headlist.end();++it)
			{				
				bNeedWrite |= InsertImport(headVal,listClass,*it,OptionName);
			}
			
			if(!bNeedWrite)continue;

			STRING filecode = FindXMLElement("pbbuffer_filename");
			Replace(filecode,"${option}",OptionName.c_str());
			STRING filedir = FindXMLElement("pbbuffer_dir");
			if(!EnvFileStream(filecode,filedir))return false;

			


			this->Write(FindXMLElement("pbbuffer_descript"));

			STRING importContent = FindXMLElement("pbbuffer_import");
			Replace(importContent,"${option}",OptionName.c_str());
			Replace(importContent,"${OPTION}",__BB(OptionName).c_str());
			Replace(importContent,"${Realclass}",realclass.c_str());
			Write(importContent);

			Write(FindXMLElement("pbbuffer_head"));


			STRING commonContent = FindXMLElement("pbbuffer_common");
			Replace(commonContent,"${option}",OptionName.c_str());
			Replace(commonContent,"${OPTION}",__BB(OptionName).c_str());
			Replace(commonContent,"${Realclass}",realclass.c_str());
			Write(commonContent);

			Write(FindXMLElement("pbbuffer_tail"));

			STRING packetDefine = "PACKET_";
			packetDefine += __BB(OptionName);
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


		}
		//////////////////////////////////////////////////////////////////////////CPP//////////////////////////////////////////////////////////////////////
		{
			if ( FALSE == ReadTemplateXML(m_xmlTemplate,C_PACKET_CC))
			{
				Model_Log::CashLog<const char*,int,const char*>("CProtoDataMethod pdatas==%s(%d)%s",__FILE__,__LINE__,C_PACKET_CC,Model_Log::CrashLog::LOG_ERROR);
				return false;
			}

			STRING filecode = FindXMLElement("pbbuffer_filename");
			Replace(filecode,"${option}",OptionName.c_str());
			STRING filedir = FindXMLElement("pbbuffer_dir");
			if(!EnvFileStream(filecode,filedir))return false;

			this->Write(FindXMLElement("pbbuffer_descript"));

			STRING importContent = FindXMLElement("pbbuffer_import");
			Replace(importContent,"${option}",OptionName.c_str());
			Replace(importContent,"${OPTION}",__BB(OptionName).c_str());			
			Write(importContent);




			STRING commonContent = FindXMLElement("pbbuffer_common");
			Replace(commonContent,"${option}",OptionName.c_str());
			Replace(commonContent,"${OPTION}",__BB(OptionName).c_str());
			Replace(commonContent,"${Realclass}",realclass.c_str());
			Write(commonContent);
		}

		//////////////////////////////////////////////////////////////////////////Handler//////////////////////////////////////////////////////////////////////
		{
			if ( FALSE == ReadTemplateXML(m_xmlTemplate,C_PACKET_HANDLER))
			{
				Model_Log::CashLog<const char*,int,const char*>("CProtoDataMethod pdatas==%s(%d)%s",__FILE__,__LINE__,C_PACKET_HANDLER,Model_Log::CrashLog::LOG_ERROR);
				return false;
			}

			STRING includehead =  FindXMLElement("pbbuffer_include");
			vector<STRING> headlist;
			AnalyRule(headlist,includehead,"|");	
			bool bNeedWrite = false;
			for(vector<STRING>::const_iterator it = headlist.begin();it!= headlist.end();++it)
			{				
				if(headVal.find(*it) != STRINGEND){bNeedWrite=true;break;}
			}

			if(!bNeedWrite)continue;



			STRING filecode = FindXMLElement("pbbuffer_filename");
			Replace(filecode,"${option}",OptionName.c_str());
			STRING filedir = FindXMLElement("pbbuffer_dir");
			if(bSkiphandler == TRUE &&(_access(filecode.c_str(), 0 )) != -1)continue;
			if(!EnvFileStream(filecode,filedir))return false;

			this->Write(FindXMLElement("pbbuffer_descript"));

			STRING importContent = FindXMLElement("pbbuffer_import");
			Replace(importContent,"${option}",OptionName.c_str());
			Replace(importContent,"${OPTION}",__BB(OptionName).c_str());
			Write(importContent);




			STRING commonContent = FindXMLElement("pbbuffer_common");
			Replace(commonContent,"${option}",OptionName.c_str());
			Replace(commonContent,"${OPTION}",__BB(OptionName).c_str());
			Replace(commonContent,"${Realclass}",realclass.c_str());
			Write(commonContent);
		}


	}//end for



	//////////////////////////////////////////////////////////////////////////Factory//////////////////////////////////////////////////////////////////////
		{
			if ( FALSE == ReadTemplateXML(m_xmlTemplate,C_PACKET_FACTORYMANAGER))
			{
				Model_Log::CashLog<const char*,int,const char*>("CProtoDataMethod pdatas==%s(%d)%s",__FILE__,__LINE__,C_PACKET_FACTORYMANAGER,Model_Log::CrashLog::LOG_ERROR);
				return false;
			}

			STRING filecode = FindXMLElement("pbbuffer_filename");			
			STRING filedir = FindXMLElement("pbbuffer_dir");
			if(!EnvFileStream(filecode,filedir))return false;

			this->Write(FindXMLElement("pbbuffer_descript"));

			STRING importContent = FindXMLElement("pbbuffer_import");
			STRING includeSingle =  FindXMLElement("pbbuffer_include_single");
			if(!includeSingle.empty())
			{
				STRING includehead =  FindXMLElement("pbbuffer_include_head");
				vector<STRING> headlist;
				AnalyRule(headlist,includehead,"|");
				STRING headInclude="";
				for(vector<STRING>::const_iterator it = headlist.begin();it!= headlist.end();++it)
				{
						headInclude = GetImport(*it,listClass,includeSingle);	
				}
				Replace(importContent,"${IMPORT}",headInclude.c_str());	
				Write(importContent);
				
			
			}




			STRING commonContent = FindXMLElement("pbbuffer_common");		
			Write(commonContent);


			
			STRING subfactoryContent = FindXMLElement("pbbuffer_factory_sub");

			STRING factoryContent = FindXMLElement("pbbuffer_factory");
			Replace(factoryContent,"${FACTORY_SUB_RS}",GePacket("RS",listClass,subfactoryContent).c_str());	
			Replace(factoryContent,"${FACTORY_SUB_SR}",GePacket("SR",listClass,subfactoryContent).c_str());	
			Replace(factoryContent,"${FACTORY_SUB_LC}",GePacket("LC",listClass,subfactoryContent).c_str());	
			Replace(factoryContent,"${FACTORY_SUB_CL}",GePacket("CL",listClass,subfactoryContent).c_str());	
			Replace(factoryContent,"${FACTORY_SUB_CS}",GePacket("CS",listClass,subfactoryContent).c_str());	
			Replace(factoryContent,"${FACTORY_SUB_SC}",GePacket("SC",listClass,subfactoryContent).c_str());	
			Replace(factoryContent,"${FACTORY_SUB_CL}",GePacket("CL",listClass,subfactoryContent).c_str());	
			Replace(factoryContent,"${FACTORY_SUB_LC}",GePacket("LC",listClass,subfactoryContent).c_str());
			Replace(factoryContent,"${FACTORY_SUB_WS}",GePacket("WS",listClass,subfactoryContent).c_str());	
			Replace(factoryContent,"${FACTORY_SUB_SW}",GePacket("SW",listClass,subfactoryContent).c_str());	
			Replace(factoryContent,"${FACTORY_SUB_GC}",GePacket("GC",listClass,subfactoryContent).c_str());	
			Write(factoryContent);

		}

	//////////////////////////////////////////////////////////////////////////PacketDefine//////////////////////////////////////////////////////////////////////
	{
		if ( FALSE == ReadTemplateXML(m_xmlTemplate,C_PACKET_DEFINE))
		{
			Model_Log::CashLog<const char*,int,const char*>("CProtoDataMethod pdatas==%s(%d)%s",__FILE__,__LINE__,C_PACKET_DEFINE,Model_Log::CrashLog::LOG_ERROR);
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
bool CPacketCplus::Init()
{
	return true;
}

bool CPacketCplus::Release()
{
	return true;
}



void CPacketCplus::Realse()
{
	if(m_File)
	{
		m_File->close();
	}
	SAFE_DELETE(m_File);
}




