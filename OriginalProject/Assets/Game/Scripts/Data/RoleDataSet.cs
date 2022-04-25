
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Datas
{
    /// <summary>
    /// 角色数据，头像、模型、角色类型、技能列表、各项属性
    /// </summary>
    [Serializable]
    public class RoleData : DataBase
    {

        /// <summary>
        /// 角色头像
        /// </summary>
        [Header("角色头像")] public AssetReferenceSprite icon;


        /// <summary>
        /// 角色形象
        /// </summary>
        [Header("角色形象")] public AssetReferenceSprite image;

        /// <summary>
        /// 士气技能插画
        /// </summary>
        [Header("士气技能插画")] public AssetReferenceSprite MoraleSkillEffectSprite;
        /// <summary>
        /// 角色的类型、英雄、或敌人
        /// </summary>
        [Header("角色的类型")] public RoleType roleType;

		/// <summary>
		/// 角色的性别
		/// </summary>
		[Header("角色的性别")] public roleSex roleSex;

		/// <summary>
		/// 英雄职业，怪物不区分职业
		/// </summary>
		[Header("英雄职业")] public HeroVocation vocation;

        /// <summary>
        /// 单位类型
        /// </summary>
        [Header("单位类型")] public UnitType unitType;

        /// <summary>
        /// 角色所拥有的技能ID
        /// </summary>
        [Header("角色所拥有的技能ID,请根据SkillData数据文件填写对应的技能ID")] public List<int> roleHaveSkill;

       
        /// <summary>
        /// 角色的模型,也可以通过职业关联模型,暂保留此项,可以做不同模型,如同职业,男性女性
        /// </summary>
       [Header("角色的模型")]  public AssetReferenceGameObject roleMode;

      
        /// <summary>
        /// 角色体积
        /// </summary>
         [Header("角色体积")] public int size;

       
        /// <summary>
        /// 行动点
        /// </summary>
       [Header("行动点")]  public int actNum;

      
        /// <summary>
        /// 士气上限
        /// </summary>
        [Header("士气上限")]  public int maxMorale;

    
        /// <summary>
        /// 士气下限
        /// </summary>
           [Header("士气下限")] public int minMorale;

        /// <summary>
        /// 伤势上限
        /// </summary>
        [Header("伤势上限")]public int maxInjuries;

       
        /// <summary>
        /// 伤势下限
        /// </summary>
      [Header("伤势下限")]   public int minInjuries;

      
        /// <summary>
        /// 生命上限
        /// </summary>
         [Header("生命上限")] public int hp;

       
        /// <summary>
        /// 防御力,免伤,正值角色受到的伤害减少，负值角色受到的伤害增加
        /// </summary>
         [Header("减伤%")]public int defence;

       
        /// <summary>
        /// 最小攻击力
        /// </summary>
        [Header("最小攻击力")] public int minAtk;

      
        /// <summary>
        /// 最大攻击力
        /// </summary>
         [Header("最大攻击力")] public int maxAtk;

      
        /// <summary>
        /// 闪避几率
        /// </summary>
         [Header("闪避")] public int dodge;

      
        /// <summary>
        /// 暴击
        /// </summary>
       [Header("暴击")]   public int crits;

        /// <summary>
        /// 暴击伤害
        /// </summary>
        [Header("暴击伤害")] public int critsDamage = 150;

        /// <summary>
        /// 精准 
        /// </summary>
        [Header("精准")]public int rate;

      
        /// <summary>
        /// 速度
        /// </summary>
         [Header("速度")] public int speed;

      
        /// <summary>
        /// 流血抗性
        /// </summary>
         [Header("流血抗性")] public int bleed;

      
        /// <summary>
        /// 中毒抗性
        /// </summary>
         [Header("中毒抗性")] public int poison;

       
        /// <summary>
        /// 减益抗性
        /// </summary>
       [Header("减益抗性")]  public int debuff;

     
        /// <summary>
        /// 眩晕抗性
        /// </summary>
          [Header("眩晕抗性")] public int vertigo;

      
        /// <summary>
        /// 位移抗性
        /// </summary>
         [Header("位移抗性")] public int position;

    
        /// <summary>
        /// 死亡抗性
        /// </summary>
        [Header("死亡抗性")] public int death;

        
        /// <summary>
        /// 偏好移动方向
        /// </summary>
       [Header("偏好移动方向")] public PreferMove preferMove;

    
        /// <summary>
        /// 移动距离
        /// </summary>
          [Header("移动距离")]  public int moveDistance;

        public RoleData Clone()
        {
            RoleData that = new RoleData();
            that.id = id;
            that.name = name;
            that.describe = describe;
			that.describe_EN = describe_EN;
			that.icon = icon;
            that.image = image;
            that.MoraleSkillEffectSprite = MoraleSkillEffectSprite;
            that.roleType = roleType;
			that.roleSex = roleSex;
            that.vocation = vocation;
            that.roleHaveSkill =  new List<int>( roleHaveSkill);
            that.roleMode = roleMode;
            that.size = size;
            that.actNum = actNum;
            that.maxMorale = maxMorale;
            that.minMorale = minMorale;
            that.maxInjuries = maxInjuries;
            that.minInjuries = minInjuries;
            that.hp = hp;
            that.defence = defence;
            that.minAtk = minAtk;
            that.maxAtk = maxAtk;
            that.dodge = dodge;
            that.crits = crits;
            that.rate = rate;
            that.speed = speed;
            that.bleed = bleed;
            that.poison = poison;
            that.debuff = debuff;
            that.vertigo = vertigo;
            that.position = position;
            that.death = death;
            that.preferMove = preferMove;
            that.moveDistance = moveDistance;
            that.critsDamage = critsDamage;
            that.unitType = unitType;
            return that; //MemberwiseClone() as RoleData;
        }
    }

    /// <summary>
    /// 怪物高级数据
    /// </summary>
    [Serializable]
    public class RoleSeniorData
    {
        public TaskDifficulty taskDifficulty;
        public RoleData roleData;
    }
    
    /// <summary>
    /// 角色基础数据集合
    /// </summary>
    [CreateAssetMenu(menuName = "NewData/Battle/RoleData")]
    [Serializable]    
    public class RoleDataSet : ScriptableObject
    {
        public string TipsA = "若想增加角色,在大小中输入一个比当前值更大的值,如5→6";
        public string TipsB = "！！！若在大小中输入了更小的值,可能会造成数据丢失";
        public string TipsC = "！！！鼠标放在字段上有提示";
        
        [Header("英雄基础数据")]
        [SerializeField] public List<RoleData> heroData = new List<RoleData>();

        [Header("怪物基础数据")]
        [SerializeField] public List<RoleData> enemyData = new List<RoleData>();

        [Header("怪物高级数据")]
        [SerializeField] public List<RoleSeniorData> enemySeniorData = new List<RoleSeniorData>();
    }

}