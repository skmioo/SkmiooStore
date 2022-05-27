using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace UnityEngine
{
    /// <summary>
    /// 一个字节流，提供反序列化，序列化操作
    /// </summary>
    public class UnityByteBuff
    {
        byte[] mBuff;
        int mPos;
        int mSize;
        public UnityByteBuff(int cap =256)
        {
            mBuff = new Byte[cap];
            mPos = 0;
            mSize = 0;
        }
        public UnityByteBuff(byte[] b)
        {
            mBuff = b;
            mPos = 0;
            mSize = b.Length;
        }
        public UnityByteBuff Clone()
        {
            var ba = new UnityByteBuff(mSize);
            ba.WriteBytes(mBuff, 0, mSize);
            ba.position = mPos;
            return ba;
        }
        /// <summary>
        /// 清理所有数据
        /// </summary>
        public void Clear()
        {
            mPos = 0;
            mSize = 0;
        }
        /// <summary>
        /// 总的字节数
        /// </summary>
        public int size
        {
            get { return mSize; }
            set
            {
                mSize = value < 0 ? 0 : value;
                Alloc(mSize);
                mPos = mPos > mSize ? mSize : mPos;
            }
        }
        /// <summary>
        /// 当前预期可装载的总字节数
        /// </summary>
        public int capacity
        {
            get { return mBuff.Length; }
            set { Alloc(value); }
        }
        /// <summary>
        /// 当前读取|写入的位置
        /// </summary>
        public int position
        {
            get { return mPos; }
            set { mPos = value < mSize ? value : mSize; }
        }
        /// <summary>
        /// 当前可读的剩余容量
        /// </summary>
        public int bytesAvailable
        {
            get { return mSize - mPos; }
        }
        public int ReadBytes(Byte[] dstBuf, int dstOffset, int len)
        {
            len = len <= 0 ? bytesAvailable : len;
            CheckAvaliable(len);
            Buffer.BlockCopy(mBuff, mPos, dstBuf, dstOffset, len);
            mPos += len;
            return len;
        }
        public int ReadBytes(UnityByteBuff dstBuf, int len)
        {
            len = len <= 0 ? bytesAvailable : len;
            CheckAvaliable(len);
            dstBuf.WriteBytes(this, mPos, len);
            mPos += len;
            return len;
        }
        public Boolean ReadBool()
        {
            CheckAvaliable(1);
            return mBuff[mPos++] != 0;
        }
        public Char ReadChar()
        {
            CheckAvaliable(1);
            return (Char)mBuff[mPos++];
        }
        public Byte ReadByte()
        {
            CheckAvaliable(1);
            return mBuff[mPos++];
        }
        public Byte ReadBYTE()
        {
            return ReadByte();
        }
        public UInt16 ReadUshort()
        {
            CheckAvaliable(2);
            ushort ret = BitConverter.ToUInt16(mBuff, mPos);
            mPos += 2;
            return ret;
        }
        public short ReadShort()
        {
            CheckAvaliable(2);
            short ret = BitConverter.ToInt16(mBuff, mPos);
            mPos += 2;
            return ret;
        }
        public UInt16 ReadWORD()
        {
            return ReadUshort();
        }
        /// <summary>
        /// 读取3个字节表示的int
        /// </summary>
        /// <returns></returns>
        public Int32 ReadTriple()
        {
            CheckAvaliable(3);
            uint b1 = mBuff[mPos++];
            uint b2 = mBuff[mPos++];
            uint b3 = mBuff[mPos++];
            uint flag = b3 & (uint)0x80;
            b3 &= 0x7f;
            int val = (int)(b1 | (b2 << 8) | (b3 << 16));
            return flag == 0 ? val : -val;
        }
        public uint ReadDWORD()
        {
            CheckAvaliable(4);
            uint ret = BitConverter.ToUInt32(mBuff, mPos);
            mPos += 4;
            return ret;
        }
        public int ReadInt()
        {
            CheckAvaliable(4);
            int ret = BitConverter.ToInt32(mBuff, mPos);
            mPos += 4;
            return ret;
        }
        public UInt64 ReadQWORD()
        {
            CheckAvaliable(8);
            UInt64 ret = BitConverter.ToUInt64(mBuff, mPos);
            mPos += 8;
            return ret;
        }
        public float ReadFloat()
        {
            CheckAvaliable(4);
            float f = BitConverter.ToSingle(mBuff, mPos);
            mPos += 4;
            return f;
        }
        public string ReadString4(int codePage = -1)
        {
            uint len = ReadDWORD();
            if (len == 0)
                return "";
            return ReadString((int)len, codePage);
        }
        public string ReadString2(int codePage = -1)
        {
            int len = (int)ReadWORD();
            if (len == 0)
                return "";
            return ReadString(len, codePage);
        }
        public string ReadString1(int codePage = -1)
        {
            int len = (int)ReadByte();
            if (len == 0)
                return "";
            return ReadString(len, codePage);
        }
        public string ReadName(int codePage = -1)
        {
            return ReadString1(codePage);
        }
        public String ReadString(int bytesNum, int codePage)
        {
            if (bytesNum <= 0)
                return "";
            CheckAvaliable(bytesNum);
            Encoding coder = codePage < 0 ? Encoding.UTF8 : Encoding.GetEncoding(codePage);
            string ret = coder.GetString(mBuff, mPos, bytesNum);
            mPos += bytesNum;
            return ret;
        }
        public Byte PeekByte(int pos)
        {
            return pos < mSize ? mBuff[pos] : (Byte)0;
        }
        public ushort PeekWORD(int pos)
        {
            if (pos + 1 < mSize)
            {
                return BitConverter.ToUInt16(mBuff, pos);
            }
            else
            {
                return 0;
            }
        }
        public UInt32 PeekDWORD(int pos)
        {
            if (pos + 3 < mSize)
            {
                return BitConverter.ToUInt32(mBuff, pos);
            }
            else
            {
                return 0;
            }
        }
        public String PeekString(int bytesNum, int codePage, int pos)
        {
            return PeekString(bytesNum, pos, Encoding.GetEncoding(codePage));
        }
        public string PeekString(int bytesNum, int pos, Encoding coder)
        {
            bytesNum = bytesNum <= 0 ? bytesAvailable : bytesNum;
            return coder.GetString(mBuff, pos, bytesNum);
        }
        public int WriteBytes(UnityByteBuff buff, int srcOffset, int len)
        {
            len = len <= 0 ? buff.size - srcOffset : len;
            Alloc(mPos + len);
            Buffer.BlockCopy(buff.mBuff, srcOffset, mBuff, mPos, len);
            mPos += len;
            mSize = Math.Max(mSize, mPos);
            return len;
        }
        public int WriteBytes(Byte[] buff, int srcOffset, int len)
        {
            len = len <= 0 ? buff.Length - srcOffset : len;
            Alloc(mPos + len);
            Buffer.BlockCopy(buff, srcOffset, mBuff, mPos, len);
            mPos += len;
            mSize = Math.Max(mSize, mPos);
            return len;
        }
        public void WriteByte(Byte val)
        {
            Alloc(mPos + 1);
            mBuff[mPos++] = val;
            mSize = Math.Max(mSize, mPos);
        }
        public void WriteBYTE(Byte val)
        {
            WriteByte(val);
        }
        public void WriteChar(Char val)
        {
            Alloc(mPos + 1);
            mBuff[mPos++] = (Byte)val;
            mSize = Math.Max(mSize, mPos);
        }
        public void WriteBool(bool val)
        {
            WriteBYTE(val ? (byte)1 : (byte)0);
        }
        public void WriteUshort(ushort val)
        {
            Alloc(mPos + 2);
            mBuff[mPos++] = (Byte)(val & 0x00ff);
            mBuff[mPos++] = (Byte)((val >> 8) & 0x00ff);
            mSize = Math.Max(mSize, mPos);
        }
        public void WriteWORD(ushort val)
        {
            WriteUshort(val);
        }
        public void WriteShort(short val)
        {
            Alloc(mPos + 2);
            mBuff[mPos++] = (Byte)(val & 0x00ff);
            mBuff[mPos++] = (Byte)((val >> 8) & 0x00ff);
            mSize = Math.Max(mSize, mPos);
        }
        public void WriteInt(int val)
        {
            Alloc(mPos + 4);
            mBuff[mPos++] = (Byte)(val & 0x000000ff);
            mBuff[mPos++] = (Byte)((val >> 8) & 0x000000ff);
            mBuff[mPos++] = (Byte)((val >> 16) & 0x000000ff);
            mBuff[mPos++] = (Byte)((val >> 24) & 0x000000ff);
            mSize = Math.Max(mSize, mPos);
        }
        public void WriteDWORD(UInt32 val)
        {
            Alloc(mPos + 4);
            mBuff[mPos++] = (Byte)(val & 0x00ff);
            mBuff[mPos++] = (Byte)((val >> 8) & 0x000000ff);
            mBuff[mPos++] = (Byte)((val >> 16) & 0x000000ff);
            mBuff[mPos++] = (Byte)((val >> 24) & 0x000000ff);
            mSize = Math.Max(mSize, mPos);
        }
        public void WriteQWORD(UInt64 val)
        {
            Alloc(mPos + 8);
            mBuff[mPos++] = (Byte)(val & 0xfful);
            mBuff[mPos++] = (Byte)((val >> 8) & 0xfful);
            mBuff[mPos++] = (Byte)((val >> 16) & 0xfful);
            mBuff[mPos++] = (Byte)((val >> 24) & 0xfful);
            mBuff[mPos++] = (Byte)((val >> 32) & 0xfful);
            mBuff[mPos++] = (Byte)((val >> 40) & 0xfful);
            mBuff[mPos++] = (Byte)((val >> 48) & 0xfful);
            mBuff[mPos++] = (Byte)((val >> 56) & 0xfful);
            mSize = Math.Max(mSize, mPos);
        }
        public void WriteFloat(float val)
        {
            Alloc(mPos + 4);
            Byte[] fb = BitConverter.GetBytes(val);
            mBuff[mPos++] = fb[0];
            mBuff[mPos++] = fb[1];
            mBuff[mPos++] = fb[2];
            mBuff[mPos++] = fb[3];
            mSize = Math.Max(mSize, mPos);
        }
        /// <summary>
        /// 写入字符串【长度占用1个字节】
        /// </summary>
        /// <param name="str"></param>
        /// <param name="fixLen"></param>
        /// <param name="sizeOfStrLen"></param>
        /// <param name="codePage"></param>
        /// <returns></returns>
        public int WriteString1(string str, int codePage = -1)
        {
            int sizeOfStrLen = 1;
            int bytesLen = 0;
            if (str != null && str.Length > 0)
            {
                Encoding coder = codePage == -1 ? Encoding.UTF8 : Encoding.GetEncoding(codePage);
                int strLen = str.Length;
                int maxLen = coder.GetMaxByteCount(strLen);
                Alloc(mPos + sizeOfStrLen + maxLen);
                bytesLen = coder.GetBytes(str, 0, strLen, mBuff, mPos + sizeOfStrLen);
            }
            WriteByte((byte)bytesLen);
            mPos += bytesLen;
            mSize += bytesLen;
            return bytesLen + sizeOfStrLen;
        }

        /// <summary>
        /// 写入字符串【长度占用2个字节】
        /// </summary>
        /// <param name="str"></param>
        /// <param name="fixLen"></param>
        /// <param name="sizeOfStrLen"></param>
        /// <param name="codePage"></param>
        /// <returns></returns>
        public int WriteString2(string str, int codePage = -1)
        {
            int sizeOfStrLen = 2;
            int bytesLen = 0;
            if (str != null && str.Length > 0)
            {
                Encoding coder = codePage == -1 ? Encoding.UTF8 : Encoding.GetEncoding(codePage);
                int strLen = str.Length;
                int maxLen = coder.GetMaxByteCount(strLen);
                Alloc(mPos + sizeOfStrLen + maxLen);
                bytesLen = coder.GetBytes(str, 0, strLen, mBuff, mPos + sizeOfStrLen);
            }
            WriteUshort((ushort)bytesLen);
            mPos += bytesLen;
            mSize += bytesLen;
            return bytesLen + sizeOfStrLen;
        }

        public int WriteString4(string str, int codePage = -1)
        {
            int sizeOfStrLen = 4;
            int bytesLen = 0;
            if (str != null && str.Length > 0)
            {
                Encoding coder = codePage == -1 ? Encoding.UTF8 : Encoding.GetEncoding(codePage);
                int strLen = str.Length;
                int maxLen = coder.GetMaxByteCount(strLen);
                Alloc(mPos + sizeOfStrLen + maxLen);
                bytesLen = coder.GetBytes(str, 0, strLen, mBuff, mPos + sizeOfStrLen);
            }
            WriteDWORD((uint)bytesLen);
            mPos += bytesLen;
            mSize += bytesLen;
            return bytesLen + sizeOfStrLen;
        }


        /// <summary>
        /// 写入字符串
        /// </summary>
        /// <param name="str">待写入的字符串</param>
        /// <param name="fixLen">固定长度（不够用0填充），0表示变长，默认0</param>
        /// <param name="sizeOfStrLen">字符串之前表示字符串长度的数值占用的字节数，0表示不写入字符串长度</param>
        /// <param name="codePage">字符串写入编码，-1表示采用游戏默认编码</param>
        /// <returns>总写入字节，0表示没有写入任何数据或者写入失败</returns>
        public int WriteString(string str, int fixLen = 0, int sizeOfStrLen = 4, int codePage = -1)
        {
            sizeOfStrLen = sizeOfStrLen > 7 ? 8
                : sizeOfStrLen > 3 ? 4
                : sizeOfStrLen > 1 ? 2
                : sizeOfStrLen > 0 ? 1 : 0;
            int bytesLen = 0;
            if (str != null && str.Length > 0)
            {
                Encoding coder = codePage == -1 ? Encoding.UTF8 : Encoding.GetEncoding(codePage);
                int strLen = str.Length;
                int maxLen = coder.GetMaxByteCount(strLen);
                Alloc(mPos + sizeOfStrLen + maxLen);
                bytesLen = coder.GetBytes(str, 0, strLen, mBuff, mPos + sizeOfStrLen);
            }
            if (fixLen > 0 && fixLen < bytesLen)
            {//超过固定长度，放弃之前的写入
                return 0;
            }
            if (sizeOfStrLen == 8)
            {
                WriteQWORD((ulong)bytesLen);
            }
            else if (sizeOfStrLen == 4)
            {
                WriteDWORD((uint)bytesLen);
            }
            else if (sizeOfStrLen == 2)
            {
                WriteUshort((ushort)bytesLen);
            }
            else if (sizeOfStrLen == 1)
            {
                WriteByte((byte)bytesLen);
            }
            if (fixLen > bytesLen)
            {//需要填充
                WriteEmpty(fixLen - bytesLen);
            }
            else
            {//不需要填充
                fixLen = bytesLen;
            }
            mPos += fixLen;
            mSize += fixLen;
            return fixLen + sizeOfStrLen;
        }
        public int WriteEmpty(int bytes)
        {
            if (bytes > 0)
            {
                int dst = mPos + bytes;
                Alloc(dst);
                for (int i = mPos; i < dst; ++i)
                {
                    mBuff[i] = 0;
                }
                WriteExpandTo(dst);
            }
            return bytes;
        }
        private void WriteExpandTo(int pos)
        {
            mPos = pos < 0 ? 0 : pos > mBuff.Length ? mBuff.Length : pos;
            if (mPos > mSize)
                mSize = mPos;
        }
        public Byte[] ToBytes()
        {
            return mBuff;
        }
        public byte[] ToArray()
        {
            byte[] b = new byte[mSize];
            if (mSize > 0)
            {
                Buffer.BlockCopy(mBuff, 0, b, 0, b.Length);
            }
            return b;
        }
        private void Alloc(int size)
        {
            if (mBuff.Length < size)
            {
                size = size > 1024 * 1024 ? size : (int)(size * 1.5);
                Byte[] newBuf = new Byte[size];
                Buffer.BlockCopy(mBuff, 0, newBuf, 0, mSize);
                mBuff = newBuf;
            }
        }
        private void CheckAvaliable(int bytesToRead)
        {
            if (bytesToRead > bytesAvailable)
            {
                throw new Exception("ByteBuff out of RANGE!");
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < size; ++i)
                sb.Append(mBuff[i].ToString() + " ");
            return sb.ToString();
        }
    }
}
