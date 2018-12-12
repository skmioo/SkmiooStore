#ifndef __FILE_STREAM_H__
#define __FILE_STREAM_H__

#include "BaseDef.h"
#include "StreamData.h"
#include "PBImpl.h"

class CFileStream:public CProtoDataMethod
{
public:
		CFileStream();
		BOOL		Load(const CHAR* pFileName);		
		BOOL	    Save(const CHAR* pFileName);
		virtual Protocol_Struct_T*  GetData(){return &m_Data;}
		virtual Protocol_Struct_T const*  GetData()const{return &m_Data;}
		string GetClassFileName() const{ return m_classFileName; }
		void SetClassFileName(const string& filename) {  m_classFileName = filename; }
protected:
		bool SerialDataStruct(string const& rContent,Protocol_Class_body_T* pList=NULL);
		bool MergedFrom(base_serialSeal& rStruct,string const& body)const;
private:	  
	Protocol_Struct_T   m_Data;
	string m_classFileName;
};
#endif