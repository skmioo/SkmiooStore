// FigurePacket.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include <iostream>
#include "Type.h"
#include "WinFun.h"
#include "FileStream.h"
#include "IPacketFactory.h"
using namespace std;


void Helper()
{
	cout <<"Code Engine V1.0\n-i:filename -s:0 -cpp -java -c# \n";
	cout <<"Create C++  -s:0 means cannot replace handler \n-i:filename -s:0 -cpp \n";
}
const int MAXARGC =3;

int _tmain(int argc, _TCHAR* argv[])
{
	_CrtSetDbgFlag(_CRTDBG_ALLOC_MEM_DF | _CRTDBG_LEAK_CHECK_DF);

	if (argc <=MAXARGC)
	{
		Helper();
		return 0;
	}
	string fileName = argv[1];	
	fileName =fileName.substr(3);

	string skiphandler = argv[2];	
	skiphandler =skiphandler.substr(3);

	BOOL bSkiphandler=skiphandler=="0"?FALSE:TRUE;

		CFileStream streamFile;

		if(streamFile.Load(fileName.c_str()))
		{
			for(int i=3;i<argc;++i)
			{	
				CPacketFactory *pPBuff =CPacketFactory::CreateInstance(argv[i]);
				if (pPBuff !=NULL && pPBuff->Init())
				{					
					pPBuff->CreatePacket(&streamFile,bSkiphandler);
					pPBuff->Release();
				}
				SAFE_DELETE(pPBuff);
			}

		}
	
	return 0;
}

