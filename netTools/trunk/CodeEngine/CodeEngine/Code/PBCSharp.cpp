#include "PBCSharp.h"
#include "StringFun.h"
#include "TemplateDef.h"
#pragma  warning(disable:4996)


using namespace Operate_Head;




bool CPBCSharp::GetProtocolBuff( CProtoDataMethod const* pdatas )
{
	
	if (pdatas == NULL ||  FALSE == ReadTemplateXML(m_xmlTemplate))
	{
		return false;
	}
	Protocol_Struct_T const* pData = pdatas->GetData();
	if (NULL == pData)return false;


	STRING sFirstnamespace="";
	//开始写入包含文件	
	this->Write(FindXMLElement("pbbuffer_descript"));
	this->Write("\n\n");
	this->Write(FindXMLElement("pbbuffer_import"));
	this->Write("\n\n");

	Code_Tail_T tailStack;

	//Enter Class

	for(Protocol_Struct_T::const_iterator it =pData->begin();
		it != pData->end();++it)
	{
		base_protocol_T const& Keys = it->first;
		Protocol_Class_body_T const& rBody = it->second;
		
		if (sFirstnamespace != Keys.packetHandler && !IsEmptOrSpace(Keys.packetHandler))
		{
			if (!sFirstnamespace.empty() && !tailStack.empty())
			{
				this->Write("\n\n");				
			   this->Write(tailStack.top());
			   tailStack.pop();
			}
			STRING namespacebody = FindXMLElement("pbbuffer_namespace");
			if (!namespacebody.empty())
			{
				Replace(namespacebody,"$namespace$",Keys.packetHandler.c_str());
			}
			this->Write(namespacebody);
			this->Write("\n{\n");
			InsertStack(tailStack,"}\n");
			sFirstnamespace =  Keys.packetHandler;
		}
		if(!IsEmptOrSpace(Keys.className))
		{
			STRING classbody = FindXMLElement("pbbuffer_classhead");
			if (!classbody.empty())
			{
				Replace(classbody,"$classname$",Keys.className.c_str());
			}
			this->Write(classbody);
			this->Write("\n{\n");
			InsertStack(tailStack,"}\n\n");
		}
//开始代码的实体部分

		std::map<INT,base_serialSeal>  SortVariable;//序列化大小
		for(Protocol_Class_body_T::const_iterator codeBody = rBody.begin();
			codeBody != rBody.end();++codeBody)
		{
			base_serialSeal const& realBody =  *codeBody;
			//先将数据插入
			SortVariable[atoi(realBody.m_index.c_str())] = realBody;

			if (EqualString(realBody.m_headType,H_REQUIRED," "))
			{
				STRING requiredtemplate = FindXMLElement("pbbuffer_required");
				if (!requiredtemplate.empty())
				{
					Replace(requiredtemplate,"$variable$",realBody.m_name.c_str());
					Replace(requiredtemplate,"$Variable$",__B(realBody.m_name).c_str());
					Replace(requiredtemplate,"$currentindex$",realBody.m_index.c_str());
					Replace(requiredtemplate,"$defautvalue$",realBody.GetDefaultValue(this).c_str());
					Replace(requiredtemplate,"$type$",realBody.GetRealType(this).c_str());
					this->Write(requiredtemplate);
				}
			}
			else if (EqualString(realBody.m_headType ,H_REPEATED," "))
			{
				STRING requiredtemplate = FindXMLElement("pbbuffer_repeated");
				if (!requiredtemplate.empty())
				{
					Replace(requiredtemplate,"$variable$",realBody.m_name.c_str());
					Replace(requiredtemplate,"$Variable$",__B(realBody.m_name).c_str());
					Replace(requiredtemplate,"$currentindex$",realBody.m_index.c_str());					
					Replace(requiredtemplate,"$type$",realBody.GetRealType(this).c_str());
					this->Write(requiredtemplate);
				}
			}
			else if (EqualString(realBody.m_headType,H_OPTIONAL," "))
			{
				STRING requiredtemplate = FindXMLElement("pbbuffer_optional");
				if (!requiredtemplate.empty())
				{
					Replace(requiredtemplate,"$variable$",realBody.m_name.c_str());
					Replace(requiredtemplate,"$Variable$",__B(realBody.m_name).c_str());
					Replace(requiredtemplate,"$currentindex$",realBody.m_index.c_str());
					Replace(requiredtemplate,"$defautvalue$",realBody.GetDefaultValue(this).c_str());
					Replace(requiredtemplate,"$type$",realBody.GetRealType(this).c_str());
					this->Write(requiredtemplate);
				}
			}
		}
		WriteCommonMothedSize(SortVariable);
		WriteCommonMothedWrite(SortVariable);
		WriteCommonMothedRead(SortVariable,Keys.className);
		WriteCommonMothedInit(SortVariable);
//开始写尾部
		this->Write("\n");				
		this->Write(tailStack.top());
		tailStack.pop();
		

	}//end class
	while (!tailStack.empty())
	{
		this->Write("\n");				
		this->Write(tailStack.top());
		tailStack.pop();
	}

	return false;
}

