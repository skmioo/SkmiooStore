using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UYMO;

namespace DRLoader
{
    /// <summary>
    /// 更新信息
    /// </summary>
    public class UpdateInfo
    {
        /// <summary>
        /// app版本
        /// </summary>
        public AppVersion appVer;
        /// <summary>
        /// 资源版本
        /// </summary>
        public long resVer;
        /// <summary>
        /// 是否强制更新APP，-1未指定，0不用，1需要
        /// </summary>
        public int forceUpdateApp;
        /// <summary>
        /// 是否记录事件（打点）
        /// </summary>
        public bool recordevt;
        /// <summary>
        /// 更新包清单文件tag
        /// </summary>
        public string updListTag;
        /// <summary>
        /// 更新清单
        /// </summary>
        public List<PackageInfo> resUpdateList;
        /// <summary>
        /// 从字符串中解析
        /// </summary>
        /// <param name="content">字符串内容</param>
        /// <param name="justUpdList">是否仅解析更新包清单</param>
        public void Parse(string content, bool justUpdList)
        {
            UpdateFile file = UnityEngine.JsonUtility.FromJson<UpdateFile>(content);
            if(!justUpdList)
            {
                appVer = AppVersion.Parse(file.version);
            }
            if(!justUpdList)
            {
                resVer = file.resver;
            }
            resUpdateList = new List<PackageInfo>(file.packageList.Length);
            for(var idx = 0; idx < file.packageList.Length; ++idx )
            {
                resUpdateList.Add(PackageInfo.Prase(file.packageList[idx]));
            }

            resUpdateList.Sort((a, b) =>
            {
                long aBase = a.baseVersion == 0 ? a.version : a.baseVersion;
                long bBase = b.baseVersion == 0 ? b.version : b.baseVersion;
                if (a.version > b.version || (a.version == b.version && aBase > bBase))
                {//a>b
                    return -1;
                }
                else if (a.version < b.version || (a.version == b.version && aBase < bBase))
                {//a<b
                    return 1;
                }
                else
                {//a==b
                    return 0;
                }
            });

            if (!justUpdList && resUpdateList.Count > 0)
            {
                resVer = resUpdateList[0].version;
            }
        }

        /// <summary>
        /// 获取更新包的名称
        /// </summary>
        /// <param name="curVer">当前版本</param>
        /// <param name="targetVer">返回此次更新的目标版本</param>
        /// <returns>更新包名称，没有返回null</returns>
        public string GetUpdatePackName(long curVer, out long targetVer)
        {
            targetVer = 0;
            if ( curVer >= resVer)
            {//不需要更新
                return null;
            }

            if ( resUpdateList != null && resUpdateList.Count > 0 )
            {
                for (var idx = 0; idx < resUpdateList.Count; ++idx)
                {
                    if (resUpdateList[idx].baseVersion == curVer && resUpdateList[idx].version <= resVer)
                    {//下载更新包
                        targetVer = resUpdateList[idx].version;
                        return resUpdateList[idx].ToString();
                    }
                }
            }

            targetVer = resVer - curVer >= 5 && curVer % 5 == 1 ? curVer + 5 : curVer + 1;
            return string.Format("{0}_{1}_{2}_{3}.bag", BaseVersion.Branch, GameDefine.osName, targetVer, curVer);
        }

        
    }
    [Serializable]
    class UpdateFile
    {
        public string version;
        public long resver;
        public string[] packageList;
    }
}
