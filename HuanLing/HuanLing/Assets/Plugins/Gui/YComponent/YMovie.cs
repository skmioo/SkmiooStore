using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using RenderHeads.Media.AVProVideo;
using SLua;
using UYMO;

namespace UnityEngine.UI
{
    /// <summary>
    /// 播放视频的ui组件
    /// </summary>
    [CustomLuaClass]
    [AddComponentMenu("YUI/YMovie", 16)]
    [SelectionBase]
    [Serializable]
    [DisallowMultipleComponent]
    [ExecuteInEditMode]
    public class YMovie : MonoBehaviour, IClearable
    {
        [SerializeField]
        [HideInInspector]
        private string _VideoFile;
        /// <summary>
        /// 需要播放的视频文件
        /// </summary>
        public string video
        {
            get { return _VideoFile; }
            set
            {
                if (value == "")
                    value = null;
                if (value != null)
                {
                    value = PluginUtil.ValidatePath(value, false);
                    value = PluginUtil.RemoveExtention(PluginUtil.SubstructPureName(value)) + ".ab";
                }
                if (value == _VideoFile)
                    return;
                _VideoFile = value;
                ApplyVideo(_VideoFile);
            }
        }
        [SerializeField]
        [HideInInspector]
        private bool _AutoClose;
        /// <summary>
        /// 播放完毕之后是否自动关闭
        /// </summary>
        public bool autoClose
        {
            get { return _AutoClose; }
            set
            {
                _AutoClose = value;
                if (_AutoClose && _AVMedia.Control != null && _AVMedia.Control.IsFinished())
                {
                    video = null;
                }
            }
        }
        /// <summary>
        /// 在组件创建时自动加载视频
        /// </summary>
        public bool autoLoad
        {
            get { return _AVMedia.m_AutoOpen; }
            set { _AVMedia.m_AutoOpen = value; }
        }
        /// <summary>
        /// 在加载（设置）完视频后自动播放
        /// </summary>
        public bool autoPlay
        {
            get { return _AVMedia.m_AutoStart; }
            set { _AVMedia.m_AutoStart = value; }
        }
        /// <summary>
        /// 保持视频宽高比
        /// </summary>
        public bool keepAspectRatio
        {
            get { return _AVGui._keepAspectRatio; }
            set { _AVGui._keepAspectRatio = value; }
        }
        /// <summary>
        /// 是否循环播放
        /// </summary>
        public bool loop
        {
            get { return _AVMedia.m_Loop; }
            set
            {
                if (_AVMedia.m_Loop != value)
                {
                    _AVMedia.m_Loop = value;
                    if (_AVMedia.Control != null)
                        _AVMedia.Control.SetLooping(value);
                }
            }
        }
        /// <summary>
        /// 音量
        /// </summary>
        public float volume
        {
            get { return _AVMedia.m_Volume; }
            set
            {
                value = MathUtil.Clamp(value, 0.0f, 1.0f);
                if (_AVMedia.m_Volume != value)
                {
                    _AVMedia.m_Volume = value;
                    if (_AVMedia.Control != null)
                        _AVMedia.Control.SetVolume(value);
                }
            }
        }
        /// <summary>
        /// 静音
        /// </summary>
        public bool mute
        {
            get { return _AVMedia.m_Muted; }
            set
            {
                if (_AVMedia.m_Muted != value)
                {
                    _AVMedia.m_Muted = value;
                    if (_AVMedia.Control != null)
                        _AVMedia.Control.MuteAudio(value);
                }
            }
        }
        /// <summary>
        /// 是否在播放中
        /// </summary>
        public bool playing
        {
            get { return _AVMedia.Control != null && _AVMedia.Control.IsPlaying(); }
        }
        /// <summary>
        /// 在编辑器里是否显示详细细节
        /// </summary>
        public bool debugInEditor
        {
            get { return _AVMedia.hideFlags != HideFlags.HideInInspector; }
            set
            {
                if (value)
                {
                    _AVMedia.hideFlags = HideFlags.None;
                    _AVGui.hideFlags = HideFlags.None;
                }
                else
                {
                    _AVMedia.hideFlags = HideFlags.HideInInspector;
                    _AVGui.hideFlags = HideFlags.HideInInspector;
                }
            }
        }