STRING CPBCSharp::CovertProtoType( string const& sType,BOOL bIsArray,BOOL bIsBaseType )
{
	if (bIsBaseType)
	{
		if(sType == T_INT16)return "Int16";
		if(sType ==T_INT32)return "Int32";
		if(sType == T_INT64)return "Int64";
		if(sType == T_UINT32)return "UInt32";
		if(sType == T_UINT64)return "UInt64";
		if(sType == T_STRING)return "string";
		if(sType == T_BYTES)return " pb::ByteString";
	}
	else
	{
		return sType;
	}
	return "<error>";
}

STRING CPBCSharp::NewInstance( string const& sType )
{
	STRING str = " new ";
	str += sType;
	str += "()";
	return str;
}

VOID CPBCSharp::WriteCommonMothedSize( std::map<INT,base_serialSeal> const& dataList )
{

	STRING serializedsize = FindXMLElement("pbbuffer_serializedsize");
	if (!serializedsize.empty())
	{
		STRING realCode ="";
		CHAR tmp[1024] ={0};
	
		 for (std::map<INT,base_serialSeal>::const_iterator it = dataList.begin();it != dataList.end();++it)
		 {
			 base_serialSeal const& datas = it->second;
			 memset(tmp,0,1024);
			 if (datas.IsBaseType())//按基本类型生成
			 {
				  if (EqualString(datas.m_headType ,H_REPEATED," "))
				  {
					  tsnprintf(tmp,1023,"{\n\
int dataSize = 0;\n\
foreach (%s element in %sList) {\n\
dataSize += pb::CodedOutputStream.%s(element);\n\
}\n\
size += dataSize;\n\
size += 1 * %s_.Count;\n}\n"
,datas.GetRealType(this).c_str(),datas.m_name.c_str(),datas.GetMothod(this,base_serialSeal::PB_SIZE).c_str(),datas.m_name.c_str());
										 
				  }
				  else
				  {
tsnprintf(tmp,1023," if (Has%s) {\n\
size += pb::CodedOutputStream.%s(%d, %s);\n}\n",
										 __B(datas.m_name).c_str(),datas.GetMothod(this,base_serialSeal::PB_SIZE).c_str(),it->first,__B(datas.m_name).c_str());
				  }
			 }
			 else//用户定义类型
			 {
				 if (EqualString(datas.m_headType ,H_REPEATED," "))
				 {
					 tsnprintf(tmp,1023,"{\n\
foreach (%s element in %sList) {\n\
int subsize = element.SerializedSize();	\n\
size += pb::CodedOutputStream.ComputeTagSize((int)%d) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;\n}\n}\n"
					,datas.m_Keys.c_str(),datas.m_name.c_str(),it->first);					
				 }
				 else
				 {
					 tsnprintf(tmp,1023,"{\n\
int subsize = %s.SerializedSize();	\n\
size += pb::CodedOutputStream.ComputeTagSize((int)%d) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;\n}\n"
	,__B(datas.m_name).c_str(),it->first);	
				 }
			 }
			realCode += tmp;
		 }
		 Replace(serializedsize,"$FULLSIZE$",realCode.c_str());
		 this->Write(serializedsize);
	}
}

VOID CPBCSharp::WriteCommonMothedWrite( std::map<INT,base_serialSeal> const& dataList )
{
	STRING serializedsize = FindXMLElement("pbbuffer_pbwrite");
	if (!serializedsize.empty())
	{
		STRING realCode ="";
		CHAR tmp[1024] ={0};

		for (std::map<INT,base_serialSeal>::const_iterator it = dataList.begin();it != dataList.end();++it)
		{
			base_serialSeal const& datas = it->second;
			memset(tmp,0,1024);
			if (datas.IsBaseType())//按基本类型生成
			{
				if (EqualString(datas.m_headType ,H_REPEATED," "))
				{
tsnprintf(tmp,1023,"{\n\
if (%s_.Count > 0) {\n\
foreach (%s element in %sList) {\n\
output.%s(%d,element);\n\
}\n}\n\n}\n",
									   datas.m_name.c_str(),datas.GetRealType(this).c_str(),datas.m_name.c_str(),
									   datas.GetMothod(this,base_serialSeal::PB_WRITE).c_str(),it->first);

				}
				else
				{
					tsnprintf(tmp,1023," \nif (Has%s) {\n\
output.%s(%d, %s);\n}\n",
									   __B(datas.m_name).c_str(),datas.GetMothod(this,base_serialSeal::PB_WRITE).c_str(),it->first,__B(datas.m_name).c_str());
				}
			}
			else//用户定义类型
			{
				if (EqualString(datas.m_headType ,H_REPEATED," "))
				{
					tsnprintf(tmp,1023,"\ndo{\n\
foreach (%s element in %sList) {\n\
output.WriteTag((int)%d, pb::WireFormat.WireType.LengthDelimited);\n\
output.WriteRawVarint32((uint)element.SerializedSize());\n\
element.WriteTo(output);\n\
\n}\n}while(false);\n"
									   ,datas.m_Keys.c_str(),datas.m_name.c_str(),
									   it->first);					
				}
				else
				{
					tsnprintf(tmp,1023,"{\n\
output.WriteTag((int)%d, pb::WireFormat.WireType.LengthDelimited);\n\
output.WriteRawVarint32((uint)%s.SerializedSize());\n\
%s.WriteTo(output);\n\
\n}\n"
									   ,it->first,__B(datas.m_name).c_str(),__B(datas.m_name).c_str());	
				}
			}
			realCode += tmp;
		}
		Replace(serializedsize,"$FULLWRITE$",realCode.c_str());
		this->Write(serializedsize);
	}
}

