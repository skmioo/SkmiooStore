using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using SLua;

namespace UYMO
{
    /// <summary>
    /// 字体信息
    /// </summary>
    [CustomLuaClassAttribute]
    public class UYFont
    {
        public const FontStyle StyleNormal = FontStyle.Normal;
        public const FontStyle StyleBold = FontStyle.Bold;
        public const FontStyle StyleItalic = FontStyle.Italic;
        public const FontStyle StyleBoldAndItalic = FontStyle.BoldAndItalic;

        public const int SizeLittle = 14;
        public const int SizeSmall = 16;
        public const int SizeNormal = 18;
        public const int SizeBig = 20;
        public const int SizeLarge = 22;
        public const int SizeTitle = 26;

        public const TextAnchor UpperLeft = TextAnchor.UpperLeft;
        public const TextAnchor UpperRight = TextAnchor.UpperRight;
        public const TextAnchor UpperCenter = TextAnchor.UpperCenter;
        public const TextAnchor MiddleLeft = TextAnchor.MiddleLeft;
        public const TextAnchor MiddleRight = TextAnchor.MiddleRight;
        public const TextAnchor MiddleCenter = TextAnchor.MiddleCenter;
        public const TextAnchor LowerLeft = TextAnchor.LowerLeft;
        public const TextAnchor LowerRight = TextAnchor.LowerRight;
        public const TextAnchor LowerCenter = TextAnchor.LowerCenter;

        public const HorizontalWrapMode HorzWrap = HorizontalWrapMode.Wrap;
        public const HorizontalWrapMode HorzOverflow = HorizontalWrapMode.Overflow;
        public const VerticalWrapMode VertTruncate = VerticalWrapMode.Truncate;
        public const VerticalWrapMode VertOverflow= VerticalWrapMode.Overflow;

        public static UYFont defaultFont
        {
            get
            {
                return new UYFont();
            }
        }

        public int size;
        public Color color;
        public FontStyle style;
        [DoNotToLuaAttribute]
        public UYFont()
        {
            SetAsDefault();
        }

        [DoNotToLuaAttribute]
        public UYFont(int aSize, Color aColor, FontStyle aStyle)
        {
            Set(aSize, aColor, aStyle);
        }

        [DoNotToLuaAttribute]
        public void Set(int aSize, Color aColor, FontStyle aStyle)
        {
            size = aSize;
            color = aColor;
            style = aStyle;
        }

        [DoNotToLuaAttribute]
        public void SetAsDefault()
        {
            size = SizeNormal;
            color = UYMO.PlayInterface.GetColorByName("黑");
            style = StyleNormal;
        }

        [DoNotToLuaAttribute]
        public UYFont Clone()
        {
            return new UYFont(size, color, style);
        }
    }
}
