using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeySetting : BasePanel
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

    public List<Button> btnList;
    private bool isRepetion = false;
    private bool isWaitingInput = false;
    private int indexInput;
    public GameObject[] btnPanelList;

    private void Start()
    {
        for(int i = 0; i < btnList.Count; i++)
        {
            btnList[i].transform.GetChild(0).GetComponent<Text>().text = KeyController.GetKeyCodeByEvent((KeyController.KeyEvent)i).ToString();
            BtnOnClick(i);
        }

        btnPanelList[0].SetActive(false);
        btnPanelList[1].SetActive(false);
        btnPanelList[2].SetActive(false);
        btnPanelList[3].SetActive(false);
        btnPanelList[13].SetActive(false);
    }
    
    private void Update()
    {
        if (isWaitingInput && Input.anyKeyDown)
        {
            foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(keyCode))
                {
                    isWaitingInput = false;
                    Text tex = btnList[indexInput].transform.GetChild(0).GetComponent<Text>();
                    tex.text = keyCode.ToString();
                    KeyController.UpdateKeyDictionary((KeyController.KeyEvent)indexInput, keyCode);
                    ShowRepetionKey();
                }
            }
        }
    }

    private void ShowRepetionKey()
    {
        foreach (var btn in btnList)
        {
            btn.transform.GetChild(0).GetComponent<Text>().color = new Color(0.7529412f, 0.7568628f, 0.7372549f);
        }

        List<int> intList = KeyController.GetIndexListRepetionKey();
        if (intList.Count > 0)
        {
            isRepetion = true;
            foreach (var i in intList)
            {
                btnList[i].transform.GetChild(0).GetComponent<Text>().color = Color.red;
            }
        }
        else
        {
            isRepetion = false;
        }
    }

    public void BtnOnClick(int index)
    {
        btnList[index].onClick.AddListener(delegate () {
            AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
            if (!isWaitingInput)
            {
                btnList[index].transform.GetChild(0).GetComponent<Text>().text = "";
                isWaitingInput = true;
                indexInput = index;
            }
        });
    }

    protected override void OnLanguageChanged()
    {
        string[] tName = {"键盘设置","在任意画面打开帮助界面","查看英雄人物页","浏览人物页时切换到上一个英雄","浏览人物页时切换到下一个英雄","向左移动（任务中）","向右移动（任务中）","快速施放第1个技能（任务中）",
        "快速施放第2个技能（任务中）","快速施放第3个技能（任务中）","快速施放第4个技能（任务中）","快速施放士气技能（任务中）","换位（任务中）","战利品窗口显示时，全部拿走（任务中）","在地图和背包之间切换（任务中）",
        "进入下一个房间/与交互物互动（任务中）"};
        for(int i = 0; i < langList.Length; i++)
        {
            if(tName[i] != null)
                langList[i].text = LanguageController.GetValue(tName[i]);
        }
    }
}