        private DisplayUGUI _AVGui;
        private MediaPlayer _AVMedia;

        private LuaTable m_LuaTable;
        private LuaTable m_LuaArgs;
        private Action<LuaTable, YMovie, LuaTable> m_LuaPlayOverHandler;

        //编辑器模式下
        private BaseMediaPlayer _edit_mediaDecoder;

        /// <summary>
        /// 播放完之后的回调
        /// </summary>
        public Action<YMovie> playOverHandler;


        void Awake()
        {
            _AVGui = gameObject.GetComponent<DisplayUGUI>();
            if (_AVGui == null)
            {
                _AVGui = gameObject.AddComponent<DisplayUGUI>();
                _AVGui.hideFlags = HideFlags.HideInInspector;
            }
            _AVMedia = gameObject.GetComponent<MediaPlayer>();
            if (_AVMedia == null)
            {
                _AVMedia = gameObject.AddComponent<MediaPlayer>();
                _AVMedia.hideFlags = HideFlags.HideInInspector;
                _AVMedia.m_VideoLocation = MediaPlayer.FileLocation.AbsolutePathOrURL;
                _AVMedia.m_Persistent = true;
                _AVGui.CurrentMediaPlayer = _AVMedia;
                autoLoad = true;
                autoPlay = true;
                autoClose = true;
                keepAspectRatio = true;
                loop = false;
                volume = 1.0f;
                mute = false;
            }
            _AVMedia.Events.AddListener(OnVideoEvent);
        }

        void Start()
        {
            if (_VideoFile != null)
            {
                ApplyVideo(_VideoFile);
            }
        }
        private void ApplyVideo(string videoFile)
        {
            if (Application.isPlaying)
            {//运行模式
                if (string.IsNullOrEmpty(videoFile))
                {
                    _AVMedia.CloseVideo();
                    return;
                }
                videoFile = PluginUtil.RemoveExtention(videoFile) + ".mp4";
                string path = PluginUtil.ValidResFilePath("Assets/AssetsData/Movie/" + videoFile, true, false, false);
                _AVMedia.OpenVideoFromFile(MediaPlayer.FileLocation.AbsolutePathOrURL, path, autoPlay);
            }
            else
            {//编辑器模式
                _AVGui._defaultTexture = null;
                if (_edit_mediaDecoder != null)
                {
                    _edit_mediaDecoder.CloseVideo();
                }
                if (!string.IsNullOrEmpty(videoFile))
                {
                    string path = PluginUtil.ValidResFilePath("Assets/AssetsData/Movie/" + videoFile, true, false, false);
                    if (_edit_mediaDecoder == null)
                        _edit_mediaDecoder = _AVMedia.CreatePlatformMediaPlayer();
                    _edit_mediaDecoder.OpenVideoFromFile(path);
                }
            }
        }
        private void OnVideoEvent(MediaPlayer mp, MediaPlayerEvent.EventType evtType, ErrorCode error)
        {
            if (evtType == MediaPlayerEvent.EventType.Error
                || evtType == MediaPlayerEvent.EventType.FinishedPlaying)
            {
                if (_AutoClose)
                {
                    Close();
                }
                if (playOverHandler != null)
                {
                    playOverHandler(this);
                }
                if (m_LuaPlayOverHandler != null)
                {
                    m_LuaPlayOverHandler(m_LuaTable, this, m_LuaArgs);
                }
            }
        }

