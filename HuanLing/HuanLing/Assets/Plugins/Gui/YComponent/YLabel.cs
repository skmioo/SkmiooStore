using System;
using System.Collections.Generic;
using UYMO;
using SLua;

namespace UnityEngine.UI
{
    /// <summary>
    /// Labels are graphics that display text.
    /// </summary>
    [CustomLuaClass]
    [AddComponentMenu("YUI/YLabel", 1)]
    public class YLabel : YMaskableGraphic, ILayoutElement
    {
        public enum OutlineStyle
        {
            OutLine4 = 0,
            OutLine8 = 1
        }

        [SerializeField]
        private YFontData m_FontData;

        [TextArea(3, 10)]
        [SerializeField]
        protected string m_Text = String.Empty;

        private TextGenerator m_TextCache;
        private TextGenerator m_TextCacheForLayout;

        static protected Material s_DefaultText = null;

        // We use this flag instead of Unregistering/Registering the callback to avoid allocation.
        [NonSerialized]
        protected bool m_DisableFontTextureRebuiltCallback = false;

        protected YLabel()
        {
            useLegacyMeshGeneration = false;
        }

        /// <summary>
        /// Get or set the material used by this Text.
        /// </summary>

        public TextGenerator cachedTextGenerator
        {
            get { return m_TextCache ?? (m_TextCache = (m_Text.Length != 0 ? new TextGenerator(m_Text.Length) : new TextGenerator())); }
        }

        public TextGenerator cachedTextGeneratorForLayout
        {
            get { return m_TextCacheForLayout ?? (m_TextCacheForLayout = new TextGenerator()); }
        }

        /// <summary>
        /// Text's texture comes from the font.
        /// </summary>
        public override Texture mainTexture
        {
            get
            {
                if (font != null && font.material != null && font.material.mainTexture != null)
                    return font.material.mainTexture;

                if (m_Material != null)
                    return m_Material.mainTexture;

                return base.mainTexture;
            }
        }

        public void FontTextureChanged()
        {
            // Only invoke if we are not destroyed.
            if (!this)
            {
                YFontUpdateTracker.UntrackText(this);
                return;
            }

            if (m_DisableFontTextureRebuiltCallback)
                return;

            cachedTextGenerator.Invalidate();

            if (!IsActive())
                return;

            // this is a bit hacky, but it is currently the
            // cleanest solution....
            // if we detect the font texture has changed and are in a rebuild loop
            // we just regenerate the verts for the new UV's
            if (CanvasUpdateRegistry.IsRebuildingGraphics() || CanvasUpdateRegistry.IsRebuildingLayout())
                UpdateGeometry();
            else
                SetAllDirty();
        }

        public Font font
        {
            get
            {
                return fontData.font;
            }
            private set
            {
                if (fontData.font == value)
                    return;

                YFontUpdateTracker.UntrackText(this);

                fontData.font = value;

                YFontUpdateTracker.TrackText(this);

                SetAllDirty();
            }
        }

        YFontData fontData
        {
            get
            {
                if( m_FontData == null )
                {
                    m_FontData = YFontData.defaultFontData;
                }
                if(m_FontData.font == null)
                {
                    m_FontData.font = YFontData.defaultFont;
                }
                return m_FontData;
            }
        }

        /// <summary>
        /// Text that's being displayed by the Text.
        /// </summary>

        public virtual string text
        {
            get
            {
                return m_Text;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    if (String.IsNullOrEmpty(m_Text))
                        return;
                    m_Text = "";
                    SetVerticesDirty();
                }
                else if (m_Text != value)
                {
                    m_Text = value;
                    SetVerticesDirty();
                    SetLayoutDirty();
                }
            }
        }

        /// <summary>
        /// Whether this Text will support rich text.
        /// </summary>

        public bool supportRichText
        {
            get
            {
                return fontData.richText;
            }
            set
            {
                if (fontData.richText == value)
                    return;
                fontData.richText = value;
                SetVerticesDirty();
                SetLayoutDirty();
            }
        }

        /// <summary>
        /// Wrap mode used by the text.
        /// </summary>

