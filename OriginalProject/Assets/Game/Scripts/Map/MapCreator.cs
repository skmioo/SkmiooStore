using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Datas;
using System.Linq;

/// <summary>
/// 地图数据生成器
/// </summary>
public class MapCreator
{
   
    //接口输入
    private MapCreateParameter parameter;
    private int roomBackgroundCount;
    private int routeBackgroundCount;
    private MapMonsterGroup mapMonsterGroup;
    //接口输出
    private N_MapData mapData;

    #region 交互物生成参数
    private bool isCreatInteractive;
    /// <summary>
    /// 是否是随机地图 true = 随机地图，false = 固定地图
    /// </summary>
    private bool isRandomMap;
    private int curMapInteractiveRoomCount;
    private int curMapInteractiveRouteCount;
    private InteractiveNumberData curInteractiveNumberData;
    private List<InteractiveType> InteractiveResult=new List<InteractiveType>();
    #endregion
    /// <summary>
    /// 生成器接口
    /// </summary>
    /// <param name="_parameter">地图生成参数</param>
    /// <param name="_roomBackgroundCount">房间背景贴图数（不含入口）</param>
    /// <param name="_routeBackgroundCount">道路背景贴图数（不含门）</param>
    /// <param name="spareData">备用数据-暂未实现</param>
    /// <returns></returns>
    public N_MapData CreateMapData(MapCreateParameter parameter, int roomBackgroundCount, int routeBackgroundCount, N_MapData spareData, MapMonsterGroup mapMonsterGroup)
    {
        Debug.Log("测试-随机地图");
        isRandomMap = true;
        this.parameter = parameter;
        this.roomBackgroundCount = roomBackgroundCount;
        this.routeBackgroundCount = routeBackgroundCount;
        this.mapMonsterGroup = mapMonsterGroup;
        isCreatInteractive = false;
        InitAll();
        for (int i = 0; i < 1000000; ++i)
        {
            if (CreatePositionData())
            {
                CreateOthersData();
                return mapData;
            }
        }

        Debug.Log("生成一百万次都失败了！请调整参数！");
        return null;
    }

    /// <summary>
    /// 生成器接口，固定地图
    /// </summary>
    /// <param name="mapData"></param>
    /// <param name="roomBackgroundCount"></param>
    /// <param name="routeBackgroundCount"></param>
    /// <param name="mapMonsterGroup"></param>
    /// <returns></returns>
    public N_MapData CreateMapData(N_MapData mapData, int roomBackgroundCount, int routeBackgroundCount, MapMonsterGroup mapMonsterGroup)
    {
        Debug.Log("测试-固定地图");
        isRandomMap = false;
        this.roomBackgroundCount = roomBackgroundCount;
        this.routeBackgroundCount = routeBackgroundCount;
        this.mapMonsterGroup = mapMonsterGroup;
        isCreatInteractive = false;
        this.mapData = mapData;

        mapData.ComplementAttribute();
        CreateRoomBackgroundIndex();
        CreateRouteBackgroundIndex();
        RefreshInteractiveCreatParameter(BattleInfo.TaskDifficulty, BattleInfo.MapSize);
        CreateRoomAdd();
        CreateRouteAdd();

        return this.mapData;
    }

    //生成器临时数据
    private bool[,] map;
    private List<Vector2Int> roomList;
    private List<List<Vector2Int>> routeGroupList;

    /// <summary>
    /// 初始化生成器数据
    /// </summary>
    private void InitAll()
    {
        map = new bool[parameter.mapSizeX, parameter.mapSizeY];
        roomList = new List<Vector2Int>();
        routeGroupList = new List<List<Vector2Int>>();
    }

    /// <summary>
    /// 清空生成器数据
    /// </summary>
    private void ClearAll()
    {
        for (int i = 0; i < parameter.mapSizeX; ++i)
        {
            for (int j = 0; j < parameter.mapSizeY; ++j)
            {
                map[i, j] = true;
            }
        }
        roomList.Clear();
        routeGroupList.Clear();
    }

    /// <summary>
    /// 生成坐标数据
    /// </summary>
    /// <returns></returns>
    private bool CreatePositionData()
    {
        ClearAll();

        if (CreateRoomPosition() && CreateRoutePosition())
        {
            CopyDataToOut();
            return true;
        }
        
        return false;
    }

