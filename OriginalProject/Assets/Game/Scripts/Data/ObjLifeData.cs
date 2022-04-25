using Datas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

/// <summary>
/// 角色数据类
/// </summary>
[Serializable]
public class ObjLifeData
{
    /// <summary>
    /// 当前生命值
    /// </summary>
    private int nowHp;

    /// <summary>
    /// 当前士气
    /// </summary>
    private int nowMorale;

    /// <summary>
    /// 角色存档数据
    /// </summary>
    private HeroMode heroMode;

    /// <summary>
    /// 角色固有数据
    /// </summary>
    private RoleData roleData;

    /// <summary>
    /// 角色天赋数据，在战斗开始时初始化
    /// </summary>
    private TalentData talentData;

    #region Buff模块

    /// <summary>
    /// 使用技能时临时添加的技能修正值buff
    /// </summary>
    private List<ObjSkillCorrect> skillCorrentList = new List<ObjSkillCorrect>();
    /// <summary>
    /// 使用技能产生的buff
    /// </summary>
    private List<ObjSkillBuff> skillBuffList = new List<ObjSkillBuff>();

    /// <summary>
    /// 常驻buff
    /// </summary>
    private List<ObjPermanentBuff> permanentBuffList = new List<ObjPermanentBuff>();

    /// <summary>
    /// 添加技能修正buff
    /// </summary>
    /// <param name="skillCorrect"></param>
    public void AddSkillCorrect(ObjSkillCorrect skillCorrect)
    {
        skillCorrentList.Add(skillCorrect);
    }

    /// <summary>
    /// 清空技能修正buff
    /// </summary>
    public void ClearSkillCorrent()
    {
        skillCorrentList.Clear();
    }

    /// <summary>
    /// 当前是否已有技能修正buff
    /// </summary>
    /// <returns></returns>
    public bool HaveSkillCorrect()
    {
        return skillCorrentList.Count > 0;
    }

    /// <summary>
    /// 添加技能产生的buff
    /// </summary>
    /// <param name="skillBuff"></param>
    public void AddSkillBuff(ObjSkillBuff skillBuff)
    {
        ObjSkillBuff objSkillBuff = null;
        switch (skillBuff.specialBuffType)
        {
            case SpecialBuffType.通用:
                objSkillBuff = new ObjSkillBuff(skillBuff);
                break;

            default:
                Debug.Log("特殊buff类型错误");
                break;
        }
        if (skillBuff.buffType == ObjBuffType.所有抗性)
        {
            skillBuffList.Add(new ObjSkillBuff(ObjBuffType.中毒抗性,skillBuff.valueType,skillBuff.buffValue,skillBuff.round));
            skillBuffList.Add(new ObjSkillBuff(ObjBuffType.减益抗性, skillBuff.valueType, skillBuff.buffValue, skillBuff.round));
            skillBuffList.Add(new ObjSkillBuff(ObjBuffType.眩晕抗性, skillBuff.valueType, skillBuff.buffValue, skillBuff.round));
            skillBuffList.Add(new ObjSkillBuff(ObjBuffType.位移抗性, skillBuff.valueType, skillBuff.buffValue, skillBuff.round));
            skillBuffList.Add(new ObjSkillBuff(ObjBuffType.流血抗性, skillBuff.valueType, skillBuff.buffValue, skillBuff.round));
        }
        else
        {
            skillBuffList.Add(objSkillBuff);
        }

        
    }

    /// <summary>
    /// 移除技能产生的buff
    /// </summary>
    /// <param name="objSkillBuff"></param>
    public void RemoveSkillBuff(ObjSkillBuff objSkillBuff)
    {
        skillBuffList.Remove(objSkillBuff);
    }

    /// <summary>
    /// 移除技能产生的一类buff
    /// </summary>
    /// <param name="buffType"></param>
    public void RemoveSkillBuff(ObjBuffType buffType)
    {
        if (buffType.Equals(ObjBuffType.减益))
        {
            skillBuffList.RemoveAll(s => s.buffValue < 0 && BattleCalculating.IsDebuff(s.buffType));
        }
        else if (buffType == ObjBuffType.增益)
        {
            skillBuffList.RemoveAll(s => s.buffValue > 0 && BattleCalculating.IsDebuff(s.buffType));
        }
        else if (buffType.Equals(ObjBuffType.异常状态))
        {
            skillBuffList.RemoveAll(s => !BattleCalculating.IsDebuff(s.buffType));
        }
        else if (buffType.Equals(ObjBuffType.异常状态不包括濒死人心惶惶)) {
            skillBuffList.RemoveAll(s => !BattleCalculating.IsDebuff(s.buffType) && s.buffType != ObjBuffType.濒死 && s.buffType == ObjBuffType.人心惶惶);
        }
        else
        {
            skillBuffList.RemoveAll(s => s.buffType.Equals(buffType));
        }
    }