        public bool resizeTextForBestFit
        {
            get
            {
                return fontData.bestFit;
            }
            set
            {
                if (fontData.bestFit == value)
                    return;
                fontData.bestFit = value;
                SetVerticesDirty();
                SetLayoutDirty();
            }
        }

        public int resizeTextMinSize
        {
            get
            {
                return fontData.minSize;
            }
            set
            {
                if (fontData.minSize == value)
                    return;
                fontData.minSize = value;

                SetVerticesDirty();
                SetLayoutDirty();
            }
        }

        public int resizeTextMaxSize
        {
            get
            {
                return fontData.maxSize;
            }
            set
            {
                if (fontData.maxSize == value)
                    return;
                fontData.maxSize = value;

                SetVerticesDirty();
                SetLayoutDirty();
            }
        }

        /// <summary>
        /// Alignment anchor used by the text.
        /// </summary>

        public TextAnchor alignment
        {
            get
            {
                return fontData.alignment;
            }
            set
            {
                if (fontData.alignment == value)
                    return;
                fontData.alignment = value;

                SetVerticesDirty();
                SetLayoutDirty();
            }
        }

        public int fontSize
        {
            get
            {
                return fontData.fontSize;
            }
            set
            {
                if (fontData.fontSize == value)
                    return;
                fontData.fontSize = value;

                SetVerticesDirty();
                SetLayoutDirty();
            }
        }

        public HorizontalWrapMode horizontalOverflow
        {
            get
            {
                return fontData.horizontalOverflow;
            }
            set
            {
                if (fontData.horizontalOverflow == value)
                    return;
                fontData.horizontalOverflow = value;

                SetVerticesDirty();
                SetLayoutDirty();
            }
        }

        public VerticalWrapMode verticalOverflow
        {
            get
            {
                return fontData.verticalOverflow;
            }
            set
            {
                if (fontData.verticalOverflow == value)
                    return;
                fontData.verticalOverflow = value;

                SetVerticesDirty();
                SetLayoutDirty();
            }
        }

        public float lineSpacing
        {
            get
            {
                return fontData.lineSpacing;
            }
            set
            {
                if (fontData.lineSpacing == value)
                    return;
                fontData.lineSpacing = value;

                SetVerticesDirty();
                SetLayoutDirty();
            }
        }

        /// <summary>
        /// Font style used by the Text's text.
        /// </summary>

        public FontStyle fontStyle
        {
            get
            {
                return fontData.fontStyle;
            }
            set
            {
                if (fontData.fontStyle == value)
                    return;
                fontData.fontStyle = value;

                SetVerticesDirty();
                SetLayoutDirty();
            }
        }

        public float pixelsPerUnit
        {
            get
            {
                var localCanvas = canvas;
                if (!localCanvas)
                    return 1;
                // For dynamic fonts, ensure we use one pixel per pixel on the screen.
                if (!font || font.dynamic)
                    return localCanvas.scaleFactor;
                // For non-dynamic fonts, calculate pixels per unit based on specified font size relative to font object's own font size.
                if (fontData.fontSize <= 0 || font.fontSize <= 0)
                    return 1;
                return font.fontSize / (float)fontData.fontSize;
            }
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            cachedTextGenerator.Invalidate();
            YFontUpdateTracker.TrackText(this);
        }

        protected override void OnDisable()
        {
            YFontUpdateTracker.UntrackText(this);
            base.OnDisable();
        }

        protected override void Awake()
        {
            base.Awake();
            ApplyFontID();
            UpdateColor();
            ApplyLanKey();
        }

        protected override void UpdateGeometry()
        {
            if (font != null)
            {
                base.UpdateGeometry();
            }
        }

#if UNITY_EDITOR
        protected override void Reset()
        {
        }

#endif

