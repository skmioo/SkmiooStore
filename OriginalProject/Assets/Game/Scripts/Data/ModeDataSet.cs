using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


namespace Datas
{
    [Serializable]
    public class ModeData : DataBase
    {
        public List<HeroMode> herosModes;

        public List<HeroMode> deadHeros;
        /// <summary>
        /// 战斗背包物品数据
        /// </summary>
        public List<KanpsackMode> kanpsackModes;

        /// <summary>
        /// 饰品背包数据
        /// </summary>
        public List<KanpsackMode> ornamentsModes;
        /// <summary>
        /// 勋章存档
        /// </summary>
        public List<MedalMode> medalModes;
        /// <summary>
        /// 圣物
        /// </summary>
        public List<SacredMode> sacredModes;
        /// <summary>
        /// 交互物存档 （只用与临时存档 副本结束时请自行清空）
        /// </summary>      
        public List<ScriptureMode> scriptureModes;
        public List<MeditationPlatformMode> meditationPlatformModes;
        public List<AltarMode> altarModeModes;
        public List<RescueMode> rescueModes;
        public List<UndergroundShopMode> undergroundShopModes;
        /// <summary>
        /// 背包中勋章，值为勋章存档列表中的序号
        /// </summary>
        public List<int> packMedals;
        //资源
        public KanpsackMode moneyMode, crystalMode, fruitMode, lightStoneMode, starFireMode, boneMode;
        /// <summary>
        /// 出征带入副本的鳞片数量 ----- 数据冗余将被舍去
        /// </summary>
        public KanpsackMode carryBattleMoneyMode;
        //建筑
        public BuildingMode skillUpBuildingMode;
        public HealBuildingMode healBuildingMode;
        public ShopBuildingMode shopBuildingMode;
        public RecruitBuildingMode recruitBuildingMode;
        public MoraleBuildingMode moraleBuildingMode;
        /// <summary>
        /// 关卡存档
        /// </summary>
        public List<InstanceZoneModeSet> instanceZoneMode;

        [System.Obsolete]public ModeData Clone()
        {
            ModeData that = new ModeData();
            //that.herosModes = new List<HeroMode>();
            //for (int i = 0; i < herosModes.Count; ++i) that.herosModes.Add(herosModes[i].Clone());

            //that.deadHeros = new List<HeroMode>();
            //for (int i = 0; i < deadHeros.Count; ++i) that.deadHeros.Add(deadHeros[i].Clone());
            //that.kanpsackModes = new List<KanpsackMode>();
            //for (int i = 0; i < kanpsackModes.Count; ++i) that.kanpsackModes.Add(kanpsackModes[i].Clone());



            //that.ornamentsModes = new List<KanpsackMode>();
            //for (int i = 0; i < ornamentsModes.Count; ++i) that.ornamentsModes.Add(ornamentsModes[i].Clone());
            //that.medalModes = new List<MedalMode>();
            //for (int i = 0; i < medalModes.Count; ++i) that.medalModes.Add(medalModes[i].Clone());
            //that.sacredModes = new List<SacredMode>();
            //for (int i = 0; i < sacredModes.Count; ++i) that.sacredModes.Add(sacredModes[i].Clone());



            return that;//this.MemberwiseClone() as ModeData;
        }

        /// <summary>
        /// 序列化深拷贝
        /// </summary>
        /// <param name="RealObject"></param>
        /// <returns></returns>
        public ModeData Clone(ModeData RealObject)
        {
            using (Stream objectStream = new MemoryStream())
            {
                //利用 System.Runtime.Serialization序列化与反序列化完成引用对象的复制  
                IFormatter formatter = new BinaryFormatter();

                formatter.Serialize(objectStream, RealObject);

                objectStream.Seek(0, SeekOrigin.Begin);

                return (ModeData)formatter.Deserialize(objectStream);
            }
        }
    }
    #region 交互物相关
    [Serializable]
    public class InteractiveMode
    {
        public InteractiveType interactiveType;
        public MapType mapType;
        public int roomIndex;
        public int routeGroupIndex;
        public int routeIndex;
        /// <summary>
        /// 是否可以继续交互（此处用于判断 如：冥想台只能异化一个技能就不能继续异化了。）
        /// </summary>
        public bool isInteractived;
        /// <summary>
        /// 已交互次数
        /// </summary>
        [Tooltip("已交互次数")] public int interactiveCount;
        public InteractiveMode() { }
        public InteractiveMode(InteractiveType _type, MapType _mapType, int _roomIndex, int _routeGroupIndex, int _routeIndex) {
            interactiveType = _type;
            mapType = _mapType;
            roomIndex = _roomIndex;
            routeGroupIndex = _routeGroupIndex;
            routeIndex = _routeIndex;
            isInteractived = true;
        }
    }

