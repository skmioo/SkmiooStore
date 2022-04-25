using Datas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 装备的基类
/// </summary>
public class EquipBase : MonoBehaviour
{

    protected ObjData objData;
    protected ObjLife objLife;

    /// <summary>
    /// 装备初始化
    /// </summary>
    public void InitEquipEvent(ObjData _objData, ObjLife _objlife)
    {
        objData = _objData;
        objLife = _objlife;
        

        PutOn();
    }

    //穿上装备
    void PutOn()
    {
        SetValue(true);
    }

    int FloatToInt(int initialValue,int ratoValue,int baseValue)
    {
        float value = initialValue * ((float)ratoValue / (float)baseValue);

        return Mathf.RoundToInt(value);
    }


    /// <summary>
    /// 脱下这个装备
    /// </summary>
    public void TakeOff()
    {
        SetValue(false);
        
        Destroy(this);
    }


    // isEnter  真 = 进入时， 假 = 离开时   
    void SetValue(bool isEnter)
    {
        



    }

    void GoSetObjlifeValue(bool isEnter,int objlifeValue,int value)
    {
        if (isEnter)
        {
            objlifeValue += value;
        }
        else
        {
            objlifeValue -= value;
        }
    }

    Dictionary<SkillStatusTpye, int> fileValues = new Dictionary<SkillStatusTpye, int>();

    void GoSetObjlifeValue(bool isEnter,int objLifeValue,int ratio,SkillStatusTpye skillStatusTpye)
    {
        if (isEnter)
        {
            int i = FloatToInt(objLifeValue, ratio, 100);
            objLifeValue += i;//如何记录这个被增加的值？
            if (fileValues.ContainsKey(skillStatusTpye))
            {
                Debug.Log("一个装备或技能,不允许多次对一个角色多次增加相同类型的属性,多余的值被丢弃了");
                return;
            }

            fileValues.Add(skillStatusTpye, i);
        }
        else
        {
            int i = fileValues[skillStatusTpye];
            objLifeValue -= i;
            fileValues.Remove(skillStatusTpye);
        }
    }
}