        public TextGenerationSettings GetGenerationSettings(Vector2 extents)
        {
            var settings = new TextGenerationSettings();

            settings.generationExtents = extents;
            if (font != null && font.dynamic)
            {
                settings.fontSize = fontData.fontSize;
                settings.resizeTextMinSize = fontData.minSize;
                settings.resizeTextMaxSize = fontData.maxSize;
            }

            // Other settings
            settings.textAnchor = fontData.alignment;
            settings.scaleFactor = pixelsPerUnit;
            settings.color = color;
            settings.font = font;
            settings.pivot = rectTransform.pivot;
            settings.richText = fontData.richText;
            settings.lineSpacing = fontData.lineSpacing;
            settings.fontStyle = fontData.fontStyle;
            settings.resizeTextForBestFit = fontData.bestFit;
            settings.updateBounds = false;
            settings.horizontalOverflow = fontData.horizontalOverflow;
            settings.verticalOverflow = fontData.verticalOverflow;

            return settings;
        }

        static public Vector2 GetTextAnchorPivot(TextAnchor anchor)
        {
            switch (anchor)
            {
                case TextAnchor.LowerLeft: return new Vector2(0, 0);
                case TextAnchor.LowerCenter: return new Vector2(0.5f, 0);
                case TextAnchor.LowerRight: return new Vector2(1, 0);
                case TextAnchor.MiddleLeft: return new Vector2(0, 0.5f);
                case TextAnchor.MiddleCenter: return new Vector2(0.5f, 0.5f);
                case TextAnchor.MiddleRight: return new Vector2(1, 0.5f);
                case TextAnchor.UpperLeft: return new Vector2(0, 1);
                case TextAnchor.UpperCenter: return new Vector2(0.5f, 1);
                case TextAnchor.UpperRight: return new Vector2(1, 1);
                default: return Vector2.zero;
            }
        }

        readonly UIVertex[] m_TempVerts = new UIVertex[4];
        protected override void OnPopulateMesh(VertexHelper toFill)
        {
            if (font == null)
                return;

            // We don't care if we the font Texture changes while we are doing our Update.
            // The end result of cachedTextGenerator will be valid for this instance.
            // Otherwise we can get issues like Case 619238.
            m_DisableFontTextureRebuiltCallback = true;

            Vector2 extents = rectTransform.rect.size;

            var settings = GetGenerationSettings(extents);
            cachedTextGenerator.Populate(text, settings);

            Rect inputRect = rectTransform.rect;

            // get the text alignment anchor point for the text in local space
            Vector2 textAnchorPivot = GetTextAnchorPivot(fontData.alignment);
            Vector2 refPoint = Vector2.zero;
            refPoint.x = (textAnchorPivot.x == 1 ? inputRect.xMax : inputRect.xMin);
            refPoint.y = (textAnchorPivot.y == 0 ? inputRect.yMin : inputRect.yMax);

            // Determine fraction of pixel to offset text mesh.
            Vector2 roundingOffset = PixelAdjustPoint(refPoint) - refPoint;

            // Apply the offset to the vertices
            IList<UIVertex> verts = cachedTextGenerator.verts;
            float unitsPerPixel = 1 / pixelsPerUnit;
            //Last 4 verts are always a new line... 
            int vertCount = verts.Count - 4;

            toFill.Clear();
            if (roundingOffset != Vector2.zero)
            {
                for (int i = 0; i < vertCount; ++i)
                {
                    int tempVertsIndex = i & 3;
                    m_TempVerts[tempVertsIndex] = verts[i];
                    m_TempVerts[tempVertsIndex].position *= unitsPerPixel;
                    m_TempVerts[tempVertsIndex].position.x += roundingOffset.x;
                    m_TempVerts[tempVertsIndex].position.y += roundingOffset.y;
                    if (tempVertsIndex == 3)
                        toFill.AddUIVertexQuad(m_TempVerts);
                }
            }
            else
            {
                for (int i = 0; i < vertCount; ++i)
                {
                    int tempVertsIndex = i & 3;
                    m_TempVerts[tempVertsIndex] = verts[i];
                    m_TempVerts[tempVertsIndex].position *= unitsPerPixel;
                    if (tempVertsIndex == 3)
                        toFill.AddUIVertexQuad(m_TempVerts);
                }
            }

            var output = YListPool<UIVertex>.Get();
            if (s_ShowGradient && m_ShowGradient)
            {
                output.Clear();
                toFill.GetUIVertexStream(output);
                ApplyGradient(output);
                toFill.Clear();
                toFill.AddUIVertexTriangleStream(output);
            }

            if (s_ShowShadow && m_ShowShadow)
            {
                output.Clear();
                toFill.GetUIVertexStream(output);
                ApplyShadow(output, m_ShadowEffectColor, 0, output.Count, m_ShadowEffectDistance.x, m_ShadowEffectDistance.y);
                toFill.Clear();
                toFill.AddUIVertexTriangleStream(output);
            }

            if (s_ShowOutline && m_ShowOutline)
            {
                output.Clear();
                toFill.GetUIVertexStream(output);
                ApplyOutline(output);
                toFill.Clear();
                toFill.AddUIVertexTriangleStream(output);
            }
            YListPool<UIVertex>.Release(output);

            m_DisableFontTextureRebuiltCallback = false;
        }

