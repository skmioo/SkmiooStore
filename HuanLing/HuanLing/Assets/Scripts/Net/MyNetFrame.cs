using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skmioo.Net
{

	/// <summary>
	/// 当前下载状态
	/// </summary>
	public enum MyNetLoadState
	{
		/// <summary>
		/// 请求中
		/// </summary>
		Requesting,
		/// <summary>
		/// 数据接收中
		/// </summary>
		Transfering,
		/// <summary>
		/// 下载完成
		/// </summary>
		Complete,
	}

	/// <summary>
	/// 网络下载返回信息
	/// </summary>
	public interface IMyNetResult
	{
		/// <summary>
		/// 下载是否成功
		/// </summary>
		bool success { get; }
		/// <summary>
		/// 下载失败时的错误消息，没有为null
		/// </summary>
		string msg { get; }
		/// <summary>
		/// 下载地址
		/// </summary>
		string[] urls { get; }
		/// <summary>
		/// 下载到文件时存储路径
		/// </summary>
		string path { get; }
		/// <summary>
		/// 下载到内存时下载好的数据
		/// </summary>
		byte[] data { get; }
		/// <summary>
		/// 获取下载的文本，只有下载到内存时有效，使用UTF-8编码
		/// </summary>
		string text { get; }
	}

	/// <summary>
	/// 一个统一的网络下载接口
	/// </summary>
	public interface IMyNetLoader
	{
		/// 下载给定url(s)
		/// </summary>
		/// <param name="url">url地址数组（第一个元素为默认url地址，其后的元素为备用地址）</param>
		/// <param name="savePath">下载内容存放的本地路径，传null表示直接存放到内存中</param>
		/// <param name="complete">下载结束（成功或者失败）的回调</param>
		/// <param name="form">post数据（post协议时使用）,传递null表示使用get协议</param>
		void Load(string[] url, string savePath, Action<IMyNetResult> complete, MyPostForm postForm = null);
		/// <summary>
		/// 取消下载
		/// </summary>
		/// <param name="url">下载地址</param>
		void CancelLoad(string url);
		/// <summary>
		/// 逻辑驱动
		/// </summary>
		void Update();
		/// <summary>
		/// 当前是否在下载中
		/// </summary>
		bool loading { get; }
		/// <summary>
		/// 暂停
		/// </summary>
		bool pause { get; set; }
		/// <summary>
		/// 当前下载状态
		/// </summary>
		MyNetLoadState state { get; }
		/// <summary>
		/// 最后的错误信息，没有返回null
		/// </summary>
		string error { get; }
		/// <summary>
		/// 当前的下载速度(byte/s)
		/// </summary>
		long speed { get; }
		/// <summary>
		/// 当前下载进度
		/// </summary>
		float progress { get; }
		/// <summary>
		/// 当前文件已经下载的字节数
		/// </summary>
		long loaded { get; }
		/// <summary>
		/// 当前文件总的下载字节数
		/// </summary>
		long length { get; }
		/// <summary>
		/// 当前下载的数据源索引
		/// </summary>
		int curSrcIndex { get; }
	}


	//网络连接及访问状态
	public enum MyNetworkState
	{
		None = 0,
		/// <summary>
		/// 没有网络连接
		/// </summary>
		NoConnect = 1,
		/// <summary>
		/// 使用的是数据连接
		/// </summary>
		Data = 2,
		/// <summary>
		/// 使用的是WIFI或网线连接
		/// </summary>
		Local = 4,
		/// <summary>
		/// 可访问互连网
		/// </summary>
		AccessInternet = 8,
		/// <summary>
		/// 不可访问互连网
		/// </summary>
		NoInternet = 16,
	}


	public class MyNetFrame
	{
		/// <summary>
		/// 临时文件的后缀
		/// </summary>
		public static string TempFileExt = ".dlf";
		/// <summary>
		/// 断点续传信息文件的后缀
		/// </summary>
		public static string BreakpointExt = ".dli";
		/// <summary>
		/// 用来测试网络是否正常的网站
		/// </summary>
		static string[] _ServerList = new string[]
		{
			"go.gz.ledo.com",
			"tx.gz.ledo.com",
			"baidu.com",
			"qq.com",
			"youku.com"
		};


		private static DRLoader.NetPing _Ping;


		//网络下载接口
		private static IMyNetLoader _UnityWebLoader;
		private static IMyNetLoader _MonoWebLoader;


		/// <summary>
		/// 默认的网络加载器
		/// </summary>
		public static IMyNetLoader netLoader
		{
			get
			{
				return monoWebLoader;
			}
		}
		/// <summary>
		/// MONO版本的http加载器
		/// </summary>
		public static IMyNetLoader monoWebLoader
		{
			get
			{
				if (_MonoWebLoader == null)
					_MonoWebLoader = new MyHttpLoader();
				return _MonoWebLoader;
			}
		}

		/// <summary>
		/// unity版本的http加载器
		/// </summary>
		public static IMyNetLoader unityWebLoader
		{
			get
			{
				if (_UnityWebLoader == null)
					_UnityWebLoader = new MyUnityLoader();
				return _UnityWebLoader;
			}
		}

		/// <summary>
		/// 外部需要持续驱动
		/// </summary>
		public static void Update()
		{
			if (_MonoWebLoader != null)
			{
				_MonoWebLoader.Update();
			}
			if (_UnityWebLoader != null)
			{
				_UnityWebLoader.Update();
			}

			if (_Ping != null)
			{
				_Ping.Update();
			}
		}


	}
}
