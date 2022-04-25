using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Datas;
using UnityEngine.Advertisements.Purchasing;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.AddressableAssets;
using DG.Tweening;
using static BattleFlowController;

/// <summary>
/// 角色类
/// </summary>
public class ObjLife : MonoBehaviour
{
    const bool enableMoraleLog = true;
    public const int FirstMorale = 100;
    /// <summary>
    /// 角色UI控制器
    /// </summary>
    private RoleUiController roleUiCon;

    /// <summary>
    /// 获取控制器
    /// </summary>
    public RoleUiController getRoleUiCon => roleUiCon;

    /// <summary>
    /// 角色动画控制器
    /// </summary>
    public RoleAnimationController roleAniCon;

    /// <summary>
    /// 角色数据
    /// </summary>
    private ObjLifeData objLifeData;
    #region 双面间谍
    /// <summary>
    /// 双面间谍形态标记 -- 是否是间谍形态,   true = 间谍形态  false = 杀戮形态
    /// </summary>
    public bool IsSpy { get; set; } = true;
    #endregion
    #region 亡命赌徒
    /// <summary>
    /// “毒品”类技能使用次数
    /// </summary>
    public int DupinSkill { get; set; } = 0;
    /// <summary>
    /// “赌徒”类技能使用次数
    /// </summary>
    public int DutuSkill { get; set; } = 0;

    /// <summary>
    /// 赌徒技能使用栈
    /// </summary>
    public Stack<int> dutuskill_stack = new Stack<int>();

    /// <summary>
    /// 毒品技能使用栈
    /// </summary>
    public Stack<int> dupinskill_stack = new Stack<int>();

    #endregion
    /// <summary>
    /// 行动点
    /// </summary>
    public int CurrentActNum { get; set; } = 0;

    /// <summary>
    /// 人心惶惶开始回合数
    /// </summary>
    [System.NonSerialized]
    public int renxinghuanghuangRound = 0;

    /// <summary>
    /// 士气爆发
    /// </summary>
    private int moraleBurstNum;

    public int MoraleBurstNum
    {
        get { return moraleBurstNum; }
        set
        {
            if (value > moraleBurstNum)
            {
                OnMoraleBurstNum();
            }
            moraleBurstNum = value;
        }
    }

    /// <summary>
    /// 这个角色的类型
    /// </summary>
    public UnitType TheUnitType
    {
        get
        {
            return objLifeData.GetRoleData().unitType;
        }
    }

    private SkillData nextSkill;

    //天赋
    public int BeCureCount { get; set; } = 0;
    /// <summary>
    /// 位移计数
    /// </summary>
    public int BePositionCount { get; set; } = 0;
    /// <summary>
    /// 是否销毁
    /// </summary>
    public bool isDestroyed { get; set; }
    public bool Is6 { get; internal set; }

    private void Awake()
    {
        roleAniCon = GetComponent<RoleAnimationController>();
        roleUiCon = GetComponent<RoleUiController>();
    }
    /// <summary>
    /// 初始化角色
    /// </summary>
    /// <param name="_roleData"></param>
    public void InitRole(ObjLifeData objLifeData)
    {
        this.objLifeData = objLifeData;
    }

    /// <summary>
    /// 角色移动
    /// </summary>
    /// <param name="time">动画时间</param>
    /// <param name="target">目标位置</param>
    public void RoleMove(float time, Vector3 target)
    {
        roleAniCon.ExchangePositionMove(time, target);
    }

    /// <summary>
    /// 释放技能时需要显示的特效
    /// </summary>
    public void ReleaseSkillEffect(SkillData skill)
    {
        // 释放技能时显示的名字
        roleAniCon.ShowReleaseSkillName(skill.name);
    }

    public void SetPosition(Vector3 target)
    {
        transform.localPosition = target;
    }

    /// <summary>
    /// 获取角色位置坐标
    /// </summary>
    /// <returns></returns>
    public Vector3 GetTransformPosition()
    {
        return transform.position;
    }

    #region 角色属性封装模块

    /// <summary>
    /// 获取当前血量
    /// </summary>
    /// <returns></returns>
    public float GetHp()
    {
        return objLifeData.GetHp();
    }

    /// <summary>
    /// 设置当前血量
    /// </summary>
    /// <param name="value"></param>
    public void SetHp(int value)
    {
        objLifeData.SetHp(value);
        roleUiCon?.UpdateValue(objLifeData);

        if (GetHp() == 0)
        {
            BattleFlowController.Instance.AddRoleToDeathDecideList(this);
        }
    }

    /// <summary>
    /// 更新当前血量（加减）
    /// </summary>
    /// <param name="value">加减值</param>
    public void UpdateHp(int value, bool isDodge = false, float delay = 0)
    {
        if (ExistsSkillBuff(ObjBuffType.割礼))
        {
            if (GetHp() < GetMaxHp() * 0.3f)
            {
                SetHp(0);
            }
        }

        objLifeData.UpdateHp(value);

        if (ExistsSkillBuff(ObjBuffType.割礼))
        {
            if (GetHp() < GetMaxHp() * 0.3f)
            {
                SetHp(0);
            }
        }

        if (GetHp() < 0)
        {
            SetHp(0);
        }
        if (GetHp() > GetMaxHp())
        {
            SetHp(GetMaxHp());
        }

        if (isDodge)
        {
            roleAniCon.ShowValue("闪避");
        }
        else
        {
            roleUiCon.UpdateValue(objLifeData);
        }

        if (value > 0)
        {
            RemovePermanentBuff(BuffSourceType.生命);
        }
        //xiaolei 272
        //if (GetHp() == 0)
        if (GetHp() == 0 && !isDodge)
        {
            BattleFlowController.Instance.AddRoleToDeathDecideList(this);
        }
    }
    public void ShowValue(int value, float delay, bool IsCrits, string hexString = "#FFFFFF")
    {
        roleAniCon.ShowValue(value, delay, IsCrits, hexString);
    }
    /// <summary>
    /// 获取当前士气
    /// </summary>
    /// <returns></returns>
    public int GetMorale()
    {
        return objLifeData.GetMorale();
    }

