using System;
using UnityEngine.EventSystems;
using UYMO;
using SLua;
namespace UnityEngine.UI
{
    [CustomLuaClass]
    public enum YSpriteAnimationState
    {
        Play,
        Stop,
        Pause
    }

    /// <summary>
    /// 序列帧动画
    /// </summary>
    [CustomLuaClass]
    [Serializable]
    public class YSpriteAnimation : UIBehaviour, IClearable, ISpriteUser
    {
        /// <summary>
        /// 播放模式
        /// </summary>
        public enum PlayModel
        {
            Once,           //播放一次后就自动停止
            Loop,           //循环播放
            LoopAndPause    //循环播放，循环一定次数后暂停
        }

        [SerializeField]
        private Vector2 _RowCols;
        /// <summary>
        /// 行列数
        /// </summary>
        public Vector2 rowCols
        {
            get { return _RowCols; }
            set { _RowCols = value; }
        }

        [SerializeField]
        private int _Count;
        /// <summary>
        /// 帧总数
        /// </summary>
        public int count
        {
            get { return _Count; }
            set { _Count = value; }
        }
        [SerializeField]
        private float _Duration;
        /// <summary>
        /// 一次帧动画总数
        /// </summary>
        public float duration
        {
            get { return _Duration; }
            set { _Duration = value; }
        }

        [SerializeField]
        private ResID _ImageID = ResID.zero;
        /// <summary>
        /// 帧动画资源ID
        /// </summary>
        public ResID imageID
        {
            get { return _ImageID; }
            set
            {
                if (_ImageID == value)
                    return;
                _ImageID = value;
                if (Application.isPlaying)
                    Stop();
            }
        }

        [SerializeField]
        private bool _PlayOnAwake = false;
        /// <summary>
        /// awake时播放
        /// </summary>
        public bool playOnAwake
        {
            get { return _PlayOnAwake; }
            set { _PlayOnAwake = value; }
        }

        [SerializeField]
        private bool _RaycastTarget = false;

        /// <summary>
        /// 是否响应点击
        /// </summary>
        public bool raycastTarget
        {
            get { return _RaycastTarget; }
            set { _RaycastTarget = true; }
        }

        [SerializeField]
        private PlayModel _PlayModel;
        public PlayModel playModel
        {
            get { return _PlayModel; }
            set
            {
                if (_PlayModel == value)
                    return;
                _PlayModel = value;
                if (Application.isPlaying)
                    Stop();
            }
        }

        // RawImage对象
        private RawImage _RawImage;
        // sprite
        private ISpriteHandle _SpriteHandle = null;
        // 当前帧
        private int _CurrentIndex;
        // 每帧大小，归一化
        private Vector2 _CellSize;
        // 循环播放次数
        private int _LoopCount = -1;
        // 当前循环Index
        private int _CurrentLoopIndex;
        // 当前播放状态
        private YSpriteAnimationState _CurrentState = YSpriteAnimationState.Stop;
        // 生命周期，-1代表循环
        private float _LifeTime = -1;
        // 开始播放时间
        private float _BeginPlayTime = 0;
        // 下一次播放时间
        private float _NextPlayTime = 0;
        // 更新间隔时间
        private float _InternalCheckTime = 0;
        // 总的运行时间
        private float _RunTime = 0;
        // 渲染器
        private CanvasRenderer _CanvasRenderer = null;

        protected override void Awake()
        {
            base.Awake();
            _CanvasRenderer = this.gameObject.GetComponentInParent<CanvasRenderer>();
        }
        protected override void OnEnable()
        {
            base.OnEnable();
            if (_PlayOnAwake)
            {
                Play();
            }
        }
        protected override void OnDisable()
        {
            Stop();
            base.OnDisable();
        }
        protected override void OnDestroy()
        {
            Stop();
            base.OnDestroy();
        }

