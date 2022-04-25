using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Datas;

/// <summary>
/// 房间附加交互物基类
/// </summary>
public class AddRoomBase : MonoBehaviour
{
    public MapController mapController;
    public int roomIndex;
    public int routeGroupIndex;
    public int routeIndex;
    public MapType mapType;
    protected AddRoomData addRoomData;

    public virtual void InitAddRoom(AddRoomData _addRoomData)
    {
        addRoomData = _addRoomData;
    }
    
}
