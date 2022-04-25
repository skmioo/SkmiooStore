using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 悬停信息UI
/// </summary>
public class HoverInfoUI : MonoBehaviour
{
    public GameObject infoItem;
    [SerializeField]
    private List<Text> texts;

    public Text GetText(int index)
    {
        if (index < texts.Count)
            return texts[index];
        else
            return null;
    }
    public void Show(int index, string str,Vector2 localPos) {
        gameObject.SetActive(true);
      Text txt =  GetText(index);
        if (txt == null) return;
        txt.text = LanguageController.GetValue(str);
        txt.gameObject.SetActive(true);
        txt.rectTransform.anchoredPosition = localPos;
    }
    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
        foreach (var item in texts)
        {
            item.gameObject.SetActive(false);
        }
    }

    public virtual Text AddItem(string info,int index,Color color,int size=14)
    {
        if (texts == null)
            texts = new List<Text>();
        Text text;
        if (index > texts.Count - 1)
        {
            GameObject go = Instantiate<GameObject>(infoItem, transform);
            text = go.GetComponent<Text>();
            texts.Add(text);
        }
        else
        {
            text = texts[index];
        }
        text.text = LanguageController.GetValue(info);
        text.gameObject.SetActive(true);
        text.color = color;
        text.fontSize = size;
        text.transform.SetAsLastSibling();
        return text;
    }

    public virtual void ClearData()
    {
        for (int i = 0; i < texts.Count; i++)
        {
            Destroy(texts[i].gameObject);
        }
        texts.Clear();
    }
}
