using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class HeroSkillNote : MonoBehaviour
{
   ObjLife m_objlife;
   public  Text m_Text;
    public void Initialized(ObjLife _objlife)
    {
     m_objlife = _objlife;
    }
    public void play(float time) {
        m_Text.text = BattleFlowController.Instance.currentSkill.tips;
      
        Sequence seq = DOTween.Sequence();
        seq.OnStart(()=> { gameObject.SetActive(true); });
        seq.AppendInterval(time);
        seq.AppendCallback(() => { gameObject.SetActive(false); });

    }
}
