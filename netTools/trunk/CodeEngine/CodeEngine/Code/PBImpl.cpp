#include "PBImpl.h"
#include "Log.h"
#include "StringFun.h"
#include "PBCSharp.h"
#include "tinyxml.h"

CprotocolBuffer* CprotocolBuffer::CreateInstance( string const& sType )
{
	 if (sType == CodeEngine_Type::C_CSHARP)
	 {
		 return new CPBCSharp();
	 }

	 return NULL;
}

 string  CprotocolBuffer::GetTailNameByType(string const& sType)
 {
	 if (sType == CodeEngine_Type::C_CSHARP)
	 {
		 return ".cs";
	 }
	 else if (sType == CodeEngine_Type::C_JAVA)
	 {
		 return ".java";
	 }
	 return "";
 }

BOOL CprotocolBuffer::ReadTemplateXML( XMLReader_T& datas )
{
	STRING fileName = GetTemplateFile();
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



