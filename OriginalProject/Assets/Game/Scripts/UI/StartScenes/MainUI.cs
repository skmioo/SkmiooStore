using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public Text[] langList;

    private void Start()
    {
        StartCoroutine(DelayedLoad());
        OnLanguageChanged();
        AudioManager.Instance.PlayMusic(AudioName.MainMenuBGM);
    }

    private void OnDestroy()
    {
        UIManager.Instance.onLanguageChangedAction -= OnLanguageChanged;
    }

    public void OpenNewGamePanel()
    {
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        UIManager.Instance.PushPanel(UIPanelType.NewGamePanel);
    }

    public void OpenContinePanel()
    {
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        UIManager.Instance.PushPanel(UIPanelType.ContinueGamePanel);
    }

    public void OpenSettingPanel()
    {
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        UIManager.Instance.PushPanel(UIPanelType.SettingPanel);
    }

    public void OpenAuthorsPanel()
    {
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        UIManager.Instance.PushPanel(UIPanelType.AuthorsPanel);
    }

    public void OnMouseEnter()
    {
        AudioManager.Instance.PlayAudio(AudioName.MouseHover, AudioType.Common);
    }

    // 退出游戏
    public void QuitGame()
    {
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        DialogMgr.Instance.onEvOk.AddListener(__QuitGame);
        DialogMgr.Instance.CreatePanel("是否确定退出游戏？");
    }

    public void __QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    private void OnLanguageChanged()
    {
        langList[0].text = LanguageController.GetValue("继续放逐");
        langList[1].text = LanguageController.GetValue("新的起源");
        langList[2].text = LanguageController.GetValue("设置");
        langList[3].text = LanguageController.GetValue("制作组");
        langList[4].text = LanguageController.GetValue("退出");
    }

    IEnumerator DelayedLoad()
    {
        yield return new WaitForSeconds(1);
        UIManager.Instance.onLanguageChangedAction += OnLanguageChanged;
    }
}
