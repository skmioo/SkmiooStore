using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using SLua;
using UYMO;

namespace UnityEngine.UI
{
    /// <summary>
    /// 富文本文字组件
    /// 支持标签：[color],[size],[image],[link],[reset]
    /// </summary>
    [CustomLuaClass]
    [AddComponentMenu("YUI/YRichLabel", 10)]
    [Serializable]
    public class YRichLabel : YLabel, IPointerClickHandler, IPointerDownHandler, IClearable
    {
        /// <summary>
        /// 富文本字符串
        /// </summary>
        [SerializeField]
        private string _RichText = "";

        /// <summary>
        /// 富文本字符串
        /// </summary>
        public string richText
        {
            get { return _RichText; }
            set
            {
                if(_RichText != value)
                {
                    _RichText = value;
                    text = AnalyzeRichText();
                }
            }
        }

        /// <summary>
        /// 富文本图片大小
        /// </summary>
        [SerializeField]
        private Vector2 _ImageSize;

        /// <summary>
        /// 富文本图片大小
        /// </summary>
        public Vector2 imageSize
        {
            get { return _ImageSize; }
            set
            {
                if (_ImageSize != value)
                {
                    _ImageSize = value;
                    text = AnalyzeRichText();
                    SetVerticesDirty();
                    SetLayoutDirty();
                }
            }
        }

        /// <summary>
        /// 文本构造器
        /// </summary>
        private static readonly StringBuilder s_TextBuilder = new StringBuilder();

        /// <summary>
        /// 初始字体
        /// </summary>
        private UYFont _DefaultFont;

        /// <summary>
        /// 当前富文本影响下字体
        /// </summary>
        private UYFont _TmpFont;

        /// <summary>
        /// 一张图片占用空格的数量
        /// </summary>
        private int _BlankNumberPerImage;

        /// <summary>
        /// 空格
        /// </summary>
        private char _BlankChar = '　'; // 中文空格

        /// <summary>
        /// 一张图片占用的宽
        /// </summary>
        private float _BlankWidthPerImage;

        /// <summary>
        /// 一张图片占用的高
        /// </summary>
        private float _BlankHeightPerImage;

        /// <summary>
        /// 一张图片需要占用的额外高度
        /// 图片的高度 - 文字的高度
        /// </summary>
        private float _ExtraHeightPerImage;

        /// <summary>
        /// 所有行信息
        /// </summary>
        private List<YLabelLineInfo> _Lines = new List<YLabelLineInfo>();
        /// <summary>
        /// image所在行集合
        /// </summary>
        private HashSet<int> _ImageLines = new HashSet<int>();

        /// <summary>
        /// 加入图片后的总偏移量
        /// </summary>
        public float totalOffset = 0;

        /// <summary>
        /// 最佳高度
        /// </summary>
        public override float preferredHeight
        {
            get
            {
                if (_ImageInfoList.Count > 0)
                {
                    return base.preferredHeight + totalOffset;
                }

                return base.preferredHeight;
            }
        }

        /// <summary>
        /// 行数
        /// </summary>
        public int lineCount
        {
            get { return _Lines == null ? 0 : _Lines.Count; }
        }

        /// <summary>
        /// 按行号获得该行图片照成的偏移
        /// </summary>
        public float GetLineImageOffset(int lineIdx)
        {
            if (_Lines == null || _Lines.Count - 1 < lineIdx)
            {
                return 0;
            }
            return _Lines[lineIdx].offset;
        }

        /// <summary>
        /// 富文本图片信息列表
        /// </summary>
        private List<YLabelImageInfo> _ImageInfoList = new List<YLabelImageInfo>();

        /// <summary>
        /// 超链接点击EventClass
        /// </summary>
        [Serializable]
        public class HrefClickEvent : UnityEvent<string, string> { }

        /// <summary>
        /// 超链接点击Event
        /// </summary>
        [SerializeField]
        private HrefClickEvent _OnHrefClick = new HrefClickEvent();

