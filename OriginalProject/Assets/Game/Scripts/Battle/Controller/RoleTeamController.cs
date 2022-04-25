using Datas;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement;

/// <summary>
/// 角色，队伍控制器
/// </summary>
public class RoleTeamController : MonoBehaviour
{
    private List<ObjLife> roleTeam = new List<ObjLife>();

    /// <summary>
    /// 完成移动角色所需要的时间
    /// </summary>
    private const float TIME_ROLE_MOVE = 0.8f;

    /// <summary>
    /// 队伍中角色的位置偏移
    /// </summary>
    private const float OFFSET_POSITION_X = 1.8f;

    /// <summary>
    /// 在场景中实例化角色并添加到队伍中
    /// </summary>
    /// <param name="roleType"></param>
    public void InitRoleTeam(RoleType roleType)
    {
        if (roleType.Equals(RoleType.英雄))
        {
            for (int i = 0; i < BattleInfo.waitingTeams.Count; ++i)
            {
                InitImpl(BattleInfo.waitingTeams[i], i);
            }
        }
        else
        {
            for (int i = 0; i < BattleInfo.waitingTeams.Count; ++i)
            {
                //roleTeam[i].GetRoleData().roleMode.InstantiateAsync(new Vector3(i * OFFSET_POSITION_X, 0, 0), Quaternion.identity, transform);
            }
        }
    }

    private void InitImpl(ObjLifeData objLifeData, int index)
    {
        objLifeData.GetRoleModel().InstantiateAsync(new Vector3(-index * OFFSET_POSITION_X - 1, 0.7f, 0), Quaternion.identity, transform).Completed += go =>
        {
            ObjLife objLife = go.Result.GetComponent<ObjLife>();
            objLife.InitRole(objLifeData);
            roleTeam.Add(objLife);
        };
    }

    /// <summary>
    /// 将角色加入队伍
    /// </summary>
    /// <param name="objLife"></param>
    public void AddRoleToTeam(ObjLife objLife)
    {
        roleTeam.Add(objLife);
    }

    /// <summary>
    /// 将角色移出队伍
    /// </summary>
    /// <param name="objLife"></param>
    public void RemoveRoleFromTeam(ObjLife objLife)
    {
        roleTeam.Remove(objLife);
    }

    /// <summary>
    /// 角色位置交换
    /// </summary>
    /// <param name="objLife1"></param>
    /// <param name="objLife2"></param>
    public void ExchangePosition(ObjLife objLife1, ObjLife objLife2)
    {
        //交换场景中的位置
        objLife1.RoleMove(TIME_ROLE_MOVE, objLife2.GetTransformPosition());
        objLife2.RoleMove(TIME_ROLE_MOVE, objLife1.GetTransformPosition());

        //交换列表中的位置
        int index1 = roleTeam.FindIndex(s => s.Equals(objLife1));
        int index2 = roleTeam.FindIndex(s => s.Equals(objLife2));
        var temp = objLife1;
        roleTeam[index1] = objLife2;
        roleTeam[index2] = temp;
    }

    /// <summary>
    /// 角色前移
    /// </summary>
    /// <param name="objLife"></param>
    /// <param name="value"></param>
    public void RoleMoveForward(ObjLife objLife, int value)
    {
        int currentIndex = roleTeam.FindIndex(s => s.Equals(objLife));
        int targetIndex = (currentIndex - value) < 0 ? 0 : (currentIndex - value);

        //移动场景中英雄的位置
        List<ObjLife> othersRole = roleTeam.GetRange(targetIndex, currentIndex - targetIndex);
        foreach (var role in othersRole)
        {
            role.RoleMove(TIME_ROLE_MOVE, roleTeam[roleTeam.FindIndex(s => s.Equals(role)) + 1].GetTransformPosition());
        }
        objLife.RoleMove(TIME_ROLE_MOVE, roleTeam[targetIndex].GetTransformPosition());

        //移动列表中英雄的位置
        roleTeam.Remove(objLife);
        roleTeam.Insert(targetIndex, objLife);
    }

    /// <summary>
    /// 角色后移
    /// </summary>
    /// <param name="objLife"></param>
    /// <param name="value"></param>
    public void RoleMoveBack(ObjLife objLife, int value)
    {
        int currentIndex = roleTeam.FindIndex(s => s.Equals(objLife));
        int targetIndex = (currentIndex + value) >= roleTeam.Count ? (roleTeam.Count - 1) : (currentIndex + value);

        //移动场景中英雄的位置
        List<ObjLife> othersRole = roleTeam.GetRange(currentIndex + 1, targetIndex - currentIndex);
        foreach (var role in othersRole)
        {
            role.RoleMove(TIME_ROLE_MOVE, roleTeam[roleTeam.FindIndex(s => s.Equals(role)) - 1].GetTransformPosition());
        }
        objLife.RoleMove(TIME_ROLE_MOVE, roleTeam[targetIndex].GetTransformPosition());

        //移动列表中英雄的位置
        roleTeam.Remove(objLife);
        if (targetIndex >= roleTeam.Count)
        {
            roleTeam.Add(objLife);
        }
        else
        {
            roleTeam.Insert(targetIndex, objLife);
        }
    }
}
