#include "TableCSharp.h"
#include <fstream>
#include "WinFun.h"
#include "Tabdef.h"
#include "Log.h"
#include "StringFun.h"
using namespace std;

STRING  CTableCSharp::GetRealType(const STRING& _sType ,STRING* defualtTypevalue)const
{
	std::string sType = __BB(_sType);
	if (sType == "FLOAT"){ if(NULL != defualtTypevalue)*defualtTypevalue="0.0f"; return "float";}
	else if (sType == "STRING") { if(NULL != defualtTypevalue)*defualtTypevalue="\"\"";return "string";}
	else if (sType == "INT") { if(NULL != defualtTypevalue)*defualtTypevalue="-1";return "int";}
	else if (sType == "SHORT"){ if(NULL != defualtTypevalue)*defualtTypevalue="-1"; return "short";}
	else if (sType == "BYTE") { if(NULL != defualtTypevalue)*defualtTypevalue="0";return "byte";}
	else if (sType == "BOOLEAN") { if(NULL != defualtTypevalue)*defualtTypevalue="false";return "bool";}
	return "<error>";
}
STRING  CTableCSharp::GetRealTypeValue(const STRING& _sType,const STRING& sIdx)const
{
	std::string sType = __BB(_sType);
	if (sType == "FLOAT") 
	{
			string str = " Convert.ToSingle(valuesList[";
			str += sIdx;
			str += "] as string )";
			return str;
	}
	if (sType == "BOOLEAN") 
	{
		string str = " (valuesList[";
		str += sIdx;
		str += "] as string)==\"TRUE\"";
		return str;
	}
	if (sType == "STRING") 
	{
		string str = " valuesList[";
		str += sIdx;
		str += "] as string";
		return str;
	}
	if (sType == "INT") 
	{
		string str = " Convert.ToInt32(valuesList[";
		str += sIdx;
		str += "] as string)";
		return str;
	}
	if (sType == "SHORT") 
	{
		string str = " Convert.ToInt16(valuesList[";
		str += sIdx;
		str += "] as string)";
		return str;
	}
	if (sType == "BYTE") 
	{
		string str = " Convert.ToByte(valuesList[";
		str += sIdx;
		str += "] as string,10)";
		return str;
	}
	return "<error>";
}

BOOL CTableCSharp::CovertFileToCode( const STRING& rFile,STRING& error ) const
{
	STRING codeFileName = GetDir();
	codeFileName += "Table_";
	codeFileName += GetCodeNameInFile(rFile);
	codeFileName += ".cs";
	std::ofstream  _File;
	TryCreateDirectory(codeFileName);
	_File.open(codeFileName.c_str(),ios_base::binary);
	if (!_File.is_open())
	{
		error = "Out file can not write please check disk:" ;
		error +=  codeFileName ;
		return FALSE;
	}
	LIstStruct_T listserial;
	if(FALSE == AnalyTxtSturct(rFile,listserial))
	{
		error = "Ananly file to XML Error:" ;
		error +=  rFile ;
		return FALSE;
	}
	//
	XMLReader_T _reader;
	if(FALSE == ReadTemplateXML(_reader,C_SHARP_CODE_TEMPLATE))
	{
		Model_Log::CashLog<const char*>("Read XML %s Error!!  Please Check XML",GetTemplatemanager(),Model_Log::CrashLog::LOG_ERROR);
		return FALSE;
	}
	WriteCode(_File,FindXMLElement(_reader,"plist_descript") );
	WriteCode(_File,FindXMLElement(_reader,"plist_import") );
	WriteCode(_File,FindXMLElement(_reader,"plist_namespace") );

	{
		STRING tempstr = FindXMLElement(_reader,"plist_classhead");
		STRING codename = GetCodeNameInFile(rFile);
		ReplaceRule(codename,"_");
		Replace(tempstr,"${CodeName}",codename.c_str());
		Replace(tempstr,"${FileName}",ChangeIndexTail(GetDataFileName(rFile),".txt").c_str());
		STRING  enumList ="INVLAID_INDEX=-1,\n";
		enumList += "ID_";
		LIstStruct_T::const_iterator it = listserial.begin();
		enumList += __BB(it->m_Name);
		enumList +=",\n";
		++it;
		if(it != listserial.end())
		{
			enumList += "ID_";
			enumList += __BB(it->m_Name);
			enumList +="=2,\n";
			++it;
		}
		for (;it != listserial.end();++it)
		{
			const Code_Serial& rData = *it;
			enumList += "ID_";
			enumList += __BB(rData.m_Name);
			enumList +=",\n";
		}
		enumList += "MAX_RECORD\n";
		Replace(tempstr,"${FULLENUM}",enumList.c_str());
		WriteCode(_File,tempstr );
	}

		STRING tempbody = FindXMLElement(_reader,"plist_inittable");
		STRING codsename = GetCodeNameInFile(rFile);
		ReplaceRule(codsename,"_");
		Replace(tempbody,"${CodeName}",codsename.c_str());
		
	
		//将表格归一化为数组，如果有的话
	SerialListStruct_T listAll;
	UniqueStruct_T sTrace;
	SerDataToArray(listserial,listAll,sTrace);
	STRING fullDataLoad="";
	for (UniqueStruct_T::const_iterator it = sTrace.begin();it != sTrace.end();++it)
	{
		 pair<SerialListStruct_T::const_iterator, SerialListStruct_T::const_iterator> RangeSort = listAll.equal_range(*it);

		 INT nCount =0;
		for(SerialListStruct_T::const_iterator subit = RangeSort.first;subit!=RangeSort.second;subit++)++nCount;

		INT nFlag=0;
		 STRING tempvar = FindXMLElement(_reader,"plist_repeat");
		 for(SerialListStruct_T::const_iterator subit = RangeSort.first;subit!=RangeSort.second;subit++)
		 {
			 if(nCount<2)
			 {
				 STRING defualtTypevalue ="";
				STRING singlevar = FindXMLElement(_reader,"plist_single");
				STRING sType = GetRealType(subit->second.m_Type,&defualtTypevalue);
				STRING sName = subit->second.m_Name;
				ReplaceRule(sName,"_");
				Replace(singlevar,"${type}",sType.c_str());
				Replace(singlevar,"${defaultvalue}",defualtTypevalue.c_str());
				Replace(singlevar,"${Variable}",sName.c_str());
				fullDataLoad += "_values.m_";
				fullDataLoad += sName;
				fullDataLoad += " = ";
				STRING enumsp = "(int)_ID.ID_";
				enumsp += __BB(subit->second.m_Name);
				fullDataLoad += GetRealTypeValue(subit->second.m_Type,enumsp);
				fullDataLoad +=";\n";
				WriteCode(_File,singlevar);
			 }
			 else
			 {
				  STRING defualtTypevalue ="";
				 STRING sType = GetRealType(subit->second.m_Type,&defualtTypevalue);
				 STRING sName = *it;
				 ReplaceRule(sName,"_");
				 if(0 == nFlag)
				 {					
					 Replace(tempvar,"${type}",sType.c_str());
					 Replace(tempvar,"${Variable}",sName.c_str());
					 Replace(tempvar,"${defaultvalue}",defualtTypevalue.c_str());
					 Replace(tempvar,"${COUNT}",CovertIntToString(nCount).c_str());
					  WriteCode(_File,tempvar);
					  ++nFlag;
				 }
				 else
				 {
					  ++nFlag;
				 }
				 fullDataLoad += "_values.m_";
				 fullDataLoad += sName;
				  fullDataLoad += " [ ";
				   fullDataLoad += CovertIntToString(nFlag-1);
				  fullDataLoad += " ]";
				 fullDataLoad += " = ";
				 STRING enumsp = "(int)_ID.ID_";
				 enumsp += __BB(subit->second.m_Name);
				 fullDataLoad += GetRealTypeValue(subit->second.m_Type,enumsp);		
				 fullDataLoad +=";\n";
			 }
		 }		
	}
	Replace(tempbody,"${FULLREADER}",fullDataLoad.c_str());
	WriteCode(_File,tempbody);
	WriteCode(_File,FindXMLElement(_reader,"plist_tail") );
	_File.close();
	return TRUE;
}

