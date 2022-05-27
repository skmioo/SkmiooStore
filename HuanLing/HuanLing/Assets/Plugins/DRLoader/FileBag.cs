using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Security.Cryptography;

namespace DRLoader
{
    public enum OSType:byte
    {
        Unknown = 0,
        Windows = 1,
        Android = 2,
        iOS =4,
        iOS_Root = 8,
        WP = 16
    }
    /// <summary>
    /// 分支信息，注意，只能用小写
    /// </summary>
    public enum BranchType:sbyte
    {
        unknown = -2,
        trunk = -1,
        s0 = 0,
    }
    /// <summary>
    /// 特殊文件类型
    /// </summary>
    public enum FileType
    {
        /// <summary>
        /// 正常文件
        /// </summary>
        Normal,
        /// <summary>
        /// 标记，文件需要被删除
        /// </summary>
        Removed
    }
    /// <summary>
    /// 文件条目
    /// </summary>
    struct FileRecord
    {
        /// <summary>
        /// 名称的hash值
        /// </summary>
        public long nameHash;
        /// <summary>
        /// 文件数据位置
        /// </summary>
        public long pos;
        /// <summary>
        /// 文件的尺寸
        /// </summary>
        public long size;

        public void Read( BinaryReader reader )
        {
            nameHash = reader.ReadInt64();
            pos = reader.ReadInt64();
            size = reader.ReadInt64();
        }
        public void Write( BinaryWriter writer )
        {
            writer.Write(nameHash);
            writer.Write(pos);
            writer.Write(size);
        }

        public static FileRecord zero = new FileRecord();

        public const int ByteSize = 24;
    }
    /// <summary>
    /// 一个存储块
    /// </summary>
    struct StorageBlock
    {
        /// <summary>
        /// 块开始位置（含）
        /// </summary>
        public long pos;
        /// <summary>
        /// 块尺寸
        /// </summary>
        public long size;
        /// <summary>
        /// 块结束位置（不包含）
        /// </summary>
        public long end
        {
            get
            {
                return size == long.MaxValue ? size : (pos + size);
            }
        }
    }

    public struct BagHead
    {
        public long fmtVersion;                          //文件格式版本（不同版本不兼容）
        public OSType platform;                       //平台
        public BranchType branch;                               //分支
        public long version;                               //版本号
        public long baseVersion;                           //基础版本号
        public int maxFileCount;                          //可存储的最大文件数
        public int curFileCount;                          //当前存储了的文件数

        public const int ByteSize = 34;

        public void Read(BinaryReader reader )
        {
            fmtVersion = reader.ReadInt64();
            platform = (OSType)reader.ReadByte();
            branch = (BranchType)reader.ReadSByte();
            version = reader.ReadInt64();
            baseVersion = reader.ReadInt64();
            maxFileCount = reader.ReadInt32();
            curFileCount = reader.ReadInt32();
        }
        public void Write(BinaryWriter writer )
        {
            writer.Write(fmtVersion);
            writer.Write((byte)platform);
            writer.Write((sbyte)branch);
            writer.Write(version);
            writer.Write(baseVersion);
            writer.Write(maxFileCount);
            writer.Write(curFileCount);
        }

        public string branchName
        {
            get
            {
                switch(branch)
                {
                    case BranchType.unknown:return "unknown";
                    case BranchType.trunk: return "trunk";
                    default:return "s" + (int)branch;
                }
            }
        }
    }
    /// <summary>
    /// 文件包：多文件集合，用于统一管理，存储大量小文件
    /// </summary>
    public class FileBag
    {
        public const long FileSystemVersion = 201511141530;
        const string RemovedMark = "~%dElFiLe%~";
        const string Hash2NameFile = "~%hAsH2nAme%~";

        /// <summary>
        /// 从文件创建一个文件包
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns>文件包,文件格式不对，返回空</returns>
        public static FileBag CreateFromFile(string path)
        {
            return CheckFileValid(path) ? new FileBag(path) : null;
        }
        /// <summary>
        /// 创建一个空的文件包<para>如果有同名文件会删除老的</para>
        /// </summary>
        /// <param name="path">文件包存储路径</param>
        /// <param name="contentSize">目录尺寸，最大可存储的文件数量越多</param>
        /// <param name="totalSize">预计的文件总尺寸</param>
        /// <returns></returns>
        public static FileBag CreateEmpty(string path, int maxFileCount, int totalSize)
        {
            return new FileBag(path, maxFileCount, totalSize);
        }
        /// <summary>
        /// 确认文件是否可用
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool CheckFileValid(string path )
        {
            if( File.Exists(path))
            {
                FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
                BinaryReader reader = new BinaryReader(file);
                long fileVersion = reader.ReadInt64();
                reader.Close();
                file.Close();
                return fileVersion == FileSystemVersion;
            }
            return false;
        }

