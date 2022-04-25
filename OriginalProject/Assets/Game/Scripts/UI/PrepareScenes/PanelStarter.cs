using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GEvent;

public class PanelStarter : MonoBehaviour
{
    public ShopPanel shopPanel;
    public HealPanel healPanel;
    public SkillUpPanel skillUpPanel;
    public WarehousePanel warehousePanel;

    private void Awake()
    {
        EventHelper.Instance.AddEvent(GEventType.PreparePanelInitial, InitialPanels);
    }

    private void Start()
    {
        
    }

    void InitialPanels(Hashtable args)
    {
        Debug.Log("InitialPanels");
        //shopPanel.InitialPanel();
        //healPanel.Initial();
        //skillUpPanel.Initial();
        //warehousePanel.InitialPanel();
    }
}
