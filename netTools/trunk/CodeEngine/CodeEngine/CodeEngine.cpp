// CodeEngine.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include "BaseDef.h"
#include "FileStream.h"
#include <iostream>
#include <vector>
#include "PBImpl.h"
#include "PBCSharp.h"
#include "WinFun.h"
#include "StringFun.h"
#include "TemplateDef.h"
using namespace std;


void Helper()
{
	cout <<"Code Engine V1.0\n-i:filename[direct] -c:sharp  [-o:outfile.cs] \n";
	cout <<"Create C++ \n-i:filename -c:c++  -o:outfile.cs \n";
	
}

const int MAXARGC =2;

int _tmain(int argc, _TCHAR* argv[])
{
	
	if (argc <=MAXARGC)
	{
		Helper();
		return 0;
	}
	vector<string> args;
	for(int i =0 ;i < argc-1 ; ++i){
		args.push_back(argv[i+1]);
	}
	
	
	string iFile,oFile,cType;

	for (int i=0;i<argc-1;++i)
	{
		if(args[i].length()<3)continue;
		if(args[i][0]=='-')
		{
			 char ch = args[i][1];
			  char chs = args[i][2];
			 if ((ch == 'i' || ch =='I')&& chs ==':')
			 {
				 iFile = args[i].substr(3);
			 }
			 else  if ((ch == 'o' || ch =='O')&& chs ==':')
			 {
				 oFile = args[i].substr(3);
			 }
			  else  if ((ch == 'c' || ch =='C')&& chs ==':')
			  {
				  cType = args[i].substr(3);
			 }
		}
		
	}
	if (iFile.empty())
	{
		cout << "-i:Input File\n\n";
		Helper();
	}

	if (cType.empty())
	{
		cout << "-C:Code Type\n\n";
		Helper();
	}
	//如果处理是的一个目录，则不需要输出的文件名称
	bool isDirect = isDirectory(iFile.c_str());
	std::set<STRING> myList;
	if (!isDirect)
	{
		myList.insert(iFile);
	}
	else
	{
		SerachFileFromDirectory(iFile.c_str(), myList , ".proto");
	}

	for(std::set<STRING>::const_iterator it =myList.begin(); it != myList.end() ;++it)
	{
		CFileStream streamFile;

		if(streamFile.Load(it->c_str()))
		{
			if(!streamFile.GetClassFileName().empty())
			{
				string fullname = streamFile.GetClassFileName() + CprotocolBuffer::GetTailNameByType(cType);
				string oldername = ChangeIndexTail(it->c_str(),CprotocolBuffer::GetTailNameByType(cType));
				streamFile.SetClassFileName(Rename(oldername,fullname));
			}
			else
			{
				if (streamFile.GetClassFileName().empty() && !isDirect)
				{
					streamFile.SetClassFileName(oFile);
				}
				if (streamFile.GetClassFileName().empty())
				{
					//输出的名称直接为proto的文件名称
					streamFile.SetClassFileName(ChangeIndexTail(iFile,CprotocolBuffer::GetTailNameByType(cType)));
				}
			}
			CprotocolBuffer *pPBuff =CprotocolBuffer::CreateInstance(cType);
			if (pPBuff !=NULL && pPBuff->Init(streamFile.GetClassFileName()))
			{
				WriteDirectory(TEMP_FILTER_CODE);
				pPBuff->GetProtocolBuff(&streamFile);
				pPBuff->Release();
			}

			SAFE_DELETE(pPBuff);
		}
	}
	
	

	return 0;
}