        int _InnerFileCount =1;                     //内部文件数量

        BagHead _Head;                              //文件头

        int _ContentAreaSize;                       //文件目录区尺寸

        List<FileRecord?> _ContentList;              //文件目录区列表
        LinkedList<StorageBlock> _EmptyStorage;      //文件存储区状态

        Dictionary<long, FileRecord> _Contents;      //文件目录
        Dictionary<long, string> _Hash2Name;         //hash值到名称的字典
        string _Path;

        FileStream _IO;                              //相关读写操作接口
        BinaryReader _Reader;
        BinaryWriter _Writer;

        string _ReadingFile;                        //当前正在读取的文件的名称
        long _ReadedLength;                         //当前正在读取的文件已经读取的大小
        long _ReadingLength;                        //当前正在读取的文件的总大小

        private FileBag(string path)
        {
            _Path = path;
            _IO = new FileStream(_Path, FileMode.Open, FileAccess.ReadWrite);
            _Writer = new BinaryWriter(_IO);
            _Reader = new BinaryReader(_IO);

            _Head = new BagHead();
            _Head.Read(_Reader);
            _ContentAreaSize = _Head.maxFileCount * FileRecord.ByteSize;

            byte[] test = _Reader.ReadBytes(_ContentAreaSize);
            _IO.Position = BagHead.ByteSize;

            _Contents = new Dictionary<long, FileRecord>();
            FileRecord rec = new FileRecord();
            int readFile = 0;
            for (var idx = 0; idx < _Head.maxFileCount && readFile < _Head.curFileCount; ++idx)
            {
                MoveToContent(idx);
                rec.Read(_Reader);
                if (rec.nameHash != 0)
                {
                    if(!_Contents.ContainsKey(rec.nameHash))
                    {
                        _Contents.Add(rec.nameHash, rec);
                        ++readFile;
                    }
                    else
                    {
                        throw new InvalidOperationException(string.Format("Same file in content!hash:{0}, pos:{1}, size:{2}", rec.nameHash, rec.pos, rec.size));
                    }
                    
                }
            }

            _Hash2Name = new Dictionary<long, string>();
            byte[] data = ReadFile(Hash2NameFile);
            if( data != null )
            {
                MemoryStream file = new MemoryStream(data, false);
                BinaryReader reader = new BinaryReader(file);
                while( file.Position < file.Length )
                {
                    long hash = reader.ReadInt64();
                    int len = reader.ReadInt32();
                    byte[] nameData = reader.ReadBytes(len);
                    string name = Encoding.UTF8.GetString(nameData);
                    
                    if(hash !=0 && name != null )
                    {
                        _Hash2Name.Add(hash, name);
                    }
                }   
            }
            data = null;
        }
        private FileBag(string path, int maxFileCount, int totalSize)
        {
            _Path = path;
            if (File.Exists(_Path))
            {
                File.Delete(_Path);
            }

            //可记录的最大条目数量
            _Head = new BagHead();
            _Head.fmtVersion = FileSystemVersion;
            _Head.branch = BranchType.unknown;
            _Head.maxFileCount = maxFileCount + _InnerFileCount;
            _Head.curFileCount = 0;

            _ContentAreaSize = _Head.maxFileCount * FileRecord.ByteSize;

            int expectSize = _ContentAreaSize + totalSize;

            _IO = new FileStream(_Path, FileMode.CreateNew, FileAccess.ReadWrite);
            _IO.SetLength(expectSize + BagHead.ByteSize);   //预定包大小
            _Reader = new BinaryReader(_IO);
            _Writer = new BinaryWriter(_IO);
            _Head.Write(_Writer);
            _Writer.Flush();

            _Hash2Name = new Dictionary<long, string>();
            _Contents = new Dictionary<long, FileRecord>();
        }
        /// <summary>
        /// 当前包中的文件数量
        /// </summary>
        public int fileCount
        {
            get
            {
                return _Head.curFileCount <= 0 ? 0 : _Head.curFileCount - _InnerFileCount;
            }
        }
        /// <summary>
        /// 包中可存储的最大文件数量
        /// </summary>
        public int maxCount
        {
            get
            {
                return _Head.maxFileCount - _InnerFileCount;
            }
        }
        /// <summary>
        /// 包是否满了
        /// </summary>
        public bool isFull
        {
            get
            {
                return _Head.curFileCount >= _Head.maxFileCount;
            }
        }

