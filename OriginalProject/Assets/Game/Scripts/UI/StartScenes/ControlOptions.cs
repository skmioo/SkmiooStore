using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlOptions : BasePanel
{
    public float fadeTime;
    private Image fadeBg;
    public Color fadeColor;
    private bool isClose = true;
    public Text[] langList;

    public void OpenKeySettingPanel()
    {
        isClose = false;
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        UIManager.Instance.PushPanel(UIPanelType.KeySetting);
    }

    protected override void _OnEnter()
    {
        isClose = true;
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
        if (isClose)
        {
            canvasGroup.alpha = 1;
            canvasGroup.DOFade(0, fadeTime).onComplete = () => gameObject.SetActive(false);
            FadeOutMask();
        }
        else
        {
            gameObject.SetActive(false);
        }
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
        string[] tName = {"控制选项","键盘设置",};
        for(int i = 0; i < langList.Length; i++)
        {
            if(tName[i] != null)
                langList[i].text = LanguageController.GetValue(tName[i]);
        }
    }
}
