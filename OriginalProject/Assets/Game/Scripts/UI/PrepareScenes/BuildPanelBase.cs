using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPanelBase : PanelBase
{
    public virtual void init() { }

    public virtual void mainLoop() { }

    public virtual void RefreshData() { }

    public override void open()
    {
        AudioManager.Instance.PlayAudio(AudioName.DOOR_Metal_Open_Creak_stereo, AudioType.Common);
        BuildPanelMag.Instance.setTouchBox(false);
        base.open();
    }

    public override void close()
    {
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        BuildPanelMag.Instance.setTouchBox(true);
        base.close();
    }
}
