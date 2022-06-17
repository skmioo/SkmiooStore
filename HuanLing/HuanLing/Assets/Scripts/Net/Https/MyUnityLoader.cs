using DRLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Skmioo.Net
{

	public class UnityLoadResult : DRLoader.INetResult
	{
		/// <summary>
		/// 下载是否成功
		/// </summary>
		public bool success { get; set; }
		/// <summary>
		/// 下载失败时的错误消息，没有为null
		/// </summary>
		public string msg { get; set; }
		/// <summary>
		/// 下载地址
		/// </summary>
		public string[] urls { get; set; }
		/// <summary>
		/// 下载到文件时存储路径
		/// </summary>
		public string path { get; set; }
		/// <summary>
		/// 下载到内存时下载好的数据
		/// </summary>
		public byte[] data { get; set; }
		/// <summary>
		/// 获取下载的文本，只有下载到内存时有效，使用UTF-8编码
		/// </summary>
		public string text
		{
			get
			{
				return GetText(System.Text.Encoding.UTF8);
			}
		}
		public string GetText(System.Text.Encoding encode)
		{
			if (data == null && path != null)
			{
				throw new InvalidOperationException(string.Format("Loaded data has save to {0}, not support parse it as text, please read it yourself!", path));
			}
			return encode.GetString(data);
		}
	}

	public class MyUnityLoadEvent : UYMO.EventBase
	{
		public const string Event_Load = "Event_Load";

		private UnityLoadStep _LoadStep;
		private MyUnityLoadRequest _Request;
		public MyUnityLoadEvent()
			: base(Event_Load)
		{ }
		public override void Reset()
		{
			base.Reset();
			_Request = null;
		}
		public void Reset(MyUnityLoadRequest aLoader, UnityLoadStep aLoadEvt)
		{
			Reset();
			_Request = aLoader;
			_LoadStep = aLoadEvt;
		}
		public MyUnityLoadRequest request
		{
			get { return _Request; }
		}
		public UnityLoadStep loadStep
		{
			get { return _LoadStep; }
		}
	}

	/// <summary>
	///  unity版本的http加载器
	/// </summary>
	public class MyUnityLoader : UYMO.EventBus, IMyNetLoader
	{
		private List<UnityLoadURL> _WaitList;
		private MyUnityLoadRequest _Request;
		private MyUnityLoadEvent _LoadEvent;
		public MyUnityLoader()
		{
			_WaitList = new List<UnityLoadURL>();
			_LoadEvent = new MyUnityLoadEvent();
		}

		/// <summary>
		/// 加载一个http地址
		/// </summary>
		/// <param name="url">http地址</param>
		/// <param name="savePath">加载内容保存路径，若为null则保存在内存</param>
		/// <param name="complete">加载完成回调</param>
		/// <param name="form">post请求时的表单</param>
		public void Load(string url, string savePath, Action<IMyNetResult> complete, MyPostForm form = null)
		{
			Load(new string[] { url }, savePath, complete, form);
		}

		/// <summary>
		/// 加载一个http地址
		/// </summary>
		/// <param name="url">http地址</param>
		/// <param name="breakPoint">是否要求断点续传</param>
		/// <param name="savePath">加载内容保存路径，若为null则保存在内存</param>
		/// <param name="complete">加载完成回调</param>
		/// <param name="form">post请求时的表单</param>
		public void Load(string[] url, string savePath, Action<IMyNetResult> complete, MyPostForm form = null)
		{
			UnityLoadURL item = new UnityLoadURL(url, form == null ? null : form.ToPostForm(), savePath);
			item.userdata = complete;
			_WaitList.Add(item);
			TryInvoke();
		}
		/// <summary>
		/// 取消指定的url的下载请求（如果已经在下载了，马上停止）
		/// </summary>
		/// <param name="url"></param>
		public void CancelLoad(string url)
		{
			if (_Request != null && _Request.EqualUrl(url))
			{
				_Request.Dispose();
				_Request = null;
				TryInvoke();
			}
			else
			{
				for (int i = 0; i < _WaitList.Count; ++i)
				{
					if (_WaitList[i].EqualUrl(url))
					{
						_WaitList.RemoveAt(i);
						break;
					}
				}
			}
		}
		/// <summary>
		/// 当前正在处理的请求
		/// </summary>
		public MyUnityLoadRequest currentRequest
		{
			get { return _Request; }
		}
		/// <summary>
		/// 下载管理器需要每帧驱动
		/// </summary>
		public void Update()
		{
			if (_Request != null)
				_Request.Update();
		}
		public bool loading
		{
			get
			{
				return _Request != null
					&& MyUnityLoadRequest.IsLoadingState(_Request.state);
			}
		}
		public bool pause
		{
			get
			{
				return !loading;
			}
			set
			{
				if (pause == value)
					return;
				if (_Request == null)
					return;
				if (value)
					_Request.Launch();
				else
					_Request.Shutdown();
			}
		}
		public NetLoadState state
		{
			get
			{
				if (_Request == null)
					return NetLoadState.Complete;
				switch (_Request.state)
				{
					case UnityLoadState.Nil:
					case UnityLoadState.Success:
					case UnityLoadState.IOError:
					case UnityLoadState.NetError:
					case UnityLoadState.UnknownError:
						return NetLoadState.Complete;
					case UnityLoadState.Content:
					case UnityLoadState.inner_Progress:
						return NetLoadState.Transfering;
					case UnityLoadState.inner_Reconnnect:
					case UnityLoadState.Request:
						return NetLoadState.Requesting;
					default:
						return NetLoadState.Complete;
				}
			}
		}
		public string error
		{
			get { return _Request == null ? null : _Request.lastError; }
		}
		public long speed
		{
			get { return _Request == null ? 0 : (long)_Request.speed; }
		}
		public float progress
		{
			get { return _Request == null ? 0.0f : _Request.progress; }
		}
		public long loaded
		{
			get { return _Request == null ? 0 : _Request.downloadLength; }
		}
		public long length
		{
			get { return _Request == null ? 0 : _Request.contentLength; }
		}
		public int curSrcIndex
		{
			get { return _Request == null ? 0 : _Request.urlIdx; }
		}

		MyNetLoadState IMyNetLoader.state => throw new NotImplementedException();

		private void TryInvoke()
		{
			if (_Request != null)
				return;
			if (_WaitList.Count > 0)
			{
				_Request = new MyUnityLoadRequest(_WaitList[0], HandleLoad);
				_WaitList.RemoveAt(0);
				_Request.Launch();
			}
		}
		private bool HandleLoad(MyUnityLoadRequest requester, UnityLoadStep loadStep)
		{
			if (loadStep == UnityLoadStep.Complete)
			{
				if (requester.state != UnityLoadState.Success)
				{
					Debug.LogErrorFormat("下载文件(页面)失败：{0}\nError: {1}", requester.url, requester.lastError);
				}
				else
				{
					Debug.LogFormat("下载文件(页面)成功：{0}", requester.url);
				}
				_Request = null;
				var cb = requester.userdata as Action<DRLoader.INetResult>;
				if (cb != null)
				{
					var result = new UnityLoadResult();
					result.urls = requester.urls;
					result.path = requester.outPath;
					result.data = requester.pageData;
					result.msg = requester.lastError;
					result.success = requester.state == UnityLoadState.Success;
					cb(result);
				}
				_LoadEvent.Reset(requester, loadStep);
				DispatchEvent(_LoadEvent);
				_LoadEvent.Reset();
				requester.Dispose();
				TryInvoke();
			}
			else if (loadStep == UnityLoadStep.Header)
			{
				Debug.LogFormat("文件头到来：{0} {1}", requester.contentLength, requester.url);
				_LoadEvent.Reset(requester, loadStep);
				DispatchEvent(_LoadEvent);
				_LoadEvent.Reset();
			}
			else if (loadStep == UnityLoadStep.Progress)
			{
				// Debug.LogFormat("进度：{0}/{1} {2:0.00}%", requester.downloadLength, requester.contentLength, requester.progress * 100.0f);
				_LoadEvent.Reset(requester, loadStep);
				DispatchEvent(_LoadEvent);
				_LoadEvent.Reset();
			}
			return true;
		}


	}
}
