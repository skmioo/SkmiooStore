
public enum MapType
{
    房间, 道路
}

public enum RoomType
{
    一般, 宝物, 大厅
}

public enum RouteType
{
    起点, 终点, 蘑菇, 墓地, 荒地, 雪景
}
/// <summary>
/// 房间附加交互类型
/// </summary>
public enum AddRoomType
{
    战斗, 交互物, 陷阱
}

public enum N_MiniMapRoomType
{
    普通房间, 入口, Boss房间, 战斗房间, 交互物房间, 有战斗和交互物房间, 精英房间
}

public enum N_MiniMapRouteType
{
    普通道路, 战斗道路, 交互物道路, 精英战斗道路
}
/// <summary>
///用来标记不同怪物的属性，区分人形怪物和异兽 (感觉不是这个像是：附加物的类型)
/// </summary>
public enum N_AddType
{
    怪物,交互物
}
/// <summary>
/// 任务难度
/// </summary>
public enum TaskDifficulty
{
    人迹罕至, 危机四伏, 艰难险阻
}

public enum MapSizeType
{
    狭小, 宽敞
}

public enum MapNameType
{
    镂空之地, 冥河矿洞, 教程关卡
}