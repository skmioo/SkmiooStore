#include "stdafx.h"
#include "WinFun.h"
#include "BaseDef.h"
#include "StrFun.h"
#include "StringFun.h"
#pragma  warning(disable:4996)
using namespace std;
#if defined(__WINDOWS__)

bool isDirectory(char const *pszDestPath)
{
	WIN32_FIND_DATA  wfd;
	bool rValue = false;
	HANDLE hFind = FindFirstFile(pszDestPath, &wfd);
	if ((hFind != INVALID_HANDLE_VALUE) && (wfd.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY))
	{
		rValue = true;   
	}
	FindClose(hFind);
	return rValue;

}


std::string Rename( std::string const& filePathName ,std::string const& newName  )
{
	   std::string dtr = filePathName;
		if(newName.empty())
		{
			return filePathName;
		}
		Trim(dtr);
		if(dtr.empty())return FALSE;
		Replace(dtr,"\\","/",dtr.length());


		STRINGTYPE nPos = dtr.find_last_of("/");
		if(nPos == STRINGEND)return filePathName;

		return dtr.substr(0,nPos+1) + newName;

}

 int EnmuDirectory(char const *pszDestPath,std::set<STRING>& myList,std::set<STRING>& myVisitedList,CHAR const* pTial/*=NULL*/)
{	//此结构说明参MSDN;
	WIN32_FIND_DATA FindFileData;
	//查找文件的句柄;
	HANDLE hListFile;
	//绝对路径，例：c:\windows\system32\cmd.exe;
	char szFullPath[MAX_PATH];
	//相对路径;
	char szFilePath[MAX_PATH];
	//构造相对路径;
	sprintf(szFilePath, "%s\\*", pszDestPath);
	//查找第一个文件，获得查找句柄，如果FindFirstFile返回INVALID_HANDLE_VALUE则返回;
	if((hListFile = FindFirstFile(szFilePath, &FindFileData)) == INVALID_HANDLE_VALUE)
	{
		//查找文件错误;
		return 1;
	}
	else
	{
		do 
		{
			//过滤.和..;
			//“.”代表本级目录“..”代表父级目录;
			if( lstrcmp(FindFileData.cFileName, TEXT(".")) == 0 ||
				lstrcmp(FindFileData.cFileName, TEXT("..")) == 0 )
			{
				continue;
			}
			//构造全路径;
			sprintf(szFullPath, "%s\\%s", pszDestPath, FindFileData.cFileName);
			//读取文件属性，如果不是文件夹;
			if(!(FindFileData.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY))
			{	
				STRING resultss =szFullPath;
				if (pTial != NULL)
				{
					  STRINGTYPE npos = resultss.find_last_of(".");
					  STRING strTail = resultss;
					  if (npos != STRINGEND)
					  {
						  strTail = resultss.substr(npos);
					  }
						MyToLower(strTail);
						STRING sourceTail = pTial;
						MyToLower(sourceTail);
						if (strTail ==sourceTail  )
						{
							if (myVisitedList.find(resultss) == myVisitedList.end())
							{
								myList.insert(resultss);
							}	
						}
				
					
				}
				else
				{
					if (myVisitedList.find(resultss) == myVisitedList.end())
					{
						myList.insert(resultss);
					}	
				}
			}


			//如果是文件夹，则递归调用EnmuDirectory函数;
			if(FindFileData.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY)
			{
				EnmuDirectory(szFullPath,myList,myVisitedList,pTial);
			}
			//循环，查找下一个文件;
		}while(FindNextFile(hListFile, &FindFileData));
	}
	//关闭句柄;
	FindClose(hListFile);
	return 0;
}

 BOOL TryCreateDirectory(STRING dtr)
 {
	 //先取得
	 Trim(dtr);
	 if(dtr.empty())return FALSE;
	 Replace(dtr,"\\","/",dtr.length());

	 if(dtr[dtr.length()-1] == '/')
	 {
		 return WriteDirectory(dtr);
	 }

	 STRINGTYPE nPos = dtr.find_last_of("/");
	 if(nPos == STRINGEND)return FALSE;

	 return WriteDirectory(dtr.substr(0,nPos));

 }


 BOOL   WriteDirectory(STRING   dd) 
 { 
	 HANDLE fFile; 
	 WIN32_FIND_DATA   fileinfo; 
	 std::vector<STRING>   m_arr; 
	 BOOL   tt; 
	 int   x1   =   0; 
	 STRING   tem   =  ""; 

	 //将相对路径转换为绝对路径
	 if(dd.length()<=2)return false;

	 //./../
	 if(dd[0] == '.')
	 {
		 CHAR bufferPath[1024]={0};
		getcwd(bufferPath,1024);

		vector<STRING> workList;
		AnalyRule(workList,bufferPath,"\\");
		vector<STRING> myList;
		vector<STRING> ruleList;
		ruleList.push_back("\\");
		ruleList.push_back("/");
		AnalyRule(myList,dd,ruleList);
		
		int nBegin =0;
		int nEnd =workList.size();
		for (vector<STRING>::iterator it = myList.begin();it != myList.end();++it)
		{
			STRING ss = *it;
			if(ss.length()==1 && ss[0]=='.')
			{
				//当前目录
				++nBegin;
			}
			else if(ss.length()==2 && ss[0]=='.' && ss[1]=='.')
			{
				--nEnd;
			}
			else
			{
				break;
			}
		}
		dd="";
		 for(int i=0;i<nEnd;++i)
		 {
			 dd += workList[i];
			 dd += "/";
		 }
		 for(int i=nBegin;i<myList.size();++i)
		 {
			 dd += myList[i];
			 dd += "/";
		 }
	 }

	


	 fFile   =   FindFirstFile(dd.c_str(),&fileinfo); 
	 //   if   the   file   exists   and   it   is   a   directory 
	 if(fileinfo.dwFileAttributes   ==   FILE_ATTRIBUTE_DIRECTORY) 
	 { 
		 //     Directory   Exists   close   file   and   return 
		 FindClose(fFile); 
		 return   TRUE; 
	 } 
	 m_arr.clear(); 
	 for(x1   =   0;   x1   <   dd.length();   x1++   ) 
	 { 
		 CHAR ch = dd[x1];
		 if(ch != '\\' && ch != '/') 
			 tem   +=   dd[x1];
		 else 
		 { 
			 m_arr.push_back(tem); 
			 tem   +=   "/"; 
		 } 
		 if(x1   ==   dd.length()-1) 
			 m_arr.push_back(tem); 
	 } 


	 //   Close   the   file 
	 FindClose(fFile); 


	 //   Now   lets   cycle   through   the   String   Array   and   create   each   directory   in   turn 
	 for(x1   =   1;   x1   <   m_arr.size();   x1++) 
	 { 
		 tem   =   m_arr[x1]; 
		 tt   =   ::CreateDirectory(tem.c_str(),NULL); 

		 //   If   the   Directory   exists   it   will   return   a   false 
		 if(tt) 
			 SetFileAttributes(tem.c_str(),FILE_ATTRIBUTE_NORMAL); 
		 //   If   we   were   successful   we   set   the   attributes   to   normal 
	 } 
	 //     Now   lets   see   if   the   directory   was   successfully   created 
	 fFile   =   FindFirstFile(dd.c_str(),&fileinfo); 

	 m_arr.clear(); 
	 if(fileinfo.dwFileAttributes   ==   FILE_ATTRIBUTE_DIRECTORY) 
	 { 
		 //     Directory   Exists   close   file   and   return 
		 FindClose(fFile); 
		 return   TRUE; 
	 } 
	 else 
	 { 
		 //   For   Some   reason   the   Function   Failed     Return   FALSE 
		 FindClose(fFile); 
		 return   FALSE; 
	 } 
 } 

