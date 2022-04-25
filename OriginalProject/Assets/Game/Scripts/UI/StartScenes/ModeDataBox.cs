using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Datas;

/// <summary>
/// 存档盒子--开始界面
/// </summary>
public class ModeDataBox : MonoBehaviour
{
    public GameObject dataItem;
    public GameObject tips;
    public Transform ContentBox;

    List<GameObject> dataItems = new List<GameObject>();
    //当面板被打开时，根据存档的个数生成存档
    ModeDataSet modeDataSet;
    bool dataGet = true;
    public void OpenBox()
    {
        tips.gameObject.SetActive(false);
        gameObject.SetActive(true);
        ///先清除一下存档再生成
        ClearDataItem();
        RestBox();
    }

    public void OffBox()
    {
        gameObject.SetActive(false);
        ClearDataItem();
    }

    private void ClearDataItem()
    {
        foreach (var item in dataItems)
        {
            Destroy(item);
        }
        dataItems.Clear();
    }

    //防止数据还未加载完成的处理
    private void Update()
    {
        //if (dataGet)
        //{
        //    if (DataManager.modeDataSet == null)
        //    {
        //        Debug.Log("数据加载未完成，等待");
        //        //播放数据加载的动画--
        //    }
        //    else
        //    {
        //        RestBox();
        //        //结束循环
        //        dataGet = false;
        //    }
        //} 
    }

    //重置盒子中的内容
    void RestBox()
    {
        if (DataManager.modeDataSet == null)
            return;
        modeDataSet = DataManager.modeDataSet;
        //默认第0个数据为初始化数据
        for (int i = 1; i < modeDataSet.modeDatas.Count; i++)
        {
            GameObject go =  Instantiate(dataItem, ContentBox);//创建数据对象到盒子下
            dataItems.Add(go);
            ModeDataItem modeDataItem = go.GetComponent<ModeDataItem>();
            modeDataItem.InitItem(modeDataSet.modeDatas[i],i,this);

            // go.GetComponent<Button>().onClick.RemoveAllListeners();
            go.GetComponent<Button>().onClick.AddListener(delegate () { ItemClick(go); });

            // UIEventManager.AddTriggersListener(go).onClick += ItemClick;
        }

    }


    void ItemClick(GameObject go)
    {
		if (GameScenesController.Instance.CheckIsLoadingScene())
			return;		
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        ModeDataItem modeDataItem = go.GetComponent<ModeDataItem>();
        DataManager.modeIndex = modeDataItem.modeIndex;

        GameScenesController.Instance.GoLoadScenes(1, "Data/Main/ZH_DataSet");
    }

    ModeDataItem waitModeDataItem;

    public void DestroyButtonDwon(ModeDataItem _modeDataItem)
    {
        tips.gameObject.SetActive(true);
        waitModeDataItem = _modeDataItem;
    }

    //删除一个存档
    public void removeModeData()
    {
        modeDataSet.modeDatas.Remove(waitModeDataItem.modeData);
        dataItems.Remove(waitModeDataItem.gameObject);

        UIEventManager.AddTriggersListener(waitModeDataItem.gameObject).onClick -= ItemClick;
        Destroy(waitModeDataItem.gameObject);
    }
  
}
