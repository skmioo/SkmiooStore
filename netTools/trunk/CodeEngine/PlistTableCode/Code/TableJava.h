#ifndef  __TABLES_JAVA_H__
#define __TABLES_JAVA_H__

#include "TabelImpl.h"
#include "Tabdef.h"
class CTableJava :	public CTabelImpl
{
public:
	CTableJava(void){};
	virtual ~CTableJava(void){};
	virtual  const CHAR* GetDir()const{return "./CodeTable/Java/";};
	virtual  STRING GetDir(const STRING& rPackage)const;
	virtual BOOL CovertFileToCode(const STRING& rFile,STRING& error)const;
	virtual  const CHAR* GetTemplatemanager()const{return JAVA_TABLE_MANAGER_TEMPLATE;};
	virtual  const CHAR* GetManagerName()const{return "TableManager.java";}
	virtual  BOOL WriteManager( const std::set<STRING>& rFile ) const;
protected:
	STRING  GetRealType(const STRING& sType ,STRING* defualtTypevalue=NULL)const;
	STRING  GetRealTypeValue(const STRING& sType,const STRING& sIdx)const;
};

#endif