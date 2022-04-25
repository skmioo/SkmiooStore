using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class IOTools
{
    public static void WriteTxt(string path,string value)
    {
        FileInfo f = new FileInfo(path);
        if (!f.Directory.Exists)
        {
            f.Directory.Create();
        }
        StreamWriter sw;
        if (!f.Exists)
        {
            sw = new StreamWriter(f.Create(), System.Text.Encoding.UTF8);
        } 
        else
        {
            sw = f.AppendText();
        }

        sw.WriteLine(value);
        sw.Dispose();
        sw.Close();
    }
}
