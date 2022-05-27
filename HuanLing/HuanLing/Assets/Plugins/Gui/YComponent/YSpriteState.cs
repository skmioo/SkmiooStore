using System;
using UnityEngine.Serialization;
using UYMO;

namespace UnityEngine.UI
{
    [Serializable]
    public class YSpriteState
    {
        [SerializeField]
        private ResID m_HighlightedSprite;

        [SerializeField]
        private ResID m_PressedSprite;

        [SerializeField]
        private ResID m_DisabledSprite;

        public ResID highlightedSprite
        {
            get { return m_HighlightedSprite; }
            set { m_HighlightedSprite = value; }
        }
        public ResID pressedSprite
        {
            get { return m_PressedSprite; }
            set { m_PressedSprite = value; }
        }
        public ResID disabledSprite
        {
            get { return m_DisabledSprite; }
            set { m_DisabledSprite = value; }
        }

        /// <summary>
        /// 普通状态ResID
        /// </summary>
        private ResID m_NormalSpriteResID;

        public ResID normalSpriteResID
        {
            get { return m_NormalSpriteResID; }
        }

        public void ApplyTargetImageID(ResID imageID)
        {
            m_NormalSpriteResID = imageID;
        }
    }
}
