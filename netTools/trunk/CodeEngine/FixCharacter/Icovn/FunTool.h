#pragma once
#include <string>
#include <set>
typedef std::string STRING;
typedef STRING::size_type STRINGTYPE;
#define  STRINGEND STRING::npos

typedef  char CHAR;

//获取一个目录下所有指定格式的文件，返回文件的个数
extern int SerachFileFromDirectory(char const *pszDestPath,std::set<STRING>& myList,CHAR const* pTial);
 void MyToLower(STRING& str);

 //写入一个文件函数
 enum WRITE_TYPE
 {
	 OVERFLOW_WRITE=0,
	 APPEND_WRITE,
 };

extern  bool  MyWriteFile(CHAR const* FileName,CHAR const* pContent,WRITE_TYPE _ID=OVERFLOW_WRITE);
extern CHAR*    MyReadFile(std::string const& file,size_t& len);