using Datas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// buff类技能基类,主要实现Buff生命周期,buff具体功能在子类中重写
/// </summary>
/*public class BuffBase : MonoBehaviour
{
    public SkillBuff skillBuff;
    protected ObjLife objLife;
    protected ObjLife attackerObjlife;

    [HideInInspector]
    public int skillLevel;

    [HideInInspector]
    public int _rounds;//记录回合数
    protected int _nowRounds;

    public ShowBuffType ShowBuffType;

    /// <summary>
    /// 初始化buff
    /// </summary>
    /// <param name="_skillBuff">技能buff</param>
    /// <param name="_objLife">角色</param>
    public void InitItam(int _skillLevel,SkillBuff _skillBuff,ObjLife _objLife,ObjLife _attackerObjlife)
    {
        skillBuff = _skillBuff;
        objLife = _objLife;
        attackerObjlife = _attackerObjlife;
        skillLevel = _skillLevel;

        _nowRounds = BattleFlowController.Instance.roundCount;
        _rounds = 0;
        StartBuff();
    }

    /// <summary>
    /// 启动buff
    /// </summary>
    protected virtual void StartBuff()
    {
       
    }


    /// <summary>
    /// 新回合消息,由RoleTeamController.RoleGo()在角色行动前通知
    /// 
    /// </summary>
    void NewRoundNews(int nowRounds)
    {
        if (_nowRounds >= BattleFlowController.Instance.roundCount)
            return;

        _nowRounds++;
        _rounds++;
        if (_rounds < skillBuff.effectiveRounds)
        {
            Damage();
        }
        else
        {
            EndDamege();
            EndAndDestroy();
        }

        if (objLife != null)
        {
            //objLife.roleUi.statusBox.ShowBuffOnlyOne();
        }
    }

    /// <summary>
    /// 持续效果/需要每个回合持续减少或者增加的值，重写此方法
    /// </summary>
    protected virtual void Damage()
    {

    }

    /// <summary>
    /// 结束buff,影响类Buff数值还原
    /// </summary>
    protected virtual void EndDamege()
    {

    }

    protected virtual void EndAndDestroy()
    {
        objLife?.roleUi.statusBox.RemoveBuffFromList(this);
        Destroy(gameObject);
    }

    /// <summary>
    /// 取Buff对应的等级值
    /// 系数类值,手动/100
    /// </summary>
    public int GetBuffLevel(BuffValue buffValue)
    {
        int value = 0;
        switch (skillLevel)
        {
            case 1:
                value = buffValue.value.level1;
                break;
            case 2:
                value = buffValue.value.level2;
                break;
            case 3:
                value = buffValue.value.level3;
                break;
            case 4:
                value = buffValue.value.level4;
                break;
            case 5:
                value = buffValue.value.level5;
                break;
            default:
                break;
        }

        return value;
    }

    
    protected int FloatToInt(int initialValue, int ratoValue, int baseValue)
    {
        float value = initialValue * ((float)ratoValue / (float)baseValue);

        return Mathf.RoundToInt(value);
    }
}*/
