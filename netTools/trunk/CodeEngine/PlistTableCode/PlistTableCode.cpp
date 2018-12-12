// PlistTableCode.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"

#include <iostream>
#include <vector>
#include <string>
#include "WinFun.h"
#include "TabelImpl.h"
#include "StringFun.h"
using namespace std;

void Helper()
{
	cout <<"Code Engine V1.0\n -d:dir -charp -java \n";
}

const int MAXARGC =3;

int _tmain(int argc, _TCHAR* argv[])
{
	
	if (argc <=2)
	{
		Helper();
	}
	STRING dir=argv[1];
	Replace(dir,"-d:");
	

	for (int i=2;i<argc;++i)
	{
		set<STRING> fileList;
		STRING variable = argv[i];
		vector<STRING> myList;
		SpiltString(myList,variable,"[],",3);


		if (myList.size() == 1)
		{
			SerachFileFromDirectory(dir.c_str(),fileList,".txt");
		}
		else
		{
				for (int k=1;k<myList.size();++k)
				{
					STRING curPath = dir + "\\"+myList[k];
					SerachFileFromDirectory(curPath.c_str(),fileList,".txt");
					cout << "Search Path from " << curPath << ".......\n";
				}
		}
	
		if (fileList.size() ==0)
		{
			cout << "not exist file from ./ and .code\n";
	         continue;
		}

		
		
		CTabelImpl*  pTable = CTabelImpl::CreateInstance(myList[0]);
		if (pTable != NULL)
		{
			pTable->WriteManager(fileList);
			STRING error;
			for (set<STRING>::const_iterator it = fileList.begin();it != fileList.end();++it)
			{
				pTable->MarkDir();
				if(!pTable->CovertFileToCode(*it,error))
				{
					cout <<error << endl;
				}
			}
		}
		SAFE_DELETE(pTable);

	}




	return 0;
}

