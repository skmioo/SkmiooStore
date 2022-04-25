using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Datas;


public class BuffShow : MonoBehaviour
{
    /*Image show;

    public Sprite bleedRTips;
    public Sprite poisonRTips;
    public Sprite debuffRTips;
    public Sprite vertigoRTips;

    public Text buffName;
    //增加抵抗提示
    private void Awake()
    {
        show = GetComponent<Image>();
        gameObject.SetActive(false);
    }

    public void ShowStart(BuffBase buffBase)
    {
        buffName.gameObject.SetActive(false);

        Image buff_Image = buffBase.GetComponent<Image>();

        show.sprite = buff_Image.sprite;
        OnShow();
       
        switch (buffBase.ShowBuffType)
        {
            case ShowBuffType.上升:ToUp();
                break;
            case ShowBuffType.下降:ToDwon();
                break;
            case ShowBuffType.放大:
                break;
            case ShowBuffType.缩小:
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 抵抗buff/或拒绝Buff
    /// </summary>
    public void RefuseBuff(SkillBuff skillBuff)
    {
        buffName.gameObject.SetActive(true);
        //播放对应的Buff抵抗效果
        switch (skillBuff.skillBuffType)
        {
            case SkillBuffType.减益:
                show.sprite = debuffRTips;
                break;
            case SkillBuffType.中毒:
                show.sprite = poisonRTips;
                break;
            case SkillBuffType.流血:
                show.sprite = bleedRTips;
                break;
            //case SkillBuffType.位移:
            //    break;
            case SkillBuffType.限制:
                show.sprite = vertigoRTips;
                break;
            default:
                break;
        }

        ToUp();
    }

    /// <summary>
    /// 上升显示
    /// </summary>
    public void ToUp()
    {
        show.transform.localPosition = Vector3.zero;

        show.transform.DOLocalMoveY(3, 3);
        show.DOColor(new Color(1, 1, 1, 0), 3).OnComplete(OffShow);
    }

    /// <summary>
    /// 下降显示
    /// </summary>
    public void ToDwon()
    {
        show.transform.localPosition = new Vector3(0, 3, 0);

        show.transform.DOLocalMoveY(0, 3);
        show.DOColor(new Color(1, 1, 1, 0), 3).OnComplete(OffShow);
    }

    void OnShow()
    {
        show.color = new Color(1, 1, 1, 1);
        gameObject.SetActive(true);
    }

    /// <summary>
    /// 不使用的图形关闭掉
    /// </summary>
    void OffShow()
    {
        show.gameObject.SetActive(false);
    }*/
}

    