std::string RecovertMyFile(std::string const& section)
 {
#if defined(__LINUX__)
	 return section;
#else
	 string filePath;
	 CHAR buf[1024]={0};
	 ::GetModuleFileNameA(NULL, buf, 1024);
	 INT nLast =0;
	 for (INT i=strlen(buf)-1;i>0;i--)
	 {
		 if (buf[i] == '\\')
		 {
			 nLast =i;
			 break;
		 }
	 }
	 for (INT i =0;i< nLast;i++)
	 {
		 filePath.append(1,buf[i]);
	 }
	 string files ;
	 if (section.substr(0,2) == "./") //当前路径
	 {
		 files = filePath + "\\"+section.substr(2,section.length());

	 }
	 else
		 if (section.substr(0,3) == "../")//上一级目录
		 {
			 INT k =filePath.find_last_of('\\');
			 files = filePath.substr(0,k) + "\\"+section.substr(3,section.length());
		 }
		 for (size_t i=0;i< files.length()-1;i++)
		 {
			 if (files[i] == '/')
			 {
				 files[i] ='\\';				
			 }			
		 }
		 return files;

#endif
 }


void bcopy( const void *src, void *dest, int n )
{
	 if (src == NULL || dest == NULL)
	 {
		 return;
	 }
	 char* p1 = (char*)src;
	 char* p2 = (char*)dest;

	 for (int i=0;i<n;++i)
	 {
		 if (p1 == NULL)
		 {
			 ++p2;
			 p2=NULL;
			 return;
		 }
		 *p2 = *p1;
		 ++p1;
		 ++p2;
	 }
}



 extern void mySleep(int minsec)
 {
#if defined(__WINDOWS__)
	 Sleep(minsec);
 #elif defined(__LINUX__)
	 usleep(minsec);
#endif
 }

 extern unsigned long int pthread_self()
 {
	return GetCurrentThreadId();

 }

 int strncasecmp( const char *s1, const char *s2, size_t n )
 {
	 const char* p1 = s1;
	 const char* p2 = s2;
	 int i=0;
	 char c1 = *p1;
	 char c2 = *p2;
	 int len = 'a' - 'A';
	 for (;i<n;++i)
	 {
		 if (NULL == p1 && p2 != NULL)
		 {
			 return -1;
		 }
		 if (NULL == p2 && p1 != NULL)
		 {
			 return 1;
		 }
		 if(p1 == NULL && p2 == NULL)
		 {
			 return 0;
		 }
		 c1 = *p1;
		 c2 = *p2;
		 if((c1>='a'&&c1<='z' || c1>='A'&&c1<='Z')&&(c2>='a'&&c2<='z' || c2>='A'&&c2<='Z'))
		 {

			 if(c1 == c2 || c1 == c2+len || c1 == c2-len)
			 {
				 ++p1;
				 ++p2;
				 continue;
			 }
		 }
		 else if (c1 > c2)
		 {
			 return 1;
		 }
		 else if(c1 < c2)
		 {
			 return -1;
		 }

		 ++p1;
		 ++p2;
	 }
	 return 0;
 }

 extern int strcasecmp( const char *s1, const char *s )
 {
	 if (s1 == NULL && s == NULL)
	 {
		 return 0;
	 }
	 if (s1 == NULL)
	 {
		 return -1;
	 }
	 return strncasecmp(s1,s,strlen(s1));
 }

 BOOL	CheckExitFile()
 {
	 if( remove( "exit.cmd" ) == -1 )
	 {
		 return FALSE;
	 }	
	 return TRUE;	
 }


 CHAR		Value2Ascii(CHAR in)
 {
	 __ENTER_FUNCTION
		 switch(in) 
	 {
		 case 0:
			 return '0';
			 break;
		 case 1:
			 return '1';
		 case 2:
			 return '2';
			 break;
		 case 3:
			 return '3';
			 break;
		 case 4:
			 return '4';
			 break;
		 case 5:
			 return '5';
			 break;
		 case 6:
			 return '6';
			 break;
		 case 7:
			 return '7';
			 break;
		 case 8:
			 return '8';
			 break;
		 case 9:
			 return '9';
			 break;
		 case 10:
			 return 'A';
			 break;
		 case 11:
			 return 'B';
			 break;
		 case 12:
			 return 'C';
			 break;
		 case 13:
			 return 'D';
			 break;
		 case 14:
			 return 'E';
			 break;
		 case 15:
			 return 'F';
			 break;
		 default:			
			 return '?';
			 break;
	 }

	 __LEAVE_FUNCTION

		 return '?';
 }

 CHAR Ascii2Value(CHAR in)
 {
	 __ENTER_FUNCTION
		 switch(in) 
	 {
		 case '0':
			 return 0;
			 break;
		 case '1':
			 return 1;
		 case '2':
			 return 2;
			 break;
		 case '3':
			 return 3;
			 break;
		 case '4':
			 return 4;
			 break;
		 case '5':
			 return 5;
			 break;
		 case '6':
			 return 6;
			 break;
		 case '7':
			 return 7;
			 break;
		 case '8':
			 return 8;
			 break;
		 case '9':
			 return 9;
			 break;
		 case 'A':
			 return 10;
			 break;
		 case 'B':
			 return 11;
			 break;
		 case 'C':
			 return 12;
			 break;
		 case 'D':
			 return 13;
			 break;
		 case 'E':
			 return 14;
			 break;
		 case 'F':
			 return 15;
			 break;
		 default:			
			 return '?';
			 break;
	 }

	 __LEAVE_FUNCTION

		 return '?';
 }


 BOOL	Binary2String(const CHAR* pIn,UINT InLength,CHAR* pOut)
 {
	 __ENTER_FUNCTION

		 if(InLength==0)
		 {
			 return FALSE;
		 }
		 UINT iOut = 0;


		 for(UINT i = 0 ;i<InLength;i++)
		 {

			 pOut[iOut] = Value2Ascii(((unsigned char)pIn[i]&0xF0)>>4);
			 iOut++;
			 pOut[iOut] = Value2Ascii(pIn[i]&0x0F);
			 iOut++;


		 }
		 return TRUE;

		 __LEAVE_FUNCTION

			 return FALSE;
 }


 BOOL DBStr2Binary(const CHAR* pIn,UINT InLength,CHAR* pOut,UINT OutLimit,UINT& OutLength)
 {
	 __ENTER_FUNCTION

		 if(InLength==0)
		 {
			 return FALSE;
		 }

		 UINT iOut = 0;
		 UINT i;
		 for( i = 0 ;i<InLength-1;)
		 {
			 if(pIn[i]=='\0'||pIn[i+1]=='\0')
			 {
				 break;
			 }

			 pOut[iOut]	=	(Ascii2Value(pIn[i])<<4) + Ascii2Value(pIn[i+1]);
			 iOut++;
			 i+=2;
			 if(iOut>=OutLimit)
				 break;
		 }
		 OutLength = iOut;
		 return TRUE;
		 __LEAVE_FUNCTION
			 return FALSE;
 }


 //采用Quake3的strncpy函数
 VOID Q_strncpyz( CHAR *dest, const CHAR *src, INT destsize ) 
 {
	 __ENTER_FUNCTION

		 if ( !src ) {			
			 return;
		 }
		 if ( destsize < 1 ) {			
			 return;
		 }

		 strncpy( dest, src, destsize-1 );
		 dest[destsize-1] = 0;

		 __LEAVE_FUNCTION
 }

