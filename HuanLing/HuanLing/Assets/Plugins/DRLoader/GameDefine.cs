using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UYMO;

namespace DRLoader
{
    /// <summary>
    /// 游戏一些常量定义
    /// 后台服务器地址
    /// 资源服务器地址
    /// 资源路径地址
    /// os相关等
    /// </summary>
    public class GameDefine
    {
        /// <summary>
        /// 内网资源服务器地址
        /// </summary>
        public const string InnerResServerUrl = "http://192.168.1.201";
        /// <summary>
        /// 内网资源服务器公网地址
        /// </summary>
        public const string InnerResSErverPubUrl = "https://www.youyegame.cn";

        /// <summary>
        /// 内网后台地址
        /// </summary>
        public const string InnerBGUrl = "http://api.ho.youyegame.cn";
        /// <summary>
        /// 内网后台公网地址
        /// </summary>
        public const string InnerBGPublicUrl = "http://api.ho.youyegame.cn:8000";

        /// <summary>
        /// 获取外网后台地址
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static string GetOuterBGUrl(string keyword)
        {
            switch(keyword)
            {
                case "tx": return "http://tx.gz.ledo.com/";
                case "tw2":
                case "twA":
                case "tw": return "http://gj999.gamedreamer.com.tw/";
                default: return "http://uer.ho.ledo.com";
            }
        }

        /// <summary>
        /// 资源下载地址
        /// </summary>
        static string[] _DownloadUrl = null;
        /// <summary>
        /// 后台地址
        /// </summary>
        static string[] _BGUrls = null;
        /// <summary>
        /// 资源存储路径
        /// </summary>
        static string _StoragePathRoot = "未指定";
        /// <summary>
        /// 是否在公司
        /// </summary>
        static bool _InCompany = false;

        /// <summary>
        /// 更改资源下载地址，谨慎调用
        /// </summary>
        public static void SetDownloadUrlRoot(string[] svrAddress)
        {
            _DownloadUrl = svrAddress;
            StringBuilder info = new StringBuilder();
            for(var idx =0; idx < _DownloadUrl.Length; ++idx )
            {
                info.AppendFormat("{0}\n", _DownloadUrl[idx]);
            }
            
            Debug.LogFormat("设定资源下载地址：{0}", info);
        }
        public static void SetBackgroundUrl(string[] urls)
        {
            _BGUrls = urls;

            StringBuilder info = new StringBuilder();
            info.Append("设定后台地址：\n");
            for (var idx = 0; idx < _BGUrls.Length; ++idx)
            {
                info.AppendFormat("{0}\n", _BGUrls[idx]);
            }
            Debug.Log(info.ToString());
        }
        /// <summary>
        /// 更改资源存储路径，谨慎调用
        /// </summary>
        public static void SetStoragePath(string path)
        {
            _StoragePathRoot = path;
            Debug.LogFormat("设置资源存储路径：{0}", path);
        }
        public static void SetLocation(bool inCompany)
        {
            _InCompany = inCompany;
            Debug.LogFormat("当前是否在公司：{0}", _InCompany);
        }

        /// <summary>
        /// 资源下载地址
        /// </summary>
        public static string[] GetDownloadUrl(string path)
        {
            string[] ret = new string[_DownloadUrl.Length];
            for(var idx = 0; idx < _DownloadUrl.Length; ++idx )
            {
                ret[idx] = _DownloadUrl[idx] + path;
            }
            return ret;
        }
        /// <summary>
        /// 后台地址
        /// </summary>
        public static string bgUrl
        {
            get { return _BGUrls != null && _BGUrls.Length > 0 ? _BGUrls[0] : "未知"; }
        }
        public static string[] bgUrls { get { return _BGUrls; } }
        /// <summary>
        /// 资源存储路径
        /// </summary>
        public static string storagePathRoot
        {
            get { return _StoragePathRoot; }
        }
        /// <summary>
        /// 当前是否在公司
        /// </summary>
        public static bool inCompany
        {
            get { return _InCompany; }
        }

        /// <summary>
        /// 系统名称
        /// </summary>
        public static string osName
        {
            get
            {
                return ChannelImpl.osName;
            }
        }

        /// <summary>
        /// 资源包路径（不再使用)
        /// </summary>
        public static string ResBagPath
        {
            get
            {
                return _StoragePathRoot + "Res.bag";
            }
        }
        /// <summary>
        /// 外部资源路径
        /// </summary>
        public static string ExtResDirPath
        {
            get
            {
                return _StoragePathRoot + "ExtRes";
            }
        }

        /// <summary>
        /// 分支类型
        /// </summary>
        public static BranchType branch
        {
            get
            {
                string branch = UYMO.BaseVersion.Branch;
                if (branch == "trunk")
                {
                    return BranchType.trunk;
                }
                if (branch.Length < 2)
                    return BranchType.unknown;
                else
                {
                    string num = branch.Substring(1);
                    sbyte ret;
                    if (sbyte.TryParse(num, out ret))
                    {
                        return (BranchType)ret;
                    }
                    return BranchType.unknown;
                }
            }
        }
    }
}
