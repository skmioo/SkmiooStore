using Datas;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
/// <summary>
/// 队伍结构类
/// </summary>
public class Team
{
    private List<ObjLife> team = new List<ObjLife>();
    private Dictionary<int, ObjLife> objDic = new Dictionary<int, ObjLife>();

    /// <summary>
    /// 添加一个角色（队伍初始化）
    /// </summary>
    /// <param name="i"></param>
    /// <param name="obj"></param>
    public void Add(int i, ObjLife obj)
    {
        objDic.Add(i, obj);
        team = objDic.OrderBy(s => s.Key).Select(s => s.Value).ToList();
    }

    /// <summary>
    /// 队伍初始化完成
    /// </summary>
    public void InitFinish()
    {
        objDic.Clear();
    }

    /// <summary>
    /// 添加一个角色（召唤）
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="direction">方向，默认在后面召唤</param>
    public void Add(ObjLife obj, bool direction = false, int index = 0)
    {
        if (direction)
        {
            team.Insert(index, obj);
        }
        else
        {
            team.Add(obj);
        }
    }

    /// <summary>
    /// 根据角色获取他在队伍中的位置
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public int GetIndex(ObjLife obj)
    {
        int index = team.FindIndex(s => s == obj);//没有元素时返回 -1
        int result = index;
        for (int i = 0; i < index; ++i)
        {
            if (team[i].GetSize() == 2)
            {
                ++result;
            }
        }
        return result;
    }
    
    /// <summary>
    /// 根据角色是否在自己偏好位置
    /// </summary>
    public bool IsPrefer(ObjLife objLife){
        int index = this.GetIndex(objLife);
        PreferMove preferMove = objLife.GetPreferMove();
        if(index < 2){
            return preferMove == PreferMove.前;
        }
        return preferMove == PreferMove.后;
    }

    /// <summary>
    /// 根据角色在队伍中的位置获取他
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public ObjLife GetObjLife(int index)
    {
        if (index < 0) { return null; }
        int result = index;
        for (int i = 0; i < Mathf.Min(index, team.Count); ++i)
        {
            if (team[i].GetSize() == 2)
            {
                --result;
                ++i;
            }
        }
        if (result < 0 || result >= team.Count) { return null; }
        return team[result];
    }

    /// <summary>
    /// 获取队伍中的所有角色
    /// </summary>
    /// <returns></returns>
    public List<ObjLife> GetObjLifes()
    {
        List<ObjLife> result = new List<ObjLife>();
        foreach (var item in team)
        {
            result.Add(item);
        }
        return result;
    }
    /// <summary>
    /// 获取队伍中的所有Animation
    /// </summary>
    /// <returns></returns>
    public List<RoleAnimationController> GetAnimation()
    {
        List<RoleAnimationController> result = new List<RoleAnimationController>();
        foreach (var item in team)
        {
            result.Add(item.roleAniCon);
        }
        return result;
    }

    /// <summary>
    /// 获取队伍中角色的数量
    /// </summary>
    /// <returns></returns>
    public int GetCount()
    {
        int result = team.Count;
        foreach (var obj in team)
        {
            if (obj.GetSize() == 2)
            {
                result++;
            }
        }
        return result;
    }

    /// <summary>
    /// 队伍中是否存在该角色
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public bool Contains(ObjLife obj)
	{
		if (tunshiObjs.Contains(obj))
			return true;
		return team.Contains(obj);
    }

    /// <summary>
    /// 角色死亡，队伍位置调整
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public void Death(ObjLife obj)
    {
        team.Remove(obj);
    }
	List<ObjLife> tunshiObjs = new List<ObjLife>();
	/// <summary>
	/// 角色被吞噬
	/// </summary>
	/// <param name="obj"></param>
	public void OnTunshi(ObjLife obj)
	{
		tunshiObjs.Add(obj);
	}

	/// <summary>
	/// 角色被吞噬释放
	/// </summary>
	/// <param name="obj"></param>
	public void OnTunshiRelease(ObjLife obj)
	{
		if (tunshiObjs.Contains(obj))
			tunshiObjs.Remove(obj);
	}


	/// <summary>
	/// 队伍列表中角色前移
	/// </summary>
	/// <param name="obj"></param>
	/// <param name="value"></param>
	/// <returns>受影响需要进行位移的其他角色</returns>
	public List<ObjLife> MoveForward(ObjLife obj, int value)
    {
        int current = GetIndex(obj);
        int target = (current - value) < 0 ? 0 : (current - value);

        team.Remove(obj);
        team.Insert(target, obj);

        return team.GetRange(target, current - target + 1);
    }

    /// <summary>
    /// 队伍列表中角色后移
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="value"></param>
    /// <returns>受影响需要进行位移的其他角色</returns>
    public List<ObjLife> MoveBackword(ObjLife obj, int value)
    {
        int current = GetIndex(obj);
        int target = (current + value) >= team.Count ? (team.Count - 1) : (current + value);

        team.Remove(obj);
        if (target >= team.Count)
        {
            team.Add(obj);
        }
        else
        {
            team.Insert(target, obj);
        }

        return team.GetRange(current, target - current + 1);
    }

    /// <summary>
    /// 获取可以与该角色换位的角色
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public List<ObjLife> GetCanBeExchange(ObjLife obj)
    {
        int index = GetIndex(obj);
        List<ObjLife> result = new List<ObjLife>();
        if (index > 0)
        {
            result.Add(GetObjLife(index - 1));
        }
        if (index < GetCount() - 1)
        {
            result.Add(GetObjLife(index + 1));
        }
        return result;
    }

    /// <summary>
    /// 队伍列表中角色位置互换
    /// </summary>
    /// <param name="obj1"></param>
    /// <param name="obj2"></param>
    public void Exchange(ObjLife obj1, ObjLife obj2)
    {
        int index1 = GetIndex(obj1);
        int index2 = GetIndex(obj2);

        team.Insert(index1, obj2);
        team.RemoveAt(index1 + 1);
        team.Insert(index2, obj1);
        team.RemoveAt(index2 + 1);
    }

    /// <summary>
    /// 重置列表顺序
    /// </summary>
    /// <param name="objLives"></param>
    public void Init(List<ObjLife> objLives)
    {
        team.Clear();
		tunshiObjs.Clear();

		foreach (var item in objLives)
        {
            team.Add(item);
        }
    }

    /// <summary>
    /// 获取技能目标位置对应的角色
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public List<ObjLife> GetRoleByPosition(SkillPosition position)
    {
        List<ObjLife> result = new List<ObjLife>();
        if (position.W && GetCount() > 0)
        {
            result.Add(GetObjLife(0));
        }
        if (position.X && GetCount() > 1)
        {
            result.Add(GetObjLife(1));
        }
        if (position.Y && GetCount() > 2)
        {
            result.Add(GetObjLife(2));
        }
        if (position.Z && GetCount() > 3)
        {
            result.Add(GetObjLife(3));
        }
        return result;
    }
}


