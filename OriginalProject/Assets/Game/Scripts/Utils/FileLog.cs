using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FileLog
{
    static bool enable = true;
    static bool init = false;
    static string logDir;

    static void Init()
    {
        if(init)
        {
            return;
        }

        init = true;

        logDir = Application.dataPath + "/file_log";

        if(!System.IO.Directory.Exists(logDir))
        {
			System.IO.Directory.CreateDirectory(logDir);
        }


    }

    public static void Log(string fileName, string log)
    {
        if(!enable)
        {
            return;
        }

        Init();

        IOTools.WriteTxt(logDir + "/" + fileName + ".txt", log);
    }
}
