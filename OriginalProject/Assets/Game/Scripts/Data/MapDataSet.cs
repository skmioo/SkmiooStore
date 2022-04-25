using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.AddressableAssets;


namespace Datas
{
    #region 弃用
    [Serializable]
    public class MapData : DataBase
    {
        public AssetReferenceGameObject miniMapmodel;


        [Tooltip("参与生成道路的ID")]
        public List<int> randomRoutesID;
        [Tooltip("道路起点,或终点的ID---带门的图")]
        public int startRouteID;

        public List<RoomData> roomDatas;

    }

    [Serializable]
    public class RoomData
    {
        public int roomNumber;
        public int roomID;

        public AddRoom addRoom;
        public List<RouteData> routeDatas;
    }

    [Serializable]
    public class RouteData
    {
        //道路识别号,room1到room3 的房间就为13, room2到room5的房间就为25
        //若已有13,那么room3到room1不需要再次写值,程序自动翻转
        [Tooltip("道路识别号,room1到room3 的房间就为13, room2到room5的房间就为25")]
        public int routeKey;
        //道路的数量
        public int routeCount;

        public List<AddRoom> addRoutes;

        //public List<int> addRoomID;
        //public List<MRouteData> mRouteDatas;
    }

    [Serializable]
    public class AddRoom
    {
        public int addRoomID;

        [Tooltip("房间填0/子道路号码1-10,0 = 起点门道路")]
        public int roomNum = 0;
    }

    //弃用
    [Serializable]
    public class MRouteData
    {
        //道路的ID
        public int routeID;

        public int addRoomID;
    }
    #endregion

    #region 地图数据

    [Serializable]
    public class N_MapData : DataBase
    {
        public List<N_RoomData> rooms;
        public List<N_RouteGroup> routeGroups;

        public List<N_AddRoom> addRoomList;
        public List<N_AddRoute> addRouteList;
        public void ComplementAttribute()
        {
            foreach (var r in routeGroups)
            {
                r.Room1 = FindIndexAround(r.routes[0].position);
                r.Room2 = FindIndexAround(r.routes[r.routes.Count - 1].position);
            }
        }

        private int FindIndexAround(Vector2Int v)
        {
            for (int i = v.x - 2; i <= v.x + 2; ++i)
            {
                for (int j = v.y - 2; j <= v.y + 2; ++j)
                {
                    if (rooms.Exists(s => s.position.x.Equals(i) && s.position.y.Equals(j)))
                    {
                        return rooms.FindIndex(s => s.position.x.Equals(i) && s.position.y.Equals(j));
                    }
                }
            }

            Debug.LogError($"地图数据错误：道路点{v}未连接到房间");
            return -1;
        }
    }

    [Serializable]
    public class N_RoomData
    {
        public Vector2Int position;
        public N_MiniMapRoomType roomType;
        /// <summary>
        /// 是否探索过
        /// </summary>
        public bool isExplore;

        public int backgroundIndex;

        public N_RoomData(Vector2Int v, N_MiniMapRoomType rType, bool isExp)
        {
            position = v;
            roomType = rType;
            isExplore = isExp;
        }
    }

    [Serializable]
    public class N_RouteGroup
    {
        public List<N_RouteData> routes;

        //这两项数据由N_MapData.ComplementAttribute()填写
        public int Room1 { get; set; }
        public int Room2 { get; set; }

        public int leftBackgroundIndex;
        public int rightBackgroundIndex;
    }

    [Serializable]
    public class N_RouteData
    {
        public Vector2Int position;
        public N_MiniMapRouteType routeType;

        public int backgroundIndex;

        public N_RouteData(Vector2Int v, N_MiniMapRouteType rType)
        {
            position = v;
            routeType = rType;
        }
    }

    public class N_AddMap
    {
        public N_AddType addType;
        public InteractiveType? m_InteractiveType;
        public List<int> enemysIdList = new List<int>();
        public N_AddMap(N_AddType _aType, List<int> eiList, InteractiveType? _iType)
        {
            addType = _aType;
            m_InteractiveType = _iType;
            foreach (var ei in eiList)
            {
                enemysIdList.Add(ei);
            }
        }
    }

