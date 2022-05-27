using UnityEngine;

namespace UYMO
{
    /// <summary>
    /// 由质量控制是否显示
    /// </summary>
    public class ShowQuality:MonoBehaviour
    {
        public static uint s_ObjectShowMask = 0xffffffff;
        public int _ObjectLevel = 0;

        public enum ObjType
        {
            Effect = 0,    // 特效
            SceneObj = 1,  // 场景物件
        }

        public ObjType _ObjectType = 0;

        uint objectLevel
        {
            get
            {
                return (uint)(1 << _ObjectLevel);
            }
        }

        bool isObjectShow(uint objLevel)
        {
            return (s_ObjectShowMask & objLevel) > 0;
        }

        void Awake()
        {
            RefreshVisibility();
        }

        public void RefreshVisibility()
        {
            bool bShow = isObjectShow(objectLevel);
            gameObject.SetActive(bShow);
        }
    }
}