        public virtual void CalculateLayoutInputHorizontal() { }
        public virtual void CalculateLayoutInputVertical() { }

        public virtual float minWidth
        {
            get { return 0; }
        }

        public virtual float preferredWidth
        {
            get
            {
                var settings = GetGenerationSettings(Vector2.zero);
                return cachedTextGeneratorForLayout.GetPreferredWidth(m_Text, settings) / pixelsPerUnit;
            }
        }

        public virtual float flexibleWidth { get { return -1; } }

        public virtual float minHeight
        {
            get { return 0; }
        }

        public virtual float preferredHeight
        {
            get
            {
                var settings = GetGenerationSettings(new Vector2(rectTransform.rect.size.x, 0.0f));
                return cachedTextGeneratorForLayout.GetPreferredHeight(m_Text, settings) / pixelsPerUnit;
            }
        }

        public virtual float flexibleHeight { get { return -1; } }

        public virtual int layoutPriority { get { return 0; } }

#if UNITY_EDITOR
        [DoNotToLua]
        public override void OnRebuildRequested()
        {
            // After a Font asset gets re-imported the managed side gets deleted and recreated,
            // that means the delegates are not persisted.
            // so we need to properly enforce a consistent state here.
            YFontUpdateTracker.UntrackText(this);
            YFontUpdateTracker.TrackText(this);

            // Also the textgenerator is no longer valid.
            cachedTextGenerator.Invalidate();

            base.OnRebuildRequested();
        }

#endif // if UNITY_EDITOR

        [SerializeField]
        private string m_ConfigColor = "无";
        /// <summary>
        /// 配置颜色
        /// 若配置颜色不为"无"，则Label的颜色由配置颜色控制。
        /// 配置颜色定义在ColorConfig.xml配置中。
        /// </summary>
        public string configColor
        {
            get { return m_ConfigColor; }
            set
            {
                m_ConfigColor = value;
                if (m_ConfigColor != "无")
                {
                    color = PlayInterface.GetColorByName(m_ConfigColor);
                }
            }
        }

        [SerializeField]
        private Color m_NormalColor = Color.white;

        public Color normalColor
        {
            get { return m_NormalColor; }
            set { color = m_NormalColor = value; }
        }

        [SerializeField]
        private string m_PressConfigColor = "无";

        public string pressConfigColor
        {
            get { return m_PressConfigColor; }
            set
            {
                m_PressConfigColor = value;
                if (m_PressConfigColor != "无")
                {
                    color = PlayInterface.GetColorByName(m_PressConfigColor);
                }
            }
        }

        [SerializeField]
        private Color m_PressColor = Color.white;

        public Color pressColor
        {
            get { return m_PressColor; }
            set { color = m_PressColor = value; }
        }

        public enum LabelTouchState
        {
            Normal = 0,
            Pressed = 1
        }

        private LabelTouchState m_TouchState = LabelTouchState.Normal;

        public LabelTouchState touchState
        {
            get { return m_TouchState; }
            set
            {
                if (m_TouchState != value)
                {
                    m_TouchState = value;
                    UpdateColor();
                }

            }
        }

        private void UpdateColor()
        {
            switch (m_TouchState)
            {
                case LabelTouchState.Normal:
                    {
                        color = m_ConfigColor == "无" ? m_NormalColor : PlayInterface.GetColorByName(m_ConfigColor);
                        break;
                    }
                case LabelTouchState.Pressed:
                    {
                        color = m_PressConfigColor == "无" ? m_PressColor : PlayInterface.GetColorByName(m_PressConfigColor);
                        break;
                    }
            }
        }

