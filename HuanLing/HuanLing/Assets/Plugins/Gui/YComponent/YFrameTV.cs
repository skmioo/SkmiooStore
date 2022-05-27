using System;
using UnityEngine.EventSystems;
using UYMO;
using SLua;

namespace UnityEngine.UI
{
    /// <summary>
    /// 一个序列帧的播放控制器
    /// </summary>
    [CustomLuaClass]
    [SelectionBase]
    [Serializable]
    [DisallowMultipleComponent]
    [ExecuteInEditMode]
    public class YFrameTV : MonoBehaviour
    {
        [SerializeField]
        private ResID _BaseID = ResID.zero;
        [SerializeField]
        private int _FrameCount = 1;
        [SerializeField]
        private int _FrameStep = 1;
        [SerializeField]
        private float _FrameDur = 0.125f;
        [SerializeField]
        private float _LoopInterval = 0.0f;
        [SerializeField]
        private int _Loops = -1;
        [SerializeField]
        private bool _HideWhenLoopEnd = false;
        [SerializeField]
        private bool _Playing = true;

        private YImage _Image;
        private float _StartTime = 0.0f;
        void Start()
        {
            if (_Playing)
            {
                _StartTime = Time.unscaledTime;
            }
            Apply();
        }
        void Update()
        {
            Apply();
        }
        /// <summary>
        /// 是否可见
        /// </summary>
        public bool visible
        {
            get { return gameObject.activeSelf; }
            set
            {
                gameObject.SetActive(value);
            }
        }
        /// <summary>
        /// 起始图片id
        /// </summary>
        public ResID imageBaseID
        {
            get { return _BaseID; }
            set
            {
                if (_BaseID != value)
                {
                    _BaseID = value;
                    Apply();
                }
            }
        }
        /// <summary>
        /// 帧数量
        /// </summary>
        public int frameCount
        {
            get { return _FrameCount; }
            set
            {
                value = MathUtil.Max(0, value);
                if (value != _FrameCount)
                {
                    _FrameCount = value;
                    Apply();
                }
            }
        }
        /// <summary>
        /// 每帧的耗时（默认0.125，即每秒8帧）
        /// </summary>
        public float frameTime
        {
            get { return _FrameDur; }
            set
            {
                value = MathUtil.Max(0.0f, value);
                if (value != _FrameDur)
                {
                    _FrameDur = value;
                    Apply();
                }
            }
        }
        /// <summary>
        /// 每帧间隔，默认1（大于1可以达到抽帧的效果）
        /// </summary>
        public int frameStep
        {
            get { return _FrameStep; }
            set
            {
                value = MathUtil.Max(1, value);
                if (value != _FrameStep)
                {
                    _FrameStep = value;
                    Apply();
                }
            }
        }
        /// <summary>
        /// 每次循环的间隔时间
        /// </summary>
        public float loopInterval
        {
            get { return _LoopInterval; }
            set
            {
                value = MathUtil.Max(0.0f, value);
                if (value != _LoopInterval)
                {
                    _LoopInterval = value;
                    Apply();
                }
            }
        }
        /// <summary>
        /// 循环次数，-1表示一直播放（默认）
        /// </summary>
        public int loops
        {
            get { return _Loops; }
            set
            {
                value = MathUtil.Max(-1, value);
                if (value != _Loops)
                {
                    _Loops = value;
                    Apply();
                }
            }
        }
        /// <summary>
        /// 一次循环结束后，是否隐藏图片， 默认false
        /// </summary>
        public bool hideWhenLoopEnd
        {
            get { return _HideWhenLoopEnd; }
            set
            {
                if (_HideWhenLoopEnd != value)
                {
                    _HideWhenLoopEnd = value;
                    Apply();
                }
            }
        }
        /// <summary>
        /// 是否在播放中，默认true
        /// </summary>
        public bool playing
        {
            get { return _Playing; }
            set
            {
                if (_Playing != value)
                {
                    _Playing = value;
                    _StartTime = Time.unscaledTime;
                    Apply();
                }
            }
        }
        /// <summary>
        /// rect transform
        /// </summary>
        public RectTransform rectTransform
        {
            get
            {
                if (_Image != null)
                    return _Image.rectTransform;
                return GetComponent<RectTransform>();
            }
        }
        /// <summary>
        /// 重新开始播放
        /// </summary>
        public void Replay()
        {
            _Playing = true;
            _StartTime = Time.unscaledTime;
        }
        private void Apply()
        {
            if (_Image == null)
                _Image = gameObject.GetComponent<YImage>();
            if (_Image == null)
            {//没有组件
                return;
            }

            if (_FrameCount == 0 || _FrameDur <= 0.0f || _BaseID.isZero)
            {//没有图片
                _Playing = false;
                _SetImageVisible(false);
                return;
            }

            if (!_Playing)
            {//没有播放
                _SetImageVisible(!_HideWhenLoopEnd);
                return;
            }

            float eps = Time.unscaledTime - _StartTime;
            float loopDur = _FrameDur * _FrameCount + _LoopInterval;
            int looped = (int)(eps / loopDur);
            if (_Loops >= 0 && looped >= _Loops)
            {//循环已经播放完毕
                _Playing = false;
                _SetImageVisible(!_HideWhenLoopEnd);
                return;
            }

            eps = eps - looped * loopDur;
            int frame = (int)(eps / _FrameDur);
            if (frame >= _FrameCount)
            {
                if (_HideWhenLoopEnd)
                    _Image.enabled = false;
                else
                    _Image.enabled = true;
                return;
            }
            _Image.imageID = new ResID(_BaseID.packId, _BaseID.grpId, _BaseID.resId + frame * _FrameStep);
            _Image.enabled = true;
        }

        private void _SetImageVisible(bool v)
        {
            if (!v)
            {
                _Image.imageID = ResID.zero;
                _Image.enabled = false;
                return;
            }
            ResID id = _Image.imageID;
            if (id.packId != _BaseID.packId
                || id.grpId != _BaseID.grpId
                || id.resId < _BaseID.resId
                || id.resId >= _BaseID.resId + _FrameCount)
            {
                _Image.imageID = _BaseID;
            }
            _Image.enabled = true;
        }
    }
}
