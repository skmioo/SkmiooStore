using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 道路集,一组道路是由多个道路组成的
/// </summary>
public class RouteSet : MonoBehaviour
{
    public int key;
    //0=起点房间  count-1 = 终点房间
    public Dictionary<int, Route> routesDict = new Dictionary<int, Route>();

    //设置限位器
    public Transform leftLimit;
    public Transform rightLimit;

    [HideInInspector]
    //起点房间
    public Route startROute;
    [HideInInspector]
    //终点房间
    public Route endRoute;

    //存档文件中的道路数量--不包含起点限位道路与终点限位道路
    int routesCount;
    //终点房间号
    public void InitRouteSet(int _key,Dictionary<int,Route> _routes,int _routesCount)
    {
        key = _key;
        routesDict = _routes;
        routesCount = _routesCount;

        SetLimit(true);
    }

    //设置限位器,true = 正向，false = 反向
    void SetLimit(bool forword)
    {
        Vector3 endLimitPos;
        Vector3 startLimitPos;

        if (forword)
        {
            endLimitPos = GetRoutePos(routesCount);
            startLimitPos = GetRoutePos(-1);
        }
        else
        {

            startLimitPos = GetRoutePos(routesCount);
            endLimitPos = GetRoutePos(-1);
        }

        leftLimit.localPosition = startLimitPos;
        rightLimit.localPosition = endLimitPos;
    }

    Vector3 GetRoutePos(int num)
    {
        float x = 7.2f * num;//从-1开始生成
        return new Vector3(x, 0, 0);
    }

    void GetStartAndEndRoute()
    {
        //第二个道路是起点道路
        startROute = routesDict[0];
        //倒数第二个道路是终点道路
        endRoute = routesDict[routesCount - 1];
    }

    /// <summary>
    /// 设置开门道路/设置可以被点击的开门的道路
    /// </summary>
    /// <param name="reverse">是否正向false = 反向,true = 正向</param>
    public void OpenTheDoor(bool forword)
    {
        if (startROute == null || endRoute == null)
            GetStartAndEndRoute();

        if (forword)
        {
            transform.localScale = Vector3.one;
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 0);
        }


        SetLimit(forword);
        startROute.OpenTheDoor(!forword);
        endRoute.OpenTheDoor(forword);

    }
}