        //public void OnBeforeSerialize()
        //{
        //    //刷新Label的颜色
        //    UpdateColor();
        //}

        //public void OnAfterDeserialize()
        //{
        //}

        public float width
        {
            get
            {
                return gameObject.GetComponent<RectTransform>().rect.width;
            }
        }

        public float height
        {
            get
            {
                return gameObject.GetComponent<RectTransform>().rect.height;
            }
        }
        /// <summary>
        /// 是否可见
        /// </summary>
        public bool visible
        {
            get { return gameObject.activeSelf; }
            set { gameObject.SetActive(value); }
        }

        /// <summary>
        /// 自动对位
        /// 一行居左，两行居中
        /// <param name="singleLineAlignment">单行的对齐方式</param>
        /// <param name="mutiLineAlignment">多行的对齐方式</param>
        /// </summary>
        public void AutoAlignment(TextAnchor singleLineAlignment, TextAnchor multiLineAlignment)
        {
            TextGenerator texGen = new TextGenerator();
            Vector2 extents = rectTransform.rect.size;
            var settings = GetGenerationSettings(extents);
            texGen.Populate(text, settings);
            if (texGen.lineCount > 1)
            {
                alignment = multiLineAlignment;
            }
            else
            {
                alignment = singleLineAlignment;
            }
        }

        /// <summary>
        /// 全局控制是否显示阴影
        /// </summary>
        public static bool s_ShowShadow = true;
        /// <summary>
        /// 全局控制是否显示描边
        /// </summary>
        public static bool s_ShowOutline = true;
        /// <summary>
        /// 全局控制是否显示渐变
        /// </summary>
        public static bool s_ShowGradient = true;

        [SerializeField]
        private bool m_ShowShadow = false;
        
        /// <summary>
        /// 组件是否显示阴影
        /// </summary>
        public bool shwoShadow
        {
            get { return m_ShowShadow; }
            set 
            {
               if (m_ShowShadow != value)
               {
                   m_ShowShadow = value;
                   SetVerticesDirty();
               }               
            }
        }

        [SerializeField]
        private Color m_ShadowEffectColor = new Color(0f, 0f, 0f, 0.5f);

        /// <summary>
        /// 阴影效果颜色
        /// </summary>
        public Color shadowEffectColor
        {
            get { return m_ShadowEffectColor; }
            set
            {
                m_ShadowEffectColor = value;
                SetVerticesDirty();
            }
        }

        [SerializeField]
        private Vector2 m_ShadowEffectDistance = new Vector2(1f, -1f);

        /// <summary>
        /// 阴影效果长度
        /// </summary>
        [DoNotToLua]
        public Vector2 shadowEffectDistance
        {
            get { return m_ShadowEffectDistance; }
            set
            {
                if (value.x > kMaxEffectDistance)
                    value.x = kMaxEffectDistance;
                if (value.x < -kMaxEffectDistance)
                    value.x = -kMaxEffectDistance;

                if (value.y > kMaxEffectDistance)
                    value.y = kMaxEffectDistance;
                if (value.y < -kMaxEffectDistance)
                    value.y = -kMaxEffectDistance;

                if (m_ShadowEffectDistance == value)
                    return;

                m_ShadowEffectDistance = value;
                SetVerticesDirty();
            }
        }

        [SerializeField]
        private bool m_ShadowUseGraphicAlpha = true;

        [DoNotToLua]
        public bool shadowUseGraphicAlpha
        {
            get { return m_ShadowUseGraphicAlpha; }
            set 
            {
                m_ShadowUseGraphicAlpha = value;
                SetVerticesDirty();
            }
        }

        private const float kMaxEffectDistance = 600f;

