using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageOptions : BasePanel
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

    public Toggle tog_fullScreen;
    public Toggle tog_windowMaximize;
    public Toggle tog_window;
    public Text tex_resolution;

    private int indexResolution;
    private int lengthResolution;
    private bool isAllowedUpdateResolution;

    private void Start()
    {
        ShowWindowMode();
        ShowResolution();

        indexResolution = (int)ImageController.GetResolution();
        lengthResolution = Enum.GetNames(typeof(ImageController.Resolution)).Length;

        if (!ImageController.GetIs16_9Screen())
        {
            tog_window.isOn = true;
            tog_fullScreen.interactable = false;
            tog_windowMaximize.interactable = false;
        }
    }

    public void TogClickFullScreen()
    {
       
        if (tog_fullScreen.isOn)
        { AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
            ImageController.SetWindowMode(ImageController.WindowMode.FullScreen);
            indexResolution = (int)ImageController.GetResolution();
            ShowResolution();
            SetTexIsAllowed(false);
        }
    }

    public void TogClickWindowMaximize()
    {
      
        if (tog_windowMaximize.isOn)
        {  AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
            ImageController.SetWindowMode(ImageController.WindowMode.WindowMaximize);
            indexResolution = (int)ImageController.GetResolution();
            ShowResolution();
            SetTexIsAllowed(false);
        }
    }

    public void TogClickWindow()
    {
       
        if (tog_window.isOn)
        {
            AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
            ImageController.SetResolution(ImageController.Resolution._1280x720);
            indexResolution = (int)ImageController.GetResolution();
            ShowResolution();
            SetTexIsAllowed(true);

            ImageController.SetWindowMode(ImageController.WindowMode.Window);
        }
    }

    public void SubClick()
    {
       
        if (indexResolution <= 0 || !isAllowedUpdateResolution)
        {
            return;
        }
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        indexResolution--;
        ImageController.SetResolution((ImageController.Resolution)indexResolution);
        ShowResolution();
    }

    public void AddClick()
    {
      
        if (indexResolution >= lengthResolution - 1 || !isAllowedUpdateResolution)
        {
            return;
        }
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        indexResolution++;
        ImageController.SetResolution((ImageController.Resolution)indexResolution);
        ShowResolution();
    }

    private void ShowWindowMode()
    {
        switch (ImageController.GetWindowMode())
        {
            case ImageController.WindowMode.FullScreen:
                SetTexIsAllowed(false);
                tog_fullScreen.isOn = true;
                break;
            case ImageController.WindowMode.WindowMaximize:
                SetTexIsAllowed(false);
                tog_windowMaximize.isOn = true;
                break;
            case ImageController.WindowMode.Window:
                SetTexIsAllowed(true);
                tog_window.isOn = true;
                break;
        }
    }

    private void ShowResolution()
    {
        tex_resolution.text = Enum.GetName(typeof(ImageController.Resolution), ImageController.GetResolution()).Remove(0, 1);
    }

    private void SetTexIsAllowed(bool isAllowed)
    {
        if (isAllowed)
        {
            isAllowedUpdateResolution = true;
            tex_resolution.color = new Color(0.96f, 0.4f, 0.21f, 1f);
        }
        else
        {
            isAllowedUpdateResolution = false;
            tex_resolution.color = new Color(.26f, .26f, .26f, 1f);
        }
    }

    protected override void OnLanguageChanged()
    {
        string[] tName = {"图像选项","全屏游戏","窗口最大化","窗口模式","分辨率",};
        for(int i = 0; i < langList.Length; i++)
        {
            if(tName[i] != null)
                langList[i].text = LanguageController.GetValue(tName[i]);
        }
    }
}
