using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;

namespace DRLoader
{
    /// <summary>
    /// http post请求表单，用于请求下载后，请不要持有或者做其它操作
    /// </summary>
    public class PostForm
    {
        static Queue<PostForm> sPool = new Queue<PostForm>();
        public static PostForm Create()
        {
            return Create(Encoding.UTF8);
        }
        public static PostForm Create(Encoding encoder)
        {
            PostForm form = sPool.Count > 0 ? sPool.Dequeue() : new PostForm();
            form.Reset(encoder);
            return form;
        }

        private List<KeyValuePair<string, string>> _Fields;
        private Encoding _Encoder;
        private PostForm()
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
            get
            {
                return _Encoder.GetBytes(ToString());
            }
        }
        public void AddField(string name, string value)
        {
            value = Uri.EscapeDataString(value);
            _Fields.Add(new KeyValuePair<string, string>(name, value));
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
