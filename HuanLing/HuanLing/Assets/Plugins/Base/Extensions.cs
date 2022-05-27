using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UYMO
{
    public static class Extensions
    {
        public static int IndexOf<T>(this T[] array, T item )
        {
            for (int idx = 0; idx < array.Length; ++idx )
            {
                if( array[idx].Equals(item))
                {
                    return idx;
                }
            }
            return -1;
        }

        public static int FindIndex<T>(this T[]array, Predicate<T> match)
        {
            for (int idx = 0; idx < array.Length; ++idx)
            {
                if (match(array[idx]))
                {
                    return idx;
                }
            }
            return -1;
        }

        public static int RemoveAll<T>(this T[] array, Predicate<T> match)
        {
            int pos = 0;
            for (var idx = 0; idx < array.Length; ++idx)
            {
                if (!match(array[idx]))
                {//不删除
                    array[pos] = array[idx];
                    ++pos;
                }
                array[idx] = default(T);
            }
            return pos;
        }

        public static T ElementAt<T>( this HashSet<T> set, int index )
        {
            int idx = 0;
            foreach( T elem in set )
            {
                if( idx == index )
                {
                    return elem;
                }
                ++idx;
            }
            return default(T);
        }

        /// <summary>
        /// 单个格式字符串
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string FormatWith(this string format, params object[] args)
        {
            if(format == null || args == null)
            {
                throw new ArgumentNullException((format == null) ? "format" : "args");
            }else
            {
                var capacity = format.Length + args.Where(a => a != null).Select(p => p.ToString()).Sum(p => p.Length);
                var stringBuilder = new StringBuilder(capacity);
                stringBuilder.AppendFormat(format, args);
                return stringBuilder.ToString();
            }
        }

        /// <summary>
        /// 针对多个格式字符串
        /// </summary>
        /// <param name="formats"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string FormatWith(this IEnumerable<string> formats, params object[] args)
        {
            if (formats == null || args == null)
            {
                throw new ArgumentNullException((formats == null) ? "format" : "args");
            }else
            {
                var capacity = formats.Where(f => !string.IsNullOrEmpty(f)).Sum(f => f.Length) + args.Where(a => a != null).Select(p => p.ToString()).Sum(p => p.Length);
                var stringBuilder = new StringBuilder(capacity);
                foreach(var f in formats)
                {
                    if(!string.IsNullOrEmpty(f))
                    {
                        stringBuilder.AppendFormat(f,args);
                    }
                }
                return stringBuilder.ToString();
            }
        }

        /// <summary>
        /// 将HasSet转换成数组
        /// </summary>
        /// <param name="hasset"></param>
        /// <returns></returns>
        public static T[] ToArray<T>(this HashSet<T> hasset)
        {
            T[] ret = new T[hasset.Count];
            var enu = hasset.GetEnumerator();
            int idx = 0;
            while(enu.MoveNext())
            {
                ret[idx++] = enu.Current;
            }
            return ret;
        }
    }
}
