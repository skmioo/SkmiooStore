#pragma once
#include "BaseDef.h"
#include "StreamData.h"

using namespace std;




namespace CodeEngine_Type
{
	const string C_CSHARP ="csharp";
	const string C_JAVA ="java";
}

class CProtoDataMethod
{
public:
	virtual		Protocol_Struct_T* GetData()=0;
	virtual       Protocol_Struct_T const*  GetData()const=0;
};

struct XMLElement
{
	STRING m_Key;
	STRING m_Content;
};

typedef  std::map<STRING,XMLElement> XMLReader_T;


class  CprotocolBuffer
{
public:
	virtual  bool GetProtocolBuff(CProtoDataMethod const* pdatas)=0;
	virtual  bool Init(std::string const& fileName)=0;
	virtual  bool Release()=0;
	virtual  STRING GetTemplateFile()const=0;
	virtual  BOOL  ReadTemplateXML(XMLReader_T& datas);
	static CprotocolBuffer*  CreateInstance(string const& sType);
	static string  GetTailNameByType(string const& sType);//通过类型获取文件后缀

	//将Proto类型转换成具体语言自身的格式
	virtual STRING CovertProtoType(string const& sType,BOOL bIsArray,BOOL bIsBaseType)=0;

	//获取内部方法
	virtual STRING GetMethod(string const& sType,BOOL bIsArray,BOOL bIsBaseType,base_serialSeal::TYPE_OPERATE opt)=0;

	//获取网络位置方法
	virtual int getVarNumber(string const& sType,BOOL bIsArray,BOOL bIsBaseType,INT nabsIdx)const=0;

	

	virtual STRING NewInstance(string const& sType)=0;
};


