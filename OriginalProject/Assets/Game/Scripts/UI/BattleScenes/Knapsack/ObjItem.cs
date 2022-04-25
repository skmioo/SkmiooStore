using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using Datas;
using System;
/// <summary>
/// 物品实体
/// </summary>
public class ObjItem : MonoBehaviour
{
    public RectTransform RectTrans { get { return transform as RectTransform; } }
    public Image icon;
    public Text countT;
    /// <summary>
    /// 物品基础数据
    /// </summary>
    public ObjData objData;
    public Transform mePos_box;
    public int count{get;set;}

    //是否可使用
    public bool use {
        get;private set;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="_objData"></param>
    /// <param name="_count"></param>
    /// <param name="_mePos_Box">背包的格子物体</param>
    public void InitItem(ObjData _objData,int _count,Transform _mePos_Box)
    {
        RectTrans.offsetMin = Vector2.zero;
        RectTrans.offsetMax = Vector2.zero;
        objData = _objData;
        mePos_box = _mePos_Box;
        count = _count;
        objData.Count = count;
        objData.Icon.LoadAssetAsync().Completed += go =>
        {
            icon.sprite = go.Result;
        };
        countT.text = _count.ToString();
    }

    //设置物品是否可用, == 不可用的物品半色显示
    public void SetUse(bool _use)
    {
        use = _use;
        if (use)
        {
            icon.color = new Color(1, 1, 1, 1);
        }
        else
        {
            icon.color = new Color(1, 1, 1, 0.5F);
        }
    }

    /// <summary>
    /// 物品数量减少
    /// </summary>
    /// <returns></returns>
    public int Reduce()
    {
        count--;
        objData.Count--;
        countT.text = count.ToString();
        return count;
    }
    public int Reduce(int _reduce)
    {
        count-= _reduce;
        objData.Count-= _reduce;
        countT.text = count.ToString();
        return count;
    }
    public void Add(int _add) {
        count += _add;
        objData.Count += _add;
        countT.text = count.ToString();
    }
}
