using DRLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnityEngine;
using UYMO;

namespace Skmioo.MyLoader
{
	public class MyVersionCheckUtil
	{
		static Action<MyUpdateInfo> _Callback;
		static string localPackageListPath;
		public static void ReqVersionInfo(Action<MyUpdateInfo> callback)
		{
			_Callback = callback;
			if (BaseVersion.IsInner)
			{
				localPackageListPath = GameDefine.storagePathRoot + "package.temp";
				string packageListFileName = string.Format("{0}_{1}_package.txt", BaseVersion.Branch, GameDefine.osName);
				string[] listUrl = GameDefine.GetDownloadUrl(packageListFileName);
				NetFrame.unityWebLoader.Load(listUrl, null, ParseVerInfoFromVerfile);
				Debug.LogFormat("[GameUpdate]LoadPackList:{0}", listUrl);
			}
			else
			{
				ReqVerInfoFromBG();
			}
		}

		static void ReqVerInfoFromBG()
		{
			Dictionary<string, string> param = new Dictionary<string, string>();
			param.Add("keyword", ChannelImpl.GetChannelName());
			param.Add("os", GameDefine.osName);
			param.Add("branch", BaseVersion.Branch);
			WebPageRequester.RequestBackground("GetVer", param, true, ParseVerInfoFromBG);
		}

		static void ParseVerInfoFromBG(BGStatusCode error, string data)
		{
			if (data == null)
			{
				Debug.LogError("版本信息获取失败！null");
				FailedGetVersionFromBG();
				return;
			}
			MyUpdateInfo svrVerInfo = new MyUpdateInfo();
			Regex jsonFinder = new Regex(@"\{.*\}");
			Match match = jsonFinder.Match(data);
			if (match.Success)
			{
				Debug.Log("从后台获得版本信息：" + match.Value);
				try
				{
					BGVerRet verInfo = LitJson.JsonMapper.ToObject<BGVerRet>(match.Value);
					if (verInfo.status >= 0 && verInfo.verRow != null)
					{
						List<string> urls = new List<string>();
						if (!string.IsNullOrEmpty(verInfo.verRow.url))
						{
							urls.Add(string.Format("{0}/{1}/", verInfo.verRow.url, GameDefine.osName));
						}
						if (verInfo.verRow.urls != null && verInfo.verRow.urls.Length > 0)
						{
							for (var idx = 0; idx < verInfo.verRow.urls.Length; ++idx)
							{
								string url = verInfo.verRow.urls[idx];
								if (url == verInfo.verRow.url)
								{
									continue;
								}
								urls.Add(string.Format("{0}/{1}/", url, GameDefine.osName));
							}
						}
						GameDefine.SetDownloadUrlRoot(urls.ToArray());
						svrVerInfo.appVersion = MyAppVersion.Parse(verInfo.verRow.setupversion);
						svrVerInfo.resVer = MathUtil.ParseLong(verInfo.verRow.resourceversion);
						svrVerInfo.forceUpdateApp = verInfo.verRow.update != "0" ? 1 : 0;
						svrVerInfo.recordevt = verInfo.recordevt == 1;
						svrVerInfo.updListTag = verInfo.verRow.rand;
						callback(svrVerInfo);
					}
					else
					{
						Debug.LogErrorFormat("版本信息状态不对！{0}", data);
						FailedGetVersionFromBG();
					}
				}
				catch (Exception e)
				{
					Debug.LogErrorFormat("Parse version info failed!{0} data {1}", e, match.Value);
					FailedGetVersionFromBG();
				}

			}
			else
			{
				Debug.LogErrorFormat("版本信息配置失败！{0}", data);
				FailedGetVersionFromBG();
			}
		}

		static void FailedGetVersionFromBG()
		{
			callback(null);
		}

		static void HandleRetry(int btn)
		{
			ReqVerInfoFromBG();
		}

		static void ParseVerInfoFromVerfile(INetResult ret)
		{
			if (!ret.success)
			{//资源列表拉取失败，换服务器试试
				LoadUI.instance.errorStr = ret.msg;
				callback(null);
				return;
			}
			Debug.Log("[GameUpdate:]更新包清单下载成功！");
			string content = ret.text;

			MyUpdateInfo svrVerinfo = new MyUpdateInfo();
			svrVerinfo.forceUpdateApp = -1;
			svrVerinfo.recordevt = true;
			svrVerinfo.Parse(content, false);
			Debug.LogFormat("版本信息 version:{0} resver:{1}", svrVerinfo.appVersion, svrVerinfo.resVer);

			callback(svrVerinfo);
		}

		static void callback(MyUpdateInfo ver)
		{
			_Callback?.Invoke(ver);
		}
	}

	[Serializable]
	class BGVerLine
	{
		public string vid;
		public string url;
		public string[] urls;
		public string setupversion;
		public string resourceversion;
		public string time;
		public string update;
		public string rand;
	}
	[Serializable]
	class BGVerRet
	{
		public int status;
		public string msg;
		public int recordevt;
		public BGVerLine verRow;
	}
}
