
using UYMO;
namespace DRLoader
{
    public struct AppVersion
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

        public static AppVersion Parse(string version)
        {
            int[] vers = MathUtil.ParseInts(version);
            AppVersion v;
            v.Large = vers.Length > 0 ? vers[0] : 0;
            v.Medium = vers.Length > 1 ? vers[1] : 0;
            v.Little = vers.Length > 2 ? vers[2] : 0;
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
