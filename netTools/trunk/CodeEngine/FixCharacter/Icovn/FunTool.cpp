#include "FunTool.h"
#include <Windows.h>

int SerachFileFromDirectory( char const *pszDestPath,std::set<STRING>& myList,CHAR const* pTial )
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



CHAR*    MyReadFile(std::string const& file,size_t& len)
{
	
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
				memset(szBuff,0,sizeof(CHAR)*(filesize+1));
				fread( szBuff, 1, sizeof(CHAR)*(filesize+1), f ) ;				
				fclose(f) ;		
				len = filesize;
				return szBuff;
			}
		}
		catch(...)
		{
		}
		fclose(f) ;
	}
	else
	{
		return NULL;
	}
	return NULL;
}

bool MyWriteFile( CHAR const* sFile,CHAR const* pContent,WRITE_TYPE _ID/*=OVERFLOW_WRITE*/ )
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
