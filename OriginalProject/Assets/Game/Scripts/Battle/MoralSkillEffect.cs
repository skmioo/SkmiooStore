using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;
using DG.Tweening;
public class MoralSkillEffect : MonoBehaviour
{
    /// <summary>
    /// 士气技能特效
    /// </summary>
    public Image EffectImage;
    private void Awake()
    {
        gameObject.SetActive(false);
        EffectImage.enabled = false;
    }
    public void Play(AssetReferenceSprite ars)
    {
        gameObject.SetActive(true);
        //if (ars.Asset != null)
      //  {
            Debug.Log("测试-Play1");
            ars.LoadAssetAsync().Completed += go =>
            {
                gameObject.SetActive(true);
                EffectImage.sprite = go.Result;
                Sequence seq = DOTween.Sequence();
                seq.AppendCallback(()=> {
                    EffectImage.enabled = true;
                });
                seq.AppendInterval(2.0f);
                seq.AppendCallback(()=> {
                    EffectImage.enabled = false;
                    gameObject.SetActive(false);
                });
              

            };
       // }
       // else
        //{
        //    Debug.Log("测试-Play2");
        //    gameObject.SetActive(false);
        //    EffectImage.enabled = false;
        //}

    }
}