    /// <summary>
    /// 按顺序依次生成除坐标外的其他地图数据
    /// </summary>
    private void CreateOthersData()
    {
        //从现有数据中计算生成部分数据
        mapData.ComplementAttribute();

        CreateRoomType();
        CreateRouteType();
        CreateRoomBackgroundIndex();
        CreateRouteBackgroundIndex();
        RefreshInteractiveCreatParameter(parameter.taskDifficulty, parameter.mapSizeType);
        CreateRoomAdd();
        CreateRouteAdd();
    }

    /// <summary>
    /// 生成房间坐标数据
    /// </summary>
    /// <returns></returns>
    private bool CreateRoomPosition()
    {
        for (int count = 0; count < parameter.roomTotalCount; ++count)
        {
            //随机一个坐标
            Vector2Int v;
            int randomCount = 0;
            do
            {
                v = new Vector2Int(Random.Range(1, parameter.mapSizeX - 1), Random.Range(1, parameter.mapSizeY - 1));
                randomCount++;
            } while (!IsUsableForRoom(v) && randomCount < 10000);

            //随机次数限制
            if (randomCount.Equals(10000))
            {
                return false;
            }

            //该坐标满足条件，添加到房间列表并更新map数据
            roomList.Add(v);
            for (int i = (v.x - 2 < 0 ? 0 : v.x - 2); i <= (v.x + 2 >= parameter.mapSizeX ? parameter.mapSizeX - 1 : v.x + 2); ++i)
            {
                for (int j = (v.y - 2 < 0 ? 0 : v.y - 2); j <= (v.y + 2 >= parameter.mapSizeY ? parameter.mapSizeY - 1 : v.y + 2); ++j)
                {
                    map[i, j] = false;
                }
            }
            map[v.x + 2 >= parameter.mapSizeX ? parameter.mapSizeX - 1 : v.x + 2, v.y] = true;
            map[v.x - 2 < 0 ? 0 : v.x - 2, v.y] = true;
            map[v.x, v.y + 2 >= parameter.mapSizeY ? parameter.mapSizeY - 1 : v.y + 2] = true;
            map[v.x, v.y - 2 < 0 ? 0 : v.y - 2] = true;
        }

        return true;
    }

    /// <summary>
    /// 生成道路坐标数据
    /// </summary>
    /// <returns></returns>
    private bool CreateRoutePosition()
    {
        //计算所有房间两两相连的最短距离
        List<Connection> connList = new List<Connection>();
        for (int i = 0; i < parameter.roomTotalCount; ++i)
        {
            for (int j = i + 1; j < parameter.roomTotalCount; ++j)
            {
                connList.Add(new Connection(i, j, roomList[i], roomList[j]));
            }
        }

        //排除不符合条件的连接
        connList.RemoveAll(c => c.lengthMin < parameter.minRouteConnect || c.lengthMin > parameter.maxRouteConnect);

        //按连接距离升序排序
        connList.Sort((c, m) => { return c.lengthMin.CompareTo(m.lengthMin); });

        //将所有房间连接到一起
        List<int> alreadyConnect = new List<int>();
        while (routeGroupList.Count < parameter.roomTotalCount - 1)
        {
            //获取连接索引，该连接的一端为 入口房间或其相连房间（已连接的），另一端为 某个未与入口房间或其相连房间有连接的房间（未连接的）
            int index = -1;
            for (int i = 0; i < connList.Count; ++i)
            {
                if (alreadyConnect.Count.Equals(0))
                {
                    index = 0;
                    break;
                }
                if (alreadyConnect.Exists(s => s.Equals(connList[i].room1)) ^ alreadyConnect.Exists(s => s.Equals(connList[i].room2)))
                {
                    index = i;
                    break;
                }
            }

            //如果不能将所有房间连接到一起，则本次生成失败
            if (index.Equals(-1))
            {
                return false;
            }

            //尝试在地图上将这两个房间相连，如果连接成功，则将这两个房间加入到已连接的房间列表
            int r1 = connList[index].room1;
            int r2 = connList[index].room2;
            if (TryConnectTwoRooms(connList, index))
            {
                if (!alreadyConnect.Exists(i => i.Equals(r1)))
                {
                    alreadyConnect.Add(r1);
                }
                if (!alreadyConnect.Exists(i => i.Equals(r2)))
                {
                    alreadyConnect.Add(r2);
                }
            }

            //无论是否连接成功，均将本连接从列表中移除
            connList.RemoveAt(index);
        }

        //补足道路数
        while (routeGroupList.Count < parameter.routeTotalCount)
        {
            if (connList.Count.Equals(0))
            {
                return false;
            }

            int index = Random.Range(0, connList.Count);
            TryConnectTwoRooms(connList, index);

            connList.RemoveAt(index);
        }

        return true;
    }