    /// <summary>
    /// 设置当前士气
    /// </summary>
    /// <param name="value"></param>
    public void SetMorale(int value)
    {
        objLifeData.SetMorale(value);
    }

    /// <summary>
    /// 更新当前士气（加减）
    /// </summary>
    /// <param name="value">加减值</param>
    public void UpdateMorale(int value, string log)
    {
        if(this.GetMaxMorale() <= 0)
        {
            return;
        }

        if (value > 0 && ExistsSkillBuff(ObjBuffType.血灌瞳人))
        {
            return;
        }

        int lastMorale = GetMorale();

        objLifeData.UpdateMorale(value);
        roleUiCon.UpdateValue(objLifeData);

        //if (lastMorale > 10 && GetMorale() <= 10)
        //{
        //    BattleFlowController.Instance.MoraleUpdateToThreshold(10, this);
        //}

        //if (lastMorale > 0 && GetMorale() == 0)
        //{
        //    BattleFlowController.Instance.MoraleUpdateToThreshold(0, this);
        //}



        WriteMoraleLog(lastMorale, value, log);


        //TalentEffect effect = Random.Range(0f, 1f) >= 0.5f ? talentData.Order : talentData.Chaos;
        //BattleFlowController.Instance.TalentTrigger(this, effect);

        TalentData talentData = objLifeData.GetTalentData();

        int marole = GetMorale();
        
        // UnityEngine.Debug.LogError("test UpdateMorale " + this.GetHeroName() + "  " + marole + "  " + lastMorale + "  " + talentData);

        if(talentData != null)
        { 
            if (lastMorale < 75 && marole >= 75)
            {
                WriteMoraleLog(lastMorale, value, log + " - " + "天赋昂扬");
                roleUiCon.ShowTalentTrigger();
                BattleFlowController.Instance.TalentTrigger(this, talentData.Order);
            }
            else if ((lastMorale < 35 && marole >= 35) || (lastMorale >=75 && marole < 75))
            {
                WriteMoraleLog(lastMorale, value, log + " - " + "天赋平衡");
                TalentEffect effect = Random.Range(0f, 1f) >= 0.5f ? talentData.Order : talentData.Chaos;
                roleUiCon.ShowTalentTrigger();
                BattleFlowController.Instance.TalentTrigger(this, effect);
            }
            else if (lastMorale >= 35 && marole < 35)
            {
                WriteMoraleLog(lastMorale, value, log + " - " + "天赋歪曲");
                roleUiCon.ShowTalentTrigger();
                BattleFlowController.Instance.TalentTrigger(this, talentData.Chaos);
            }
        }
         
        if (lastMorale < 35 && GetMorale() >= 35)
        {
            if (ExistsPermanentBuff(ObjBuffType.人心惶惶))
            {
                WriteMoraleLog(lastMorale, value, log + " - " + "减buff人心惶惶");
                // UnityEngine.Debug.LogError("test UpdateMorale  remove 负向士气 " + this.GetHeroName() + "  " + marole + "  " + lastMorale + "  " + talentData);
                RemovePermanentBuff(BuffSourceType.负向士气);
            }
        }
        if(lastMorale >= 15 && GetMorale() < 15)
        {
            if (!ExistsPermanentBuff(ObjBuffType.人心惶惶))
            {
                WriteMoraleLog(lastMorale, value, log + " - " + "加buff人心惶惶");

                // UnityEngine.Debug.LogError("test UpdateMorale  add 负向士气 " + this.GetHeroName() + "  " + marole + "  " + lastMorale + "  " + talentData);

                AddPermanentBuff(new ObjPermanentBuff(ObjBuffType.人心惶惶, ValueType.加减, 0, BuffSourceType.负向士气));
                this.renxinghuanghuangRound = BattleFlowController.Instance.GetRoundNum();
            }
        }

        if (objLifeData.GetRoleType() == RoleType.英雄)
        {
            var s = GetMorale() - lastMorale;
            if (s != 0)
            {
                roleAniCon.ShowMoraleValue(s, 2.5f);
            }
        }
    }


    void WriteMoraleLog(int lastMorale, int updateMoraleValue, string log, bool writePreLog = true)
    {
        if (!enableMoraleLog)
        {
            return;
        }

        string preLog = "";
        if (writePreLog)
        {
            int curMorale = GetMorale();
            preLog = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "  "  + this.GetHeroName() + " | " + "旧值:" + lastMorale + " | " + "当前值:" + curMorale + " | " + "更新值:" + updateMoraleValue + " | ";
        }

        FileLog.Log("morale_log", preLog + log);
    }
    /// <summary>
    /// 获取当前伤势
    /// </summary>
    /// <returns></returns>
    public int GetInjuries()
    {
        return objLifeData.GetInjuries();
    }

    /// <summary>
    /// 设置当前伤势
    /// </summary>
    /// <param name="value"></param>
    public void SetInjuries(int value)
    {
        objLifeData.SetInjuries(value);
    }

    /// <summary>
    /// 更新当前伤势（加减）
    /// </summary>
    /// <param name="value">加减值</param>
    public void UpdateInjuries(int value)
    {
        value = objLifeData.GetAttribute(ObjBuffType.伤势伤害, value);
        objLifeData.UpdateInjuries(value);
        roleUiCon.UpdateValue(objLifeData);
    }

    /// <summary>
    /// 获取最大血量
    /// </summary>
    /// <returns></returns>
    public int GetMaxHp()
    {
        return objLifeData.GetMaxHp();
    }

    /// <summary>
    /// 获取最大血量，不计算buff
    /// </summary>
    /// <returns></returns>
    public int GetMaxHpExceptBuff()
    {
        return objLifeData.GetMaxHpExceptBuff();
    }

    /// <summary>
    /// 设置最大血量
    /// </summary>
    /// <param name="value"></param>
    public void SetMaxHp(int value)
    {
        objLifeData.SetMaxHp(value);
    }

    /// <summary>
    /// 获取攻击下限
    /// </summary>
    /// <returns></returns>
    public int GetMinAtk()
    {
        return objLifeData.GetMinAtk();
    }

    /// <summary>
    /// 获取攻击上限
    /// </summary>
    /// <returns></returns>
    public int GetMaxAtk()
    {
        return objLifeData.GetMaxAtk();
    }

