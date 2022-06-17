using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UYMO;

namespace Skmioo.MyLoader
{
	/// <summary>
	/// App版本信息
	/// </summary>
	public struct MyAppVersion
	{
		/// <summary>
		/// 大版本号
		/// </summary>
		public int Large;
		/// <summary>
		/// 中版本号
		/// </summary>
		public int Medium;

		/// <summary>
		/// 小版本号
		/// </summary>
		public int Little;


		public static MyAppVersion Parse(string version)
		{
			int[] ver = MathUtil.ParseInts(version);
			MyAppVersion v;
			v.Large = ver.Length > 0 ? ver[0] : 0;
			v.Medium = ver.Length > 1 ? ver[1] : 0;
			v.Little = ver.Length > 2 ? ver[2] : 0;
			return v;
		}

		public override string ToString()
		{
			return string.Format("{0}.{1}.{2}", Large, Medium, Little);
		}

		public ulong ToUlong()
		{
			//0~23 Little
			//24~47 Medium
			//48~63 Large
			return ((ulong)Large << 48) | ((ulong)Medium << 24) | (ulong)Little;
		}
	}
}