    /// <summary>
    /// 将房间坐标数据和道路坐标数据复制到mapData，以进行下一步数据生成
    /// </summary>
    private void CopyDataToOut()
    {
        mapData = new N_MapData()
        {
            rooms = new List<N_RoomData>(),
            routeGroups = new List<N_RouteGroup>()
        };

        foreach (var v in roomList)
        {
            mapData.rooms.Add(new N_RoomData(v, N_MiniMapRoomType.普通房间, false));
        }
        
        foreach (var rg in routeGroupList)
        {
            List<N_RouteData> rdList = new List<N_RouteData>();
            foreach (var v in rg)
            {
                rdList.Add(new N_RouteData(v, N_MiniMapRouteType.普通道路));
            }
            mapData.routeGroups.Add(new N_RouteGroup()
            {
                routes = rdList
            });
        }
    }

    /// <summary>
    /// 生成房间类型，按优先级依次替换，若普通房间已被替换完则后续不做替换
    /// </summary>
    private void CreateRoomType()
    {
        List<int> rList = new List<int>();
        for (int i = 0; i < mapData.rooms.Count; ++i)
        {
            rList.Add(i);
        }
        
        CreateRoomOneType(N_MiniMapRoomType.入口, rList);
        CreateRoomOneType(N_MiniMapRoomType.Boss房间, rList);
        CreateRoomOneType(N_MiniMapRoomType.战斗房间, rList);
        CreateRoomOneType(N_MiniMapRoomType.交互物房间, rList);
        CreateRoomOneType(N_MiniMapRoomType.有战斗和交互物房间, rList);
        CreateRoomOneType(N_MiniMapRoomType.精英房间, rList);
    }

    /// <summary>
    /// 生成道路类型，按优先级依次替换，若普通道路已被替换完则后续不做替换
    /// </summary>
    private void CreateRouteType()
    {
        List<RouteGroup> rgList = new List<RouteGroup>();
        for (int i = 0; i < mapData.routeGroups.Count; ++i)
        {
            List<int> rList = new List<int>();
            for (int j = 0; j < mapData.routeGroups[i].routes.Count; ++j)
            {
                rList.Add(j);
            }
            rgList.Add(new RouteGroup(i, rList));
        }

        CreateRouteOneType(N_MiniMapRouteType.战斗道路, rgList);
        CreateRouteOneType(N_MiniMapRouteType.交互物道路, rgList);
        CreateRouteOneType(N_MiniMapRouteType.精英战斗道路, rgList);
    }

    /// <summary>
    /// 生成房间贴图索引
    /// 备注：入口房间有单独的资源，不从索引获取
    /// </summary>
    private void CreateRoomBackgroundIndex()
    {
        foreach (var r in mapData.rooms)
        {
            r.backgroundIndex = Random.Range(0, roomBackgroundCount);
        }
    }

