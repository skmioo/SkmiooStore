/* ==============================================================================
   * 类名称：leexiang
   * 类描述：HtmlUtil
   * 创建人：leexiang-pc
   * 创建时间：2015/7/8 15:44:54
   * ==============================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SLua;
using UnityEngine;
using System.Text.RegularExpressions;
namespace UYMO
{
    [CustomLuaClassAttribute]
    public class HtmlUtil
    {
        static StringBuilder sBuilder = new StringBuilder();
        private const int DEFAULT_SIZE = 14;

        public const string WHITE = "#ffffff";

        public const string RED = "#ff0000";

        public const string YELLOW = "#ffff00";

        public const string GREEN = "#008000";

        public const string BLUE = "#0000ff";

        public const string GRAY = "#666666";

        public const string LIGHT_YELLOW = "#AD9D80";

        public const string TU_YELLOW = "#FAECB0";
        public static string Color(string str,string color)
        {
            return "<size=" + HtmlUtil.DEFAULT_SIZE + "><color=" + color + ">" + str + "</color></size>";
        }

        public static string ColorOnly(string str, string color)
        {
            return "<color=" + color + ">" + str + "</color>";
        }

        public static string StringByColor(string str,Color color)
        {
            return ColorOnly(str, ColorToString(color));
        }

        public static string Size(string str ,uint size)
        {
            return "<size=" + size + ">" + str + "</size>";
        }
            
        public static string I(string str)
        {
            return "<i>" + str + "</i>";
        }

        public static string B(string str)
        {
            return "<b>" + str + "</b>";
        }
        
        public static string ColorToString(Color c)
        {
            sBuilder.Length = 0;
            sBuilder.AppendFormat("#{0:X2}{1:X2}{2:X2}", (int)(c.r * 255), (int)(c.g * 255), (int)(c.b * 255));
            return sBuilder.ToString();
            //string rStr = Math.Floor((c.r * 255) / 16) == 0 ? "0" + Convert.ToString((int)(c.r * 255), 16) : Convert.ToString((int)(c.r * 255), 16);
            //string gStr = Math.Floor((c.g * 255) / 16) == 0 ? "0" + Convert.ToString((int)(c.g * 255), 16) : Convert.ToString((int)(c.g * 255), 16);
            //string bStr = Math.Floor((c.b * 255) / 16) == 0 ? "0" + Convert.ToString((int)(c.b * 255), 16) : Convert.ToString((int)(c.b * 255), 16);
            //return "#" + rStr + gStr + bStr;
        }

        public static string ColorToString2(Color c)
        {
            sBuilder.Length = 0;
            sBuilder.AppendFormat("{0:X2}{1:X2}{2:X2}", (int)(c.r * 255), (int)(c.g * 255), (int)(c.b * 255));
            return sBuilder.ToString();
            //string rStr = Math.Floor((c.r * 255) / 16) == 0 ? "0" + Convert.ToString((int)(c.r * 255), 16) : Convert.ToString((int)(c.r * 255), 16);
            //string gStr = Math.Floor((c.g * 255) / 16) == 0 ? "0" + Convert.ToString((int)(c.g * 255), 16) : Convert.ToString((int)(c.g * 255), 16);
            //string bStr = Math.Floor((c.b * 255) / 16) == 0 ? "0" + Convert.ToString((int)(c.b * 255), 16) : Convert.ToString((int)(c.b * 255), 16);
            //return rStr + gStr + bStr;
        }


        /// <summary>
        /// 处理Unity自带的富文本信息，从中提取出纯文本信息 Tips 消息中带有额外的 "< > "处理会出错
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>长度</returns>
        public static int GetLength(string str)
        {
            int start = 0;
            int output = 0;
            char bracket = '<';
            while (start < str.Length)
            {
                int idx = str.IndexOf(bracket, start);
                if (idx == -1)
                {
                    output = str.Length;
                    break;
                }
                if (bracket == '<')
                {
                    if (idx > start)
                    {
                        output += idx - start;
                    }
                    start = idx + 1;
                    bracket = '>';
                }
                else
                {
                    if (idx > start)
                    {
                        ;
                    }
                    start = idx + 1;
                    bracket = '<';
                }
            }
            return str.Length;
        }
        /// <summary>
        /// 获取给定字符串的字节长度
        /// 默认模式 一个汉字长度为2个字节
        /// </summary>
        /// <param name="str">纯文本信息请勿包含富文本信息</param>
        /// <returns>字节长度</returns>
        public static int GetByteLength(string str)
        {
            int count = 0;
            string chinese = "[\u4e00-\u9fa5]";
            for (int i = 0; i < str.Length; ++i )
            {
                var sub = str.Substring(i, 1);
                if (Regex.IsMatch(sub, chinese))
                {
                    count += 2;
                }
                else
                {
                    count += 1;
                }
            }
            return count;
        }

    }

}
