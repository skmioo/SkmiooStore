using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using DG.Tweening;

public class ReadyMapCtrl : MonoBehaviour
{
    public RectTransform bigMap;
    public RectTransform[] smallMap;
    private GameObject[] smallMapSelObj;
    private Image[] smallMapBtnImage;
    private Image[] smallMapImage;
    private Image[] smallMapSelImage;
    public Text txWarning;
    public List<AssetReferenceSprite> taskIcons;

    int warningValue;
    TaskObjData[] tasks;

    int clickValue = -1;
    int mapIndex = -1;
    Sequence seq;

    private void Awake()
    {
        smallMapSelObj = new GameObject[smallMap.Length];
        smallMapBtnImage = new Image[smallMap.Length];
        smallMapImage = new Image[smallMap.Length];
        smallMapSelImage = new Image[smallMap.Length];
        for(int i = 0; i < smallMap.Length; i++)
        {
            if(smallMap[i] != null)
            {
                smallMapBtnImage[i] = smallMap[i].GetComponent<Image>();

                GameObject imgObj = smallMap[i].Find("Image").gameObject;
                smallMapImage[i] = imgObj.GetComponent<Image>();

                GameObject imgSelObj = smallMap[i].Find("ImageSel").gameObject;
                smallMapSelObj[i] = imgSelObj;
                smallMapSelImage[i] = imgSelObj.GetComponent<Image>();
            }
        }

    }

    public void open(int inIndex)
    {
        mapIndex = inIndex;
        tasks = new TaskObjData[smallMap.Length];

    }

    public void setWarningValue(int inValue)
    {
        if (inValue > 100) inValue = 100;
        if (inValue < 0) inValue = 0;

        warningValue = inValue;
        var tempValue = 1 - ((float)inValue / 100.0f);
        // bigMapMater.DOFloat(tempValue, "_colorSwitch", 0.5f);
        txWarning.text = "" + warningValue;
    }

    public void setBigData(string inName, int inWarning)
    {
        bigMap.GetComponentInChildren<Text>().text = LanguageController.GetValue(inName);
        setWarningValue(inWarning);
    }

    public void setSmallData(int inIndex, bool isOpeng)
    {
        if (inIndex > smallMap.Length) return;
        smallMap[inIndex].gameObject.SetActive(isOpeng);
    }
    public void setSmallData(int inIndex, TaskObjData inTask, bool isOpeng, System.Action<TaskObjData, int, int> inFunc)
    {
        if (inIndex > smallMap.Length) return;
        tasks[inIndex] = inTask;
        // smallMap[inIndex].GetComponentInChildren<Text>().text = tasks[inIndex].GetTaskName();
        smallMap[inIndex].gameObject.SetActive(isOpeng);

        N_TaskType taskType = inTask.GetTaskType();
        AssetReferenceSprite taskIcon = null;
        AssetReferenceSprite taskSelIcon = null;
        switch(taskType)
        {
            case N_TaskType.扫荡:
                taskIcon = taskIcons[0];
                taskSelIcon = taskIcons[1];
                break;
            case N_TaskType.侦查:
                taskIcon = taskIcons[2];
                taskSelIcon = taskIcons[3];
                break;
            case N_TaskType.固定boss:
                taskIcon = taskIcons[4];
                taskSelIcon = taskIcons[5];
                break;
            case N_TaskType.随机boss:
                taskIcon = taskIcons[4];
                taskSelIcon = taskIcons[5];
                break;
        }

        taskIcon.LoadAssetAsync().Completed += inGo => { smallMapBtnImage[inIndex].sprite = inGo.Result; };
        taskSelIcon.LoadAssetAsync().Completed += inGo => { smallMapImage[inIndex].sprite = inGo.Result; };
        taskSelIcon.LoadAssetAsync().Completed += inGo => { smallMapSelImage[inIndex].sprite = inGo.Result; };

        UIEventManager.AddTriggersListener(smallMap[inIndex].gameObject).onLeftClick = (inGo) =>
        { inFunc(tasks[inIndex], mapIndex, inIndex); clickSmall(inIndex); };
    }

    public void clickSmall(int nIndex)
    {
        clearClick();
        clickValue = nIndex;
        seq.Kill();
        seq = DOTween.Sequence();
        seq.Append(smallMap[nIndex].DOScale(new Vector2(1.2f,1.2f),0.5f)).
        Append(smallMap[nIndex].DOScale(new Vector2(1f,1f),0.5f));
        seq.SetLoops(-1);

        // for(int i = 0; i < smallMapSelObj.Length; i++)
        // {
        //     GameObject imgSelect = smallMapSelObj[i];
        //     if(imgSelect != null)
        //     {   
        //         if(nIndex == i)
        //         {
        //             imgSelect.SetActive(true);
        //         }
        //         else
        //         {
        //             imgSelect.SetActive(false);
        //         }
        //     }
        // }
    }

    public void clearClick()
    {
        seq.Kill();
        clickValue = -1;
        for(int i = 0; i < smallMap.Length; i++)
        {
            if(smallMap[i] != null)
            {
                smallMap[i].DOScale(new Vector2(1,1),0.01f);
            }
        }
        // for(int i = 0; i < smallMapSelObj.Length; i++)
        // {
        //     if(smallMapSelObj[i] != null)
        //     {
        //         smallMapSelObj[i].SetActive(false);
        //     }
        // }
    }

}
