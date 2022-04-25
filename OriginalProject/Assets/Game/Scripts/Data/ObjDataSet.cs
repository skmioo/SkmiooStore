using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Datas
{

    /// <summary>
    /// 物品数据
    /// </summary>
    [Serializable]
    public class ObjData:DataBase
    {
        public AssetReferenceSprite Icon;
        /// <summary>
        /// Icon背景
        /// </summary>
        [Tooltip("Icon背景")] public AssetReferenceSprite IconBg;
        [Tooltip("物品类型")]
        public ObjType objType;

        [Tooltip("职业限制")]
        public HeroVocation heroVocation;

        [Tooltip("品级类型")]
        public LevelType levelType;

        [Tooltip("掉落者类型")]
        public OwnerType ownerType;

        [Tooltip("买入价格")]
        public int buy;

        [Tooltip("卖出价格")]
        public int sell;

        [Tooltip("结算价格")]
        public int settlement;

        [Tooltip("堆叠量")]
        public int maxCount;

        [Tooltip("道具效果")]
        public List<ObjAction> objActions;

        [Tooltip("特殊效果")]
        public SpecialEffect specialEffect;
     
        public int Count { get; set; }

        public  ObjData Clone()
        {
            ObjData that = new ObjData();
            that.id = id;
            that.name = name;
            that.describe = describe;
            that.describe_EN = describe_EN;
            that.Icon = Icon;
            that.IconBg = IconBg;
            that.objType = objType;
            that.heroVocation = heroVocation;
            that.levelType = levelType;
            that.ownerType = ownerType;
            that.buy = buy;
            that.sell = sell;
            that.settlement = settlement;
            that.maxCount = maxCount;
            that.objActions = objActions;
            that.specialEffect = specialEffect;
            that.Count = Count;
            return that;// MemberwiseClone() as ObjData;
        }
    }


    /// <summary>
    /// 物品的功能
    /// </summary>
    [Serializable]
    public class ObjAction
    {
        /// <summary>
        /// 限制类型
        /// </summary>
        [Tooltip("限制类型")]
        public ObjLimitType limitType;

        /// <summary>
        /// 限制值
        /// </summary>
        [Tooltip("限制值")]
        public int limitValue;

        /// <summary>
        /// 限制职业
        /// </summary>
        [Tooltip("限制职业")]
        public HeroVocation vocation;

        /// <summary>
        /// Buff类型
        /// </summary>
        [Tooltip("Buff类型")]
        public ObjBuffType buffType;

        /// <summary>
        /// 即时效果类型——消耗品
        /// </summary>
        [Tooltip("即时效果类型——消耗品")]
        public SkillTailType tailType;
       
        /// <summary>
        /// 值类型
        /// </summary>
        [Tooltip("值类型")]
        public ValueType valueType;

        /// <summary>
        /// 作用值
        /// </summary>
        [Tooltip("作用值")]
        public int value;
    }
    /// <summary>
    /// 宝物数据
    /// </summary>
    [Serializable]
    public class TreasureData : ObjData
    {
        /// <summary>
        /// 所属地图区域
        /// </summary>
        [Tooltip("所属地图区域")]
        public MapNameType ownerMapArea;

       new public TreasureData Clone()
        {
            TreasureData that = new TreasureData();
			that.id = id;
			that.name = name;
			that.describe = describe;
			that.describe_EN = describe_EN;
			that.Icon = Icon;
			that.IconBg = IconBg;
			that.objType = objType;
			that.heroVocation = heroVocation;
			that.levelType = levelType;
			that.ownerType = ownerType;
			that.buy = buy;
			that.sell = sell;
			that.settlement = settlement;
			that.maxCount = maxCount;
			that.objActions = objActions;
			that.specialEffect = specialEffect;
			that.Count = Count;
			that.ownerMapArea = ownerMapArea;
            return that;// MemberwiseClone() as ObjData;
        }
    }
    [CreateAssetMenu(menuName = "NewData/ObjSet")]
    [Serializable]
    /// <summary>
    /// 物品类数据集
    /// </summary>
    public class ObjDataSet : ScriptableObject
    {

        public string TipsA = "若想增加数据,在大小中输入一个比当前值更大的值,如5→6";
        public string TipsB = "！！！若在大小中输入了更小的值,可能会造成数据丢失";
        public string TipsC = "！！！鼠标放在字段上有提示";
        /// <summary>
        /// 道具基础数据
        /// </summary>
        [Header("道具基础数据")]
        [SerializeField] public List<ObjData> porpDatas = new List<ObjData>();
        /// <summary>
        /// 饰品基础数据
        /// </summary>
        [Header("饰品基础数据")]
        [SerializeField] public List<ObjData> ornamentsDatas = new List<ObjData>();

        /// <summary>
        /// 宝物基础数据（单指地图掉落的宝物数据）
        /// </summary>
        [Header("宝物基础数据")]
        [SerializeField] public List<TreasureData> treasuresDatas = new List<TreasureData>();

        //[Header("圣物基础数据")]

        //给Objlife起一个专用于饰品的隐藏属性参与计算,用于对饰品的特殊属性加成，如伤害增幅,治疗增幅等
        //饰品对技能的特殊加成  做在技能释放前的判断中去
        //饰品对技能的特殊减益  做到哪?
        //饰品上像状态一样的效果如何处理？   如当血量低于44%时伤害增加
    }
}

