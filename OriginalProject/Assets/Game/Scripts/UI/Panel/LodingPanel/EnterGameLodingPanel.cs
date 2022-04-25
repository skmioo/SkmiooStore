using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class EnterGameLodingPanel : BasePanel
{
    [Header("背景图")]
    public Image bg;
    [Header("进度条")]
    public Slider slider;
    [Header("进度数字")]
    public Text grogressValue;
    [Header("速率曲线")]
    public AnimationCurve curve;
    [Header("压暗或提亮的时间")]
    public float showTime = 1;
    [Header("精度条走满的时间")]
    public float waitTime = 1;

    private int progress = 0;
    private float timer = 0;

    protected override void _OnEnter()
    {
        progress = 0;
        timer = 0;
        //GameScenesController.Instance.toScenes.AddListener(OnGoToScene);
        if (!bg) bg = GetComponent<Image>();
        bg.DOColor(Color.white, showTime).onComplete = () => {
            progress++;
        };
    }

    protected override void _OnExit()
    {
        Debug.Log("---- 关闭Loding界面 ----");
        //GameScenesController.Instance.toScenes.RemoveListener(OnGoToScene);
    }

    protected override void _OnResume()
    {
        
    }
    
    //private void OnGoToScene()
    //{
    //    progress++;
    //}

    private void Update()
    {
        if (progress == 1)
        {
            timer += Time.deltaTime;
            if (timer >= waitTime)
            {
                progress++;
                bg.DOColor(Color.black, showTime).onComplete = () =>
                {
                    progress++;
                };
            }
            else
            {
                var v = curve.Evaluate(timer / waitTime);
                slider.value = v;
                grogressValue.text = Mathf.CeilToInt(v * 100).ToString() + "%";
            }
        }
        else if (progress >= 3)
        {
            UIManager.Instance.PopPanel();
            Destroy(gameObject);
        }
    }
}