    /// <summary>
    /// 获取攻击
    /// </summary>
    /// <returns></returns>
    public int GetAtk()
    {
        return objLifeData.GetAtk();
    }


	/// <summary>
	/// 获取攻击原本的log
	/// </summary>
	/// <returns></returns>
	public string GetAtkBeforeLog()
	{
		return objLifeData.GetAtkBeforeLog();
	}


	/// <summary>
	/// 获取攻击属性加成后的log
	/// </summary>
	/// <returns></returns>
	public string GetAtkAfterLog()
	{
		return objLifeData.GetAtkAfterLog();
	}


	public string GetAtkCalculateLog()
    {
        return objLifeData.log;
    }

    /// <summary>
    /// 获取精准值
    /// </summary>
    /// <returns></returns>
    public int GetRate()
    {
        return objLifeData.GetRate();
    }

    /// <summary>
    /// 获取暴击值
    /// </summary>
    /// <returns></returns>
    public int GetCrits()
    {
        return objLifeData.GetCrits();
    }

    /// <summary>
    /// 获取暴击伤害值
    /// </summary>
    /// <returns></returns>
    public int GetCritsDamage()
    {
        return objLifeData.GetCritsDamage();
    }

    /// <summary>
    /// 获取伤害修正值
    /// </summary>
    /// <returns></returns>
    public int GetDamageAdd()
    {
        return objLifeData.GetDamageAdd();
    }


    /// <summary>
    /// 获取减伤值
    /// </summary>
    /// <returns></returns>
    public int GetDefence()
    {
        return objLifeData.GetDefence();
    }

    /// <summary>
    /// 获取闪避值
    /// </summary>
    /// <returns></returns>
    public int GetDodge()
    {
        return objLifeData.GetDodge();
    }

    /// <summary>
    /// 获取速度值
    /// </summary>
    /// <returns></returns>
    public int GetSpeed()
    {
        return objLifeData.GetSpeed();
    }

    /// <summary>
    /// 获取流血抗性
    /// </summary>
    /// <returns></returns>
    public int GetBleed()
    {
        return objLifeData.GetBleed();
    }

    /// <summary>
    /// 获取中毒抗性
    /// </summary>
    /// <returns></returns>
    public int GetPoison()
    {
        return objLifeData.GetPoison();
    }

    /// <summary>
    /// 获取减益抗性
    /// </summary>
    /// <returns></returns>
    public int GetDebuff()
    {
        return objLifeData.GetDebuff();
    }

    /// <summary>
    /// 获取眩晕抗性
    /// </summary>
    /// <returns></returns>
    public int GetVertigo()
    {
        return objLifeData.GetVertigo();
    }

    /// <summary>
    /// 获取位移抗性
    /// </summary>
    /// <returns></returns>
    public int GetPosition()
    {
        return objLifeData.GetPosition();
    }

    /// <summary>
    /// 获取死亡抗性
    /// </summary>
    /// <returns></returns>
    public int GetDeath()
    {
        return objLifeData.GetDeath();
    }

    /// <summary>
    /// 获取士气上限
    /// </summary>
    /// <returns></returns>
    public int GetMaxMorale()
    {
        return objLifeData.GetMaxMorale();
    }

    /// <summary>
    /// 获取士气下限
    /// </summary>
    /// <returns></returns>
    public int GetMinMorale()
    {
        return objLifeData.GetMinMorale();
    }

    /// <summary>
    /// 获取伤势上限
    /// </summary>
    /// <returns></returns>
    public int GetMaxInjuries()
    {
        return objLifeData.GetMaxInjuries();
    }

    /// <summary>
    /// 获取角色头像
    /// </summary>
    /// <returns></returns>
    public AssetReferenceSprite GetIcon()
    {
        return objLifeData.GetIcon();
    }

    /// <summary>
    /// 获取角色类型
    /// </summary>
    /// <returns></returns>
    public RoleType GetRoleType()
    {
        return objLifeData.GetRoleType();
    }

    /// <summary>
    /// 获取英雄职业
    /// </summary>
    /// <returns></returns>
    public HeroVocation GetVocation()
    {
        return objLifeData.GetVocation();
    }

    /// <summary>
    /// 获取角色模型
    /// </summary>
    /// <returns></returns>
    public AssetReferenceGameObject GetRoleModel()
    {
        return objLifeData.GetRoleModel();
    }

    /// <summary>
    /// 获取角色体积
    /// </summary>
    /// <returns></returns>
    public int GetSize()
    {
        return objLifeData.GetSize();
    }

    /// <summary>
    /// 获取角色行动点
    /// </summary>
    /// <returns></returns>
    public int GetActNum()
    {
        return objLifeData.GetActNum();
    }

    /// <summary>
    /// 获取技能等级
    /// </summary>
    /// <param name="skillData"></param>
    /// <returns></returns>
    public int GetSkillLevel(SkillData skillData)
    {
        return objLifeData.GetSkillLevel(skillData);
    }

    /// <summary>
    /// 获取角色名字
    /// </summary>
    /// <returns></returns>
    public string GetHeroName()
    {
        return objLifeData.GetHeroName();
    }

    /// <summary>
    /// 设置角色名字
    /// </summary>
    /// <param name="value"></param>
    public void SetHeroName(string value)
    {
        objLifeData.SetHeroName(value);
    }

    /// <summary>
    /// 获取当前技能列表
    /// </summary>
    /// <returns></returns>
    public List<SkillMode> GetSkillModes()
    {
        return objLifeData.GetSkillModes();
    }

    /// <summary>
    /// 重置所有技能cd
    /// </summary>
    public void ResetSkillCd()
    {
        foreach (var skill in GetSkillModes())
        {
            skill.cd = 0;
        }
    }

    /// <summary>
    /// 更新技能cd
    /// </summary>
    /// <param name="skillId"></param>
    public void UpdateSkillCd(int skillId)
    {
        foreach (var skill in GetSkillModes())
        {
            if (skill.skillId == skillId)//cd重置
            {
                SkillData skillData = DataManager.Instance.GetSkillDataById(skillId);
                if (skillData == null)
                {
                    skill.cd = 0;
                }
                else
                {
                    skill.cd = skillData.cd;
                }
            }
            else
            {
                if (skill.cd > 0)
                {
                    skill.cd--;
                }
            }
        }
    }

