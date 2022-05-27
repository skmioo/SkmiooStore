using System.Collections.Generic;
using System.IO;
using System;
using System.Text;
using SevenZip.Compression.LZMA;
using UnityEngine;

namespace DRLoader
{
    public class SevenZipAsset
    {
        public static SevenZipAsset CreateFromFile( string path)
        {
            if (!File.Exists(path))
            {
                throw new InvalidOperationException("can't find file:" + path);
            }

            FileStream asset = new FileStream(path, FileMode.Open);
            byte[] srcData = new byte[asset.Length];
            asset.Read(srcData, 0, srcData.Length);
            asset.Close();
            Debug.Log("Load 7Zip Data:"+path);
            return CreateFromMemory(srcData);
        }
        public static SevenZipAsset CreateFromMemory(byte[] data)
        {
            return new SevenZipAsset(data);
        }


        private string[] _Names;
        /// <summary>
        /// 是否为多重压缩
        /// <para>是：单文件压缩然后再整体压缩</para>
        /// <para>否：只是整体压缩，单个文件数据没有压</para>
        /// </summary>
        bool _DualCompression = false;
        /// <summary>
        /// 文件数据
        /// </summary>
        Dictionary<string, byte[]> _files = new Dictionary<string, byte[]>();
        public SevenZipAsset(byte[] srcData)
        {
            Encoding coder = Encoding.UTF8;
            byte[] deData = SevenZipHelper.Decompress(srcData);
            MemoryStream mm = new MemoryStream(deData);
            BinaryReader reader = new BinaryReader(mm);
            _DualCompression = reader.ReadByte() == 1;
            uint fileCount = reader.ReadUInt32();
            for( uint idx = 0; idx < fileCount; ++idx )
            {
                int nameSize = reader.ReadInt32();
                byte[] nameData = reader.ReadBytes(nameSize);
                string fileName = coder.GetString(nameData);
                int dataSize = reader.ReadInt32();
                byte[] unzipData = reader.ReadBytes(dataSize);
                _files.Add(fileName.ToLower(), unzipData);
            }
            reader.Close();
            mm.Close();
        }

        public string[] GetAllFileNames()
        {
            if (_Names == null )
            {
                List<string> temp = new List<string>();
                foreach( var name in _files.Keys )
                {
                    temp.Add(name);
                }
                _Names = temp.ToArray();
            }
            return _Names;
        }

        private byte[] _GetFileData(string name, bool remove)
        {
            name = name.ToLower();
            byte[] ret;
            if( _files.TryGetValue(name, out ret))
            {
                if (remove)
                    _files.Remove(name);
                return ret;
            }
            else
            {
                var enu = _files.GetEnumerator();
                while(enu.MoveNext())
                {
                    var cur = enu.Current;
                    if( name == Path.GetFileName(cur.Key))
                    {
                        ret = cur.Value;
                        if (remove)
                            _files.Remove(cur.Key);
                        return ret;
                    }
                }
            }
            return null;
        }

        public byte[] GetFileData(string name, bool remove)
        {
            var b = _GetFileData(name, remove);
            if (b != null && _DualCompression )
            {
                b = SevenZipHelper.Decompress(b);
            }
            return b;
        }
    }

