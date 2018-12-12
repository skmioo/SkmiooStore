#include "TabelImpl.h"
#include "BaseDef.h"
#include "Type.h"
#include "TableCSharp.h"
#include "TableJava.h"
#include "StringFun.h"
#include "WinFun.h"
#include "tinyxml.h"
#include "Log.h"

CTabelImpl* CTabelImpl::CreateInstance( const STRING& rTpye )
{
	if (rTpye =="-charp")
	{
		return new CTableCSharp();
	}
	else if (rTpye =="-java")
	{
		return new CTableJava();
	}
	 return NULL;
}

VOID CTabelImpl::MarkDir() const
{
	WriteDirectory(GetDir());
}

STRING CTabelImpl::GetCodeNameInFile( const STRING& file )const
{	
	 STRING subStr = GetDataFileName(file);
	  ReplaceRule(subStr,"_");
	 return subStr;
}
STRING CTabelImpl::GetDataFileName( const STRING& file ) const
{
	if (file.empty())return "";

	STRINGTYPE npos = file.find_last_of("/");
	STRINGTYPE notherpos = file.find_last_of("\\");

	if (npos == STRINGEND)npos =0;
	if (notherpos == STRINGEND)notherpos =0;

	npos = npos >notherpos ? npos : notherpos;

	notherpos =  file.find(".",npos);
	if (notherpos == STRINGEND)notherpos =file.length();

	 return file.substr(npos+1,notherpos-npos-1);
}

BOOL CTabelImpl::AnalyXMLSturct( const STRING& fileName,LIstStruct_T& serival ) const
{
	TiXmlDocument doc;  
	if (doc.LoadFile(fileName.c_str()))
	{  	
		//doc.Print();  
	} else {
		Model_Log::CashLog<const char*>("Can not Open %s",fileName.c_str(),Model_Log::CrashLog::LOG_ERROR);
		return FALSE;
	}

	TiXmlElement* rootElement = doc.RootElement();  //pbbuffer元素 
	if (rootElement==NULL)
	{
		Model_Log::CashLog<const char*>("Read XML %s Error!! not Root Element",fileName.c_str(),Model_Log::CrashLog::LOG_ERROR);
		return FALSE;
	}
	rootElement =rootElement->FirstChildElement();  //direct元素 
	if (rootElement==NULL)
	{
		Model_Log::CashLog<const char*>("Read XML %s Error!! not direct Element",fileName.c_str(),Model_Log::CrashLog::LOG_ERROR);
		return FALSE;
	}

	vector<STRING> myTmp[2];
	INT nK=0;
	for (TiXmlElement* pSubElement = rootElement->FirstChildElement(); 
		pSubElement != NULL; pSubElement = pSubElement->NextSiblingElement() )
	{
		const char* pKey =  pSubElement->Value();
		const char* PContent = pSubElement->GetText();
		if(pKey ==NULL)continue;

		if (strcmp("name",pKey)==0)
		{
			nK =1;
		}
		else
		{
			nK =0;
		}
		for (TiXmlElement* pSpringElement = pSubElement->FirstChildElement(); 
			pSpringElement != NULL; pSpringElement = pSpringElement->NextSiblingElement() )
		{
			
			const char* PSpringContent = pSpringElement->GetText();
			if(PSpringContent == NULL)continue;
			myTmp[nK].push_back(PSpringContent);
		}		
	}
	if (myTmp[1].size() != myTmp[0].size())
	{
		Model_Log::CashLog<const char*>("Read XML %s Error!! code size(%d) not type size(%d)",fileName.c_str(),myTmp[1].size(), myTmp[0].size(),Model_Log::CrashLog::LOG_ERROR);
		return FALSE;
	}
	for (int i=0;i<myTmp[1].size();++i)
	{
		Code_Serial element;
		element.m_Type = myTmp[1][i];
		element.m_Name = myTmp[0][i];
		serival.push_back(element);
	}
	return TRUE;
}
BOOL CTabelImpl::AnalyTxtSturct( const STRING& rFile,LIstStruct_T& serival ) const
{
	typedef std::ifstream	Sysifstream;
	Sysifstream file(rFile,ios::in );	
	if (!file) 
	{		
		Model_Log::CashLog<const char*>("Read TXT %s Error!! ",rFile.c_str(),Model_Log::CrashLog::LOG_ERROR);
		return FALSE;
	}
	string line;
	int nCol=0;
	vector<STRING> myTmp[2];
	while (getline(file,line))
	{
		if ( !line.length()) continue;
		if ( line[0] == '#') continue;
		if ( line[0] == ';') continue;
		
		if(nCol == 0)
		{
			++nCol;
			AnalyRule(myTmp[0],line,"\t");
		}
		else if(nCol == 1)
		{
			++nCol;
			AnalyRule(myTmp[1],line,"\t");
		}
		else break;
	}
		if (myTmp[1].size() != myTmp[0].size())
		{
			Model_Log::CashLog<const char*>("Read TXT %s Error!! code size(%d) not type size(%d)",rFile.c_str(),myTmp[1].size(), myTmp[0].size(),Model_Log::CrashLog::LOG_ERROR);
			return FALSE;
		}
		for (int i=0;i<myTmp[1].size();++i)
		{
		
			if(i==1)continue;
			Code_Serial element;
			element.m_Type = myTmp[1][i];
			element.m_Name = myTmp[0][i];
			serival.push_back(element);
		}

	file.close();
	return TRUE;
}

STRING CTabelImpl::FindXMLElement(XMLReader_T const& _xmlTemplate,STRING const& key ) const
{
	if (IsEmptOrSpace(key))
	{
		return "";
	}
	XMLReader_T::const_iterator itincludes = _xmlTemplate.find(key);
	if (itincludes != _xmlTemplate.end())
	{
		return itincludes->second.m_Content;
	}
	return "";
}

BOOL CTabelImpl::ReadTemplateXML( XMLReader_T& datas ,const  CHAR* FileName)const
{
		STRING fileName = FileName==NULL? GetTemplatemanager():FileName;
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

		TiXmlElement* rootElement = doc.RootElement();  //pbbuffer元素 
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

VOID CTabelImpl::WriteCode( std::ofstream& pFile,const STRING& RContent ) const
{
		STRING tmp =RContent;
		Replace(tmp,"${N}","\n");
		Replace(tmp,"${L}","<");
		Replace(tmp,"${R}",">");
		Replace(tmp,"${C}","&");
		pFile << tmp << endl;
}

VOID CTabelImpl::SerDataToArray( const LIstStruct_T &rSource,SerialListStruct_T & rDest,UniqueStruct_T& sTrace )
{
	//主要检测是否能拼装成数组	 
	for (LIstStruct_T::const_iterator it = rSource.begin();it != rSource.end();++it)
	{
		Code_Serial const& oCode = *it;
		STRING StrKey = RraseTailNumber(oCode.m_Name);	
		rDest.insert(make_pair(StrKey,oCode));
		sTrace.insert(StrKey);
	}

}



