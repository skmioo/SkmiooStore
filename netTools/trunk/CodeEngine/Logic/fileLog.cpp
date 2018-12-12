#include "BaseDef.h"
#include "fileLog.h"

namespace Model_Log{
using namespace std;

CFileLog::CFileLog(const char* fileName):m_logFile(fileName)
{
	// 生成文件
	m_file.open(m_logFile.c_str(),ios::out|ios::app);	
}

CFileLog::~CFileLog()
{
	// 释放文件
	m_file.close();
}

int CFileLog::WriteData(const char* szMsg)
{	
	m_file<<szMsg<<std::endl;	
	return 0;
}

void CFileLog::DeleteOneLine()
{
	
}
}
