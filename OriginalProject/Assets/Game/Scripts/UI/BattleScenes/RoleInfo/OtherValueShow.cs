using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OtherValueShow : MonoBehaviour
{
    public Image image;
    public Text valueText;

    public Sprite morale;
    public Sprite injuries;

    public float showTime = 2;
    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void ShowValue(bool isMorale,int value)
    {
        valueText.text = value.ToString();
        if (isMorale)
        {
            image.sprite = morale;
        }
        else
        {
            image.sprite = injuries;
        }

        OnShow();
        GoAnimation();
    }


    void OnShow()
    {
        valueText.color = new Color(1, 1, 1, 1);
        gameObject.SetActive(true);
    }

    void GoAnimation()
    {
        valueText.transform.localPosition = new Vector2(0, 2);

        valueText.transform.DOLocalMoveY(3, showTime);
        valueText.DOColor(new Color(1, 1, 1, 0), showTime).OnComplete(OffShow);

        image.fillAmount = 0;
        image.DOFillAmount(1, showTime);

    }

    void OffShow()
    {
        gameObject.SetActive(false);
    }

}
