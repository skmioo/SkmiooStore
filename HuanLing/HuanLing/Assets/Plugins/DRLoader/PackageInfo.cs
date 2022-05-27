using System.IO;
using UYMO;

namespace DRLoader
{
    public struct PackageInfo
    {
        public long version;
        public long baseVersion;
        public static PackageInfo Prase(string name)
        {
            string[] parts = name == null ? new string[0] : name.Split('_', ' ');
            PackageInfo ret;
            if (parts.Length <1 || !long.TryParse(parts[0], out ret.version))
            {
                ret.version = 0;
            }
            if (parts.Length <2 || !long.TryParse(parts[1], out ret.baseVersion))
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
