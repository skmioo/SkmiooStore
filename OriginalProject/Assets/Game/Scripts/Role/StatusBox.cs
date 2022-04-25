using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// buff盒子管理 
/// </summary>
public class StatusBox : MonoBehaviour
{
    /*public List<BuffBase> buffs = new List<BuffBase>();

    public BuffShow buffShow;
    public bool moraleB;
    public int moraleCount;
    public bool injurieB;

    public GameObject buffOnlyOne;

    /// <summary>
    /// 增加一个buff
    /// </summary>
    /// <param name="buff"></param>
    public void AddBuff(BuffBase buff)
    {
        buff.transform.localScale = Vector3.zero;

        buffs.Add(buff);

        buffShow.ShowStart(buff);

        //if (buff.skillBuff.skillBuffType == SkillBuffType.状态切换)
        //{

        //}

        //鼠标悬停显示信息
        UIEventManager.AddTriggersListener(buffOnlyOne).onEnter = go =>
        {
            GameObject.Find("BuffInfo").GetComponent<BuffInfo>().Show(buffOnlyOne.transform.position, buffs);
        };
        UIEventManager.AddTriggersListener(buffOnlyOne).onExit = go =>
        {
            GameObject.Find("BuffInfo").GetComponent<BuffInfo>().Hidden();
        };

        ShowBuffOnlyOne();
    }

    /// <summary>
    /// 移除一类异常状态
    /// </summary>
    /// <param name="skillStatusTpye"></param>
    public void RemoveBuff(SkillBuffType skillBuffType)
    {
        for (int i = buffs.Count - 1; i >= 0; i--)
        {
            if (buffs[i].skillBuff.skillBuffType.Equals(skillBuffType))
            {
                Destroy(buffs[i].gameObject);
                buffs.RemoveAt(i);
            }
        }

        ShowBuffOnlyOne();
    }

    /// <summary>
    /// 将buff从列表中移除，不销毁
    /// </summary>
    /// <param name="goBuff"></param>
    public void RemoveBuffFromList(BuffBase buff)
    {
        buffs.Remove(buff);
        //Destroy(buffs[index]);//由buffbase自行销毁
    }

    /// <summary>
    /// 整合buff显示
    /// </summary>
    public void ShowBuffOnlyOne()
    {
        if (buffs.Count.Equals(0))
        {
            buffOnlyOne.transform.localScale = Vector3.zero;
        }
        else
        {
            buffOnlyOne.transform.localScale = Vector3.one;
        }
    }*/

    //由盒子发起一个UIbuff show 流程,让UI控制器控制他实现方法
}
