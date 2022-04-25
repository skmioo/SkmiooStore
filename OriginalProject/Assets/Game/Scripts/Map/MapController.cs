#define NEW_MAP_ROAD_TYPE

using Datas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// 地图控制器
/// </summary>
public class MapController : MonoBehaviour
{
    #region 部分弃用旧逻辑

    public Transform showRooms;
    public Transform showRoomRoad1;
    public Transform showRoomRoad2;
    public Transform waitRooms;
    public Transform miniMapContent;
    public GameObject routeSetObj;
    [System.NonSerialized]
    public int enterNewRoomCount;

    // MapData mapdata;
    /// <summary>
    /// 地图数据
    /// </summary>
    Dictionary<int, MapData> mapDict = new Dictionary<int, MapData>();
    /// <summary>
    /// 地图中房间，道路数据
    /// </summary>
    Dictionary<int, MapItemData> mapItemDict = new Dictionary<int, MapItemData>();
    /// <summary>
    /// 房间数据
    /// </summary>
    Dictionary<int, RoomItemData> roomDict = new Dictionary<int, RoomItemData>();
    /// <summary>
    /// 道路数据
    /// </summary>
    Dictionary<int, RouteItemData> routeDict = new Dictionary<int, RouteItemData>();
    /// <summary>
    /// 房间附加物数据
    /// </summary>
    Dictionary<int, AddRoomData> addRoomDict = new Dictionary<int, AddRoomData>();

    /// <summary>
    /// 道路集字典---用于找房间 --  
    /// </summary>
    Dictionary<int, RouteSet> routeSetDict = new Dictionary<int, RouteSet>();
    public Dictionary<int, RoomSet> roomSetDict = new Dictionary<int, RoomSet>();
    //private void Update()
    //{
    //    if (!roomOne)
    //    {
    //        if (BattleInfo.startRoom != null)
    //        {
    //            InitMap();
    //            roomOne = true;
    //        }
    //    }
    //}

