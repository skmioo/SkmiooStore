using System;
using System.Collections.Generic;
using UnityEngine;

namespace Datas
{
    /// <summary>
    /// 按键设置
    /// </summary>
    [Serializable]
    public class KeySettingData : DataBase
    {
        [Tooltip("按键-事件对应表")] public List<SingleKeySetting> keySettings = new List<SingleKeySetting>();
    }

    /// <summary>
    /// 图像设置
    /// </summary>
    [Serializable]
    public class ImageSettingData : DataBase
    {
        [Tooltip("窗口模式")] public WindowModeType windowModeType;
        [Tooltip("分辨率")] public Vector2Int resolution;
    }

    /// <summary>
    /// 音频设置
    /// </summary>
    [Serializable]
    public class AudioSettingData : DataBase
    {
        [Tooltip("静音")] public bool mute;
        [Tooltip("后台静音")] public bool backtageMute;
        [Tooltip("主音量")] public int masterVolumn;
        [Tooltip("音效音量")] public int soundVolumn;
    }

    /// <summary>
    /// 单个按键事件
    /// </summary>
    [Serializable]
    public class SingleKeySetting
    {
        [Tooltip("按键事件")] public KeyEventType keyEventType;
        [Tooltip("按键编码")] public KeyCode keyCode;
    }

    [CreateAssetMenu(menuName = "NewData/SettingData")]
    [Serializable]
    public class SettingDataSet : ScriptableObject
    {
        [Header("按键设置")]
        [SerializeField] public KeySettingData keySettingData;
        [Header("图像设置")]
        [SerializeField] public ImageSettingData imageSettingData;
        [Header("音频设置")]
        [SerializeField] public AudioSettingData audioSettingData;
    }
}

