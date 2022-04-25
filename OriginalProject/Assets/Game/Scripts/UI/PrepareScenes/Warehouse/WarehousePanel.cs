using Datas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using GEvent;
using DG.Tweening;
using UnityEngine.AddressableAssets;
/// <summary>
/// 仓库面板
/// </summary>
public class WarehousePanel : MonoBehaviour
{
    #region 弃用2.0
    #region 弃用1.0
    public GameObject itemObj, objItemPrefab, medalItemPrefab;
    public GameObject ornamentPack, medalPack;
    public Toggle ornamentsBtn, medalBtn;
    public Transform ornamentsBox, medalBox;
    public Image dragImg;
    private List<ShopItem> ornamentItems, medalItems;
    private bool initialized;
    ModeData modeData;
    Dictionary<int, ObjData> objDataDict = new Dictionary<int, ObjData>();
    //Dictionary<int, MedalAttribute> medalAttriDic = new Dictionary<int, MedalAttribute>();
    Dictionary<int, MedalEntry> medalEntryDic = new Dictionary<int, MedalEntry>();
    private bool onDraging;

    private RectTransform panelRect;
    private bool isFading;

    private RectTransform PanelRect
    {
        get
        {
            if (panelRect == null)
                panelRect = GetComponent<RectTransform>();
            return panelRect;
        }
    }

    public void InitialPanel()
    {
        SetDict();
        medalItems = new List<ShopItem>(medalBox.GetComponentsInChildren<ShopItem>());
        foreach (var item in medalItems)
        {
            //item.SetBoxRaycast(true);
            //item.itemIcon.raycastTarget = false;
            item.gameObject.tag = "W_MedalBox";
            item.Clear();
            item.OnHoverEnter += OnItemHoverEnter;
            item.OnHoverExit += OnItemHoverExit;
            //item.OnLeftClick += OnItemLeftClick;
            UIEventManager.AddTriggersListener(item.gameObject).onDrag = OnItemDrag;
            UIEventManager.AddTriggersListener(item.gameObject).onEndDrag = OnItemEndDrag;
        }
        if (modeData.packMedals != null)
        {
            for (int i = 0; i < modeData.packMedals.Count; i++)
            {
                ObjData obj;
                if (modeData.packMedals[i] < modeData.medalModes.Count)
                {
                    if (objDataDict.TryGetValue(modeData.medalModes[modeData.packMedals[i]].objId, out obj))
                    {
                        AddMedal(obj, modeData.medalModes[modeData.packMedals[i]]);
                    }
                }
            }
        }
        else
        {
            modeData.packMedals = new List<int>();
        }
        ornamentItems = new List<ShopItem>(ornamentsBox.GetComponentsInChildren<ShopItem>());
        foreach (var item in ornamentItems)
        {
            //item.SetBoxRaycast(true);
            //item.itemIcon.raycastTarget = false;
            item.gameObject.tag = "W_OrnamentsBox";
            item.Clear();
            GameObject go = Instantiate<GameObject>(objItemPrefab, item.transform);
            go.name = "ObjItem";
            go.SetActive(false);
            item.OnHoverEnter += OnItemHoverEnter;
            item.OnHoverExit += OnItemHoverExit;
            //item.OnLeftClick += OnItemLeftClick;
            UIEventManager.AddTriggersListener(item.gameObject).onDrag = OnItemDrag;
            UIEventManager.AddTriggersListener(item.gameObject).onEndDrag = OnItemEndDrag;
        }
        for (int i = 0; i < modeData.ornamentsModes.Count; i++)
        {
            ObjData obj;
            if (objDataDict.TryGetValue(modeData.ornamentsModes[i].objId, out obj))
            {
                AddOrnament(obj);
            }
        }
        EventHelper.Instance.AddEvent(GEventType.AddItem, RecieveItem);
        EventHelper.Instance.AddEvent(GEventType.RemoveItem, RemoveItem);
        initialized = true;
    }

