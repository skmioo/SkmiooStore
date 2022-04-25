using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buff_InteractiveGroup : MonoSingleton<Buff_InteractiveGroup>
{
    public RectTransform rectTrans { get { return transform as RectTransform; } }
    [HideInInspector]public HorizontalLayoutGroup groupComponent;
    public GameObject BuffInteractivePrefab;
    public BuffInfo goBuffInfo;
    public List<Buff_Interactive> BuffGroup;
    protected override void Awake()
    {
        base.Awake();
        groupComponent = GetComponent<HorizontalLayoutGroup>();
        BuffInteractivePrefab.SetActive(false);
        BuffGroup = new List<Buff_Interactive>();
    }
    public Buff_Interactive NewGet() {
        GameObject gtmp = Instantiate(BuffInteractivePrefab, transform);
        gtmp.SetActive(true);
        Buff_Interactive buffTemp = gtmp.GetComponent<Buff_Interactive>();
        buffTemp.Initialized(goBuffInfo,this,BuffGroup.Count);
        BuffGroup.Add(buffTemp);
        return buffTemp;
    }
    
}
