using DRLoader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UYMO;

namespace Skmioo.MyLoader
{
	/// <summary>
	/// 资源文件读取回调，读取失败返回参数为null
	/// </summary>
	/// <param name="filedata"></param>
	public delegate void FileLoaded(string name, byte[] fileData, AssetBundle ab);

	/// <summary>
	/// 资源文件存在状态
	/// </summary>
	public enum FileExist
	{
		/// <summary>
		/// 不存在
		/// </summary>
		No,
		/// <summary>
		/// 存在内部
		/// </summary>
		Inner,
		/// <summary>
		/// 存在外部
		/// </summary>
		Ext
	}

	/// <summary>
	/// 加载优先级
	/// </summary>
	public enum LoadPriority
	{
		/// <summary>
		/// 空闲下载
		/// </summary>
		Idle,
		/// <summary>
		/// 一般优先级
		/// </summary>
		Normal,
		/// <summary>
		/// 高优先级
		/// </summary>
		High,
		/// <summary>
		/// 高优先级并且高速加载
		/// </summary>
		HighSpeed,
		/// <summary>
		/// 优先级分类数量
		/// </summary>
		PriorityCount
	}

	/// <summary>
	/// 字节文件类型
	/// </summary>
	public enum AssetsFileType
	{
		/// <summary>
		/// assetbundle的资源文件类型
		/// </summary>
		AssetsBundle,
		/// <summary>
		/// 未压缩的assetbundle
		/// </summary>
		UnCompressedAssetBundle,
		/// <summary>
		/// 字节数据的文件类型
		/// </summary>
		BytesData,
	}


	public class MyAssetsFileMgr : SingletonAuto<MyAssetsFileMgr>, IDisposable
	{
		public static bool log = false;
		/// <summary>
		/// 最大的加载线程数量
		/// </summary>
		public static int maxLoadThreadNum = 1;

		/// <summary>
		/// 异步加载assetbundle的优先级值
		/// 不写死，以备需要调整
		/// </summary>
		public static int asynPriority = 1;

		const string VersionFileName = "version.ab";

		class LoadFileItem
		{
			public float beginTime;
			public string fileName;
			public AssetsFileType fileType;
			public FileLoaded loaded;

			public WWW loader;
			public AssetBundleCreateRequest request;
			public AssetBundle ab;


			static Queue<LoadFileItem> _Idles = new Queue<LoadFileItem>();
			internal static LoadFileItem Create()
			{
				if (_Idles.Count > 0)
					return _Idles.Dequeue();
				return new LoadFileItem();
			}

			public static LoadFileItem Dispose(LoadFileItem item)
			{
				item.beginTime = 0;
				item.fileName = null;
				item.fileType = AssetsFileType.AssetsBundle;
				item.loaded = null;
				item.ab = null;
				if (item.loader != null)
				{
					item.loader.Dispose();
					item.loader = null;
				}
				item.request = null;
				_Idles.Enqueue(item);
				return null;
			}

		}

		Predicate<LoadFileItem> _CheckLoaded;
		

		bool _ForceHighSpeed = true;
		int _MaxLoadThread = maxLoadThreadNum;

		ResDir _ExtRes;
		long _InnerVersion;
		HashSet<string> _InnerList;

		bool _StopLoad = false;
		bool _CacheEnabled = false;

		Queue<LoadFileItem>[] _WaitLoads = new Queue<LoadFileItem>[(int)LoadPriority.PriorityCount];
		LoadPriority _CurPriority = LoadPriority.HighSpeed;

		List<LoadFileItem> _Loadings = new List<LoadFileItem>();
		float _LastLoadNewTime = 0;//最后一次开始加载一个文件的时间

		bool _Inited = false;

		Action _InnerInitedCb = null;
		bool _InnerInited = false;

		public event Action<string> eLoadBegin;
		public event Action<string, bool> eLoadEnd;