    /// <summary>
    /// 判断某个技能是否可用（CD）
    /// </summary>
    /// <param name="skillId"></param>
    /// <returns></returns>
    public bool IsUseSkillForCd(int skillId)
    {
        SkillMode skill = GetSkillModes().Find(s => s.skillId == skillId);
        if (skill == null)
        {
            return false;
        }
        else
        {
            bool b_use = skill.cd == 0;
            if (skill.cd < 0) throw new System.Exception("技能cd值 小于0了");
            return b_use;
        }
    }

    /// <summary>
    /// 获取偏好移动方向
    /// </summary>
    /// <returns></returns>
    public PreferMove GetPreferMove()
    {
        return objLifeData.GetPreferMove();
    }

    /// <summary>
    /// 获取移动距离
    /// </summary>
    /// <returns></returns>
    public int GetMoveDistance()
    {
        return objLifeData.GetMoveDistance();
    }

    /// <summary>
    /// 获取士气技能id
    /// </summary>
    /// <returns></returns>
    public int GetMoraleSkillId()
    {
        return objLifeData.GetMoraleSkillId();
    }

    /// <summary>
    /// 获取装备的勋章
    /// </summary>
    /// <returns></returns>
    public MedalMode GetMedal()
    {
        return objLifeData.GetMedal();
    }

    /// <summary>
    /// 获取饰品id
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public int GetOrnamentId(int index)
    {
        return GetOrnamentId(index);
    }

    /// <summary>
    /// 获取角色拥有的技能
    /// </summary>
    /// <returns></returns>
    public List<int> GetHaveSkill()
    {
        return objLifeData.GetHaveSkill();
    }

    #endregion

    #region Buff模块

    /// <summary>
    /// 添加技能修正buff
    /// </summary>
    /// <param name="skillCorrect"></param>
    public void AddSkillCorrect(ObjSkillCorrect skillCorrect)
    {
        objLifeData.AddSkillCorrect(skillCorrect);
    }

    /// <summary>
    /// 清空技能修正buff
    /// </summary>
    public void ClearSkillCorrent()
    {
        objLifeData.ClearSkillCorrent();
    }

    /// <summary>
    /// 当前是否已有技能修正buff
    /// </summary>
    public bool HaveSkillCorrent()
    {
        return objLifeData.HaveSkillCorrect();
    }

    public List<ObjSkillBuff> GetBuff(ObjBuffType buffType)
    {
        var b = GetSkillBuffs().Where(x => x.buffType == buffType).ToList();
        return b;
    }

    /// <summary>
    /// 当守护BUFF被添加
    /// </summary>
    /// <param name="skillBuff"></param>
    public void OnAddBuffBefor(ObjSkillBuff skillBuff)
    {
        if (skillBuff.buffType == ObjBuffType.守护 || skillBuff.buffType == ObjBuffType.被守护)
        {
            var lifeDatas =
              BattleFlowController.Instance.GetHerosLife().Contains(this) ?
              BattleFlowController.Instance.GetHerosLife() :
              BattleFlowController.Instance.GetMonsterLife();

            var d = GetBuff(ObjBuffType.守护);
            var ud = GetBuff(ObjBuffType.被守护);

            d.ForEach((x) =>
            {
                if (x.linkTarget != null)
                {
                    x.linkTarget.RemoveSkillBuff(ObjBuffType.被守护);
                }
                RemoveSkillBuff(x);
            });
            ud.ForEach((x) =>
            {
                if (x.linkTarget != null)
                {
                    x.linkTarget.RemoveSkillBuff(ObjBuffType.守护);
                }
                RemoveSkillBuff(x);
            });

            if (skillBuff.buffType == ObjBuffType.守护)
            {
                lifeDatas.ForEach((x) =>
                {
                    var tud = x.GetBuff(ObjBuffType.被守护);
                    if (tud.Count > 0 && tud[0].linkTarget == null)
                    {
                        tud[0].linkTarget = this;
                        skillBuff.linkTarget = x;
                    }
                });
            }
            else
            {
                lifeDatas.ForEach((x) =>
                {
                    var tud = x.GetBuff(ObjBuffType.守护);
                    if (tud.Count > 0 && tud[0].linkTarget == null)
                    {
                        tud[0].linkTarget = this;
                        skillBuff.linkTarget = x;
                    }
                });
            }
        }
        else if (skillBuff.buffType == ObjBuffType.反击)
        {
            if (ExistsSkillBuff(ObjBuffType.反击))
            {
                RemoveSkillBuff(ObjBuffType.反击);
            }

			var nextSkill = BattleFlowController.Instance.currentSkill.Clone();
			skillBuff.nextSkill = get反击SkillData(nextSkill);
        }
    }


	protected SkillData get反击SkillData(SkillData skill)
	{
		skill.name = "技能反击";
		skill.describe = string.Empty;
		skill.skillType = SkillType.近战伤害;
		skill.targetType = SkillTargetType.敌方单体;
		skill.rate = new IntLevel() { level1 = 100 };
		skill.atk = new IntLevel() { level1 = -10 };
		skill.skillTails.Clear();
		skill.skillBuffs.Clear();
		skill.useLimits.Clear();
		skill.additionalDamage.Clear();
		skill.summon.Clear();
		return skill;
	}

	/// <summary>
	/// 添加技能产生的buff
	/// </summary>
	/// <param name="skillBuff"></param>
	public void AddSkillBuff(ObjSkillBuff skillBuff)
    {
        OnAddBuffBefor(skillBuff);
        objLifeData.AddSkillBuff(skillBuff);
        roleUiCon.UpdateBuff();
        roleUiCon?.UpdateValue(objLifeData);

        OnAddBuff(skillBuff);
    }
    


    /// <summary>
    /// 移除技能产生的buff
    /// </summary>
    /// <param name="skillBuff"></param>
    public void RemoveSkillBuff(ObjSkillBuff skillBuff)
    {
        Debug.LogWarning("移除BUFF =>" + skillBuff.buffType);
        objLifeData.RemoveSkillBuff(skillBuff);
        roleUiCon.UpdateBuff();
        roleUiCon?.UpdateValue(objLifeData);
    }

