using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Datas
{
    /// <summary>
    /// 音效数据类
    /// </summary>
    [Serializable]
    public class AudioClipData : DataBase
    {
        [Tooltip("音效资源")]
        /// <summary>
        /// 角色头像
        /// </summary>
        public AssetReference clip;
        public AudioType type;
    }

    /// <summary>
    /// 角色基础数据集合
    /// </summary>
    [CreateAssetMenu(menuName = "NewData/Audio/AudioClipData")]
    [Serializable]
    public class AudioClipDataSet : ScriptableObject
    {
        public string TipsA = "音效数据类";
        public string TipsB = "若想增加角色,在大小中输入一个比当前值更大的值,如5→6";
        public string TipsC = "！！！若在大小中输入了更小的值,可能会造成数据丢失";
        public string TipsD = "！！！鼠标放在字段上有提示";
        [Header("英雄基础数据")]
        [SerializeField] public List<AudioClipData> audioClipDatas = new List<AudioClipData>();
    }
}
