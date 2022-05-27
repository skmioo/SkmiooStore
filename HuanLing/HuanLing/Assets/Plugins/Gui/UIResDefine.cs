using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UYMO
{
    public class UIResDefine
    {
        /// <summary>
        /// Object list 单元个资源ID
        /// </summary>
        public static ResID objCellPrefabResID = new ResID(7, 1, 28);
        /// <summary>
        /// button字体资源ID
        /// </summary>
        public static ResID fontResID = new ResID(7, 5, 1);
        /// <summary>
        ///  异步加载未完成时显示的图片的资源ID
        /// </summary>
        public static ResID defaultSpriteResID = new ResID(5, 11, 281);

        /// <summary>
        /// 垂直Scrollbar资源ID
        /// </summary>
        public static ResID vertScrollListResID = new ResID(7, 1, 26);

        /// <summary>
        /// 水平Scrollbar资源ID
        /// </summary>
        public static ResID horScrollListResID = new ResID(7, 1, 27);

        /// <summary>
        /// UI上默认的声音资源
        /// </summary>
        public static ResID uiSoundResID = new ResID(51, 2, 1);

        /// <summary>
        /// UIEffect 的additive shader
        /// </summary>
        public static string s_UIOneone = "UYShader/UIOneone";
        public static string s_UIEffectAdditive = "UYShader/UIEffectAdditive";
        public static string s_UIEffectAlphaBlend = "UYShader/UIEffectAlphaBlend";

        /// <summary>
        /// ui特效摄像机
        /// </summary>
        public const string UIEffectCameraName = "UIEffectCamera";

        /// <summary>
        /// 输入框默认的选中颜色
        /// </summary>
        public static readonly Color InputSelectColor = new Color(168f / 255f, 206f / 255f, 255f / 255f, 192f / 255f);
    }
}
