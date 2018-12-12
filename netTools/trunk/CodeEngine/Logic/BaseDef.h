#ifndef __BASEDEF_H_
#define __BASEDEF_H_
#include <set>
#include <vector>
#include <string>
#include <list>
#include <fstream>
#include "stdafx.h"
#include "Type.h"

#define FILE_SCRIPT "./Script/Script.dat"


#define ENVTEMP "./temp.bat"

#undef INVALID_ID
#define  INVALID_ID -1
#define  AssertEx(x,str){if(x==0){MessageBox(NULL,str,"error",MB_OK);}}

#ifndef  STRING
#define STRING std::string
#define  STRINGEND STRING::npos
typedef  std::string::size_type STRINGTYPE ;
#endif

#ifndef __ENTERFUNCTION

#define __ENTERFUNCTION  try{
#define __LEAVEFUNCTION }catch(...){}

#endif

#ifndef __ENTER_FUNCTION
#define __ENTER_FUNCTION  try{
#define __LEAVE_FUNCTION  }catch(...){}

#endif

#define  _MY_TRY try{
#define  _MY_CATCH  }catch(...){}
//根据指针值删除内存
#ifndef SAFE_DELETE
#if defined(__WINDOWS__)
#define SAFE_DELETE(x)	if( (x)!=NULL ) {delete (x); (x)=NULL; }
#elif defined(__LINUX__)
#define SAFE_DELETE(x)	if( (x)!=NULL ) { delete (x); (x)=NULL; }
#endif
#endif
//根据指针值删除数组类型内存
#ifndef SAFE_DELETE_ARRAY
#if defined(__WINDOWS__)
#define SAFE_DELETE_ARRAY(x)	if( (x)!=NULL ) {delete[] (x); (x)=NULL; }
#elif defined(__LINUX__)
#define SAFE_DELETE_ARRAY(x)	if( (x)!=NULL ) { delete[] (x); (x)=NULL; }
#endif
#endif

//删除指针型数据(应尽量使用SAFE_DELETE_ARRAY)
#ifndef DELETE_ARRAY
#if defined(__WINDOWS__)
#define DELETE_ARRAY(x)	if( (x)!=NULL ) { delete[] (x); (x)=NULL; }
#elif defined(__LINUX__)
#define DELETE_ARRAY(x)	if( (x)!=NULL ) { delete[] (x); (x)=NULL; }
#endif
#endif
//根据指针调用free接口
#ifndef SAFE_FREE
#define SAFE_FREE(x)	if( (x)!=NULL ) { free(x); (x)=NULL; }
#endif
//根据指针调用Release接口
#ifndef SAFE_RELEASE
#define SAFE_RELEASE(x)	if( (x)!=NULL ) { (x)->Release(); (x)=NULL; }
#endif


#if defined(__WINDOWS__)
#define		tvsnprintf		_vsnprintf
#define		tstricmp		_stricmp
#define		tsnprintf		_snprintf
#elif defined(__LINUX__)
#define		tvsnprintf		vsnprintf
#define		tstricmp		strcasecmp
#define		tsnprintf		snprintf
#endif

#define  ScriptID_t INT



#define  MyMessageBox(x){MessageBox(NULL,x,"info",MB_OK);}
#define  Assert(x) NULL

#ifndef _DEBUG
#define  assert(x) 
#endif



//共享锁
#if defined(__WINDOWS__)
class MyLock
{
	CRITICAL_SECTION m_Lock ;
public :
	MyLock( ){ InitializeCriticalSection(&m_Lock); } ;
	~MyLock( ){ DeleteCriticalSection(&m_Lock); } ;
	VOID	Lock( ){ EnterCriticalSection(&m_Lock); } ;
	VOID	Unlock( ){ LeaveCriticalSection(&m_Lock); } ;
};
#elif defined(__LINUX__)
class MyLock
{
	pthread_mutex_t 	m_Mutex; 
public :
	MyLock( ){ pthread_mutex_init( &m_Mutex , NULL );} ;
	~MyLock( ){ pthread_mutex_destroy( &m_Mutex) ; } ;
	VOID	Lock( ){ pthread_mutex_lock(&m_Mutex); } ;
	VOID	Unlock( ){ pthread_mutex_unlock(&m_Mutex); } ;
};
#endif
//自动加锁解锁器
class AutoLock_T
{
public:
	AutoLock_T(MyLock& rLock)
	{
		m_pLock = &rLock;
		m_pLock->Lock();
	}
	~AutoLock_T()
	{
		m_pLock->Unlock();
	}
protected:
private:
	AutoLock_T();
	MyLock* m_pLock;
};


#endif