#ifndef __STREAM_DATA_H__
#define __STREAM_DATA_H__

#include "BaseDef.h"

class CprotocolBuffer;

namespace Operate_Head
{
#define  H_OPTION  "option "
#define   H_MESSAGE "message "
#define   H_REQUIRED  "required "
#define   H_OPTIONAL  "optional "
#define   H_REPEATED  "repeated "

#define        T_INT32     "int32" 
#define    	 T_STRING "string" 
#define   	 T_INT16   "int16"  
#define   	 T_INT64   "int64"  
#define   	 T_UINT32   "uint32"
#define  	     T_UINT64   "uint64"
#define  	     T_BYTES   "bytes"
}



using namespace std;
using namespace Operate_Head;






struct  base_serialSeal
{
	enum TYPE_OPERATE
	{
		PB_SIZE,
		PB_WRITE,
		PB_READ,
	};


	string m_headType;
	string m_Keys;
	string m_name;
	string  m_index;

	string GetDefaultValue(CprotocolBuffer* pBuff) const;	

	string GetRealType(CprotocolBuffer* pBuff) const;

	bool  IsBaseType()const;

	string GetMothod(CprotocolBuffer* pBuff,base_serialSeal::TYPE_OPERATE opt)const;

	int  getVarNumber(CprotocolBuffer* pBuff,int idx)const;

	

	void Clear()
	{
		m_headType ="";
		m_Keys ="";
		m_name ="";
		m_index ="";
	}
	base_serialSeal()
	{
		 Clear();
	}
	bool Isvalid()
	{
		return !m_name.empty();
	}
};

class base_protocol_T
{
public:
	string packetHandler;
	string className;
	string descipt;
	string keyVariable;

	base_protocol_T(){};
	base_protocol_T(string const& _className,string const& _packetHandler,string const& _desc,string const& _val):className(_className),packetHandler(_packetHandler),descipt(_desc),keyVariable(_val)
	{
		
	};
	bool operator<(const base_protocol_T& _Right) const
	{
		return className < _Right.className;
	}
	bool operator==(const base_protocol_T& _Right) const
	{
		return packetHandler==_Right.packetHandler && className ==_Right.className;
	};

	bool operator!=(const base_protocol_T& _Right) const
	{	// test for iterator inequality
		return (!(*this == _Right));
	}
		
};
typedef list<base_serialSeal> Protocol_Class_body_T;
typedef  std::map<base_protocol_T, Protocol_Class_body_T>  Protocol_Struct_T;
#endif