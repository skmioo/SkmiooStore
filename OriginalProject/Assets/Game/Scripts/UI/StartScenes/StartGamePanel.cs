using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StartGamePanel : BasePanel
{
    public float fadeTime;
    private Image fadeBg;
    public Color fadeColor;
    public Text[] langList;

    protected override void _OnEnter()
    {
        if (fadeBg == null)
        {
            Transform canvasTrans = GetComponentInParent<Canvas>().transform;
            Transform fadeObj = canvasTrans.Find("fadeBg");
            if (fadeObj != null)
                fadeBg = fadeObj.GetComponent<Image>();
        }
        gameObject.SetActive(true);
        canvasGroup.alpha = 0;
        canvasGroup.DOFade(1, fadeTime);
        FadeInMask();

        OpenPanel();
    }

    protected virtual void OpenPanel()
    {

    }

    protected override void _OnExit()
    {
        canvasGroup.alpha = 1;
        canvasGroup.DOFade(0, fadeTime).onComplete=()=>gameObject.SetActive(false);
        FadeOutMask();
    }

    private void FadeInMask()
    {
        if (fadeBg == null)
            return;
        fadeBg.gameObject.SetActive(true);
        fadeBg.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, 0);
        fadeBg.DOColor(fadeColor, fadeTime);
    }

    private void FadeOutMask()
    {
        if (fadeBg == null)
            return;
        fadeBg.DOColor(new Color(fadeColor.r, fadeColor.g, fadeColor.b, 0), fadeTime).onComplete = ()
            => fadeBg.gameObject.SetActive(false);
    }

    protected override void OnLanguageChanged()
    {
        string[] tName = {"新的起源", "新的起源", "开始放逐", "请为此次放逐命名"};
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