    /// <summary>
    /// 生成道路贴图索引
    /// 备注：门有单独的资源，不从索引获取；左门左和右门右贴图索引在此生成
    /// </summary>
    private void CreateRouteBackgroundIndex()
    {
        foreach (var rg in mapData.routeGroups)
        {
            int lastIndex = -1;
            foreach (var r in rg.routes)
            {
                int index = Random.Range(0, routeBackgroundCount);
                while (index.Equals(lastIndex))
                {
                    index = Random.Range(0, routeBackgroundCount);
                }
                r.backgroundIndex = index;
                lastIndex = index;
            }

            rg.leftBackgroundIndex = Random.Range(0, routeBackgroundCount);
            rg.rightBackgroundIndex = Random.Range(0, routeBackgroundCount);
        }
    }
    /// <summary>
    /// 刷新交互物生成参数
    /// </summary>
    /// <param name="taskDifficulty"></param>
    /// <param name="mapsize"></param>
    private void RefreshInteractiveCreatParameter(TaskDifficulty taskDifficulty,MapSizeType mapsize)
    {
        if (isCreatInteractive) return;
        isCreatInteractive = true;
        InteractiveResult.Clear();
        curMapInteractiveRoomCount = 0;
        curMapInteractiveRouteCount = 0;
        curInteractiveNumberData = DataManager.Instance.GetInteractiveNumberData(taskDifficulty, mapsize);
        Debug.Log(curInteractiveNumberData);
        curMapInteractiveRoomCount = mapData.rooms.FindAll(s => s.roomType == N_MiniMapRoomType.交互物房间 || s.roomType == N_MiniMapRoomType.有战斗和交互物房间).Count;
        for (int i = 0; i < mapData.routeGroups.Count; ++i)
        {
            for (int j = 0; j < mapData.routeGroups[i].routes.Count; ++j)
            {
                if (mapData.routeGroups[i].routes[j].routeType == N_MiniMapRouteType.交互物道路)
                    curMapInteractiveRouteCount++;
            }
        }
        int curTargetCount = curMapInteractiveRoomCount + curMapInteractiveRouteCount;
        if (curTargetCount <= 0) return;
        int countTemp = 0;
        Dictionary<InteractiveType, int> tempDic = new Dictionary<InteractiveType, int>();
        if (isRandomMap)
        {
            int minCount = 0, maxCount = 0;
            for (int i = 0; i < curInteractiveNumberData.numbers.Count; ++i)
            {
                InteractiveNumber temp = curInteractiveNumberData.numbers[i];
                minCount += temp.minCount;
                maxCount += temp.maxCount;
                if (tempDic.ContainsKey(temp.interactiveType)) continue;
                int range = Random.Range(temp.minCount, temp.maxCount + 1);
                countTemp += range;
                tempDic.Add(temp.interactiveType, range);
            }
            Debug.Log(curTargetCount + "," + minCount + "," + maxCount);
            if (curTargetCount < minCount || curTargetCount > maxCount) throw new System.Exception("交互物刷新数据和交互物房间道路数量错误1");

            while (curTargetCount != countTemp)
            {
                List<InteractiveType> templistAdd = new List<InteractiveType>();
                List<InteractiveType> templistSub = new List<InteractiveType>();
                foreach (var item in tempDic)
                {
                    InteractiveNumber temp = curInteractiveNumberData.numbers.Find(s => s.interactiveType == item.Key);
                    if (item.Value == temp.minCount) templistAdd.Add(item.Key);
                    else if (item.Value == temp.maxCount) templistSub.Add(item.Key);
                    else { templistAdd.Add(item.Key); templistSub.Add(item.Key); }
                }

                if (countTemp > curTargetCount)
                {
                    if (templistSub.Count <= 0) throw new System.Exception("交互物刷新数据和交互物房间道路数量错误2");
                    tempDic[templistSub[Random.Range(0, templistSub.Count)]] -= 1;
                    countTemp -= 1;
                }
                else if (countTemp < curTargetCount)
                {
                    if (templistAdd.Count <= 0) throw new System.Exception("交互物刷新数据和交互物房间道路数量错误3");
                    tempDic[templistAdd[Random.Range(0, templistAdd.Count)]] += 1;
                    countTemp += 1;
                }
            }
        }
        else {
            //固定地图暂时这样处理---待优化
            for (int i = 0; i < curTargetCount; ++i) {
                InteractiveType inter = (InteractiveType)(Random.Range((int)InteractiveType.经文, (int)InteractiveType.地下游商 + 1));
                if (!tempDic.ContainsKey(inter)) tempDic.Add(inter, 0);
                tempDic[inter] += 1;
            }
        }
        foreach (var item in tempDic)
        {
            if (item.Value <= 0) continue;
            for (int i = 0; i < item.Value; ++i) InteractiveResult.Add(item.Key);
        }
        if (InteractiveResult.Count != curTargetCount) throw new System.Exception("当前生成的数量 与 目标数量不等");
        //乱序列表待优化
        for (int i = 0; i < InteractiveResult.Count; ++i) {
            int index = Random.Range(0, InteractiveResult.Count);
            int index2 = Random.Range(0, InteractiveResult.Count);
            var temp = InteractiveResult[index];
            InteractiveResult[index] = InteractiveResult[index2];
            InteractiveResult[index2] = temp;
        }
        if (InteractiveResult.Count <= 0) throw new System.Exception($"交互物刷新数量参数错误-交互物Count = { InteractiveResult.Count }");
    }
  
