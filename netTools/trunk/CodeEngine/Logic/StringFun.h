#ifndef _STRING_FUN__H__
#define _STRING_FUN__H__
#include <string>
#include <map>
#include<list>
#include <vector>

using namespace std;

 void Replace(string &str,const char* psor,const char* pdest=NULL);
  void ReplaceRule(string &str,const char* psor);
  void Replace(string &str,string const& oldS,string const& newS,int len);
 string Left(string const& str,string::size_type len);
 string Right(string const& str,string::size_type len);
 void SkipDesc(string &str,const char* psor);
 bool EqualString(string const& rStr,string const& rDest,string const& rSkip);
 string StringLink(const char* pSource,const char* pDest,const char* pLinkString=NULL);
 string RraseTailNumber(const string &str);
 string __L(string const& rStr);
 string __B(string const& rStr);
 string __BB(string const& rStr);
 string __B(char ch);
 bool SpiltStringAndNumber(const string &str,string& rString,string& number,int nStart=0);
 bool IsCharacter(char ch);
 bool IsNumber(char ch);
 string CovertIntToString(int num);

 struct RealContent_T
 {
	 string m_Key;
	 list<string> m_Content;
 };

 typedef map<string,RealContent_T> RULE_MAP_T;

 //剔除掉字符串的左边的空白字符
 void DimLeft(string& str);
 //基于规则过滤分割 
 void AnalyRule(RULE_MAP_T& ruleList,string const& rContent,char const* pReg);
  void AnalyRule(vector<string>& ruleList,string const& rContent,char const* pReg);
  void AnalyRule(vector<string>& ruleList,string const& rContent,vector<string> const& vReg);

  typedef string::size_type SIZE_STRING;
  //获取规则字符上极值
SIZE_STRING GetMaxPostion(string const& rContent,vector<string> const& vReg,SIZE_STRING nCurPos,string& sub);
SIZE_STRING GetMinPostion(string const& rContent,vector<string> const& vReg,SIZE_STRING nCurPos,string& sub);


//检查一个字符是否是空白符或者是空
bool IsEmptOrSpace(string const& rContent);
  //剔除掉从指定字符串以后的字符
  void RemoveLeft(string& str,string const& reg);

  //根据规则获取一个字符串
  /*
  string const& rContent,  //需要查找的原始字符串
  string::size_type& nCurrentPos, //需要查找的原始字符串开始位置
  string const& strStart,//开始匹配字符
  string const& strEnd,//结束字符
  bool bmoveoffset=true//是否更改开始位置，如果为true则nCurrentPos指向到结束字符的后一个字符位置，如果没有找到nCurrentPos不会改变，返回false
  */
 bool GetRuleString( string const& rContent,std::string& result ,string::size_type& nCurrentPos,string const& strStart,string const& strEnd ,bool bmoveoffset=true);

  //字符串分割函数
  void SpiltString(vector<string>& ListData,string const& rContent,char pReg=' ');
  void SpiltString(vector<string>& ListData,string const& rContent,char pReg[],int nSize);

  //找到一组字符在主字符串的的位置信息
  //最后一个参数0表示往字符串的后面找，1表示往字符串的前面找
  string::size_type GetMinePositionString(string const& rContent,char const* pReg,string::size_type nCurrentPos ,int nRule=0);

  //根据内容来进行词的排序
  void SortByRelationPosition(vector<string>& ListData,string const& rContent);
 bool HaveEn_us_String(string const& str);
 void ToAllEn_us_ToLow(string const& str,string& result);

 //读取一行
 bool	GetLines(string const& rContent,string& rNewStr,string::size_type& nPos,string ch="\n");

 //消除前后的空白符
 void  Trim(string& str);
 //更改文件的后缀名
 string ChangeIndexTail(string const& rfile,string const& tail);
#endif