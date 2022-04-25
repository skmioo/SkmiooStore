using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine;

public class SkillReleaseInfo : MonoBehaviour
{
    public Image bg;
    public Text skillName;
    public float waitTime = 1;
    public float showTime = 1;

    public void ShowSkillName(string name)
    {
      Debug.Log(name);
        skillName.text = name;

        var showColor = new Color(skillName.color.r, skillName.color.g, skillName.color.b, 1);
        var closeColor = new Color(skillName.color.r, skillName.color.g, skillName.color.b, 0);

        Sequence seq = DOTween.Sequence();
        seq.Append(bg.DOColor(Color.white, showTime * 0.5f)).
              Append(skillName.DOColor(showColor, showTime * 0.5f)).
              AppendInterval(waitTime).
              Append(bg.DOColor(new Color(0, 0, 0, 0), showTime * 0.5f)).
              Append(skillName.DOColor(closeColor, showTime * 0.5f));
    }
}
