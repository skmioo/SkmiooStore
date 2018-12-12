
#include "StrFun.h"
#include "StringFun.h"
#pragma  warning(disable:4244)
#pragma  warning(disable:4018)

void Replace( string &str,const char* psor,const char* pdest )
{
	if (NULL == psor)
	{
		return;
	}
	string newsstr="";
	string::size_type pos= str.find(psor);
	string::size_type startpos=0;
	if (pos ==string::npos )
	{
		return;
	}
	while(pos!=string::npos)
	{
		newsstr += str.substr(startpos,pos-startpos);
		if(pdest)
		{
			string tmp =pdest;
			newsstr += tmp;
		}
		startpos = pos + strlen(psor);
		pos = str.find(psor,startpos);
		if (pos==string::npos)
		{
			newsstr += str.substr(startpos);
		}
	}
	str = newsstr;
}

 string RraseTailNumber(const string &str)
{
	if (str.empty())return "";
		
	SIZE_STRING nPos =str.length();
	for (;nPos>0;--nPos)
	{
		char ch = str[nPos-1];
		if (ch == ' ' || ch == '\t' || (ch >='0' && ch <='9'))
		{
			continue;
		}
		else
		{
			break;
		}
	}
	if (nPos == 0 || nPos == str.length()) return str;
	
	return str.substr(0,nPos);
}
 void ReplaceRule(string &str,const char* psor)
 {
	 if (NULL == psor)
	 {
		  str = __B(str);
		 return;
	 }
	 string newsstr="";
	 string::size_type pos= str.find(psor);
	 string::size_type startpos=0;
	 if (pos ==string::npos )
	 {
		 str = __B(str);
		 return;
	 }
	 while(pos!=string::npos)
	 {
		 newsstr += str.substr(startpos,pos-startpos);		 
		 startpos = pos + strlen(psor);

		 while(startpos < str.length() && (str[startpos] == ' ' || str[startpos] == '\t'))++startpos;

		 if (startpos < str.length())
		 {
			 newsstr += __B(str[startpos]);
			 ++startpos;
			 pos = str.find(psor,startpos);
			 if (pos==string::npos)
			 {
				 newsstr += str.substr(startpos);
			 }
		 }
		 else
		 {
			 break;
		 }
		
	 }
	newsstr =  __B(newsstr);
	 str = newsstr;
 }

void Replace( string &str,string const& oldS,string const& newS,int len )
{
	if (len<=0 || str.empty())return;
	
	string temp ;
	string::size_type currentpos =0;
	
	while(currentpos < len && currentpos < str.length())
	{
		string::size_type pos = str.find(oldS,currentpos);
		if (pos != string::npos)
		{
			 temp += str.substr(currentpos,pos-currentpos);
			  temp +=newS;
			 currentpos = pos + oldS.length();
		}
		else
		{
			break;
		}
	}
	temp += str.substr(currentpos);
	str = temp;
}

std::string Left(string const& str, string::size_type len)
{
	if (str.empty() || len <=0 || string::npos == len)return "";
	if (len > str.length())
	{
		return str;
	}

	string temp;	
	for (int i=0;i<len;++i)
	{
		temp.push_back(str[i]);
	}
	return temp;
}

std::string Right( string const& str , string::size_type len)
{
	if (str.empty() || len <=0  || string::npos == len)return "";
	if (len > str.length())
	{
		return str;
	}

	string temp;	
	for (int i=len+1;i<str.length();++i)
	{
		temp.push_back(str[i]);
	}
	return temp;
}

void SkipDesc( string &str,const char* psor )
{
	if (NULL == psor)
	{
		return;
	}
	string newsstr="";
	string::size_type pos= str.find(psor);
	if (pos ==string::npos )
	{
		return;
	}
	newsstr= str.substr(0,pos);
	str = newsstr;
}


bool HaveEn_us_String( string const& str )
{
	for (string::size_type i =0;i<str.length();++i)
	{
		char h = str[i];
		if ( ((h>='a')&&(h<='z')) ||  ((h>='A')&&(h<='Z')))
		{
			return true;
		}
	}
	return false;
}

