using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitBattleScenes : MonoBehaviour
{
    public static System.Action onBeginExitBattleScenes;
    //退出战斗场景
    public void ExitScenes()
    {
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        UIManager.Instance.PopAllPanel();
        GameScenesController.Instance.GoLoadScenes(1);
        //Invoke("ComeBack", 1f);
        ComeBack();
        Debug.Log("ExitScenes");
    }
    /// <summary>
    /// 退出后对角色减少士气
    /// </summary>
 [System.Obsolete]  public void DamageMorale()
    {
        List< ObjLifeData> heros =   BattleFlowController.Instance.GetHeros();
        foreach (var item in heros)
        {
            if (item.ExistsPermanentBuff(ObjBuffType.逃离副本不损失士气)) continue;
            item.UpdateMorale(-20);
        }
    }

    public void OnClickExit()
    {
        onBeginExitBattleScenes?.Invoke();
    }

    private void ComeBack()
    {
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        Debug.Log("ComeBack");
        //Camp.Instance.ComeBack();
        Camp.backFromBattle = true;
    }

}
