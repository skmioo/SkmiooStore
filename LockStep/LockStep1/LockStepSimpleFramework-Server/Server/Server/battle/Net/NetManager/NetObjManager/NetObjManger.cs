
using System.Collections.Generic;
using System;


public class NetObjManger : CSharpSingletion<NetObjManger>
{
    private Dictionary<Int64, object> _idToObjDic = null;
    private Dictionary<object, Int64> _objToIdDic = null;

    #region interface implementation
    public void OnInit()
    {
        _idToObjDic = new Dictionary<Int64, object>();
        _objToIdDic = new Dictionary<object, Int64>();
    }

	public void OnDispose()
	{
        _idToObjDic.Clear();
        _objToIdDic.Clear();
        _idToObjDic = null;
        _objToIdDic = null;
	}
    #endregion

    public T GetObjByID<T>(Int64 objID)
    {
        object obj = GetObjByID(objID);
        return (T)obj;
    }

    public object GetObjByID(Int64 objID)
	{
		object obj;
		if (_idToObjDic.TryGetValue(objID, out obj))
			return obj;
		
        Console.Write("没有找到id {0} 的obj！",objID);
		return null;
	}

    public Int64 GetIDByObj(object obj)
    {
        Int64 id = -1;
        _objToIdDic.TryGetValue(obj, out id);
        return id;
    }

	public void AddObj(Int64 objID, object obj)
	{
        Console.Write("obj不能为null");

        if (_idToObjDic.ContainsKey(objID))
            _idToObjDic[objID] = obj;
        else
            _idToObjDic.Add(objID, obj);

        if (_objToIdDic.ContainsKey(obj))
            _objToIdDic[obj] = objID;
        else
            _objToIdDic.Add(obj, objID);

    }

	public void DelObj(Int64 objID)
	{
        if (_idToObjDic.ContainsKey(objID))
        {
            object obj = _idToObjDic[objID];
            _idToObjDic.Remove(objID);
            Console.Write("obj 和 id不对应");
            _objToIdDic.Remove(obj);
        }
        
//		GameLog.LogCtrl.Warn("没有找到id " + objID + "的obj!");
	}
}