    /// <summary>
    /// 移除技能产生的一类buff
    /// </summary>
    /// <param name="buffType"></param>
    public void RemoveSkillBuff(ObjBuffType buffType)
    {
        objLifeData.RemoveSkillBuff(buffType);
        roleUiCon.UpdateBuff();
        roleUiCon?.UpdateValue(objLifeData);
    }

    public void EndBuff()
    {
        roleUiCon.EndBuff();
    }

    /// <summary>
    /// 清空技能产生的buff
    /// </summary>
    public void ClearSkillBuff()
    {
        objLifeData.ClearSkillBuff();
        roleUiCon?.UpdateValue(objLifeData);
    }


    /// <summary>
    /// 是否存在某个buff
    /// </summary>
    /// <param name="skillBuff"></param>
    /// <returns></returns>
    public bool ExistsSkillBuff(ObjBuffType buffType)
    {
        return objLifeData.ExistsSkillBuff(buffType);
    }
    /// <summary>
    /// 获取Buff类型的所有PermanentBuff
    /// </summary>
    /// <param name="buffType"></param>
    /// <returns></returns>
    public List<ObjPermanentBuff> GetPermanentBuff(ObjBuffType buffType)
    {
        return objLifeData.FindPermanentBuff(buffType);
    }
    /// <summary>
    /// 添加常驻buff
    /// </summary>
    /// <param name="permanentBuff"></param>
    public void AddPermanentBuff(ObjPermanentBuff permanentBuff)
    {
        objLifeData.AddPermanentBuff(permanentBuff);
        UpdateBuff();
    }

    /// <summary>
    /// 移除常驻buff
    /// </summary>
    /// <param name="source"></param>
    public void RemovePermanentBuff(BuffSourceType source)
    {
        objLifeData.RemovePermanentBuff(source);
        UpdateBuff();
    }

    /// <summary>
    /// 是否存在某个常驻buff
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public bool ExistsPermanentBuff(BuffSourceType source)
    {
        return objLifeData.ExistsPermanentBuff(source);
    }

    /// <summary>
    /// 是否存在某个常驻buff
    /// </summary>
    /// <param name="buffType"></param>
    /// <returns></returns>
    public bool ExistsPermanentBuff(ObjBuffType buffType)
    {
        return objLifeData.ExistsPermanentBuff(buffType);
    }

    /// <summary>
    /// 是否存在某个特殊效果
    /// </summary>
    /// <param name="specialEffect"></param>
    /// <returns></returns>
    public bool ExistsSpecialEffect(SpecialEffect specialEffect)
    {
        return objLifeData.ExistsSpecialEffect(specialEffect);
    }

    /// <summary>
    /// 获取常驻buff列表
    /// </summary>
    /// <returns></returns>
    public List<ObjPermanentBuff> GetPermanentBuff()
    {
        return objLifeData.GetPermanentBuff();
    }

    /// <summary>
    /// 技能buff生效
    /// </summary>
    public void BuffTakeEffect()
    {
        
        List<ObjSkillBuff> buffs = GetSkillBuffs();
		waitHandleBuffs.Clear();
		///伤害
		int damageValue = 0;
        ///治疗
        
        int cureValue = 0;
        bool shemian = ExistsSkillBuff(ObjBuffType.赦免);
        for (int i = buffs.Count - 1; i >= 0; --i)
        {
            Debug.Log(name + " :=========更新buff============"+buffs[i].buffType);
            switch (buffs[i].buffType)
            {
                case ObjBuffType.持续回复生命:
                    cureValue += buffs[i].buffValue;
                    ShowValue(buffs[i].buffValue, 0, false);//显示数字
                    roleAniCon.SetTopState(buffs[i].buffType.ToString());//提示文字显示
                    break;
                case ObjBuffType.流血:
                case ObjBuffType.中毒:
                case ObjBuffType.包裹:
                    damageValue += buffs[i].buffValue;
                    ShowValue(buffs[i].buffValue, 0, false);//显示数字
                    roleAniCon.SetTopState(buffs[i].buffType.ToString());//提示文字显示
                    break;
                case ObjBuffType.持续回复伤势:
                    UpdateInjuries(buffs[i].buffValue);
                    ShowValue(buffs[i].buffValue, 0, false);//显示数字
                    roleAniCon.SetTopState(buffs[i].buffType.ToString());//提示文字显示
                    break;
                case ObjBuffType.炸弹:
                    if (buffs[i].round == 1)
                    {
                        damageValue += buffs[i].buffValue;
                        RemoveSkillBuff(buffs[i]);
                        if (i < buffs.Count)
                        {
                            ShowValue(buffs[i].buffValue, 0, false);//显示数字
                            roleAniCon.SetTopState(buffs[i].buffType.ToString());//提示文字显示
                        }
                        continue;
                    }
                    break;
                case ObjBuffType.吞噬:
                    if (buffs[i].round == 1)
                    {
                        BattleFlowController.Instance.Tunshi_Tuchu(this);
                        ShowValue(buffs[i].buffValue, 0, false);//显示数字
                        roleAniCon.SetTopState(buffs[i].buffType.ToString());//提示文字显示
                    }
                    break;
				case ObjBuffType.持续回复士气:
					UpdateMorale(buffs[i].buffValue, "buff 持续回复士气");
					ShowValue(buffs[i].buffValue, 0, false);//显示数字
					roleAniCon.SetTopState(buffs[i].buffType.ToString());//提示文字显示
					break;
				case ObjBuffType.守护:
				case ObjBuffType.被守护:
					//守护跟被守护buff回合数特殊处理
					continue;
			}
			if (!CheckIsWaitHandleBuff(buffs[i]))
			{
				buffs[i].round--;
			}
			else
			{
				waitHandleBuffs.Add(buffs[i]);
			}
			
            if (buffs[i].round <= 0)
            {
                if (buffs[i].buffType == ObjBuffType.流血 && BattleFlowController.Instance.IsBattling)
                {
                    TalentTrigger(TalentTriggerType.流血结束);
                }
                RemoveSkillBuff(buffs[i]);
            }
        }

		checkIsShouhuBuff(buffs);

        if (ExistsSpecialEffect(SpecialEffect.每回合受到伤害) && BattleFlowController.Instance.IsBattling)
        {
            damageValue -= Random.Range(1, 3);
        }

        if (cureValue != 0)
        {
            UpdateHp(cureValue, false, 0f);
            ShowValue(cureValue, 0, false);
            if (BattleFlowController.Instance.IsBattling && ++BeCureCount >= 3)
            {
                BeCureCount = 0;
                TalentTrigger(TalentTriggerType.被治疗3次);
            }
        }
        if (damageValue != 0)
        {
            if (shemian)
            {
                damageValue = 0;
            }
            UpdateHp(damageValue, false, cureValue == 0 ? 0f : 0.3f);
            ShowValue(damageValue, 0, false);
        }
    }

