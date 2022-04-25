using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class FullScreenBloodEffect : MonoBehaviour
{
    public List<Image> List_HeroFillBloodEffect;
    public List<Image> List_MonsterFullBloodEffect;
    public static FullScreenBloodEffect _instance;
    public static FullScreenBloodEffect Instance
    {
        get { return _instance; }
    }
    private void Awake()
    {
        _instance = this;
    }
    private void OnDestroy()
    {
        _instance = null;
    }
    /// <summary>
    /// 展示全屏出血特效
    /// </summary>
    public void Show(RoleType type)
    {
        switch (type)
        {
            case RoleType.英雄:
               
                TweenBlood(List_HeroFillBloodEffect[Mathf.RoundToInt( Random.Range(-0.49f, List_HeroFillBloodEffect.Count-1.0f+0.49f))]);
                break;
            case RoleType.怪物:
                TweenBlood(List_MonsterFullBloodEffect[Mathf.RoundToInt(Random.Range(-0.49f, List_MonsterFullBloodEffect.Count-1.0f + 0.49f))]);
                break;
            default:
                break;
        }
    }
    public Sequence TweenBlood(Image sp)
    {
        
        var seq = DOTween.Sequence();
        seq.Append(sp.DOFade(1, .5f));
        seq.AppendInterval(0.9f);
        seq.Append(sp.DOFade(0, .5f));
        return seq;
    }
}
