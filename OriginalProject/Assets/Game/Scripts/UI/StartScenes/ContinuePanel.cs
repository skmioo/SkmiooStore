using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuePanel : StartGamePanel
{
    public ModeDataBox modeDataBox;

    //private void Start()
    //{
    //    modeDataBox.OpenBox();
    //}
    //需要每次打开面板都刷新盒子,  因为新建存档会增加

    protected override void OpenPanel()
    {
        modeDataBox.OpenBox();
    }

    protected override void OnLanguageChanged()
    {
        string[] tName = {"继续放逐",};
        for(int i = 0; i < langList.Length; i++)
        {
            if(tName[i] != null)
            {
                if(langList[i] != null)
                    langList[i].text = LanguageController.GetValue(tName[i]);
            }
        }

    }
}