	List<ObjSkillBuff> waitHandleBuffs = new List<ObjSkillBuff>();

	/// <summary>
	/// 增益或减益的攻击的buff应该在进行攻击计算完后在进行buff的round--
	/// </summary>
	/// <param name="objSkillBuff"></param>
	/// <returns></returns>
	protected bool CheckIsWaitHandleBuff(ObjSkillBuff objSkillBuff)
	{
		if (objSkillBuff.buffType == ObjBuffType.精准 || objSkillBuff.buffType == ObjBuffType.暴击 || objSkillBuff.buffType == ObjBuffType.暴击伤害 || objSkillBuff.buffType == ObjBuffType.伤害)
		{
			return true;
		}
		return false;
	}

	/// <summary>
	/// 真正进行增益或减益的攻击的buff round --
	/// </summary>
	public void HandleWaitHandleBuff()
	{
		List<ObjSkillBuff> buffs = GetSkillBuffs().FindAll(s => { return CheckIsWaitHandleBuff(s); });
		for (int i = buffs.Count - 1; i >= 0; --i)
		{
			if (!waitHandleBuffs.Contains(buffs[i]))
				continue;
			buffs[i].round--;
			if (buffs[i].round <= 0)
			{
				RemoveSkillBuff(buffs[i]);
			}
		}
		waitHandleBuffs.Clear();
	}

	/// <summary>
	/// 检测是否是守护buff 被守护的buff回合数跟守护的回合数一样
	/// </summary>
	/// <param name="buffs"></param>
	/// <returns></returns>
	private bool checkIsShouhuBuff(List<ObjSkillBuff> buffs)
	{
		if (buffs.Any(s => s.buffType == ObjBuffType.守护))
		{
			List<ObjSkillBuff> shouhuBuffs = buffs.Where(s => s.buffType == ObjBuffType.守护).ToList();
			shouhuBuffs.ForEach((x) =>
			{
				x.round--;
			});
			for (int i = shouhuBuffs.Count - 1; i >= 0; --i)
			{
				if (shouhuBuffs[i].round <= 0)
				{
					RemoveSkillBuff(shouhuBuffs[i]);
				}
			}
			int maxRound = shouhuBuffs.Max(s => s.round);
			shouhuBuffs.ForEach((x) =>
			{
				if (x.linkTarget != null && x.linkTarget.GetBuff(ObjBuffType.被守护).Count > 0)
				{
					List<ObjSkillBuff> shouhuLinkBuffs = x.linkTarget.GetBuff(ObjBuffType.被守护);
					shouhuLinkBuffs.ForEach(m =>
					{
						m.round = maxRound;
					});
					for (int i = shouhuLinkBuffs.Count - 1; i >= 0; --i)
					{
						if (shouhuLinkBuffs[i].round <= 0)
						{
							x.linkTarget.RemoveSkillBuff(shouhuLinkBuffs[i]);
						}
					}
				}
			}); ;

		}

		if (buffs.Any(s => s.buffType == ObjBuffType.被守护))
		{
			List<ObjSkillBuff> beishouhuBuffs = buffs.Where(s => s.buffType == ObjBuffType.被守护).ToList();
			beishouhuBuffs.ForEach((x) =>
			{
				if (x.linkTarget != null)
				{
					List<ObjSkillBuff> targetBuffs = x.linkTarget.GetBuff(ObjBuffType.守护);
					if (targetBuffs != null)
					{
						x.round = targetBuffs.Max(s => s.round);
					}
				}
			});
		}
		
		return false;
	}

    /// <summary>
    /// 设置常驻buff是否生效
    /// </summary>
    /// <param name="limitType"></param>
    /// <param name="isTakeEffect"></param>
    public void SetBuffIsTakeEffect(ObjLimitType limitType, bool isTakeEffect)
    {
        objLifeData.SetBuffIsTakeEffect(limitType, isTakeEffect);
    }

    /// <summary>
    /// 更新buff
    /// </summary>
    public void UpdateBuff()
    {
        roleUiCon.UpdateBuff();
    }

    /// <summary>
    /// 获取技能buff列表
    /// </summary>
    /// <returns></returns>
    public List<ObjSkillBuff> GetSkillBuffs()
    {
        return objLifeData.GetSkillBuffs();
    }

    /// <summary>
    /// 获取属性
    /// </summary>
    /// <param name="type"></param>
    /// <param name="basis"></param>
    /// <returns></returns>
    public int GetAttribute(ObjBuffType type, int basis)
    {
        return objLifeData.GetAttribute(type, basis);
    }

    /// <summary>
    /// 初始化天赋数据
    /// </summary>
    public void InitTalentData()
    {
        objLifeData.InitTalentData();
        BeCureCount = 0;
        BePositionCount = 0;
    }

    #endregion

    public RoleData GetRoleData()
    {
        return objLifeData.GetRoleData();
    }

    public HeroMode GetHeroMode()
    {
        return objLifeData.GetHeroMode();
    }

    public ObjLifeData GetObjLifeData()
    {
        return objLifeData;
    }
    public AssetReferenceSprite GetMoralSkillEffect()
    {
        return objLifeData.GetMoralSkillEffect();
    }
    /// <summary>
    /// 显示选中提示
    /// </summary>
    public void ShowSeletionTips()
    {
        if (isDestroyed) return;
        roleUiCon.ShowSeletionTips();
        if (BattleFlowController.Instance.IsBattling) return;
        playSeletionAnima();
    }

