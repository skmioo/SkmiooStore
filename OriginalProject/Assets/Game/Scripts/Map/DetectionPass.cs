using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectionPass : MonoBehaviour
{
    public Dictionary<GameObject, List<Sprite>> passMiniMapDicSp = new Dictionary<GameObject, List<Sprite>>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in passMiniMapDicSp)
        {
            GameObject go = item.Key.gameObject;
            Vector2 w = go.transform.GetComponent<RectTransform>().sizeDelta;
            go.AddComponent<BoxCollider2D>().size = w;
        }

        Vector2 wh = transform.GetComponent<RectTransform>().sizeDelta;
        gameObject.AddComponent<BoxCollider2D>().size = wh*0.9f;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        gameObject.AddComponent<Rigidbody2D>().isKinematic = true;
    }


    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (passMiniMapDicSp.ContainsKey(collision.gameObject))
    //    {
    //        collision.GetComponent<Image>().sprite = passMiniMapDicSp[collision.gameObject][0];
    //    }
    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (passMiniMapDicSp.ContainsKey(collision.gameObject))
    //    {
    //        collision.GetComponent<Image>().sprite = passMiniMapDicSp[collision.gameObject][1];
    //    }
    //    GameObject.Destroy(collision);
    //}
}
