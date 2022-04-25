using Datas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AudioNode
{
    private AudioSource m_AudioSource;
    public int m_id { get; private set; }
    public bool isPlaying
    {
        get
        {
            if (m_AudioSource.clip == null) return false;
            return m_AudioSource.isPlaying;
        }
    }
    public bool isLoop { get { return m_AudioSource.loop; } }
    public float Volume { get { return m_AudioSource.volume; } set { m_AudioSource.volume = value; } }
    public bool Mute { get { return m_AudioSource.mute; } set { m_AudioSource.mute = value; } }
    public AudioNode(AudioSource _source, int _id)
    {
        m_AudioSource = _source;
        m_id = _id;
        m_AudioSource.Stop();
    }

    public void Play(AudioClip _clip, float _volume, bool _loop,bool _mute)
    {
        m_AudioSource.clip = _clip;
        m_AudioSource.loop = _loop;
        Volume = _volume;
        Mute = _mute;
        m_AudioSource.Play();
        //AudioSettings.dspTime
       //m_AudioSource.PlayScheduled()
    }
    public void Stop()
    {
        m_AudioSource.loop = false;
        m_AudioSource.Stop();
    }
}
/// <summary>
/// 音效管理 数据持久化待完善
/// </summary>
public class AudioManager : MonoSingleton<AudioManager>
{
    protected override bool global => true;
    private List<AudioNode> m_AudioNodes = new List<AudioNode>();
    private Dictionary<string, AudioClip> m_AudioDic = new Dictionary<string, AudioClip>();
    private int curBgmAudioId = int.MinValue;
    AudioSettingData m_audioSettingData;
    private  bool m_mute;
    private  bool m_backstageMute;
    private  int m_mainVolume;
    public float CurMainVolume { get { return m_mainVolume / (MainVolumeMax * 1.0f); } }
    private  int m_soundVolume;
    public float CurSoundVolume { get { return CurMainVolume * (m_soundVolume / (SoundVolumeMax * 1.0f)) * (1f / 3f); } }
    public const int MainVolumeMax = 100;
    public const int SoundVolumeMax = 100;
    protected const string defaultResourcesPath = "Audio/";
    public const string BgmPath = defaultResourcesPath + "BGM/";
    public const string CommonPath = defaultResourcesPath + "Common/";
    public const string BattleCommonPath = defaultResourcesPath + "BattleCommon/";
    public const string SkillPath = defaultResourcesPath + "Skill/";
    private bool m_bPlayOpenVideo = false;
    /// <summary>
    /// 测试
    /// </summary>
    protected override void Awake()
    {
        base.Awake();
        m_mute = false;
        m_backstageMute = false;
        m_mainVolume = MainVolumeMax;
        m_soundVolume = SoundVolumeMax;
    }
    /// <summary>
    /// 初始化数据
    /// </summary>
    public void Initialized()
    {
        m_audioSettingData = DataManager.Instance.GetAudioSettingData();
        m_mute = m_audioSettingData.mute;
        m_backstageMute = m_audioSettingData.backtageMute;
        m_mainVolume = m_audioSettingData.masterVolumn;
        m_soundVolume = m_audioSettingData.soundVolumn ;
    }

    private AudioNode NewAudioNode()
    {
        AudioNode atmp = null;
        bool ishave = false;
        for (int i = 0; i < m_AudioNodes.Count; ++i)
        {
            if (!m_AudioNodes[i].isPlaying)
            {
                atmp = m_AudioNodes[i];
                ishave = true;
                break;
            }
        }
        if (!ishave)
        {
            AudioSource tmp = gameObject.AddComponent<AudioSource>();
            tmp.playOnAwake = false;
            atmp = new AudioNode(tmp, m_AudioNodes.Count);
            m_AudioNodes.Add(atmp);
        }
        return atmp;
    }
    /// <summary>
    /// 播放背景音乐
    /// </summary>
    /// <param name="_audioName"></param>
    /// <param name="_volume">此参数是为了方便微调部分音效音量默认直接给1就可以</param>
    /// <returns></returns>
    public int PlayMusic(string _audioName, float _volume = 1)
    {
        float mainVolumeTemp = CurMainVolume * _volume;
        AudioNode temp = PlayAudiobyPath(_audioName, mainVolumeTemp, true, BgmPath, () => { StopAudio(curBgmAudioId); }, (id) => { curBgmAudioId = id; });
        return temp != null ? temp.m_id:int.MinValue;
    }
    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="_audioName"></param>
    /// <param name="type">音效类型</param>
    /// <param name="_loop"></param>
    /// <param name="_volume">此参数是为了方便微调部分音效音量默认直接给1就可以</param></param>
    /// <returns></returns>
    public int PlayAudio(string _audioName, AudioType type,  bool _loop = false,float _volume = 1)
    {
        float soundVolumeTemp = CurSoundVolume * _volume;
        string pathTemp = CommonPath;
        switch (type)
        {
            case AudioType.BGM: pathTemp = BgmPath; break;
            case AudioType.Common: pathTemp = CommonPath; break;
            case AudioType.BattleCommon: pathTemp = BattleCommonPath ; break;
            case AudioType.Skill: pathTemp =SkillPath ; break;
        }
        AudioNode temp = PlayAudiobyPath(_audioName, soundVolumeTemp, _loop, pathTemp);
        return temp != null ? temp.m_id : int.MinValue;
    }
    private AudioNode PlayAudiobyPath(string _audioName, float _volume, bool _loop, string _path, UnityAction playBefore = null, UnityAction<int> playAfter = null)
    {
        AudioNode tmp = null;
        if (!m_AudioDic.ContainsKey(_audioName))
        {
            AudioClip _clip = Resources.Load<AudioClip>(_path + _audioName);
            if (_clip == null)
            {
                Debug.LogError(_audioName + " is no Audio");
                return tmp;
            }
            m_AudioDic.Add(_audioName, _clip);
        }
        tmp = NewAudioNode();
        playBefore?.Invoke();
        //窗口的状态
        bool windowActive = false;
        tmp.Play(m_AudioDic[_audioName], _volume, _loop, m_backstageMute?(windowActive ? m_mute :false) : m_mute);
        playAfter?.Invoke(tmp.m_id);
        return tmp;
    }
    public void StopBgmMusic() {
        StopAudio(curBgmAudioId);
    }
    /// <summary>
    /// 停止播放的音效
    /// </summary>
    /// <param name="_name"></param>
    public void StopAudio(int audioID)
    {
        if (audioID == int.MinValue) return;
        UpdateAudioNodeStage(audioID, (node) => {
            if (node.isPlaying) node.Stop();
        });
      
    }
   
