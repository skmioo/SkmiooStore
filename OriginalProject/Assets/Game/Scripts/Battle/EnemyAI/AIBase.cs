using Datas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 单个怪物的AI基类-- 基类完成AI主流程生命周期
/// 重写Action -- 完成要使用的技能判断
/// 重写Attack -- 完成要攻击的目标判断
/// 重写EndAttack -- 完成释放一个技能后，还需要处理的事--如果没有需要处理的事，可空
/// </summary>
public class AIBase : MonoBehaviour
{
    protected ObjLife objLife;

    protected BattleFlowController bController;

    private void Awake()
    {
        objLife = GetComponent<ObjLife>();
    }

    /// <summary>
    /// 初始化角色
    /// </summary>
    public virtual void InitRole()
    {
        bController = BattleFlowController.Instance;
    }

    /// <summary>
    /// 开始战斗
    /// </summary>
    public virtual void StartBattle()
    {
    }

    /// <summary>
    /// 结束战斗
    /// </summary>
    public virtual void EndBattleing()
    {
    }

    /// <summary>
    /// 死亡处理
    /// </summary>
    public virtual void OnDeath()
    {
    }

    /// <summary>
    /// 新的回合
    /// </summary>
    public virtual void OnNewRound(int round)
    {
    }

    /// <summary>
    /// 开始行动
    /// </summary>
    public virtual void ReGo()
    {
        Debug.Log("测试- 怪物AI 开始行动");
        // 执行偏好位置
        if(this.DoPreferMove()){
            return;
        }

        // 进入释放技能环节
        if(this.UseSkill()){
            return;
        }
        
        // 如果什么技能都没能释放成功 执行跳过操作
        this.Skip();
    }

    /// <summary>
    /// AI 放技能流程
    /// </summary>
    public virtual bool UseSkill()
    {
        // 如果没有复写 就走以前的流程
        bController.AIUseSkill();
        return true;
    }

    /// <summary>
    /// AI 位置偏好
    /// </summary>
    public virtual bool DoPreferMove()
    {
        Team our = bController.GetTeamFromRole(objLife);
        // 如果没有处于偏好位置
        if (!our.IsPrefer(objLife))
        {
            //获取偏好方向目标
            ObjLife moveObj = this.GetPreferMoveTarget();
            if(moveObj != null){
                // 检查当前是否有技能可以释放 
                if (this.CheckCanSkill())
                {
                    if(this.Range(33)){
                        bController.ExchangeMoveFromButton(moveObj);
                        return true;
                    }
                }else{
                    bController.ExchangeMoveFromButton(moveObj);
                    return true;
                }
            }
        }
        return false;
    }

    /// <summary>
    /// AI 放技能目标选择
    /// </summary>
    public virtual ObjLife SelectTarget()
    {
        // 暂时随机
        return bController.canBeSelected[UnityEngine.Random.Range(0, bController.canBeSelected.Count)];
    }

    /// <summary>
    ///  检测是否有技能可以释放
    /// </summary>
    public virtual bool CheckCanSkill()
    {
        // 暂时设定都能释放
        return true;
    }

    /// <summary>
    /// 释放技能伤害
    /// </summary>
    public void FightingCalculating(SkillData skillData)
    {
        bController.currentSkill = skillData;
        bController.CloseAllObjTargetTips();
        ObjLife target = this.SelectTarget();
        bController.FightingCalculating(target);
        objLife.ReleaseSkillEffect(skillData);
    }

    /// <summary>
    ///  跳过该AI
    /// </summary>
    public void Skip()
    {
        // 通知控制器 跳过该AI
        bController.DelayAction(bController.ROLE_ACTION_TIME, bController.FindSpeedMaxFromActionList);
    }

    #region 工具方法
    /// <summary>
    /// 百分比随机
    /// </summary>
    public bool Range(int range)
    {
        return range >= Random.Range(1, 100);
    }

    /// <summary>
    /// 获取偏好方向目标
    /// </summary>
    public ObjLife GetPreferMoveTarget()
    {
        PreferMove preferMove = objLife.GetPreferMove();
        Team our = bController.GetTeamFromRole(objLife);
        int index = our.GetIndex(objLife);
        if (objLife.GetPreferMove() == PreferMove.前 && index > 0)
        {
            return our.GetObjLife(index - 1);
        }
        if (objLife.GetPreferMove() == PreferMove.后 && index < our.GetCount() - 1)
        {
            return our.GetObjLife(index + 1);
        }
        return null;
    }

    #endregion
}
