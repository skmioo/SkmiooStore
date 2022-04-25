using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MiniRouteSet : MonoBehaviour
{
    //手动输入的值,和基础数据集中填写一致
    public int setKey;

    //按顺序排列---很容易错,后期改为 程序自动生成小地图
    List<Transform> _routes = new List<Transform>();

    public List<Transform> routes
    {
        get
        {
            if (_routes.Count < 1)
            {
                foreach (Transform item in transform)
                {
                    _routes.Add(item);
                }
                return _routes;
            }
            return _routes;
        }
    }

    public Transform GetRoute(int num)
    {
        if (_routes.Count < 1)
        {
            foreach (Transform item in transform)
            {
                _routes.Add(item);
            }          
        }

        if (num < 0 || num > _routes.Count - 1)
        {
            return null;
        }
        return _routes[num];
    }
}
