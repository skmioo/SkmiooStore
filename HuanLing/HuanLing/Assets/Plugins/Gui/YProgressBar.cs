using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using SLua;

namespace UYMO
{
    [RequireComponent(typeof(RectTransform))]
    [SLua.CustomLuaClass]
    public class YProgressBar : UIBehaviour
    {
        [SerializeField]
        float _SrcWdith;
        [SerializeField]
        YImage _BackGround;
        [SerializeField]
        YImage _Front;
        [SerializeField]
        YLabel _Label;
        [Range(0, 1)]
        [SerializeField]
        float _Progress;

        [DoNotToLua]
        public YImage backTarget
        {
            get { return _BackGround; }
            set { _BackGround = value; }
        }
        [DoNotToLua]
        public YImage frontTarget
        {
            get { return _Front; }
            set { _Front = value; }
        }
        [DoNotToLua]
        public YLabel labelTarget
        {
            get { return _Label; }
            set { _Label = value; }
        }
        [DoNotToLua]
        public float sourceWidth
        {
            get { return _SrcWdith; }
            set { _SrcWdith = value; }
        }

        protected override void Start()
        {
            Refresh();
        }
        public float progress
        {
            get
            {
                return _Progress;
            }
            set
            {
                float v = UnityEngine.Mathf.Clamp(value, 0, 1);
                if(v!= _Progress)
                {
                    _Progress = v;
                    Refresh();
                }
            }
        }
        [SLua.DoNotToLua]
        public void Refresh()
        {
            if (_Front)
            {
                Vector2 pos = _Front.rectTransform.anchoredPosition;
                _Front.rectTransform.anchoredPosition = pos;

                float prg = Mathf.Clamp(_Progress, 0, 1);
                Vector2 size = _Front.rectTransform.sizeDelta;
                size.x = _SrcWdith * prg;
                _Front.rectTransform.sizeDelta = size;
            }
        }

        public string text
        {
            get
            {
                return _Label ? _Label.text : "";
            }
            set
            {
                if (_Label)
                {
                    _Label.text = value;
                }
            }
        }
    }
}