		public MyAssetsFileMgr()
		{
			maxLoadTime = 10f;
			string path = cacheCfgPath;
			if (File.Exists(path))
			{
				using (FileStream cfg = new FileStream(path, FileMode.Open, FileAccess.Read))
				{
					_CacheEnabled = cfg.ReadByte() == (byte)1;
					cfg.Close();
				}
			}

			//不需要缓存 把缓存删除
			if (!_CacheEnabled)
			{
				Caching.ClearCache();
			}
			_CheckLoaded = CheckLoaded;
			for (int idx = 0; idx < _WaitLoads.Length; ++idx)
			{
				_WaitLoads[idx] = new Queue<LoadFileItem>();
			}
		}
	
		static string cacheCfgPath { get { return GameDefine.storagePathRoot + "cache.toggle"; } }

		/// <summary>
		/// 初始化内部资源管理
		/// </summary>
		public void InitInner(Action cb)
		{
			Debug.Log("Init Inner");
			_InnerInitedCb = cb;
			LoadFileAsyn(VersionFileName, AssetsFileType.BytesData, LoadPriority.HighSpeed, InnerInited);
		}


		/// <summary>
		/// 初始化外部资源管理
		/// </summary>
		public void InitExt()
		{
			Dispose();
			if (ResDir.CheckValidResDir(GameDefine.ExtResDirPath))
			{
				_ExtRes = ResDir.Create(GameDefine.ExtResDirPath);
			}
		}

		/// <summary>
		/// 内部文件处理
		/// </summary>
		/// <param name="name"></param>
		/// <param name="data"></param>
		/// <param name="ab"></param>
		void InnerInited(string name, byte[] data, AssetBundle ab)
		{
			_InnerList = new HashSet<string>();
			if (data != null)
			{//有内部资源
				MemoryStream ms = new MemoryStream(data);
				StreamReader ss = new StreamReader(ms, Encoding.ASCII);
				long.TryParse(ss.ReadLine(), out _InnerVersion);
				while (!ss.EndOfStream)
				{
					_InnerList.Add(ss.ReadLine());
				}
			}
			_InnerInited = true;
			if (_InnerInitedCb != null)
			{
				_InnerInitedCb();
			}
		}



