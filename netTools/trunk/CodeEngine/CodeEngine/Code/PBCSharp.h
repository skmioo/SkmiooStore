#pragma once
#include <stack>
#include "filestream.h"
#include "BaseDef.h"


typedef std::stack<string> Code_Tail_T;

class CPBCSharp :
	public CprotocolBuffer
{
public:
	virtual  bool GetProtocolBuff (CProtoDataMethod const* pdatas );
	virtual  bool Init(std::string const& fileName);
	virtual  bool Release();
	virtual STRING GetTemplateFile()const;
	virtual STRING CovertProtoType(string const& sType,BOOL bIsArray,BOOL bIsBaseType);
	virtual STRING GetMethod(string const& sType,BOOL bIsArray,BOOL bIsBaseType,base_serialSeal::TYPE_OPERATE opt);
	virtual int getVarNumber(string const& sType,BOOL bIsArray,BOOL bIsBaseType,INT nabsIdx)const;
	virtual STRING NewInstance(string const& sType);
	CPBCSharp(void);
	virtual ~CPBCSharp(void);
private:
	void Write(STRING const& ptext);
	STRING FindXMLElement(STRING const& key)const;
	VOID InsertStack(Code_Tail_T& stackTail,string const& tail="}");
	VOID WriteCommonMothedSize(std::map<INT,base_serialSeal> const& dataList);
	VOID WriteCommonMothedWrite(std::map<INT,base_serialSeal> const& dataList);
	VOID WriteCommonMothedInit(std::map<INT,base_serialSeal> const& dataList);
	VOID WriteCommonMothedRead(std::map<INT,base_serialSeal> const& dataList,string const& className);
private:
	ofstream*  m_File;
	XMLReader_T m_xmlTemplate;
};