    /// <summary>
    /// 清空技能产生的buff
    /// </summary>
    public void ClearSkillBuff()
    {
        skillBuffList.Clear();
    }

    /// <summary>
    /// 获取技能产生的buff列表
    /// </summary>
    /// <returns></returns>
    public List<ObjSkillBuff> GetSkillBuffs()
    {
        return skillBuffList;
    }

    /// <summary>
    /// 是否存在某个buff
    /// </summary>
    /// <param name="objSkillBuff"></param>
    /// <returns></returns>
    public bool ExistsSkillBuff(ObjBuffType buffType)
    {
        switch (buffType)
        {
            case ObjBuffType.增减益:
                return ExistsSkillBuff(ObjBuffType.增益) && ExistsSkillBuff(ObjBuffType.减益);
            case ObjBuffType.增益:
                foreach (var buff in skillBuffList)
                {
                    if (BattleCalculating.IsDebuff(buff.buffType) && buff.buffValue > 0)
                    {
                        return true;
                    }
                }
                return false;
            case ObjBuffType.减益:
                foreach (var buff in skillBuffList)
                {
                    if (BattleCalculating.IsDebuff(buff.buffType) && buff.buffValue < 0)
                    {
                        return true;
                    }
                }
                return false;
            default:
                return skillBuffList.Exists(s => s.buffType.Equals(buffType));
        }
    }

    /// <summary>
    /// 添加常驻buff
    /// </summary>
    /// <param name="objAction"></param>
    /// <param name="sourceIndex"></param>
    public void AddPermanentBuff(ObjPermanentBuff permanentBuff)
    {
        permanentBuffList.Add(permanentBuff);
    }

    /// <summary>
    /// 移除常驻buff
    /// </summary>
    /// <param name="sourceIndex"></param>
    public void RemovePermanentBuff(BuffSourceType source)
    {
        permanentBuffList.RemoveAll(s => s.source == source);
    }

    /// <summary>
    /// 是否存在某个来源的常驻buff
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public bool ExistsPermanentBuff(BuffSourceType source)
    {
        return permanentBuffList.Exists(s => s.source == source);
    }
    
    /// <summary>
    /// 是否存在某个类型的常驻buff
    /// </summary>
    /// <param name="buffType"></param>
    /// <returns></returns>
    public bool ExistsPermanentBuff(ObjBuffType buffType)
    {
        return permanentBuffList.Exists(s => s.buffType == buffType);
    }
    public List<ObjPermanentBuff> FindPermanentBuff(params ObjBuffType[] buffType) {
        List<ObjPermanentBuff> buffs = new List<ObjPermanentBuff>();
        if (permanentBuffList == null || permanentBuffList.Count <= 0) return buffs;
        for (int i = 0; i < buffType.Length; ++i)
        {
            ObjPermanentBuff buffTemp =  permanentBuffList.Find(s => s.buffType == buffType[i]);
            if (buffTemp == null) continue;
            buffs.Add(buffTemp);
        }
        return buffs;
    }

