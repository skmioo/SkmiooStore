using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class BloodExplosionEffect : MonoBehaviour
{
    private SpriteRenderer HeroBlood=new SpriteRenderer();
    private SpriteRenderer MonsterBlood=new SpriteRenderer();

    [SerializeField]
    public List<SpriteRenderer> ListHeroBlood;
    [SerializeField]
    public List<SpriteRenderer> ListMonsterBlood;

    private bool  _inFadeProgess=false;
    public UnityAction fadeCompletedEvent = null;

    private void OnEnable()
    {
        HeroBlood = ListHeroBlood[Mathf.RoundToInt(Random.Range(-0.49f, ListHeroBlood.Count - 1.0f + 0.49f))];
        MonsterBlood = ListMonsterBlood[Mathf.RoundToInt(Random.Range(-0.49f, ListMonsterBlood.Count - 1.0f + 0.49f))];
    }


    public void SetSortOrder(int value)
    {
        for(int i=0;i<ListHeroBlood.Count;i++)
        {
            ListHeroBlood[i].sortingOrder = value;
            ListMonsterBlood[i].sortingOrder = value;
        }

    }

    /// <summary>
    /// 等待淡出结束后 再进行的事件
    /// </summary>
    /// <param name="fadeCompletedEvent"></param>
    public void WaitFadeOver(UnityAction fadeCompletedEvent)
    {
         
        if (_inFadeProgess==false)
        {
            if (fadeCompletedEvent != null)
                fadeCompletedEvent.Invoke();
        }
        else
            this.fadeCompletedEvent = fadeCompletedEvent;
    }

    public Sequence TweenBlood(SpriteRenderer sp)
    {
        _inFadeProgess = true;
        Debug.Log("TweenBlood startßß");
        sp.transform.localScale = Vector3.zero;   
        var seq = DOTween.Sequence();
        seq.Append(sp.transform.DOScale(Vector3.one,0.15f));

        //seq.Append(sp.DOFade(1, 0.15f));
        //seq.AppendInterval(0.65f);
        //seq.Append(sp.DOFade(0, 0.15f));

        seq.Append(sp.DOFade(1, 0.15f));
        seq.AppendInterval(0.65f);
        seq.Append(sp.DOFade(0, 0.6f).OnComplete(()=>
        {
            _inFadeProgess = false;
            if (fadeCompletedEvent != null)
                fadeCompletedEvent.Invoke();

        }));

        return seq;
    }
    public void TweenBloods()
    { 
        StartCoroutine(TweenBlood());
    }

    public IEnumerator TweenBlood()
    {
        TweenBlood(HeroBlood);
        yield return new WaitForSeconds(0.1f);
        TweenBlood(MonsterBlood);
    }

}
