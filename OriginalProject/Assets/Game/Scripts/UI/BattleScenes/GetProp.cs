using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Datas;
using System;
using UnityEngine.EventSystems;

/// <summary>
/// 道具获得
/// </summary>
public class GetProp : MonoBehaviour
{
    public RectTransform panel;
    public Transform boxContent;
    [HideInInspector]public List<Transform> PropBoxs;
    public GameObject objItem;
    public ObjItemInfo objItemInfo;
    public Image objItemOnDrag;

    //战斗结束,点击交互物等都是打开这个面板,所以这个面板会变化值
    public Text panelName;
    public Text panelTips;

    Dictionary<int, ObjData> objDataDict = new Dictionary<int, ObjData>();

    static GetProp _instance;
    private bool onDraging;


    public static GetProp Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
        PropBoxs = new List<Transform>();
        for (int i = 0; i < boxContent.childCount; ++i) PropBoxs.Add(boxContent.GetChild(i));
        panel.gameObject.SetActive(false);
        //SetDict();
    }

    void SetDict()
    {
        DataSetItem dataSet = DataManager.Instance.GetData("ObjData");
        ObjDataSet objData = dataSet.scriptableObject as ObjDataSet;

        foreach (var item in objData.porpDatas)
        {
            objDataDict.Add(item.id, item);
        }

        //foreach (var item in objData.medalDatas)
        //{
        //    objDataDict.Add(item.id, item);
        //}

        foreach (var item in objData.ornamentsDatas)
        {
            objDataDict.Add(item.id, item);
        }
    }
    public void Show() { 
        panel.gameObject.SetActive(true);
        BattleFlowController.Instance.IsInteracting = true;
    }
    public void Exit() {
        BattleFlowController.Instance.IsInteracting = false;
        panel.gameObject.SetActive(false);
        MapController.Instance.UpdateTaskStatus();
    }
    public void ShowProp(List<ObjData> objDatas)
    {
        int index = 0;
        for (int i = 0; i < objDatas.Count; i++)
        {
            GameObject go = Instantiate(objItem, PropBoxs[i]);
            ObjItem _obj = go.GetComponent<ObjItem>();

            _obj.InitItem(objDatas[i], objDatas[i].Count, PropBoxs[i]);
            ItemListener(go);
            index = i;
            PropBoxs[i].gameObject.SetActive(true);
        }
        for (int i = index + 1; i < PropBoxs.Count; ++i)
        {
            PropBoxs[i].gameObject.SetActive(false);
        }
        Show();
    }

    void ItemListener(GameObject item)
    {
        UIEventManager.AddTriggersListener(item).onEnter = go => ItemOnEnter(go);
        UIEventManager.AddTriggersListener(item).onExit = go => ItemOnExit(go);
        UIEventManager.AddTriggersListener(item).onDrag = (go, eventData) => ItemOnDrag(go, eventData);
        UIEventManager.AddTriggersListener(item).onEndDrag = (go, eventData) => ItemEndDrag(go, eventData);

        UIEventManager.AddTriggersListener(item).onLeftClick = go => ItemLeftClick(go);
        UIEventManager.AddTriggersListener(item).onRightClick = go => ItemRightClick(go);

    }

    private void ItemRightClick(GameObject go)
    {
        
    }

    private void ItemLeftClick(GameObject go)
    {
       
    }

    private void ItemEndDrag(GameObject go, PointerEventData eventData)
    {

        //onDraging = false;
        //objItemOnDrag.gameObject.SetActive(false);
        //if (eventData.pointerEnter == null)
        //    return;

        //Transform target = eventData.pointerEnter.transform;
        //if (target.tag == "ObjItemBox")
        //{
        //    MoveValue(go.transform.parent, target);
        //}
        //else if (target.parent.tag == "ObjItemBox")
        //{
        //    MoveValue(go.transform.parent, target.parent);
        //}

        //有几种情况
        //1、空格子   2、格子内有物品但与拖拽的不同   3、格子内有物品且相同   4、格子内相同的物品达到上限了
    }

    private RectTransform ItemOnDrag(GameObject go, PointerEventData eventData)
    {
        onDraging = true;
        ObjItem obj = go.GetComponent<ObjItem>();
        objItemOnDrag.sprite = obj.icon.sprite;
        RectTransform rectTransform = objItemOnDrag.GetComponent<RectTransform>();
        objItemOnDrag.gameObject.SetActive(true);

        return rectTransform;

    }

    private void ItemOnExit(GameObject go)
    {
        objItemInfo.Off();
    }

    private void ItemOnEnter(GameObject go)
    {
        if (onDraging)
            return;

        ObjItem obj = go.GetComponent<ObjItem>();
        objItemInfo.Show(obj.objData, go.transform.position);
    }
}
