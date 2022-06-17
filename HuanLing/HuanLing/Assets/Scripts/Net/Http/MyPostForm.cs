using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Skmioo.Net
{
	/// <summary>
	/// http post请求表单，用于请求下载后，请不要持有或者做其它操作
	/// </summary>
	public class MyPostForm
	{
		static Queue<MyPostForm> sPool = new Queue<MyPostForm>();

		public static MyPostForm Create()
		{
			return Create(Encoding.UTF8);
		}

		public static MyPostForm Create(Encoding encoder)
		{
			MyPostForm form = sPool.Count == 0 ? new MyPostForm() : sPool.Dequeue();
			form.Reset(encoder);
			return form;
		}

		//List<KeyValuePair<TKey,TValue>> 与 Dictionary<TKey,TValue> 不同
		//前者可以有相同的key，后者不可以 前者可以转化为后者
		//Dictionary<string, string> dictionary = list.ToDictionary(x => x.Key, x => x.Value);
		private List<KeyValuePair<string, string>> _Fields;
		private Encoding _Encoder;

		public MyPostForm()
		{
			_Fields = new List<KeyValuePair<string, string>>();
		}

		private void Reset(Encoding aEncoder)
		{
			_Fields.Clear();
			_Encoder = aEncoder;
		}

		private void Dispose()
		{
			_Fields = null;
			_Encoder = null;
		}

		public byte[] data
		{
			get {
				return _Encoder.GetBytes(ToString());
			}
		}

		public void AddField(string name, string value)
		{
			//把value转化为uri提交表单时的数据
			//http://www.contoso.com/index.htm#search 转化后 http%3A%2F%2Fwww.contoso.com%2Findex.htm%23search
			value = Uri.EscapeDataString(value);
			_Fields.Add(new KeyValuePair<string, string>());
		}

		public int fieldCount
		{
			get { return _Fields.Count; }
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			for (int i = 0; i < _Fields.Count; ++i)
			{
				var f = _Fields[i];
				if (i == 0)
				{
					sb.AppendFormat("{0}={1}", f.Key, f.Value);
				}
				else
				{
					sb.AppendFormat("&{0}={1}", f.Key, f.Value);
				}
			}
			return sb.ToString();
		}

		public WWWForm ToPostForm()
		{
			var w = new WWWForm();
			for (int i = 0; i < _Fields.Count; ++i)
			{
				var f = _Fields[i];
				w.AddField(f.Key, f.Value, _Encoder);
			}
			return w;
		}

	}
}