    public class N_AddRoom : N_AddMap
    {
        public int roomIndex;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aType"></param>
        /// <param name="eiList">怪物id表</param>
        /// <param name="rIndex">房间索引</param>
        public N_AddRoom(N_AddType aType, List<int> eiList, int rIndex, InteractiveType? iType) : base(aType, eiList,iType) {
            roomIndex = rIndex;
        }
    }

    public class N_AddRoute : N_AddMap
    {
        public int routeGroupIndex;
        public int routeIndex;

        public N_AddRoute(N_AddType aType, List<int> eiList, int rgIndex, int rIndex, InteractiveType? iType) : base(aType, eiList, iType)
        {
            routeGroupIndex = rgIndex;
            routeIndex = rIndex;
        }
    }
    #endregion

    #region 地图资源

    [Serializable]
    public class N_MapResources : DataBase
    {
        [Tooltip("小地图资源")]
        public N_MiniMapResources miniMap;
        [Tooltip("场景元素资源")]
        public N_MapElementResources mapElement;
        [Tooltip("场景背景资源")]
        public List<N_BackgroundResources> background;
        [Tooltip("场景交互物预制体资源")]
        public List<N_InteractiveResources> interactivePrefabs;
        [Tooltip("临时")]
        public AssetReferenceGameObject addRoom;
    }

    [Serializable]
    public class N_MiniMapResources
    {
        [Tooltip("房间预制体")]
        public AssetReferenceGameObject roomPrefab;
        [Tooltip("道路预制体")]
        public AssetReferenceGameObject routePrefab;
        [Tooltip("英雄预制体")]
        public AssetReferenceGameObject mePos;
        [Tooltip("房间资源")]
        public List<N_MiniMapRoomResources> roomResources;
        [Tooltip("道路资源")]
        public List<N_MiniMapRouteResources> routeResources;
    }

    [Serializable]
    public class N_MiniMapRoomResources
    {
        [HideInInspector]
        public string name;
        [Tooltip("房间类型")]
        public N_MiniMapRoomType roomType;
        [Tooltip("贴图")]
        public List<AssetReferenceSprite> sprite;

        public N_MiniMapRoomResources(int i)
        {
            roomType = (N_MiniMapRoomType)i;
            name = roomType.ToString();
        }
    }

    [Serializable]
    public class N_MiniMapRouteResources
    {
        [Tooltip("道路类型")]
        public N_MiniMapRouteType routeType;
        [Tooltip("贴图")]
        public List<AssetReferenceSprite> sprite;
    }

    [Serializable]
    public class N_MapElementResources
    {
        [Tooltip("左限制器")]
        public AssetReferenceGameObject leftLimit;
        [Tooltip("右限制器")]
        public AssetReferenceGameObject rightLimit;
        [Tooltip("门")]
        public AssetReferenceGameObject door;
        [Tooltip("房间背景预制体")]
        public AssetReferenceGameObject roomBackground;
        [Tooltip("道路背景预制体")]
        public AssetReferenceGameObject routeBackground;
    }

    [Serializable]
    public class N_BackgroundResources
    {
        [Tooltip("场景名")]
        public string name;
        [Tooltip("场景名")]
        public MapNameType nameType;
        [Tooltip("入口背景")]
        public AssetReferenceSprite entrance;
        [Tooltip("其他房间背景")]
        public List<AssetReferenceSprite> rooms;
        [Tooltip("道路门背景")]
        public AssetReferenceSprite door;
        [Tooltip("其他道路背景")]
        public List<AssetReferenceSprite> routes;
        [Tooltip("道路前景资源")]
        public List<AssetReferenceSprite> road1;
        [Tooltip("道路中景资源")]
        public AssetReferenceSprite road2;
        [Tooltip("道路后景资源")]
        public AssetReferenceSprite road3;
        [Tooltip("道路前景门资源")]
        public AssetReferenceSprite road4;
    }
    [Serializable]
    public class N_InteractiveResources :DataBase
    {
        [Tooltip("交互物类型")] public InteractiveType type;
        [Tooltip("交互物预制")] public AssetReferenceGameObject InteractivePrefab;
    }
    #endregion

