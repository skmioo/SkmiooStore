using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SLua;

namespace UYMO
{
    /// <summary>
    /// 富文本工具
    /// </summary>
    [CustomLuaClassAttribute]
    public class RichTextUtil
    {
        /// <summary>
        /// 转义文本处理回调
        /// </summary>
        /// <param name="transfer">转义词（null表示没有转义，是普通文本）</param>
        /// <param name="text">文本参数（如果transfer是null，说明text是普通文本）</param>
        [DoNotToLuaAttribute]
        public delegate void ProcessTransferCallback(string transfer, string text);
        /// <summary>
        /// 转义文本处理回调
        /// </summary>
        /// <param name="lua">lua</param>
        /// <param name="transfer">转义词（null表示没有转义，是普通文本）</param>
        /// <param name="text">文本参数（如果transfer是null，说明text是普通文本）</param>
        [DoNotToLuaAttribute]
        public delegate void LuaProcessTransferCallback(LuaTable lua, string transfer, string text);

        private static UYFont s_defaultFont = UYFont.defaultFont;
        private static UYFont s_tmpFont = new UYFont();
        private static StringBuilder s_tmpHtmlBuilder = new StringBuilder();

        /// <summary>
        /// 富文本解析为html格式的文本
        /// </summary>
        /// <param name="richText">富文本</param>
        /// <param name="defaultFont">默认字体，传null表示使用系统默认字体</param>
        /// <returns>html格式文本</returns>
        public static string RichText2Html(string richText, UYFont defaultFont = null)
        {
            if (richText == null || richText == "")
                return "";
            if (defaultFont == null)
                s_defaultFont.SetAsDefault();
            else
                s_defaultFont.Set(defaultFont.size, defaultFont.color, defaultFont.style);
            s_tmpFont.Set(s_defaultFont.size, s_defaultFont.color, s_defaultFont.style);
            s_tmpHtmlBuilder.Length = 0;
            ProcessRichText(richText, _DoRichTransfer);
            return s_tmpHtmlBuilder.ToString();
        }

        public static string RichText2HtmlSize(string richText, int size)
        {
            s_defaultFont.SetAsDefault();
            UYFont defaultFont = s_defaultFont;
            defaultFont.size = size;
            return RichText2Html(richText, defaultFont);
        }

        private static void _DoRichTransfer(string transfer, string paramStr)
        {
            if (transfer == null)
            {
                s_tmpHtmlBuilder.Append(Wrap2Html(s_tmpFont, paramStr));
            }
            else if (transfer == "color")
            {
                s_tmpFont.color = MathUtil.ParseColor(paramStr);
            }
            else if (transfer == "size")
            {
                s_tmpFont.size = MathUtil.ParseInt(paramStr);
            }
            else if (transfer == "reset")
            {
                if (paramStr == "color")
                {
                    s_tmpFont.color = s_defaultFont.color;
                }
                else if (paramStr == "size")
                {
                    s_tmpFont.size = s_defaultFont.size;
                }
                else if (paramStr == "all")
                {
                    s_tmpFont.Set(s_defaultFont.size, s_defaultFont.color, s_defaultFont.style);
                }
            }
            else if(transfer == "link")
            {
                if (paramStr != "end")
                {
                    s_tmpHtmlBuilder.Append(Wrap2Html(s_tmpFont, "["));
                    s_tmpHtmlBuilder.Append("<a href=" + paramStr + ">");
                }
                else
                {
                    s_tmpHtmlBuilder.Append(Wrap2Html(s_tmpFont, "]"));
                    s_tmpHtmlBuilder.Append("</a>");
                }
            }
        }
        public static string Wrap2Html(UYFont font, string text)
        {
            return "<size=" + font.size + "><color=" + HtmlUtil.ColorToString(font.color) + ">" + text + "</color></size>";
        }

        /// <summary>
        /// 将成对的转义文本切割成转义词和转义参数
        /// </summary>
        /// <param name="transText">转义文本</param>
        /// <param name="transfer">转义词</param>
        /// <param name="paramStr">转义参数</param>
        /// <returns>有效的转义文本返回true</returns>
        public static bool SpliteTransfer(string transText, out string transfer, out string paramStr)
        {
            int idx = transText.IndexOf('=');
            if (idx == -1)
            {
                transfer = transText;
                paramStr = "";
                return true;
            }
            if (idx == 0)
            {
                transfer = null;
                paramStr = null;
                return false;
            }
            transfer = transText.Substring(0, idx);
            if (idx + 1 < transText.Length)
            {
                paramStr = transText.Substring(idx + 1);
            }
            else
            {
                paramStr = "";
            }
            return true;
        }
        /// <summary>
        /// 处理一段富文本
        /// </summary>
        /// <param name="richText">待处理的富文本</param>
        /// <param name="transferProcessFunc">转义处理回调函数</param>
        [DoNotToLuaAttribute]
        public static void ProcessRichText(string richText, ProcessTransferCallback transferProcessFunc)
        {
            _ProcessRichText(richText, transferProcessFunc, null, null);
        }
        /// <summary>
        /// 处理一段富文本
        /// </summary>
        /// <param name="richText">待处理的富文本</param>
        /// <param name="transferProcessFunc">转义处理回调函数</param>
        /// <param name="lua">lua</param>
        public static void ProcessRichText(string richText, LuaTable lua, LuaProcessTransferCallback transferProcessFunc)
        {
            _ProcessRichText(richText, null, transferProcessFunc, lua);
        }

        private static void _ProcessRichText(string richText, ProcessTransferCallback transferProcessFunc, LuaProcessTransferCallback luaProcFunc, LuaTable lua)
        {
            int start = 0;
            char bracket = '[';
            while (start < richText.Length)
            {
                int idx = richText.IndexOf(bracket, start);
                if (idx == -1)
                {//没有任何转义数据，退出
                    break;
                }
                if (bracket == '[')
                {//遇到左括号，转义开始
                    if (idx > start)
                    {//处理之前的普通文本
                        _CallbackTransfer(null, richText.Substring(start, idx - start), transferProcessFunc, luaProcFunc, lua);
                    }
                    start = idx + 1;
                    //等待右括号到来
                    bracket = ']';
                }
                else
                {//遇到右括号（左括号已经遇到），处理转义
                    if (idx > start)
                    {//处理转义
                        string transfer; string paramStr;
                        if (SpliteTransfer(richText.Substring(start, idx - start), out transfer, out paramStr))
                        {
                            _CallbackTransfer(transfer, paramStr, transferProcessFunc, luaProcFunc, lua);
                        }
                    }
                    start = idx + 1;
                    //等待左括号来
                    bracket = '[';
                }
            }
            if (start < richText.Length)
            {//部分文本未处理完
                if (bracket == '[')
                {//剩下的文本是普通文本
                    if (start == 0)
                        _CallbackTransfer(null, richText, transferProcessFunc, luaProcFunc, lua);
                    else
                        _CallbackTransfer(null, richText.Substring(start), transferProcessFunc, luaProcFunc, lua);
                }
                else
                {//剩下的文本是转义文本，但是右括号没有，所以直接丢弃
                }
            }
        }
        private static void _CallbackTransfer(string transfer, string paramStr, ProcessTransferCallback transferProcessFunc, LuaProcessTransferCallback luaProcFunc, LuaTable lua)
        {
            if (transferProcessFunc != null)
                transferProcessFunc(transfer, paramStr);
            else if (luaProcFunc != null)
                luaProcFunc(lua, transfer, paramStr);
        }
    }
}