        /// <summary>
        /// 超链接点击Event
        /// </summary>
        public HrefClickEvent onHrefClick
        {
            get { return _OnHrefClick; }
            set { _OnHrefClick = value; }
        }

        /// <summary>
        /// 超链接点击LuaClass
        /// </summary>
        private LuaTable _OnHrefLua;

        /// <summary>
        /// 超链接的默认点击处理，与_LuaOnHrefClick不共存
        /// </summary>
        public static Action<string, string> LuaDefHrefClick;

        /// <summary>
        /// 超链接点击Lua回调
        /// </summary>
        private Action<LuaTable, string, string> _LuaOnHrefClick;

        /// <summary>
        /// 非超链接点击LuaClass
        /// </summary>
        private LuaTable _OnNoHrefLua;

        /// <summary>
        /// 非超链接点击Lua回调
        /// </summary>
        private Action<LuaTable> _LuaOnNoHrefClick;

        /// <summary>
        /// OnPopulateMesh LuaClass
        /// </summary>
        private LuaTable _OnPopulateMeshLua;

        /// <summary>
        /// OnPopulateMesh Lua回调
        /// </summary>
        private Action<LuaTable> _LuaOnPopulateMesh;

        /// <summary>
        /// 设置超链接点击Lua回调
        /// </summary>
        public void SetLuaOnHrefClick(LuaTable lua, Action<LuaTable, string, string> callBack)
        {
            _OnHrefLua = lua;
            _LuaOnHrefClick = callBack;

        }

        /// <summary>
        /// 设置非超链接点击Lua回调
        /// </summary>
        public void SetLuaOnNoHrefClick(LuaTable lua, Action<LuaTable> callBack)
        {
            _OnNoHrefLua = lua;
            _LuaOnNoHrefClick = callBack;
        }

        public void SetLuaOnPopulateMeshCallBack(LuaTable lua, Action<LuaTable> callBack)
        {
            _OnPopulateMeshLua = lua;
            _LuaOnPopulateMesh = callBack;
        }

        /// <summary>
        /// 清空所有回调
        /// </summary>
        public void ClearLuaHandler()
        {
            _OnHrefLua = null;
            _LuaOnNoHrefClick = null;
            _OnNoHrefLua = null;
            _LuaOnNoHrefClick = null;
            _OnPopulateMeshLua = null;
            _LuaOnPopulateMesh = null;
        }

        /// <summary>
        /// 超链接信息列表
        /// </summary>
        private List<YHrefInfo> _HrefInfoList = new List<YHrefInfo>();

        protected override void Awake()
        {
            base.Awake();
            if (_RichText != null || _RichText != "")
            {
                text = AnalyzeRichText();
            }
        }

        /// <summary>
        /// 点击事件处理
        /// 分发点击
        /// </summary>
        [DoNotToLua]
        public void OnPointerClick(PointerEventData eventData)
        {
            Vector2 clickPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out clickPoint);
            bool noHref = true;
            for (int i = 0; i < _HrefInfoList.Count; i++)
            {
                var info = _HrefInfoList[i];
                var checkRects = info.clickCheckRects;
                for (int j = 0; j < checkRects.Count; j++)
                {
                    var checkRect = checkRects[j];
                    if (checkRect.Contains(clickPoint))
                    {
                        noHref = false;
                        //分发点击
                        _OnHrefClick.Invoke(info.name, info.param);

                        //分发到Lua
                        if (_OnHrefLua != null && _LuaOnHrefClick != null)
                        {
                            _LuaOnHrefClick(_OnHrefLua, info.name, info.param);
                        }
                        else if (YRichLabel.LuaDefHrefClick != null)
                        {
                            YRichLabel.LuaDefHrefClick(info.name, info.param);
                        }
                    }
                }
            }

            //没有超链接点击，但label被点击分发
            if (noHref && _OnNoHrefLua != null && _LuaOnNoHrefClick != null)
            {
                _LuaOnNoHrefClick(_OnNoHrefLua);
            }
        }