        public BagHead info
        {
            get
            {
                BagHead ret = _Head;
                ret.curFileCount -= _InnerFileCount;
                ret.curFileCount = Math.Max(0, ret.curFileCount);
                ret.maxFileCount -= _InnerFileCount;
                return ret;
            }
        }

        public string path
        {
            get
            {
                return _Path;
            }
        }

        public void SetInfo( OSType platform, BranchType branch, long version, long baseVersion )
        {
            _Head.platform = platform;
            _Head.branch = branch;
            _Head.version = version;
            _Head.baseVersion = baseVersion;
            _IO.Position = 0;
            _Head.Write(_Writer);
        }
        public string[] GetAllFileNames()
        {
            long Hash2NameFileHash = GetNameHash(Hash2NameFile);

            string[] ret = new string[fileCount];
            int idx = 0;
            foreach( var item in _Contents )
            {
                if( item.Key == Hash2NameFileHash)
                {
                    continue;
                }
                string name = "NoName:"+item.Key.ToString();
                _Hash2Name.TryGetValue(item.Key, out name);
                ret[idx] = name;
                ++idx;
            }
            return ret;
        }

        string GetFileName(long hash )
        {
            string name;
            if(_Hash2Name.TryGetValue(hash, out name))
            {
                return name;
            }
            return "Unknown";
        }
        /// <summary>
        /// 是否包含文件
        /// </summary>
        /// <param name="name">文件名称</param>
        public bool ContainFile(string name)
        {
            return _Contents.ContainsKey(GetNameHash(name));
        }
        /// <summary>
        /// 确认文件类型
        /// </summary>
        /// <param name="data">文件数据</param>
        /// <returns>文件类型</returns>
        public FileType CheckFileType(byte[] data, int size)
        {
            if(size > RemovedMark.Length )
            {
                return FileType.Normal;
            }
            string mark = Encoding.ASCII.GetString(data,0, size);
            switch(mark)
            {
                case RemovedMark:
                    return FileType.Removed;
            }
            return FileType.Normal;
        }
        /// <summary>
        /// 添加特殊类型文件
        /// </summary>
        /// <param name="name">文件名称</param>
        /// <param name="type">文件类型</param>
        public void AddFile(string name, FileType type )
        {
            string mark = null;
            switch( type )
            {
                case FileType.Removed:
                    mark = RemovedMark;
                    break;
                default:
                    return;
            }
            byte[] data = Encoding.ASCII.GetBytes(mark);
            AddFile(name, data);
        }

        public void AddFile(string name, string path )
        {
            //读取文件
            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
            byte[] data = new byte[file.Length];
            file.Read(data, 0, data.Length);
            file.Close();

            AddFile(name, data);
        }


        public void AddFile(string name, byte[] fileData )
        {
            if (isFull)
            {
                throw new InvalidOperationException(string.Format("File bag is full, this bag cant store {0} files!", name));
            }
            long nameHash = GetNameHash(name);
            if (_Contents.ContainsKey(nameHash))
            {
                throw new InvalidOperationException(string.Format("Exist same hashcode file! {0} & {1}", name, GetFileName(nameHash)));
            }
            //写入包
            var to = FindValidBlock(fileData.Length);
            long dataPos = to == null ? 0 : to.Value.pos;
            MoveToStorage(dataPos);
            _IO.Write(fileData, 0, fileData.Length);
            MarkBlockUsed(to, fileData.Length);
            //写入文件目录
            FileRecord record;
            record.nameHash = nameHash;
            record.pos = dataPos;
            record.size = fileData.Length;

            int contentIdx = 0;
            for (; contentIdx < _ContentList.Count; ++contentIdx)
            {
                if (_ContentList[contentIdx] == null)
                {
                    break;
                }
            }

            MoveToContent(contentIdx);
            _Writer.Write(record.nameHash);
            _Writer.Write(record.pos);
            _Writer.Write(record.size);
            _Writer.Flush();

            ++_Head.curFileCount;
            _IO.Position = 0;
            _Head.Write(_Writer);

            //更新文件索引
            SetContentList(contentIdx, record);
            _Contents.Add(record.nameHash, record);
            _Hash2Name.Add(record.nameHash, name);
        }

