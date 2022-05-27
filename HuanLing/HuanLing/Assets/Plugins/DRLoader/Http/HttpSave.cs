using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DRLoader.Http
{
    class HttpSave
    {
        HttpRequest _Request;
        Stream _Stream;
        Stream _InfoFile;
        DLInfo _Info;
        byte[] _Buff;
        int _BuffUsed;
        long _Received;

        System.Diagnostics.Stopwatch _SpdWatch;
        long _RevInSec;
        long _Speed;
        string _Path;

        string _Error;
        bool _Pause = false;

        public HttpSave(string path, bool breakPoint)
        {
            _SpdWatch = new System.Diagnostics.Stopwatch();
            _Path = path;
            _Info = new DLInfo();
            if (!saveInMemory)
            {//保存到文件
                string tdfPath = tempPath;
                string tdiPath = infoPath;

                if (breakPoint && File.Exists(tdfPath) && File.Exists(tdiPath))
                {//断点续传
                    try
                    {
                        _Stream = new FileStream(tdfPath, FileMode.Open, FileAccess.ReadWrite);
                        _InfoFile = new FileStream(tdiPath, FileMode.Open, FileAccess.ReadWrite);
                        BinaryReader reader = new BinaryReader(_InfoFile);
                        _Info.total = reader.ReadInt64();
                        _Info.saved = reader.ReadInt64();
                        _Received = _Info.saved;
                        _Stream.Seek(_Info.saved, SeekOrigin.Begin);
                    }
                    catch
                    {
                        ClearReceivedData();
                    }
                }
                else
                {
                    ClearReceivedData();
                }
            }
        }
        /// <summary>
        /// 开始接收数据
        /// </summary>
        /// <param name="request">http源</param>
        /// <returns>是否成功</returns>
        public bool BeginReceive(HttpRequest request )
        {
            if(_Request != null)
            {
                throw new InvalidOperationException("has begining receive...");
            }
            _Request = request;
            if (request.length <= 0)
            {//数据被压缩过，未设置长度
                _Received = 0;
                _Info.total = _Request.length;
            }
            else if (saveInMemory)
            {//保存到内存
                try
                {
                    _Stream = new MemoryStream((int)request.length);
                    _Buff = new byte[512 * 100];
                    _BuffUsed = 0;
                    _Received = 0;
                    _Info.total = _Request.length;
                }
                catch(Exception e)
                {
                    _Error = e.ToString();
                    return false;
                }
                
            }
            else
            {//保存到文件
                if(_Info.total != 0 && _Request.length != _Info.total)
                {//源数据长度与本地当前长度不符
                    ClearReceivedData();
                    return false;
                }

                long bsz = Math.Min(1024 * 1024, _Request.length);
                _Buff = new byte[bsz];
                _BuffUsed = 0;

                if (_Stream == null)
                {
                    try
                    {
                        _Stream = new FileStream(tempPath, FileMode.CreateNew, FileAccess.Write);
                        _Stream.SetLength(_Request.length);

                        _Info.total = _Request.length;
                        _Info.saved = 0;
                        _Received = _Info.saved;

                        _InfoFile = new FileStream(infoPath, FileMode.CreateNew, FileAccess.Write);
                        BinaryWriter writer = new BinaryWriter(_InfoFile);
                        writer.Seek(0, SeekOrigin.Begin);
                        writer.Write(_Info.total);
                        writer.Write(_Info.saved);
                        _InfoFile.Flush();
                    }
                    catch(Exception e )
                    {
                        _Error = e.ToString();
                        return false;
                    }
                    
                }
            }

            _SpdWatch.Reset();
            _SpdWatch.Start();
            _RevInSec = 0;
            _Speed = 0;
            return true;
        }

        public bool ResetRev(HttpRequest request)
        {
            if(_Info.total != request.length)
            {//长度不匹配
                ClearReceivedData();
                _Request = null;
                return false;
            }
            _Request = request;

            _SpdWatch.Reset();
            _SpdWatch.Start();
            _RevInSec = 0;
            _Speed = 0;
            return true;
        }

        public bool hasBegin { get { return _Request != null; } }

        public bool ReceiveData()
        {
            int size = 0;
            UpdateSpeed(size);//预先刷新下
            if (!_Pause)
            {
                var stream = _Request.stream;
                if (stream == null)
                {
                    return false;
                }

                if (_Request.length <= 0)
                {
                    string text = string.Empty;
                    try
                    {
                        StreamReader reader = new StreamReader(stream);
                        text = reader.ReadToEnd();
                    }
                    catch (Exception e)
                    {
                        _Error = e.ToString();
                        return false;
                    }

                    byte[] data = Encoding.UTF8.GetBytes(text);
                    size = data.Length;
                    _Received += size;
                    _Info.saved += size;
                    _Stream = new MemoryStream(data);
                    if (!saveInMemory)
                    {//要求保存到文件
                        File.WriteAllBytes(tempPath, data);
                    }
                }
                else if (saveInMemory)
                {
                    try
                    {
                        size = stream.Read(_Buff, 0, _Buff.Length);
                        _Received += size;
                    }
                    catch (Exception e)
                    {
                        _Error = e.ToString();
                        return false;
                    }

                    MemoryStream mm = _Stream as MemoryStream;
                    _Stream.Write(_Buff, 0, size);
                    _Info.saved += size;
                }
                else
                {
                    try
                    {
                        size = stream.Read(_Buff, _BuffUsed, _Buff.Length - _BuffUsed);
                    }
                    catch (Exception e)
                    {
                        _Error = e.ToString();
                        return false;
                    }

                    _BuffUsed += size;
                    _Received += size;
                    if (_BuffUsed >= _Buff.Length || received >= _Info.total)
                    {//写入文件
                        _Stream.Write(_Buff, 0, _BuffUsed);
                        long curSaved = _Info.saved + _BuffUsed;
                        BinaryWriter writer = new BinaryWriter(_InfoFile);
                        writer.Seek(0, SeekOrigin.Begin);
                        writer.Write(_Info.total);
                        writer.Write(curSaved);
                        _Info.saved = curSaved;
                        _BuffUsed = 0;
                    }
                }
            }

            UpdateSpeed(size);

            return true;
        }

        void UpdateSpeed(int size )
        {
            _RevInSec += size;
            int nowSec = DateTime.Now.Second;
            if (_SpdWatch.ElapsedMilliseconds >= 1000)
            {
                _Speed = _RevInSec;
                _RevInSec = 0;
                _SpdWatch.Reset();
                _SpdWatch.Start();
                //UnityEngine.Debug.LogFormat("Refresh Speed:{0}", _Speed);
            }
        }
        /// <summary>
        /// 已经接收的数据长度
        /// </summary>
        public long received
        {
            get
            {
                return _Received;
            }
        }
        /// <summary>
        /// 已经接收并保存的数据长度
        /// </summary>
        public long saved
        {
            get
            {
                return _Info.saved;
            }
        }
        /// <summary>
        /// 速度
        /// </summary>
        public long speed
        {
            get
            {
                return _Speed;
            }
        }

        public float progress
        {
            get
            {
                return (float)((double)received / (double)_Info.total);
            }
        }

        public long length
        {
            get
            {
                return _Info.total;
            }
        }

        public bool complete
        {
            get
            {
                return _Info.total <= 0 ? _Received >= 0 : saved >= _Info.total;
            }
        }

        public bool pause
        {
            get
            {
                return _Pause;
            }
            set
            {
                _Pause = value;
            }
        }

        public byte[] data
        {
            get
            {
                if(saveInMemory)
                {
                    return (_Stream as MemoryStream).ToArray();
                }
                else
                {
                    return null;
                }
            }
        }

        public string error { get { return _Error; } }
        public bool saveInMemory { get { return string.IsNullOrEmpty(_Path); } }

        public void Dispose()
        {
            if(_Stream!= null)
            {
                _Stream.Flush();
                _Stream.Dispose();
                _Stream = null;
            }
            
            if (_InfoFile != null )
            {
                _InfoFile.Flush();
                _InfoFile.Close();
                _InfoFile = null;
            }
            if(!saveInMemory && complete )
            {
                if(File.Exists(infoPath))
                {
                    File.Delete(infoPath);
                }
                if(File.Exists(tempPath))
                {
                    if(File.Exists(_Path))
                    {
                        File.Delete(_Path);
                    }
                    File.Move(tempPath, _Path);
                }
            }
            if(_Buff!= null)
            {
                _Buff = null;
            }
            _Info.total = 0;
            _Info.saved = 0;
        }

        string tempPath
        {
            get
            {
                return _Path + NetFrame.TempFileExt;
            }
        }

        string infoPath
        {
            get
            {
                return _Path + NetFrame.BreakpointExt;
            }
        }

        void ClearReceivedData()
        {
            _Info.total = 0;
            _Info.saved = 0;
            _Received = _Info.saved;
            if(_Stream != null)
            {
                _Stream.Close();
                _Stream = null;
            }
            if(_InfoFile != null)
            {
                _InfoFile.Close();
                _InfoFile = null;
            }
            
            if (File.Exists(infoPath))
            {
                File.Delete(infoPath);
            }
            if(File.Exists(tempPath))
            {
                File.Delete(tempPath);
            }
        }

        struct DLInfo
        {
            /// <summary>
            /// 数据总长度
            /// </summary>
            public long total;
            /// <summary>
            /// 已经保存下来的长度
            /// </summary>
            public long saved;
        }
    }
}
