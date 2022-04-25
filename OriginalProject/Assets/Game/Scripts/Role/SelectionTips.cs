using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// 角色点击提示
/// </summary>
public class SelectionTips : MonoBehaviour
{
    public Sprite action;
    public Sprite enemy;
    public Sprite friends;

    //两种方式，一是改变图标来达到不同显示，
    //二是开关不同的

    Image image;
    RectTransform rectTransform;
    private void Awake()
    {
        image = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        //ShowPing();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ShowPing();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            DOTween.KillAll(rectTransform);
        }
    }

    /// <summary>
    /// 行动指示
    /// </summary>
    public void ActionTpis()
    {
        transform.localPosition = new Vector3(1f, 5.2f, 0f);
        transform.localScale = new Vector3(0.5f, 0.5f, 1f);

        ShowPing();
        image.sprite = action;
        gameObject.SetActive(true);
    }

    /// <summary>
    /// 敌对指示
    /// </summary>
    public void EnemyTips()
    {
        DOTween.Kill(rectTransform);       
        rectTransform.sizeDelta = new Vector2(2, 1);

        ShowTips();
        image.sprite = enemy;
        gameObject.SetActive(true);
    }

    /// <summary>
    /// 队友指示
    /// </summary>
    public void FriendsTips()
    {
        DOTween.Kill(rectTransform);
        rectTransform.sizeDelta = new Vector2(2, 1);


        ShowTips();
        image.sprite = friends;
        gameObject.SetActive(true);
    }

    /// <summary>
    /// 关闭提示
    /// </summary>
    public void OffTips()
    {      
        gameObject.SetActive(false);
        DOTween.Kill(rectTransform);
        rectTransform.sizeDelta = new Vector2(2, 1);
    }

    //动画显示效果
    void ShowTips()
    {
        DOTween.Kill(transform);
        transform.localPosition = new Vector3(1, 2,0);
        transform.localScale = new Vector3(1.5f,1.5f,1);

        transform.DOLocalMove(new Vector3(1,1,0), 0.7f);
        transform.DOScale(Vector3.one, 0.7f);
    }

    //public float showTime = 0.7f;

    void ShowPing()
    {
        //rectTransform.DOSizeDelta(new Vector2(3,1), 0.48f).OnComplete(ShowPong);
        rectTransform.DOSizeDelta(new Vector2(1, 1), 0.48f).OnComplete(ShowPong);
    }

    void ShowPong()
    {
        //rectTransform.DOSizeDelta(new Vector2(2,1), 0.48f).OnComplete(ShowPing);
        rectTransform.DOSizeDelta(new Vector2(0, 1), 0.48f).OnComplete(ShowPing);
    }
}
