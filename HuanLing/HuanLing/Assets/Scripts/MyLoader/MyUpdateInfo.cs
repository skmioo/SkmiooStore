using DRLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UYMO;

namespace Skmioo.MyLoader
{
	/// <summary>
	/// 更新信息
	/// </summary>
	public class MyUpdateInfo
	{
		/// <summary>
		/// App版本信息
		/// </summary>
		public MyAppVersion appVersion;

		/// <summary>
		/// 资源版本信息
		/// </summary>
		public long resVer;

		/// <summary>
		/// 是否强制更新App -1 未指定 0 不用 1 需要
		/// </summary>
		public int forceUpdateApp;

		/// <summary>
		/// 是否记录事件（打点）
		/// </summary>
		public bool recordevt;

		/// <summary>
		/// 更新包清单文件Tag
		/// </summary>
		public string updListTag;

		/// <summary>
		/// 更新清单
		/// </summary>
		public List<MyPackageInfo> resUpdateList;

		/// <summary>
		/// 从字符串中解析
		/// </summary>
		/// <param name="content">字符串内容</param>
		/// <param name="justUpdList">是否仅解析更新包清单</param>
		public void Parse(string content, bool justUpdList)
		{
			MyUpdateFile file = UnityEngine.JsonUtility.FromJson<MyUpdateFile>(content);
			if (!justUpdList)
			{
				appVersion = MyAppVersion.Parse(file.version);
				resVer = file.resver;
			}
			resUpdateList = new List<MyPackageInfo>(file.packageList.Length);
			for (int idx = 0; idx < file.packageList.Length; ++idx)
			{
				resUpdateList.Add(MyPackageInfo.Prase(file.packageList[idx]));
			}

			resUpdateList.Sort((a, b) =>
			{
				long aBase = a.baseVersion == 0 ? a.version : a.baseVersion;
				long bBase = b.baseVersion == 0 ? b.version : b.baseVersion;
				//-1表示不交换 1表示交换 
				//最终效果是版本号按照从大到小排序
				if (a.version > b.version || (a.version == b.version && aBase > bBase))
				{
					//a>b
					return -1;
				}
				else if (a.version < b.version || (a.version == b.version) && aBase < bBase)
				{
					//a <b
					return 1;
				}
				else
				{
					return 0;
				}

			});

			if (!justUpdList && resUpdateList.Count > 0)
			{
				resVer = resUpdateList[0].version;
			}
		}

		/// <summary>
		/// 获取更新包名称
		/// </summary>
		/// <param name="curVer">当前版本</param>
		/// <param name="targetVer">返回此次更新的目标版本</param>
		/// <returns>更新包名称，没有返回null</returns>
		public string GetUpdatePackName(long curVer, out long targetVer)
		{
			targetVer = 0;
			//不需要更新
			if (curVer >= resVer)
				return null;
			if (resUpdateList != null && resUpdateList.Count > 0)
			{
				for (var idx = 0; idx < resUpdateList.Count; ++idx)
				{
					if (resUpdateList[idx].baseVersion == curVer && resUpdateList[idx].version <= resVer)
					{
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
	class MyUpdateFile
	{
		public string version;
		public long resver;
		public string[] packageList;
	}
}
