using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OtherOptions : BasePanel
{
    #region 界面切换
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
        // FadeInMask();

        OpenPanel();
    }

    protected virtual void OpenPanel()
    {
        OnLanguageChanged();
    }

    protected override void _OnExit()
    {
        canvasGroup.alpha = 1;
        canvasGroup.DOFade(0, fadeTime).onComplete = () => gameObject.SetActive(false);
        // FadeOutMask();
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
    #endregion

    public Text tex_LanguageOption;

    private int indexLanguageOption;
    private int lengthLanguageOption;

    private void Start()
    {
        ShowLanguageOption();

        indexLanguageOption = (int)LanguageController.GetLanguageOption();
        lengthLanguageOption = Enum.GetNames(typeof(LanguageController.LanguageOption)).Length;
    }

    public void SubClick()
    {
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        indexLanguageOption--;
        if (indexLanguageOption < 0)
        {
            indexLanguageOption = lengthLanguageOption - 1;
        }
        LanguageController.SetLanguageOption((LanguageController.LanguageOption)indexLanguageOption);
        ShowLanguageOption();
    }

    public void AddClick()
    {
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        indexLanguageOption++;
        if (indexLanguageOption > lengthLanguageOption - 1)
        {
            indexLanguageOption = 0;
        }
        LanguageController.SetLanguageOption((LanguageController.LanguageOption)indexLanguageOption);
        ShowLanguageOption();
    }

    private void ShowLanguageOption()
    {
        tex_LanguageOption.text = Enum.GetName(typeof(LanguageController.LanguageOption), LanguageController.GetLanguageOption());
    }

    protected override void OnLanguageChanged()
    {
        string[] tName = {"其他选项","语言",};
        for(int i = 0; i < langList.Length; i++)
        {
            if(tName[i] != null)
                langList[i].text = LanguageController.GetValue(tName[i]);
        }
    }
    
}
