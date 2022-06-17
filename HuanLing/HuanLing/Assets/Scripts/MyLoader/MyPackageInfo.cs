using DRLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UYMO;

namespace Skmioo.MyLoader
{
	public struct MyPackageInfo
	{

		public long version;
		public long baseVersion;

		public static MyPackageInfo Prase(string name)
		{
			string[] parts = name == null ? new string[0] : name.Split('_', ' ');
			MyPackageInfo ret;
			if (parts.Length < 1 || !long.TryParse(parts[0], out ret.version))
			{
				ret.version = 0;
			}
			if (parts.Length < 2 || !long.TryParse(parts[1], out ret.baseVersion))
			{
				ret.baseVersion = 0;
			}
			return ret;
		}
		public override string ToString()
		{
			return string.Format("{0}_{1}_{2}{3}.bag", BaseVersion.Branch, GameDefine.osName, version, baseVersion == 0 ? "" : "_" + baseVersion);
		}

	}
}