void ReadFileSamll( std::string const& file ,std::string& rContent  )
 {
	 __ENTER_FUNCTION
	 FILE* f = fopen( file.c_str(), "rb" ) ;
	 if( f )
	 {
		 unsigned long filesize = -1;  
		 try
		 {

			 fseek(f, 0L, SEEK_END);
			 filesize = ftell(f);  
			 fseek(f, 0L, SEEK_SET);
			 if(filesize>0)
			 {
				 CHAR *szBuff = new CHAR[filesize+1];
				// AssertEx(szBuff,"Not Enough Memory");
				 memset(szBuff,0,sizeof(CHAR)*(filesize+1));
				 fread( szBuff, 1, sizeof(CHAR)*(filesize+1), f ) ;
				rContent = szBuff;
				 SAFE_DELETE_ARRAY(szBuff);
				 fclose(f) ;			
			 }
		 }
		catch(...)
		 {
		 }
		 fclose(f) ;
	 }
	 else
	 {
		//////////////////////////////////////////////////////////////////////////
	 }
	 __LEAVE_FUNCTION
	
 }

bool WriteFile( CHAR const* sFile,CHAR const* pContent,WRITE_TYPE _ID/*=OVERFLOW_WRITE*/ )
{
try{
	if (sFile == NULL || pContent==NULL )
	{
		return false;
	}
	FILE* f = NULL;
	if (_ID == APPEND_WRITE)
	{
		f = fopen( sFile, "a+" ) ;		
	}
	else
	{
		 f = fopen( sFile, "w" ) ;		
	}
	if( f )
	{ 			
		fwrite( pContent, 1, strlen(pContent), f ) ;			
	}
	fclose(f);
}
catch(...){}
		return false;
}

