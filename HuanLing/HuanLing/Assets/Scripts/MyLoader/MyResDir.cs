using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skmioo.MyLoader
{
	/// <summary>
	/// 一个资源目录的管理类
	/// </summary>
	public class MyResDir : IDisposable
	{

		/// <summary>
		/// ExtResDirPath return _StoragePathRoot + "ExtRes";
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static MyResDir Create(string path)
		{
			return new MyResDir(path);
		}

		public static bool CheckValidResDir(string path)
		{
			if (!Directory.Exists(path))
			{
				return false;
			}
			string p = FormatDirPath(path);
			string verPath = p + "/" + VerFileName;
			return File.Exists(verPath);
		}
		const string VerFileName = ".version";
		string _DirPath = null;
		#region HEAD
		private const string sHeadVer = "v1";
		struct Head
		{
			public string headVer;
			public string branch;
			public long version;
			public static Head Load(string path)
			{
				if (File.Exists(path))
				{
					try
					{
						string content = File.ReadAllText(path, Encoding.ASCII);
						var ret = LitJson.JsonMapper.ToObject<Head>(content);
						if (ret.headVer == sHeadVer)
						{
							return ret;
						}
					}
					catch (Exception e)
					{
						UnityEngine.Debug.LogErrorFormat("Read ResDir head failed! {0}", e);
					}
				}
				Head nHead;
				nHead.headVer = sHeadVer;
				nHead.branch = "";
				nHead.version = 0;
				return nHead;
			}

			public void Save(string path)
			{
				try
				{
					string content = LitJson.JsonMapper.ToJson(this);
					File.WriteAllText(path,content);
				}
                catch(Exception e)
                {
                    UnityEngine.Debug.LogErrorFormat("Save ResDir head failed! {0}", e);
                }
			 }

		}

		Head _Head;
		#endregion

		HashSet<string> _AllRes;
		string _AddingRes;
		FileStream _Saving;

		public MyResDir(string path)
		{
			_AllRes = new HashSet<string>();
			_DirPath = FormatDirPath(path) + "/";
			if (!Directory.Exists(_DirPath))
			{
				Directory.CreateDirectory(_DirPath);
			}
			_Head = Head.Load(_DirPath + VerFileName);
			DirectoryInfo dir = new DirectoryInfo(_DirPath);
			FileInfo[] allfile = dir.GetFiles();
			for (var idx = 0; idx < allfile.Length; ++idx)
			{
				if (allfile[idx].Name != VerFileName)
				{
					_AllRes.Add(allfile[idx].Name);
				}
			}
		}

		/// <summary>
		/// 资源分支信息
		/// </summary>
		public string branchName
		{
			get
			{
				return _Head.branch;
			}
		}
		/// <summary>
		/// 资源版本信息
		/// </summary>
		public long version
		{
			get
			{
				return _Head.version;
			}
		}


		internal bool Exist(string resName)
		{
			return _AllRes.Contains(resName);
		}

		public void Dispose()
		{

		}

		/// <summary>
		/// 获取资源的完整路径
		/// </summary>
		/// <param name="resName">资源名称</param>
		/// <returns></returns>
		public string GetResPath(string resName)
		{
			return _DirPath + resName;
		}


		/// <summary>
		/// 将资源目录清空，删除所有资源
		/// </summary>
		public void Clear()
		{
			_Head.branch = "";
			_Head.version = 0;
			_AllRes.Clear();
			DirectoryInfo dir = new DirectoryInfo(_DirPath);
			FileInfo[] files = dir.GetFiles();
			for (int idx = 0; idx < files.Length; ++idx)
			{
				if (files[idx].Extension != VerFileName)
				{
					File.Delete(files[idx].FullName);
				}
			}
		}

		/// <summary>
		/// 开始添加资源
		/// </summary>
		/// <param name="resName">资源名称</param>
		public void BeginAddRes(string resName)
		{
			if (Exist(resName))
			{
				throw new InvalidOperationException(string.Format("Exist Res {0} already in ResDir {1}", resName, _DirPath));
			}

			if (_Saving != null || _AddingRes != null)
			{
				throw new InvalidOperationException("Now is adding res, can't begin an other add!");
			}
			string path = GetResPath(resName);
			_AddingRes = resName;
			_Saving = new FileStream(path, FileMode.Open, FileAccess.Write);
		}

		/// <summary>
		/// 处理添加数据到资源
		/// </summary>
		/// <param name="data">资源数据</param>
		/// <param name="offset">data中偏移</param>
		/// <param name="length">data中的长度需要被添加</param>
		public void ProcessSaveRes(byte[] data, int offset, int length)
		{
			_Saving.Write(data, offset, length);
		}

		/// <summary>
		/// 结束添加资源
		/// </summary>
		/// <param name="resName">资源名称</param>
		/// <param name="cancelAdd">是否取消本次添加的资源（删除已添加的资源）</param>
		public void EndAddRes(string resName, bool cancelAdd)
		{
			if (_AddingRes != resName)
			{
				throw new InvalidOperationException(string.Format("End add res failed! Now adding res is {0}, not {1}", _AddingRes, resName));
			}
			_Saving.Flush();
			_Saving.Close();
			_AddingRes = null;
			_Saving = null;
			if (cancelAdd)
			{
				string path = GetResPath(resName);
				if (File.Exists(path))
				{
					File.Delete(path);
				}
			}
			else
			{
				_AllRes.Add(resName);
			}
		}



		/// <summary>
		/// 添加资源到资源目录
		/// </summary>
		/// <param name="resName">资源名称</param>
		/// <param name="data">资源数据</param>
		public void AddRes(string resName, byte[] data)
		{
			if (Exist(resName))
			{
				throw new InvalidOperationException(string.Format("Exist Res {0} already in ResDir {1}", resName, _DirPath));
			}
			string path = GetResPath(resName);
			FileStream res = new FileStream(path, FileMode.Create, FileAccess.Write);
			res.Write(data, 0, data.Length);
			res.Flush();
			res.Close();
			_AllRes.Add(resName);
		}

		/// <summary>
		/// 添加资源到资源目录
		/// </summary>
		/// <param name="resName">资源名称</param>
		/// <param name="srcPath">资源所在路径</param>
		public void AddRes(string resName, string srcPath)
		{
			if (!File.Exists(srcPath))
			{
				throw new InvalidOperationException(string.Format("Resource file not find! {0}", srcPath));
			}
			if (Exist(resName))
			{
				throw new InvalidOperationException(string.Format("Exist Res {0} already in ResDir {1}", resName, _DirPath));
			}
			string path = GetResPath(resName);
			FileStream target = new FileStream(path, FileMode.Create, FileAccess.Write);
			FileStream reader = new FileStream(srcPath, FileMode.Open, FileAccess.Read);
			byte[] data = new byte[reader.Length]; //10M的缓存
			
			reader.Read(data, 0, data.Length);
			target.Write(data,0, data.Length);
			

			target.Flush();
			target.Close();
			reader.Close();
			_AllRes.Add(resName);
			
		}


		/// <summary>
		/// 删除资源
		/// </summary>
		/// <param name="resName">资源名称</param>
		public void DelRes(string resName)
		{
			string path = GetResPath(resName);
			if (File.Exists(path))
			{
				File.Delete(path);
			}
			_AllRes.Remove(resName);
		}

		/// <summary>
		/// 设置版本信息
		/// </summary>
		/// <param name="branch">分支编号</param>
		/// <param name="version">版本号</param>
		public void SetInfo(string branch, long version)
		{
			_Head.branch = branch;
			_Head.version = version;
			_Head.Save(_DirPath + VerFileName);
		}
		/// <summary>
		/// 格式化一个目录路径，保证其不会以\或/结尾
		/// </summary>
		public static string FormatDirPath(string path)
		{
			if (string.IsNullOrEmpty(path))
			{
				return path;
			}
			int lastNot = path.Length - 1;
			while (path[lastNot] == '/' || path[lastNot] == '\\' || lastNot < 0)
			{
				--lastNot;
			}
			return lastNot >= path.Length - 1 ? path : path.Substring(0, lastNot + 1);
		}
	}
}
