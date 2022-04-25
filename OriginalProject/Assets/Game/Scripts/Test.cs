#define LCC
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
#if LCC
    public Button ButTest;
    private void Awake()
    {
        if (ButTest == null) ButTest = GameObject.Find("ButTest").GetComponent<Button>();
        ButTest.onClick.AddListener(BtnClick);
    }
    public Camera cameraTest;
    public void BtnClick()
    {
     
        return;
        Datas.MapDataSet mapDataSet = DataManager.Instance.GetData("MapData").scriptableObject as Datas.MapDataSet;
        //for (int i = 0; i < mapDataSet.mapDroppings.Count; ++i)
        //{
        //    for (int j = 0; j < mapDataSet.mapDroppings[i].roomDroppings.Count; ++j)
        //    {
        //        for (int k = 0; k < mapDataSet.mapDroppings[i].roomDroppings[j].mapDroppings.Count; ++k)
        //        {
        //            Datas.MapDropping mapDropping = mapDataSet.mapDroppings[i].roomDroppings[j].mapDroppings[k];
        //            Debug.Log(mapDataSet.mapDroppings[i].nameType + "," + mapDataSet.mapDroppings[i].roomDroppings[j].roomType + "," + mapDropping.taskDifficulty);
        //            Dictionary<string, int> drops = mapDropping.CreateDrop();
        //        }
        //    }
        //    for (int j = 0; j < mapDataSet.mapDroppings[i].routeDroppings.Count; ++j)
        //    {
        //        for (int k = 0; k < mapDataSet.mapDroppings[i].routeDroppings[j].mapDroppings.Count; ++k)
        //        {
        //            Datas.MapDropping mapDropping = mapDataSet.mapDroppings[i].routeDroppings[j].mapDroppings[k];
        //            Debug.Log(mapDataSet.mapDroppings[i].nameType + "," + mapDataSet.mapDroppings[i].routeDroppings[j].routeType + "," + mapDropping.taskDifficulty);
        //            Dictionary<string, int> drops = mapDropping.CreateDrop();
        //        }
        //    }
        //}

        Datas.MapDropping mapDropping = mapDataSet.mapDroppings[0].routeDroppings[1].mapDroppings[2];
        Debug.Log(mapDropping.json);
        Dictionary<string, int> drops = mapDropping.CreateDrop();
    }
#endif
    public void BtnClickGetOrnament()
    {
        DataManager.Instance.AddOrnamentToMode(DataManager.Instance.CreateOrnamentData());
    }

    public void BtnClickGetMedal()
    {
        MedalObjData medal = DataManager.Instance.CreateMedal(UnityEngine.Random.Range(1, 7));
        DataManager.Instance.AddMedalToMode(medal);
    }

    #region Addressables 音效加载测试
    private AudioSource source;
    public void BtnClickGetAudioClipData()
    {
        if (source == null) source = gameObject.AddComponent<AudioSource>();
        DataManager.Instance.GetAudioClipData()[0].clip.LoadAssetAsync<AudioClip>().Completed += (s) =>
        {
            source.clip = s.Result;
            source.Play();
        };
    }
    #endregion
}
