using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UIUtils;

/// <summary>
/// 接收到伤害或加血的显示
/// </summary>
public class ValueShow : MonoBehaviour
{
    ObjLife m_objlife;
    Text text;
    Image img;
     float intervalTime = 0.2f;
     float showTime = 1f;
    public Vector3 initPos = new Vector3(-0.4f, 1.18f,1f), targetPos = new Vector3(-0.15f, 1.96f, 1f);
    private void Awake()
    {
        text = GetComponent<Text>();
        img = GetComponent<Image>();
        gameObject.SetActive(false);
    }
    public void Initialized(ObjLife _objlife)
    {
        m_objlife = _objlife;
    }
    public void ShowStart(int value, float delay, string hexString = "#FFFFFF") {
        if (text)
        {
            text.color = new Color(1, 1, 1, 1);
            text.text = StringToRichText(value.ToString(), hexString);
 
        }
        StopCoroutine("ShowAndAnimation");
        Invoke("ShowAndAnimation", delay);
    }
    public void ShowStart(string str, string hexString = "#FFFFFF")
    {
        if (text)
        {
            text.text = StringToRichText(str, hexString);
        }

        ShowAndAnimation();
    }

    string StringToRichText( string str, string hexString)
    {
        bool flag = ColorUtility.TryParseHtmlString(hexString, out Color color);
        if (!flag) throw new System.Exception($"{hexString} is not Conver to Color");
        //string colorTagStart = $"<color={hexString}>";
        //string colorTagEnd = "</color>";
        //string sTemp = colorTagStart + str + colorTagEnd;
        return str;
    }
   
    private void ShowAndAnimation()
    {
        OnShow();
        GoAnimation();
    }

   
    void GoAnimation()
    {
        Sequence seq = DOTween.Sequence();
        Sequence seqtext = DOTween.Sequence();
        seq.OnComplete(()=> {
            OffShow();
        });
        seqtext.AppendInterval(intervalTime);
        seq.AppendInterval(intervalTime);
        seqtext.Append(text.DOColor(new Color(1, 1, 1, 0), showTime));
        seq.Append(transform.DOLocalMove(targetPosTemp, showTime).SetEase(Ease.InOutFlash));

        seq.AppendCallback(()=> {
            if (text)
            {
                text.color = new Color(1, 1, 1, 0);
            }
            else
            {
                img.color = new Color(1, 1, 1, 0);
            }
        });
    }
    Vector3 targetPosTemp = Vector3.zero;
   void OnShow()
    {
        RoleType tempType = m_objlife.GetRoleType();
        Vector3 initPosTemp = new Vector3(initPos.x * (tempType == RoleType.英雄 ? 1 : -1), initPos.y, initPos.z);
         targetPosTemp = new Vector3(targetPos.x * (tempType == RoleType.英雄 ? 1 : -1), targetPos.y, initPos.z);
        transform.localPosition = initPosTemp;

        if (text)
        {
            text.color = new Color(1, 1, 1, 1);
        }
        else
        {
            img.color = new Color(1, 1, 1, 1);
        }

        gameObject.SetActive(true);
    }

    void OffShow()
    {
        gameObject.SetActive(false);
    }
}
