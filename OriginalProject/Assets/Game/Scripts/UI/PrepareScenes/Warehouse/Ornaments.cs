using Datas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 饰品背包   。弃用脚本,改入WarehousePanel统一管理
/// </summary>
public class Ornaments : MonoBehaviour
{
    public GameObject objItem;
    public Transform[] ornamentsBoxs;

    public Image objItemOnDrag;
    public ObjItemInfo objItemInfo;

    public Camp camp;
    ModeData modeData;
    Dictionary<int, ObjData> objDataDict = new Dictionary<int, ObjData>();

    Dictionary<Transform, ObjItem> ornamentsDict = new Dictionary<Transform, ObjItem>();

    bool onDraging;
    private void Start()
    {
        SetDict();
        InitOrnaments();
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

    void InitOrnaments()
    {
        for (int i = 0; i < modeData.ornamentsModes.Count; i++)
        {
            ObjItem obj = null;
            int id = modeData.ornamentsModes[i].objId;
            if (id != 0)
            {
                if (!objDataDict.ContainsKey(id))
                {
                    Debug.Log($"存档ID在基础数据中找不到{id}");
                    break;
                }
                ObjData objData = objDataDict[id];
                GameObject go = Instantiate(objItem, ornamentsBoxs[i]);
                obj = go.GetComponent<ObjItem>();
                obj.InitItem(objData, modeData.ornamentsModes[i].count,ornamentsBoxs[i]);

                ItemListener(go);
            }

            ornamentsDict.Add(ornamentsBoxs[i], obj);
        }
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

        print(eventData.pointerEnter.name);
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
        if (target.tag == "W_OrnamentsBox")
        {
            MoveValue(go.transform.parent, target);
        }
        else if (target.parent.tag == "W_OrnamentsBox")
        {
            MoveValue(go.transform.parent, target.parent);
        }
        else if (target.tag == "OrnamentsBox" || target.parent.tag == "OrnamentsBox")
        {
            if (target.parent.tag == "OrnamentsBox")
                target = target.parent;

            RemoveItemListener(go);

            ObjItem _obj = camp.roleInfo.heroEquipmentInfo.AddOrnamentsItem(go, target);

            if (_obj != null)
            {
                _obj.transform.SetParent(goBox);
                _obj.transform.localPosition = Vector3.one;

                ItemListener(_obj.gameObject);
            }

            ornamentsDict[goBox] = _obj;
        }

    }

    public void AddMoveItem(ObjItem objItem,Transform target)
    {
        objItem.transform.SetParent(target);
        objItem.transform.localPosition = Vector3.one;

        ornamentsDict[target] = objItem;
        ItemListener(objItem.gameObject);
    }

    //增加一个数据
    public void AddValue(ObjData objData, int count)
    {
        int addBoxIndex = 0;
        foreach (var item in ornamentsDict)
        {
            if (item.Value == null)
            {
                GameObject go = Instantiate(objItem, item.Key);
                ObjItem obj = go.GetComponent<ObjItem>();

                obj.InitItem(objData, count,item.Key);
                ornamentsDict[item.Key] = obj;

                ItemListener(go);

                if (modeData.ornamentsModes.Count > addBoxIndex)
                {
                    modeData.ornamentsModes[addBoxIndex].objId = objData.id;
                    modeData.ornamentsModes[addBoxIndex].count = count;
                }
                else
                {
                    modeData.ornamentsModes.Add(new KanpsackMode());
                    modeData.ornamentsModes[addBoxIndex].objId = objData.id;
                    modeData.ornamentsModes[addBoxIndex].count = count;
                }
                return;
            }
            addBoxIndex++;
        }

        Debug.Log("一个空格子都没找到,包满了");
    }

    //删除
    void RemoveValue(Transform key)
    {
        //这个类型的物品应该都不能够堆叠的吧？--直接写删除逻辑
        Destroy(ornamentsDict[key]);
        if (ornamentsDict[key] == null)
        {
            Debug.Log("验证一下空");
        }
        //ornamentsDict[key] = null;

    }

    //移动数据
    void MoveValue(Transform source, Transform target)
    {
        ObjItem targetItem = ornamentsDict[target];
        ObjItem sourceItem = ornamentsDict[source];

        sourceItem.transform.SetParent(target);
        sourceItem.transform.localPosition = Vector3.zero;
        ornamentsDict[target] = sourceItem;

        //目标点有可能是空的
        if (targetItem != null)
        {
            targetItem.transform.SetParent(source);
            targetItem.transform.localPosition = Vector3.zero;
        }


        ornamentsDict[source] = targetItem;
    }
}
