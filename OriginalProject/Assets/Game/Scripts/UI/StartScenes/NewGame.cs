using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Datas;

public class NewGame : MonoBehaviour
{
    //拷贝初始化存档
    public Button goButton;
    public InputField inputField;

    string inputName;

    ModeDataSet modeDataSet;
    private void Awake()
    {
        goButton.interactable = false;
        inputField.onEndEdit.AddListener(EndInputField);
        inputField.onValueChanged.AddListener((s) => { 
            inputField.text = inputField.text.Replace(" ", "");
            AudioManager.Instance.PlayAudio(AudioName.TABLE_TENNIS_Ball_Table_Hit_02_mono, AudioType.Common);
             });
        goButton.onClick.AddListener(goButtonDwon);

        modeDataSet = DataManager.modeDataSet;
    }

    private void EndInputField(string arg0)
    {
        inputName = arg0;

        if (inputName.Length > 0)
        {
            goButton.interactable = true;
        }
        else
        {
            goButton.interactable = false;
        }
    }


    private void goButtonDwon()
    {
        goButton.onClick.RemoveAllListeners();
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        AudioManager.Instance.SetPlayOpenVideo(true);
        ModeData newData = modeDataSet.modeDatas[0].Clone(modeDataSet.modeDatas[0]);

        newData.name = inputName;

        modeDataSet.modeDatas.Add(newData);

        GameScenesController.Instance.GoLoadScenes(1, "Data/Main/ZH_DataSet");
        
        DataManager.modeIndex = modeDataSet.modeDatas.Count - 1;
    }
}
