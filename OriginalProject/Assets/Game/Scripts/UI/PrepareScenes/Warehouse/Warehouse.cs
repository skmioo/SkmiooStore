using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Datas;

/// <summary>
/// 暂弃用脚本2020.12.3
/// </summary>
public class Warehouse : MonoBehaviour
{
    public GameObject objItem;

    public Transform[] ornamentsBoxs;
    public Transform[] medalBoxs;

    ModeData modeData;
    Dictionary<int, ObjData> objDataDict = new Dictionary<int, ObjData>();

    private void Start()
    {
        SetDict();

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




    

}