void ToAllEn_us_ToLow( string const& str,string& result )
{
	int diff = 'a' -'A';
	for (string::size_type i =0;i<str.length();++i)
	{
		char h = str[i];
		if ( ((h>='A')&&(h<='Z')))
		{
			result.push_back(h+diff);
		}
		else
		{
			result.push_back(h);
		}
	}
}
//发布时间:@{1}下载人数@{2}人@{3} @{4}排名：@{5}价格：@{6}
void AnalyRule( RULE_MAP_T& ruleList,string const& rContent,char const* pReg )
{
	if (rContent.empty() || NULL==pReg)
	{
		return;
	}
	typedef string::size_type SIZE_STRING;
	SIZE_STRING Curpos =0;
	string kes,valus;
	while(1)
	{
		SIZE_STRING pos = rContent.find(pReg,Curpos);
		if (pos == string::npos) break;
		valus = rContent.substr(Curpos,pos-Curpos);
		kes ="";
		Curpos = pos;
		for (SIZE_STRING i=pos;i<rContent.length();++i,++Curpos)
		{
			kes.push_back(rContent[i]);
			if (rContent[i] == '}')
			{
				++Curpos;
				break;
			}
		}
	
		if (!kes.empty() )
		{
			RealContent_T valuelIst;
			valuelIst.m_Key = valus;				 
			ruleList[kes] = valuelIst;
		}

	}
}

void AnalyRule( vector<string>& ruleList,string const& rContent,char const* pReg )
{
	if (rContent.empty() || NULL==pReg)
	{
		return;
	}
	typedef string::size_type SIZE_STRING;
	SIZE_STRING Curpos =0;
	string valus;
	while(1)
	{
		SIZE_STRING pos = rContent.find(pReg,Curpos);
		if (pos == string::npos) break;
		valus = rContent.substr(Curpos,pos-Curpos);
		Curpos = pos + strlen(pReg);
		ruleList.push_back(valus);
	}
	if(Curpos < rContent.length())
	ruleList.push_back(rContent.substr(Curpos));
}


SIZE_STRING GetMaxPostion(string const& rContent,vector<string> const& vReg,SIZE_STRING nCurPos,string& sub)
{
	if (rContent.empty() || vReg.size()==0)
	{
		return string::npos;
	}
	SIZE_STRING nMax = 0;
	for (vector<string>::const_iterator it =vReg.begin();it != vReg.end();++it)
	{
		SIZE_STRING nPos = rContent.find(*it,nCurPos);
		if (nPos == string::npos)continue;		
		if(nPos>nMax)
		{
			nMax= nPos;
			sub = *it;
		}
	}	
	if (nMax ==0)
	{
		nMax =  string::npos;
	}
	return nMax;
}

bool IsEmptOrSpace( string const& rContent )
{
	if (rContent.empty())return true;

	for(SIZE_STRING i=0;i<rContent.length();++i)
	{
	    
		 if(rContent[i] != ' ' && rContent[i] != '\t' && 
			 rContent[i] != '\n'  && rContent[i] != '\r')
		 {
			 return false;
		 }
	}
	return true;
}

SIZE_STRING GetMinPostion(string const& rContent,vector<string> const& vReg,SIZE_STRING nCurPos,string& sub)
{
	if (rContent.empty() || vReg.size()==0)
	{
		return string::npos;
	}
	SIZE_STRING nMIN =string::npos;
	for (vector<string>::const_iterator it =vReg.begin();it != vReg.end();++it)
	{
		 SIZE_STRING nPos = rContent.find(*it,nCurPos);
		 if (nPos == string::npos)continue;		
		 if(nPos<nMIN)
		 {
			 nMIN= nPos;
			 sub = *it;
		 }
	}	
	return nMIN;
}

void AnalyRule( vector<string>& ruleList,string const& rContent,vector<string> const& vReg )
{
	if (rContent.empty() || vReg.size()==0)
	{
		return;
	}
	
	SIZE_STRING Curpos =0;
	string valus;
	string substr;
		while(1)
		{
			substr.clear();
			SIZE_STRING pos = GetMinPostion(rContent,vReg,Curpos,substr);
			if (pos == string::npos) break;
			if (pos == Curpos)
			{
					Curpos = pos + strlen(substr.c_str());
					continue;
			}
			valus = rContent.substr(Curpos,pos-Curpos);
			Curpos = pos + strlen(substr.c_str());
			if(!valus.empty())ruleList.push_back(valus);
		}
	
	
	if(Curpos < rContent.length())
	{
		string tails = rContent.substr(Curpos);
		if(!tails.empty())ruleList.push_back(tails);
	}
}

