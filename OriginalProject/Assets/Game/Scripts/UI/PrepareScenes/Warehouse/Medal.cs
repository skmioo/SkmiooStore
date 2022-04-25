using Datas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// 勋章包 ..弃用脚本,改入WarehousePanel统一管理
/// </summary>
public class Medal : MonoBehaviour
{
    public GameObject objItem;
    public Image objItemOnDrag;
    public ObjItemInfo objItemInfo;

    public Camp camp;

    public Transform[] medalBoxs;

    ModeData modeData;
    Dictionary<int, ObjData> objDataDict = new Dictionary<int, ObjData>();

    Dictionary<Transform, ObjItem> medalDict = new Dictionary<Transform, ObjItem>();


    bool onDraging;
    private void Start()
    {
        SetDict();
        InitMedal();
    }

    void SetDict()
    {
        modeData = DataManager.Instance.modeData;

        DataSetItem dataSet = DataManager.Instance.GetData("ObjData");
        ObjDataSet objData = dataSet.scriptableObject as ObjDataSet;

        foreach (var item in objData.ornamentsDatas)
        {
            objDataDict.Add(item.id, item);
        }

        /*foreach (var item in objData.medalDatas)
        {
            objDataDict.Add(item.id, item);
        }*/

        //暂时用道具数据进行测试,后期可不加载
        foreach (var item in objData.porpDatas)
        {
            objDataDict.Add(item.id, item);
        }
    }

    void InitMedal()
    {
        /*for (int i = 0; i < modeData.MedalModes.Count; i++)
        {
            ObjItem obj = null;
            int id = modeData.MedalModes[i].objId;
            if (id != 0)
            {
                if (!objDataDict.ContainsKey(id))
                {
                    Debug.Log($"存档ID在基础数据中找不到{id}");
                    break;
                }

                ObjData objData = objDataDict[id];
                GameObject go = Instantiate(objItem, medalBoxs[i]);
                obj = go.GetComponent<ObjItem>();
                obj.InitItem(objData, modeData.MedalModes[i].count, medalBoxs[i]);

                ItemListener(go);
            }

            medalDict.Add(medalBoxs[i], obj);
        }*/
    }

    void ItemListener(GameObject item)
    {
        UIEventManager.AddTriggersListener(item).onEnter += ItemOnEnter;
        UIEventManager.AddTriggersListener(item).onExit += ItemOnExit;
        UIEventManager.AddTriggersListener(item).onDrag += ItemOnDrag;
        UIEventManager.AddTriggersListener(item).onEndDrag += ItemEndDrag;
    }

    void RemoveItemListener(GameObject item)
    {
        UIEventManager.AddTriggersListener(item).onEnter -= ItemOnEnter;
        UIEventManager.AddTriggersListener(item).onExit -= ItemOnExit;
        UIEventManager.AddTriggersListener(item).onDrag -= ItemOnDrag;
        UIEventManager.AddTriggersListener(item).onEndDrag -= ItemEndDrag;
    }

    void ItemOnEnter(GameObject go)
    {
        if (onDraging)
            return;

        ObjItem obj = go.GetComponent<ObjItem>();
        objItemInfo.Show(obj.objData, go.transform.position);
    }

    void ItemOnExit(GameObject go)
    {
        objItemInfo.Off();
    }

    RectTransform ItemOnDrag(GameObject go, PointerEventData eventData)
    {
        onDraging = true;
        ObjItem obj = go.GetComponent<ObjItem>();
        objItemOnDrag.sprite = obj.icon.sprite;
        RectTransform rectTransform = objItemOnDrag.GetComponent<RectTransform>();

        if (obj.objData.objType == ObjType.圣物)
        {

        }

        objItemOnDrag.gameObject.SetActive(true);

        return rectTransform;
    }

    void ItemEndDrag(GameObject go, PointerEventData eventData)
    {
        onDraging = false;
        objItemOnDrag.gameObject.SetActive(false);
        if (eventData.pointerEnter == null)
            return;
        Transform goBox = go.transform.parent;
        Transform target = eventData.pointerEnter.transform;
        if (target.tag == "W_MedalBox")
        {
            MoveValue(go.transform.parent, target);
        }
        else if (target.parent.tag == "W_MedalBox")
        {
            MoveValue(go.transform.parent, target.parent);
        }
        else if (target.tag == "MedalBox" || target.parent.tag == "MedalBox")
        {

            RemoveItemListener(go);
            ObjItem _obj = camp.roleInfo.heroEquipmentInfo.AddMedalItem(go, target);

            if (_obj != null)
            {
                _obj.transform.SetParent(goBox);
                _obj.transform.localPosition = Vector3.one;
                ItemListener(_obj.gameObject);
            }

            medalDict[goBox] = _obj;
        }
        else if (target.name.Equals("medalBox"))
        {
            ObjItem _obj = go.GetComponent<ObjItem>();
            Destroy(_obj.gameObject);
            Hashtable args = new Hashtable();
            args.Add("ObjData", _obj.objData);
            args.Add("Icon", objItemOnDrag.sprite);
            GEvent.EventHelper.Instance.ExcuteEvent(GEvent.GEventType.RightClickMedal, args);
        }

    }

    /// <summary>
    /// 移入一个数据
    /// </summary>
    public void AddMoveItem(ObjItem objItem, Transform target)
    {
        objItem.transform.SetParent(target);
        objItem.transform.localPosition = Vector3.one;

        medalDict[target] = objItem;
        ItemListener(objItem.gameObject);
    }

    //增加一个数据
    public void AddValue(ObjData objData, int count)
    {
        foreach (var item in medalDict)
        {
            if (item.Value == null)
            {
                GameObject go = Instantiate(objItem, item.Key);
                ObjItem obj = go.GetComponent<ObjItem>();

                obj.InitItem(objData, count, item.Key);
                medalDict[item.Key] = obj;

                ItemListener(go);
                return;
            }
        }

        Debug.Log("一个空格子都没找到,包满了");
    }

    //删除
    void RemoveValue(Transform key)
    {
        //这个类型的物品应该都不能够堆叠的吧？--直接写删除逻辑
        Destroy(medalDict[key]);
        medalDict[key] = null;

    }

    //移动数据
    void MoveValue(Transform source, Transform target)
    {
        ObjItem targetItem = medalDict[target];
        ObjItem sourceItem = medalDict[source];

        sourceItem.transform.SetParent(target);
        sourceItem.transform.localPosition = Vector3.zero;
        medalDict[target] = sourceItem;

        //目标点有可能是空的
        if (targetItem != null)
        {
            targetItem.transform.SetParent(source);
            targetItem.transform.localPosition = Vector3.zero;
        }


        medalDict[source] = targetItem;
    }


}
