using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSetting : BasePanel
{
    public float fadeTime;
    private Image fadeBg;
    public Color fadeColor;
    private bool isClose = true;
    public GameObject[] btnList;
    public Text[] langList;

    public void OpenControlOptionsPanel()
    {
        isClose = false;
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        UIManager.Instance.PushPanel(UIPanelType.KeySetting);
    }

    public void OpenImageOptionsPanel()
    {
        isClose = false;
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        UIManager.Instance.PushPanel(UIPanelType.ImageOptions);
    }

    public void OpenAudioOptionsPanel()
    {
        isClose = false;
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        UIManager.Instance.PushPanel(UIPanelType.AudioOptions);
    }

    public void OpenOtherOptionsPanel()
    {
        isClose = false;
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        UIManager.Instance.PushPanel(UIPanelType.OtherOptions);
    }

    // 返回到开始场景
    public void OutToStart()
    {
        isClose = false;
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        GameScenesController.Instance.GoLoadScenes(0);
        UIManager.Instance.Ondestory();

        GEvent.EventHelper.Instance.ClearEvents();
    }

    // 退出游戏
    public void QuitGame()
    {
        isClose = false;
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

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
        string sSceneName = SceneManager.GetActiveScene().name;
        if(sSceneName == GameSceneName.Z_Start_0.ToString())
        {
            btnList[3].SetActive(true);
            btnList[5].SetActive(false);
            btnList[6].SetActive(false);
        }
        else
        {
            btnList[3].SetActive(false);
            btnList[5].SetActive(true);
            btnList[6].SetActive(true);
        }
            
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

    protected override void _OnResume()
    {
        gameObject.SetActive(true);
        isClose = true;
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
        string[] tName = {"设置","键盘设置","图像选项","音频选项","其他选项","帮助","返回主界面","退出游戏",};
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
