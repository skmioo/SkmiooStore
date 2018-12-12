#pragma once


#include "BaseDef.h"
#include "StreamData.h"
#include "PBImpl.h"

using namespace std;

typedef map<STRING,vector<STRING> > ImportList_T;
typedef list<STRING> PacketDefine_T;


namespace PACKET_Type
{
	const string C_CSHARP ="-c#";
	const string C_JAVA ="-java";
	const string C_CPLUSE ="-cpp";
}




class  CPacketFactory
{
public:
	virtual  bool CreatePacket(CProtoDataMethod const* pdatas,BOOL bSkiphandler=FALSE)=0;
	virtual  bool Init()=0;
	virtual  bool Release()=0;	
	virtual  ofstream*  GetWriteHandle()=0;
	virtual   void SetWriteHandle(ofstream*  p)=0;
	virtual  XMLReader_T&      GetOptCurXML()=0;
	virtual  const XMLReader_T&      GetOptCurXML()const=0;	
	virtual void Realse()=0;

	virtual  BOOL  ReadTemplateXML(XMLReader_T& datas,const STRING& filename);
	static CPacketFactory*  CreateInstance(string const& sType);

	void Write(STRING const& ptext);
	STRING FindXMLElement(STRING const& key)const;

	bool EnvFileStream(const STRING& rFileName,const STRING& rDir);


	bool  InsertImport(const STRING&headVal, ImportList_T& listClass,const STRING& Key,const STRING& values);
	STRING  GetImport(const STRING&headVal, ImportList_T& listClass,const STRING& xmltempleate);
	STRING GePacket(const STRING&headVal, ImportList_T& listClass,const STRING& rrep);

};