        public bool DelFile(string name )
        {
            long nameHash = GetNameHash(name);
            if ( !_Contents.ContainsKey(nameHash))
            {//没有文件
                return false;
            }
            //删除索引
            _Contents.Remove(nameHash);
            _Hash2Name.Remove(nameHash);
            //删除目录（数据）
            int idx = _ContentList.FindIndex(item => item != null && item.Value.nameHash == nameHash);
            if (idx != -1)
            {
                var rec = _ContentList[idx];

                SetContentList(idx, null);
                MoveToContent(idx);
                FileRecord.zero.Write(_Writer);

                --_Head.curFileCount;
                _IO.Position = 0;
                _Head.Write(_Writer);
                return true;
            }
            throw new InvalidOperationException(string.Format("Del file failed!{0}", name));
        }
        /// <summary>
        /// 一次性读取文件到内存
        /// </summary>
        /// <param name="name">文件名称</param>
        /// <returns>读取好的文件数据</returns>
        public byte[] ReadFile(string name)
        {
            long nameHash = GetNameHash(name);
            FileRecord rec;
            if (!_Contents.TryGetValue(nameHash, out rec))
            {
                return null;
            }
            MoveToStorage(rec.pos);
            if( rec.size > 300 *1024*1024 || rec.size < 0)
            {
                throw new InvalidOperationException(string.Format("ERROR: file size invalid {0}", rec.size));
            }

            byte[] buff = new byte[rec.size];
            _IO.Read(buff, 0, buff.Length);
            return buff;
        }
        /// <summary>
        /// 开始读取文件，配合ProcessReadFile，EndReadFile使用
        /// </summary>
        /// <param name="name">文件名</param>
        public void BeginReadFile(string name )
        {
            long nameHash = GetNameHash(name);
            FileRecord rec;
            if (!_Contents.TryGetValue(nameHash, out rec))
            {
                return;
            }
            if (rec.size > 300 * 1024 * 1024 || rec.size < 0)
            {
                throw new InvalidOperationException(string.Format("ERROR: file size invalid {0}", rec.size));
            }
            MoveToStorage(rec.pos);
            _ReadingFile = name;
            _ReadedLength = 0;
            _ReadingLength = rec.size;
        }
        /// <summary>
        /// 读取文件，配合BeginReadFile，EndReadFile使用
        /// </summary>
        /// <param name="buff">缓冲区</param>
        /// <returns>本次读取的大小</returns>
        public int ProcessReadFile(byte[] buff)
        {
            long remainSize = _ReadingLength - _ReadedLength;
            int readSize = remainSize > buff.Length ? buff.Length : (int)remainSize;
            _IO.Read(buff, 0, readSize);
            _ReadedLength += readSize;
            return readSize;
        }
        /// <summary>
        /// 结束读取文件，配合BeginReadFile，ProcessReadFile使用
        /// </summary>
        /// <param name="name"></param>
        public void EndReadFile(string name )
        {
            if( name != _ReadingFile )
            {
                throw new InvalidOperationException(string.Format("ERROR: Now reading file is {0}， end read failed!", _ReadingFile));
            }
            _ReadingFile = null;
            _ReadedLength = 0;
            _ReadingLength = 0;
        }

        public bool Exist(string name )
        {
            long nameHash = GetNameHash(name);
            return _Contents.ContainsKey(nameHash);
        }

        public bool canWrite
        {
            get
            {
                return _EmptyStorage != null;
            }
        }
        /// <summary>
        /// 开始修改文件包
        /// </summary>
        public void BeginWrite()
        {
            //初始化目录区状态
            _ContentList = new List<FileRecord?>(_Head.maxFileCount);
            int hasFind = 0;
            for( int idx = 0; idx < _Head.maxFileCount && hasFind < _Head.curFileCount; ++idx )
            {
                MoveToContent( idx );
                FileRecord rec = new FileRecord();
                rec.Read(_Reader);

                if( rec.nameHash != 0 )
                {
                    SetContentList(idx, rec);
                    ++hasFind;
                }
            }

            //初始化存储区状态
            _EmptyStorage = new LinkedList<StorageBlock>();
            foreach (var file in _Contents)
            {
               MarkBlockUsed(file.Value.pos, file.Value.size);
            }
        }
        /// <summary>
        /// 结束修改文件包
        /// </summary>
        public void EndWrite()
        {
            if( _Hash2Name.Count != 0 )
            {
                DelFile(Hash2NameFile);
                MemoryStream nhFile = new MemoryStream();
                BinaryWriter writer = new BinaryWriter(nhFile);
                foreach ( var item in _Hash2Name )
                {
                    writer.Write(item.Key);
                    byte[] nameData = Encoding.UTF8.GetBytes(item.Value);
                    writer.Write(nameData.Length);
                    writer.Write(nameData, 0, nameData.Length);
                }
                writer.Flush();
                writer.Close();
                nhFile.Close();
                byte[] data = nhFile.ToArray();
                AddFile(Hash2NameFile, data);
            }
            
            _ContentList = null;
            _EmptyStorage = null;
        }


