using System;
using UnityEngine;
using UnityEngine.UI;

public class Route : MonoBehaviour
{
    public static Action<int,int> EnterRoute;//MiniMapController注册

    public bool onExitButton;
    int routeSetID;
    int numInSet;

    [Tooltip("可空,带门的道路才需要设置门按钮")]
    public GameObject doorButton;

    private void Awake()
    {
        if (doorButton != null)
        {
            UIEventManager.AddTriggersListener(doorButton).onClick += OutRouteClick;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnterRoute?.Invoke(routeSetID,numInSet);
    }

    public void InitRoute(int _routeID,int num)
    {
        routeSetID = _routeID;
        numInSet = num;
    }


    /// <summary>
    /// 退出房间按钮被点击,,只有起点或终点才需要在事件上关联该方法
    /// </summary>
    private void OutRouteClick(GameObject go)
    {
        MapController.Instance.ExitRoute();
    }


    /// <summary>
    /// 开门方法--
    /// </summary>
    /// <param name="open">true = 打开,false = 关闭</param>
    public void OpenTheDoor(bool open)
    {
        if (doorButton == null)
        {
            Debug.Log($"正在为一个错误的房间设置门开关,道路集号：{routeSetID},道路号:{numInSet}");
            return;
        }
            
        //doorButton.interactable = open;
        doorButton.gameObject.SetActive(open);
    }


}
