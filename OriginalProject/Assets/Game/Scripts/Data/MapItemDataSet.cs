using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;


namespace Datas
{
    [Serializable]
    /// <summary>
    /// 地图基础数据
    /// </summary>
    public class MapItemData : DataBase
    {
        public AssetReferenceGameObject roomModel;
    }

    [Serializable]
    public class RoomItemData :MapItemData
    {

        public RoomType roomType;
    }

    [Serializable]
    public class RouteItemData :MapItemData
    {

        public RouteType routeType;
    }


    [CreateAssetMenu(menuName = "NewData/Map/MapItemData")]
    [Serializable]
    /// <summary>
    /// 地图基础数据集
    /// </summary>
    public class MapItemDataSet : ScriptableObject
    {
        [Header("房间基础数据")]
        [SerializeField] public List<RoomItemData> roomData = new List<RoomItemData>();

        [Header("道路基础数据")]
        [SerializeField] public List<RouteItemData> routeData = new List<RouteItemData>();

    }


}

