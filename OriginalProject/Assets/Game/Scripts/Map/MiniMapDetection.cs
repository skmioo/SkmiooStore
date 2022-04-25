using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;

public class MiniMapDetection : MonoBehaviour
{
    public List<AssetReferenceSprite> sprite;

    private List<Sprite> spriteList;

    internal bool isExplore;

    int index;
    private void Start()
    {

        spriteList = new List<Sprite>();

        sprite[0].LoadAssetAsync<Sprite>().Completed += s =>
        {
            spriteList.Add(s.Result);
            sprite[1].LoadAssetAsync<Sprite>().Completed += s1 =>
            {
                spriteList.Add(s1.Result);
                sprite[2].LoadAssetAsync<Sprite>().Completed += s2 =>
                {
                    spriteList.Add(s2.Result);
                };
            };
        };
        Vector2 wh = transform.GetComponent<RectTransform>().sizeDelta;
        transform.gameObject.AddComponent<BoxCollider2D>().size = wh;
        isExplore = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (spriteList.Count>0)
        {
            transform.GetComponent<Image>().sprite = spriteList[1];
        }
        isExplore = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.GetComponent<Image>().sprite = spriteList[2];
        GameObject.Destroy(transform.GetComponent<BoxCollider2D>());
    }

    public void UnlockMiniMap()
    {
        if (transform.GetComponent<BoxCollider2D>()!=null)
        {
            transform.GetComponent<Image>().sprite = spriteList[1];
            GameObject.DestroyImmediate(transform.GetComponent<BoxCollider2D>());
            isExplore = true;
        }
    }
}
