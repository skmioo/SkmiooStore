using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.SharpZipLib.Zip.Compression;

namespace ICSharpCode.SharpZipLib.Zip
{
    /// <summary>
    /// 压缩器，保证线程安全
    /// </summary>
    public class Zipper
    {
        private Deflater _Deflater;
        public Zipper()
        {
            _Deflater = new Deflater();
        }
        /// <summary>
        /// 预估给定尺寸字节数最大的压缩尺寸
        /// </summary>
        /// <param name="len">压缩前字节长度</param>
        /// <returns>压缩后可能的最大字节数</returns>
        public int UpperBound(int len)
        {
            uint sourceLen = (uint)len;
            return (int)(sourceLen + (sourceLen >> 12) + (sourceLen >> 14) + (sourceLen >> 25) + 13);
        }
        /// <summary>
        /// 同步快速压缩
        /// </summary>
        /// <param name="inBuf">输入字节数组</param>
        /// <param name="inStart">输入字节数组去起始位置</param>
        /// <param name="inLen">输入字节长度</param>
        /// <param name="outBuf">输出字节容器</param>
        /// <param name="outStart">输出起始位置</param>
        /// <param name="outBufLen">可输出的最大长度</param>
        /// <returns>压缩后的尺寸，0表示压缩失败，或者是输出容器空间不足</returns>
        public int Compress(byte[] inBuf, int inStart, int inLen, byte[] outBuf, int outStart, int outBufLen)
        {
            if (inLen == 0)
            {//输入数据长度为0
                return 0;
            }
            _Deflater.Reset();
            if (_Deflater.IsNeedingInput)
            {
                _Deflater.SetInput(inBuf, inStart, inLen);
            }
            else
            {
                throw new SharpZipBaseException("Deflater error");
            }
            _Deflater.Finish();
            int outLen = _Deflater.Deflate(outBuf, outStart, outBufLen);
            if (outLen == 0)
            {
                throw new SharpZipBaseException("Deflater deflate error");
            }
            return outLen;
        }
    }

    /// <summary>
    /// 解压器，保证线程安全
    /// </summary>
    public class Unzipper
    {
        private Inflater _Inflater;
        public Unzipper()
        {
            _Inflater = new Inflater();
        }
        /// <summary>
        /// 解压给定数据
        /// </summary>
        /// <param name="inBuf">压缩数据</param>
        /// <param name="inStart">压缩数据起始位置</param>
        /// <param name="inLen">压缩数据长度</param>
        /// <param name="outBuf">解压后数据容器</param>
        /// <param name="outStart">解压后起始位置</param>
        /// <param name="outBufLen">解压容器容量</param>
        /// <returns>解压后数据大小，0表示解压失败</returns>
        public int Uncompress(byte[] inBuf, int inStart, int inLen, byte[] outBuf, int outStart, int outBufLen)
        {
            if (inLen == 0)
            {//输入数据长度为0
                return 0;
            }
            _Inflater.Reset();
            if (_Inflater.IsNeedingInput)
            {
                _Inflater.SetInput(inBuf, inStart, inLen);
            }
            else
            {
                throw new SharpZipBaseException("Inflater error");
            }
            int outLen = _Inflater.Inflate(outBuf, outStart, outBufLen);
            if (outLen == 0)
            {
                if (_Inflater.IsNeedingInput)
                {
                    throw new SharpZipBaseException("input not enough");
                }
                else if (_Inflater.IsNeedingDictionary)
                {
                    throw new SharpZipBaseException("inflater need dic");
                }
                else if (_Inflater.IsFinished)
                {
                    throw new SharpZipBaseException("odd inflate");
                }
            }
            return outLen;
        }
    }
}