    /// <summary>
    /// 文件列表打包7ZIP工具
    /// </summary>
    public class SevenZipAssetBuild
    {
        private const string TextFileExtensions = "xml,lua,txt";
        private int _SamePos;
        Dictionary<string, string> _FileList = new Dictionary<string, string>();
        /// <summary>
        /// 压缩并保存到文件
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="dualCmp">是否启用双重压缩</param>
        public void Build(string path, bool dualCmp )
        {
            if( _FileList.Count == 0 )
            {
                Debug.LogWarningFormat("Compress file list error: source file list is empty! --{0}", path);
                return;
            }
            if( File.Exists(path))
            {
                File.Delete(path);
            }
            Encoding coder = Encoding.GetEncoding(65001);

            string tempPath = path + ".temp";

            if( File.Exists(tempPath))
            {
                File.Delete(tempPath);
            }
            FileStream outAsset = new FileStream(tempPath, FileMode.CreateNew);
            BinaryWriter write = new BinaryWriter(outAsset);
            write.Write(dualCmp ? (byte)1 : (byte)0);   //是否双重压缩标识
            write.Write((int)_FileList.Count);          //文件数量标识
            foreach( var file in _FileList )
            {
                if( !File.Exists(file.Key))
                {
                    write.Close();
                    outAsset.Close();
                    File.Delete(path);
                    throw new InvalidOperationException(string.Format("Compress file list error: source file {0} not exist! --{1}", file.Key, path));
                }
                FileStream srcFile = new FileStream(file.Key, FileMode.Open);
                byte[] srcFileData = new byte[ srcFile.Length];
                srcFile.Read(srcFileData, 0, srcFileData.Length);
                string extension = Path.GetExtension(file.Key);
                if (extension == ".lua" )
                {
                    if (srcFileData.Length >= 3)
                    {//判断bom，删除（mac下不支持bom）
                        if (srcFileData[0] == 0xEF
                            && srcFileData[1] == 0xBB
                            && srcFileData[2] == 0xBF)
                        {//utf8 bom
                            byte[] tmp = new byte[srcFileData.Length - 3];
                            Buffer.BlockCopy(srcFileData, 3, tmp, 0, tmp.Length);
                            srcFileData = tmp;
                        }
                    }
                }
                
                srcFile.Close();

                if( dualCmp )
                {
                    srcFileData = SevenZipHelper.Compress(srcFileData);
                }

                byte[] nameData = coder.GetBytes(file.Value == null ? file.Key : file.Value);
                write.Write((int)nameData.Length);
                write.Write(nameData);
                write.Write((int)srcFileData.Length);
                write.Write(srcFileData);
            }
            write.Flush();
            write.Close();
            outAsset.Close();

            FileStream tempFile = new FileStream(tempPath, FileMode.Open);
            byte[] srcData = new byte[tempFile.Length];
            tempFile.Read(srcData, 0, srcData.Length);
            tempFile.Close();

            byte[] outData = SevenZipHelper.Compress(srcData);
            FileStream outFile = new FileStream(path, FileMode.CreateNew);
            outFile.Write(outData, 0, outData.Length);
            outFile.Flush();
            outFile.Close();

            File.Delete(tempPath);
        }

        /// <summary>
        /// 添加文件
        /// </summary>
        /// <param name="fileList">文件路径列表</param>
        /// <param name="fileIDs">文件标识（读取时使用此ID来读取文件）</param>
        public void AddFileList(string[] fileList, string[] fileIDs)
        {
            if( fileIDs != null && fileIDs.Length != fileList.Length )
            {
                Debug.LogErrorFormat("指定了文件的标识ID，但与文件数量不匹配! fileList:{0} fileIDs:{1}", fileList.Length, fileIDs.Length);
                return;
            }
            for(var idx = 0; idx < fileList.Length; ++idx )
            {
                string path = fileList[idx];
                string id = fileIDs == null ? path : fileIDs[idx];
                if(_FileList.ContainsKey(path))
                {
                    Debug.LogWarningFormat("has exist file:{0}", path);
                }
                else
                {
                    _FileList.Add(path, id);
                }
            }
        }

        /// <summary>
        /// 添加文件
        /// </summary>
        /// <param name="fileList">文件路径列表，文件标识也为路径</param>
        public void AddFileList(string[] fileList )
        {
            AddFileList(fileList, null);
        }



        /// <summary>
        /// 所有打包的文件的路径
        /// </summary>
        //public string[] fileList
        //{
        //    set
        //    {
        //        foreach( string path in value )
        //        {
        //            if( _FileList.Contains( path ) )
        //            {
        //                Debug.LogWarning("7Zip Compress: same file "+path);
        //            }
        //            else
        //            {
        //                _FileList.Add(path);
        //            }
        //        }


        //            string[] names = value;
        //            _SamePos = -1;
        //            bool goon = names.Length > 1;
        //            while(goon)
        //            {
        //                ++_SamePos;
        //                char cur = names[0][_SamePos];
        //                for (int nIdx = 1; nIdx < names.Length; ++nIdx)
        //                {
        //                    if (names[nIdx][_SamePos] != cur)
        //                    {
        //                        --_SamePos;
        //                        goon = false;
        //                        break;
        //                    }
        //                }
        //            }
        //    }
        //}

        //private string GetName(string path )
        //{
        //    return _SamePos == -1 ? path : path.Remove(0, _SamePos + 1);
        //}
    }
}