    #region 地图生成参数

    [Serializable]
    public class MapCreateParameter : DataBase
    {
        [Tooltip("任务难度")]
        public TaskDifficulty taskDifficulty;
        [Tooltip("地图类型")]
        public MapSizeType mapSizeType;
        [Tooltip("地图宽")]
        public int mapSizeX;
        [Tooltip("地图高")]
        public int mapSizeY;
        [Tooltip("房间总数")]
        public int roomTotalCount;
        [Tooltip("房间详细参数")]
        public List<MapCreateParameterRoom> rooms;
        [Tooltip("道路总数")]
        public int routeTotalCount;
        [Tooltip("道路详细参数")]
        public List<MapCreateParameterRoute> routes;
        [Tooltip("道路最小链接格子数")]
        public int minRouteConnect;
        [Tooltip("道路最大链接格子数")]
        public int maxRouteConnect;
    }

    [Serializable]
    public class MapCreateParameterRoom
    {
        public N_MiniMapRoomType roomType;
        /// <summary>
        /// 房间数量的最小值
        /// </summary>
        public int minCount;
        /// <summary>
        /// 房间数量的最大值
        /// </summary>
        public int maxCount;
    }

    [Serializable]
    public class MapCreateParameterRoute
    {
        public N_MiniMapRouteType routeType;
        public int minCount;
        public int maxCount;
    }

    #endregion

    #region 地图怪物

    [Serializable]
    public class MapMonsterGroup : DataBase
    {
        public MapNameType nameType;
        public List<RoomMonsterGroup> roomMonsters;
        public List<RouteMonsterGroup> routeMonsters;
    }

    [Serializable]
    public class MonsterGroups
    {
        public List<MonsterGroup> monsterGroups;
    }

    [Serializable]
    public class MonsterGroup
    {
        public List<int> monsterGroup;
    }

    [Serializable]
    public class RoomMonsterGroup : MonsterGroups
    {
        public N_MiniMapRoomType roomType;
    }

    [Serializable]
    public class RouteMonsterGroup : MonsterGroups
    {
        public N_MiniMapRouteType routeType;
    }

    #endregion

    #region 地图掉落

    [Serializable]
    public class MapDroppingSet : DataBase
    {
        public MapNameType nameType;
        public List<RoomDropping> roomDroppings;
        public List<RouteDropping> routeDroppings;
    }

    [Serializable]
    public class RoomDropping : DroppingGroup
    {
        public N_MiniMapRoomType roomType;
    }

    [Serializable]
    public class RouteDropping : DroppingGroup
    {
        public N_MiniMapRouteType routeType;
    }

    [Serializable]
    public class DroppingGroup
    {
        public List<MapDropping> mapDroppings;
    }

    [Serializable]
    public class MapDropping
    {
        public TaskDifficulty taskDifficulty;
        [TextArea]
        public string json;
    