		/// <summary>
		/// 是否已经初始化
		/// </summary>
		public bool inited
		{
			get
			{
				return _Inited;
			}
		}
		/// <summary>
		/// 内部资源版本
		/// </summary>
		public long innerVersion
		{
			get
			{
				return _InnerVersion;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public long version
		{
			get
			{
				return _ExtRes != null ? _ExtRes.version : innerVersion;
			}
		}

		/// <summary>
		/// 当前正在加载的资源数量
		/// </summary>
		public int assetNumLoading
		{
			get { return _Loadings.Count; }
		}


		/// <summary>
		/// 确认某个资源文件的存在状态
		/// </summary>
		/// <param name="name">文件名</param>
		public FileExist Exist(string name)
		{
			if (Boot.LocalBake)
			{
				//本地烧制调试,本地资源优先
				if (_InnerList != null && _InnerList.Contains(name))
				{
					return FileExist.Inner;
				}
				if (_ExtRes != null && _ExtRes.Exist(name))
				{//优先判断外部资源
					return FileExist.Ext;
				}
			}
			else
			{//普通运行，在线（外部）资源优先
				if (_ExtRes != null && _ExtRes.Exist(name))
				{//优先判断外部资源
					return FileExist.Ext;
				}
				if (_InnerList != null && _InnerList.Contains(name))
				{//然后再看内部有不
					return FileExist.Inner;
				}
			}
			return FileExist.No;
		}

		/// <summary>
		/// 加载资源文件到内存,不保证按顺序加载
		/// </summary>
		/// <param name="name">文件名称 </param>
		/// <param name="fileType">文件类型</param>
		/// <param name="priority">优先级</param>
		/// <param name="loaded">加载回调</param>
		public void LoadFileAsyn(string name, AssetsFileType fileType, LoadPriority priority, FileLoaded loaded)
		{
			if (_StopLoad)
				return;
			if (priority < LoadPriority.Idle || priority > LoadPriority.HighSpeed)
			{
				throw new InvalidOperationException("Illegal priority type!" + priority);
			}
			LoadFileItem item = LoadFileItem.Create();
			item.fileName = name;
			item.fileType = fileType;
			item.loaded = loaded;
			_WaitLoads[(int)priority].Enqueue(item);
			if (priority > _CurPriority)
			{
				_CurPriority = priority;
				SynLoadSpeed();
			}
		}

		/// <summary>
		/// 同步加载assetbundle
		/// </summary>
		/// <param name="name">文件名</param>
		public AssetBundle LoadAssetBundle(string name)
		{
			string path = null;
			FileExist exist = Exist(name);
			switch (exist)
			{
				case FileExist.Inner:
					path = _GetInnerPath(name, AssetsFileType.UnCompressedAssetBundle);
					break;
				case FileExist.Ext:
					path = _GetExtPath(name, AssetsFileType.UnCompressedAssetBundle);
					break;
				default:
					return null;
			}
			return AssetBundle.LoadFromFile(path);
		}

		/// <summary>
		/// 停止任何资源文件的加载，测试用
		/// </summary>
		public bool stopLoad
		{
			set {
				_StopLoad = value;
				if (_StopLoad)
				{
					for (int idx = 0; idx < _WaitLoads.Length; ++idx)
					{
						_WaitLoads[idx].Clear();
					}
				}
			}

			get {

				return _StopLoad;
			}
		}

		public void Dispose()
		{
			if (_ExtRes != null)
			{
				_ExtRes.Dispose();
				_ExtRes = null;
			}
		}

		Queue<LoadFileItem> curPriority { get { return _WaitLoads[(int)_CurPriority]; } }

		public void Update()
		{
			while (curPriority.Count <= 0 && _CurPriority > LoadPriority.Idle)
			{
				--_CurPriority;
				SynLoadSpeed();
			}

			bool loadTooLong = Time.time - _LastLoadNewTime >= maxLoadTime;
			if (loadTooLong && _Loadings.Count > 0)
			{
				++_MaxLoadThread;
				_LastLoadNewTime = Time.time;
				Debug.LogErrorFormat("{0}加载了{1}s，扩张线程:{2}！waite:{3} periot:{4}", _Loadings[_Loadings.Count - 1].fileName,
																						maxLoadTime, 
																						_MaxLoadThread, 
																						curPriority.Count, 
																						_CurPriority);
			}

			while (_Loadings.Count < _MaxLoadThread && curPriority.Count > 0)
			{
				LoadFileItem item = _WaitLoads[(int)_CurPriority].Dequeue();
				FileExist st = item.fileName == VersionFileName ? FileExist.Inner : Exist(item.fileName);
				switch (st)
				{
					case FileExist.Inner:
						try
						{
							string path = _GetInnerPath(item.fileName, item.fileType);
							_CreateLoader(path, ref item);
							_LastLoadNewTime = Time.time;
							_Loadings.Add(item);
							if (eLoadBegin != null)
								eLoadBegin(item.fileName);
						}
						catch (Exception e)
						{
							Debug.LogErrorFormat("Try load file from inner failed! {0}\n{1}", item.fileName, e);
							Done(item, null, null);
						}

						break;
					case FileExist.Ext:
						try
						{
							string path = _GetExtPath(item.fileName, item.fileType);
							_CreateLoader(path, ref item);
							_LastLoadNewTime = Time.time;
							_Loadings.Add(item);
							if (eLoadBegin != null)
								eLoadBegin(item.fileName);
						}
						catch (Exception e)
						{
							Debug.LogErrorFormat("Try load file from ext failed! {0}\n{1}", item.fileName, e);
							Done(item, null, null);
						}
						break;
					case FileExist.No:
						Debug.LogErrorFormat("文件不存在:{0}", item.fileName);
						Done(item, null, null);
						break;
				}
			}

			_Loadings.RemoveAll(_CheckLoaded);
		}

		string _GetInnerPath(string fileName, AssetsFileType fileType)
		{
			string path = System.IO.Path.Combine(Application.streamingAssetsPath, fileName);
			if (Application.platform != RuntimePlatform.Android && fileType == AssetsFileType.BytesData)
			{
				path = "file://" + path;
			}
			return path;
		}

		string _GetExtPath(string fileName, AssetsFileType fileType)
		{
			string path = _ExtRes.GetResPath(fileName);
			if (fileType == AssetsFileType.BytesData)
			{
				path = "file://" + path;
			}
			return path;
		}


		void _CreateLoader(string path, ref LoadFileItem item)
		{
			item.beginTime = Time.time;
			switch (item.fileType)
			{
				case AssetsFileType.BytesData:
					item.loader = new WWW(path);
					break;
				case AssetsFileType.AssetsBundle:
				case AssetsFileType.UnCompressedAssetBundle:
					item.request = AssetBundle.LoadFromFileAsync(path);
					item.request.priority = asynPriority;
					break;
			}
			//return type == AssetsFileType.BytesData || !_CacheEnabled ? new WWW(path) : WWW.LoadFromCacheOrDownload(path, (int)version);
		}

		public bool needUpdate
		{
			get
			{
				return _Loadings.Count > 0 || _CurPriority > LoadPriority.Idle || curPriority.Count > 0;
			}
		}

		bool CheckLoaded(LoadFileItem item)
		{
			if (item.loader != null)
			{
				if (item.loader.isDone)
				{
					if (string.IsNullOrEmpty(item.loader.error))
					{
						if (item.fileType == AssetsFileType.BytesData)
						{
							Done(item, item.loader.bytes, null);
						}
						else
						{
							Done(item, null, item.loader.assetBundle);
						}
					}
					else
					{
						Debug.LogWarningFormat("文件{0}读取失败\n{1}", item.fileName, item.loader.error);
						Done(item, null, null);
					}
					return true;
				}
				return false;
			}
			else if (item.request != null)
			{
				if (item.request.isDone)
				{
					Done(item, null, item.request.assetBundle);
					return true;
				}
				return false;
			}
			else if (item.ab != null)
			{
				Done(item, null, item.ab);
				return true;
			}
			Debug.LogWarningFormat("文件读取失败{0}", item.fileName);
			Done(item, null, null);
			return true;
		}


		void Done(LoadFileItem item, byte[] data, AssetBundle ab)
		{
			if (log)
			{
				Debug.LogFormat("加载：{0}完成，耗时{1}", item.fileName, Time.time - item.beginTime);
			}

			var cb = item.loaded;
			string fileName = item.fileName;
			item = LoadFileItem.Dispose(item);

			cb(fileName, data, ab);
			if (eLoadEnd != null)
				eLoadEnd(fileName, data != null || ab != null);
		}


		/// <summary>
		/// 强制调整加载
		/// <param name="v">指定是否强制高速加载</param>
		/// </summary>
		public void SetForceHighSpeed(bool v)
		{
			if (_ForceHighSpeed != v)
			{
				_ForceHighSpeed = v;
				SynLoadSpeed();
			}
		}

		void SynLoadSpeed()
		{
			_MaxLoadThread = (_ForceHighSpeed || _CurPriority == LoadPriority.HighSpeed) ? maxLoadThreadNum : 1;
		}


		/// <summary>
		/// 是否启用缓存机制（会大量增加ROM占有量）
		/// </summary>
		public bool enableCache
		{
			get { return _CacheEnabled; }
			set {
				if (_CacheEnabled != value)
				{
					_CacheEnabled = value;
					string path = cacheCfgPath;
					using(FileStream cfg = new FileStream(path,FileMode.OpenOrCreate,FileAccess.Write))
					{
						byte v = _CacheEnabled ? (byte)1 : (byte)0;
						cfg.WriteByte(v);
						cfg.Flush();
						cfg.Close();
					}
				}
			}
		}

		/// <summary>
		/// 单个文件加载的最长时间，超过的话就不等了，会启动下一个
		/// 默认10s
		/// </summary>
		public float maxLoadTime { get; set; }

		/// <summary>
		/// 当前正在加载的文件数量
		/// </summary>
		public int loadingCount { get { return _Loadings.Count; } }
		/// <summary>
		/// 当前正在加载的文件列表
		/// </summary>
		public string[] loadingFiles
		{
			get
			{
				string[] ret = new string[_Loadings.Count];
				for (var idx = 0; idx < _Loadings.Count; ++idx)
				{
					ret[idx] = _Loadings[idx].fileName;
				}
				return ret;
			}
		}
		public ResDir extRes
		{
			get
			{
				return _ExtRes;
			}
		}
	}
}