    [Serializable]
    public class ScriptureMode: InteractiveMode
    {
        public ScriptureMode(){ }
        /// <summary>
        /// 经文ID
        /// </summary>
        public int ScriptureId;
        public ScriptureMode(InteractiveType _type, MapType _mapType, int _roomIndex, int _routeGroupIndex, int _routeIndex) :base(_type,  _mapType,  _roomIndex,  _routeGroupIndex,  _routeIndex) {

        }
    }
    [Serializable]
    public class MeditationPlatformMode : InteractiveMode
    {
        public MeditationPlatformMode() { }
        public MeditationPlatformMode(InteractiveType _type, MapType _mapType, int _roomIndex, int _routeGroupIndex, int _routeIndex) : base(_type, _mapType, _roomIndex, _routeGroupIndex, _routeIndex)
        {

        }
    }
    [Serializable]
    public class AltarMode : InteractiveMode
    {
        public AltarType altarType;
        public int altarId;
        //public int sacrificeCout;
        public AltarMode() { }
        public AltarMode(InteractiveType _type, MapType _mapType, int _roomIndex, int _routeGroupIndex, int _routeIndex) : base(_type, _mapType, _roomIndex, _routeGroupIndex, _routeIndex)
        {

        }
    }

    [Serializable]
    public class RescueMode : InteractiveMode
    {
       public RescueType rescueType;
        /// <summary>
        /// 囚徒id
        /// </summary>
        public int rescueId;
        public RescueMode() { }
        public RescueMode(InteractiveType _type, MapType _mapType, int _roomIndex, int _routeGroupIndex, int _routeIndex) : base(_type, _mapType, _roomIndex, _routeGroupIndex, _routeIndex)
        {

        }

    }
    [Serializable]
    public class UndergroundShopMode : InteractiveMode
    {
        /// <summary>
        /// 商品列表
        /// </summary>
        public List<UndergroundShopItemData> shopItemDatas;
        public Dictionary<int, ObjData> shopItemObjDataDic;
        public UndergroundShopMode() { }
        public UndergroundShopMode(InteractiveType _type, MapType _mapType, int _roomIndex, int _routeGroupIndex, int _routeIndex) : base(_type, _mapType, _roomIndex, _routeGroupIndex, _routeIndex)
        {

        }
    }
    [Serializable]
    public class UndergroundShopItemData {
        /// <summary>
        /// 商品ID
        /// </summary>
       public int shopItemId;
        /// <summary>
        /// 商品数量
        /// </summary>
        public int count; 

        public UndergroundShopItemData(int _id,int _count)
        {
            shopItemId = _id;
            count = _count;
        }
    }
    #endregion
    [Serializable]
    /// <summary>
    /// 已经招募的英雄存档数据
    /// </summary>
    public class HeroMode
    {
        /// <summary>
        /// 角色名字
        /// </summary>
        public string heroName;

        /// <summary>
        /// 准备出征的状态，true = 出征
        /// </summary>
        public bool readyStart;

        /// <summary>
        /// 如果在出征状态,那么他在出征队伍的第几位
        /// </summary>
        public int numInTeam_Waiting;

        /// <summary>
        /// 是否正在治疗
        /// </summary>
        public bool isHealing;
        public int healBoxIndex;

        /// <summary>
        /// 英雄ID
        /// </summary>
        public int heroId;


        /// <summary>
        ///士气
        /// </summary>
        public int nowMorale;


        /// <summary>
        /// 当前伤势
        /// </summary>
        public int injuries;

        /// <summary>
        /// 技能列表
        /// </summary>
        public List<SkillMode> skillModes;

        /// <summary>
        /// 士气技能
        /// </summary>
        public int moraleSkillId;

        /// <summary>
        /// 装备的勋章
        /// </summary>
        public MedalMode medal;

        /// <summary>
        /// 饰品格1装备的饰品
        /// </summary>
        public int ornaments1ID;

        /// <summary>
        /// 饰品格2装备的饰品
        /// </summary>
        public int ornaments2ID;

        /// <summary>
        /// 角色天赋
        /// </summary>
        public TalentMode talent;

        public HeroMode Clone()
        {
            HeroMode result = new HeroMode();// MemberwiseClone() as HeroMode;

            result.heroName = heroName;
            result.readyStart = readyStart;
            result.numInTeam_Waiting = numInTeam_Waiting;
            result.isHealing = isHealing;
            result.healBoxIndex = healBoxIndex;
            result.heroId = heroId;
            result.nowMorale = nowMorale;
            result.injuries = injuries;
            result.skillModes = new List<SkillMode>();
            foreach (var item in skillModes)
            {
                result.skillModes.Add(item.Clone());
            }
            result.moraleSkillId = moraleSkillId;
            result.medal = medal;
            result.ornaments1ID = ornaments1ID;
            result.ornaments2ID = ornaments2ID;
            if (talent != null) { result.talent = talent.Clone(); }

            return result;
        }
    }

    /// <summary>
    /// 天赋存档
    /// </summary>
    [Serializable]
    public class TalentMode
    {
        /// <summary>
        /// 类别id
        /// </summary>
        public int typeId;

