using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 复仇状态
/// 当血量低于50%时，buff增加30%攻击力,高于50%时增加10%攻击力
/// </summary>
/*public class Buff_Fuchou : GainBuff
{
    bool k1;
    int k1Max;
    int k1Min;

    bool k5;
    int k5Max;
    int k5Min;

    int buffValue;

    protected override void Start_Z()
    {
        CheckTrigger();
        foreach (var item in skillBuff.buffValues)
        {
            if (item.statusType == SkillStatusTpye.攻击)
            {
                buffValue = GetBuffLevel(item);
            }
        }
    }

    protected override void Damage()
    {
        CheckTrigger();
    }

    protected override void End_Z()
    {
        if (k1)
        {
            K1Off();
        }
        if (k5)
        {
            K5Off();
        }
    }

    void CheckTrigger()
    {
        if (ContrastHP())
        {
            if (k1)
            {
                K1Off();
            }
            

            k5Max = FloatToInt(objLife.GetMinAtk(), buffValue, 100);
            k5Min = FloatToInt(objLife.GetMinAtk(), buffValue, 100);
            K5On();
        }
        else
        {
            if (k5)
            {
                K5Off();
            }
            k1Min = Mathf.RoundToInt(objLife.GetMinAtk() * 0.1f);
            k1Max = Mathf.RoundToInt(objLife.GetMinAtk() * 0.1f);
            K1On();
        }
    }


    void K1On()
    {
        objLife.GetMinAtk() += k1Min;
        objLife.GetMinAtk() += k1Max;
        k1 = true;
    }

    void K1Off()
    {
        objLife.GetMinAtk() -= k1Min;
        objLife.GetMinAtk() -= k1Max;
        k1 = false;
    }


    void K5On()
    {
        objLife.GetMinAtk() += k5Max;
        objLife.GetMinAtk() += k5Min;
        k5 = true;
    }

    void K5Off()
    {
        objLife.GetMinAtk() -= k5Max;
        objLife.GetMinAtk() -= k5Min;
        k5 = false;
    }

    bool ContrastHP()
    {
        float f = objLife.GetNowHp() / objLife.GetHp();

        return f < 0.5f;
    }

}
*/