        protected override void OnPopulateMesh(VertexHelper toFill)
        {
            base.OnPopulateMesh(toFill);
            UIVertex vert = new UIVertex();

            //处理图片
            //计算图片位置
            for (int i = 0; i < _ImageInfoList.Count; ++i)
            {
                var imageInfo = _ImageInfoList[i];
                var imageIndex = imageInfo.index * 4;
                if (imageIndex >= toFill.currentVertCount)
                {
                    //无效，丢弃
                    continue;
                }
                toFill.PopulateUIVertex(ref vert, imageInfo.index * 4);
                Vector2 imagePos = new Vector2(vert.position.x, vert.position.y);
                imagePos.x += _BlankWidthPerImage / 2;
                imagePos.y += _ImageSize.y < _BlankHeightPerImage ? _ImageSize.y / 2 : _BlankHeightPerImage / 2;
                var lineIndex = _ImageInfoList[i].line;
                if (lineIndex != -1)
                {
                    var ylineInfo = _Lines[lineIndex];
                    imagePos.y += ylineInfo.offset;
                }
                
                imageInfo.imagePosition = imagePos;
                if (imageInfo.imageRtt)
                {
                    imageInfo.imageRtt.anchoredPosition = imagePos;
                }
            }

            // 根据图片带来偏移调整顶点数据
            for (int i = 0; i < _Lines.Count; ++i)
            {
                var lineInfo = _Lines[i];
                if (lineInfo.offset == 0)
                {
                    continue;
                }
                int beginVertexIndex = lineInfo.startCharIdx * 4;
                int endVertexIndex = lineInfo.endCharIdx * 4 + 3; //换行符号不是4个顶点
                for (int j = beginVertexIndex; j <= endVertexIndex; ++j)
                {
                    UIVertex newVertex = new UIVertex();
                    toFill.PopulateUIVertex(ref newVertex, j);
                    newVertex.position = new Vector3(newVertex.position.x, newVertex.position.y + lineInfo.offset, newVertex.position.z);
                    toFill.SetUIVertex(newVertex, j);
                }
            }


            //处理超链接        
            //获得超链接的点击检查区域
            for (int i = 0; i < _HrefInfoList.Count; ++i)
            {
                var hrefInfo = _HrefInfoList[i];
                hrefInfo.clickCheckRects.Clear();
                if (hrefInfo.startIndex >= toFill.currentVertCount || hrefInfo.endIndex == -1)
                {
                    //无效信息，丢弃
                    continue;
                }

                // 将超链接里面的文本顶点索引坐标加入到包围框
                toFill.PopulateUIVertex(ref vert, hrefInfo.startIndex);
                var pos = vert.position;
                var bounds = new Bounds(pos, Vector3.zero);
                for (int j = hrefInfo.startIndex; j < hrefInfo.endIndex; ++j)
                {
                    if (j >= toFill.currentVertCount)
                    {
                        break;
                    }

                    toFill.PopulateUIVertex(ref vert, j);
                    pos = vert.position;
                    if (pos.x < bounds.min.x) // 换行重新添加包围框
                    {
                        hrefInfo.clickCheckRects.Add(new Rect(bounds.min, bounds.size));
                        bounds = new Bounds(pos, Vector3.zero);
                    }
                    else
                    {
                        bounds.Encapsulate(pos); // 扩展包围框
                    }
                }
                hrefInfo.clickCheckRects.Add(new Rect(bounds.min, bounds.size));
            }

            if (_LuaOnPopulateMesh != null && _OnPopulateMeshLua != null)
            {
                _LuaOnPopulateMesh(_OnPopulateMeshLua);
            }
        }

        [DoNotToLua]
        public override void SetVerticesDirty()
        {
            //更新image的anchor
            for (int i = 0; i < _ImageInfoList.Count; ++i)
            {
                var imageInfo = _ImageInfoList[i];
                if (imageInfo.imageRtt != null)
                    imageInfo.imageRtt.anchorMin = imageInfo.imageRtt.anchorMax = rectTransform.pivot;
            }
            base.SetVerticesDirty();
        }