        /// <summary>
        /// 触发条件id
        /// </summary>
        public int triggerId;

        /// <summary>
        /// 秩序效果id
        /// </summary>
        public int orderId;

        /// <summary>
        /// 昏乱效果id
        /// </summary>
        public int chaosId;

        public TalentMode Clone()
        {
            TalentMode that = new TalentMode();
            that.typeId = typeId;
            that.triggerId = triggerId;
            that.orderId = orderId;
            that.chaosId = chaosId;
            return that;//MemberwiseClone() as TalentMode;
        }
    }

    /// <summary>
    /// 单个技能存档
    /// </summary>
    [Serializable]    
    public class SkillMode
    {
        /// <summary>
        /// 技能ID
        /// </summary>
        public int skillId;

        /// <summary>
        /// 当前等级,等级默认0,大于0 = 已学习/已获得技能
        /// </summary>
        public int level;

        /// <summary>
        /// 是否被选择使用/带入出征后,战斗场景中使用
        /// </summary>
        public bool isUse;

        /// <summary>
        /// 战斗中cd
        /// </summary>
        public int cd;

        public SkillMode Clone()
        {
            SkillMode that = new SkillMode();
            that.skillId = skillId;
            that.level = level;
            that.isUse = isUse;
            that.cd = cd;
            return that;//MemberwiseClone() as SkillMode;
        }
    }

    /// <summary>
    /// 背包类存档
    /// </summary>
    [Serializable]   
    public class KanpsackMode
    {
        /// <summary>
        /// 物品ID
        /// </summary>
        public int objId;
        /// <summary>
        /// 数量
        /// </summary>
        public int count;
        public KanpsackMode Clone()
        {
            KanpsackMode that = new KanpsackMode();
            that.objId = objId; that.count = count;
            return that;
        }
    }
    /// <summary>
    /// 勋章存档
    /// </summary>
    [Serializable] 
    public class MedalMode:KanpsackMode
    {
        public List<int> attributeRoll;
        public List<int> entryRoll;
    }
    /// <summary>
    /// 圣物存档
    /// </summary>
    [Serializable]
    public class SacredMode
    {
        /// <summary>
        /// 圣物id
        /// </summary>
        public int id;
        /// <summary>
        /// 圣物是否被摆放
        /// </summary>
        public bool isBePut;
        /// <summary>
        /// 圣物在当前集合中的序号
        /// </summary>
        public int num;
    }
   
    /// <summary>
    /// 建筑存档
    /// </summary>
    [Serializable]
    public class BuildingMode
    {
        public BuildingMode()
        {
            equipLvs = new List<int>(new int[2]);
        }
        /// <summary>
        /// 建筑升级设施等级
        /// </summary>
        public List<int> equipLvs;
    }
    //饰品商店存档
    [Serializable]
    public class ShopBuildingMode:BuildingMode
    {
        public ShopBuildingMode()
        {
            equipLvs=new List<int>(new int[2]);
        }
        public List<int> goods;
    }
    //复生池存档
    [Serializable]
    public class HealBuildingMode : BuildingMode
    {
        public HealBuildingMode()
        {
            equipLvs = new List<int>(new int[3]);
        }
    }
    //流放营地存档
    [Serializable]
    public class RecruitBuildingMode : BuildingMode
    {
        public RecruitBuildingMode()
        {
            equipLvs = new List<int>(new int[2]);
        }

        [Obsolete] public List<HeroMode> heroModes;
        public List<int> heroIds;
    }
    //起源神树存档
    [Serializable]
    public class MoraleBuildingMode : BuildingMode
    {
        public MoraleBuildingMode()
        {
            equipLvs = new List<int>(new int[3]);
        }
        public List<int> moraleSkillIDs;
    }

    /// <summary>
    /// 关卡存档
    /// </summary>
    [Serializable]
    public class InstanceZoneModeSet
    {
        public MapNameType mapName;
        public int warningValue;
        public bool bAtkBoss;
        public bool bKillBoss;
        /// <summary>
        /// 任务存档
        /// </summary>
        public List<InstanceZoneMode> zones;
        public void AddTaskDataToMode(InstanceZoneMode _mode)
        {
            if (zones == null) zones = new List<InstanceZoneMode>();
            zones.Add(_mode);
        }
    }

    /// <summary>
    /// 单个任务存档
    /// </summary>
    [Serializable]
    public class InstanceZoneMode
    {
        public N_TaskType taskType;
        public int taskId;
        public MapSizeType mapSize;
        public TaskDifficulty taskDifficulty;
    }
    
    /// <summary>
    /// 存档数据
    /// </summary>
    [CreateAssetMenu(menuName = "NewData/ModeData")]
    [Serializable]
    public class ModeDataSet : ScriptableObject
    {
        public string str = "--可无损耗改JSON，此方式方便调试";

        [Header("存档数据")]
        [SerializeField] public List<ModeData> modeDatas = new List<ModeData>();

    }

}

