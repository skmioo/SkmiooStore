#ifndef _WIN_FUN__H__
#define _WIN_FUN__H__
#include "BaseDef.h"


#if defined(__WINDOWS__)
#define  __STD_ETX_THREAD  unsigned __stdcall 
#include <process.h>
#include <set>
#include <string>
//　函数说明：strncasecmp()用来比较参数s1和s2字符串前n个字符，比较时会自动忽略大小写的差异
//    返回值 ：若参数s1和s2字符串相同则返回0 s1若大于s2则返回大于0的值 s1若小于s2则返回小于0的值 
#ifdef __cplusplus
extern "C"
{
#endif
extern int strncasecmp(const char *s1, const char *s2, size_t n);

extern int strcasecmp(const char *s1, const char *s);

#ifdef __cplusplus
}
#endif

//功能：将字符串src的前n个字节复制到dest中 　　
//说明：bcopy不检查字符串中的空字节NULL，函数没有返回值
extern void bcopy(const void *src, void *dest, int n);

extern std::string RecovertMyFile(std::string const& section);

extern void ReadFileSamll( std::string const& file ,std::string& rContent  );

extern  int EnmuDirectory(char const *pszDestPath,std::set<STRING>& myList,std::set<STRING>& myVisitedList,CHAR const* pTial);

//判断文件是否是目录
extern  bool isDirectory(char const *pszDestPath);

//对文件重新命名
extern std::string Rename( std::string const& filePathName ,std::string const& newName  );

//分割文件路径和文件名称


//获取一个目录下所有指定格式的文件，返回文件的个数
#ifndef _DLL_TDENGIN_
extern int SerachFileFromDirectory(char const *pszDestPath,std::set<STRING>& myList,CHAR const* pTial);
#endif

//获得线程自身的ID。pthread_t的类型为unsigned long int，所以在打印的时候要使用%lu方式，否则将产生奇怪的结果
extern unsigned long int pthread_self();

#define O_NONBLOCK 1
#define  F_SETFL 0

#elif defined(__LINUX__)
#define  __STD_ETX_THREAD  void* 
#endif

extern void mySleep(int minsec);
 extern BOOL	CheckExitFile();
 CHAR		Value2Ascii(CHAR in);
 CHAR		Ascii2Value(CHAR in);

 BOOL		Binary2String(const CHAR* pIn,UINT InLength,CHAR* pOut);
 BOOL		DBStr2Binary(const CHAR* pIn,UINT InLength,CHAR* pOut,UINT OutLimit,UINT& OutLength);


 //采用Quake3的strncpy函数
 VOID Q_strncpyz( CHAR *dest, const CHAR *src, INT destsize ) ;

 //写入一个文件函数
 enum WRITE_TYPE
 {
	 OVERFLOW_WRITE=0,
	 APPEND_WRITE,
 };
 bool  WriteFile(CHAR const* FileName,CHAR const* pContent,WRITE_TYPE _ID=OVERFLOW_WRITE);
bool    ReadFile(std::string const& fileName,std::string& content);

BOOL   WriteDirectory(STRING   dd) ;

BOOL TryCreateDirectory(STRING dtr);

 void MyToLower(STRING& str);

 //获取当前运行的完整的目录
 //Input 传入的文件名，如果传入文件名，将检查文件是否存在，如果不存在直接返回空
 std::string GetShellScriptFullPath(CHAR const* pfileName = NULL);

 
 
#endif