    /// <summary>
    /// 生成交互物
    /// </summary>
    /// <param name="_type"></param>
    /// <param name="roomIndex"></param>
    /// <param name="routeGroupIndex"></param>
    /// <param name="routeIndex"></param>
    private void CreateInteraciveAdd(MapType _type, int roomIndex, int routeGroupIndex, int routeIndex)
    {
        if (InteractiveResult.Count <= 0) throw new System.Exception($"InteractiveResult.Count <= 0");
         InteractiveType temp = InteractiveResult[0];
        InteractiveResult.RemoveAt(0);
        switch (_type)
        {
            case MapType.房间:
                mapData.addRoomList.Add(new N_AddRoom(N_AddType.交互物, new List<int>(), roomIndex, temp));
                break;
            case MapType.道路:
                mapData.addRouteList.Add(new N_AddRoute(N_AddType.交互物, new List<int>(), routeGroupIndex, routeIndex, temp));
                break;
        }
    }
    /// <summary>
    /// 生成房间附加物，目前仅有怪物盒子
    /// </summary>
    private void CreateRoomAdd()
    {
        mapData.addRoomList = new List<N_AddRoom>();
        for (int i = 0; i < mapData.rooms.Count; ++i)
        {
            switch (mapData.rooms[i].roomType)
            {
                case N_MiniMapRoomType.战斗房间:
                case N_MiniMapRoomType.精英房间:
                case N_MiniMapRoomType.Boss房间:
                    List<MonsterGroup> monsterGroups = mapMonsterGroup.roomMonsters.Find(s => s.roomType == mapData.rooms[i].roomType).monsterGroups;
                    mapData.addRoomList.Add(new N_AddRoom(N_AddType.怪物, monsterGroups[Random.Range(0, monsterGroups.Count)].monsterGroup, i,null));
                    break;
                case N_MiniMapRoomType.有战斗和交互物房间:
                  
                    List<MonsterGroup> monsterGroups1 = mapMonsterGroup.roomMonsters.Find(s => s.roomType == mapData.rooms[i].roomType).monsterGroups;
                    mapData.addRoomList.Add(new N_AddRoom(N_AddType.怪物, monsterGroups1[Random.Range(0, monsterGroups1.Count)].monsterGroup, i, null));

                    CreateInteraciveAdd(MapType.房间, i, -1, -1); 
                    break;
                case N_MiniMapRoomType.入口:
                    //{
                    //    ////测试
                    //    mapData.addRoomList.Add(new N_AddRoom(N_AddType.交互物, new List<int>(), i, InteractiveType.冥想台));
                    //    break;
                    //}
                case N_MiniMapRoomType.普通房间:
                    break;
                case N_MiniMapRoomType.交互物房间:
                    CreateInteraciveAdd(MapType.房间, i, -1, -1);
                    break;
            }
        }
    }
 
    /// <summary>
    /// 生成道路附加物，目前仅有怪物盒子
    /// </summary>
    private void CreateRouteAdd()
    {
        mapData.addRouteList = new List<N_AddRoute>();
        for (int i = 0; i < mapData.routeGroups.Count; ++i)
        {
            for (int j = 0; j < mapData.routeGroups[i].routes.Count; ++j)
            {
                switch (mapData.routeGroups[i].routes[j].routeType)
                {
                    case N_MiniMapRouteType.战斗道路:
                    case N_MiniMapRouteType.精英战斗道路:
                        List<MonsterGroup> monsterGroups = mapMonsterGroup.routeMonsters.Find(s => s.routeType == mapData.routeGroups[i].routes[j].routeType).monsterGroups;
                        mapData.addRouteList.Add(new N_AddRoute(N_AddType.怪物, monsterGroups[Random.Range(0, monsterGroups.Count)].monsterGroup, i, j,null));
                        break;
                    case N_MiniMapRouteType.交互物道路:
                        CreateInteraciveAdd(MapType.道路, -1,i,j); 
                        break;
                }
            }
        }
    }

