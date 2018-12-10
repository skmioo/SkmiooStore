using System;
using UnityEngine;
using System.Collections;
using com.mile.common.message;


/**********************************************
* @说明: 接受消息测试
* @作者：SS 
* @版本号：V1.00
**********************************************/
/*
public class OP_GCLoginGameServer
{
    public static void Execute(object p)
    {
        GCLoginGameServer lb = p as GCLoginGameServer;

		NetMsgManager.Instance.HandleMessage(MessageID.GCLoginGameServer, lb);
    }
}

public class OP_GCEnterScene
{
    public static void Execute(object p)
    {
        GCEnterScene gcEnterScene = p as GCEnterScene;
        //LogCtrl.Info("GCEnterScene Flag = {0} SceneId = {1}", gcEnterScene.Flag, gcEnterScene.SceneId);
        NetMsgManager.Instance.HandleMessage(MessageID.GCEnterScene, gcEnterScene);
    }
}


public class OP_GCEnterSceneOk
{
    public static void Execute(object p)
    {
        GCEnterSceneOk gcEnterSceneOk = p as GCEnterSceneOk;
		NetMsgManager.Instance.HandleMessage(MessageID.GCEnterSceneOk, gcEnterSceneOk);
    }
}
*/

public class OP_GCheartbeatServerBack
{
    public static void Execute(object p)
    {
        GCheartbeatServerBack msg = p as GCheartbeatServerBack;
        NetMsgManager.Instance.HandleMessage(MessageID.GCheartbeatServerBack, msg);
    }
}

public class OP_CGheartbeatClientSend
{
    public static void Execute(object p)
    {
        CGheartbeatClientSend msg = p as CGheartbeatClientSend;
        NetMsgManager.Instance.HandleMessage(MessageID.CGheartbeatClientSend, msg);
    }
}

public class OP_GamePlayerInfo
{
    public static void Execute(object p)
    {
        GamePlayerInfo msg = p as GamePlayerInfo;
        NetMsgManager.Instance.HandleMessage(MessageID.GamePlayerInfo, msg);
    }
}

public class OP_EnterGame
{
    public static void Execute(object p)
    {
        EnterGame msg = p as EnterGame;
        NetMsgManager.Instance.HandleMessage(MessageID.EnterGame, msg);
    }
}

public class OP_NextFrameOpts
{
    public static void Execute(object p)
    {
        NextFrameOpts msg = p as NextFrameOpts;
        NetMsgManager.Instance.HandleMessage(MessageID.NextFrameOpts, msg);
    }
}



