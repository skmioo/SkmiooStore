using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 技能开始前的判断基类---
/// 子类重写StartSkill开始单个技能开始前特殊判断
/// 子类必须调用End方法使技能发动攻击
/// </summary>
public class StartSkillBase : MonoBehaviour
{
    /// <summary>
    /// 启动时是打好的伤害包
    /// </summary>
    //protected DamagePack damagePack;
    /// <summary>
    /// 攻击者,
    /// </summary>
    protected ObjLife objLife;
    /// <summary>
    /// 被攻击者
    /// </summary>
    protected ObjLife attackedObjlife;
    //技能的目标们
    bool[] targetPos;
    //技能攻击的队伍
    RoleTeamController roleTeamController;

    public void InitStartSkill(/*DamagePack _damagePack,ObjLife _objLife,ObjLife _attackedObjlife, bool[] _targetPos,RoleTeamController _roleTeamController*/)
    {
        /*roleTeamController = _roleTeamController;
        targetPos = _targetPos;
        damagePack = _damagePack;
        objLife = _objLife;
        attackedObjlife = _attackedObjlife;

        StartSkill();*/
    }

    /// <summary>
    /// 启动
    /// </summary>
    protected virtual void StartSkill()
    {

    }

    protected virtual void EndSkill()
    {
        //发动攻击流程

        GoSkill();

        Destroy(gameObject);
    }

    //发动技能攻击流程/从RoleInfoView截获--从AIBase截获待完善
    void GoSkill()
    {
        /*List<ObjLife> targets = new List<ObjLife>();

        //计算目标 --- 
        //if (damagePack.skillData.targetType.Equals(SkillTargetType.敌方群体))//多个目标
        {
            for (int i = 0; i < targetPos.Length; i++)
            {
                if (i >= roleTeamController.roleTeam.Count)
                    break;

                if (targetPos[i])
                {
                    //roleTeamController.roleTeam[i].objLife.DamageNews(damagePack);
                    targets.Add(roleTeamController.roleTeam[i].objLife);
                }
            }
        }
        //else//单个目标
        {
            //attackedObjlife.DamageNews(damagePack);
            targets.Add(attackedObjlife);
        }

        //通知攻击者播放动画
        FightingCameraCon.Instance.Fighting();
        //objLife.roleController.Fighting(true, damagePack.skillData, damagePack.skillLevel, targets);
        */

    }

}
