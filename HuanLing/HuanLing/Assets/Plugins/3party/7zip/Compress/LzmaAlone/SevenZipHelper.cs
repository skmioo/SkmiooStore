using System;
using System.IO;


namespace SevenZip.Compression.LZMA
{
    public static class SevenZipHelper
    {

       static int dictionary = 1 << 23;

      // static Int32 posStateBits = 2;
     // static  Int32 litContextBits = 3; // for normal files
        // UInt32 litContextBits = 0; // for 32-bit data
     // static  Int32 litPosBits = 0;
        // UInt32 litPosBits = 2; // for 32-bit data
    // static   Int32 algorithm = 2;
    // static    Int32 numFastBytes = 128;

     static   bool eos = false;





     static   CoderPropID[] propIDs = 
				{
					CoderPropID.DictionarySize,
					CoderPropID.PosStateBits,
					CoderPropID.LitContextBits,
					CoderPropID.LitPosBits,
					CoderPropID.Algorithm,
					CoderPropID.NumFastBytes,
					CoderPropID.MatchFinder,
					CoderPropID.EndMarker
				};

        // these are the default properties, keeping it simple for now:
     static   object[] properties = 
				{
					(Int32)(dictionary),
					(Int32)(2),
					(Int32)(3),
					(Int32)(0),
					(Int32)(2),
					(Int32)(128),
					"bt4",
					eos
				};


        public static byte[] Compress(byte[] inputBytes)
        {

            MemoryStream inStream = new MemoryStream(inputBytes);
            MemoryStream outStream = new MemoryStream();
            SevenZip.Compression.LZMA.Encoder encoder = new SevenZip.Compression.LZMA.Encoder();
            encoder.SetCoderProperties(propIDs, properties);
            encoder.WriteCoderProperties(outStream);
            long fileSize = inStream.Length;
            for (int i = 0; i < 8; i++)
                outStream.WriteByte((Byte)(fileSize >> (8 * i)));
            encoder.Code(inStream, outStream, -1, -1, null);
            return outStream.ToArray();
        }


        static byte[] _Properties2;
        static SevenZip.Compression.LZMA.Decoder _Decoder;
        static object _Locker = new object();
        /// <summary>
        /// 解压数据
        /// </summary>
        /// <param name="inputBytes">压缩的数据包</param>
        /// <returns>解压好的数据包，需要立即使用完，不能引用</returns>
        public static byte[] Decompress(byte[] inputBytes)
        {
            lock(_Locker)
            {
                MemoryStream newInStream = new MemoryStream(inputBytes);

                if (_Decoder == null)
                {
                    _Decoder = new SevenZip.Compression.LZMA.Decoder();
                }

                newInStream.Seek(0, 0);

                if (_Properties2 == null)
                {
                    _Properties2 = new byte[5];
                }
                if (newInStream.Read(_Properties2, 0, 5) != 5)
                    throw (new Exception("input .lzma is too short"));
                long outSize = 0;
                for (int i = 0; i < 8; i++)
                {
                    int v = newInStream.ReadByte();
                    if (v < 0)
                        throw (new Exception("Can't Read 1"));
                    outSize |= ((long)(byte)v) << (8 * i);
                }
                _Decoder.SetDecoderProperties(_Properties2);

                MemoryStream newOutStream = new MemoryStream((int)outSize);

                long compressedSize = newInStream.Length - newInStream.Position;
                _Decoder.Code(newInStream, newOutStream, compressedSize, outSize, null);

                byte[] b = newOutStream.GetBuffer();
                newOutStream.Dispose();
                newInStream.Dispose();
                return b;
            }
        }
    }
}
