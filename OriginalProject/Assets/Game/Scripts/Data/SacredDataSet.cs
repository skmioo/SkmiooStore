using Datas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Datas
{
    [System.Serializable]
    public class SacredData : ObjData //DataBase
    {
        /// <summary>
        /// 掉落区域
        /// </summary>
       [Tooltip("圣物掉落区域")] public SacredArea sacredArea;
        /// <summary>
        /// 图标
        /// </summary>
        //public AssetReferenceSprite icon;
    }

    [System.Serializable]
    public class SacredCombination : DataBase
    {
        /// <summary>
        /// 组合
        /// </summary>
        public List<int> combinationIds;

        /// <summary>
        /// 效果
        /// </summary>
        public List<ObjAction> objActions;

        /// <summary>
        /// 将组合效果转为字符串
        /// </summary>
        /// <returns></returns>
        public string ObjActionsToString()
        {
            string result = "";
            foreach (var item in objActions)
            {
                result += item.buffType.ToString() + "\t" + (item.value > 0 ? "+" : "") + item.value.ToString() + (item.valueType == ValueType.系数 ? "%" : "") + "\n";
            }
            return result;
        }
    }

    [CreateAssetMenu(menuName = "NewData/SacredDataSet")]
    [System.Serializable]
    public class SacredDataSet : ScriptableObject
    {
        [Header("圣物数据")]
        public List<SacredData> sacredDatas;
        [Header("组合效果")]
        public List<SacredCombination> sacredCombinations;
    }
}

/// <summary>
/// 圣物对象类
/// </summary>
public class SacredObjData
{
    private SacredMode sacredMode;
    private SacredData sacredData;

    public SacredObjData(SacredMode sacredMode, SacredData sacredData)
    {
        this.sacredMode = sacredMode;
        this.sacredData = sacredData;
    }

    /// <summary>
    /// 获取id
    /// </summary>
    /// <returns></returns>
    public int GetId()
    {
        return sacredMode.id;
    }

    /// <summary>
    /// 获取名字
    /// </summary>
    /// <returns></returns>
    public string GetName()
    {
        return sacredData.name;
    }

    /// <summary>
    /// 获取描述
    /// </summary>
    /// <returns></returns>
    public string GetDescribe()
    {
        return sacredData.describe;
    }

    /// <summary>
    /// 获取是否被放置
    /// </summary>
    /// <returns></returns>
    public bool GetIsBePut()
    {
        return sacredMode.isBePut;
    }

    /// <summary>
    /// 设置是否被放置
    /// </summary>
    /// <returns></returns>
    public void SetIsBePut(bool isBePut)
    {
        sacredMode.isBePut = isBePut;
    }

    /// <summary>
    /// 获取放置的位置
    /// </summary>
    /// <returns></returns>
    public int GetNum()
    {
        return sacredMode.num;
    }
    public SacredMode GetSacredMode() {
        return sacredMode;
    }
    /// <summary>
    /// 设置放置的位置
    /// </summary>
    /// <returns></returns>
    public void SetNum(int num)
    {
        sacredMode.num = num;
    }

    /// <summary>
    /// 获取所属区域
    /// </summary>
    /// <returns></returns>
    public SacredArea GetArea()
    {
        return sacredData.sacredArea;
    }

    /// <summary>
    /// 获取图标
    /// </summary>
    /// <returns></returns>
    public AssetReferenceSprite GetIcon()
    {
        return sacredData.Icon;
    }
}