        protected void ApplyShadowZeroAlloc(List<UIVertex> verts, Color32 color, int start, int end, float x, float y)
        {
            UIVertex vt;

            var neededCpacity = verts.Count * 2;
            if (verts.Capacity < neededCpacity)
                verts.Capacity = neededCpacity;

            for (int i = start; i < end; ++i)
            {
                vt = verts[i];
                verts.Add(vt);

                Vector3 v = vt.position;
                v.x += x;
                v.y += y;
                vt.position = v;
                var newColor = color;
                if (m_ShadowUseGraphicAlpha)
                    newColor.a = (byte)((newColor.a * verts[i].color.a) / 255);
                vt.color = newColor;
                verts[i] = vt;
            }
        }

        protected void ApplyShadow(List<UIVertex> verts, Color32 color, int start, int end, float x, float y)
        {
            var neededCpacity = verts.Count * 2;
            if (verts.Capacity < neededCpacity)
                verts.Capacity = neededCpacity;

            ApplyShadowZeroAlloc(verts, color, start, end, x, y);
        }

        [SerializeField]
        private bool m_ShowOutline = false;

        /// <summary>
        /// 组件是否显示描边
        /// </summary>
        public bool shwoOutline
        {
            get { return m_ShowOutline; }
            set
            {
                if (m_ShowOutline != value)
                {
                    m_ShowOutline = value;
                    SetVerticesDirty();
                }
            }
        }

        [SerializeField]
        private Color m_OutlineEffectColor = new Color(0f, 0f, 0f, 0.5f);

        /// <summary>
        ///描边效果颜色
        /// </summary>
        public Color outlineEffectColor
        {
            get { return m_OutlineEffectColor; }
            set
            {
                m_OutlineEffectColor = value;
                SetVerticesDirty();
            }
        }

        [SerializeField]
        private OutlineStyle m_OutlineStyle = OutlineStyle.OutLine4;

        /// <summary>
        /// 描边效果为4方向还是8方向
        /// </summary>
        public OutlineStyle outlineStyle
        {
            get { return m_OutlineStyle; }
            set
            {
                if (m_OutlineStyle != value)
                {
                    m_OutlineStyle = value;
                    SetVerticesDirty();
                    SetLayoutDirty();
                }
            }
        }

        [SerializeField]
        private Vector2 m_OutlineEffectDistance = new Vector2(1f, -1f);

        /// <summary>
        /// 阴影效果长度
        /// </summary>
        [DoNotToLua]
        public Vector2 outlineEffectDistance
        {
            get { return m_OutlineEffectDistance; }
            set
            {
                if (value.x > kMaxEffectDistance)
                    value.x = kMaxEffectDistance;
                if (value.x < -kMaxEffectDistance)
                    value.x = -kMaxEffectDistance;

                if (value.y > kMaxEffectDistance)
                    value.y = kMaxEffectDistance;
                if (value.y < -kMaxEffectDistance)
                    value.y = -kMaxEffectDistance;

                if (m_OutlineEffectDistance == value)
                    return;

                m_OutlineEffectDistance = value;
                SetVerticesDirty();
            }
        }

        [SerializeField]
        private bool m_OutlineUseGraphicAlpha = true;

        [DoNotToLua]
        public bool outlineUseGraphicAlpha
        {
            get { return m_OutlineUseGraphicAlpha; }
            set
            {
                m_OutlineUseGraphicAlpha = value;
                SetVerticesDirty();
            }
        }
        protected void ApplyOutline(List<UIVertex> output)
        {
            Vector2 _Pos = m_OutlineEffectDistance;
            var start = 0;
            var end = output.Count;
            ApplyShadowZeroAlloc(output, m_OutlineEffectColor, start, output.Count, _Pos.x, _Pos.y);
            start = end;
            end = output.Count;
            ApplyShadowZeroAlloc(output, m_OutlineEffectColor, start, output.Count, _Pos.x, -_Pos.y);
            start = end;
            end = output.Count;
            ApplyShadowZeroAlloc(output, m_OutlineEffectColor, start, output.Count, -_Pos.x, _Pos.y);
            start = end;
            end = output.Count;
            ApplyShadowZeroAlloc(output, m_OutlineEffectColor, start, output.Count, -_Pos.x, -_Pos.y);

            if (m_OutlineStyle == OutlineStyle.OutLine8)
            {
                start = end;
                end = output.Count;
                ApplyShadowZeroAlloc(output, m_OutlineEffectColor, start, output.Count, _Pos.x, 0);
                start = end;
                end = output.Count;
                ApplyShadowZeroAlloc(output, m_OutlineEffectColor, start, output.Count, -_Pos.x, 0);
                start = end;
                end = output.Count;
                ApplyShadowZeroAlloc(output, m_OutlineEffectColor, start, output.Count, 0, _Pos.y);
                start = end;
                end = output.Count;
                ApplyShadowZeroAlloc(output, m_OutlineEffectColor, start, output.Count, 0, -_Pos.y);
            }
        }