    /// <summary>
    /// 当抵抗BUFF时
    /// </summary>
    public void OnResist()
    {
        roleAniCon.SetTopState("抵抗");
    }

    /// <summary>
    /// 当闪避敌人攻击
    /// </summary>
    public void OnDodge()
    {
        roleAniCon.SetTopState("闪避");
    }

    /// <summary>
    /// 当自己的攻击Miss
    /// </summary>
    public void OnMiss()
    {
        roleAniCon.SetTopState("未命中");
    }

    /// <summary>
    /// 当被暴击时调用
    /// </summary>
    public void OnBeCrits()
    {

    }

    /// <summary>
    /// 当自身暴击时调用
    /// </summary>
    public void OnCrits()
    {

    }

    public void ShowCrits()
    {
        roleAniCon.SetTopState("暴击");
    }
    /// <summary>
    /// 当自身有增治疗
    /// </summary>
    public void OnCure()
    {
        roleAniCon.SetTopState("治疗");
    }
    /// <summary>
    /// 当自身有增益Buff时时调用
    /// </summary>
    public void OnTreated()
    {
        roleAniCon.SetTopState("增益");
    }
    public void On_neardeath()
    {
        roleAniCon.SetTopState("濒死");
    }
    public void  Onnervous()
    {
        roleAniCon.SetTopState("人心惶惶");
    }
    public void OnDebuff()
    {
        roleAniCon.SetTopState("减益");
    }
    public void OnVertigo()
    {
        roleAniCon.SetTopState("眩晕");
    }
    /// <summary>
    /// 当士气爆发
    /// </summary>
    public void OnMoraleBurstNum()
    {
        if (objLifeData.GetRoleType() == RoleType.英雄)
            roleAniCon.SetTopState("士气爆发", 2f);
    }

    /// <summary>
    /// 当死亡时调用
    /// </summary>
    public void OnDeath()
    {
        roleAniCon.PlayDeathEffect();
    }

    /// <summary>
    /// 当自身被添加BUFF时
    /// </summary>
    public void OnAddBuff(ObjSkillBuff skillBuff)
    {
        if (skillBuff.buffType != ObjBuffType.暴击 &&
            skillBuff.buffType != ObjBuffType.闪避)
        {
            roleAniCon.SetTopState(skillBuff.buffType.ToString());
        }
        if (BattleCalculating.IsDebuff(skillBuff.buffType) && skillBuff.buffValue <= 0)
        {
            OnDebuff();
        }
        else if (BattleCalculating.IsDebuff(skillBuff.buffType) && skillBuff.buffValue > 0)
        {
            OnTreated();
        }

    }

    /// <summary>
    /// 关闭选中提示
    /// </summary>
    public void CloseSelectionTips()
    {
        if (isDestroyed) return;
        roleUiCon.CloseSelectionTips();
    }
    Sequence seqs = null;
    /// <summary>
    /// 播放选中动画
    /// </summary>
    public void playSeletionAnima()
    {
        if (isDestroyed) return;
        if (seqs != null) return;
        float initScale = 1.0f, targetScale = 1.2f;
        float goRoleInitY = roleAniCon.goRole.transform.localPosition.y, goRoleTargetY = 0f;
        float duration = 0.3f;
        seqs = DOTween.Sequence();
        Sequence seq = DOTween.Sequence();
        seq.Append(roleAniCon.goRole.transform.DOScale(targetScale, duration));
        seq.AppendInterval(duration / 4f);
        seq.Append(roleAniCon.goRole.transform.DOScale(initScale, duration / 3f));
        seqs.Append(seq);


        seq = DOTween.Sequence();
        seq.Append(roleAniCon.goRole.transform.DOLocalMoveY(goRoleTargetY, duration));
        seq.AppendInterval(duration / 4f);
        seq.Append(roleAniCon.goRole.transform.DOLocalMoveY(goRoleInitY, duration / 3f));
        seqs.Join(seq);
        float goSelectTipsInitY = roleUiCon.goSelectTips.transform.localPosition.y, goSelectTipsTargetY = roleUiCon.goSelectTips.transform.localPosition.y + 1.3f;
        seq = DOTween.Sequence();
        seq.Append(roleUiCon.goSelectTips.transform.DOLocalMoveY(goSelectTipsTargetY, duration));
        seq.AppendInterval(duration / 4f);
        seq.Append(roleUiCon.goSelectTips.transform.DOLocalMoveY(goSelectTipsInitY, duration / 3f));
        seqs.Join(seq);
        seqs.OnComplete(() => { seqs = null; });
    }

    /// <summary>
    /// 显示目标提示
    /// </summary>
    /// <param name="roleRelationType"></param>
    public void ShowTargetTips(RoleRelationType roleRelationType, bool isEmemyHover = false)
    {
        if (isDestroyed) return;
        roleUiCon.ShowTargetTips(roleRelationType, isEmemyHover);
    }

    /// <summary>
    /// 关闭目标提示
    /// </summary>
    public void CloseTargetTips(bool isClose)
    {

        if (isDestroyed) return;
        roleUiCon.CloseTargetTips(isClose);
    }


    /// <summary>
    /// 动画：开始战斗
    /// </summary>
    /// <param name="time"></param>
    public void AniStartFighting(float time, float nTimeScale = 1)
    {
        if (isDestroyed) return;
        roleAniCon.StartFighting(time, nTimeScale);
    }

    /// <summary>
    /// 动画：开始战斗
    /// </summary>
    /// <param name="time"></param>
    public void AniTargetStartFighting(float time, float nTimeScale = 1)
    {
        if (isDestroyed) return;
        roleAniCon.TargetStartFighting(time, nTimeScale);
    }

    /// <summary>
    /// 技能注语动画
    /// </summary>
    public void AniSkillNote(float time)
    {
        if (isDestroyed) return;
        roleAniCon.SkillNodeAni(time);
    }
    /// <summary>
    /// 动画：攻击前移
    /// </summary>
    /// <param name="time"></param>
    public void AniMoveForward(float time)
    {
        if (isDestroyed) return;
        roleAniCon.MoveForward(time);
    }
    public void AniMoveForward(float target, float time)
    {
        if (isDestroyed) return;
        roleAniCon.MoveForward(target, time);
    }
    public void AniMoveForward(float targetx, float targety, float time)
    {
        if (isDestroyed) return;
        roleAniCon.MoveForward(targetx, targety, time);
    }