void DimLeft( string& str )
{
	if(str.empty())return;
	string::size_type i=0;
	if (str[0] !=' '&& str[0] != '\t')
	{
		return;
	}
	for(;i<str.length();++i)
	{
		if (str[i] ==' ' || str[i] == '\t')
		{
			continue;
		}	
		break;
	}
	if(i == str.length())
	{
		str ="";
		return;
	}
	string tmp = str.substr(i);
	str = tmp;
}


void SpiltString( vector<string>& ListData,string const& rContent,char pReg[],int nSize )
{
	if(rContent.empty())return;
	string tmp ="";
	for (string::size_type i=0;i<rContent.length();++i)
	{
		char ch = rContent[i];
		bool bflag = false;
		for(int i=0;i<nSize;++i)
		{
			if( ch == pReg[i])
			{
				bflag = true;
				break;
			}
		}
		if (bflag)
		{
			if(!tmp.empty())ListData.push_back(tmp);
			tmp.clear();
		}
		else
		{
			tmp.push_back(ch);
		}
	}
	if(!tmp.empty())ListData.push_back(tmp);

}

void SpiltString( vector<string>& ListData,string const& rContent,char pReg )
{
	if(rContent.empty())return;
	string tmp ="";
	for (string::size_type i=0;i<rContent.length();++i)
	{
		char ch = rContent[i];
		if (ch == pReg)
		{
			if(!tmp.empty())ListData.push_back(tmp);
			tmp.clear();
		}
		else
		{
			tmp.push_back(ch);
		}
	}
	if(!tmp.empty())ListData.push_back(tmp);
	
}

string::size_type GetMinePositionString( string const& rContent,char const* pReg,string::size_type nCurrentPos ,int nRule/*=0*/ )
{
	if (rContent.length() <nCurrentPos || pReg == NULL) return string::npos;

	string::size_type nPos =nCurrentPos;
	char const* pHead = pReg;
	if (nRule == 0)
	{
		for (;nPos<rContent.length()&&pHead !=NULL;++nPos)
		{
			char ch = *pHead;
			if (ch == rContent[nPos])
			{
				++pHead;
				if(pHead!=NULL && *pHead == '\0')return nPos;
			}
		}
	}
	else if (nRule == 1)
	{
		for (;nPos>0&&pHead !=NULL;--nPos)
		{
			char ch = *pHead;
			if (ch == rContent[nPos])
			{
				++pHead;
				if(pHead!=NULL && *pHead == '\0')return nPos;
			}
		}
	}

	return string::npos;
}

bool GetLines( string const& rContent,string& rNewStr,string::size_type& nPos,string ch/*='\n'*/ )
{
	 if (rContent.length()<=0 || nPos >= rContent.length())
	 {
		 return false;
	 }
	 string::size_type nFindPos = rContent.find(ch,nPos);
	 if (nFindPos == string::npos || nFindPos>=rContent.length())
	 {
		 rNewStr = rContent.substr(nPos);
		 nPos = string::npos;
		 return true;
	 }
	
	 rNewStr = rContent.substr(nPos,nFindPos-nPos);
	 nPos = nFindPos + ch.length();
	 return true;
}

void Trim( string& str )
{
	
	if (str.length()<=1)
	{
		return;
	}
	__int64 nEnd = (__int64)(str.length()-1);
	if (nEnd==0)
	{
		str ="";
	}
	for (;nEnd>=0;--nEnd)
	{
		if(str[nEnd] != ' ' && str[nEnd] != '\n' && str[nEnd] != '\r')break;
	}
	__int64 i = 0;
	for (;i<=nEnd;++i)
	{
		if(str[i] != ' ' && str[i] != '\n' && str[i] != '\r')break;
	}
	if (i == nEnd)
	{
		str ="";
	}
	else
	{
		str = str.substr(i,nEnd-i+1);
	}
}

std::string ChangeIndexTail( string const& rfile,string const& tail )
{
	if (rfile.empty() || tail.empty())
	{
		return "";
	}
	string::size_type nPos = rfile.find_last_of(".");
	if (nPos == string::npos)
	{
		return rfile+tail;
	}
	string temp =rfile.substr(0,nPos-1);
	temp += tail;
	return temp;
}