    /// <summary>
    /// 是否存在某个特殊效果-饰品
    /// </summary>
    /// <param name="specialEffect"></param>
    /// <returns></returns>
    public bool ExistsSpecialEffect(SpecialEffect specialEffect)
    {
        if (GetOrnamentId(1) != 0)
        {
            if (DataManager.Instance.GetOrnamentDataById(GetOrnamentId(1)).specialEffect == specialEffect)
            {
                return true;
            }
        }
        if (GetOrnamentId(2) != 0)
        {
            if (DataManager.Instance.GetOrnamentDataById(GetOrnamentId(2)).specialEffect == specialEffect)
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// 获取常驻buff列表
    /// </summary>
    /// <returns></returns>
    public List<ObjPermanentBuff> GetPermanentBuff()
    {
        return permanentBuffList;
    }

    /// <summary>
    /// 设置常驻buff是否生效
    /// </summary>
    /// <param name="limitType"></param>
    /// <param name="value"></param>
    /// <param name="isTakeEffect"></param>
    public void SetBuffIsTakeEffect(ObjLimitType limitType, bool isTakeEffect)
    {
        List<ObjPermanentBuff> buffs = permanentBuffList.FindAll(s => s.limitType == limitType);
        foreach (var buff in buffs)
        {
            buff.isTakeEffect = isTakeEffect;
        }
    }

    /// <summary>
    /// 更新常驻buff是否生效，针对生命值限制类
    /// </summary>
    public void UpdateBuffIsTakeEffect()
    {
        foreach (var buff in permanentBuffList)
        {
            if (buff.limitType == ObjLimitType.生命值大于等于)
            {
                buff.isTakeEffect = GetHp() >= GetMaxHp() * buff.limitValue * 0.01f;
            }
            if (buff.limitType == ObjLimitType.生命值小于)
            {
                buff.isTakeEffect = GetHp() < GetMaxHp() * buff.limitValue * 0.01f;
            }
        }
    }

    public string log;

    /// <summary>
    /// 获取属性，角色基础属性+buff加成
    /// </summary>
    /// <param name="type"></param>
    /// <param name="basis"></param>
    /// <returns></returns>
    public int GetAttribute(ObjBuffType type, int basis)
    {
        List<int> addList = new List<int>();
        List<int> ratioList = new List<int>();

        foreach (var buff in skillCorrentList)//额外技能附加概率
        {
            if (buff.buffType.Equals(type))
            {
                if (buff.valueType.Equals(ValueType.加减))
                {
                    addList.Add(buff.buffValue);
                }
                else
                {
                    ratioList.Add(buff.buffValue);
                }
            }
        }
        foreach (var buff in skillBuffList)//角色概率
        {
            if (buff.buffType.Equals(type))
            {
                if (buff.valueType.Equals(ValueType.加减))
                {
                    addList.Add(buff.buffValue);
                }
                else
                {
                    ratioList.Add(buff.buffValue);
                }
            }
        }
        foreach (var buff in permanentBuffList)
        {
            if (buff.isTakeEffect && buff.buffType.Equals(type))
            {
                if (buff.valueType.Equals(ValueType.加减))
                {
                    addList.Add(buff.buffValue);
                }
                else
                {
                    ratioList.Add(buff.buffValue);
                }
            }
        }


        var add = addList.Sum();
        var ratio = ratioList.Sum();
		switch (type)
		{
			case ObjBuffType.暴击伤害:
			case ObjBuffType.暴击:
			case ObjBuffType.减伤:
			case ObjBuffType.伤害修正:

				return GetAttributeLimitValue(basis + addList.Sum() + ratioList.Sum(), type);
			default:

				var calValue =(basis + add) * (1 + ratio / 100f);
				// +0.01f因为系统Mathf.RoundToInt四舍五入不准确
				var finalValue = Mathf.RoundToInt(calValue + 0.01f);

				finalValue = GetAttributeLimitValue(finalValue, type);
				if (type == ObjBuffType.伤害)
				{
					//伤害不好为负值
					log += $"\n[{type}] 带入随机后的值({basis}) => (基础值({basis}) + 附加值({add})) * (1 + 倍率({ratio}) / 100) = {calValue} 四舍五入 舍弃负值后 = {finalValue}\n";
					log += $"[{type}] 伤害倍率值:{getRatioListDest(ratioList)}";
				}

                return finalValue;
        }
    }

	/// <summary>
	/// 熟悉值限制后的值
	/// </summary>
	/// <returns></returns>
	public int GetAttributeLimitValue(int value, ObjBuffType type)
	{
		switch (type)
		{
			case ObjBuffType.精准:
			case ObjBuffType.闪避:
			case ObjBuffType.攻击下限:
			case ObjBuffType.攻击上限:
			case ObjBuffType.伤害:
			case ObjBuffType.暴击:
			case ObjBuffType.速度:
				return Mathf.Clamp(value, 0, 999);
			//状态
			case ObjBuffType.中毒状态基础概率:
			case ObjBuffType.流血状态基础概率:
			case ObjBuffType.减益状态基础概率:
			case ObjBuffType.眩晕状态基础概率:
				return Mathf.Clamp(value, 0, 999);
			//状态抗性
			case ObjBuffType.中毒抗性:
			case ObjBuffType.流血抗性:
			case ObjBuffType.减益抗性:
			case ObjBuffType.眩晕抗性:
				return Mathf.Clamp(value, 0, 999);
			case ObjBuffType.减伤:
				return Mathf.Clamp(value, 0, 90);
		}
		return value;
	}

	string getRatioListDest(List<int> ratioList)
	{
		StringBuilder sb = new StringBuilder();
		foreach(int ratio in ratioList)
		{
			sb.Append(ratio.ToString());
			sb.Append(" ");
		}
		return sb.ToString();
	}

	#endregion

	#region 属性封装模块

	/// <summary>
	/// 获取角色id
	/// </summary>
	/// <returns></returns>
	public int GetId()
    {
        return roleData.id;
    }

    /// <summary>
    /// 获取当前血量
    /// </summary>
    /// <returns></returns>
    public float GetHp()
    {
        return nowHp;
    }

    /// <summary>
    /// 设置当前血量
    /// </summary>
    /// <param name="value"></param>
    public void SetHp(int value)
    {
        nowHp = value;
        UpdateBuffIsTakeEffect();
    }

    /// <summary>
    /// 更新当前血量（加减）
    /// </summary>
    /// <param name="value">加减值</param>
    public void UpdateHp(int value)
    {
        nowHp += value;
        UpdateBuffIsTakeEffect();
    }

    /// <summary>
    /// 获取当前士气
    /// </summary>
    /// <returns></returns>
    public int GetMorale()
    {
        return heroMode.nowMorale;
    }
    
    /// <summary>
    /// 设置当前士气
    /// </summary>
    /// <param name="value"></param>
    public void SetMorale(int value)
    {
        // UnityEngine.Debug.LogError("test set morale " + this.GetHeroName() + "  " + heroMode.nowMorale + "   " + value);
        heroMode.nowMorale = value;
    }

    /// <summary>
    /// 更新当前士气（加减）
    /// </summary>
    /// <param name="value">加减值</param>
    public void UpdateMorale(int value)
    {
        // UnityEngine.Debug.LogError("test update morale " + this.GetHeroName() + "  " + heroMode.nowMorale + "   " + value);
        heroMode.nowMorale += value;
        if (GetMorale() < GetMinMorale())
        {
            SetMorale(GetMinMorale());
        }
        if (GetMorale() > GetMaxMorale())
        {
            SetMorale(GetMaxMorale());
        }
    }

    /// <summary>
    /// 获取当前伤势
    /// </summary>
    /// <returns></returns>
    public int GetInjuries()
    {
        return heroMode.injuries;
    }

    /// <summary>
    /// 设置当前伤势
    /// </summary>
    /// <param name="value"></param>
    public void SetInjuries(int value)
    {
        heroMode.injuries = value;
    }

    /// <summary>
    /// 更新当前伤势（加减）
    /// </summary>
    /// <param name="value">加减值</param>
    public void UpdateInjuries(int value)
    {
        heroMode.injuries += value;
        if (GetInjuries() < 0)
        {
            SetInjuries(0);
        }
        if (GetInjuries() > GetMaxInjuries())
        {
            SetInjuries(GetMaxInjuries());
        }
    }
    public AssetReferenceSprite GetMoralSkillEffect()
    {
       return roleData.MoraleSkillEffectSprite;
    }

    /// <summary>
    /// 获取最大血量
    /// </summary>
    /// <returns></returns>
    public int GetMaxHp()
    {
        return GetAttribute(ObjBuffType.最大生命, roleData.hp);
    }

    /// <summary>
    /// 获取最大血量，不计算buff
    /// </summary>
    /// <returns></returns>
    public int GetMaxHpExceptBuff()
    {
        return roleData.hp;
    }

    /// <summary>
    /// 设置最大血量
    /// </summary>
    /// <param name="value"></param>
    public void SetMaxHp(int value)
    {
        roleData.hp = value;
    }

    /// <summary>
    /// 获取攻击下限
    /// </summary>
    /// <returns></returns>
    public int GetMinAtk()
    {
        return GetAttribute(ObjBuffType.攻击下限, roleData.minAtk);
    }

    /// <summary>
    /// 获取攻击上限
    /// </summary>
    /// <returns></returns>
    public int GetMaxAtk()
    {
        return GetAttribute(ObjBuffType.攻击上限, roleData.maxAtk);
    }

    /// <summary>
    /// 获取攻击
    /// </summary>
    /// <returns></returns>
    public int GetAtk()
    {
        var r = UnityEngine.Random.Range(GetMinAtk(), GetMaxAtk() + 1);
        log = string.Empty;
        log += $"攻击随机结果({r})\t";
        int result = GetAttribute(ObjBuffType.伤害,r );
        return result < 0 ? 0 : result;
    }

	/// <summary>
	/// 获取攻击原本的log
	/// </summary>
	/// <returns></returns>
	public string GetAtkBeforeLog()
	{
		return $"最低值({GetMinAtk()})~最高值({GetMaxAtk()}）";
	}
	/// <summary>
	/// 获取攻击属性加成后的log
	/// </summary>
	/// <returns></returns>
	public string GetAtkAfterLog()
	{
		int minAtk = GetAttribute(ObjBuffType.伤害, GetMinAtk());
		int maxAtk = GetAttribute(ObjBuffType.伤害, GetMaxAtk());
		return $"属性加成后 最低值({minAtk})~最高值({maxAtk}）";
	}

	/// <summary>
	/// 获取精准值
	/// </summary>
	/// <returns></returns>
	public int GetRate()
    {
        return GetAttribute(ObjBuffType.精准, roleData.rate);
    }

    /// <summary>
    /// 获取暴击值
    /// </summary>
    /// <returns></returns>
    public int GetCrits()
    {
        return GetAttribute(ObjBuffType.暴击, roleData.crits);
    }

    /// <summary>
    /// 获取暴击伤害值
    /// </summary>
    /// <returns></returns>
    public int GetCritsDamage()
    {
        return GetAttribute(ObjBuffType.暴击伤害, roleData.critsDamage);
    }

    /// <summary>
    /// 获取伤害修正值
    /// </summary>
    /// <returns></returns>
    public int GetDamageAdd()
    {
        return GetAttribute(ObjBuffType.伤害修正, 100);
    }


    /// <summary>
    /// 获取减伤值
    /// </summary>
    /// <returns></returns>
    public int GetDefence()
    {
        return GetAttribute(ObjBuffType.减伤, roleData.defence);
    }

    /// <summary>
    /// 获取闪避值
    /// </summary>
    /// <returns></returns>
    public int GetDodge()
    {
        return GetAttribute(ObjBuffType.闪避, roleData.dodge);
    }

    /// <summary>
    /// 获取速度值
    /// </summary>
    /// <returns></returns>
    public int GetSpeed()
    {
        return GetAttribute(ObjBuffType.速度, roleData.speed);
    }

    /// <summary>
    /// 获取流血抗性
    /// </summary>
    /// <returns></returns>
    public int GetBleed()
    {
        return GetAttribute(ObjBuffType.流血抗性, roleData.bleed);
    }

    /// <summary>
    /// 获取中毒抗性
    /// </summary>
    /// <returns></returns>
    public int GetPoison()
    {
        return GetAttribute(ObjBuffType.中毒抗性, roleData.poison);
    }

    /// <summary>
    /// 获取减益抗性
    /// </summary>
    /// <returns></returns>
    public int GetDebuff()
    {
        return GetAttribute(ObjBuffType.减益抗性, roleData.debuff);
    }

    /// <summary>
    /// 获取眩晕抗性
    /// </summary>
    /// <returns></returns>
    public int GetVertigo()
    {
        return GetAttribute(ObjBuffType.眩晕抗性, roleData.vertigo);
    }

    /// <summary>
    /// 获取位移抗性
    /// </summary>
    /// <returns></returns>
    public int GetPosition()
    {
        return GetAttribute(ObjBuffType.位移抗性, roleData.position);
    }

    /// <summary>
    /// 获取死亡抗性
    /// </summary>
    /// <returns></returns>
    public int GetDeath()
    {
        return GetAttribute(ObjBuffType.死亡抗性, roleData.death);
    }

    /// <summary>
    /// 获取士气上限
    /// </summary>
    /// <returns></returns>
    public int GetMaxMorale()
    {
        return GetAttribute(ObjBuffType.士气上限, roleData.maxMorale);
    }

    /// <summary>
    /// 获取士气下限
    /// </summary>
    /// <returns></returns>
    public int GetMinMorale()
    {
        return GetAttribute(ObjBuffType.士气下限, roleData.minMorale);
    }

    /// <summary>
    /// 获取伤势上限
    /// </summary>
    /// <returns></returns>
    public int GetMaxInjuries()
    {
        return GetAttribute(ObjBuffType.伤势上限, roleData.maxInjuries);
    }

    /// <summary>
    /// 获取角色头像
    /// </summary>
    /// <returns></returns>
    public AssetReferenceSprite GetIcon()
    {
        return roleData.icon;
    }

    /// <summary>
    /// 获取角色类型
    /// </summary>
    /// <returns></returns>
    public RoleType GetRoleType()
    {
        return roleData.roleType;
    }

    /// <summary>
    /// 获取英雄职业
    /// </summary>
    /// <returns></returns>
    public HeroVocation GetVocation()
    {
        return roleData.vocation;
    }

    /// <summary>
    /// 获取角色固有技能ID列表
    /// </summary>
    /// <returns></returns>
    public List<int> GetHaveSkill()
    {
        return roleData.roleHaveSkill;
    }

    /// <summary>
    /// 获取角色模型
    /// </summary>
    /// <returns></returns>
    public AssetReferenceGameObject GetRoleModel()
    {
        return roleData.roleMode;
    }

    /// <summary>
    /// 获取角色形象
    /// </summary>
    /// <returns></returns>
    public AssetReferenceSprite GetRoleImage()
    {
        return roleData.image;
    }

    /// <summary>
    /// 获取角色体积
    /// </summary>
    /// <returns></returns>
    public int GetSize()
    {
        return roleData.size;
    }

    /// <summary>
    /// 获取角色行动点
    /// </summary>
    /// <returns></returns>
    public int GetActNum()
    {
        return roleData.actNum;
    }

    /// <summary>
    /// 获取技能等级
    /// </summary>
    /// <param name="skillData"></param>
    /// <returns></returns>
    public int GetSkillLevel(SkillData skillData)
    {
        if (heroMode.skillModes == null || heroMode.skillModes.Find(s => s.skillId.Equals(skillData.id)) == null)
        {
            return 1;
        }
        else
        {
            return heroMode.skillModes.Find(s => s.skillId.Equals(skillData.id)).level;
        }
    }

    /// <summary>
    /// 获取角色名字
    /// </summary>
    /// <returns></returns>
    public string GetHeroName()
    {
        return heroMode.heroName;
    }

    /// <summary>
    /// 设置角色名字
    /// </summary>
    /// <param name="value"></param>
    public void SetHeroName(string value)
    {
        heroMode.heroName = value;
    }

    /// <summary>
    /// 获取准备出征状态，true=出征
    /// </summary>
    /// <returns></returns>
    public bool GetReadyStart()
    {
        return heroMode.readyStart;
    }

    /// <summary>
    /// 设置英雄准备出征状态
    /// </summary>
    /// <param name="isReady"></param>
    /// <returns></returns>
    public void SetReadyStart(bool isReady)
    {
        heroMode.readyStart = isReady;
    }

    /// <summary>
    /// 如果在出征状态，获取他在出征队伍的第几位
    /// </summary>
    /// <returns></returns>
    public int GetNumInTeamWaiting()
    {
        return heroMode.numInTeam_Waiting;
    }

    /// <summary>
    /// 如果在出征状态，设置他在出征队伍的第几位
    /// </summary>
    /// <param name="num"></param>
    public void SetNumInTeamWaiting(int num)
    {
        heroMode.numInTeam_Waiting = num;
    }

    /// <summary>
    /// 是否正在治疗
    /// </summary>
    /// <returns></returns>
    public bool GetIsHealing()
    {
        return heroMode.isHealing;
    }

    /// <summary>
    /// 治疗盒子索引
    /// </summary>
    /// <returns></returns>
    public int GetHealBoxIndex()
    {
        return heroMode.healBoxIndex;
    }

    /// <summary>
    /// 获取当前技能列表
    /// </summary>
    /// <returns></returns>
    public List<SkillMode> GetSkillModes()
    {
        return heroMode.skillModes;
    }

    /// <summary>
    /// 获取偏好移动方向
    /// </summary>
    /// <returns></returns>
    public PreferMove GetPreferMove()
    {
        return roleData.preferMove;
    }

    /// <summary>
    /// 获取移动距离
    /// </summary>
    /// <returns></returns>
    public int GetMoveDistance()
    {
        return roleData.moveDistance;
    }

    /// <summary>
    /// 获取士气技能
    /// </summary>
    /// <returns></returns>
    public OtherSkillData GetMoraleSkill()
    {
        return DataManager.Instance.GetMoraleSkillById(GetMoraleSkillId());
    }

    /// <summary>
    /// 获取士气技能id
    /// </summary>
    /// <returns></returns>
    public int GetMoraleSkillId()
    {
        return heroMode.moraleSkillId;
    }

    /// <summary>
    /// 设置士气技能id
    /// </summary>
    /// <param name="id"></param>
    public void SetMoraleSkillId(int id)
    {
        heroMode.moraleSkillId = id;
    }

    /// <summary>
    /// 获取装备的勋章
    /// </summary>
    /// <returns></returns>
    public MedalMode GetMedal()
    {
        return heroMode.medal;
    }

    /// <summary>
    /// 获取饰品id
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public int GetOrnamentId(int index)
    {
        if (index == 1)
        {
            return heroMode.ornaments1ID;
        }
        else if (index == 2)
        {
            return heroMode.ornaments2ID;
        }
        else
        {
            Debug.Log("获取饰品索引错误");
            return -1;
        }
    }

    /// <summary>
    /// 戴上饰品
    /// </summary>
    /// <param name="index"></param>
    /// <param name="objData"></param>
    public void AddOrnament(int index, ObjData objData)
    {
        if (objData == null) { return; }

        if (index == 1)
        {
            RemovePermanentBuff(BuffSourceType.饰品1);
            heroMode.ornaments1ID = objData.id;
            List<ObjAction> objActions = objData.objActions;
            foreach (var objAction in objActions)
            {
                AddPermanentBuff(new ObjPermanentBuff(objAction, BuffSourceType.饰品1));
            }
        }
        else if (index == 2)
        {
            RemovePermanentBuff(BuffSourceType.饰品2);
            heroMode.ornaments2ID = objData.id;
            List<ObjAction> objActions = objData.objActions;
            foreach (var objAction in objActions)
            {
                AddPermanentBuff(new ObjPermanentBuff(objAction, BuffSourceType.饰品2));
            }
        }
        else
        {
            Debug.Log("获取饰品索引错误");
            return;
        }

        UpdateBuffIsTakeEffect();
        CompleteOrnamentCheck();
    }

    /// <summary>
    /// 脱下饰品
    /// </summary>
    /// <param name="index"></param>
    public void RemoveOrnament(int index)
    {
        if (index == 1)
        {
            RemovePermanentBuff(BuffSourceType.饰品1);
            heroMode.ornaments1ID = 0;
        }
        else if (index == 2)
        {
            RemovePermanentBuff(BuffSourceType.饰品2);
            heroMode.ornaments2ID = 0;
        }
        else
        {
            Debug.Log("获取饰品索引错误");
            return;
        }

        CompleteOrnamentCheck();
    }

    /// <summary>
    /// 套装检查
    /// </summary>
    private void CompleteOrnamentCheck()
    {
        if (GetOrnamentId(1) != 0 && GetOrnamentId(2) != 0 
            && GetOrnamentId(1) != GetOrnamentId(2)
            && DataManager.Instance.GetOrnamentDataById(GetOrnamentId(1)).specialEffect == SpecialEffect.异化套装
            && DataManager.Instance.GetOrnamentDataById(GetOrnamentId(2)).specialEffect == SpecialEffect.异化套装)
        {
            if (!ExistsPermanentBuff(BuffSourceType.套装))
            {
                foreach (var objAction in DataManager.Instance.GetOrnamentDataById(GetOrnamentId(1)).objActions)
                {
                    AddPermanentBuff(new ObjPermanentBuff(objAction, BuffSourceType.套装));
                }
                foreach (var objAction in DataManager.Instance.GetOrnamentDataById(GetOrnamentId(2)).objActions)
                {
                    AddPermanentBuff(new ObjPermanentBuff(objAction, BuffSourceType.套装));
                }
            }
        }
        else
        {
            RemovePermanentBuff(BuffSourceType.套装);
        }
    }

    /// <summary>
    /// 戴上勋章
    /// </summary>
    /// <param name="objData"></param>
    public void AddMedal(MedalObjData objData)
    {
        RemovePermanentBuff(BuffSourceType.勋章);
        heroMode.medal = objData.GetMedalMode();
        foreach (var item in objData.GetAttribute())
        {
            AddPermanentBuff(item);
        }
        foreach (var item in objData.GetEntry())
        {
            AddPermanentBuff(item);
        }
    }

    /// <summary>
    /// 脱下勋章
    /// </summary>
    public void RemoveMedal()
    {
        RemovePermanentBuff(BuffSourceType.勋章);
        heroMode.medal = new MedalMode();
    }

    /// <summary>
    /// 设置天赋存档（浅拷贝）
    /// </summary>
    /// <param name="talentMode"></param>
    public void SetTalentMode(TalentMode talentMode)
    {
        heroMode.talent = talentMode;
    }

    /// <summary>
    /// 获取天赋数据
    /// </summary>
    /// <returns></returns>
    public TalentData GetTalentData()
    {
        if (talentData == null)
        {
            InitTalentData();
        }
        return talentData;
    }

    /// <summary>
    /// 初始化天赋数据，在战斗开始时调用
    /// </summary>
    public void InitTalentData()
    {
        talentData = DataManager.Instance.GetTalentData(heroMode.talent);
    }

    #endregion

    public ObjLifeData()
    {

    }

    public ObjLifeData(int nowHp, int nowMorale, HeroMode heroMode, RoleData roleData)
    {
        this.nowHp = nowHp;
        this.nowMorale = nowMorale;
        this.heroMode = heroMode;
        this.roleData = roleData;
    }

    public RoleData GetRoleData()
    {
        return roleData;
    }

    public HeroMode GetHeroMode()
    {
        return heroMode;
    }

    public void SetHeroMode(HeroMode heroMode)
    {
        this.heroMode = heroMode;

        //启用饰品效果
        if (GetOrnamentId(1) != 0)
        {
            AddOrnament(1, DataManager.Instance.GetOrnamentDataById(GetOrnamentId(1)));
        }
        if (GetOrnamentId(2) != 0)
        {
            AddOrnament(2, DataManager.Instance.GetOrnamentDataById(GetOrnamentId(2)));
        }

        //启用勋章效果
        if (GetMedal() != null && GetMedal().objId != 0)
        {
            AddMedal(DataManager.Instance.GetMedalByMode(GetMedal()));
        }
    }

    /// <summary>
    /// 导入高级数据
    /// </summary>
    /// <param name="data"></param>
    public void ImportSeniorData(RoleData data)
    {
        roleData.hp = data.hp;
        nowHp = data.hp;
        roleData.defence = data.defence;
        roleData.minAtk = data.minAtk;
        roleData.maxAtk = data.maxAtk;
        roleData.dodge = data.dodge;
        roleData.crits = data.crits;
        roleData.rate = data.rate;
        roleData.speed = data.speed;
        roleData.bleed = data.bleed;
        roleData.poison = data.poison;
        roleData.debuff = data.debuff;
        roleData.vertigo = data.vertigo;
        roleData.position = data.position;
    }

    public ObjLifeData Clone()
    {
        ObjLifeData result = new ObjLifeData();

        result.nowHp = nowHp;
        result.nowMorale = nowMorale;
        result.heroMode = heroMode.Clone();
        result.roleData = roleData.Clone();

        result.skillCorrentList = new List<ObjSkillCorrect>();
        foreach (var item in skillCorrentList)
        {
            result.skillCorrentList.Add(new ObjSkillCorrect(item));
        }
        result.skillBuffList = new List<ObjSkillBuff>();
        foreach (var item in skillBuffList)
        {
            result.skillBuffList.Add(item);
        }
        result.permanentBuffList = new List<ObjPermanentBuff>();
        foreach (var item in permanentBuffList)
        {
            result.permanentBuffList.Add(item);
        }

        return result;
    }

}