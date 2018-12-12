
#include "StreamData.h"
#include "PBImpl.h"
#include "StringFun.h"
#include <set>
using namespace Operate_Head;


class ToolHelper
{
public:
	ToolHelper()
	{
		s_DefaultType.insert(T_INT32  );
		s_DefaultType.insert(T_STRING);
		s_DefaultType.insert(T_INT16  );
		s_DefaultType.insert(T_INT64  );
		s_DefaultType.insert(T_UINT32);
		s_DefaultType.insert(T_UINT64);
		s_DefaultType.insert(T_BYTES);
	};
	std::set<STRING> s_DefaultType;
};


static ToolHelper s_helper;



std::string base_serialSeal::GetDefaultValue(CprotocolBuffer* pBuff) const
{
	  if(pBuff ==NULL)
	  {
		  return "<error>";
	  }

		std::set<STRING>::const_iterator subit = s_helper.s_DefaultType.find(m_Keys);
		if (subit != s_helper.s_DefaultType.end())
		{
			if(m_Keys == T_BYTES)
			{
				return "pb::ByteString.Empty";
			}
			else if (m_Keys != T_STRING )
			{
				return "0";
			}
			else
			{
				return "\"\"";
			}
		}
		else
		{
			 return pBuff->NewInstance(m_Keys);
		}
}

std::string base_serialSeal::GetRealType( CprotocolBuffer* pBuff ) const
{
	if(pBuff ==NULL)
	{
		return "<error>";
	}

	std::set<STRING>::const_iterator subit = s_helper.s_DefaultType.find(m_Keys);
	if (subit != s_helper.s_DefaultType.end())
	{
		if (!EqualString(m_headType , H_REPEATED," ") )
		{
			return pBuff->CovertProtoType(m_Keys,FALSE,TRUE);
		}
		else
		{
			return pBuff->CovertProtoType(m_Keys,TRUE,TRUE);
		}
	}
	else
	{
		if (!EqualString(m_headType , H_REPEATED," ") )
		{
			return pBuff->CovertProtoType(m_Keys,FALSE,FALSE);
		}
		else
		{
			return pBuff->CovertProtoType(m_Keys,TRUE,FALSE);
		}
	}
}

bool base_serialSeal::IsBaseType()const
{
	std::set<STRING>::const_iterator subit = s_helper.s_DefaultType.find(m_Keys);
	if (subit != s_helper.s_DefaultType.end())
	{
		return true;
	}
	return false;
}

std::string base_serialSeal::GetMothod( CprotocolBuffer* pBuff,TYPE_OPERATE opt ) const
{
	if(pBuff ==NULL)
	{
		return "<error>";
	}

	std::set<STRING>::const_iterator subit = s_helper.s_DefaultType.find(m_Keys);
	if (subit != s_helper.s_DefaultType.end())
	{
		if (!EqualString(m_headType , H_REPEATED," ") )
		{
			return pBuff->GetMethod(m_Keys,FALSE,TRUE,opt);
		}
		else
		{
			return pBuff->GetMethod(m_Keys,TRUE,TRUE,opt);
		}
	}
	else
	{
		if (!EqualString(m_headType , H_REPEATED," ") )
		{
			return pBuff->GetMethod(m_Keys,FALSE,FALSE,opt);
		}
		else
		{
			return pBuff->GetMethod(m_Keys,TRUE,FALSE,opt);
		}
	}

}

int base_serialSeal::getVarNumber( CprotocolBuffer* pBuff,int idx ) const
{
	if(pBuff ==NULL)
	{
		return -1;
	}

	std::set<STRING>::const_iterator subit = s_helper.s_DefaultType.find(m_Keys);
	if (subit != s_helper.s_DefaultType.end())
	{
		if (!EqualString(m_headType , H_REPEATED," ") )
		{
			return pBuff->getVarNumber(m_Keys,FALSE,TRUE,idx);
		}
		else
		{
			return pBuff->getVarNumber(m_Keys,TRUE,TRUE,idx);
		}
	}
	else
	{
		if (!EqualString(m_headType , H_REPEATED," ") )
		{
			return pBuff->getVarNumber(m_Keys,FALSE,FALSE,idx);
		}
		else
		{
			return pBuff->getVarNumber(m_Keys,TRUE,FALSE,idx);
		}
	}

}

