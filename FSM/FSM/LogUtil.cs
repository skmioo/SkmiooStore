using System;

public class LogUtil
{
    public static bool isLog = true;
    public static void Log(string data)
    {
        if (isLog)
        {
            Console.WriteLine(data);
        }
    }

    public static void Log(string format, object arg0)
    {
        if (isLog)
        {
            Console.WriteLine(format, arg0);
        }
    }

    public static void Log(string format, object arg0, object arg1)
    {
        if (isLog)
        {
            Console.WriteLine(format, arg0, arg1);
        }
    }

    public static void Log(string format, object arg0, object arg1, object arg2)
    {
        if (isLog)
        {
            Console.WriteLine(format, arg0, arg1, arg2);
        }
    }
}