void MyToLower( STRING& str )
{
	STRING __temp;
	int len = 'a' - 'A';
	for (STRING::size_type i =0;i<str.length();++i)
	{
		char ch = str[i];
		if (ch >='A' && ch <= 'Z')
		{
			__temp.push_back(ch+len);
			continue;
		}
		__temp.push_back(ch);
	}
	str = __temp;
}

std::string GetShellScriptFullPath( CHAR const* pfile /*= NULL*/ )
{
	std::string fullpath;
	char pFileName[MAX_PATH]={0}; 
	int nPos = GetCurrentDirectory( MAX_PATH, pFileName); 
	if (nPos <0)
	{
		return "";
	}
	fullpath = pFileName;
	fullpath += "/Shell/";
	if (NULL != pfile)
	{
		fullpath += pfile;
	}

	return fullpath;
}

bool ReadFile( std::string const& fileName,std::string& content )
{
	//打开文件
	FILE* fp = fopen(fileName.c_str(), "rb");
	if(NULL == fp) return FALSE;

	fseek(fp, 0, SEEK_END);
	int nFileSize = ftell(fp);
	fseek(fp, 0, SEEK_SET);

	//读入内存
	char* pMemory = new char[nFileSize+1];
	fread(pMemory, 1, nFileSize, fp);
	pMemory[nFileSize] = 0;

	content = pMemory;

	SAFE_DELETE_ARRAY(pMemory); 
	pMemory = 0;
	return TRUE;
}
#ifndef _DLL_TDENGIN_
int SerachFileFromDirectory( char const *pszDestPath,std::set<STRING>& myList,CHAR const* pTial )
#else
#include "TEngineCode.h"
TABLEENGINECODE_API int SerachFileFromDirectory( char const *pszDestPath,std::set<STRING>& myList,CHAR const* pTial )
#endif
{
	//此结构说明参MSDN;
	WIN32_FIND_DATA FindFileData;
	//查找文件的句柄;
	HANDLE hListFile;
	//绝对路径，例：c:\windows\system32\cmd.exe;
	char szFullPath[MAX_PATH];
	//相对路径;
	char szFilePath[MAX_PATH];
	//构造相对路径;
	sprintf(szFilePath, "%s\\*", pszDestPath);
	//查找第一个文件，获得查找句柄，如果FindFirstFile返回INVALID_HANDLE_VALUE则返回;
	if((hListFile = FindFirstFile(szFilePath, &FindFileData)) == INVALID_HANDLE_VALUE)
	{
		//查找文件错误;
		return -1;
	}
	else
	{
		do 
		{
			//过滤.和..;
			//“.”代表本级目录“..”代表父级目录;
			if( lstrcmp(FindFileData.cFileName, TEXT(".")) == 0 ||
				lstrcmp(FindFileData.cFileName, TEXT("..")) == 0 )
			{
				continue;
			}
			//构造全路径;
			sprintf(szFullPath, "%s\\%s", pszDestPath, FindFileData.cFileName);
			//读取文件属性，如果不是文件夹;
			if(!(FindFileData.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY))
			{	
				STRING resultss =szFullPath;
				if (pTial != NULL)
				{
					STRINGTYPE npos = resultss.find_last_of(".");
					STRING strTail = resultss;
					if (npos != STRINGEND)
					{
						strTail = resultss.substr(npos);
					}
					MyToLower(strTail);
					STRING sourceTail = pTial;
					MyToLower(sourceTail);
					if (strTail ==sourceTail  )
					{						
							myList.insert(resultss);					
					}


				}
				else
				{					
						myList.insert(resultss);					
				}
			}


			//如果是文件夹，则递归调用EnmuDirectory函数;
			if(FindFileData.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY)
			{
				SerachFileFromDirectory(szFullPath,myList,pTial);
			}
			//循环，查找下一个文件;
		}while(FindNextFile(hListFile, &FindFileData));
	}
	//关闭句柄;
	FindClose(hListFile);
	return myList.size();
}









#endif