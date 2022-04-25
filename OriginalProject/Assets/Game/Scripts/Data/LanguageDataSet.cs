using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Datas
{
    /// <summary>
    /// 多语言数据类
    /// </summary>
    [Serializable]
    public class LanguageData
    {
        public int id;
        /// <summary>
        /// 技能id(当项不是技能时默认-1)
        /// </summary>
        public int skillID;
        [TextArea] public string model;
        [TextArea] public string type;
        /// <summary>
        /// 中文
        /// </summary>
        [Tooltip("中文")]
        public string cn;
        /// <summary>
        /// 英语
        /// </summary>
        [Tooltip("英语")]
        public string en;
    }

    /// <summary>
    /// 多语言数据集合
    /// </summary>
    [CreateAssetMenu(menuName = "NewData/Language/LanguageDataSet")]
    [Serializable]
    public class LanguageDataSet : ScriptableObject
    {
        public string TipsA = "多语言数据类";
        public string TipsB = "若想增加角色,在大小中输入一个比当前值更大的值,如5→6";
        public string TipsC = "！！！若在大小中输入了更小的值,可能会造成数据丢失";
        public string TipsD = "！！！鼠标放在字段上有提示";
        [Header("多语言基础数据")]
        [SerializeField] public List<LanguageData> LanguageDatas = new List<LanguageData>();
    }
}
