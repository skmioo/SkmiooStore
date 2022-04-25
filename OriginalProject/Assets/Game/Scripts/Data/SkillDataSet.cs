
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Datas
{
    [Serializable]
    /// <summary>
    /// 技能基础源数据
    /// </summary>
    public class SkillData : DataBase
    {
      
        /// <summary>
        /// 使用者特效
        /// </summary>
          [Header("释放姿势，必填")]public AssetReferenceSprite useRoleSprite;

      
        /// <summary>
        /// 使用者特效
        /// </summary>
        [Header("使用者特效")]  public AssetReferenceSprite useEffectSprite;


        /// <summary>
        /// 使用者spin动画特效
        /// </summary>
        [Header("使用者特效")]  public AssetReferenceGameObject useEffectSpine;

   
        /// <summary>
        /// 被击者特效
        /// </summary>
          [Header("被击者特效")]   public AssetReferenceSprite targetEffectSprite;

      
        /// <summary>
        /// 被击者spin动画特效
        /// </summary>
        [Header("被击者spin动画特效")]  public AssetReferenceGameObject targetEffectSpine;

        
        /// <summary>
        /// 技能图标
        /// </summary>
       [Header("技能图标")] public AssetReferenceSprite icon;


        /// <summary>
        /// 技能注语
        /// </summary>
        [Header("技能注语")]  public string tips;

      
        /// <summary>
        /// 技能类型
        /// </summary>
         [Header("技能类型")] public SkillType skillType;


        /// <summary>
        /// 目标类型
        /// </summary>
        [Header("目标类型")] public SkillTargetType targetType;


        /// <summary>
        /// 目标随机个数
        /// </summary>
        [Header("目标随机个数,0=不随机(当前只针对-敌方群体-有效)")] public int targetRandomNum;


        /// <summary>
        /// 技能有效位置
        /// </summary>
        [Header("技能有效位置")] public SkillPosition position;


        /// <summary>
        /// 精准修正
        /// </summary>
        [Header("精准修正")] public IntLevel rate;


        /// <summary>
        /// 暴击修正
        /// </summary>
        [Header("暴击修正")] public IntLevel crits;

        /// <summary>
        /// 暴击伤害修正
        /// </summary>
        [Header("暴击伤害修正")] public IntLevel critsDamage;

        /// <summary>
        /// 伤害修正
        /// </summary>
        [Header("伤害修正")] public IntLevel atk;

        /// <summary>
        /// 释放技能后,即时判定的效果
        /// </summary>
        [Header("释放技能后,即时判定的效果")]
        public List<TailValue> skillTails;

        /// <summary>
        /// Buff效果
        /// </summary>
        [Header("Buff效果")]
        public List<SkillBuff> skillBuffs;

        /// <summary>
        /// 使用限制
        /// </summary>
        [Header("使用限制")]
        public List<Limit> useLimits;

        /// <summary>
        /// 目标限制
        /// </summary>
        [Header("目标限制")]
        public List<Limit> targetLimits;

        /// <summary>
        /// 额外伤害
        /// </summary>
        [Header("额外效果")]
        public List<ExtraDamage> additionalDamage;

        /// <summary>
        /// 击杀可再次行动
        /// </summary>
        [Header("击杀可再次行动")]
        public bool killToActAgain;

        /// <summary>
        /// 召唤
        /// </summary>
        [Header("召唤")]
        public List<SkillSummon> summon;

        /// <summary>
        /// 技能cd
        /// </summary>
        [Header("cd")]
        public int cd;

        [Header("摄像机移动数据")]
        public List <CameraMoveData> cameraMoveData;

        /// <summary>
        /// 浅拷贝
        /// </summary>
        /// <returns></returns>
        public SkillData Clone()
        {
            SkillData that = new SkillData();
			that.id = id;
			that.name = name;
			that.describe = describe;
			that.describe_EN = describe_EN;
			that.useRoleSprite = useRoleSprite;
            that.useEffectSprite = useEffectSprite;
            that.useEffectSpine = useEffectSpine;
            that.targetEffectSprite = targetEffectSprite;
            that.targetEffectSpine = targetEffectSpine;
            that.icon = icon;
            that.tips = tips;
            that.skillType = skillType;
            that.targetType = targetType;
			that.targetRandomNum = targetRandomNum;
			that.position = position.Clone();
            that.rate = rate.Clone();
            that.crits = crits.Clone();
			that.critsDamage = critsDamage.Clone();
			that.atk = atk.Clone();
			that.skillTails = new List<TailValue>();
            for (int i = 0; i < skillTails.Count; ++i) that.skillTails.Add(skillTails[i].Clone());
            that.skillBuffs =  new List<SkillBuff>();
            for (int i = 0; i < skillBuffs.Count; ++i) that.skillBuffs.Add(skillBuffs[i].Clone());
            that.useLimits = new List<Limit>();
            for (int i = 0; i < useLimits.Count; ++i) that.useLimits.Add(useLimits[i].Clone()); ;
            that.targetLimits = new List<Limit>();
            for (int i = 0; i < targetLimits.Count; ++i) that.targetLimits.Add(targetLimits[i].Clone()); 

            that.additionalDamage = new List<ExtraDamage>();
            for (int i = 0; i < additionalDamage.Count; ++i) that.additionalDamage.Add(additionalDamage[i].Clone()); 
            

            that.killToActAgain = killToActAgain;
            that.summon = new List<SkillSummon>();
            for (int i = 0; i < summon.Count; ++i) that.summon.Add(summon[i].Clone()); 
            that.cd = cd;
			that.cameraMoveData = new List<CameraMoveData>();
			for (int i = 0; i < cameraMoveData.Count; ++i) that.cameraMoveData.Add(cameraMoveData[i].Clone());

            return that;// MemberwiseClone() as SkillData;
        }
        /// <summary>
        /// 当前技能是否是士气技能
        /// </summary>
        public bool IsMoralSkill {
            get {
                return id > 9000;
            }
        }
        public bool IsHaveTips
        {
            get {
                return tips != string.Empty;
            }
        }
    }


    public enum CameraMoveType
    {
        旋转, 缩放, 震动, 等待, FOV
    }

    [System.Serializable]
    public class CameraMoveData
    {
        [Header("是否同时进行")] public bool sameTime = true;
        [Header("摄像机移动类型")] public CameraMoveType moveType;
        [Header("[旋转] 填写那个周选组含多少度")] public Vector3 rotationValue;
        [Header("[缩放] 缩放值(2D相机Size)")] public float scaleValue;
        [Header("[FOV] 设置3D 相机的FOV")] public float fovValue;

        /// <summary>
        /// 振动方向与强度
        /// </summary>
        [Header("[震动] 沿着哪个方向震动")] public Vector3 shakeValue;
        /// <summary>
        /// 震动次数
        /// </summary>
        [Header("[震动] 震动次数")] public int shakeVabrato = 10;
        /// <summary>
        /// 改变震动方向的随机值（大小：0~180）
        /// </summary>
        [HideInInspector] public float radomness = 90;
        /// <summary>
        /// 振幅
        /// </summary>
        [HideInInspector] public bool snapping = false;
        /// <summary>
        /// 震动淡入淡出
        /// </summary>
        [Header("[震动] 是否淡入淡出")] public bool fadeout = true;

        [Header("调整移动曲线")] public AnimationCurve curve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

        [Header("持续时间")] public float time;

        public CameraMoveData Clone()
        {
            CameraMoveData nCmd = new CameraMoveData() {
                sameTime = this.sameTime,
                moveType = this.moveType,
                rotationValue = this.rotationValue,
                scaleValue = this.scaleValue,
                fovValue = this.fovValue,
                shakeValue = this.shakeValue,
                shakeVabrato = this.shakeVabrato,
                radomness = this.radomness,
                snapping = this.snapping,
                fadeout = this.fadeout,
                curve = this.curve,
                time = this.time
            };

            return nCmd;
        }
    }

    /// <summary>
    /// 额外伤害
    /// </summary>
    [Serializable]
    public class ExtraDamage
    {
        public string name;

        /// <summary>
        /// 条件
        /// </summary>
        [Header("条件")]
        public Limit limit;

        public enum Keys
        {
            精准修正,
            暴击修正,
            暴击伤害修正,
            伤害修正,
            最终伤害率修正,
            最终伤害增加,
            自身士气,
            所有友方士气,
            增加Buff种类,
            生命最大值计算伤害,
            损失生命计算伤害,
            必定暴击,
            移除标记,

        }

        [Serializable]
        public class Data
        {
            public string name;
            public Keys key;
            public IntLevel value;
            public SkillBuff buff;
			public Data Clone()
			{
				Data that = new Data();
				that.name = name;
				that.key = key;
				that.value = value.Clone();
				that.buff = buff.Clone();
				return that;
			}
		}

        public List<Data> kv = new List<Data>();
        
        public ExtraDamage Clone()
        {
            ExtraDamage that = new ExtraDamage();
            that.limit = limit.Clone();
            that.kv = new List<Data>(kv);
            return that;
        }
    }

    [Serializable]
    /// <summary>
    /// 限制
    /// </summary>
    public class Limit
    {
        /// <summary>
        /// 限制目标群体
        /// </summary>
        [Header("限制目标群体")]
        public LimitTarget target;

        /// <summary>
        /// 限制类型
        /// </summary>
        [Header("限制类型")]
        public LimitType limitType;

        /// <summary>
        /// 限制buff类型，具有buff型限制使用
        /// </summary>
        [Header("限制buff类型，具有buff型限制使用")]
        public ObjBuffType buffType;

        /// <summary>
        /// 限制条件，对象属性型限制使用
        /// </summary>
        [Header("限制条件，对象属性型限制使用")]
        public LimitCondition limitCondition;

        /// <summary>
        /// 限制值，对象属性型限制使用
        /// </summary>
        [Header("限制值，对象属性型限制使用")]
        public int limitValue;

        /// <summary>
        /// 限制对象类型使用
        /// </summary>
        [Header("限制对象类型使用")]
        public UnitType limitUnitType;

        /// <summary>
        /// 限制对象形态使用
        /// </summary>
        [Header("限制对象类型使用")]
        public LimitTargetStatus limitTargetStatus;

        /// <summary>
        /// 值类型，对象属性型限制使用
        /// </summary>
        [Header("值类型，对象属性型限制使用")]
        public ValueType valueType;

        /// <summary>
        /// 命中率
        /// </summary>
        [Header("命中率")]
        public IntLevel rate;
        public Limit Clone()
        {
            Limit that = new Limit();
            that.target = target;
            that.limitType = limitType;
            that.buffType = buffType;
            that.limitCondition = limitCondition;
            that.limitValue = limitValue;
            that.valueType = valueType;
            that.rate = rate.Clone();
            that.limitUnitType = limitUnitType;
            that.limitTargetStatus = limitTargetStatus;
            return that;
        }
    }

    [Serializable]
    /// <summary>
    /// 召唤
    /// </summary>
    public class SkillSummon
    {
        /// <summary>
        /// 召唤类型
        /// </summary>
        [Header("召唤类型")]
        public ObjBuffType summonType;

        /// <summary>
        /// 延迟召唤的回合
        /// </summary>
        [Header("延迟召唤的回合")]
        public int value;

        /// <summary>
        /// 召唤的目标
        /// </summary>
        [Header("召唤的目标")]
        public int target;
        public SkillSummon Clone()
        {
            SkillSummon that = new SkillSummon();
            that.summonType = summonType;
            that.value = value;
            that.target = target;
            return that;
        }
    }



    /// <summary>
    /// 士气/伤势技能数据
    /// </summary>
    [Serializable]
    public class OtherSkillData : SkillData
    {
        /// <summary>
        /// 词条数上限
        /// </summary>
        [Header("词条数上限")]
        public int maxEntryCount;

        /// <summary>
        /// 当前持有的词条id表（初始为空）
        /// </summary>
        [Header("词条id")]
        private List<int> entryIds = new List<int>();

        /// <summary>
        /// 可用词条id
        /// </summary>
        [Header("可用词条id")]
        public List<int> canUseEntryIds = new List<int>();

        /// <summary>
        /// 获取士气技能详情
        /// </summary>
        /// <returns></returns>
        public string GetInfo()
        {
            return describe;
        }

        /// <summary>
        /// 词条是否达到上限
        /// </summary>
        /// <returns></returns>
        public bool IsEntryReachLimit()
        {
            if (maxEntryCount == 0) { return true; }
            if (entryIds == null) { return false; }
            return entryIds.Count >= maxEntryCount;
        }

        /// <summary>
        /// 添加或更改一个词条（士气技能异化）
        /// </summary>
        public void AddOrUpdateOneEntry()
        {
            bool isMaxed = IsEntryReachLimit();
            if (isMaxed)
            {
                int index = UnityEngine.Random.Range(0, entryIds.Count);
                entryIds[index] = RandomEntry();
            }
            else
            {
                //ps:没有考虑当词条上限值大于1时的词条重复的情况
                entryIds.Add(RandomEntry());
            }
        }
        /// <summary>
        /// 从可用词条中随机
        /// </summary>
        /// <returns></returns>
        public int RandomEntry()
        {
            if (canUseEntryIds.Count <= 0) throw new Exception("可用词条列表为空了");
            int index = UnityEngine.Random.Range(0, canUseEntryIds.Count);
            return  canUseEntryIds[index];
        }
        /// <summary>
        /// 获取士气技能词条数据
        /// </summary>
        /// <returns></returns>
        public List<AlienatedEntryData> GetEntry()
        {
            List<AlienatedEntryData> stemp = DataManager.Instance.GetEntryDataById(entryIds.ToArray());
            return stemp;
        }

        /// <summary>
        /// 获取士气技能词条描述
        /// </summary>
        /// <returns></returns>
        public string GetEntryDescribe()
        {
            string describe = null;

            List<AlienatedEntryData> stemp = GetEntry();
            for (int i = 0; i < stemp.Count; i++)
            {
                describe += '\n' + stemp[i].describe;
            }

            return describe;
        }
        /// <summary>
        /// 获取士气技能词条
        /// </summary>
        /// <returns></returns>
        [Obsolete]
        public string EntryToString()
        {
            return "";
        }
    }
    /// <summary>
    /// 异化词条数据
    /// </summary>
    [Serializable]
    public class AlienatedEntryData: DataBase
    {
        /// <summary>
        /// 释放技能后,即时判定的效果
        /// </summary>
        [Header("释放技能后,即时判定的效果")]
        public List<TailValue> skillTails;

        /// <summary>
        /// Buff效果
        /// </summary>
        [Header("Buff效果")]
        public List<SkillBuff> skillBuffs;

        /// <summary>
        /// 使用限制
        /// </summary>
        [Header("使用限制")]
        public List<Limit> useLimits;

        /// <summary>
        /// 目标限制
        /// </summary>
        [Header("目标限制")]
        public List<Limit> targetLimits;

        /// <summary>
        /// 额外伤害
        /// </summary>
        [Header("额外伤害")]
        public List<Limit> additionalDamage;

        /// <summary>
        /// 击杀可再次行动
        /// </summary>
        [Header("击杀可再次行动")]
        public bool killToActAgain;
        
    }
    /// <summary>
    /// 技能基础数据集合
    /// </summary>
    [CreateAssetMenu(menuName = "NewData/Battle/SkillData")]
    [Serializable]
    public class SkillDataSet : ScriptableObject
    {
        public string TipsA = "若想增加技能,在大小中输入一个比当前值更大的值,如5→6";
        public string TipsB = "！！！若在大小中输入了更小的值,可能会造成数据丢失";
        public string TipsC = "！！！鼠标放在字段上有提示";

        [Header("英雄技能数据")]
        [SerializeField] public List<SkillData> heroSkills = new List<SkillData>();

        [Header("怪物技能数据")]
        [SerializeField] public List<SkillData> enemySkills = new List<SkillData>();

        [Header("士气/伤势技能数据")]
        [SerializeField] public List<OtherSkillData> otherSkills = new List<OtherSkillData>();

        [Header("士气技能异化词条表")]
        [SerializeField]
        public List<AlienatedEntryData> entryDatas = new List<AlienatedEntryData>();
    }

    [Serializable]
    public class FloatLevel
    {
        /// <summary>
        /// 等级1
        /// </summary>
        [Range(-1,1)]
        [Header("等级1")]
        public float level1 =0;

        /// <summary>
        /// 等级2
        /// </summary>
        [Range(-1, 1)]
        [Header("等级2")]
        public float level2;

        /// <summary>
        /// 等级3
        /// </summary>
        [Range(-1, 1)]
        [Header("等级3")]
        public float level3;

        /// <summary>
        /// 等级4
        /// </summary>
        [Range(-1, 1)]
        [Header("等级4")]
        public float level4;

        /// <summary>
        /// 等级5
        /// </summary>
        [Range(-1, 1)]
        [Header("等级5")]
        public float level5;
    }

    [Serializable]
    public class IntLevel
    {
        /// <summary>
        /// 等级1
        /// </summary>       
        [Header("等级1")]
        public int level1;

        /// <summary>
        /// 等级2
        /// </summary>
        [Header("等级2")]
        public int level2;

        /// <summary>
        /// 等级3
        /// </summary>
        [Header("等级3")]
        public int level3;

        /// <summary>
        /// 等级4
        /// </summary>
        [Header("等级4")]
        public int level4;

        /// <summary>
        /// 等级5
        /// </summary>
        [Header("等级5")]
        public int level5;
        public IntLevel Clone()
        {
            IntLevel that = new IntLevel();
            that.level1 = level1 ;
            that.level2 = level2 ;
            that.level3 = level3 ;
            that.level4 = level4 ;
            that.level5 = level5;
            return that;
        }
        public IntLevel() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str">"[lv1|lv2|lv3|lv4|lv5]"</param>
        public IntLevel(string str, params char[] separator) {
            if (!str.StartsWith("[") || !str.EndsWith("]")) new Exception($"{str} is Error 参数错误");
            //Debug.Log(str);
            str = str.TrimStart('[');
            str = str.TrimEnd(']');
            string[] stringArrayTemp = str.Split(separator);
            level1 = Convert.ToInt32(stringArrayTemp[0]);
            level2 = Convert.ToInt32(stringArrayTemp[1]);
            level3 = Convert.ToInt32(stringArrayTemp[2]);
            level4 = Convert.ToInt32(stringArrayTemp[3]);
            level5 = Convert.ToInt32(stringArrayTemp[4]);
        }

        public static IntLevel operator+ (IntLevel a, IntLevel b)
        {
            IntLevel intlevel = new IntLevel();
            intlevel.level1 = a.level1 + b.level1;
            intlevel.level2 = a.level2 + b.level2;
            intlevel.level3 = a.level3 + b.level3;
            intlevel.level4 = a.level4 + b.level4;
            intlevel.level5 = a.level5 + b.level5;
            return intlevel;
        }
        public static IntLevel operator -(IntLevel a, IntLevel b)
        {
            IntLevel intlevel = new IntLevel();
            intlevel.level1 = a.level1 - b.level1;
            intlevel.level2 = a.level2 - b.level2;
            intlevel.level3 = a.level3 - b.level3;
            intlevel.level4 = a.level4 - b.level4;
            intlevel.level5 = a.level5 - b.level5;
            return intlevel;
        }
    }

    /// <summary>
    /// 技能有效位置（对应配置表中的位置条件）
    /// </summary>
    [Serializable]
    public class SkillPosition
    {
        [Header("技能施放位置")]
        public bool D;
        public bool C, B, A;

        [Header("可选目标位置")]
        public bool W;
        public bool X, Y, Z;
        public SkillPosition Clone() {
           SkillPosition that = new SkillPosition();
           that.D = D;
           that.C = C;
           that.B = B;
           that.A = A;
           that.W = W;
           that.X = X;
           that.Y = Y;
           that.Z = Z;
           return that;
    }
    }

    /// <summary>
    /// 即时判定效果
    /// </summary>
    [Serializable]
    public class TailValue
    {
        /// <summary>
        /// 作用对象
        /// </summary>
        [Header("作用对象")]
        public SkillBuffTarget buffTarget;

        /// <summary>
        /// 效果类型
        /// </summary>
        [Header("效果类型")]
        public SkillTailType tailType;

        /// <summary>
        /// buff类型
        /// </summary>
        [Header("buff类型")]
        public ObjBuffType buffType;

        /// <summary>
        /// 值类型
        /// </summary>
        [Header("值类型")]
        public ValueType valueType;

        /// <summary>
        /// 值上限
        /// </summary>
        [Header("作用值上限")]
        public IntLevel maxValue;

        /// <summary>
        /// 值下限
        /// </summary>
        [Header("作用值下限")]
        public IntLevel minValue;

        /// <summary>
        /// 命中率
        /// </summary>
        [Header("命中率")]
        public IntLevel rate;

        public TailValue Clone()
        {
            TailValue that = new TailValue();
            that.buffTarget = buffTarget;
            that.tailType = tailType;
            that.buffType = buffType;
            that.valueType = valueType;
            that.maxValue = maxValue.Clone();
            that.minValue = minValue.Clone();
			if (rate != null)
			{
				that.rate = rate.Clone();
			}
			else
			{
				that.rate = null;
			}
            return that;
        }
       
    }

    /// <summary>
    /// 状态/异常状态
    /// </summary>
    [Serializable]
    public class SkillBuff 
    {
        [Header("Buff的目标类型")]
        /// <summary>
        /// Buff的目标类型
        /// </summary>
        public SkillBuffTarget buffTarget;

        /// <summary>
        /// 作用值类型
        /// </summary>
        [Header("状态类型/作用值类型")]
        public ObjBuffType buffType;

        /// <summary>
        /// 作用值作用方式
        /// </summary>
        [Header("作用值作用方式")]
        public ValueType valueType;

        /// <summary>
        /// 作用值
        /// </summary>
        [Header("作用值")]
        public IntLevel value;

        /// <summary>
        /// 作用回合数
        /// </summary>
        [Header("Buff作用回合数")]
        public int effectiveRounds;

        /// <summary>
        /// 作用回合数2
        /// </summary>
        [Header("Buff作用回合数2，用于随机")]
        public int effectiveRounds2;

        /// <summary>
        /// 作用回合数随机
        /// </summary>
        [Header("Buff作用回合数随机,左右包含")]
        public bool randomRounds = false;

        /// <summary>
        /// 命中概率
        /// </summary>
        [Header("Buff的命中概率,与目标抵抗率计算")]
        public IntLevel rate;

        /// <summary>
        /// 特殊buff类型，用于附加不同的buff脚本
        /// </summary>
        [Header("特殊buff类型，用于附加不同的buff脚本")]
        public SpecialBuffType specialType;
        public SkillBuff Clone()
        {
            SkillBuff that = new SkillBuff();
            that.buffTarget = buffTarget;
            that.buffType = buffType;
            that.valueType = valueType;
            that.value = value.Clone();
            that.effectiveRounds = effectiveRounds;
            that.effectiveRounds2 = effectiveRounds2;
            that.randomRounds = randomRounds;
            that.rate = rate.Clone();
            that.specialType = specialType;
            return that;
        }

        /// <summary>
        /// 作用回合数,randomRounds = true?随机:effectiveRounds
        /// </summary>
        /// <returns>作用回合数,每次调用都会随机</returns>
        public int EffectiveRoundsOrRandom()
        {
            if (randomRounds)
            {
                return UnityEngine.Random.Range(effectiveRounds, effectiveRounds2 + 1);
            }
            return effectiveRounds;
        }

    }
}

