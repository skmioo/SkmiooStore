using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Utils;

/// <summary>
/// 位置工具，修改脚本自PlayerControllerManager
/// </summary>
public static class RolePosManager
{
    public const float width = 1.7f;
    public const float original = 1.75f;
    private static Vector3[] playerPos;
    private static Vector3[] enemyPos;

    private static bool inited = false;
    private static void Init()
    {
        inited = true;
        playerPos = new Vector3[4];
        enemyPos = new Vector3[4];
        for (int i = 0; i < 4; i++)
        {
            playerPos[i] = new Vector3(-(original + width * i), 0, 0);
            enemyPos[i] = new Vector3(original + width * i, 0, 0);
        }
    }

    /// <summary>
    /// 返回英雄的位置
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    public static Vector3 GetHeroLocalPosition(int pos)
    {
        if (!inited)
        {
            Init();
        }
        return playerPos[pos];
    }
    /// <summary>
    /// 返回指定敌人的位置
    /// </summary>
    /// <param name="pos">敌人在列表中的位置</param>
    /// <returns></returns>
    public static Vector3 GetEnemyLocalPosition(int pos)
    {
        if (!inited)
        {
            Init();
        }
        return enemyPos[pos];
    }




    /// <summary>
    /// 返回队伍的中间点
    /// </summary>
    /// <returns></returns>
    //public static float GetPlayerMiddlePoint()
    //{
    //    float middlePoint;
    //    //计算队伍中点
    //    int playerNum = BattleController.Instance.HeroNum;
    //    if (playerNum % 2 == 0)
    //    {
    //        middlePoint = Mathh.Average(playerPos[playerNum / 2].x, playerPos[playerNum / 2 - 1].x);
    //    }
    //    else
    //    {
    //        middlePoint = playerPos[playerNum / 2].x;
    //    }
    //    return middlePoint;
    //}
}
