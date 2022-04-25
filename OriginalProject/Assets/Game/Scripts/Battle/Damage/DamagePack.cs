
using Datas;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 伤害包
/// </summary>
/*public class DamagePack
{
    public DamagePackType damagePackType;
    
    /// <summary>
    /// 最终作用值
    /// </summary>
    public float damageValue;
    /// <summary>
    /// 最终回复值
    /// </summary>
    public float replyValue;
    /// <summary>
    /// 是否发生了暴击--给接收者作为暴击提示用
    /// </summary>
    public bool critsB;
    /// <summary>
    /// 最终精准值
    /// </summary>
    public int hitRate;
    
    //public List<TailValue> skillTailValues;

    ///// <summary>
    ///// 作用自己的移动值
    ///// </summary>
    //public int mPos = 0;
    ///// <summary>
    ///// 作用目标的移动值
    ///// </summary>
    //public int tPos = 0;

    public SkillData skillData;
    public int skillLevel;
    public ObjLife attackerObjlife;

    public DamagePack(SkillData skillData, int skillLevel, ObjLife attackerObjlife)
    {
        this.skillData = skillData;
        this.skillLevel = skillLevel;
        this.attackerObjlife = attackerObjlife;
    }

    
    /// <summary>
    /// 伤害包打包、、未完成所有参数计算,待完善
    /// </summary>
    /// <param name="_skillData"></param>
    /// <param name="skillLevel"></param>
    /// <param name="roleData"></param>
    public DamagePack(SkillData _skillData, int _skillLevel, ObjLife _attackerObjlife)
    {
        //技能已经有类型了,这个准备弃用
        damagePackType = DamagePackType.buff;

        skillData = _skillData.Clone();
        skillLevel = _skillLevel;
        attackerObjlife = _attackerObjlife;
        skillTailValues = new List<TailValue>(_skillData.skillTails);

        switch (skillData.skillType)
        {
            case SkillType.近战伤害:
                _DamagePack();
                break;
            case SkillType.远程伤害:
                _DamagePack();
                break;
            case SkillType.BUFF:
                break;
            case SkillType.治疗:
                ReplyPack();
                break;
            case SkillType.综合:
                _DamagePack();//这个类型暂时打伤害包,--根据需求调整
                break;
            default:
                break;
        }


    }*/

    /*
/// <summary>
/// 回复类技能,打成回复包
/// </summary>
void ReplyPack()
{
    damagePackType = DamagePackType.HPUP;
    replyValue = Random.Range(AnalysisLevel(skillData.minCureHP, skillLevel), AnalysisLevel(skillData.maxCureHP, skillLevel));

    int crits = attackerObjlife.roleData.roleLife.crits + (AnalysisLevel(skillData.crits, skillLevel) / 100 + 1);
    critsB = AnalysisProbability(crits, 100);
    if (critsB)
    {
        replyValue *= 1.5f;//！！！1.5F暴击系数待调整
    }
}

/// <summary>
/// 伤害类技能,打成伤害包
/// </summary>
void _DamagePack()
{
    damagePackType = DamagePackType.HPDwon;
    int dv = Random.Range(attackerObjlife.roleData.roleLife.minAtk, attackerObjlife.roleData.roleLife.maxAtk + 1);
    Debug.Log("角色攻击值：在[" + attackerObjlife.roleData.roleLife.minAtk + "," + attackerObjlife.roleData.roleLife.maxAtk + "]中取到随机值" + dv);
    //damageValue = Calculation(dv, AnalysisValue(skillData.atk, skillLevel));
    float atk = IntToFloat(AnalysisLevel(skillData.atk, skillLevel)) + 1;
    Debug.Log("当前技能等级" + skillLevel + "，技能伤害修正：" + atk);


    damageValue = dv * atk;
    Debug.Log("计算伤害值" + dv + "*" + atk + "=" + damageValue);

    //计算暴击概率最终值
    int crits = attackerObjlife.roleData.roleLife.crits + AnalysisLevel(skillData.crits, skillLevel);
    Debug.Log("计算暴击率：角色暴击率" + attackerObjlife.roleData.roleLife.crits + "+技能暴击修正" + AnalysisLevel(skillData.crits, skillLevel) + "=" + crits);
    //判断是否暴击
    critsB = AnalysisProbability(crits, 100);
    if (critsB)
    {
        damageValue *= 1.5f;//！！！1.5F暴击系数待调整
        Debug.Log("触发了暴击，伤害值*1.5=" + damageValue);
    }
    else
    {
        Debug.Log("未触发暴击，伤害值=" + damageValue);
    }

    //精准值不是最终作用值--与被击者的闪避值相减

    float rate = IntToFloat(AnalysisLevel(skillData.rate, skillLevel));

    hitRate = Mathf.RoundToInt(rate * attackerObjlife.roleData.roleLife.rate);
    Debug.Log("计算精准值：技能精准值" + rate + "*角色精准值" + attackerObjlife.roleData.roleLife.rate + "=" + hitRate);

    //mPos = skillData.mePos;
    //tPos = skillData.targetPos;
}

/// <summary>
/// int类系数值转换
/// </summary>
/// <returns></returns>
float IntToFloat(int value)
{
    if (value == 0)
    {
        return 1;
    }

    float f = value / 100f;
    return f;
}

/// <summary>
/// 解析技能等级对应的值
/// </summary>
/// <param name="intLevel"></param>
/// <param name="level"></param>
/// <returns></returns>
int AnalysisLevel(IntLevel intLevel, int level)
{
    switch (level)
    {
        case 1: return intLevel.level1;
        case 2: return intLevel.level2;
        case 3: return intLevel.level3;
        case 4: return intLevel.level4;
        case 5: return intLevel.level5;
        default:Debug.Log($"使用了一个超出技能等级长度的值{level}");
            return 100;
    }
}

/// <summary>
/// 分析概率,返回True = 触发
/// </summary>
/// <param name="bValue">要计算的概率值</param>
/// <param name="cValue">概率的区间值,0-100</param>
/// <returns></returns>
bool AnalysisProbability(int bValue, int cValue)
{
    float vr = Random.Range(0, cValue);
    Debug.Log("在[0," + cValue + "]中取到随机数" + vr);
    if (bValue > vr)
    {
        Debug.Log(bValue + ">" + vr + "，暴击");
        return true;
    }
    Debug.Log(bValue + "<=" + vr + "，未暴击");
    return false;
}*/
/*}


/// <summary>
/// 伤害包类型/伤害类型
/// </summary>
public enum DamagePackType
{
    HPDwon, HPUP, morale, injuries, buff
}
*/
