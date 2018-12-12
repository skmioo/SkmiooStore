#include "PBCSharp.h"
#include "StringFun.h"
#include "TemplateDef.h"

using namespace Operate_Head;

CPBCSharp::CPBCSharp(void)
{
	m_File=NULL;
}


CPBCSharp::~CPBCSharp(void)
{
	Release();
}


bool CPBCSharp::Init( std::string const& fileName )
{
	if (fileName.empty())
	{
		cout << "Out file not empty\n";
		return false;
	}
	if(m_File !=NULL)
	{
		Release();
	}
	m_File = new ofstream();
	if(m_File!=NULL)
	{
		m_File->open(fileName.c_str(),ios_base::binary);
		if (!m_File->is_open())
		{
			cout << "Out file can not write please check disk:" << fileName << endl;
			SAFE_DELETE(m_File);
			return false;
		}
		return true;
	}
	return false;
}

bool CPBCSharp::Release()
{
	if (m_File!=NULL)
	{
		m_File->close();
		SAFE_DELETE(m_File);
	}
	return true;
}

STRING CPBCSharp::GetTemplateFile()const
{
	return COMMON_CSHARP_CODE;
}

void CPBCSharp::Write( STRING const& ptext )
{
	STRING lastMsg = ptext;
	Replace(lastMsg,"$N$","\n");
	Replace(lastMsg,"$L$","<");
	Replace(lastMsg,"$R$",">");
	if(!lastMsg.empty())
	{
		*m_File  << lastMsg;
	}
}

STRING CPBCSharp::FindXMLElement( STRING const& key ) const
{
	if (IsEmptOrSpace(key))
	{
		return "";
	}
	XMLReader_T::const_iterator itincludes = m_xmlTemplate.find(key);
	if (itincludes != m_xmlTemplate.end())
	{
		return itincludes->second.m_Content;
	}
	return "";
}

VOID CPBCSharp::InsertStack( Code_Tail_T& stackTail ,string const& tail)
{
	string heads ="";

	for (int i=0;i<stackTail.size();++i)
	{
		heads += "\t";
	}
	heads +=tail;
	stackTail.push(heads);
}

STRING CPBCSharp::GetMethod( string const& sType,BOOL bIsArray,BOOL bIsBaseType,base_serialSeal::TYPE_OPERATE opt )
{
	if (bIsBaseType)
	{
		if(sType == T_INT16)
		{
			if(!bIsArray)
			{
				switch(opt)
				{
				case base_serialSeal::PB_SIZE: return "ComputeInt16Size";break;
				case base_serialSeal::PB_WRITE: return "WriteInt16";break;
				case base_serialSeal::PB_READ: return "ReadInt16";break;
				}
			}
			else
			{
				switch(opt)
				{
				case base_serialSeal::PB_SIZE: return "ComputeInt16SizeNoTag";break;
				case base_serialSeal::PB_WRITE: return "WriteInt16";break;
				case base_serialSeal::PB_READ: return "ReadInt16";break;
				}
			}
		}
		if(sType ==T_INT32)
		{

			if(!bIsArray)
			{
				switch(opt)
				{
				case base_serialSeal::PB_SIZE: return "ComputeInt32Size";break;
				case base_serialSeal::PB_WRITE: return "WriteInt32";break;
				case base_serialSeal::PB_READ: return "ReadInt32";break;
				}
			}
			else
			{
				switch(opt)
				{
				case base_serialSeal::PB_SIZE: return "ComputeInt32SizeNoTag";break;
				case base_serialSeal::PB_WRITE: return "WriteInt32";break;
				case base_serialSeal::PB_READ: return "ReadInt32";break;
				}
			}
		}
		if(sType == T_INT64)
		{

			if(!bIsArray)
			{
				switch(opt)
				{
				case base_serialSeal::PB_SIZE: return "ComputeInt64Size";break;
				case base_serialSeal::PB_WRITE: return "WriteInt64";break;
				case base_serialSeal::PB_READ: return "ReadInt64";break;
				}
			}
			else
			{
				switch(opt)
				{
				case base_serialSeal::PB_SIZE: return "ComputeInt64SizeNoTag";break;
				case base_serialSeal::PB_WRITE: return "WriteInt64";break;
				case base_serialSeal::PB_READ: return "ReadInt64";break;
				}
			}
		}
		if(sType == T_UINT32)
		{
			if(!bIsArray)
			{
				switch(opt)
				{
				case base_serialSeal::PB_SIZE: return "ComputeUInt32Size";break;
				case base_serialSeal::PB_WRITE: return "WriteUInt32";break;
				case base_serialSeal::PB_READ: return "ReadUInt32";break;
				}
			}
			else
			{
				switch(opt)
				{
				case base_serialSeal::PB_SIZE: return "ComputeUInt32SizeNoTag";break;
				case base_serialSeal::PB_WRITE: return "WriteUInt32";break;
				case base_serialSeal::PB_READ: return "ReadUInt32";break;
				}
			}
		}
		if(sType == T_UINT64)
		{
			if(!bIsArray)
			{
				switch(opt)
				{
				case base_serialSeal::PB_SIZE: return "ComputeUInt64Size";break;
				case base_serialSeal::PB_WRITE: return "WriteUInt64";break;
				case base_serialSeal::PB_READ: return "ReadUInt64";break;
				}
			}
			else
			{
				switch(opt)
				{
				case base_serialSeal::PB_SIZE: return "ComputeUInt64SizeNoTag";break;
				case base_serialSeal::PB_WRITE: return "WriteUInt64";break;
				case base_serialSeal::PB_READ: return "ReadUInt64";break;
				}
			}
		}
		if(sType == T_STRING)
		{
			if(!bIsArray)
			{
				switch(opt)
				{
				case base_serialSeal::PB_SIZE: return "ComputeStringSize";break;
				case base_serialSeal::PB_WRITE: return "WriteString";break;
				case base_serialSeal::PB_READ: return "ReadString";break;
				}
			}
			else
			{
				switch(opt)
				{
				case base_serialSeal::PB_SIZE: return "ComputeStringSize";break;
				case base_serialSeal::PB_WRITE: return "WriteString";break;
				case base_serialSeal::PB_READ: return "ReadString";break;
				}
			}
		}
		if(sType == T_BYTES)
		{
			if(!bIsArray)
			{
				switch(opt)
				{
				case base_serialSeal::PB_SIZE: return "ComputeBytesSize";break;
				case base_serialSeal::PB_WRITE: return "WriteBytes";break;
				case base_serialSeal::PB_READ: return "ReadBytes";break;
				}
			}
			else
			{
				switch(opt)
				{
				case base_serialSeal::PB_SIZE: return "ComputeBytesSize";break;
				case base_serialSeal::PB_WRITE: return "WriteBytes";break;
				case base_serialSeal::PB_READ: return "ReadBytes";break;
				}
			}
		}
	}

	return "<error>";
}



