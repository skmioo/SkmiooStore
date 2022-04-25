using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 增益状态---理论上所有带增益的状态都可以通过继承该类来处理增益效果
/// PS:这个类不能处理持续恢复！无法通过继承实现
/// </summary>
/*public class GainBuff : BuffBase
{
    //启动buff效果
    protected override void StartBuff()
    {
        if (skillBuff.skillBuffType != SkillBuffType.持续回复)
        {

            foreach (var item in skillBuff.buffValues)
            {
                switch (item.statusType)
                {
                    case SkillStatusTpye.最大生命:
                        if (item.valueType == ValueType.加减)
                        {
                            objLife.GetHp() += GetBuffLevel(item);
                        }
                        else
                        {
                            objLife.GetHp() += FloatToInt(objLife.GetHp(), GetBuffLevel(item), 100);
                        }
                        break;
                    case SkillStatusTpye.士气:
                        if (item.valueType == ValueType.加减)
                        {
                            objLife.GetMorale() += GetBuffLevel(item);
                        }
                        else
                        {
                            objLife.GetMorale() += FloatToInt(objLife.GetMorale(), GetBuffLevel(item), 100);
                        }
                        break;
                    case SkillStatusTpye.伤势:
                        if (item.valueType == ValueType.加减)
                        {
                            objLife.GetInjuries() += GetBuffLevel(item);
                        }
                        else
                        {
                            objLife.GetInjuries() += FloatToInt(objLife.GetInjuries(), GetBuffLevel(item), 100);
                        }
                        break;
                    case SkillStatusTpye.位置:
                        //?有可以改变位置的道具吗?
                        break;
                    case SkillStatusTpye.攻击:
                        if (item.valueType == ValueType.加减)
                        {
                            objLife.GetMinAtk() += GetBuffLevel(item);
                            objLife.GetMinAtk() += GetBuffLevel(item);
                        }
                        else
                        {
                            objLife.GetMinAtk() += FloatToInt(objLife.GetMinAtk(), GetBuffLevel(item), 100);
                            objLife.GetMinAtk() += FloatToInt(objLife.GetMinAtk(), GetBuffLevel(item), 100);

                        }
                        break;
                    case SkillStatusTpye.精准:
                        if (item.valueType == ValueType.加减)
                        {
                            objLife.GetRate() += GetBuffLevel(item);
                        }
                        else
                        {
                            objLife.GetRate() += FloatToInt(objLife.GetRate(), GetBuffLevel(item), 100);

                        }
                        break;
                    case SkillStatusTpye.暴击:
                        if (item.valueType == ValueType.加减)
                        {
                            objLife.GetCrits() += GetBuffLevel(item);
                        }
                        else
                        {
                            objLife.GetCrits() += FloatToInt(objLife.GetCrits(), GetBuffLevel(item), 100);
                        }
                        break;
                    case SkillStatusTpye.减伤:
                        if (item.valueType == ValueType.加减)
                        {
                            objLife.GetDefence() += GetBuffLevel(item);
                        }
                        else
                        {
                            objLife.GetDefence() += FloatToInt(objLife.GetDefence(), GetBuffLevel(item), 100);
                        }
                        break;
                    case SkillStatusTpye.闪避:
                        if (item.valueType == ValueType.加减)
                        {
                            objLife.GetDodge() += GetBuffLevel(item);
                        }
                        else
                        {
                            objLife.GetDodge() += FloatToInt(objLife.GetDodge(), GetBuffLevel(item), 100);
                        }
                        break;
                    case SkillStatusTpye.速度:
                        if (item.valueType == ValueType.加减)
                        {
                            objLife.GetSpeed() += GetBuffLevel(item);
                        }
                        else
                        {
                            objLife.GetSpeed() += FloatToInt(objLife.GetSpeed(), GetBuffLevel(item), 100);
                        }
                        break;
                    case SkillStatusTpye.回复生命:
                        //--
                        break;
                    case SkillStatusTpye.持续伤害:
                        //--
                        break;
                    case SkillStatusTpye.流血抗性:
                        if (item.valueType == ValueType.加减)
                        {
                            objLife.GetBleed() += GetBuffLevel(item);
                        }
                        else
                        {
                            objLife.GetBleed() += FloatToInt(objLife.GetBleed(), GetBuffLevel(item), 100);
                        }
                        break;
                    case SkillStatusTpye.中毒抗性:
                        if (item.valueType == ValueType.加减)
                        {
                            objLife.GetPoison() += GetBuffLevel(item);
                        }
                        else
                        {
                            objLife.GetPoison() += FloatToInt(objLife.GetPoison(), GetBuffLevel(item), 100);
                        }
                        break;
                    case SkillStatusTpye.减益抗性:
                        if (item.valueType == ValueType.加减)
                        {
                            objLife.GetDebuff() += GetBuffLevel(item);
                        }
                        else
                        {

                            objLife.GetDebuff() += FloatToInt(objLife.GetDebuff(), GetBuffLevel(item), 100);
                        }
                        break;
                    case SkillStatusTpye.眩晕抗性:
                        if (item.valueType == ValueType.加减)
                        {
                            objLife.GetVertigo() += GetBuffLevel(item);
                        }
                        else
                        {
                            objLife.GetVertigo() += FloatToInt(objLife.GetVertigo(), GetBuffLevel(item), 100);
                        }
                        break;
                    case SkillStatusTpye.位移抗性:
                        if (item.valueType == ValueType.加减)
                        {
                            objLife.GetPosition() += GetBuffLevel(item);
                        }
                        else
                        {
                            objLife.GetPosition() += FloatToInt(objLife.GetPosition(), GetBuffLevel(item), 100);
                        }
                        break;
                    case SkillStatusTpye.死亡抗性:
                        if (item.valueType == ValueType.加减)
                        {
                            objLife.GetDeath() += GetBuffLevel(item);
                        }
                        else
                        {
                            objLife.GetDeath() += FloatToInt(objLife.GetDeath(), GetBuffLevel(item), 100);
                        }
                        break;
                    case SkillStatusTpye.流血概率:
                        //增加技能异常状态命中概率暂时不写,角色基础属性中没有该字段
                        //若后期确实需要,考虑可以把这些属性做到存档数据中去
                        break;
                    case SkillStatusTpye.中毒概率:
                        break;
                    case SkillStatusTpye.减益概率:
                        break;
                    case SkillStatusTpye.眩晕概率:
                        break;
                    case SkillStatusTpye.士气上限:
                        if (item.valueType == ValueType.加减)
                        {
                            objLife.GetMaxMorale() += GetBuffLevel(item);
                        }
                        else
                        {
                            objLife.GetMaxMorale() += FloatToInt(objLife.GetMaxMorale(), GetBuffLevel(item), 100);
                        }
                        break;
                    case SkillStatusTpye.士气下限:
                        if (item.valueType == ValueType.加减)
                        {
                            objLife.GetMinMorale() += GetBuffLevel(item);
                        }
                        else
                        {
                            objLife.GetMinMorale() += FloatToInt(objLife.GetMinMorale(), GetBuffLevel(item), 100);
                        }
                        break;
                    case SkillStatusTpye.伤势上限:
                        if (item.valueType == ValueType.加减)
                        {
                            objLife.GetMaxInjuries() += GetBuffLevel(item);
                        }
                        else
                        {
                            objLife.GetMaxInjuries() += FloatToInt(objLife.GetMinAtk(), GetBuffLevel(item), 100);
                        }
                        break;
                    default:
                        break;
                }
            }

        }
        Start_Z();
    }

    /// <summary>
    /// 给子类的启动方法
    /// </summary>
    protected virtual void Start_Z()
    {
        
    }

    protected override void EndDamege()
    {
        if (skillBuff.skillBuffType != SkillBuffType.持续回复)
        {
            foreach (var item in skillBuff.buffValues)
            {

                switch (item.statusType)
                {
                    case SkillStatusTpye.最大生命:
                        if (item.valueType == ValueType.加减)
                        {
                            objLife.GetHp() -= GetBuffLevel(item);
                        }
                        else
                        {
                            objLife.GetHp() -= FloatToInt(objLife.GetHp(), GetBuffLevel(item), 100);
                        }
                        break;
                    case SkillStatusTpye.士气:
                        if (item.valueType == ValueType.加减)
                        {
                            objLife.GetMorale() -= GetBuffLevel(item);
                        }
                        else
                        {
                            objLife.GetMorale() -= FloatToInt(objLife.GetMorale(), GetBuffLevel(item), 100);
                        }
                        break;
                    case SkillStatusTpye.伤势:
                        if (item.valueType == ValueType.加减)
                        {
                            objLife.GetInjuries() -= GetBuffLevel(item);
                        }
                        else
                        {
                            objLife.GetInjuries() -= FloatToInt(objLife.GetInjuries(), GetBuffLevel(item), 100);
                        }
                        break;
                    case SkillStatusTpye.位置:
                        //?有可以改变位置的道具吗?
                        break;
                    case SkillStatusTpye.攻击:
                        if (item.valueType == ValueType.加减)
                        {
                            objLife.GetMinAtk() -= GetBuffLevel(item);
                            objLife.GetMinAtk() -= GetBuffLevel(item);
                        }
                        else
                        {
                            objLife.GetMinAtk() -= FloatToInt(objLife.GetMinAtk(), GetBuffLevel(item), 100);
                            objLife.GetMinAtk() -= FloatToInt(objLife.GetMinAtk(), GetBuffLevel(item), 100);

                        }
                        break;
                    case SkillStatusTpye.精准:
                        if (item.valueType == ValueType.加减)
                        {
                            objLife.GetRate() -= GetBuffLevel(item);
                        }
                        else
                        {
                            objLife.GetRate() -= FloatToInt(objLife.GetRate(), GetBuffLevel(item), 100);

                        }
                        break;
                    case SkillStatusTpye.暴击:
                        if (item.valueType == ValueType.加减)
                        {
                            objLife.GetCrits() -= GetBuffLevel(item);
                        }
                        else
                        {
                            objLife.GetCrits() -= FloatToInt(objLife.GetCrits(), GetBuffLevel(item), 100);
                        }
                        break;
                    case SkillStatusTpye.减伤:
                        if (item.valueType == ValueType.加减)
                        {
                            objLife.GetDefence() -= GetBuffLevel(item);
                        }
                        else
                        {
                            objLife.GetDefence() -= FloatToInt(objLife.GetDefence(), GetBuffLevel(item), 100);
                        }
                        break;
                    case SkillStatusTpye.闪避:
                        if (item.valueType == ValueType.加减)
                        {
                            objLife.GetDodge() -= GetBuffLevel(item);
                        }
                        else
                        {
                            objLife.GetDodge() -= FloatToInt(objLife.GetDodge(), GetBuffLevel(item), 100);
                        }
                        break;
                    case SkillStatusTpye.速度:
                        if (item.valueType == ValueType.加减)
                        {
                            objLife.GetSpeed() -= GetBuffLevel(item);
                        }
                        else
                        {
                            objLife.GetSpeed() -= FloatToInt(objLife.GetSpeed(), GetBuffLevel(item), 100);
                        }
                        break;
                    case SkillStatusTpye.回复生命:
                        //--
                        break;
                    case SkillStatusTpye.持续伤害:
                        //--
                        break;
                    case SkillStatusTpye.流血抗性:
                        if (item.valueType == ValueType.加减)
                        {
                            objLife.GetBleed() -= GetBuffLevel(item);
                        }
                        else
                        {
                            objLife.GetBleed() -= FloatToInt(objLife.GetBleed(), GetBuffLevel(item), 100);
                        }
                        break;
                    case SkillStatusTpye.中毒抗性:
                        if (item.valueType == ValueType.加减)
                        {
                            objLife.GetPoison() -= GetBuffLevel(item);
                        }
                        else
                        {
                            objLife.GetPoison() -= FloatToInt(objLife.GetPoison(), GetBuffLevel(item), 100);
                        }
                        break;
                    case SkillStatusTpye.减益抗性:
                        if (item.valueType == ValueType.加减)
                        {
                            objLife.GetDebuff() -= GetBuffLevel(item);
                        }
                        else
                        {

                            objLife.GetDebuff() -= FloatToInt(objLife.GetDebuff(), GetBuffLevel(item), 100);
                        }
                        break;
                    case SkillStatusTpye.眩晕抗性:
                        if (item.valueType == ValueType.加减)
                        {
                            objLife.GetVertigo() -= GetBuffLevel(item);
                        }
                        else
                        {
                            objLife.GetVertigo() -= FloatToInt(objLife.GetVertigo(), GetBuffLevel(item), 100);
                        }
                        break;
                    case SkillStatusTpye.位移抗性:
                        if (item.valueType == ValueType.加减)
                        {
                            objLife.GetPosition() -= GetBuffLevel(item);
                        }
                        else
                        {
                            objLife.GetPosition() -= FloatToInt(objLife.GetPosition(), GetBuffLevel(item), 100);
                        }
                        break;
                    case SkillStatusTpye.死亡抗性:
                        if (item.valueType == ValueType.加减)
                        {
                            objLife.GetDeath() -= GetBuffLevel(item);
                        }
                        else
                        {
                            objLife.GetDeath() -= FloatToInt(objLife.GetDeath(), GetBuffLevel(item), 100);
                        }
                        break;
                    case SkillStatusTpye.流血概率:
                        //增加技能异常状态命中概率暂时不写,角色基础属性中没有该字段
                        //若后期确实需要,考虑可以把这些属性做到存档数据中去
                        break;
                    case SkillStatusTpye.中毒概率:
                        break;
                    case SkillStatusTpye.减益概率:
                        break;
                    case SkillStatusTpye.眩晕概率:
                        break;
                    case SkillStatusTpye.士气上限:
                        if (item.valueType == ValueType.加减)
                        {
                            objLife.GetMaxMorale() -= GetBuffLevel(item);
                        }
                        else
                        {
                            objLife.GetMaxMorale() -= FloatToInt(objLife.GetMaxMorale(), GetBuffLevel(item), 100);
                        }
                        break;
                    case SkillStatusTpye.士气下限:
                        if (item.valueType == ValueType.加减)
                        {
                            objLife.GetMinMorale() -= GetBuffLevel(item);
                        }
                        else
                        {
                            objLife.GetMinMorale() -= FloatToInt(objLife.GetMinMorale(), GetBuffLevel(item), 100);
                        }
                        break;
                    case SkillStatusTpye.伤势上限:
                        if (item.valueType == ValueType.加减)
                        {
                            objLife.GetMaxInjuries() -= GetBuffLevel(item);
                        }
                        else
                        {
                            objLife.GetMaxInjuries() -= FloatToInt(objLife.GetMinAtk(), GetBuffLevel(item), 100);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        End_Z();
    }
    /// <summary>
    /// 给子类的结束方法
    /// </summary>
    protected virtual void End_Z()
    {

    }
}*/
