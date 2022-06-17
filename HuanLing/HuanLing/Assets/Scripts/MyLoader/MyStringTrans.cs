using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

namespace Skmioo.MyLoader
{
	/// <summary>
	/// 处理字符串翻译
	/// </summary>
	public class MyStringTrans
	{
		/// <summary>
		/// 二进制语言ab包名称
		/// </summary>
		public const string LanPackName = "lan.ab";
		/// <summary>
		/// 二进制语言包名称
		/// </summary>
		public const string LanFileName = "lan.lan";

		/// <summary>
		/// 翻译字典
		/// </summary>
		private static Dictionary<string, string> s_LanTextDic;

		public static string T(string src)
		{
			string dest;
			if (s_LanTextDic == null || !s_LanTextDic.TryGetValue(src, out dest) || string.IsNullOrEmpty(dest))
				dest = src;
			return dest;
		}

		public static string T(string src, params object[] args)
		{
			return string.Format(T(src), args);
		}
		/// <summary>
		/// 重新加载语言包
		/// </summary>
		public static void ReloadLanPack(byte[] fileData)
		{
			byte[] data = null;
			if (fileData == null)
				return;
			MySevenZipAsset sevenZipAsset = MySevenZipAsset.CreateFromMemory(fileData);
			data = sevenZipAsset.GetFileData(LanFileName,true);
			if (data == null)
			{
				Debug.LogErrorFormat("can't find {0} in {1}!", LanFileName, LanPackName);
				return;
			}
			//读取二级制信息
			ReadBinary(data);
		}


		private static void ReadBinary(byte[] data)
		{
			s_LanTextDic = new Dictionary<string, string>();
			MemoryStream mem = new MemoryStream(data);
			BinaryReader ba = new BinaryReader(mem);
			if (mem.Length < 8)
			{
				throw new Exception(string.Format("Length of Lan less than 8!"));
			}

			if (ba.ReadChar() != 'L'
				|| ba.ReadChar() != 'A'
				|| ba.ReadChar() != 'N'
				|| ba.ReadChar() != 'B')
			{
				throw new Exception(string.Format("Header of Lan is not 'LANB'!"));
			}
			uint num = ba.ReadUInt32();
			for (int idx = 0; idx < num; ++idx)
			{
				string key = readString1(ba);
				string val = readString2(ba);
				if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(val))
				{
					continue;
				}
				s_LanTextDic.Add(key, val);
			}
			Debug.LogFormat("read translate dic=>{0}", s_LanTextDic.Count);
		}

		public static String readString1(BinaryReader br, int codePage = -1)
		{
			int len = br.ReadByte();
			if (len == 0)
			{
				return string.Empty;
			}
			return readString(br, len, codePage);
		}

		public static String readString2(BinaryReader br, int codePage = -1)
		{
			int len = br.ReadInt16();
			if (len == 0)
			{
				return string.Empty;
			}
			return readString(br, len, codePage);
		}

		public static String readString(BinaryReader br, int bytesNum, int codePage)
		{
			if (bytesNum <= 0)
				return string.Empty;
			byte[] strData = br.ReadBytes(bytesNum);
			Encoding coder = codePage == -1 ? System.Text.Encoding.UTF8 : Encoding.GetEncoding(codePage);
			return coder.GetString(strData);
		}

	}
}