        public Dictionary<string, int> CreateDrop()
        {
            if (json == string.Empty) { Debug.Log("json error"); return null; }
            Dictionary<string, int> result = new Dictionary<string, int>();
            string[] dropGroups, drops, drop;
            
            ///必掉类
            string must = Regex.Match(json, @"(必掉类:\{){1}[^.]*(\}\r\n){1}").Value;
            drop = must.Split('{', '[', '~', ']', '}');
            int iTemp1 = -1;
            int iTemp2 = -1;
            IntTryParse(drop[2],out iTemp1);
            IntTryParse(drop[3], out iTemp2);
            result.Add(drop[1], UnityEngine.Random.Range(iTemp1, iTemp2 + 1));

            ///单权重类
            string onlyOne = RemoveCurlyBracket(Regex.Match(json, @"(单权重类:\{){1}[^.]*(\}\r\n){1}").Value);
            dropGroups = onlyOne.Split('&');
            foreach (var dropGroup in dropGroups)
            {
                int iTemp3 = -1;
                IntTryParse(dropGroup.Split('%')[0], out iTemp3);
                if (iTemp3 > UnityEngine.Random.Range(0, 101))
                {
                    drops = RemoveCurlyBracket(dropGroup).Split('|');
                    int[] pros = new int[drops.Length];
                    int roll = UnityEngine.Random.Range(0, 100);
                    for (int i = 0; i < drops.Length; ++i)
                    {
                        int iTemp4 = -1;
                        IntTryParse(Regex.Match(drops[i], @"[\d]+").Value, out iTemp4);
                        pros[i] = iTemp4;
                        if (pros[i] > roll)
                        {
                            drop = drops[i].Split('[', '~', ']');
                            int iTemp5 = -1;
                            int iTemp6 = -1;
                            IntTryParse(drop[1], out iTemp5);
                            IntTryParse(drop[2], out iTemp6);
                            result.Add(Regex.Match(drop[0], @"[\D]+").Value, UnityEngine.Random.Range(iTemp5, iTemp6 + 1));
                            break;
                        }
                        else
                        {
                            roll -= pros[i];
                        }
                    }
                }
            }
            //多权重类
            string maybeMulti = RemoveCurlyBracket(Regex.Match(json, @"(多权重类:\{){1}[^.]*(\}){1}").Value);
            drops = maybeMulti.Split('|');
            List<ObjLifeData> heros = BattleFlowController.Instance.GetHeros();
            foreach (var dp in drops)
            {
                int iTemp7 = -1;
                IntTryParse(Regex.Match(dp, @"[\d]+").Value, out iTemp7);
                drop = dp.Split('[', '~', ']');
                if (Regex.Match(drop[0], @"[\D]+").Value == "圣物") {
                    List<ObjPermanentBuff> buff = heros.Count <= 0 ? new List<ObjPermanentBuff>() : heros[0].FindPermanentBuff(ObjBuffType.圣物掉落率增加);
                    if (buff.Count > 0) iTemp7 = Mathf.RoundToInt(iTemp7 * (1 + buff[0].buffValue / 100f));
                }
                if (iTemp7 > UnityEngine.Random.Range(0, 100))
                {
                  
                    int iTemp8 = -1;
                    IntTryParse(drop[1], out iTemp8);
                    int iTemp9 = -1;
                    IntTryParse(drop[2], out iTemp9);
                    result.Add(Regex.Match(drop[0], @"[\D]+").Value, UnityEngine.Random.Range(iTemp8, iTemp9 + 1));
                }
            }

            return result;
        }
        private bool IntTryParse(string str, out int result)
        {
            bool re = int.TryParse(str, out result);
            if (!re) throw new System.Exception($"[ {str} ] is dont Conver To int");
            return re;
        }
        /// <summary>
        /// 删除括号
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string RemoveCurlyBracket(string input)
        {
            string str = input;
            str = str.Remove(0, str.IndexOf('{') + 1);
            str = str.Remove(str.LastIndexOf('}'), 1);
            return str;
        }
    }

    #endregion

    [CreateAssetMenu(menuName = "NewData/Map/MapData")]
    [Serializable]
    public class MapDataSet : ScriptableObject
    {
        [Header("弃用的数据类型")]
        [SerializeField] public List<MapData> mapData = new List<MapData>();
        /// <summary>
        /// 地图数据
        /// </summary>
        [Header("地图基础数据，固定地图")]
        [SerializeField] public List<N_MapData> nMapData = new List<N_MapData>();
        /// <summary>
        /// 地图相关资源
        /// </summary>
        [Header("地图相关资源")]
        [SerializeField] public N_MapResources nMapResources = new N_MapResources();
        /// <summary>
        /// 地图生成参数
        /// </summary>
        [Header("地图生成参数")]
        [SerializeField] public List<MapCreateParameter> mapCreateParameter = new List<MapCreateParameter>();
        /// <summary>
        /// 地图怪物数据
        /// </summary>
        [Header("地图怪物数据")]
        [SerializeField] public List<MapMonsterGroup> mapMonsterGroups = new List<MapMonsterGroup>();
        /// <summary>
        /// 地图掉落数据
        /// </summary>
        [Header("地图掉落数据")]
        [SerializeField] public List<MapDroppingSet> mapDroppings = new List<MapDroppingSet>();
    }
}