        /// <summary>
        /// 检查图片所在行号
        /// </summary>
        private int CheckImageLine(int imageIndex)
        {
            int lineIndex = -1;
            for (int i = 0; i < _Lines.Count; ++i)
            {
                var yline = _Lines[i];
                if (imageIndex >= yline.startCharIdx && imageIndex <= yline.endCharIdx)
                {
                    lineIndex = i;
                    if (!_ImageLines.Contains(i))
                    {
                        _ImageLines.Add(i);
                    }
                }
            }
            return lineIndex;
        }

        /// <summary>
        /// 计算图片偏移量
        /// </summary>
        private void CalcImageOffset(TextGenerator textGen)
        {
            totalOffset = 0;
            
            //解析行信息
            _ImageLines.Clear();
            var textlines = textGen.lines;
            _Lines.Clear();
            
            for (int i = 0; i < textlines.Count; ++i)
            {
                var yline = new YLabelLineInfo();
                yline.height = textlines[i].height;
                yline.startCharIdx = textlines[i].startCharIdx;
                if (i + 1 >= textlines.Count)
                {
                    yline.endCharIdx = textGen.characterCount - 2;
                }
                else
                {
                    yline.endCharIdx = textlines[i + 1].startCharIdx - 1;
                }
                _Lines.Add(yline);
            }
            for (int i = 0; i < _ImageInfoList.Count; ++i)
            {
                var imageInfo = _ImageInfoList[i];
                int imageIndex = imageInfo.index;
                int imageLine = CheckImageLine(imageIndex);
                imageInfo.line = imageLine;

            }

            float imageExtraHeight = _ExtraHeightPerImage;
            if (alignment == TextAnchor.UpperCenter || alignment == TextAnchor.UpperLeft || alignment == TextAnchor.UpperRight)
            {
                // 从上到下
                for (int i = 0; i < _Lines.Count; ++i)
                {
                    var line = _Lines[i];
                    if (i > 0 && _ImageLines.Contains(i - 1))
                        totalOffset -= imageExtraHeight / 2;
                    if (_ImageLines.Contains(i))
                        totalOffset -= imageExtraHeight / 2;
                    line.offset = totalOffset;
                    _Lines[i] = line;
                }
                totalOffset = -totalOffset;
            }
            else if (alignment == TextAnchor.LowerCenter || alignment == TextAnchor.LowerLeft || alignment == TextAnchor.LowerRight)
            {
                // 从下到上
                for (int i = _Lines.Count - 1; i >= 0; --i)
                {
                    var line = _Lines[i];
                    if (i < _Lines.Count - 1 && _ImageLines.Contains(i + 1))
                        totalOffset += imageExtraHeight / 2;
                    if (_ImageLines.Contains(i))
                        totalOffset += imageExtraHeight / 2;
                    line.offset = totalOffset;
                    _Lines[i] = line;
                }
            }
            else if (alignment == TextAnchor.MiddleCenter || alignment == TextAnchor.MiddleLeft || alignment == TextAnchor.MiddleRight)
            {
                // 从上到下
                int mid = _Lines.Count / 2;
                float partOffset = 0;
                for (int i = mid; i < _Lines.Count; ++i)
                {
                    var line = _Lines[i];
                    if (i > mid && _ImageLines.Contains(i - 1))
                        partOffset -= imageExtraHeight / 2;
                    if (_ImageLines.Contains(i))
                        partOffset -= imageExtraHeight / 2;
                    line.offset = partOffset;
                    _Lines[i] = line;
                }
                totalOffset = -partOffset;
                partOffset = 0;

                // 从下到上
                for (int i = mid - 1; i >= 0; --i)
                {
                    var line = _Lines[i];
                    if (i < mid - 1 && _ImageLines.Contains(i + 1))
                        partOffset += imageExtraHeight / 2;
                    if (_ImageLines.Contains(i))
                        partOffset += imageExtraHeight / 2;
                    line.offset = partOffset;
                    _Lines[i] = line;
                }
                totalOffset += partOffset;
            }
        }

