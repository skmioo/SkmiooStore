#pragma once
#include  "IPacketFactory.h"

class CPacketJava :public CPacketFactory
{
public:
	CPacketJava(void);
	virtual ~CPacketJava(void);
	virtual  bool CreatePacket(CProtoDataMethod const* pdatas,BOOL bSkiphandler=FALSE);
	virtual  bool Init();
	virtual  bool Release();	
	virtual  ofstream*  GetWriteHandle(){return m_File;};
	virtual  XMLReader_T&      GetOptCurXML(){return m_xmlTemplate;};
	virtual  const XMLReader_T&      GetOptCurXML()const{return m_xmlTemplate;};	
	virtual void Realse(){};
	virtual   void SetWriteHandle(ofstream*  p){SAFE_DELETE(m_File);m_File = p;}
protected:
	


private:
	ofstream*  m_File;
	XMLReader_T m_xmlTemplate;
};

