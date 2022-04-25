using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutToStart : MonoBehaviour
{
    public void ButtonDwon()
    {
        //后退至初标题界面
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        GameScenesController.Instance.GoLoadScenes(0);
        UIManager.Instance.Ondestory();

        GEvent.EventHelper.Instance.ClearEvents();
    }

}
