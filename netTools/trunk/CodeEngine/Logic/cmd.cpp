#include "stdafx.h"
#include "cmd.h"

#define CHUNK 25

typedef struct 
{
	HANDLE pipe;
	STRING buffer;
} pipeinfo;

DWORD WINAPI ReadFromPipe(LPVOID args);

std::string ExecuteCommand( CHAR const* cmdline ,STRING& errors)
{
	
	if (cmdline == NULL || strlen(cmdline) ==0)
	{
		return "";
	}
	pipeinfo Out;
	Out.pipe = INVALID_HANDLE_VALUE;
	pipeinfo Err ;
	Err.pipe = INVALID_HANDLE_VALUE;

	STARTUPINFO si;
    PROCESS_INFORMATION pi;
    SECURITY_ATTRIBUTES sa;
    DWORD threadID;
    char msg[300];
    BOOL ok;
    HANDLE hProcess, h, pipeThreads[2];   
 
    hProcess = GetCurrentProcess();
 
    ZeroMemory(&pi, sizeof(PROCESS_INFORMATION));
    ZeroMemory(&si, sizeof(STARTUPINFO));
    si.cb = sizeof(STARTUPINFO);
    si.dwFlags   = STARTF_USESTDHANDLES;
    si.hStdInput = INVALID_HANDLE_VALUE;
 
    ZeroMemory(&sa, sizeof(SECURITY_ATTRIBUTES));
    sa.nLength = sizeof(SECURITY_ATTRIBUTES);
    sa.lpSecurityDescriptor = NULL;
    sa.bInheritHandle = TRUE;
 
    /*
     * Create a non-inheritible pipe.
     */
 
    CreatePipe(&Out.pipe, &h, &sa, 0);
 
    /*
     * Dupe the write side, make it inheritible, and close the original.
     */
 
    DuplicateHandle(hProcess, h, hProcess, &si.hStdOutput, 0, TRUE,
         DUPLICATE_SAME_ACCESS | DUPLICATE_CLOSE_SOURCE);
 
    /*
     * Same as above, but for the error side.
     */
 
    CreatePipe(&Err.pipe, &h, &sa, 0);
    DuplicateHandle(hProcess, h, hProcess, &si.hStdError, 0, TRUE,
         DUPLICATE_SAME_ACCESS | DUPLICATE_CLOSE_SOURCE);
 
 
   
 
    ok = CreateProcess(
         NULL,     /* Module name. */
         (CHAR*)cmdline,     /* Command line. */
         NULL,     /* Process handle not inheritable. */
         NULL,     /* Thread handle not inheritable. */
         TRUE,     /* yes, inherit handles. */
         DETACHED_PROCESS, /* No console for you. */
         NULL,     /* Use parent's environment block. */
         NULL,     /* Use parent's starting directory. */
         &si,     /* Pointer to STARTUPINFO structure. */
         &pi);     /* Pointer to PROCESS_INFORMATION structure. */
 
    if (!ok) {
     DWORD err = GetLastError();
     int chars = _snprintf(msg, sizeof(msg) - 1,
         "Tried to launch: \"%s\", but got error [%u]: ", cmdline, err);
 
     FormatMessage(FORMAT_MESSAGE_FROM_SYSTEM|FORMAT_MESSAGE_IGNORE_INSERTS|
         FORMAT_MESSAGE_MAX_WIDTH_MASK, 0L, err, 0, &msg[chars],
         (300-chars), 0);
     WriteFile(GetStdHandle(STD_ERROR_HANDLE), msg, lstrlen(msg), &err,NULL);
	 errors = msg;
	 return "";
    }
 
    /*
     * Close our references to the write handles that have now been inherited.
     */
 
    CloseHandle(si.hStdOutput);
    CloseHandle(si.hStdError);
 
  //  WaitForInputIdle(pi.hProcess, 5000);
    CloseHandle(pi.hThread);
 
    /*
     * Start the pipe reader threads.
     */
 
    pipeThreads[0] = CreateThread(NULL, 0, ReadFromPipe, &Out, 0, &threadID);
    pipeThreads[1] = CreateThread(NULL, 0, ReadFromPipe, &Err, 0, &threadID);
 
    /*
     * Block waiting for the process to end.
     */
 
    WaitForSingleObject(pi.hProcess, INFINITE);
    CloseHandle(pi.hProcess);
 
    /*
     * Wait for our pipe to get done reading, should it be a little slow.
     */
 
    WaitForMultipleObjects(2, pipeThreads, TRUE, INFINITE);
    CloseHandle(pipeThreads[0]);
    CloseHandle(pipeThreads[1]);

	errors = Err.buffer;
	return Out.buffer;

}

DWORD WINAPI ReadFromPipe(LPVOID args)
{
	pipeinfo *pi = (pipeinfo *) args;
	STRING& lastBuf = pi->buffer;
	lastBuf ="";
	DWORD dwRead;
	BOOL ok;
	char buf[2000];

	while(true)
	{
		memset(buf,0,sizeof(buf));
		ok = ReadFile(pi->pipe, buf, 1999, &dwRead, 0L);
		if (!ok || dwRead == 0) 
		{
			CloseHandle(pi->pipe);
			return 0;
		}
		else
		{					
			lastBuf += buf;
		}
	}

	return 0; /* makes the compiler happy */
} 
