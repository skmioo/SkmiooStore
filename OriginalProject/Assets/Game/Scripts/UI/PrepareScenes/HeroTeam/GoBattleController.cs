using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBattleController : MonoBehaviour
{
    public GameObject goGoBattle;
    public GoBattle goBattleScript { get { return goGoBattle.GetComponent<GoBattle>(); } }
    // public GameObject goLoukongzhidi;
    // public GameObject goMinghekuangdong;

    public GameObject goGetBackground;
    public GameObject goReadyBackground;

    public void BtnClickGoBattle()
    {

    }
    public void BtnClickGoLoukongzhidi()
    {
        goBattleScript.BtnClickLoukongzhidi();
        Debug.Log("镂空之地Boss");
        {
            //测试
            goBattleScript?.GoButtonDwon();
        }
    }

    public void BtnClickMinghekuangdong()
    {
        goBattleScript.BtnClickMinghekuangdong();
        Debug.Log("冥河矿洞Boss");
        {
            //测试
            goBattleScript?.GoButtonDwon();
        }
    }
    public void BtnClickGoJiaoChengGuanka()
    {
        goBattleScript.BtnClickGoJiaoChengGuanka();
        Debug.Log("教程关卡");
        {
            //测试
            goBattleScript?.GoButtonDwon();
        }
    }
    public void BtnClickRandom()
    {
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        BattleInfo.MapName = Random.Range(0f, 1f) > 0.5f ? MapNameType.冥河矿洞 : MapNameType.镂空之地;
    }

}