        public void Dispose()
        {
            _IO.Flush();
            _IO.Close();
        }

        LinkedListNode<StorageBlock> FindValidBlock(long size)
        {
            var block = _EmptyStorage.First;
            while( !( block == null || block.Value.size == 0 || block.Value.size >= size ) )
            {
                block = block.Next;
            }
            return block;
        }

        private void CheckZero(StorageBlock block)
        {
            if( block.size == 0 )
            {
                //Debug.Log("zero");
            }
        }
        void MarkBlockUsed(long pos, long size)
        {
            if (_EmptyStorage.Count == 0)
            {
                if (pos > 0)
                {
                    StorageBlock pre;
                    pre.pos = 0;
                    pre.size = pos;
                    _EmptyStorage.AddLast(pre);
                    //CheckZero(pre);
                }
                StorageBlock after;
                after.pos = pos + size;
                after.size = long.MaxValue;
                _EmptyStorage.AddLast(after);
                //CheckZero(after);
                return;
            }
            long end = pos + size;
            for (var block = _EmptyStorage.First; block != null; block = block.Next)
            {
                if (pos >= block.Value.pos && pos < block.Value.end)
                {
                    if (block.Value.size < size || end > block.Value.end)
                    {
                        throw new InvalidOperationException(string.Format("Can't provide storage (size:{0}) at pos {1}, max allowed size is {2}", size, pos, block.Value.size));
                    }
                    else
                    {
                        StorageBlock from = block.Value;
                        if (pos > from.pos)
                        {
                            StorageBlock pre;
                            pre.pos = from.pos;
                            pre.size = pos - from.pos;
                            _EmptyStorage.AddBefore(block, pre);
                            //CheckZero(pre);
                        }
                        
                        if(end < from.end )
                        {
                            StorageBlock after;
                            after.pos = end;
                            after.size = from.size == long.MaxValue ? long.MaxValue : from.end - end;
                            _EmptyStorage.AddAfter(block, after);
                            //CheckZero(after);
                        }
                    }
                    _EmptyStorage.Remove(block);
                    return;
                }
            }

            throw new InvalidOperationException("Mark storage as used failed!");
        }
        
        void MarkBlockUsed(LinkedListNode<StorageBlock> from, long size )
        {
            if( from == null )
            {//未指定从哪块空闲区分配
                if(_EmptyStorage.Count == 0 )
                {//整个存储区都是空闲的
                    StorageBlock block;
                    block.pos = size;
                    block.size = long.MaxValue;     //到结尾
                    _EmptyStorage.AddLast(block);
                    //CheckZero(block);
                }
                else
                {//需要指定
                    throw new InvalidOperationException("Storage is not empty, must indicate which block you want to use!");
                }
                return;
            }
            if( from.Value.size < size )
            {//指定的区域不够大
                throw new InvalidOperationException(string.Format("Indicated block which has size {0} isn't enough used for storage size {1}", from.Value.size, size));
            }
            if( from.Value.size == size )
            {//刚好够用
                _EmptyStorage.Remove(from);
            }
            else
            {//调整可用尺寸
                StorageBlock block = from.Value;
                block.pos += size;
                if( block.size != long.MaxValue )
                {
                    block.size -= size;
                }
                from.Value = block;
                //CheckZero(block);
            }
        }

        void SetContentList(int idx, FileRecord? rec )
        {
            while( idx >= _ContentList.Count )
            {
                _ContentList.Add(null);
            }

            _ContentList[idx] = rec;
        }
        void MoveToContent( int contentIdx )
        {
            _IO.Position = contentIdx * FileRecord.ByteSize + BagHead.ByteSize;
        }

        void MoveToStorage(long posInStorage )
        {
            long pos = posInStorage + BagHead.ByteSize + _ContentAreaSize;
            if( pos > _IO.Length )
            {
                throw new InvalidOperationException(string.Format("非法位置，posInStorage:{0} BagHeadSize:{1} _ContentAreaSize:{2} pos:{3} length:{4}", posInStorage, BagHead.ByteSize, _ContentAreaSize, pos, _IO.Length));
            }
            _IO.Position = pos;
        }

        public static long GetNameHash(string name )
        {
            long seed = 131;//31131131313131131313etc..
            long hash = 0;
            for (int i = 0; i < name.Length; i++)
                hash = (hash * seed) + name[i];
            return hash;
        }
    }
}
