using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 换位技能
/// </summary>
public class SkillMove : MonoBehaviour
{
    //选中与取消选中

    Image selected_img;

    [HideInInspector]
    /// <summary>
    /// 技能起点位置组
    /// </summary>
    public bool[] startPos = new bool[4];


    private void Awake()
    {
        selected_img = transform.Find("selected_img").GetComponent<Image>();
        selected_img.gameObject.SetActive(false);
    }

    /// <summary>
    /// 设置移动按钮---主要设置哪些目标可选
    /// </summary>
    public void SetMoveButton(/*RoleBattleingData roleBattleingData*/)
    {
        //当队伍中只有一人时，需要关闭这个技能吗
        /*switch (roleBattleingData.numInTeam)
        {
            case 0:SetTarget(false, true, false, false);
                break;
            case 1:SetTarget(true, false, true, false);
                break;
            case 2:SetTarget(false, true, false, true);
                break;
            case 3:SetTarget(false, false, true, false);
                break;
            default:
                break;
        }*/
    }

    private void SetTarget(bool a,bool b,bool c,bool d)
    {
        startPos[0] = a;
        startPos[1] = b;
        startPos[2] = c;
        startPos[3] = d;
    }

    /// <summary>
    /// 被选中
    /// </summary>
    public void SelectedOn()
    {
        selected_img.gameObject.SetActive(true);
    }
    /// <summary>
    /// 关闭选中提示
    /// </summary>
    public void SelectedOff()
    {
        selected_img.gameObject.SetActive(false);
    }

    //只能交换一个位置。。
}