VOID CPBCSharp::WriteCommonMothedRead( std::map<INT,base_serialSeal> const& dataList,string const& className )
{
	STRING serializedsize = FindXMLElement("pbbuffer_mergedfrom");
	if (!serializedsize.empty())
	{
		Replace(serializedsize,"$classname$",className.c_str());
		STRING realCode ="";
		CHAR tmp[1024] ={0};
		for (std::map<INT,base_serialSeal>::const_iterator it = dataList.begin();it != dataList.end();++it)
		{
			base_serialSeal const& datas = it->second;
			memset(tmp,0,1024);
			if (datas.IsBaseType())//按基本类型生成
			{
				if (EqualString(datas.m_headType ,H_REPEATED," "))
				{
					tsnprintf(tmp,1023,"   case  %d: {\n\
 _inst.Add%s(input.%s());\nbreak;\n}\n",
									   datas.getVarNumber(this,it->first),__B(datas.m_name).c_str(),datas.GetMothod(this,base_serialSeal::PB_READ).c_str());

				}
				else
				{
					tsnprintf(tmp,1023,"   case  %d: {\n\
 _inst.%s = input.%s();\nbreak;\n}\n",
									   datas.getVarNumber(this,it->first),__B(datas.m_name).c_str(),datas.GetMothod(this,base_serialSeal::PB_READ).c_str());
				}
			}
			else//用户定义类型
			{
				if (EqualString(datas.m_headType ,H_REPEATED," "))
				{
					tsnprintf(tmp,1023,"    case  %d: {\n%s subBuilder =  new %s();\n\
input.ReadMessage(subBuilder);\n\
 _inst.Add%s(subBuilder);\nbreak;\n}\n",
									   datas.getVarNumber(this,it->first),datas.m_Keys.c_str(),datas.m_Keys.c_str(),__B(datas.m_name).c_str()
									   );					
				}
				else
				{
					tsnprintf(tmp,1023,"    case  %d: {\n%s subBuilder =  new %s();\n\
 input.ReadMessage(subBuilder);\n _inst.%s = subBuilder;\n\
break;\n}\n"
									   ,datas.getVarNumber(this,it->first),datas.m_Keys.c_str(),datas.m_Keys.c_str(),__B(datas.m_name).c_str()
									   );			
				}
			}
			realCode += tmp;
		}
		Replace(serializedsize,"$FULLREAD$",realCode.c_str());
		this->Write(serializedsize);

		}

		
	}

VOID CPBCSharp::WriteCommonMothedInit( std::map<INT,base_serialSeal> const& dataList )
{
	STRING serializedsize = FindXMLElement("pbbuffer_isinitialized");
	if (!serializedsize.empty())
	{
		
		STRING realCode ="";
		CHAR tmp[1024] ={0};
		for (std::map<INT,base_serialSeal>::const_iterator it = dataList.begin();it != dataList.end();++it)
		{
			base_serialSeal const& datas = it->second;
			memset(tmp,0,1024);
			if (datas.IsBaseType())//按基本类型生成
			{
				if (EqualString(datas.m_headType ,H_REQUIRED," "))
				{
					tsnprintf(tmp,1023," if (!has%s) return false;\n", __B(datas.m_name).c_str());	
				}
				
			}
			else//用户定义类型
			{
				if(EqualString(datas.m_headType ,H_REPEATED," "))
				{
					tsnprintf(tmp,1023,"foreach (%s element in %sList) {\nif (!element.IsInitialized()) return false;\n}\n",datas.m_Keys.c_str(), datas.m_name.c_str());
				}
				else
				{
					tsnprintf(tmp,1023,"  if (Has%s) {\nif (!%s.IsInitialized()) return false;\n}\n",
									   __B(datas.m_name).c_str(),__B(datas.m_name).c_str());	
				}
			}
			realCode += tmp;
		}
		Replace(serializedsize,"$FULLINIT$",realCode.c_str());
		this->Write(serializedsize);

	}
}



