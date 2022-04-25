using Datas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Datas
{
    [System.Serializable]
    public class MedalAttribute: DataBase
    {
        public ObjBuffType buffType;
        public ValueType valueType;
        public int initValue;
        public int addValue;
        public int rollMin;
        public int rollMax;
    }

    [System.Serializable]
    public class MedalEntry:DataBase
    {
        public List<ObjAction> objActions;
    }

    [System.Serializable]
    public class MedalData:DataBase
    {
        public int level;
        /// <summary>
        /// 勋章Icon
        /// </summary>
        [Tooltip("勋章Icon")]public AssetReferenceSprite icon;
        /// <summary>
        /// 勋章Icon背景
        /// </summary>
        [Tooltip("勋章Icon背景")] public AssetReferenceSprite iconBg;
        public LevelType levelType;
        public int entryRollCount;
        public List<int> entryRollRange;
        public int attributeRollCount;
    }

    [CreateAssetMenu(menuName = "NewData/MedalDataSet")]
    [System.Serializable]
    public class MedalDataSet:ScriptableObject
    {
        [Header("随机属性")]
        public List<MedalAttribute> medalAttributes;
        [Header("勋章词条")]
        public List<MedalEntry> medalEntries;
        [Header("勋章属性")]
        public List<MedalData> medalDatas;
    }
}

/// <summary>
/// 勋章对象类
/// </summary>
public class MedalObjData
{
    private MedalData medalData;
    private MedalMode medalMode;
    private List<ObjPermanentBuff> attributes;
    private List<ObjPermanentBuff> entries;

    public MedalObjData(MedalData medalData, MedalMode medalMode, List<ObjPermanentBuff> attributes, List<ObjPermanentBuff> entries)
    {
        this.medalData = medalData;
        this.medalMode = medalMode;
        this.attributes = attributes;
        this.entries = entries;
    }

    /// <summary>
    /// 获取id
    /// </summary>
    /// <returns></returns>
    public int GetId()
    {
        return medalData.id;
    }

    /// <summary>
    /// 获取星级
    /// </summary>
    /// <returns></returns>
    public int GetLevel()
    {
        return medalData.level;
    }

    /// <summary>
    /// 获取名称
    /// </summary>
    /// <returns></returns>
    public string GetName()
    {
        return medalData.name;
    }

    /// <summary>
    /// 获取贴图
    /// </summary>
    /// <returns></returns>
    public AssetReferenceSprite GetIcon()
    {
        return medalData.icon;
    }

    /// <summary>
    /// 获取品质
    /// </summary>
    /// <returns></returns>
    public LevelType GetLevelType()
    {
        return medalData.levelType;
    }

    /// <summary>
    /// 获取词条随机次数
    /// </summary>
    /// <returns></returns>
    public int GetEntryRollCount()
    {
        return medalData.entryRollCount;
    }

    /// <summary>
    /// 获取词条随机范围
    /// </summary>
    /// <returns></returns>
    public List<int> GetEntryRollRange()
    {
        return medalData.entryRollRange;
    }

    /// <summary>
    /// 获取属性随机次数
    /// </summary>
    /// <returns></returns>
    public int GetAttributeRollCount()
    {
        return medalData.entryRollCount;
    }

    /// <summary>
    /// 获取属性
    /// </summary>
    /// <returns></returns>
    public List<ObjPermanentBuff> GetAttribute()
    {
        return attributes;
    }

    /// <summary>
    /// 获取词条
    /// </summary>
    /// <returns></returns>
    public List<ObjPermanentBuff> GetEntry()
    {
        return entries;
    }

    public MedalMode GetMedalMode()
    {
        return medalMode;
    }

    /// <summary>
    /// 将效果转为字符串
    /// </summary>
    /// <returns></returns>
    public string ObjActionsToString()
    {
        string result = "";
        foreach (var item in attributes)
        {
            result += item.buffType.ToString() + "\t" + (item.buffValue > 0 ? "+" : "") + item.buffValue.ToString() + (item.valueType == ValueType.系数 ? "%" : "") + "\n";
        }
        foreach (var item in entries)
        {
            result += item.buffType.ToString() + "\t" + (item.buffValue > 0 ? "+" : "") + item.buffValue.ToString() + (item.valueType == ValueType.系数 ? "%" : "") + "\n";
        }
        return result;
    }
}