    /// <summary>
    /// 判断在坐标v是否可以放置房间
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    private bool IsUsableForRoom(Vector2Int v)
    {
        for (int i = (v.x - 1 < 0 ? 0 : v.x - 1); i <= (v.x + 1 >= parameter.mapSizeX - 1 ? parameter.mapSizeX - 1 : v.x + 1); ++i)
        {
            for (int j = (v.y - 1 < 0 ? 0 : v.y - 1); j <= (v.y + 1 >= parameter.mapSizeY - 1 ? parameter.mapSizeY - 1 : v.y + 1); ++j)
            {
                if (!map[i, j])
                {
                    return false;
                }
            }
        }
        return true;
    }

    /// <summary>
    /// 尝试连接两个房间，若连接成功则更新道路组列表和地图
    /// </summary>
    /// <param name="connList"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    private bool TryConnectTwoRooms(List<Connection> connList, int index)
    {
        int r1 = connList[index].room1;
        int r2 = connList[index].room2;
        List<Vector2Int> routeGroup = ConnectTwoRooms(roomList[r1], roomList[r2]);
        if (routeGroup != null)
        {
            routeGroupList.Add(routeGroup);
            foreach (var r in routeGroup)
            {
                for (int i = r.x - 1 < 0 ? 0 : r.x - 1; i <= (r.x + 1 >= parameter.mapSizeX ? parameter.mapSizeX - 1 : r.x + 1); ++i)
                {
                    for (int j = r.y - 1 < 0 ? 0 : r.y - 1; j <= (r.y + 1 >= parameter.mapSizeY ? parameter.mapSizeY - 1 : r.y + 1); ++j)
                    {
                        map[i, j] = false;
                    }
                }
            }
            return true;
        }

        return false;
    }

    /// <summary>
    /// 连接房间的实现步骤之一，将房间坐标偏移得到道路起终点坐标并将其连接
    /// </summary>
    /// <param name="sp"></param>
    /// <param name="tp"></param>
    /// <returns></returns>
    private List<Vector2Int> ConnectTwoRooms(Vector2Int sp, Vector2Int tp)
    {
        Vector2Int sp1 = NotOutOfRange(sp + new Vector2Int(sp.x < tp.x ? 2 : -2, 0));
        Vector2Int sp2 = NotOutOfRange(sp + new Vector2Int(0, sp.y < tp.y ? 2 : -2));
        Vector2Int tp1 = NotOutOfRange(tp + new Vector2Int(tp.x < sp.x ? 2 : -2, 0));
        Vector2Int tp2 = NotOutOfRange(tp + new Vector2Int(0, tp.y < sp.y ? 2 : -2));

        List<int> rList = new List<int>() { 1, 2, 3, 4 };
        List<Vector2Int> result = null;
        do
        {
            switch (rList[Random.Range(0, rList.Count)])
            {
                case 1:
                    result = ConnectByThreeLine(sp1, tp1);
                    rList.Remove(1);
                    break;
                case 2:
                    result = ConnectByThreeLine(sp1, tp2);
                    rList.Remove(2);
                    break;
                case 3:
                    result = ConnectByThreeLine(sp2, tp1);
                    rList.Remove(3);
                    break;
                case 4:
                    result = ConnectByThreeLine(sp2, tp2);
                    rList.Remove(4);
                    break;
            }
        } while (result == null && rList.Count > 0);

        return result;
    }

    /// <summary>
    /// 防止坐标偏移后越界
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    private Vector2Int NotOutOfRange(Vector2Int v)
    {
        v.x = v.x < 0 ? 0 : v.x >= parameter.mapSizeX ? parameter.mapSizeX - 1 : v.x;
        v.y = v.y < 0 ? 0 : v.y >= parameter.mapSizeY ? parameter.mapSizeY - 1 : v.y;
        return v;
    }

