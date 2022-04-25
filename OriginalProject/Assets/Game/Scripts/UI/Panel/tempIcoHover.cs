using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempIcoHover : MonoBehaviour
{
    public HoverInfoUI hover;
    [TextArea]
    public string hoverString;

    private void Start()
    {
        hover.AddItem(hoverString, 0, Color.white);

        UIEventManager.AddTriggersListener(gameObject).onEnter = (inGo) =>
        { hover.Show(); hover.transform.parent = transform.root; hover.transform.SetAsLastSibling(); };

        UIEventManager.AddTriggersListener(gameObject).onExit = (inGo) =>
        { hover.gameObject.SetActive(false); hover.transform.parent = transform; };
    }

    public void UpdateText(string sText)
    {
        hoverString = sText;
        hover.ClearData();
        hover.AddItem(sText, 0, Color.white);
    }
}
