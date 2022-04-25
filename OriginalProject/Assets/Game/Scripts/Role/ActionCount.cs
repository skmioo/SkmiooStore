using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ActionCount : MonoBehaviour
{
    Image image;
    RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        gameObject.SetActive(false);
    }


    public void SetCount(int i)
    {
        if (i>0)
        {
            //如果有具体显示什么值,暂缓
            rectTransform.sizeDelta = Vector2.one;
            rectTransform.DOSizeDelta(new Vector2(0.5f, 0.5f), 1f);
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
