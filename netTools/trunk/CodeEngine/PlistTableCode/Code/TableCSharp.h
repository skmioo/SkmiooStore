#ifndef  __TABLES_CHSARP_H__
#define __TABLES_CHSARP_H__

#include "TabelImpl.h"
#include "Tabdef.h"
class CTableCSharp :	public CTabelImpl
{
public:
	CTableCSharp(void){};
	virtual ~CTableCSharp(void){};

	
	virtual  const CHAR* GetDir()const{return "./CodeTable/CSharp/";};
	virtual BOOL CovertFileToCode(const STRING& rFile,STRING& error)const;
	virtual  const CHAR* GetTemplatemanager()const{return C_SHARP_TABLE_MANAGER_TEMPLATE;};
	virtual  const CHAR* GetManagerName()const{return "TableManager.cs";}
	virtual BOOL  WriteManager(const std::set<STRING>&  rFile)const;

protected:
	STRING  GetRealType(const STRING& sType, STRING* defualtTypevalue=NULL)const;
	STRING  GetRealTypeValue(const STRING& sType,const STRING& sIdx)const;
};


#endif
