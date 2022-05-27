using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using System.IO;

namespace UYMO
{
    public class LogRecoder:SingletonManual<LogRecoder>
    {
        class LogItem
        {
            public string condition;
            public string stack;
            public LogType type;
        }
        Queue<LogItem> _WaiteRecord = new Queue<LogItem>();
        Queue<LogItem> _Idle = new Queue<LogItem>();
        Application.LogCallback _LogCallback;
        UnhandledExceptionEventHandler _ExceptionCallback;

        Thread _WriteThread;
        bool _Saving = true;
        string _LogPath;
        
        public void Start()
        {
#if UNITY_EDITOR || UNITY_STANDALONE
            _LogPath = Application.dataPath + "/../Data/log.txt";
#else
            _LogPath = Application.persistentDataPath  + "/log.txt";
#endif
            if (_LogCallback==null)
            {
                _LogCallback = new Application.LogCallback(HandleLog);
            }
            if (_ExceptionCallback == null)
            {
                _ExceptionCallback = new UnhandledExceptionEventHandler(HandleException);
            }
            Application.logMessageReceived += _LogCallback;
            AppDomain.CurrentDomain.UnhandledException += _ExceptionCallback;

            _Saving = true;
            if (_WriteThread == null)
            {
                _WriteThread = new Thread(SaveLogToFile);
                _WriteThread.Start();
            }
        }

        public void Stop()
        {
            if(_LogCallback != null)
            {
                Application.logMessageReceived -= _LogCallback;
            }
            if(_ExceptionCallback != null)
            {
                AppDomain.CurrentDomain.UnhandledException -= _ExceptionCallback;
            }

            if(_WriteThread!= null)
            {
                _Saving = false;
                _WriteThread = null;
            }
        }
        
        void HandleLog(string condition, string stackTrace, LogType type)
        {
            LogItem item = _Idle.Count > 0 ? _Idle.Dequeue() : new LogItem();
            item.condition = condition;
            item.stack = stackTrace;
            item.type = type;
            _WaiteRecord.Enqueue(item);
        }

        void HandleException(object sender, UnhandledExceptionEventArgs args)
        {
            if (args.ExceptionObject.GetType() != typeof(Exception))
            {
                return;
            }
            Exception e = args.ExceptionObject as Exception;

            LogItem item = _Idle.Count > 0 ? _Idle.Dequeue() : new LogItem();
            item.condition = sender.ToString();
            item.stack = e.Message;
            item.type =  LogType.Exception;
            _WaiteRecord.Enqueue(item);
        }

        void SaveLogToFile()
        {
            if ( File.Exists(_LogPath))
            {
                File.Delete(_LogPath);
            }
            FileStream file = new FileStream(_LogPath, FileMode.CreateNew, FileAccess.Write);
            TextWriter writer = new StreamWriter(file, System.Text.Encoding.UTF8);
            while (_Saving)
            {
                while(_WaiteRecord.Count > 0)
                {
                    LogItem item = _WaiteRecord.Dequeue();

                    writer.WriteLine(string.Format("[{0}] {1}", item.type, item.condition));
                    writer.WriteLine(item.stack);
                    _Idle.Enqueue(item);
                }
                writer.Flush();
                Thread.Sleep(1000);
            }
            writer.Close();
            file.Close();
        }
    }
}