        /// <summary>
        /// 创建图片
        /// </summary>
        private void CreateImages()
        {
            for (int i = 0; i < _ImageInfoList.Count; ++i)
            {
                var imageInfo = _ImageInfoList[i];
                if (imageInfo.imageRtt != null)
                    continue;
                GameObject imageObject;
                YImage image;
                if (s_ReuseableImageList.Count > 0)
                {
                    imageObject = s_ReuseableImageList.Dequeue();
                    image = imageObject.GetComponent<YImage>();
                }
                else
                {
                    imageObject = new GameObject("inlineImage");
                    imageObject.transform.SetParent(transform);
                    imageObject.transform.localScale = Vector3.one;
                    image = imageObject.AddComponent<YImage>();               
                }

                var imageRtt = imageObject.GetComponent<RectTransform>();
                imageRtt.sizeDelta = _ImageSize;
                imageRtt.anchorMin = imageRtt.anchorMax = rectTransform.pivot;
                imageRtt.pivot = new Vector2(0.5f, 0.5f);
                imageInfo.imageRtt = imageRtt;
                image.imageID = imageInfo.imageID;
            }
        }

        /// <summary>
        /// 可重用的ImageGameObject
        /// </summary>
        private static Queue<GameObject> s_ReuseableImageList = new Queue<GameObject>();
        /// <summary>
        /// 解析富文本
        /// 将color，size标签转换为HTML标签
        /// 解析image，link标签信息
        /// </summary>
        /// <returns>带HTML标签的字符串</returns>
        private string AnalyzeRichText()
        {
            s_ReuseableImageList.Clear();
            _HrefInfoList.Clear();    
            for (int i = 0; i < _ImageInfoList.Count; ++i)
            {
                if (_ImageInfoList[i].imageRtt != null)
                {
                    s_ReuseableImageList.Enqueue(_ImageInfoList[i].imageRtt.gameObject);
                }
                _ImageInfoList[i] = null;
            }
            _ImageInfoList.Clear();
            totalOffset = 0;
            _DefaultFont = new UYFont();
            _TmpFont = new UYFont();
            _DefaultFont.Set(fontSize, color, fontStyle);
            _TmpFont.Set(_DefaultFont.size, _DefaultFont.color, _DefaultFont.style);
            s_TextBuilder.Length = 0;

            _ImageLines.Clear();
            _Lines.Clear();

            var blankCharWidth = cachedTextGeneratorForLayout.GetPreferredWidth(_BlankChar.ToString(), GetGenerationSettings(rectTransform.rect.size)) / pixelsPerUnit;
            var blankCharHeight = cachedTextGeneratorForLayout.GetPreferredHeight(_BlankChar.ToString(), GetGenerationSettings(rectTransform.rect.size)) / pixelsPerUnit;
            _BlankHeightPerImage = blankCharHeight;
            _BlankNumberPerImage = Mathf.CeilToInt(imageSize.x / blankCharWidth);
            _BlankNumberPerImage = _BlankNumberPerImage <= 1 ? 1 : _BlankNumberPerImage;
            _BlankWidthPerImage = blankCharWidth * _BlankNumberPerImage;
            _ExtraHeightPerImage = imageSize.y > _BlankHeightPerImage ? imageSize.y - _BlankHeightPerImage : 0.0f;

            ProcessRichText(_RichText);

            string ret = s_TextBuilder.ToString();
            TextGenerator texGen = new TextGenerator();
            var settings = GetGenerationSettings(rectTransform.rect.size);
            texGen.Populate(ret, settings);
            CalcImageOffset(texGen);
            if (_ImageInfoList.Count > 0)
            {
                CreateImages();
            }

            while (s_ReuseableImageList.Count > 0)
            {
                U3DUtil.DestroyGameObject(s_ReuseableImageList.Dequeue());
            }
            s_ReuseableImageList.Clear();
                
            return ret;
        }