        /// <summary>
        /// 当前动画播放状态
        /// </summary>
        public YSpriteAnimationState state
        {
            get { return _CurrentState; }
        }
        /// <summary>
        /// implement ISpriteUser
        /// </summary>
        public bool imageReady
        {
            get { return _SpriteHandle == null || _SpriteHandle.ready; }
        }
        /// <summary>
        /// implement ISpriteUser
        /// </summary>
        public ResID[] imageHold
        {
            get
            {
                return _SpriteHandle == null ? null : new ResID[] { _SpriteHandle.id };
            }
        }
        /// <summary>
        /// 播放
        /// </summary>
        public void Play()
        {
            Stop();
            if (_ImageID.valid)
            {
                _CurrentState = YSpriteAnimationState.Play;
                if (_RawImage == null)
                {
                    _RawImage = GetComponent<RawImage>();
                    if (_RawImage == null)
                    {
                        _RawImage = gameObject.AddComponent<RawImage>();
                    }
                    _RawImage.enabled = false;
                    _RawImage.raycastTarget = _RaycastTarget;
                }
                _SpriteHandle = PlayInterface.LoadSprite(_ImageID, _HandleSpriteLoaded);
            }
        }
        /// <summary>
        /// 播放，顺便设置循环次数
        /// </summary>
        /// <param name="loopCount"></param>
        public void Play(int loopCount)
        {
            _LoopCount = loopCount;
            Play();
        }
        /// <summary>
        /// 播放，顺便设置播放时长
        /// </summary>
        /// <param name="duration"></param>
        public void PlayDuration(float duration)
        {
            _LifeTime = duration;
            Play();
        }
        /// <summary>
        /// 暂停
        /// </summary>
        public void Pause()
        {
            if (_CurrentState == YSpriteAnimationState.Play)
            {//只有在播放中，才能简单地这样设置
                _CurrentState = YSpriteAnimationState.Pause;
            }
        }
        /// <summary>
        /// 停止播放
        /// </summary>
        public void Stop()
        {
            //停止播放就直接走清理流程
            Clear();
        }
        /// <summary>
        /// 清理
        /// </summary>
        public void Clear()
        {
            if (_RawImage != null)
            {
                _RawImage.texture = null;
                _RawImage.enabled = false;
            }
            _SpriteHandle = PlayInterface.UnloadSprite(_SpriteHandle);
            _CurrentLoopIndex = 0;
            _LoopCount = -1;
            _CurrentState = YSpriteAnimationState.Stop;
        }

        private void _HandleSpriteLoaded(ISpriteHandle h)
        {
            _SpriteHandle = h;
            Sprite sp = h.sprite;
            if (sp == null)
            {
                Debug.LogWarningFormat("序列帧动画资源{0}加载失败", h.id);
                return;
            }
            _RawImage.texture = sp.texture;
            _RawImage.enabled = true;
            _CellSize = new Vector2(1 / _RowCols.y, 1 / _RowCols.x);
            _CurrentIndex = 0;
            _CurrentLoopIndex = 0;
            _RawImage.uvRect = _CurrentUVRect;
            _InternalCheckTime = _Duration / (_Count - 1);
            _RunTime = 0;
            _BeginPlayTime = Time.unscaledTime;
            _NextPlayTime = _BeginPlayTime;
        }

        private int _CurrentRow
        {
            get
            {
                return Mathf.FloorToInt(_CurrentIndex / (int)_RowCols.y);
            }
        }
        private int _CurrentCols
        {
            get
            {
                return _CurrentIndex % (int)_RowCols.y;
            }
        }
        private Vector2 _CurrentUVPostion
        {
            get
            {
                Vector2 uvPos = new Vector2();
                uvPos.x = _CurrentCols / _RowCols.y;
                uvPos.y = 1 - ((_CurrentRow + 1) / _RowCols.x);
                return uvPos;
            }
        }
        private Rect _CurrentUVRect
        {
            get
            {
                Rect uvRect = new Rect(_CurrentUVPostion, _CellSize);
                return uvRect;
            }
        }
        private void _DriveAnim()
        {
            ++_CurrentIndex;
            ++_CurrentLoopIndex;
            if (_LoopCount != -1 && _CurrentLoopIndex / _Count >= _LoopCount)
            {
                if (_PlayModel == PlayModel.LoopAndPause)
                {
                    Pause();
                    _CurrentIndex--;
                }
                else
                {
                    Stop();
                }
                return;
            }

            if (_CurrentIndex >= _Count)
            {
                switch (_PlayModel)
                {
                    case PlayModel.Loop:
                        {
                            _CurrentIndex %= _Count;
                            break;
                        }
                    case PlayModel.LoopAndPause:
                        {
                            _CurrentIndex %= _Count;
                            break;
                        }
                    case PlayModel.Once:
                        {
                            Stop();
                            return;
                        }
                }
            }
            _RawImage.uvRect = _CurrentUVRect;
        }
        void Update()
        {
            if (PlayInterface.StopYSpriteAnimation())
            {//如果游戏性能模式需要暂停特效
                return;
            }
            if (_CurrentState != YSpriteAnimationState.Play)
            {//不是播放状态，不进行任何处理
                return;
            }
            if (_CanvasRenderer != null && _CanvasRenderer.cull)
            {//裁剪掉的不进行处理
                return;
            }
            if (_RawImage == null || !_RawImage.enabled)
            {//资源未准备好或者rawImage禁用，直接返回
                return;
            }
            if (Time.unscaledTime >= _NextPlayTime)
            {
                _NextPlayTime = Time.unscaledTime + _InternalCheckTime;
                _DriveAnim();
            }
            _RunTime = Time.unscaledTime - _BeginPlayTime;
            if (_LifeTime > 0 && _RunTime >= _LifeTime)
            {
                Stop();
            }
        }
    }
}
