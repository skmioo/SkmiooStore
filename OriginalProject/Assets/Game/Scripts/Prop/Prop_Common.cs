using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 通用型道具
/// 处理所有带objActions功能值的脚本,故所有带这种值的道具都可以继承此脚本
/// </summary>
public class Prop_Common : PropBase
{
    /*protected override void GoAction()
    {
        GoOtherAction();
        foreach (var item in objData.objActions)
        {
            switch (item.actionType)
            {
                case SkillStatusTpye.士气:
                    if (item.valueType == ValueType.加减)
                    {
                        objLife.UpdateMorale(item.value);
                    }
                    else
                    {
                        objLife.UpdateMorale(FloatToInt(objLife.GetMorale(), item.value, 100));
                    }
                    if (objLife.GetMorale() > objLife.GetMaxMorale())
                        objLife.SetMorale(objLife.GetMaxMorale());
                    //objLife.roleUi.ShowValue(item.value, DamagePackType.HPUP);
                    //objLife.roleUi.SetHp(DamagePackType.HPUP);
                    break;
                case SkillStatusTpye.伤势:
                    if (item.valueType == ValueType.加减)
                    {
                        objLife.UpdateInjuries(item.value);
                    }
                    else
                    {
                        objLife.UpdateInjuries(FloatToInt(objLife.GetInjuries(), item.value, 100));
                    }
                    if (objLife.GetInjuries() > objLife.GetMaxInjuries())
                        objLife.SetInjuries(objLife.GetMaxInjuries());
                    //objLife.roleUi.ShowValue(item.value, DamagePackType.HPUP);
                    //objLife.roleUi.SetHp(DamagePackType.HPUP);
                    break;
                default:
                    break;
            }

        }
    }*/


    protected int FloatToInt(int initialValue, int ratoValue, int baseValue)
    {
        float value = initialValue * ((float)ratoValue / (float)baseValue);

        return Mathf.RoundToInt(value);
    }


    protected virtual void GoOtherAction()
    {

    }


}
