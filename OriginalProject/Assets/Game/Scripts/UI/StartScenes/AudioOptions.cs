using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioOptions : BasePanel
{
    #region 界面切换逻辑
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
    
    public Toggle tog_mute;

    public Toggle tog_backtageMute;

    public Button btn_subMainVolume;
    public Text tex_mainVolume;
    public Button btn_addMainVolume;

    public Button btn_subSoundVolume;
    public Text tex_soundVolume;
    public Button btn_addSoundVolume;
    private void Start()
    {
        tog_mute.isOn = AudioManager.Instance.GetMute();
        //AudioManager.Instance.SetMute(tog_mute.isOn);
        tog_backtageMute.isOn = AudioManager.Instance.GetBackStageMute();
        //AudioManager.Instance.SetBacktageMute(tog_backtageMute.isOn);
        UpdateMainVolume(AudioManager.Instance.GetMainVolume());
        UpdateSoundVolume(AudioManager.Instance.GetSoundVolume());
    }

    public void OnValueChangeMute()
    {
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        AudioManager.Instance.SetMute(tog_mute.isOn);
    }

    public void OnValueChangeBacktageMute()
    {
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        AudioManager.Instance.SetBacktageMute(tog_backtageMute.isOn);
    }

    public void OnClickMainVolume(int dValue)
    {
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        int newVolume = AudioManager.Instance.GetMainVolume() + dValue;
        if (newVolume > AudioManager.MainVolumeMax) newVolume = AudioManager.MainVolumeMax;
        AudioManager.Instance.SetMainVolume(newVolume);
        UpdateMainVolume(newVolume);
    }

    public void OnClickSoundVolume(int dValue)
    {
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        int newVolume = AudioManager.Instance.GetSoundVolume() + dValue;
        if (newVolume > AudioManager.SoundVolumeMax) newVolume = AudioManager.SoundVolumeMax;
        AudioManager.Instance.SetSoundVolume(newVolume);
        UpdateSoundVolume(newVolume);
    }

    private void UpdateMainVolume(int value)
    {
        tex_mainVolume.text = value.ToString();
        btn_subMainVolume.interactable = value == 0 ? false : true;
        btn_addMainVolume.interactable = value == 100 ? false: true;
    }

    private void UpdateSoundVolume(int value)
    {
        tex_soundVolume.text = value.ToString();
        btn_subSoundVolume.interactable = value == 0 ? false : true;
        btn_addSoundVolume.interactable = value == 100 ? false : true;
    }

    protected override void OnLanguageChanged()
    {
        string[] tName = {"音频选项","静音","后台静音","主音量","音效音量",};
        for(int i = 0; i < langList.Length; i++)
        {
            if(tName[i] != null)
                langList[i].text = LanguageController.GetValue(tName[i]);
        }
    }
}
