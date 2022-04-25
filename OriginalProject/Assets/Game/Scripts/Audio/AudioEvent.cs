using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEvent : MonoBehaviour
{
    /// <summary>
    /// 通用点击
    /// </summary>
    public void Click_Common()
    {
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
    }
    /// <summary>
    /// 启程
    /// </summary>
    public void TheStart_Common()
    {
        AudioManager.Instance.PlayAudio(AudioName.MOVEMENT_Snow_RR1_mono, AudioType.Common);
    }
  



}
