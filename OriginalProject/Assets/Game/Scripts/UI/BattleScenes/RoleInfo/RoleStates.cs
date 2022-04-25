using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;

public class RoleStates : MonoBehaviour
{
    /// <summary>
    /// 状态图标引用
    /// </summary>
    public ReferenceTool statesIcons;
    public float waitTime = 1;
    private Image stateIcon;
    private Color before = new Color(0, 0, 0, 0), after = new Color(1, 1, 1, 1);
    private bool onPlay = false;
    private ObjLife SelfObjLife=null;

    public class StatusData
    {
        public string key;
        public float delay;
        public int priority;
        public int value;
    }

    List<StatusData> status;

    void Awake()
    {
        if (statesIcons == null)
        {
            statesIcons = GetComponent<ReferenceTool>();
        }
        status = new List<StatusData>();
        stateIcon = GetComponent<Image>();
    }

    public void SetStates(string key,float delay,int value =0,ObjLife objlif=null)
    {
        if (statesIcons.ContainsKey(key))
        {
            status.Add(new StatusData
            {
                key = key,
                delay = delay,
                priority = statesIcons.priority[statesIcons.keys.IndexOf(key)],
                value = value
            }) ;
            status.OrderBy(x => x.priority);
            if(objlif!=null)
            {
                SelfObjLife = objlif;
            }
            if (!onPlay)
            {
                Play();
            }
        }
    }

    private void Play()
    {
        if (status.Count == 0)
        {
            onPlay = false;
            return;
        }

        var max = status[0];
        status.RemoveAt(0);
        var key = max.key;
        if (key== "闪避")
        {
            return;
        }
        var delay = max.delay;
        onPlay = true;
       if(SelfObjLife!=null&& max.value!=0)
        {
            SelfObjLife.ShowValue(max.value, 0,false);
        }
        stateIcon.sprite = (Sprite)statesIcons[key];
        stateIcon.color = before;
        stateIcon.type = Image.Type.Simple;
        stateIcon.SetNativeSize();
        stateIcon.rectTransform.sizeDelta = new Vector2(
              stateIcon.sprite.rect.width,
             stateIcon.sprite.rect.height) * 0.01f;

        Sequence seq = DOTween.Sequence();
        seq.
              AppendInterval(delay).
              Append(stateIcon.DOColor(after, 0.1f)).
              AppendInterval(waitTime).
              Append(stateIcon.DOColor(before, 0.1f)).
              AppendCallback(() =>
              {
                      Play();
              });
    }

}