        [SerializeField]
        private bool m_ShowGradient = false;
        
        public bool showGradient
        {
            get { return m_ShowGradient; }
            set
            {
                if (m_ShowGradient != value)
                {
                    m_ShowGradient = value;
                    SetVerticesDirty();
                }
            }
        }
        [SerializeField]
        private Color32 m_GradientTopColor = Color.white;

        public Color32 gradientTopColor
        {
            get { return m_GradientTopColor; }
            set
            {
                m_GradientTopColor = value;
                SetVerticesDirty();
            }
        }

        [SerializeField]
        private Color32 m_GradientBottomColor = Color.black;

        public Color32 gradientBottomColor
        {
            get { return m_GradientBottomColor; }
            set
            {
                m_GradientBottomColor = value;
                SetVerticesDirty();
            }
        }

        public void SetBottomColor(Color color)
        {
            gradientBottomColor = color;
        }
        public void SetTopColor(Color color)
        {
            gradientTopColor = color;
        }

        protected void ApplyGradient(List<UIVertex> output)
        {
            int count = output.Count;
            if (count > 0)
            {
                float bottomY = output[0].position.y;
                float topY = output[0].position.y;

                for (int i = 1; i < count; i++)
                {
                    float y = output[i].position.y;
                    if (y > topY)
                    {
                        topY = y;
                    }
                    else if (y < bottomY)
                    {
                        bottomY = y;
                    }
                }

                float uiElementHeight = topY - bottomY;

                for (int i = 0; i < count; i++)
                {
                    UIVertex uiVertex = output[i];
                    uiVertex.color = Color32.Lerp(m_GradientBottomColor, m_GradientTopColor, (uiVertex.position.y - bottomY) / uiElementHeight);
                    output[i] = uiVertex;
                }
            }
        }

        [SerializeField]
        [Header("语言包key")]
        private string m_LanKey;

        /// <summary>
        /// 语言包key
        /// </summary>
        public string lanKey
        {
            get { return m_LanKey; }
            set
            {
                if (m_LanKey != value)
                {
                    m_LanKey = value;
                    ApplyLanKey();
                }
            }
        }

        public void ApplyLanKey()
        {
            if (m_LanKey != null && m_LanKey != "")
            {
                if (PlayInterface.LanTrans != null)
                    text = PlayInterface.LanTrans(m_LanKey);
            }
        }


        #region FontID
        public ResID fontID
        {
            get
            {
                return fontData.fontID;
            }
            set
            {
                if (fontID != value)
                {
                    PlayInterface.CancelRes(fontID, HandleFontLoaded);
                    fontData.fontID = value;
                    ApplyFontID();
                }
            }
        }

        [DoNotToLua]
        public void ApplyFontID()
        {
            if (fontID.isZero)
            {
                font = YFontData.defaultFont;
            }
            else
            {
                if (!Application.isPlaying)
                {//编辑器模式下
                    font = PlayInterface.GetResInEditor(fontID, typeof(Font)) as Font;
                    if(font == null)
                    {
                        font = YFontData.defaultFont;
                    }
                }
                else
                {
                    PlayInterface.LoadRes(fontID, HandleFontLoaded, typeof(Font));
                }
            }
            
        }

        private void HandleFontLoaded(Object res, ResID id )
        {
            if(IsDestroyed())
            {
                PlayInterface.CancelRes(id, HandleFontLoaded);
                return;
            }
            Font newFont = res as Font;
            if(newFont == null)
            {
                font = YFontData.defaultFont;
                Debug.LogWarningFormat("Failed to load res {0} as Font", id);
                return;
            }
            font = newFont;
        }
        #endregion
    }
}