void RemoveLeft( string& str,string const& reg )
{
	if (str.empty() || reg.empty())
	{
		return;
	}
	string::size_type nPos = str.find(reg);
	if (nPos == string::npos)
	{
		return;
	}
	str = str.substr(0,nPos);
}

  //根据规则获取一个字符串
  /*
  string const& rContent,  //需要查找的原始字符串
  string::size_type& nCurrentPos, //需要查找的原始字符串开始位置
  string const& strStart,//开始匹配字符
  string const& strEnd,//结束字符
  bool bmoveoffset=true//是否更改开始位置，如果为true则nCurrentPos指向到结束字符的后一个字符位置，如果没有找到nCurrentPos不会改变，返回false
  */
 bool GetRuleString( string const& rContent,std::string& result ,string::size_type& nCurrentPos,string const& strStart,string const& strEnd ,bool bmoveoffset/*=true*/)
{
	if (rContent.empty() || rContent.length()<nCurrentPos || strStart.empty() || strEnd.empty())return false;

	string::size_type nStartPos = rContent.find(strStart,nCurrentPos);
	if(nStartPos == string::npos)return false;
	nStartPos += strStart.length();
	if(nStartPos >=rContent.length()) return false;

	string::size_type nEndPos = rContent.find(strEnd,nStartPos);
	if(nEndPos == string::npos)return false;

	result = rContent.substr(nStartPos,nEndPos-nStartPos);
	if(bmoveoffset)
	{
		nCurrentPos = nEndPos + strEnd.length();
	}
	return true;
}



 std::string StringLink( const char* pSource,const char* pDest,const char* pLinkString/*=NULL*/ )
 {
	 std::string dests;
	 if(pSource ==NULL && pDest == NULL)
	 {
		 dests ="";
	 }
	 if (pDest == NULL)
	 {
		 dests = pSource;		
	 }
	 else if (pSource == NULL)
	 {
		 dests = pDest;
	 }
	 else
	 {
		 dests = pSource;
		 if (pLinkString != NULL)
		 {
			 dests += pLinkString;
		 }
		 dests += pDest;
	 }

	 return dests;
 }

 bool EqualString( string const& rStr,string const& rDest,string const& rskip )
 {
	  string _str = rStr;
	  string _dest =rDest;
	  if(!rskip.empty())
	  {
		  Replace(_str,rskip.c_str());
		   Replace(_dest,rskip.c_str());
	  }
	  return _str == _dest;
 }

 std::string __L( string const& rStr )
 {
	 if (rStr.empty())return "";
	
	 if (rStr[0]>='A'&&rStr[0]<='Z')
	 {
		 string tmp ;
		 tmp.push_back(rStr[0]+'a'-'A');
		 if(rStr.length()>1) tmp += rStr.substr(1);
		 return tmp;
	 }
	 return rStr;
 }

 std::string __B( string const& rStr )
 {
	 if (rStr.empty())return "";

	 if (rStr[0]>='a'&&rStr[0]<='z')
	 {
		 string tmp ;
		 tmp.push_back(rStr[0]-'a'+'A');
		 if(rStr.length()>1)tmp += rStr.substr(1);
		 return tmp;
	 }
	 return rStr;
 }

 std::string __B( char ch )
 {
	  string tmp ="";
	   if (ch>='a'&&ch<='z') tmp.push_back(ch-'a'+'A');
	   else tmp.push_back(ch);
	   return tmp;
 }

 std::string __BB( string const& rStr )
 {
	 if (rStr.empty())return "";

	  string tmp ;
	 for (int i=0;i<rStr.length();++i)
	 {
		 char ch = rStr[i];
		 if (ch>='a'&&ch<='z') tmp.push_back(ch-'a'+'A');
		 else tmp.push_back(ch);	  
	 }
	 return tmp;
 }
  bool SpiltStringAndNumber(const string &str,string& rString,string& number,int nStart)
  {
	  if(str.empty() || nStart>=str.length())return false;
	  rString.clear();
	  number.clear();
	  bool bIsreturn = false;
	  for (string::size_type i=nStart;i<str.length();++i)
	  {
		  char ch = str[i];
		  if(IsCharacter(ch))
		  {
			  if(bIsreturn)return true;
			  rString.push_back(ch);
		  }
		  else if (IsNumber(ch))
		  {
			  bIsreturn =true;
			  number.push_back(ch);
		  }
	  }
	  return bIsreturn;
  }
  bool IsCharacter(char ch)
  {
	  return ((ch>='a'&&ch<='z') ||(ch>='A'&&ch<='Z'));
  }
  bool IsNumber(char ch)
  {
	  return (ch>='0'&&ch<='9');
  }
 string CovertIntToString(int num)
 {
	 char str[32]={0};
	 itoa(num, str, 10); 
	 return str;
 }


