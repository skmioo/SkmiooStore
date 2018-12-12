#include "FileStream.h"
#include "WinFun.h"
#include "StringFun.h"





 CFileStream::CFileStream()
 {
	
 }


BOOL CFileStream::Load( const CHAR* pFileName )
{
	if(pFileName == NULL)
	{
		printf("Can not open file NULL\n");
		return FALSE;
	}
	string strContent="";
	if(ReadFile(pFileName,strContent))
	{
		return  SerialDataStruct(strContent);
	}
	else
	{
		printf("Can not open file %s\n",pFileName);
	}
	return FALSE;
}

bool CFileStream::MergedFrom( base_serialSeal& rStruct,string const& body ) const
{
	if (IsEmptOrSpace(body))return true;
	
	vector<string> subrules;

	vector<string> rules;
	rules.push_back(" ");
	rules.push_back("=");
	AnalyRule(subrules,body,rules);
	if (subrules.size() != 4)
	{
		return false;
	}
	rStruct.m_headType = subrules[0];
	rStruct.m_Keys = subrules[1];
	rStruct.m_name = subrules[2];
	rStruct.m_index = subrules[3];
	
	return true;
}

bool CFileStream::SerialDataStruct( string const& strContent ,Protocol_Class_body_T* pList)
{
	string lines="";
	string::size_type nPos =0;
	string namespaces="";
	string descript ="";
	string sysvariable="";
	string classFileName;
	while(GetLines(strContent,lines,nPos))
	{
		Replace(lines,"\t"," ");
		DimLeft(lines);
		if(lines.find("//#")!=STRINGEND)
		{
			descript = lines;
			Replace(descript,"//#");
			Replace(descript,"\r");
			Replace(descript,"\n");
		}
		else if (lines.find("//@")!=STRINGEND)
		{
			sysvariable =  lines;
			Replace(sysvariable,"//@");
			Replace(sysvariable,"\r");
			Replace(sysvariable,"\n");
		}
		RemoveLeft(lines,"//");
		if (lines.empty() || lines.length()<=2)continue;

		if (lines.find(H_OPTION) != string::npos)
		{
			 if (lines.find("_package") != string::npos)
			 {
				 string::size_type ntmpPos =0; 
				 GetRuleString(lines,namespaces,ntmpPos,"\"","\"");
				 Trim(namespaces);		
				 Replace(namespaces,"\r");
				 Replace(namespaces,"\n");
			 }
			 else if (lines.find("_outer_classname") != string::npos)
			 {
				 string::size_type ntmpPos =0; 
				 GetRuleString(lines,classFileName,ntmpPos,"\"","\"");
				 Trim(classFileName);		
				 Replace(classFileName,"\r");
				 Replace(classFileName,"\n");
			 }
			
			continue;
		}
		else if (lines.find("package") != string::npos)
		{
			string results = lines;
			Replace(results,"package");
			Replace(results," ");
			Replace(results,";");
			Replace(results,"\r");
			Replace(results,"\n");
			namespaces= results;
			continue;
		}
		else if (lines.find("outer_classname") != string::npos)
		{
			string results = lines;
			Replace(results,"package");
			Replace(results," ");
			Replace(results,";");
			Replace(results,"\r");
			Replace(results,"\n");
			namespaces= results;
			continue;
		}
		else if (lines.find(H_MESSAGE) != string::npos)
		{
			string bodyclass ="";
			string keytmps = lines;
			string keys;
			Replace(keytmps,H_MESSAGE);
			Trim(keytmps);
			for(int k=0;k<keytmps.length();++k)
			{
				if(keytmps[k] ==' ' || keytmps[k] == '{')break;
				keys.push_back(keytmps[k]);
			}
			string::size_type nDes = lines.find(keys);
			if(nDes!=STRINGEND)
			{
				int last = lines.length() -(nDes + keys.length()-1);
				if(last>0)
				{
					nPos -= last;
				}
			}
			Trim(keys);
			Protocol_Class_body_T bodys;
			if(GetRuleString(strContent,bodyclass,nPos,"{","}"))
			{
				SerialDataStruct(bodyclass,&bodys);
			}
			else
			{
				string errLog ="Analy message body Error:not equal {} at ";
				errLog  += lines;
				AssertEx(false,errLog.c_str());
				return false;
			}
			m_Data[base_protocol_T(keys,namespaces,descript,sysvariable)]  = bodys;
			descript ="";
			sysvariable ="";
			continue;
		}
		else if (pList!=NULL)
		{
				Protocol_Class_body_T& bodys = *pList;
				base_serialSeal singles ;
				vector<string> rules;
				AnalyRule(rules,lines,";");
				for (vector<string>::const_iterator it = rules.begin();it != rules.end();++it)
				{
					singles.Clear();
					if(MergedFrom(singles,*it))
					{
						if(singles.Isvalid())bodys.push_back(singles);
					}
					else
					{
						string errLog ="Analy message body inner Error:not equal {} at ";
						errLog  += lines;
						AssertEx(false,errLog.c_str());
						return false;
					}
				}
		}	
	}
	if(!classFileName.empty()){
		m_classFileName = classFileName;
	}
	return true;
}


