using Datas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeDataItem : MonoBehaviour
{
    public Text _name;
    public int modeIndex;

    [HideInInspector]
    public ModeData modeData;
    ModeDataBox modeDataBox;
    /// <summary>
    /// 被创建时的初始化
    /// </summary>
    public void InitItem(ModeData _modeData,int index,ModeDataBox _modeDataBox)
    {
        modeData = _modeData;
        modeIndex = index;
        modeDataBox = _modeDataBox;

        _name.text = LanguageController.GetValue("存档") + $"{index}:{_modeData.name}";
    }

    public void DestroyButtonDwon()
    {
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        modeDataBox.DestroyButtonDwon(this);
    }
}