        /// <summary>
        /// 播放视频
        /// </summary>
        public void Play(bool fromStart = false)
        {
            if (fromStart)
                _AVMedia.Rewind(false);
            _AVMedia.Play();
        }
        /// <summary>
        /// 停止（暂停）视频播放
        /// </summary>
        public void Stop(bool pause = true)
        {
            if (pause)
                _AVMedia.Pause();
            else
                _AVMedia.Stop();
        }
        /// <summary>
        /// 关闭并清理视频
        /// </summary>
        public void Close()
        {
            _AVMedia.CloseVideo();
        }
        /// <summary>
        /// 所有的清理，包括视频、事件
        /// </summary>
        public void Clear()
        {
            playOverHandler = null;
            ClearLuaHandler();
        }
        /// <summary>
        /// 设置控件大小为视频原始尺寸
        /// </summary>
        public void SetNativeSize()
        {
            if (Application.isPlaying)
            {//运行模式下
                _AVGui.SetNativeSize();
            }
            else
            {//编辑器模式下
                if (_edit_mediaDecoder != null)
                {
                    float w = _edit_mediaDecoder.GetVideoWidth();
                    float h = _edit_mediaDecoder.GetVideoHeight();
                    GetComponent<RectTransform>().sizeDelta = new Vector2(w, h);
                }
            }
        }
        /// <summary>
        /// 编辑器模式下刷新
        /// </summary>
        public void UpdateInEditor()
        {
            if (_edit_mediaDecoder != null)
            {
                _edit_mediaDecoder.Update();
                if (_AVGui._defaultTexture == null)
                {
                    int w = _edit_mediaDecoder.GetVideoWidth();
                    int h = _edit_mediaDecoder.GetVideoHeight();
                    if (w > 0 && h > 0)
                    {
                        var tex = new Texture2D(w, h, TextureFormat.RGB24, false);
                        _AVGui._defaultTexture = tex;
                    }
                }
            }
        }
        /// <summary>
        /// 抓取当前纹理
        /// </summary>
        /// <returns></returns>
        public Texture currentTexture
        {
            get
            {
                if (Application.isPlaying)
                    return _AVGui.mainTexture;
                else if (_edit_mediaDecoder != null)
                    return _edit_mediaDecoder.GetTexture();
                else
                    return null;
            }
        }
        /// <summary>
        /// 源视频宽
        /// </summary>
        public int videoWidth
        {
            get
            {
                if (_edit_mediaDecoder != null)
                {
                    return _edit_mediaDecoder.GetVideoWidth();
                }
                if (_AVMedia.Info != null)
                {
                    return _AVMedia.Info.GetVideoWidth();
                }
                return 0;
            }
        }
        /// <summary>
        /// 源视频高
        /// </summary>
        public int videoHeight
        {
            get
            {
                if (_edit_mediaDecoder != null)
                {
                    return _edit_mediaDecoder.GetVideoHeight();
                }
                if (_AVMedia.Info != null)
                {
                    return _AVMedia.Info.GetVideoHeight();
                }
                return 0;
            }
        }
        /// <summary>
        /// 设置视频播放完毕后的回调
        /// </summary>
        /// <param name="lua"></param>
        /// <param name="handler"></param>
        public void SetMoviePlayOverHandler(LuaTable lua, Action<LuaTable, YMovie, LuaTable> handler)
        {
            SetMoviePlayOverHandler(lua, handler, null);
        }
        /// <summary>
        /// 设置视频播放完毕后的回调
        /// </summary>
        /// <param name="lua"></param>
        /// <param name="handler"></param>
        /// <param name="args"></param>
        public void SetMoviePlayOverHandler(LuaTable lua, Action<LuaTable, YMovie, LuaTable> handler, LuaTable args)
        {
            m_LuaTable = lua;
            m_LuaArgs = args;
            m_LuaPlayOverHandler = handler;
        }
        /// <summary>
        /// 清理回调
        /// </summary>
        public void ClearLuaHandler()
        {
            m_LuaArgs = m_LuaTable = null;
            m_LuaPlayOverHandler = null;
        }
    }
}