    static MapController _instance;
    public static MapController Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        _instance = this;
        showRoomRoad1 = new GameObject("showRoomRoad1").transform;
        showRoomRoad2 = new GameObject("showRoomRoad2").transform;
        showRoomRoad1.SetParent(showRooms);
        showRoomRoad2.SetParent(showRooms);
    }

    private void Start()
    {
        sceneFade = FightingCameraCon.Instance.mainCamera.GetComponent<SceneFade>();
        InitMap();
        //Debug.Log("测试启动");
        NewbieGuideMag.Instance.triggerGuide(GuideDataSet.guideEnum.inMap);
    }

    void InitMap()
    {
      //  mapdata = BattleInfo.mapData;

        DataSetItem mapDataSet = DataManager.Instance.GetConstData("MapData");
        DataSetItem mapItemDataSet = DataManager.Instance.GetConstData("MapItemData");
        DataSetItem addRoomDataSet = DataManager.Instance.GetConstData("MapAddRoomData");


        MapDataSet _mapDataSet = mapDataSet.scriptableObject as MapDataSet;
        MapItemDataSet _mapItemDataSet = mapItemDataSet.scriptableObject as MapItemDataSet;
        MapAddRoomDataSet _addRoomDataSet = addRoomDataSet.scriptableObject as MapAddRoomDataSet;

        foreach (var item in _mapDataSet.mapData)
        {
            mapDict.Add(item.id, item);
        }

        foreach (var item in _mapItemDataSet.roomData)
        {
            mapItemDict.Add(item.id, item);
            roomDict.Add(item.id, item);
        }

        foreach (var item in _mapItemDataSet.routeData)
        {
            mapItemDict.Add(item.id, item);
            routeDict.Add(item.id, item);
        }

        foreach (var item in _addRoomDataSet.addRoomData)
        {
            addRoomDict.Add(item.id, item);
        }

        //CreateRoom();
        //CreateMiniMap();
        N_CreateMap(_mapDataSet);
    }

    void CreateMiniMap()
    {
        //mapdata.miniMapmodel.InstantiateAsync(miniMapContent).Completed += go =>
        //{
        //    MiniMapController mini = go.Result.GetComponent<MiniMapController>();
        //    mini.InitMiniMap();
        //};
    }

    #region 场景生成部分
    void CreateRoom()
    {
        //for (int i = 0; i < mapdata.roomDatas.Count; i++)
        //{
        //    RoomData roomData = mapdata.roomDatas[i];

        //    if (!roomDict.ContainsKey(roomData.roomID))
        //    {
        //        Debug.Log($"提供的ID找不到{roomData.roomID}");
        //        return;
        //    }

        //    roomDict[roomData.roomID].roomModel.InstantiateAsync(waitRooms).Completed += go =>
        //    {
        //        RoomSet room = go.Result.GetComponent<RoomSet>();
        //        room.transform.localPosition = Vector3.zero;
        //        room.InitRoom(roomData.roomNumber);

        //        if (roomData.addRoom.addRoomID != 0)
        //        {
        //            CreateAddRoom(room.transform, roomData.addRoom.addRoomID);
        //        }

        //        if (room.key == 1)//默认房间号码为1的房间,在初始化时调用进入
        //        {
        //            SwithMapGround(room.transform, room.transform, room.transform);
        //        }
        //        roomSetDict.Add(room.key, room);
        //    };

        //    for (int n = 0; n < roomData.routeDatas.Count; n++)
        //    {
        //        RouteData routeData = roomData.routeDatas[n];
        //        // CreateRouteSet(routeData.mRouteDatas, routeData.routeKey);
        //        CreateRouteSet(routeData);
        //    }
        //}
    }

    void CreateAddRoom(Transform parent, int addRoomID)
    {
        if (!addRoomDict.ContainsKey(addRoomID))
        {
            Debug.Log($"提供的附加房间在基础数据中找不到{addRoomID}");
            return;
        }

        AddRoomData addRoomData = addRoomDict[addRoomID];

        addRoomData.addRoomModel.InstantiateAsync(parent).Completed += go =>
        {
            AddRoomBase addRoomBase = go.Result.GetComponent<AddRoomBase>();
            addRoomBase.InitAddRoom(addRoomData);
        };
    }

    //
    void CreateRouteSet(RouteData routeData)
    {
        //GameObject routeSetobj = Instantiate(routeSetObj, waitRooms);
        //routeSetobj.name = routeData.routeKey.ToString();

        //Dictionary<int, Route> routesObj = new Dictionary<int, Route>();

        //for (int i = -1; i < routeData.routeCount + 1; i++)
        //{
        //    CreateRoute(routeSetobj.transform, i, routeData, routeData.routeKey, routesObj);

        //}

        //RouteSet routeSet = routeSetobj.GetComponent<RouteSet>();
        //routeSet.InitRouteSet(routeData.routeKey, routesObj, routeData.routeCount);

        //routeSetDict.Add(routeSet.key, routeSet);
    }

    void CreateRoute(Transform routeSet, int num, RouteData routeData, int routeSetKey, Dictionary<int, Route> routes)
    {
        //int rd = UnityEngine.Random.Range(0, mapdata.randomRoutesID.Count);
        //int randomID = mapdata.randomRoutesID[rd];
        //if (!routeDict.ContainsKey(randomID))
        //{
        //    Debug.Log(randomID);
        //}
        //RouteItemData routeItem = routeDict[randomID];

        //if (num == 0 || num == routeData.routeCount - 1)//这是起点或终点
        //{
        //    routeItem = routeDict[mapdata.startRouteID];
        //}


        //routeItem.roomModel.InstantiateAsync(routeSet).Completed += go =>
        //{
        //    GameObject _go = go.Result;
        //    //根据num改位置
        //    _go.transform.localPosition = GetRoutePos(num);

        //    Route route = _go.GetComponent<Route>();
        //    route.InitRoute(routeSetKey, num);

        //    routes.Add(num, route);

        //    foreach (var item in routeData.addRoutes)
        //    {
        //        if (item.roomNum == num)
        //        {
        //            CreateAddRoom(route.transform, item.addRoomID);
        //        }
        //    }
        //};

    }

    #region 弃用的创建道路方法
    void CreateRouteSet(List<MRouteData> routes, int key)
    {
        GameObject routeSet = Instantiate(new GameObject(), waitRooms);
        routeSet.name = key.ToString();


        List<GameObject> routesObj = new List<GameObject>();
        for (int i = 0; i < routes.Count; i++)
        {
            CreateRoute(routeSet.transform, i, key, routes[i], routesObj);
        }

        RouteSet RouteSet = routeSet.AddComponent<RouteSet>();
        //RouteSet.InitRouteSet(key, routesObj);

        routeSetDict.Add(RouteSet.key, RouteSet);
    }

    void CreateRoute(Transform routeSet, int num, int routeSetKey, MRouteData mRouteData, List<GameObject> routes)
    {
        routeDict[mRouteData.routeID].roomModel.InstantiateAsync(routeSet).Completed += go =>
        {
            GameObject _go = go.Result;
            //根据num改位置
            _go.transform.localPosition = GetRoutePos(num);

            Route route = _go.AddComponent<Route>();
            route.InitRoute(routeSetKey, num);

            routes.Add(go.Result);

            if (mRouteData.addRoomID != 0)
            {

            }
        };
    }

    #endregion

    Vector3 GetRoutePos(int num)
    {
        float x = 7.2f * num;//从-1开始生成
        return new Vector3(x, 0, 0);
    }

    #endregion


    #region 场景切换
    Transform showNow;
    Transform backRoom;

    Transform backNow;
    Transform backTeamPos;
    MiniRoom targetRoom;
    public Transform battflowT;
    public SceneFade sceneFade;
    //步骤   1点击要去的目的地..获得目的地,屏幕转暗, 关闭正在显示的地图,打开想要显示的地图  ,设置到起点,  屏幕转亮
    //切换场景
    void SwithMapGround(Transform target, Transform teamPos, Transform endPos)
    {
        Vector3 _teamPos = new Vector3(teamPos.position.x, 0.7f, 0);

        if (showNow == null)
        {
            backRoom = target;
            backTeamPos = endPos;
        }
        else
        {
            backRoom = showNow;
            backTeamPos = backNow;
        }

        if (showNow == null)
        {
            battflowT.position = _teamPos;
            target.SetParent(showRooms);
            showNow = target;
            backNow = endPos;
        }
        else
        {
            sceneFade.Fade(true);
            showNow.SetParent(waitRooms);


            battflowT.position = _teamPos;
            target.SetParent(showRooms);
            showNow = target;
            backNow = endPos;
        }
    }

    /// <summary>
    /// 退回到上一个道路终点或上一个房间  -- 战斗中撤退专用
    /// </summary>
    public void BackMapGroud()
    {
        Retreat();
        //if (backRoom == null || backTeamPos == null)
        //return;//一般不允许第一个房间是战斗房间

        //SwithMapGround(backRoom, backRoom,null);
        //要不查一下backRoom上是否能取出 
    }

    // 房间被点击
    public void MiniRoom_OnClickMiniRoom(MiniRoom obj, int meRoomNum)
    {
        targetRoom = obj;
        //A型是正向1-2,3-5
        string routeKeyA = meRoomNum.ToString() + obj.roomNum.ToString();
        //B型是负向2-1,5-3
        string routeKeyB = obj.roomNum.ToString() + meRoomNum.ToString();

        if (routeSetDict.ContainsKey(int.Parse(routeKeyA)))
        {
            RouteSet routeSet = routeSetDict[int.Parse(routeKeyA)];
            routeSet.OpenTheDoor(true);


            SwithMapGround(routeSet.transform, routeSet.startROute.transform, routeSet.endRoute.transform);
        }
        else if (routeSetDict.ContainsKey(int.Parse(routeKeyB)))
        {
            RouteSet routeSet = routeSetDict[int.Parse(routeKeyB)];
            routeSet.OpenTheDoor(false);


            SwithMapGround(routeSet.transform, routeSet.endRoute.transform, routeSet.startROute.transform);
        }
        else
        {
            Debug.Log($"小地图房间号错误A:{routeKeyA}___B:{routeKeyB}");
            return;
        }



    }

    /// <summary>
    /// 退出道路
    /// </summary>
    public void ExitRoute()
    {
        if (!roomSetDict.ContainsKey(targetRoom.roomNum))
        {
            Debug.Log($"小地图房间号与基础数据房间号不一致");
            return;
        }

        RoomSet roomSet = roomSetDict[targetRoom.roomNum];


        SwithMapGround(roomSet.transform, roomSet.transform, roomSet.transform);
    }

    #endregion

    #endregion

    #region 新逻辑实现——入口在InitMap()中调用

    /// <summary>
    /// 当前使用的地图数据和资源
    /// </summary>
    private N_MapData mapData;
    /// <summary>
    /// 地图相关资源数据
    /// </summary>
    private N_MapResources mapResources;

    //当前场景在地图资源中的引用
    private int sceneIndex;
    private MapNameType nameType;

    //地图中心点坐标
    private Vector2 MapCenterPosition;

    //地图UI组件中心点偏移量及UI缩放——根据源数据测量
    private readonly Vector2 UICenterOffset = new Vector2(0, 0);
    private readonly float UIScale = 20f;
    private readonly float OffsetLimitRoomX = 10f;
    private readonly float OffsetLimitRouteX = 3f;
    private readonly float OffsetLimitY = 2f;
    private readonly float OffsetBgRouteX = 7.2f;
    private readonly float OffsetBgY = 2f;
    private readonly float OffsetDoorTrigger = 1f;

    //保留相关引用
    private List<GameObject> goRoomList = new List<GameObject>();
    /// <summary>
    /// 火把
    /// </summary>
    private GameObject goHeros;
    private RectTransform goHerosRectTrans;

    /// <summary>
    /// 英雄们当前位置
    /// </summary>
    private Vector2Int herosCurrentPosition;

    /// <summary>
    /// 是否正在等待异步加载完成
    /// </summary>
    private bool isWaitingLoad = true;

    /// <summary>
    /// 英雄们是否在道路上
    /// </summary>
    private bool isOnRoute = false;

    /// <summary>
    /// 英雄们所处的道路组索引
    /// </summary>
    private int routeGroupIndex;

    /// <summary>
    /// 道路列表是否升序
    /// </summary>
    private bool isAscendingOrder;

    /// <summary>
    /// 该次移动是否为撤退
    /// </summary>
    private bool isRetreat = false;

    /// <summary>
    /// 当前触发战斗的怪物盒子在地图数据中的索引
    /// </summary>
    private int addRoomIndex;
    private int addRouteGroupIndex;
    private int addRouteIndex;

    /// <summary>
    /// 任务
    /// </summary>
    //private TaskBase task;
    private List<TaskBase> tasks = new List<TaskBase>();

   // private N_TaskType taskType;
    private TaskDifficulty taskDifficulty;
    private MapSizeType mapSize;

    /// <summary>
    /// 任务显示
    /// </summary>
    public TaskProgress taskShow;

    /// <summary>
    /// 保存上次英雄们所在道路的位置，用于判断英雄是否走过一个格子
    /// </summary>
    private int lastIndex = -1;




    //一键解锁地图
    public Button unlockBtn;
    public Button showBtn;
    public Button closeBtn;
    public RectTransform mapView;
    public RectTransform mapContent;
    /// <summary>
    /// 是否显示小地图
    /// </summary>
    bool isShowMap = true;
    Vector2 contentScale;
    Vector2 mouseScroll;
    Vector2 oldMouseScroll;
    /// <summary>
    /// 前进道路格数
    /// </summary>
    int goForwordRoadCount = 0;
    /// <summary>
    /// 后退道路格数
    /// </summary>
    int goBackRoadCount = 0;

    private void Update()
    {
        //等待异步加载完成
        if (isWaitingLoad && mapData != null && goRoomList.Count.Equals(mapData.rooms.Count) && goHeros != null)
        {
            isWaitingLoad = false;
            goHeros.transform.SetAsLastSibling();
            IntoRoom(mapData.rooms.FindIndex(s => s.roomType == N_MiniMapRoomType.入口));
        }

        //在道路上时，实时更新英雄们在小地图中的位置
        if (isOnRoute)
        {
            int index = (int)(battflowT.position.x / OffsetBgRouteX + 0.3f) - 1;

            //越界限制
            if (index < 0)
            {
                index = 0;
            }
            if (index > mapData.routeGroups[routeGroupIndex].routes.Count - 1)
            {
                index = mapData.routeGroups[routeGroupIndex].routes.Count - 1;
            }

            if (!isAscendingOrder)
            {
                index = mapData.routeGroups[routeGroupIndex].routes.Count - 1 - index;
            }

            if (lastIndex != index)
            {
                MoveTeam.Instance.UpdateMoveForwardOrBackCount();
                //倒退数大于3格时,以后每一格都要检查
                if (MoveTeam.Instance.goBackRoadCount > 3)
                {
                    if (BattleFlowController.Instance.ReduceMoralWhenGoBack2Road())
                    {
                        MoveTeam.Instance.goBackRoadCount = 0;
                    }
                }

                //前进数大于0格时,以后每一格都要检查
                if (MoveTeam.Instance.goForwordRoadCount > 0)
                {
                    BattleFlowController.Instance.AddMoralWhenGoForword0Road();
                }

                //前进数大于10格时,以后每一格都要检查
                if (MoveTeam.Instance.goForwordRoadCount > 10)
                {
                    if (BattleFlowController.Instance.AddMoralWhenGoForword10Road())
                    {
                        MoveTeam.Instance.goForwordRoadCount = 0;
                    }
                }

                //if (MoveTeam.Instance.goForwordRoadCount % 8 == 0&& MoveTeam.Instance.goForwordRoadCount != 0)
                //{
                //    BattleFlowController.Instance.AddMoralWhenGoForword8Road();
                //}
                //if (MoveTeam.Instance.goForwordRoadCount % 18 == 0 && MoveTeam.Instance.goForwordRoadCount != 0)
                //{
                //    BattleFlowController.Instance.AddMoralWhenGoForword18Road();
                //}


                lastIndex = index;
                UpdateHerosPosition(mapData.routeGroups[routeGroupIndex].routes[index].position);
                BattleFlowController.Instance.UpdateRound();
               
            }
        }

        //滚轮
        if(!isZoomOut)
		{
            mouseScroll = Input.mouseScrollDelta;
            if (mouseScroll != oldMouseScroll)
			{
                if (contentScale.x + mouseScroll.y * 0.01f > 0.2f && contentScale.x + mouseScroll.y * 0.01f < 3f)
                {
                    contentScale.x += mouseScroll.y * 0.01f;
                    contentScale.y += mouseScroll.y * 0.01f;
                }

                mapContent.localScale = contentScale;
                oldMouseScroll = mouseScroll;
			}
        }
    }
    /// <summary>
    /// 创建地图，地图实现的入口
    /// </summary>
    /// <param name="_mapData"></param>
    /// <param name="_mapResources"></param>
    private void N_CreateMap(MapDataSet mapDataSet)
    {
        mapResources = mapDataSet.nMapResources;
        contentScale = Vector2.one;

        List<MapMonsterGroup> mapMonsterGroups = mapDataSet.mapMonsterGroups;

        //根据任务类型动态更改生成参数
        List<MapCreateParameter> mapCreateParameters = mapDataSet.mapCreateParameter;
        MapCreateParameter mcp = mapCreateParameters[0];
        MapCreateParameterRoom mcpr = mcp.rooms.Find(s => s.roomType.Equals(N_MiniMapRoomType.Boss房间));
        {
            //taskType = BattleInfo.TaskType;
            //switch (taskType)
            //{
            //    case N_TaskType.扫荡:
            //        task = gameObject.AddComponent<Task_SaoDang>();
            //        mcpr.minCount = 0;
            //        mcpr.maxCount = 0;
            //        break;
            //    case N_TaskType.侦查:
            //        task = gameObject.AddComponent<Task_ZhenCha>();
            //        mcpr.minCount = 0;
            //        mcpr.maxCount = 0;
            //        break;
            //    case N_TaskType.固定boss:
            //    case N_TaskType.随机boss:
            //        task = gameObject.AddComponent<Task_JiShaBoss>();
            //        mcpr.minCount = 1;
            //        mcpr.maxCount = 1;
            //        break;
            //}
        }
        foreach (var tasktype in BattleInfo.TaskObjDatas)
        {
            TaskBase task = null;
            switch (tasktype.GetTaskType())
            {
                case N_TaskType.扫荡:
                    task = gameObject.AddComponent<Task_SaoDang>();
                    mcpr.minCount = 0;
                    mcpr.maxCount = 0;
                    break;
                case N_TaskType.侦查:
                    task = gameObject.AddComponent<Task_ZhenCha>();
                    mcpr.minCount = 0;
                    mcpr.maxCount = 0;
                    break;
                case N_TaskType.固定boss:
                case N_TaskType.随机boss:
                    task = gameObject.AddComponent<Task_JiShaBoss>();
                    mcpr.minCount = 1;
                    mcpr.maxCount = 1;
                    break;
            }
            tasks.Add(task);
        }
        //地图类型
        nameType = BattleInfo.MapName;
        sceneIndex = (int)nameType;
        MapMonsterGroup mmg = mapMonsterGroups.Find(s => s.nameType == nameType);

        //任务难度
        taskDifficulty = BattleInfo.TaskDifficulty;
        mapSize = BattleInfo.MapSize;
        //数据初始化
        MapCreator mapCreator = new MapCreator();
        {
            //if (taskType == N_TaskType.固定boss)
            //{
            //    mapData = mapCreator.CreateMapData(DataManager.Instance.GetMapData(nameType), mapResources.background[sceneIndex].rooms.Count, mapResources.background[sceneIndex].routes.Count, mmg);
            //    MapCenterPosition = new Vector2(Mathf.Max(mapData.rooms.Select(s => s.position).Select(s => s.x).ToArray()), Mathf.Max(mapData.rooms.Select(s => s.position).Select(s => s.y).ToArray())) / 2f;
            //}
            //else
            //{
            //    mapData = mapCreator.CreateMapData(mcp, mapResources.background[sceneIndex].rooms.Count, mapResources.background[sceneIndex].routes.Count, spareData, mmg);
            //    MapCenterPosition = new Vector2(mcp.mapSizeX, mcp.mapSizeY) / 2f;
            //}
        }

        bool hasBoss = false;
        foreach (var tasktype in BattleInfo.TaskObjDatas)
        {
            if (tasktype.GetTaskType() == N_TaskType.固定boss)// || tasktype == N_TaskType.随机boss)
            {
                hasBoss = true;
                break;
            }
        }
        N_MapData spareData = mapDataSet.nMapData[0];// mapDataSet.nMapData.Find(s => s.name == BattleInfo.MapName.ToString());

        if (nameType == MapNameType.教程关卡 || hasBoss)
        {
            mapData = mapCreator.CreateMapData(DataManager.Instance.GetMapData(nameType), mapResources.background[sceneIndex].rooms.Count, mapResources.background[sceneIndex].routes.Count, mmg);
            MapCenterPosition = new Vector2(Mathf.Max(mapData.rooms.Select(s => s.position).Select(s => s.x).ToArray()), Mathf.Max(mapData.rooms.Select(s => s.position).Select(s => s.y).ToArray())) / 2f;
        }
        else
        {
            mapData = mapCreator.CreateMapData(mcp, mapResources.background[sceneIndex].rooms.Count, mapResources.background[sceneIndex].routes.Count, spareData, mmg);
            MapCenterPosition = new Vector2(mcp.mapSizeX, mcp.mapSizeY) / 2f;
        }

        {    ////任务初始化
             //task.taskShow = taskShow;
             //task.Init(mapData);
        }
        for (int i = 0;i  < tasks.Count;++i)
        {
            if (tasks[i] == null)
            {
                tasks.RemoveAt(i);
                BattleInfo.TaskObjDatas.RemoveAt(i);
                i -= 1;
                continue;
            }
         
            //任务初始化
            tasks[i].taskShow = taskShow;
            tasks[i].Init(BattleInfo.TaskObjDatas[i], mapData);
        }

        N_CreateMiniMap();
    }

    private List<MiniMapDetection> miniMapDetection;
    /// <summary>
    /// 生成小地图
    /// </summary>
    private void N_CreateMiniMap()
    {
        miniMapDetection = new List<MiniMapDetection>();
        //在小地图中实例化房间
        foreach (var room in mapData.rooms)
        {

            mapResources.miniMap.roomPrefab.InstantiateAsync(miniMapContent).Completed += go =>
            {
                go.Result.transform.localPosition = PositionTransform(room.position);
                go.Result.transform.localScale = Vector3.one;

                var miniMap = mapResources.miniMap.roomResources.Find(s => s.roomType.Equals(room.roomType)).sprite;

                miniMap[0].LoadAssetAsync<Sprite>().Completed += s =>
                {
                    go.Result.GetComponent<Image>().sprite = s.Result;
                    go.Result.AddComponent<MiniMapDetection>().sprite = miniMap;
                    miniMapDetection.Add(go.Result.GetComponent<MiniMapDetection>());

                };

                goRoomList.Add(go.Result);
                BtnRoomClick(go.Result, room.position);

                UIEventManager.AddTriggersListener(go.Result).onEnter = s => MiniMapUIEnter(room.position, room.roomType.ToString(), go.Result.GetComponent<MiniMapDetection>(), true, go.Result.GetComponent<Button>());
                UIEventManager.AddTriggersListener(go.Result).onExit = s => MiniMapUIExit();
            };
        }

        //在小地图中实例化道路
        foreach (var routeGroup in mapData.routeGroups)
        {
            foreach (var route in routeGroup.routes)
            {

                mapResources.miniMap.routePrefab.InstantiateAsync(miniMapContent).Completed += go =>
                {
                    go.Result.transform.localPosition = PositionTransform(route.position);
                    go.Result.transform.localScale = Vector3.one;

                    var miniMap = mapResources.miniMap.routeResources.Find(s => s.routeType.Equals(route.routeType));

                    miniMap.sprite[0].LoadAssetAsync<Sprite>().Completed += s =>
                    {
                        go.Result.GetComponent<Image>().sprite = s.Result;
                        go.Result.AddComponent<MiniMapDetection>().sprite = miniMap.sprite;
                        miniMapDetection.Add(go.Result.GetComponent<MiniMapDetection>());
                    };

                    UIEventManager.AddTriggersListener(go.Result).onEnter = s => MiniMapUIEnter(route.position, route.routeType.ToString(), go.Result.GetComponent<MiniMapDetection>(), false);
                    UIEventManager.AddTriggersListener(go.Result).onExit = s => MiniMapUIExit();
                };
            }
        }

        //在小地图中实例化英雄们（火把）
        mapResources.miniMap.mePos.InstantiateAsync(miniMapContent).Completed += go =>
        {
            herosCurrentPosition = mapData.rooms.Find(s => s.roomType.Equals(N_MiniMapRoomType.入口)).position;
            go.Result.transform.localPosition = PositionTransform(herosCurrentPosition);
            go.Result.transform.localScale = Vector3.one;
            goHeros = go.Result;
            goHerosRectTrans = goHeros.GetComponent<RectTransform>();
            mapContent.anchoredPosition = -goHerosRectTrans.anchoredPosition * 0.6f;

            //碰撞检测
            Vector2 wh = go.Result.GetComponent<RectTransform>().sizeDelta;
            go.Result.AddComponent<BoxCollider2D>().size = wh * 0.9f;
            go.Result.GetComponent<BoxCollider2D>().isTrigger = true;
            go.Result.AddComponent<Rigidbody2D>().isKinematic = true;

            //go.Result.AddComponent<DetectionPass>().passMiniMapDicSp = passMiniMapDicSp;

            //一键解锁
            unlockBtn.onClick.AddListener(UnlockMiniMap);
            showBtn.onClick.AddListener(ShowMap);
            closeBtn.onClick.AddListener(CloseMap);

			//-----------
			UIEventManager.AddTriggersListener(mapView.gameObject).onEnter = s => OnMapZoomIn();
			UIEventManager.AddTriggersListener(mapView.gameObject).onExit = s => OnMapZoomOut();

			OnMapZoomIn();
        };


        Tween tween = mapView.DOSizeDelta(Vector2.zero, 0.01f);
        tween.SetAutoKill(false);
        tween.Pause();

        //为地图元素父节点添加销毁子物体方法
        showRooms.gameObject.AddComponent<DestroyChildren>();
    }
    /// <summary>
    /// 解锁小地图
    /// </summary>
    public void UnlockMiniMap() {
        for (int i = 0; i < miniMapDetection.Count; i++)
        {
            miniMapDetection[i].UnlockMiniMap();
        }
    }

    /// <summary>
    /// 修改地图大小
    /// </summary>
    internal bool isZoomOut;
    bool isClose;
    public void OnMapZoomOut()
    {
        if (isClose) return;
        //mapView.sizeDelta = new Vector2(354, 216);
        //mapContent.localScale = new Vector3(0.6f, 0.6f, 1f);
        isZoomOut = true;
        mapContent.anchoredPosition = -goHerosRectTrans.anchoredPosition * 0.6f;
    }
    public void OnMapZoomIn()
    {
        if (isClose) return;
        //mapView.sizeDelta = new Vector2(590, 360);
        mapView.sizeDelta = new Vector2(687.5599f, 311.8423f);
        mapContent.localScale = Vector3.one;
        isZoomOut = false;
        mapContent.anchoredPosition = -goHerosRectTrans.anchoredPosition * 0.6f;
    }

    /// <summary>
    /// 切换是否显示地图
    /// </summary>
    public void OnSwitchShowMap()
	{
        isShowMap = isShowMap ? false : true;
        if (isShowMap) ShowMap();
        else CloseMap();
	}

    public void ShowMap()
    {
        mapView.DOPlayBackwards();
        showBtn.gameObject.SetActive(false);
        closeBtn.gameObject.SetActive(false);
        unlockBtn.gameObject.SetActive(true);
        isClose = false;
        isShowMap = true;
    }

    public void CloseMap()
    {
        unlockBtn.gameObject.SetActive(false);
        mapView.DOPlayForward();
        showBtn.gameObject.SetActive(false);
        closeBtn.gameObject.SetActive(false);
        isClose = true;
        isShowMap = false;
    }
 
    private IEnumerator IEDelayMethod(Action dele)
    {
        yield return new WaitForSeconds(0.2f);
        if (dele != null)
        {
            dele.Invoke();
        }
    }  /// <summary>
       /// 按键进入房间或交互物
       /// </summary>
    public void IntoRoomOrInteractiveOfKeyDown() {
        if (BattleFlowController.Instance.IsBattling || BattleFlowController.Instance.IsInteracting) return;
        Transform distanceMin = null;
        DoorClick door = null;
        InteractiveTriggerBox interactive = null;
        for (int i = 0; i < showRooms.childCount; ++i) {
            Transform child = showRooms.GetChild(i);
            door = child.GetComponent<DoorClick>();
            interactive = child.GetComponent<InteractiveTriggerBox>();
            if (distanceMin == null && door != null)  distanceMin = door.transform; 
            if (distanceMin == null && interactive != null) distanceMin = interactive.transform;
            if (distanceMin != null && door != null) {
                float disDoor = Vector3.Distance(door.transform.position, BattleFlowController.Instance.transform.position);
                float disMin = Vector3.Distance(distanceMin.position, BattleFlowController.Instance.transform.position);
                if (disMin >= disDoor) distanceMin = door.transform;
            }
            if (distanceMin != null && interactive != null)
            {
                float disInteractive = Vector3.Distance(interactive.transform.position, BattleFlowController.Instance.transform.position);
                float disMin = Vector3.Distance(distanceMin.position, BattleFlowController.Instance.transform.position);
                if (disMin >= disInteractive) distanceMin = interactive.transform;
            }
        }
        if (distanceMin == null) return;
         door = distanceMin.GetComponent<DoorClick>();
         interactive = distanceMin.GetComponent<InteractiveTriggerBox>();
        if (door != null) {
            float dis = Vector3.Distance(door.transform.position, BattleFlowController.Instance.transform.position);
            if (dis <= door.BoxSize.x) door.IntoRoomOfKeyDown();
        }
        else if (interactive != null) {
            float dis = Vector3.Distance(interactive.transform.position, BattleFlowController.Instance.transform.position);
            if (dis <= interactive.BoxSize.x) interactive.IntoInteractiveOfKeyDown();
        }
        
    }
    bool canclick(Vector3 RoomPos)
    {
        bool B_canclick = BattleFlowController.Instance.herosTeam.GetObjLifes().All(x => Mathf.Abs(x.transform.position.x - RoomPos.x) < 6.3f);
        return B_canclick;
    }
    IEnumerator waitmini(int roomIndex)
    {
        sceneFade.Fade(false);///add
        yield return new WaitForSeconds(3.5f); //减少时间4 > 3.5f
        //完成后回到起始状态
        for (int i = 0; i < BattleFlowController.Instance.herosTeam.GetObjLifes().Count; i++)
        {
            BattleFlowController.Instance.herosTeam.GetObjLifes()[i].transform.position = HeroPos[i];
            BattleFlowController.Instance.herosTeam.GetAnimation()[i].goRole.GetComponent<Renderer>().
                sharedMaterial.SetColor("_Color", new Color(1, 1, 1, 1));
            FightingCameraCon.Instance.ResetMainCamOrth();
            BattleFlowController.Instance.herosTeam.GetAnimation()[i].EntryDoorAnim = false;
        }
        IntoRoom(roomIndex);
    }
    float maxdistance = 0;
    List<Vector3> HeroPos = new List<Vector3>();
    float othogra_Size = 5;

    public void PlayEntryRoomAni(int roomint, Vector3 RoomPos)
    {
        if (!canclick(RoomPos)) return;
        othogra_Size = 5;
        HeroPos.Clear();
        foreach (var a in BattleFlowController.Instance.herosTeam.GetObjLifes())
        {
            HeroPos.Add(a.transform.position);
            float temp = Mathf.Abs(RoomPos.x - a.transform.position.x);
            if (temp > maxdistance)
            {
                maxdistance = temp;
            }
        }
        foreach (var a in BattleFlowController.Instance.herosTeam.GetAnimation())
        {
            a.PlayIndoorEffect(RoomPos, maxdistance);
        }
        DOTween.To(() => othogra_Size, x =>
        {
            othogra_Size = x;
            FightingCameraCon.Instance.UpdateMainCamOrth(x);
        }, 3f, 2f); //3.5> 3
        StartCoroutine(waitmini(roomint));
    }
    /// <summary>
    /// 进入房间
    /// </summary>
    /// <param name="roomIndex"></param>
    public void IntoRoom(int roomIndex)
    {

        AudioManager.Instance.PlayAudio(AudioName.CREAK_Metal_Heavy_mono, AudioType.BattleCommon);
        isOnRoute = false;

        sceneFade.Fade(true);

        UpdateHerosPosition(mapData.rooms[roomIndex].position);
        UpdateClickable(roomIndex);

        ClearScene();

        //背景图
        N_BackgroundResources br = mapResources.background[sceneIndex];
        AddGameObjectToScene(mapResources.mapElement.roomBackground, new Vector3(0, OffsetBgY),
        mapData.rooms[roomIndex].roomType.Equals(N_MiniMapRoomType.入口) ? br.entrance : br.rooms[mapData.rooms[roomIndex].backgroundIndex]);

		//左右限位器
		Vector3 left = new Vector3(-OffsetLimitRoomX, OffsetLimitY);
		Vector3 right = new Vector3(OffsetLimitRoomX, OffsetLimitY);
		AddGameObjectToScene(mapResources.mapElement.leftLimit, left);
        AddGameObjectToScene(mapResources.mapElement.rightLimit,right);
		FightingCameraCon.Instance.CheckUpdateCinemachineLimt(left, right);
		//附加物-怪物盒子
		if (mapData.addRoomList.Exists(s => s.roomIndex.Equals(roomIndex)))
        {
            List<N_AddRoom> roomTempList = mapData.addRoomList.FindAll(s => s.roomIndex.Equals(roomIndex));
           
            for (int i = 0; i < roomTempList.Count; ++i)
            {
                if (roomTempList[i].addType == N_AddType.怪物 && !roomTempList[i].m_InteractiveType.HasValue)
                {
                    if ( (tasks[0].data.GetTaskType() == N_TaskType.固定boss || tasks[0].data.GetTaskType() == N_TaskType.随机boss) &&
                        tasks[0].data.TaskInfoData.triggerKeys.Length > 0 && mapData.rooms[roomTempList[i].roomIndex].roomType == N_MiniMapRoomType.Boss房间)
                        roomTempList[i].enemysIdList = new List<int>(tasks[0].data.TaskInfoData.triggerKeys);


                        AddGameObjectToScene(mapResources.addRoom, Vector3.zero, roomTempList[i].enemysIdList, roomIndex);
                }
                else if (roomTempList[i].addType == N_AddType.交互物 && roomTempList[i].m_InteractiveType.HasValue) AddGameObjectToScene(mapResources.interactivePrefabs.Find(s => s.type == roomTempList[i].m_InteractiveType.Value).InteractivePrefab, MapType.房间, Vector3.zero, roomTempList[i].enemysIdList, roomIndex, -1, -1);
            }

        }

        //如果房间内没有怪物，则该房间设置为已探索，否则战斗胜利后设置为已探索-DeleteEnemy()
        if (mapData.addRoomList.FindAll(s => s.roomIndex.Equals(roomIndex)).Count.Equals(0))
        {
            mapData.rooms[roomIndex].isExplore = true;
            UpdateTaskStatus();
        }
        else
        {
            this.enterNewRoomCount++;
            if (this.enterNewRoomCount > 2)
            {
                if (BattleFlowController.Instance.ReduceRandomMemeberMoralWhenEnterNewRoom())
                {
                    this.enterNewRoomCount = 0;
                }
            }
        }

        if (mapData.rooms[roomIndex].roomType.Equals(N_MiniMapRoomType.Boss房间))
        {
            BattleFlowController.Instance.isBossRoom = true;

            AudioManager.Instance.PlayMusic(AudioName.Decisive_Battle_BGM);
        }

        lastIndex = -1;
        BattleFlowController.Instance.UpdateRound();
    }

    private System.Action onIntoRoute;

    public System.Action OnIntoRoute
    {
        get { return onIntoRoute; }
        set { onIntoRoute = value; }
    }

    /// <summary>
    /// 进入道路
    /// </summary>
    /// <param name="sourceRoomIndex"></param>
    /// <param name="targetRoomIndex"></param>
    private void IntoRoute(int sourceRoomIndex, int targetRoomIndex)
    {
        AudioManager.Instance.PlayAudio(AudioName.GATE_Metal_Close_02_Dark_stereo, AudioType.BattleCommon);
        isOnRoute = true;
        sceneFade.Fade(true);

        AllNotClickable();
        ClearScene();

        //设置各项属性：道路组索引，道路列表升序/降序；更新英雄位置
        if (mapData.routeGroups.Exists(s => s.Room1.Equals(sourceRoomIndex) && s.Room2.Equals(targetRoomIndex)))
        {
            routeGroupIndex = mapData.routeGroups.FindIndex(s => s.Room1.Equals(sourceRoomIndex) && s.Room2.Equals(targetRoomIndex));
            isAscendingOrder = true;
            UpdateHerosPosition(mapData.routeGroups[routeGroupIndex].routes[0].position);
        }
        else
        {
            routeGroupIndex = mapData.routeGroups.FindIndex(s => s.Room2.Equals(sourceRoomIndex) && s.Room1.Equals(targetRoomIndex));
            isAscendingOrder = false;
            UpdateHerosPosition(mapData.routeGroups[routeGroupIndex].routes[mapData.routeGroups[routeGroupIndex].routes.Count - 1].position);
        }

        //BattleFlowController.Instance.ReduceRandomMemeberMoralWhenEnterNewRoomAndRoad();

        N_MapElementResources mer = mapResources.mapElement;
        AssetReferenceGameObject argo = mer.routeBackground;
        N_BackgroundResources br = mapResources.background[sceneIndex];
        N_RouteGroup rg = mapData.routeGroups[routeGroupIndex];
        int rCount = rg.routes.Count;

#if NEW_MAP_ROAD_TYPE
        //门背景图
        AddGameObjectToScene(argo, new Vector3(0, 2), br.road4);
        AddGameObjectToScene(argo, new Vector3((rCount + 1) * OffsetBgRouteX, OffsetBgY), br.road4);

        //左右各多加一块背景图
        AddGameObjectToScene(argo, new Vector3((isAscendingOrder ? -1 : rCount + 2) * OffsetBgRouteX, OffsetBgY), br.road1[rg.leftBackgroundIndex]);
        AddGameObjectToScene(argo, new Vector3((isAscendingOrder ? rCount + 2 : -1) * OffsetBgRouteX, OffsetBgY), br.road1[rg.rightBackgroundIndex]);

        //中间道路背景图
        for (int i = 0; i < rCount; ++i)
        {
            AddGameObjectToScene(argo, new Vector3((i + 1) * OffsetBgRouteX, OffsetBgY), br.road1[rg.routes[isAscendingOrder ? i : rCount - i - 1].backgroundIndex], -1, showRooms);
        }

		showRoomRoad1.transform.localPosition = Vector3.zero;
		showRoomRoad2.transform.localPosition = Vector3.zero;
        for (int i = 0; i < rCount + 1; ++i)
        {
            AddGameObjectToScene(argo, new Vector3((i - 1) * OffsetBgRouteX, OffsetBgY), br.road3, -3, showRoomRoad2);
            AddGameObjectToScene(argo, new Vector3((i - 1) * OffsetBgRouteX, OffsetBgY), br.road2, -2, showRoomRoad1);
        }
#else
        //门背景图
        AddGameObjectToScene(argo, new Vector3(0, 2), br.door);
        AddGameObjectToScene(argo, new Vector3((rCount + 1) * OffsetBgRouteX, OffsetBgY), br.door);

        //左右各多加一块背景图
        AddGameObjectToScene(argo, new Vector3((isAscendingOrder ? -1 : rCount + 2) * OffsetBgRouteX, OffsetBgY), br.routes[rg.leftBackgroundIndex]);
        AddGameObjectToScene(argo, new Vector3((isAscendingOrder ? rCount + 2 : -1) * OffsetBgRouteX, OffsetBgY), br.routes[rg.rightBackgroundIndex]);

        //中间道路背景图
        for (int i = 0; i < rCount; ++i)
        {
            AddGameObjectToScene(argo, new Vector3((i + 1) * OffsetBgRouteX, OffsetBgY), br.routes[rg.routes[isAscendingOrder ? i : rCount - i - 1].backgroundIndex]);
        }
#endif

		Vector3 left = new Vector3(-OffsetBgRouteX - OffsetLimitRouteX, OffsetLimitY);
		Vector3 right = new Vector3((rCount + 2) * OffsetBgRouteX + OffsetLimitRouteX, OffsetLimitY);
		//左右限位器
		AddGameObjectToScene(mer.leftLimit, left);
        AddGameObjectToScene(mer.rightLimit, right);
		FightingCameraCon.Instance.CheckUpdateCinemachineLimt(left, right);
        //门触发器
        AddGameObjectToScene(mer.door, new Vector3(0, OffsetDoorTrigger), sourceRoomIndex);
        AddGameObjectToScene(mer.door, new Vector3((rCount + 1) * OffsetBgRouteX, OffsetDoorTrigger), targetRoomIndex);

        //附加物
        if (mapData.addRouteList.Exists(s => s.routeGroupIndex.Equals(routeGroupIndex)))
        {
            List<N_AddRoute> arList = mapData.addRouteList.FindAll(s => s.routeGroupIndex.Equals(routeGroupIndex));
            foreach (var ar in arList)
            {
                if (ar.addType == N_AddType.怪物 && !ar.m_InteractiveType.HasValue) AddGameObjectToScene(mapResources.addRoom, new Vector3((isAscendingOrder ? ar.routeIndex + 1 : rCount - ar.routeIndex) * OffsetBgRouteX, 0), ar.enemysIdList, ar.routeGroupIndex, ar.routeIndex);
                else if (ar.addType == N_AddType.交互物 && ar.m_InteractiveType.HasValue) AddGameObjectToScene(mapResources.interactivePrefabs.Find(s => s.type == ar.m_InteractiveType.Value).InteractivePrefab, MapType.道路, new Vector3((isAscendingOrder ? ar.routeIndex + 1 : rCount - ar.routeIndex) * OffsetBgRouteX, 0), ar.enemysIdList, -1, ar.routeGroupIndex, ar.routeIndex);
            }
        }

        OnIntoRoute?.Invoke();
    }

    /// <summary>
    /// 更新英雄位置
    /// </summary>
    /// <param name="position"></param>
    private void UpdateHerosPosition(Vector2Int position)
    {
        herosCurrentPosition = position;
        goHeros.transform.localPosition = PositionTransform(position);
        mapContent.anchoredPosition = -goHerosRectTrans.anchoredPosition * 0.6f;
    }

    /// <summary>
    /// 将小地图中所有房间组件设为不可点击
    /// </summary>
    public void AllNotClickable()
    {
        foreach (var g in goRoomList)
        {
            g.GetComponent<Button>().interactable = false;
        }
    }

    /// <summary>
    /// 更新小地图中房间组件的可点击状态
    /// </summary>
    /// <param name="roomIndex"></param>
    public void UpdateClickable(int roomIndex)
    {
        AllNotClickable();
        if (!isOnRoute)
        {
            foreach (var r in mapData.routeGroups)
            {
                if (r.Room1.Equals(roomIndex))
                {
                    goRoomList[r.Room2].GetComponent<Button>().interactable = true;
                }
                if (r.Room2.Equals(roomIndex))
                {
                    goRoomList[r.Room1].GetComponent<Button>().interactable = true;
                }
            }
        }
    }

    /// <summary>
    /// 更新小地图中房间组件的可点击状态
    /// </summary>
    public void UpdateClickable()
    {
        UpdateClickable(addRoomIndex);
    }

    /// <summary>
    /// 给小地图中的房间组件添加点击事件
    /// </summary>
    /// <param name="goRoom"></param>
    /// <param name="position"></param>
    private void BtnRoomClick(GameObject goRoom, Vector2Int position)
    {
        goRoom.AddComponent<Button>().onClick.AddListener(delegate
        {
            AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
            IntoRoute(mapData.rooms.FindIndex(s => s.position.Equals(herosCurrentPosition)), mapData.rooms.FindIndex(s => s.position.Equals(position)));
        });
    }

    public Text tipsTxt;
    public RectTransform tipTrans;

    void MiniMapUIEnter(Vector2Int pos, string tips, MiniMapDetection dectection, bool isRoom, Button btn = null)
    {
        tipTrans.localPosition = PositionTransform(pos) + (isRoom ? new Vector3(0, -50, 0) : new Vector3(0, -30, 0));

        if (btn != null && btn.interactable)
        {
            tipsTxt.text = "移至此房间";

            tipTrans.SetSiblingIndex(mapContent.childCount - 1);
            tipTrans.gameObject.SetActive(true);
        }
        else if (dectection.isExplore)
        {
            tipsTxt.text = tips;

            tipTrans.SetSiblingIndex(mapContent.childCount - 1);
            tipTrans.gameObject.SetActive(true);
        }
    }

    void MiniMapUIExit()
    {
        tipTrans.gameObject.SetActive(false);
    }

    /// <summary>
    /// 将地图坐标转为UI坐标
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    private Vector3 PositionTransform(Vector2Int position)
    {
        //实际偏移量
        float offsetX = UICenterOffset.x - MapCenterPosition.x;
        float offsetY = UICenterOffset.y - MapCenterPosition.y;
        return new Vector3(position.x + offsetX, position.y + offsetY) * UIScale;
    }

    /// <summary>
    /// 清空场景元素，重置英雄们在场景中的位置
    /// </summary>
    private void ClearScene()
    {
        showRooms.gameObject.GetComponent<DestroyChildren>().BroadcastMessageToDestroy();

        battflowT.position = new Vector3(0f, 0.7f);
        if (isRetreat)
        {
            isRetreat = false;
            if (isOnRoute)
            {
                battflowT.position = new Vector3((mapData.routeGroups[routeGroupIndex].routes.Count + 0.3f) * OffsetBgRouteX, 0.7f);
            }
        }
    }

    /// <summary>
    /// 添加场景元素，适用于限位器
    /// </summary>
    /// <param name="argo"></param>
    /// <param name="position"></param>
    private void AddGameObjectToScene(AssetReferenceGameObject argo, Vector3 position)
    {
        argo.InstantiateAsync(position, Quaternion.identity, showRooms).Completed += go =>
        {
            go.Result.AddComponent<Child>();
        };
    }

    /// <summary>
    /// 添加场景元素，适用于门触发器
    /// </summary>
    /// <param name="argo"></param>
    /// <param name="position"></param>
    /// <param name="roomIndex"></param>
    private void AddGameObjectToScene(AssetReferenceGameObject argo, Vector3 position, int roomIndex)
    {
        argo.InstantiateAsync(position, Quaternion.identity, showRooms).Completed += go =>
        {
            go.Result.AddComponent<Child>();
            DoorClick dc = go.Result.AddComponent<DoorClick>();
            dc.mapController = this;
            dc.roomIndex = roomIndex;
        };
    }

    /// <summary>
    /// 添加场景元素，适用于背景
    /// </summary>
    /// <param name="argo"></param>
    /// <param name="position"></param>
    /// <param name="arSprite"></param>
    private void AddGameObjectToScene(AssetReferenceGameObject argo, Vector3 position, AssetReferenceSprite arSprite)
    {
        argo.InstantiateAsync(position, Quaternion.identity, showRooms).Completed += go =>
        {
            go.Result.AddComponent<Child>();

            arSprite.LoadAssetAsync<Sprite>().Completed += s =>
            {
                go.Result.GetComponent<SpriteRenderer>().sprite = s.Result;
            };
        };
    }

    /// <summary>
    /// 添加场景元素，适用于背景
    /// </summary>
    /// <param name="argo"></param>
    /// <param name="position"></param>
    /// <param name="arSprite"></param>
    /// <param name="nSortValue"></param>
    private void AddGameObjectToScene(AssetReferenceGameObject argo, Vector3 position, AssetReferenceSprite arSprite, int nSortValue, Transform oParent)
    {
        argo.InstantiateAsync(position, Quaternion.identity, oParent).Completed += go =>
        {
            go.Result.AddComponent<Child>();

            arSprite.LoadAssetAsync<Sprite>().Completed += s =>
            {
                SpriteRenderer oSpriteRenderer = go.Result.GetComponent<SpriteRenderer>();
                oSpriteRenderer.sprite = s.Result;
                oSpriteRenderer.sortingOrder = nSortValue;

            };
        };
    }

    /// <summary>
    /// 添加场景元素，适用于房间中的怪物盒子
    /// </summary>
    /// <param name="argo"></param>
    /// <param name="position"></param>
    /// <param name="addRoomData"></param>
    private void AddGameObjectToScene(AssetReferenceGameObject argo, Vector3 position, List<int> keys, int roomIndex)
    {
        AddRoomData addRoomData = new AddRoomData() { triggerKeys = keys };
        argo.InstantiateAsync(position, Quaternion.identity, showRooms).Completed += go =>
        {
            go.Result.AddComponent<Child>();

            AddRoomBase addRoomBase = go.Result.GetComponent<AddRoomBase>();
            addRoomBase.mapController = this;
            addRoomBase.roomIndex = roomIndex;
            addRoomBase.mapType = MapType.房间;
            addRoomBase.InitAddRoom(addRoomData);

        };
    }
    /// <summary>
    /// 添加场景元素，适用于交互物
    /// </summary>
    /// <param name="argo"></param>
    /// <param name="_type"></param>
    /// <param name="position"></param>
    /// <param name="keys"></param>
    /// <param name="roomIndex"></param>
    /// <param name="routeGroupIndex"></param>
    /// <param name="routeIndex"></param>
    private void AddGameObjectToScene(AssetReferenceGameObject argo, MapType _type, Vector3 position, List<int> keys, int roomIndex, int routeGroupIndex, int routeIndex)
    {

        AddRoomData addRoomData = new AddRoomData() { triggerKeys = keys };
        Debug.Log("============================AddGameObjectToScene_Interactive");
        argo.InstantiateAsync(position, Quaternion.identity, showRooms).Completed += go =>
        {
            go.Result.transform.localPosition = new Vector3(position.x, 0, position.z);
            go.Result.AddComponent<Child>();
            InteractiveTriggerBox addRoomBase = go.Result.GetComponent<InteractiveTriggerBox>();
            addRoomBase.InteractiveDataInitialized(addRoomData);
            addRoomBase.mapController = this;
            switch (_type)
            {
                case MapType.房间:
                    addRoomBase.roomIndex = roomIndex;
                    addRoomBase.mapType = MapType.房间;
                    break;
                case MapType.道路:
                    addRoomBase.routeGroupIndex = routeGroupIndex;
                    addRoomBase.routeIndex = routeIndex;
                    addRoomBase.mapType = MapType.道路;
                    break;
            }
        };
    }
    /// <summary>
    /// 添加场景元素，适用于道路中的怪物盒子
    /// </summary>
    /// <param name="argo"></param>
    /// <param name="position"></param>
    /// <param name="keys"></param>
    /// <param name="routeGroupIndex"></param>
    /// <param name="routeIndex"></param>
    private void AddGameObjectToScene(AssetReferenceGameObject argo, Vector3 position, List<int> keys, int routeGroupIndex, int routeIndex)
    {
        AddRoomData addRoomData = new AddRoomData() { triggerKeys = keys };
        argo.InstantiateAsync(position, Quaternion.identity, showRooms).Completed += go =>
        {
            go.Result.AddComponent<Child>();

            AddRoomBase addRoomBase = go.Result.GetComponent<AddRoomBase>();
            addRoomBase.mapController = this;
            addRoomBase.routeGroupIndex = routeGroupIndex;
            addRoomBase.routeIndex = routeIndex;
            addRoomBase.mapType = MapType.道路;
            addRoomBase.InitAddRoom(addRoomData);
        };
    }

    /// <summary>
    /// 撤退
    /// 备注：必须在战斗中才可以使用，否则可能会导致位置错误（从左门进入房间后撤退）
    /// </summary>
    public void Retreat()
    {
        isRetreat = true;

        N_RouteGroup rg = mapData.routeGroups[routeGroupIndex];
        if (isOnRoute)
        {
            IntoRoom(isAscendingOrder ? rg.Room1 : rg.Room2);
        }
        else
        {
            IntoRoute(isAscendingOrder ? rg.Room1 : rg.Room2, isAscendingOrder ? rg.Room2 : rg.Room1);
        }
    }

    /// <summary>
    /// 设置当前触发战斗的怪物盒子在地图数据中的索引，适用于房间
    /// </summary>
    /// <param name="index"></param>
    public void SetBattleIndex(int roomIndex)
    {
        addRoomIndex = roomIndex;

        SetDoorClickable(false);
    }

    /// <summary>
    /// 设置当前触发战斗的怪物盒子在地图数据中的索引，适用于道路
    /// </summary>
    /// <param name="routeGroupIndex"></param>
    /// <param name="routeIndex"></param>
    public void SetBattleIndex(int routeGroupIndex, int routeIndex)
    {
        addRouteGroupIndex = routeGroupIndex;
        addRouteIndex = routeIndex;

        SetDoorClickable(false);
    }

    /// <summary>
    /// 战斗胜利时需要对地图控制器的一系列操作，相关数据在战斗开始时已经赋值给地图控制器
    /// </summary>
    public void BattleWin()
    {
        //删除怪物数据
        if (isOnRoute)
        {
            mapData.addRouteList.Remove(mapData.addRouteList.Find(s => s.routeGroupIndex.Equals(addRouteGroupIndex) && s.routeIndex.Equals(addRouteIndex)));
        }
        else
        {
            mapData.addRoomList.Remove(mapData.addRoomList.Find(s => s.roomIndex.Equals(addRoomIndex)));

            //房间设置为已探索
            mapData.rooms[addRoomIndex].isExplore = true;
        }
        
        SetDoorClickable(true);
    }
    /// <summary>
    /// 更新任务状态
    /// </summary>
    public void UpdateTaskStatus()
    {
        //task.UpdateTaskStatus(mapData);
        foreach (var task in tasks)
        {
            task.UpdateTaskStatus(mapData);
        }
    }
    /// <summary>
    /// 撤退 中途退出战斗
    /// </summary>
    public void ExitBattle()
    {
        //删除怪物数据
        if (isOnRoute)
        {
            mapData.addRouteList.Remove(mapData.addRouteList.Find(s => s.routeGroupIndex.Equals(addRouteGroupIndex) && s.routeIndex.Equals(addRouteIndex)));
        }
        else
        {
            mapData.addRoomList.Remove(mapData.addRoomList.Find(s => s.roomIndex.Equals(addRoomIndex)));

            //房间设置为未探索
            mapData.rooms[addRoomIndex].isExplore = false;
        }
        SetDoorClickable(true);
    }

    /// <summary>
    /// 设置门的可点击状态
    /// </summary>
    /// <param name="isClickable"></param>
    private void SetDoorClickable(bool isClickable)
    {
        if (isOnRoute)
        {
            if (isClickable)
            {
                BroadcastMessage("SetDoorClickableTrue", isClickable);
            }
            else
            {
                BroadcastMessage("SetDoorClickableFalse", isClickable);
            }
        }
    }

    /// <summary>
    /// 获取怪物掉落数据
    /// </summary>
    /// <returns></returns>
    public List<ObjData> GetMapDrop()
    {
        if (isOnRoute)
        {
            N_MiniMapRouteType routeType = mapData.routeGroups[addRouteGroupIndex].routes[addRouteIndex].routeType;
            return DataManager.Instance.GetMapDrop(nameType, routeType, taskDifficulty);
        }
        else
        {
            N_MiniMapRoomType roomType = mapData.rooms[addRoomIndex].roomType;
            return DataManager.Instance.GetMapDrop(nameType, roomType, taskDifficulty);
        }
    }

    public TaskDifficulty GetTaskDifficulty()
    {
        return taskDifficulty;
    }

    public MapNameType GetMapName()
    {
        return nameType;
    }
    #endregion
}

