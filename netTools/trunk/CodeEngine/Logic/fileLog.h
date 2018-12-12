#ifndef FILELOG_H
#define FILELOG_H

#pragma warning(disable:4786)

#include "BaseDef.h"
#include "logImp.h"
#include <fstream>

namespace Model_Log{

class CFileLog:public CImplementLog
{
public:
	CFileLog(const char* fileName = "log.txt");
	~CFileLog();
	int WriteData(const char* szMsg);
	void DeleteOneLine();
private:

	std::ofstream m_file;
	std::string m_logFile;
};


}
#endif