// Icovn.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include "FunTool.h"
#include <iostream>
#include <vector>
#include <string>
#include <Windows.h>
using namespace std;

void Helper()
{
	cout <<"Code Engine V1.0\n -f:FileTail -i:UTF-8 -o:GBK\n eg -f:.cpp -i:UTF-8 -o:GBK\n";
}
typedef void* iconv_t;

typedef int (*covert)(iconv_t cd,  char* * inbuf, size_t *inbytesleft, char* * outbuf, size_t *outbytesleft);
typedef iconv_t (*iconv_open) (const char* tocode, const char* fromcode);
typedef int (*iconv_close )(iconv_t cd);


int _tmain(int argc, _TCHAR* argv[])
{
	if (argc <4)
	{
		Helper();
		return -1;
	}
	string  args[] = { argv[1],argv[2], argv[3]};

	string iFile,oFile,cType;

	for (int i=0;i<3;++i)
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
			else  if ((ch == 'f' || ch =='F')&& chs ==':')
			{
				cType = args[i].substr(3);
			}
		}

	}
	if (iFile.empty())
	{
		cout << "-i:Input Character you can enter -i:UTF-8\n\n";
		Helper();
	}
	if (oFile.empty())
	{
		cout << "-o:Output Character you can enter -O:UTF-8\n\n";
		Helper();
	}
	if (cType.empty())
	{
		cout << "-f:Tail Type -f:.java\n\n";
		Helper();
	}

	set<STRING> fileList;
	int nSize = SerachFileFromDirectory("./",fileList,cType.c_str());
	if (nSize ==0)
	{
		cout << "not exist file from ./ and\n";
		return 0;
	}
	//装载库
	HINSTANCE hDll = LoadLibrary("libiconv-2.dll");; //声明一个Dll实例文件句柄 hDll = LoadLibrary("DllDemo.dll");//导入DllDemo.dll动态连接库
	if (hDll == NULL)
	{
		
		MessageBox(NULL,_T("Can not Load libiconv-2.dll "),"Exception",MB_OK);
		return -1;
	}
	covert 	Covert = (covert)GetProcAddress(hDll,"libiconv"); 
	iconv_open Iconv_open = (iconv_open)GetProcAddress(hDll,"libiconv_open"); 
	iconv_close Iconv_close = (iconv_close)GetProcAddress(hDll,"libiconv_close"); 




	if (Covert == NULL)
	{
		MessageBox(NULL,_T("Can not Load libiconv-2.dll function covert"),"Exception",MB_OK);
		return -1;
	}
	iconv_t cd = Iconv_open(iFile.c_str(),oFile.c_str());

	if (cd == (iconv_t)-1)
	{
		return -1;
	}



	const int MAXDEST =0xFFFFFFF;
	char* dest = new char[MAXDEST];
	for (set<STRING>::const_iterator it = fileList.begin();it != fileList.end();++it)
	{
		char* pdest =dest;
		size_t len=0;
		char * pfilecontent = MyReadFile(*it, len);
		char* ptmp = pfilecontent;
		memset(dest,0,MAXDEST);		
		size_t iLen =MAXDEST;
		char **pin = &ptmp;
		char **pout = &pdest;
		if (Covert(cd, pin, &len, pout, &iLen)) return -1;	
		MyWriteFile(it->c_str(),dest);
		delete[] pfilecontent;
		pfilecontent=NULL;
		cout << "covert file " << *it << " from " << iFile.c_str()<<"  to " << oFile.c_str() << "OK !!!" << endl;
	}
	delete[] dest;
	dest =NULL;
	
	Iconv_close(cd);


	FreeLibrary(hDll);

	scanf("%s");

	return 0;
}

