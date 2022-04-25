using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DialogPanel : BasePanel
{
    public float fadeTime;
    public Text[] langList;

    protected override void _OnEnter()
    {
        gameObject.SetActive(true);
        canvasGroup.alpha = 0;
        canvasGroup.DOFade(1, fadeTime);
    }

    protected override void _OnExit()
    {
        canvasGroup.alpha = 1;
        canvasGroup.DOFade(0, fadeTime).onComplete=()=>gameObject.SetActive(false);
    }

    public void OnBtnOk()
    {
        DialogMgr.Instance.OnBtnOk();
        UIManager.Instance.PopPanel();
    }

    public void OnBtnNot()
    {
        DialogMgr.Instance.OnBtnNot();
        UIManager.Instance.PopPanel();
    }

    protected override void OnLanguageChanged()
    {
        string[] tName = {"确定","取消", DialogMgr.Instance.GetDesc()};
        for(int i = 0; i < langList.Length; i++)
        {
            if(tName[i] != null)
            {
                if(langList[i] != null)
                    langList[i].text = LanguageController.GetValue(tName[i]);
            }
        }

    }
}
