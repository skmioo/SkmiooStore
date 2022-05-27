namespace UYMO
{
    [SLua.CustomLuaClassAttribute]
    public class BaseVersion
    {
        /// <summary>
        /// C# 版本号
        /// </summary>
        public static string CSharpVersion = "undefined";
        /// <summary>
        /// C# 版本信息
        /// </summary>
        public static string VersionTime = "undefined";
        /// <summary>
        /// 是否为内部版本
        /// </summary>
        public static bool IsInner = true;
        /// <summary>
        /// 版本分支
        /// </summary>
        public static string Branch = "trunk";
    }
}
