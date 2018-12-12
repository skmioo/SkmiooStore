#ifndef __TABLE_IMPL_H__
#define __TABLE_IMPL_H__
#include "Type.h"
#include "BaseDef.h"

struct  Code_Serial
{
	Code_Serial():m_Type(""),m_Name(""){}
	STRING m_Type;
	STRING m_Name;
};
typedef std::list<Code_Serial> LIstStruct_T;

typedef std::multimap<STRING,Code_Serial> SerialListStruct_T;
typedef std::set<STRING> UniqueStruct_T;


struct XMLElement
{
	STRING m_Key;
	STRING m_Content;
};
typedef  std::map<STRING,XMLElement> XMLReader_T;

class CTabelImpl
{
public:	
	virtual  const CHAR* GetDir()const=0;
	virtual  const CHAR* GetTemplatemanager()const=0;
	virtual  const CHAR* GetManagerName()const=0;
	virtual BOOL CovertFileToCode(const STRING& rFile,STRING& error)const=0;	

public:
	virtual VOID	MarkDir()const;	
	STRING   GetCodeNameInFile(const STRING& file)const;	
	STRING   GetDataFileName(const STRING& file)const;	
	virtual BOOL  WriteManager(const std::set<STRING>&  rFile)const=0;
	virtual  BOOL  ReadTemplateXML(XMLReader_T& datas,const  CHAR* FileName=NULL)const;

public:
	static CTabelImpl*   CreateInstance(const STRING& rTpye);
	static VOID		SerDataToArray(const LIstStruct_T &rSource,SerialListStruct_T & rDest,UniqueStruct_T& sTrace);


protected:
	virtual  BOOL AnalyXMLSturct(const STRING& rFile,LIstStruct_T& serival)const;
	virtual  BOOL AnalyTxtSturct(const STRING& rFile,LIstStruct_T& serival)const;
	virtual STRING FindXMLElement(XMLReader_T const& _xmlTemplate,STRING const& key ) const;
	virtual VOID  WriteCode(std::ofstream& pFile,const STRING& RContent)const;

	virtual STRING  GetRealType(const STRING& sType,STRING* defaultValue=NULL)const=0;
	virtual STRING  GetRealTypeValue(const STRING& sType,const STRING& sIdx)const=0;
	
};

#endif