using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Datas
{
    /// <summary>
    /// 交互物数据
    /// </summary>
    [Serializable]
    public class InteractiveData : DataBase
    {
        public InteractiveType interactiveType;
        public string tip;
        /// <summary>
        /// 可交互次数最大值
        /// </summary>
        [Tooltip("可交互次数最大值")] public int interactiveCountMax;
        /// <summary>
        /// 权重
        /// </summary>
        public int probability;
        public AssetReferenceSprite icon;
        /// <summary>
        /// 祭坛icon
        /// </summary>
       [Tooltip("祭坛icon")] public List<AltarIconData> altarIcons;
    }

    /// <summary>
    /// 交互物刷新数量
    /// </summary>
    [Serializable]
    public class InteractiveNumberData
    {
        public TaskDifficulty taskDifficulty;
        public MapSizeType mapSize;
        public List<InteractiveNumber> numbers;
    }
    /// <summary>
    /// 交互物刷新数量的上下限
    /// </summary>
    [Serializable]
    public class InteractiveNumber
    {
        public InteractiveType interactiveType;
        public int minCount;
        public int maxCount;
    }

    /// <summary>
    /// 经文数据
    /// </summary>
    [Serializable]
    public class InteractiveScripture : ObjData
    {
        [Header("经文数据")]
        /// <summary>
        /// 经文类型
        /// </summary>
        [Tooltip("经文类型")] public ScriptureType scriptureType;
        /// <summary>
        /// 经文背包描述
        /// </summary>
        [Tooltip("经文背包描述")] [TextArea] public string knapsackDescribe;
        /// <summary>
        /// 经文类型权重
        /// </summary>
        [Tooltip("经文类型权重")] public int ScriptureTypeProbability;
        /// <summary>
        /// 经文效果权重
        /// </summary>
        [Tooltip("经文效果权重")] public int probability;
        /// <summary>
        /// 使用经文产生的Buff效果
        /// </summary>
        [Tooltip("经文产生的Buff效果")]
        public List<SkillBuff> skillBuffs;

    }
    /// <summary>
    /// 祭坛献祭
    /// </summary>
    [Serializable]
    public class InteractiveAltar : DataBase
    {
        public AltarType altarType;
        public int probability;
        /// <summary>
        /// 献祭次数最大值
        /// </summary>
        [Tooltip("献祭次数最大值")]public int sacrificeCoutMax;
        public List<AltarSacrifice> sacrifices;
    }
    /// <summary>
    /// 祭坛Icon
    /// </summary>
    [Serializable]
    public class AltarIconData {
       public AltarType altarType;
        public AssetReferenceSprite icon;
    }
    /// <summary>
    /// 献祭消耗
    /// </summary>
    [Serializable]
    public class AltarSacrifice
    {
        /// <summary>
        /// 第几次献祭(从0开始)
        /// </summary>
        [Tooltip("第几次献祭(从0开始)")] public int sacrificeCount;
        /// <summary>
        /// 消耗hp下限
        /// </summary>
        [Tooltip("消耗hp下限")] public int minHpReduce;
        /// <summary>
        /// 消耗hp上限
        /// </summary>
        [Tooltip("消耗hp上限")] public int maxHpReduce;
        /// <summary>
        /// 全队的hp限制 >= hpLimit
        /// </summary>
        [Tooltip("全队的hp限制")] public int hpLimit;
        /// <summary>
        /// 奖励
        /// </summary>
        public List<AltarReward> rewards;
    }

    /// <summary>
    /// 祭坛奖励-贪婪
    /// </summary>
    [Serializable]
    public class AltarReward
    {
        public AltarRewardType rewardType;
        [Tooltip("奖励的数量")] public int count;
        public int probability;
    }

    /// <summary>
    /// 祭坛奖励-愚昧-祝福
    /// </summary>
    [Serializable]
    public class AltarBless
    {
        public AltarRewardType rewardType;
        public List<AltarBlessAction> actions;
    }

    [Serializable]
    public class AltarBlessAction
    {
        public int probability;
       [TextArea] public string describe;
        public List<TalentBuff> action;
    }

    /// <summary>
    /// 解救交互-囚犯事件
    /// </summary>
    [Serializable]
    public class InteractiveRescue : DataBase
    {
        /// <summary>
        /// 囚徒身份
        /// </summary>
        public RescueType rescueType;
        /// <summary>
        /// 
        /// </summary>
        public int probability;
        /// <summary>
        /// 交互结果数据
        /// </summary>
        public List<RescueInteractiveResltData> interactiveResultDatas;
        public AssetReferenceSprite icon;
        /// <summary>
        /// 怪物组合，留空以选取地图数据中的怪物组合
        /// </summary>
        [Tooltip("战斗事件-怪物列表")] public List<int> monsterIds;
    }
    [Serializable]
    public class RescueInteractiveResltData {
        public RescueResultType resultType;
        /// <summary>
        /// 奖励概率 或 战斗概率
        /// </summary>
        public int probability;
    }
    /// <summary>
    /// 地下游商
    /// </summary>
    [Serializable]
    public class InteractiveShop
    {
        public ObjType objType;

        /// <summary>
        /// 刷新概率，注意不是权重
        /// </summary>
        public int probability;
        public int minCount;
        public int maxCount;
        public List<InteractiveShopOrnament> levels;
    }

    [Serializable]
    public class InteractiveShopOrnament
    {
        public LevelType levelType;
        public int probability;
    }
    /// <summary>
    /// 交互物数据集
    /// </summary>
    [CreateAssetMenu(menuName = "NewData/InteractiveData")]
    [Serializable]
    public class InteractiveDataSet : ScriptableObject
    {
        /// <summary>
        /// 交互物数据
        /// </summary>
        [Header("交互物数据")]
        [SerializeField] public List<InteractiveData> interactiveDatas = new List<InteractiveData>();
        /// <summary>
        /// 交互物刷新数量
        /// </summary>
        [Header("交互物刷新数量")]
        [SerializeField] public List<InteractiveNumberData> interactiveNumberDatas = new List<InteractiveNumberData>();
        /// <summary>
        /// 经文表
        /// </summary>
        [Header("经文表")]
        [SerializeField] public List<InteractiveScripture> interactiveScriptures = new List<InteractiveScripture>();
        /// <summary>
        /// 祭坛献祭
        /// </summary>
        [Header("祭坛献祭")]
        [SerializeField] public List<InteractiveAltar> interactiveAltars = new List<InteractiveAltar>();
        /// <summary>
        /// 祭坛奖励-祝福
        /// </summary>
        [Header("祭坛奖励-祝福")]
        [SerializeField] public List<AltarBless> altarBlesses = new List<AltarBless>();
        /// <summary>
        /// 解救-囚犯事件
        /// </summary>
        [Header("解救-囚犯事件")]
        [SerializeField] public List<InteractiveRescue> interactiveRescues = new List<InteractiveRescue>();
        /// <summary>
        /// 地下游商
        /// </summary>
        [Header("地下游商")]
        [SerializeField] public List<InteractiveShop> interactiveShops = new List<InteractiveShop>();
    }
}