    public void MuteAudio(int audioID) {
        if (audioID == int.MinValue) return;
        UpdateAudioNodeStage(audioID, (node) => {
            if(node.isPlaying) node.Mute = false;
        });
    }
    public void ForEachAudioNode(UnityAction<AudioNode> call)
    {
        for (int i = 0; i < m_AudioNodes.Count; ++i) call.Invoke(m_AudioNodes[i]);
    }
    public void UpdateAudioNodeStage(int audioID, UnityAction<AudioNode> call) {
        if (audioID == int.MinValue) return;
        ForEachAudioNode((node)=> {
            if(node.m_id == audioID) call.Invoke(node);
        });
    }
    public int GetMainVolume()
    {
      //  if (m_mainVolume != m_audioSettingData.masterVolumn) m_mainVolume = m_audioSettingData.masterVolumn;
        return m_mainVolume;
    }
    /// <summary>
    /// 设置主音量
    /// </summary>
    /// <param name="_volume">音量取值[0,100]</param>
    public void SetMainVolume(int _volume)
    {
        if (_volume < 0 || _volume > 100)
        {
            Debug.LogError("音量值错误，音量取值范围[0,100]");
            return;
        }
        m_mainVolume = _volume;
      //  m_audioSettingData.masterVolumn = m_mainVolume;
        ForEachAudioNode((node)=> {
          if(node.isPlaying)  node.Volume = node.m_id == curBgmAudioId ? CurMainVolume : CurSoundVolume;
        });
    }

    /// <summary>
    /// 设置音效音量
    /// </summary>
    /// <param name="volume">音量取值[0,100]</param>
    public void SetSoundVolume(int volume)
    {
        if (volume < 0 || volume > 100)
        {
            Debug.LogError("音量值错误，音量取值范围[0,100]");
            return;
        }
        m_soundVolume = volume;
      //  m_audioSettingData.soundVolumn = m_soundVolume;
      
        ForEachAudioNode((node) => {
          if(node.isPlaying && node.m_id != curBgmAudioId)   node.Volume = CurSoundVolume;
        });
    }
    public int GetSoundVolume()
    {
       // if (m_soundVolume != m_audioSettingData.soundVolumn) m_soundVolume = m_audioSettingData.soundVolumn;
        return m_soundVolume;
    }
    public void SetMute(bool _isMute)
    {
        m_mute = _isMute;
      //  m_audioSettingData.mute = m_mute;
        ForEachAudioNode((node) => {
            node.Mute = _isMute;
        });
    } 
    public bool GetMute()
    {
       // if (m_mute != m_audioSettingData.mute) m_mute = m_audioSettingData.mute;
        return m_mute;
    }
    public void SetBacktageMute(bool _isMute)
    {
        m_backstageMute = _isMute;
       // m_audioSettingData.backtageMute = m_backstageMute;
    }
    public bool GetBackStageMute()
    {
       // if (m_backstageMute != m_audioSettingData.backtageMute) m_backstageMute = m_audioSettingData.backtageMute;
        return m_backstageMute;
    }

    /// <summary>
    /// 设置开场动画
    /// </summary>
    public void SetPlayOpenVideo(bool bPlayOpenVideo)
    {
        m_bPlayOpenVideo = bPlayOpenVideo;
    }

    /// <summary>
    /// 获取开场动画
    /// </summary>
    public bool GetPlayOpenVideo()
    {
        return m_bPlayOpenVideo;
    }
}