        /// <summary>
        /// 逐字解析富文本
        /// </summary>
        /// <param name="richText"></param>
        private void ProcessRichText(string richText)
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
                        DoRichTransfer(null, richText.Substring(start, idx - start));
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
                        if (RichTextUtil.SpliteTransfer(richText.Substring(start, idx - start), out transfer, out paramStr))
                        {
                            DoRichTransfer(transfer, paramStr);
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
                        DoRichTransfer(null, richText);
                    else
                        DoRichTransfer(null, richText.Substring(start));
                }
                else
                {//剩下的文本是转义文本，但是右括号没有，所以直接丢弃
                }
            }
        }

        /// <summary>
        /// 分段处理解析结果
        /// </summary>
        /// <param name="transfer">标签</param>
        /// <param name="paramStr">参数</param>
        private void DoRichTransfer(string transfer, string paramStr)
        {
            if (transfer == null)
            {
                s_TextBuilder.Append(RichTextUtil.Wrap2Html(_TmpFont, paramStr));
            }
            else if (transfer == "color")
            {
                _TmpFont.color = MathUtil.ParseColor(paramStr);
            }
            else if (transfer == "size")
            {
                _TmpFont.size = MathUtil.ParseInt(paramStr);
            }
            else if (transfer == "reset")
            {
                if (paramStr == "color")
                {
                    _TmpFont.color = _DefaultFont.color;
                }
                else if (paramStr == "size")
                {
                    _TmpFont.size = _DefaultFont.size;
                }
                else if (paramStr == "all")
                {
                    _TmpFont.Set(_DefaultFont.size, _DefaultFont.color, _DefaultFont.style);
                }
            }
            else if (transfer == "image")
            {
                var imageID = MathUtil.ParseResID(paramStr);
                if (!imageID.isZero && PlayInterface.IsImageResID(imageID))
                {
                    AddTextImage(imageID);
                }
                else
                {
                    if(paramStr == null)
                    {
                        s_TextBuilder.Append(RichTextUtil.Wrap2Html(_TmpFont, "[" + transfer + "]"));
                    }
                    else
                    {
                        s_TextBuilder.Append(RichTextUtil.Wrap2Html(_TmpFont, "[" + transfer + "=" + paramStr + "]"));
                    }                  
                }
                    
            }

            else if (transfer == "link")
            {
                AddTextHref(paramStr);
            }
            else
            {
                //没有适配到任何transfer，直接当作纯文本处理
                s_TextBuilder.Append(RichTextUtil.Wrap2Html(_TmpFont, "[" + transfer + "]"));
            }
        }

        /// <summary>
        /// 添加image
        /// 添加空格占位符并添加图片信息
        /// </summary>
        private void AddTextImage(ResID imageID)
        {
            StringBuilder temp = new StringBuilder(s_TextBuilder.ToString());
            TextGenerator texGen = new TextGenerator(s_TextBuilder.Length);
            texGen.Populate(temp.ToString(), GetGenerationSettings(rectTransform.rect.size));
            int preLineCout = texGen.lineCount;

            for (int i = 0; i < _BlankNumberPerImage; ++i)
            {
                temp.Append(_BlankChar);
            }
            texGen.Populate(temp.ToString(), GetGenerationSettings(rectTransform.rect.size));
            int curLineCout = texGen.lineCount;

            if (curLineCout > preLineCout)
            {
                // 如果添加的占位符会导致换行，则强制换行
                s_TextBuilder.Append('\n');
            }
            for (int i = 0; i < _BlankNumberPerImage; ++i)
            {
                s_TextBuilder.Append(_BlankChar);
            }
            var imageInfo = new YLabelImageInfo(s_TextBuilder.Length - _BlankNumberPerImage, imageID);
            _ImageInfoList.Add(imageInfo);
        }

        /// <summary>
        /// 添加超链接信息
        /// </summary>
        /// <param name="paramStr"></param>
        private void AddTextHref(string paramStr)
        {
            if (paramStr == "end")
            {
                //超链接结束
                int hrefIndex = _HrefInfoList.Count - 1;
                if (hrefIndex < 0)
                {
                    //无效的结束标志，抛弃
                    return;
                }
                var info = _HrefInfoList[hrefIndex];
                info.endIndex = s_TextBuilder.Length * 4 + 3; // 超链接里的文本结束顶点索引
            }
            else
            {
                //超链接开始
                string linkName;
                string linkParam;
                int idx = paramStr.IndexOf(":", System.StringComparison.Ordinal);
                if (idx >= 0)
                {
                    linkName = paramStr.Substring(0, idx);
                    linkParam = paramStr.Substring(idx + 1);
                }
                else
                {
                    linkName = paramStr;
                    linkParam = null;
                }
                
                var hrefInfo = new YHrefInfo
                {
                    startIndex = s_TextBuilder.Length * 4, // 超链接里的文本起始顶点索引
                    endIndex = -1,
                    name = linkName,
                    param = linkParam
                };
                _HrefInfoList.Add(hrefInfo);
            }
        }

        /// <summary>
        /// 组装HTML标签
        /// </summary>
        public static string Wrap2Html(UYFont font, string text)
        {
            return "<size=" + font.size + "><color=" + HtmlUtil.ColorToString(font.color) + ">" + text + "</color></size>";
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            //继承PointerDown接口，防止事件被button吞噬
        }

        public void Clear()
        {
            for (int idx = 0; idx < _ImageInfoList.Count; idx++)
            {
                _ImageInfoList[idx].Clear();
                _ImageInfoList[idx] = null;
            }

            _ImageLines.Clear();
            _Lines.Clear();
            _ImageInfoList.Clear();
            _HrefInfoList.Clear();
            ClearLuaHandler();
        }

    }


    /// <summary>
    /// 超链接信息
    /// </summary>
    public class YHrefInfo
    {
        /// <summary>
        /// 起始字符顶点Index
        /// </summary>
        public int startIndex;

        /// <summary>
        /// 结束字符顶点Index
        /// </summary>
        public int endIndex;

        /// <summary>
        /// 超链接名
        /// </summary>
        public string name;

        /// <summary>
        /// 超链接参数
        /// </summary>
        public string param;

        /// <summary>
        /// 点击检查区域列表
        /// </summary>
        public List<Rect> clickCheckRects = new List<Rect>();
    }

    /// <summary>
    /// 富文本图片信息
    /// </summary>
    public class YLabelImageInfo
    {
        /// <summary>
        /// image对应字符串中的字符Index,非顶点index
        /// </summary>
        public int index;

        /// <summary>
        /// 图片ID
        /// </summary>
        public ResID imageID;

        /// <summary>
        /// 所在行
        /// </summary>
        public int line;

        /// <summary>
        /// 创建好的image RectTransform
        /// </summary>
        public RectTransform imageRtt;

        /// <summary>
        /// 图片位置
        /// </summary>
        public Vector2 imagePosition;

        public YLabelImageInfo(int index, ResID imageID)
        {
            this.index = index;
            this.imageID = imageID;
            line = -1;
            imageRtt = null;
        }

        public void Clear()
        {
            if (imageRtt != null)
            {
                U3DUtil.DestroyGameObject(imageRtt.gameObject);
                imageRtt = null;
            }

        }
    }

    /// <summary>
    /// 文字行信息
    /// </summary>
    public struct YLabelLineInfo
    {
        /// <summary>
        /// 行高
        /// </summary>
        public int height;

        /// <summary>
        /// 行起始字符的Index
        /// </summary>
        public int startCharIdx;


        /// <summary>
        /// 行结束字符的Index
        /// </summary>
        public int endCharIdx;


        /// <summary>
        /// 受图片影响，该行的y轴偏移量
        /// </summary>
        public float offset;
    }
}