    /// <summary>
    /// 连接房间的实现步骤之一，将两个点用直线连接
    /// </summary>
    /// <param name="sp"></param>
    /// <param name="tp"></param>
    /// <returns></returns>
    private List<Vector2Int> ConnectByOneLine(Vector2Int sp, Vector2Int tp)
    {
        if (sp.x != tp.x && sp.y != tp.y)
        {
            Debug.Log("这两个房间不能用直线连接");
            return null;
        }

        List<Vector2Int> result = new List<Vector2Int>();

        for (int i = Mathf.Min(sp.x, tp.x); i <= Mathf.Max(sp.x, tp.x); ++i)
        {
            for (int j = Mathf.Min(sp.y, tp.y); j <= Mathf.Max(sp.y, tp.y); ++j)
            {
                if (map[i, j])
                {
                    result.Add(new Vector2Int(i, j));
                }
                else
                {
                    return null;
                }
            }
        }

        if (result[0].Equals(tp))
        {
            result.Reverse();
        }
        return result;
    }

    /// <summary>
    /// 连接房间的实现步骤之一，将两个点用直线分别和拐点连接
    /// </summary>
    /// <param name="v"></param>
    /// <param name="sp"></param>
    /// <param name="tp"></param>
    /// <returns></returns>
    private List<Vector2Int> ConnectByInflection(Vector2Int v, Vector2Int sp, Vector2Int tp)
    {
        List<Vector2Int> list1 = ConnectByTwoLine(sp, v);
        List<Vector2Int> list2 = ConnectByTwoLine(v, tp);
        if (list1 != null && list2 != null)
        {
            for (int i = 1; i < list2.Count; ++i)
            {
                list1.Add(new Vector2Int(list2[i].x, list2[i].y));
            }
            return list1;
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// 连接房间的实现步骤之一，将两个点用二折线连接
    /// </summary>
    /// <param name="sp"></param>
    /// <param name="tp"></param>
    /// <returns></returns>
    private List<Vector2Int> ConnectByTwoLine(Vector2Int sp, Vector2Int tp)
    {
        if (sp.x == tp.x || sp.y == tp.y)
        {
            return ConnectByOneLine(sp, tp);
        }

        //加入两个拐点
        return ConnectByInflection(new Vector2Int(sp.x, tp.y), sp, tp) ?? ConnectByInflection(new Vector2Int(tp.x, sp.y), sp, tp);
    }

    /// <summary>
    /// 连接房间的实现步骤之一，将两个点用三折线连接
    /// </summary>
    /// <param name="sp"></param>
    /// <param name="tp"></param>
    /// <returns></returns>
    private List<Vector2Int> ConnectByThreeLine(Vector2Int sp, Vector2Int tp)
    {
        List<Vector2Int> result = ConnectByTwoLine(sp, tp);
        if (result != null)
        {
            return result;
        }

        //得到拐点列表
        List<Vector2Int> tList = new List<Vector2Int>();
        for (int i = Mathf.Min(sp.x, tp.x) + 1; i < Mathf.Max(sp.x, tp.x); ++i)
        {
            tList.Add(new Vector2Int(i, sp.y));
        }
        for (int j = Mathf.Min(sp.y, tp.y) + 1; j < Mathf.Min(sp.y, tp.y); ++j)
        {
            tList.Add(new Vector2Int(sp.x, j));
        }

        //使用拐点进行连接
        while (tList.Count > 0)
        {
            Vector2Int v = tList[Random.Range(0, tList.Count)];
            result = ConnectByInflection(v, sp, tp);
            if (result != null)
            {
                return result;
            }
            else
            {
                tList.Remove(v);
            }
        }

        return null;
    }

    /// <summary>
    /// 寻找最远房间
    /// </summary>
    /// <param name="sourceRoom"></param>
    /// <returns></returns>
    private int FindRoomFurthest(int sourceRoom)
    {
        //所有房间到源房间的距离字典
        Dictionary<int, int> dDict = new Dictionary<int, int>();
        for (int i = 0; i < mapData.rooms.Count; ++i)
        {
            dDict.Add(i, i.Equals(sourceRoom) ? 0 : 10000);
        }

        //待处理的房间队列
        Queue<int> q = new Queue<int>();
        q.Enqueue(sourceRoom);

        //处理队列中的房间
        while (q.Count > 0)
        {
            int index = q.Dequeue();

            //获取所有与当前房间相连的房间信息
            List<N_RouteGroup> cList = mapData.routeGroups.FindAll(s => s.Room1.Equals(index) || s.Room2.Equals(index));
            if (cList != null)
            {
                foreach (var c in cList)
                {
                    int room = c.Room1.Equals(index) ? c.Room2 : c.Room1;

                    //如果这个房间到源房间的距离比字典中的小，则更新字典，并将这个房间加入到待处理队列
                    if (c.routes.Count + dDict[index] + 1 < dDict[room])
                    {
                        dDict[room] = c.routes.Count + dDict[index] + 1;
                        q.Enqueue(room);
                    }
                }
            }
        }
        
        //从字典中找到最远的房间
        int max = 0;
        int maxRoom = 0;
        foreach (var d in dDict)
        {
            if (d.Value > max)
            {
                max = d.Value;
                maxRoom = d.Key;
            }
        }

        return maxRoom;
    }

    /// <summary>
    /// 生成房间类型的实现，其中入口数量必为1，boss房间离入口最远
    /// </summary>
    /// <param name="rType"></param>
    /// <param name="rList">未被替换的普通房间列表</param>
    private void CreateRoomOneType(N_MiniMapRoomType rType, List<int> rList)
    {
        MapCreateParameterRoom mpRoom = parameter.rooms.Find(s => s.roomType.Equals(rType));
        int count = rType.Equals(N_MiniMapRoomType.入口) ? 1 : Mathf.Min(Random.Range(mpRoom.minCount, mpRoom.maxCount + 1), rList.Count);
        for (int i = 0; i < count; ++i)
        {
            int r = rType.Equals(N_MiniMapRoomType.Boss房间) ? FindRoomFurthest(mapData.rooms.FindIndex(s => s.roomType.Equals(N_MiniMapRoomType.入口))) : rList[Random.Range(0, rList.Count)];
            mapData.rooms[r].roomType = rType;
            rList.Remove(r);
        }
    }

    /// <summary>
    /// 生成道路类型的实现
    /// </summary>
    /// <param name="rType"></param>
    /// <param name="rListList">未被替换的道路类型列表</param>
    private void CreateRouteOneType(N_MiniMapRouteType rType, List<RouteGroup> rgList)
    {
        MapCreateParameterRoute mpRoute = parameter.routes.Find(s => s.routeType.Equals(rType));
        int count = Random.Range(mpRoute.minCount, mpRoute.maxCount + 1);
        for (int i = 0; i < count; ++i)
        {
            RouteGroup rg = rgList[Random.Range(0, rgList.Count)];
            int route = rg.rList[Random.Range(0, rg.rList.Count)];
            mapData.routeGroups[rg.index].routes[route].routeType = rType;
            rg.rList.Remove(route);

            if (rg.rList.Count.Equals(0))
            {
                rgList.RemoveAll(s => s.index.Equals(rg.index));
            }
        }
    }

    /// <summary>
    /// 结构类，表示一个连接
    /// </summary>
    public class Connection
    {
        public int room1;
        public int room2;
        public int lengthMin;

        public Connection(int room1, int room2, int lengthMin)
        {
            this.room1 = room1;
            this.room2 = room2;
            this.lengthMin = lengthMin;
        }

        public Connection(int room1, int room2, Vector2Int v1, Vector2Int v2)
        {
            this.room1 = room1;
            this.room2 = room2;
            lengthMin = Mathf.Abs(v1.x - v2.x) + Mathf.Abs(v1.y - v2.y) - 3;
        }
    }

    /// <summary>
    /// 结构类，表示一个道路组
    /// </summary>
    public class RouteGroup
    {
        public int index;
        public List<int> rList;

        public RouteGroup(int index, List<int> rList)
        {
            this.index = index;
            this.rList = rList;
        }
    }
}