BOOL CTableCSharp::WriteManager( const std::set<STRING>& rFile ) const
{
	STRING codeFileName = GetDir();
	codeFileName +=GetManagerName();	
	std::ofstream  _File;
	TryCreateDirectory(codeFileName);
	_File.open(codeFileName.c_str(),ios_base::binary);
	if (!_File.is_open())
	{
		Model_Log::CashLog<const char*>("Create Code %s Error!!  Please Check Disk",codeFileName.c_str(),Model_Log::CrashLog::LOG_ERROR);
		return FALSE;
	}
	XMLReader_T _reader;
	if(FALSE == ReadTemplateXML(_reader))
	{
		Model_Log::CashLog<const char*>("Read XML %s Error!!  Please Check XML",GetTemplatemanager(),Model_Log::CrashLog::LOG_ERROR);
		return FALSE;
	}
	WriteCode(_File,FindXMLElement(_reader,"plist_descript") );
	WriteCode(_File,FindXMLElement(_reader,"plist_import") );
	WriteCode(_File,FindXMLElement(_reader,"plist_namespace") );
	WriteCode(_File,FindXMLElement(_reader,"plist_classhead") );

	{
		STRING tempxml = FindXMLElement(_reader,"plist_managerdata");
		for (std::set<STRING>::const_iterator it = rFile.begin();it  != rFile.end();++it)
		{
			STRING serial = tempxml;
			STRING codeName = GetCodeNameInFile(*it);
			ReplaceRule(codeName,"_");
			Replace(serial,"${CodeName}",codeName.c_str());
			WriteCode(_File,serial);
		}
	}

	{

		STRING singlexml = FindXMLElement(_reader,"plist_initsingle");
		STRING rContents ="";
		for (std::set<STRING>::const_iterator it = rFile.begin();it  != rFile.end();++it)
		{			
			STRING simplease = singlexml;
			STRING codeName = GetCodeNameInFile(*it);
			ReplaceRule(codeName,"_");
			Replace(simplease,"${CodeName}",codeName.c_str());
			rContents += simplease;
			rContents += "\n";
		}
		{
			STRING tempxml = FindXMLElement(_reader,"plist_inittable");
			STRING serial = tempxml;
			Replace(serial,"${FULLINIT}",rContents.c_str());
			WriteCode(_File,serial);
		}
	}


	{
		STRING tempxml = FindXMLElement(_reader,"plist_manageropt");
		for (std::set<STRING>::const_iterator it = rFile.begin();it  != rFile.end();++it)
		{
			STRING serial = tempxml;
			STRING codeName = GetCodeNameInFile(*it);
			ReplaceRule(codeName,"_");
			Replace(serial,"${CodeName}",codeName.c_str());
			WriteCode(_File,serial);
		}
	}

	WriteCode(_File,FindXMLElement(_reader,"plist_tail") );
	_File.close();
	return TRUE;
}