    /// <summary>
    /// 动画：被击后移
    /// </summary>
    /// <param name="time"></param>
    /// <param name="roleType"></param>
    public void AniMoveBackward(float time, RoleType roleType)
    {
        if (isDestroyed) return;
        roleAniCon.MoveBackward(time, roleType);
    }

    /// <summary>
    /// 动画：显示被击效果
    /// </summary>
    /// <param name="time"></param>
    /// <param name="effect"></param>
    public void AniShowEffect(float time, AssetReferenceGameObject effect)
    {
        if (isDestroyed) return;
        roleAniCon.ShowEffect(time, effect);
    }

    /// <summary>
    /// 动画：战斗结束
    /// </summary>
    /// <param name="time"></param>
    public void AniEndFighting(float time)
    {
        if (isDestroyed) return;
        roleAniCon.EndFighting(time);
    }

    /// <summary>
    /// 动画：换位移动
    /// </summary>
    /// <param name="time"></param>
    /// <param name="target"></param>
    public void AniExchangePositionMove(float time, Vector3 target)
    {
        if (isDestroyed) return;
        roleAniCon.ExchangePositionMove(time, target);
    }

    /// <summary>
    /// 动画：显示骨骼动画
    /// </summary>
    public void AniUseGoRole()
    {
        if (isDestroyed) return;
        roleAniCon.UseGoRole();
    }

    /// <summary>
    /// 动画：显示杀戮骨骼动画
    /// </summary>
    public void AniUseGoShalu()
    {
        if (isDestroyed) return;
        roleAniCon.UseShalu();
    }
    /// <summary>
    /// 动画：显示士气技能插画
    /// </summary>
    public void AniUseMoralSkill()
    {
        if (isDestroyed) return;
        roleAniCon.UseMoralSkill(objLifeData.GetMoralSkillEffect());
    }
    /// <summary>
    /// 动画：显示攻击贴图
    /// </summary>
    public void AniUseGoAttack(AssetReferenceSprite ars)
    {
        if (isDestroyed) return;
        roleAniCon.UseGoAttack(ars);
    }

    /// <summary>
    /// 动画：显示被击贴图
    /// </summary>
    public void AniUseGoAttacked()
    {
        if (isDestroyed) return;
        roleAniCon.UseGoAttacked();
    }
    /// <summary>
    /// 动画：显示血爆特效
    /// </summary>
    public void ShowBloodExplosionEffect()
    {
        roleAniCon.ShowBloodExplosionEffect(GetRoleType());
    }
    public void ShowXuewu()
    {
        roleAniCon.ShowXuewu(GetRoleType());
    }
    /// <summary>
    /// 动画：显示技能特效
    /// </summary>
    /// <param name="ars"></param>
    /// <param name="time"></param>
    public void AniShowSkillEffect(AssetReferenceSprite ars, float time, Vector3 offset)
    {
        if (isDestroyed) return;
        roleAniCon.ShowSkillEffect(ars, time, offset);
    }

    /// <summary>
    /// 动画：显示技能特效
    /// </summary>
    /// <param name="argo"></param>
    /// <param name="time"></param>
    public void AniShowSkillEffect(AssetReferenceGameObject argo, float time, Vector3 offset, ObjLife source)
    {
        if (isDestroyed) return;
        roleAniCon.ShowSkillEffect(argo, time, offset, source);
    }

    /// <summary>
    /// 更改渲染层级
    /// </summary>
    /// <param name="order"></param>
    public void UpdateSortingOrder(int value)
    {
        if (isDestroyed) return;
        roleAniCon.UpdateSortingOrder(value);
    }
    public void UpdateSortingLayer(string _layer)
    {
        int iLayer = -1;
        switch (_layer)
        {
            case FightingCameraCon.DefaultLayerName: iLayer = (int)Enum_Layer.Default; break;
            case FightingCameraCon.FightingCameraLayerName: iLayer = (int)Enum_Layer.FightingCamera; break;
            case FightingCameraCon.FightingRoundCameraLayerName: iLayer = (int)Enum_Layer.FightingRoundCamera; break;
        }
        if (iLayer == -1) return;
        Transform[] transArray = gameObject.GetComponentsInChildren<Transform>(true);
        foreach (Transform trans in transArray)
        {
            // UI层不显示
            if (trans.gameObject.layer != (int)Enum_Layer.UI)
                trans.gameObject.layer = iLayer;
        }
    }
    /// <summary>
    /// 触发天赋
    /// </summary>
    /// <param name="type"></param>
    public void TalentTrigger(TalentTriggerType type)
    {
        Debug.Log($"测试-{objLifeData.GetHeroName()}-TalentTrigger - 1 -{type}");
        if (isDestroyed) return;
        Debug.Log($"测试-{objLifeData.GetHeroName()}-TalentTrigger - 2 -{type}");
        TalentData talentData = objLifeData.GetTalentData();
        if (talentData == null) return;
        Debug.Log($"测试-{objLifeData.GetHeroName()}-TalentTrigger - 3 -{type}");
        Debug.Log($"测试-{objLifeData.GetHeroName()}-TalentTrigger - 3 -{type}-{talentData.Trigger.type}");
        if (talentData.Trigger.type == type)
        {
            Debug.Log($"测试-{objLifeData.GetHeroName()}-TalentTrigger - 4 -{type}");
            roleUiCon.ShowTalentTrigger();
            TalentEffect effect = Random.Range(0f, 1f) >= 0.5f ? talentData.Order : talentData.Chaos;
            BattleFlowController.Instance.TalentTrigger(this, effect);
        }
    }

	int curRound = 0;
	public bool UpdateRoundEndAct(int round)
	{
		if (curRound < round)
		{
			curRound = round;
			return true;
		}
		return false;
	}

	/// <summary>
	/// 每次战斗开始时执行
	/// </summary>
	public void OnBattleStart()
	{
		curRound = 0;
	}

}