    private void OnItemLeftClick(ShopItem item)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            print("售出物品");
            ResPanel.Instance.ChangeResource(item.Obj.sell);
            item.hoverInfoUI.Hide();
            item.ReputInfoUI();
            item.RemoveItem();
            SaveData();
        }
    }

    private void OnItemHoverEnter(ShopItem item, HoverInfoUI hoverInfo)
    {
        hoverInfo.AddItem(item.Obj.name, 0, Color.white);
        if (item.Obj.objType.Equals(ObjType.饰品))
        {
            hoverInfo.AddItem(item.Obj.describe, 1, Color.white);
        }
        else if (item.Obj.objType.Equals(ObjType.勋章))
        {
            /*int index = 1;
            MedalMode medalMode = (item as MedalInstance).medalInfo.copyMedalMode;
            if (medalMode.life > 0)
                hoverInfo.AddItem("生命+" + medalMode.life, index++, Color.white);
            if (medalMode.damage > 0)
                hoverInfo.AddItem("伤害+" + medalMode.damage, index++, Color.white);
            if (medalMode.speed > 0)
                hoverInfo.AddItem("速度+" + medalMode.speed, index++, Color.white);
            if (medalMode.accurate > 0)
                hoverInfo.AddItem("精准+" + medalMode.accurate, index++, Color.white);
            if (medalMode.evade > 0)
                hoverInfo.AddItem("闪避+" + medalMode.evade, index++, Color.white);
            if (medalMode.dmgReduce > 0)
                hoverInfo.AddItem("减伤+" + medalMode.dmgReduce.ToString("P0"), index++, Color.white);
            if (medalMode.critical > 0)
                hoverInfo.AddItem("暴击+" + medalMode.critical.ToString("P0"), index++, Color.white);
            if (medalMode.bleedDef > 0)
                hoverInfo.AddItem("流血抗性+" + medalMode.bleedDef.ToString("P0"), index++, Color.white);
            if (medalMode.poisonDef > 0)
                hoverInfo.AddItem("中毒抗性+" + medalMode.poisonDef.ToString("P0"), index++, Color.white);
            if (medalMode.moveDef > 0)
                hoverInfo.AddItem("位移抗性+" + medalMode.moveDef.ToString("P0"), index++, Color.white);
            if (medalMode.dizzinessDef > 0)
                hoverInfo.AddItem("眩晕抗性+" + medalMode.dizzinessDef.ToString("P0"), index++, Color.white);
            if (medalMode.deathDef > 0)
                hoverInfo.AddItem("死亡抗性+" + medalMode.deathDef.ToString("P0"), index++, Color.white);
            if (medalMode.debuffDef > 0)
                hoverInfo.AddItem("减益抗性+" + medalMode.debuffDef.ToString("P0"), index++, Color.white);
            if (medalMode.entryID != 0)
            {
                hoverInfo.AddItem(medalEntryDic[medalMode.entryID].name + ":" + medalEntryDic[medalMode.entryID].describe, index++, Color.white);
            }*/
        }
        hoverInfo.Show();
        hoverInfo.transform.parent = transform;
    }

    private void OnItemHoverExit(ShopItem item, HoverInfoUI hoverInfo)
    {
        hoverInfo.Hide();
        item.ReputInfoUI();
    }

    void RecieveItem(Hashtable args)
    {
        print("recieve item");
        ObjData objData = args["ObjData"] as ObjData;
        if (objData != null)
        {
            if (objData.objType.Equals(ObjType.饰品))
            {
                AddOrnament(objData);
                SaveData();
            }
            else if (objData.objType.Equals(ObjType.勋章))
            {
                MedalMode data = args["medalInfo"] as MedalMode;
                AddMedal(objData, data);
                SaveData();
            }
        }
    }

    void RemoveItem(Hashtable args)
    {
        SaveData();
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

        DataSetItem medalDataSet = DataManager.Instance.GetData("MedalData");
        MedalDataSet medalData = medalDataSet.scriptableObject as MedalDataSet;
        foreach (var entry in medalData.medalEntries)
        {
            medalEntryDic.Add(entry.id, entry);
        }
    }

    //添加一个饰品
    public void AddOrnament(ObjData objData)
    {
        bool hasEmptyBox = false;
        for (int i = 0; i < ornamentItems.Count; i++)
        {
            if (ornamentItems[i].Obj == null)
            {
                hasEmptyBox = true;
                ornamentItems[i].SetItemData(objData, 1, false);
                ObjItem objItem = ornamentItems[i].GetComponentInChildren<ObjItem>(true);
                if (objItem == null)
                {
                    GameObject go = Instantiate<GameObject>(objItemPrefab, ornamentItems[i].transform);
                    go.name = "ObjItem";
                    objItem = go.GetComponent<ObjItem>();
                    go.SetActive(false);
                }
                objItem.InitItem(objData, 1, ornamentItems[i].transform);
                break;
            }
        }
        if (!hasEmptyBox)
        {
            int boxCount = ornamentItems.Count;
            ornamentItems.AddRange(ExtendItemBoxes(ornamentsBox, 6));
            if (ornamentItems.Count > boxCount)
            {
                ornamentItems[boxCount].SetItemData(objData, 1, false);
            }
        }
    }
    //添加一个勋章
    public void AddMedal(ObjData objData, MedalMode medalMode)
    {
        bool hasEmptyBox = false;
        for (int i = 0; i < medalItems.Count; i++)
        {
            if (medalItems[i].Obj == null)
            {
                hasEmptyBox = true;
                medalItems[i].SetItemData(objData, 1, false);
                (medalItems[i] as MedalInstance).medalInfo = new MedalInfo(medalMode);

                ObjItem objItem = medalItems[i].GetComponentInChildren<ObjItem>(true);
                if (objItem == null)
                {
                    GameObject go = Instantiate<GameObject>(medalItemPrefab, medalItems[i].transform);
                    go.name = "ObjItem";
                    objItem = go.GetComponent<ObjItem>();
                    go.SetActive(false);
                }
                objItem.InitItem(objData, 1, medalItems[i].transform);
                (objItem as MedalObjItem).medalMode = medalMode;
                break;
            }
        }
        if (!hasEmptyBox)
        {
            int boxCount = medalItems.Count;
            medalItems.AddRange(ExtendItemBoxes(medalBox, 6));
            if (medalItems.Count > boxCount)
            {
                medalItems[boxCount].SetItemData(objData, 1, false);
                (medalItems[boxCount] as MedalInstance).medalInfo = new MedalInfo(medalMode);
            }
        }
    }

    //扩展背包格子
    List<ShopItem> ExtendItemBoxes(Transform container, int extendCount)
    {
        List<ShopItem> addItems = new List<ShopItem>();
        for (int i = 0; i < extendCount; i++)
        {
            GameObject go = Instantiate<GameObject>(itemObj, container);
            addItems.Add(go.GetComponent<ShopItem>());
        }
        if (addItems.Count > 0)
            return addItems;
        else
            return null;
    }

    void ExchangeItem(ShopItem source, ShopItem target)
    {
        int sourceSibling = source.transform.GetSiblingIndex();
        int targetSibling = target.transform.GetSiblingIndex();
        source.transform.SetSiblingIndex(targetSibling);
        target.transform.SetSiblingIndex(sourceSibling);
    }

    void SaveData()
    {
        modeData.ornamentsModes.Clear();
        for (int i = 0; i < ornamentItems.Count; i++)
        {
            if (ornamentItems[i].Obj != null)
            {
                KanpsackMode data = new KanpsackMode();
                data.objId = ornamentItems[i].Obj.id;
                data.count = ornamentItems[i].itemCount;
                modeData.ornamentsModes.Add(data);
            }
        }
        //modeData.MedalModes.Clear();
        modeData.packMedals.Clear();
        for (int i = 0; i < medalItems.Count; i++)
        {
            if (medalItems[i].Obj != null)
            {
                MedalMode data = (medalItems[i] as MedalInstance).medalInfo.copyMedalMode;
                //data.objId = medalItems[i].Obj.id;
                //data.count = medalItems[i].itemCount;
                //modeData.MedalModes.Add(data);
                modeData.packMedals.Add(modeData.medalModes.IndexOf(data));
            }
        }
    }

    RectTransform OnItemDrag(GameObject go, PointerEventData eventData)
    {

        ShopItem dragItem = go.GetComponent<ShopItem>();
        if (dragItem.Obj == null)
            return null;
        onDraging = true;
        dragItem.itemIcon.enabled = false;
        dragImg.sprite = dragItem.itemIcon.sprite;
        RectTransform rectTransform = dragImg.GetComponent<RectTransform>();
        Vector3 globalMousePos;
        dragImg.gameObject.SetActive(true);

        return rectTransform;
    }

    void OnItemEndDrag(GameObject go, PointerEventData eventData)
    {
        if (!onDraging)
            return;
        onDraging = false;

        ShopItem dragItem = go.GetComponent<ShopItem>();
        dragItem.itemIcon.enabled = true;
        dragImg.gameObject.SetActive(false);
        GameObject target = eventData.pointerEnter;
        if (target.tag == "W_OrnamentsBox")
        {
            ShopItem targetItem = target.GetComponent<ShopItem>();
            ExchangeItem(dragItem, targetItem);
        }
        else if (target.name.Equals("medalBox"))
        {
            Hashtable args = new Hashtable();
            args.Add("MedalData", dragItem);
            //args.Add("Icon", dragImg.sprite);
            EventHelper.Instance.ExcuteEvent(GEventType.RightClickMedal, args);
            dragItem.RemoveItem();
        }
        else if (target.tag == "OrnamentsBox" || target.transform.parent.tag == "OrnamentsBox")
        {
            if (target.transform.parent.tag == "OrnamentsBox")
                target = target.transform.parent.gameObject;

            dragItem.RemoveItem();
            GameObject objItem = go.transform.Find("ObjItem").gameObject;
            objItem.SetActive(true);

            //装备饰品，返回替换的饰品
            ObjItem _obj = Camp.Instance.roleInfo.heroEquipmentInfo.AddOrnamentsItem(objItem, target.transform);

            if (_obj != null)
            {
                AddOrnament(_obj.objData);
                Destroy(_obj.gameObject);
            }
            SaveData();
        }
        else if (target.tag == "MedalBox" || target.transform.parent.tag == "MedalBox")
        {
            if (target.transform.parent.tag == "MedalBox")
                target = target.transform.parent.gameObject;
            dragItem.RemoveItem();
            GameObject objItem = go.transform.Find("ObjItem").gameObject;
            objItem.SetActive(true);
            //装备勋章，返回替换的勋章
            ObjItem _obj = Camp.Instance.roleInfo.heroEquipmentInfo.AddMedalItem(objItem, target.transform);
            if (_obj != null)
            {
                AddMedal(_obj.objData, (_obj as MedalObjItem).medalMode);
                Destroy(_obj.gameObject);
            }
        }
    }

    public void SetPanel(bool isOpen)
    {
        if (isOpen)
        {
            if (!initialized)
            {
                InitialPanel();
            }
            if (!isFading)
            {
                isFading = true;
                gameObject.SetActive(true);
                PanelRect.localScale = Vector3.zero;
                PanelRect.DOScale(Vector3.one, 0.3f).onComplete = () => isFading = false;
            }
        }
        else
        {
            if (!isFading)
            {
                isFading = true;
                PanelRect.DOScale(Vector3.zero, 0.15f).onComplete = () => { isFading = false; gameObject.SetActive(false); };
            }
        }
    }

    public void OpenPanel(bool isMedal)
    {
        if (isMedal)
        {
            medalBtn.isOn = true;
        }
    }
    #endregion

    public static WarehousePanel instance;

    public RoleInfoPanel roleInfoPanel;
    private HoverInfoUI hover;

    private const string STR_ICON = "icon";
    private const string STR_HOVER = "HoverInfoUI";

    private void Awake()
    {
        instance = this;
    }

    public void PackBtnClick()
    {
        OrnamentBtnClick();
        gameObject.SetActive(true);
    }

    public void CloseBtnClick()
    {
        gameObject.SetActive(false);
    }

    public void OrnamentBtnClick()
    {
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        HideAll();
        List<ObjData> objDatas = DataManager.Instance.GetOrnamentDatasFromMode();
        for (int i = 0; i < objDatas.Count; ++i)
        {
            InitOrnamentObj(ornamentsBox.transform.GetChild(i).gameObject, objDatas[i], i);
        }
    }

    public void MedalBtnClick()
    {
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        HideAll();
        List<MedalObjData> medalObjDatas = DataManager.Instance.GetMedalsFromMode();
        for (int i = 0; i < medalObjDatas.Count; ++i)
        {
            InitMedalObj(ornamentsBox.transform.GetChild(i).gameObject, medalObjDatas[i], i);
        }
    }

    private void InitOrnamentObj(GameObject go, ObjData objData, int index)
    {
        if (go.GetComponent<ShopItem>() != null) 
            go.GetComponent<ShopItem>().SetItemData(objData, index, 1);
    }

    private void InitMedalObj(GameObject go, MedalObjData objData, int inIndex)
    {
        if (go.GetComponent<ShopItem>() != null)
            go.GetComponent<ShopItem>().SetItemData(objData, inIndex, 1);
    }

    public void OrnamentObjClick(GameObject go, ObjData objData, int index)
    {
        if (!roleInfoPanel.gameObject.activeSelf || !go.transform.Find(STR_ICON).gameObject.activeSelf)
        {
            return;
        }

        if (roleInfoPanel.AddOrnament(objData, 1))
        {
            DataManager.Instance.RemoveOrnamentFromMode(index);
            go.transform.Find(STR_ICON).gameObject.SetActive(false);
        }
    }

    public void MedalObjClick(GameObject go, MedalObjData objData)
    {
        if (!roleInfoPanel.gameObject.activeSelf || !go.transform.Find(STR_ICON).gameObject.activeSelf)
        {
            return;
        }

        if (roleInfoPanel.AddMedal(objData))
        {
            DataManager.Instance.RemoveMedalFromMode(objData);
            go.transform.Find(STR_ICON).gameObject.SetActive(false);
        }
    }

    private void AddMedalToRoll(GameObject go, MedalObjData objData)
    {
        RollMedalPanel.instance?.addMedal(objData);
    }

    private void HideAll()
    {
        //for (int i = 0; i < ornamentsBox.transform.childCount; ++i)
        //{
        //    ornamentsBox.transform.GetChild(i).Find(STR_ICON).gameObject.SetActive(false);
        //}
        for (int i = 0; i < ornamentsBox.transform.childCount; ++i)
            ornamentsBox.transform.GetChild(i).GetComponent<ShopItem>()?.Clear();
    }
    #endregion


}