int CPBCSharp::getVarNumber( string const& sType,BOOL bIsArray,BOOL bIsBaseType, INT nabsIdx ) const
{
	enum WireType 
	{
		Varint = 0,
		Fixed64 = 1,
		LengthDelimited = 2,
		StartGroup = 3,
		EndGroup = 4,
		Fixed32 = 5
	};

	static int TagTypeBits = 3;
	if (bIsBaseType)
	{
		if(sType == T_INT16)
		{
			if(!bIsArray)
			{
				  return (UINT) (nabsIdx << TagTypeBits) | (UINT) Varint;
			}
			else
			{
				return (UINT) (nabsIdx << TagTypeBits) | (UINT) Varint;
			}
		}
		if(sType ==T_INT32)
		{

			if(!bIsArray)
			{
				return (UINT) (nabsIdx << TagTypeBits) | (UINT) Varint;
			}
			else
			{
				return (UINT) (nabsIdx << TagTypeBits) | (UINT) Varint;
			}
		}
		if(sType == T_INT64)
		{

			if(!bIsArray)
			{
				return (UINT) (nabsIdx << TagTypeBits) | (UINT) Varint;
			}
			else
			{
				return (UINT) (nabsIdx << TagTypeBits) | (UINT) Varint;
			}
		}
		if(sType == T_UINT32)
		{
			if(!bIsArray)
			{
				return (UINT) (nabsIdx << TagTypeBits) | (UINT) Varint;
			}
			else
			{
				return (UINT) (nabsIdx << TagTypeBits) | (UINT) Varint;
			}
		}
		if(sType == T_UINT64)
		{
			if(!bIsArray)
			{
				return (UINT) (nabsIdx << TagTypeBits) | (UINT) Varint;
			}
			else
			{
				return (UINT) (nabsIdx << TagTypeBits) | (UINT) Varint;
			}
		}
		if(sType == T_STRING)
		{
			if(!bIsArray)
			{
				return (UINT) (nabsIdx << TagTypeBits) | (UINT) LengthDelimited;
			}
			else
			{
				return (UINT) (nabsIdx << TagTypeBits) | (UINT) LengthDelimited;
			}
		}
		if(sType == T_BYTES)
		{
			if(!bIsArray)
			{
				return (UINT) (nabsIdx << TagTypeBits) | (UINT) LengthDelimited;
			}
			else
			{
				return (UINT) (nabsIdx << TagTypeBits) | (UINT) LengthDelimited;
			}
		}
	}
	else
	{
		return (UINT) (nabsIdx << TagTypeBits) | (UINT) LengthDelimited;
	}

	return -1;
}