using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Skmioo.Net
{
	/// <summary>
	/// 支持网络请求跟文件下载请求
	/// </summary>
	public class MyHttpRequest
	{
		enum MyRequestStep
		{
			Requesting,
			Complete,
			Done
		}

		HttpWebRequest _Request;
		HttpWebResponse _Response;

		string _Url;
		MyPostForm _Form;
		int _Pos;
		byte[] _PostData;
		Action<bool, string> _CompleteCallBack;
		float _TimeOut = 6f;
		float _StartTime = 0;

		MyRequestStep _Step;
		string _Error;

		/// <summary>
		/// 正常的Get请求 数据保存与发起请求
		/// </summary>
		/// <param name="url"></param>
		/// <param name="pos"></param>
		/// <param name="callBack"></param>
		public void Request(string url, int pos, Action<bool, string> callBack)
		{
			if (_Request != null)
			{
				throw new InvalidOperationException("Request is running, please waite it complete!");
			}
			try
			{
				_Url = url;
				_Pos = pos;
				_CompleteCallBack = callBack;
				_Step = MyRequestStep.Requesting;
				_Error = null;
				_Request = HttpWebRequest.Create(_Url) as HttpWebRequest;
				_Request.AddRange(_Pos);
				_Request.Timeout = (int)(_TimeOut * 1000);
				_Request.KeepAlive = false;
				_StartTime = Time.time;
				_Request.BeginGetResponse(new AsyncCallback(GetResponseCallback), _Request);
			}
			catch (Exception e)
			{
				MarkComplete(e.ToString());
			}
		}


		/// <summary>
		/// 正常的Post请求 请求数据保存
		/// </summary>
		/// <param name="url"></param>
		/// <param name="pos"></param>
		/// <param name="callBack"></param>
		public void RequestPost(string url, MyPostForm form, int pos, Action<bool, string> callBack)
		{
			if (_Request != null)
			{
				throw new InvalidOperationException("Request is running, please waite it complete!");
			}
			_Url = url;
			_Form = form;
			_Pos = pos;
			_CompleteCallBack = callBack;
			_Step = MyRequestStep.Requesting;
			_Error = null;
			HandleRequestPost();
		}

		/// <summary>
		/// 正常的Post请求 请求配置
		/// </summary>
		/// <param name="url"></param>
		/// <param name="pos"></param>
		/// <param name="callBack"></param>
		void HandleRequestPost()
		{
			try
			{
				_Request = HttpWebRequest.Create(_Url) as HttpWebRequest;
				_Request.AddRange(_Pos);
				_Request.Timeout = (int)(_TimeOut * 1000);
				_Request.Method = "POST";
				_Request.KeepAlive = false;
				_Request.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
				_PostData = _Form.data;
				_Request.ContentLength = _PostData.Length;
				_Request.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), _Request);
				_StartTime = Time.time;
			}
			catch (Exception e)
			{
				MarkComplete(e.ToString());
			}
		}

		/// <summary>
		/// 正常的Post请求 获取写入流 并写入Post数据
		/// </summary>
		/// <param name="url"></param>
		/// <param name="pos"></param>
		/// <param name="callBack"></param>
		private void GetRequestStreamCallback(IAsyncResult asynResult)
		{
			try
			{
				HttpWebRequest request = asynResult.AsyncState as HttpWebRequest;
				Stream stream = request.EndGetRequestStream(asynResult);
				stream.Write(_PostData, 0, _PostData.Length);
				stream.Close();
				request.BeginGetResponse(new AsyncCallback(GetResponseCallback), request);
			}
			catch (Exception e)
			{
				MarkComplete(e.ToString());
			}
		}


		/// <summary>
		/// 发送请求后，收到的回复处理
		/// </summary>
		/// <param name="url"></param>
		/// <param name="pos"></param>
		/// <param name="callBack"></param>
		void GetResponseCallback(IAsyncResult asynResult)
		{
			try
			{
				HttpWebRequest request = asynResult.AsyncState as HttpWebRequest;
				_Response = request.EndGetResponse(asynResult) as HttpWebResponse;
				MarkComplete(null);
			}
			catch (Exception e)
			{
				MarkComplete(e.ToString());
			}

		}

		void MarkComplete(string err)
		{
			if (_Step == MyRequestStep.Requesting)
			{
				_Step = MyRequestStep.Complete;
				_Error = err;
			}
		}


		/// <summary>
		/// 返回数据长度
		/// </summary>
		public long length
		{
			get
			{
				return _Response == null ? 0 : _Pos + _Response.ContentLength;
			}
		}

		/// <summary>
		/// 返回的数据流文件
		/// </summary>
		public Stream stream
		{
			get
			{
				return _Response == null ? null : _Response.GetResponseStream();
			}
		}

		/// <summary>
		/// 是否还在请求中
		/// </summary>
		public bool running
		{
			get
			{
				return _Request != null;
			}
		}


		public float timeOut
		{
			get { return _TimeOut; }
			set { _TimeOut = value; }
		}

		/// <summary>
		/// 主动结束当前的请求，清空数据以使可开启下一个请求
		/// </summary>
		public void DoneRequest(bool clearCallback = true)
		{
			if (clearCallback)
			{
				_CompleteCallBack = null;
			}

			if (_Response != null)
			{
				_Response.Close();
				_Response = null;
			}
			if (_Request != null)
			{
				_Request.Abort();
				_Request = null;
			}
		}

		public void Update()
		{
			if (_Request != null && _Step == MyRequestStep.Requesting && Time.time >= _StartTime + _TimeOut)
			{//请求超时
				DoneRequest(false);
				//Complete(false, string.Format("request timeout {0}s", _TimeOut));
			}

			if (_Step == MyRequestStep.Complete)
			{
				Complete(_Error == null, _Error);
			}
		}

		void Complete(bool success, string error)
		{
			_Step = MyRequestStep.Done;
			var temp = _CompleteCallBack;
			_CompleteCallBack = null;
			if (temp != null)
			{
				temp(success, error);
			}
		}

	}
}
