using com.mile.common.message;
using Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Timers;

public class BattleMgr
{
    //预定的每帧的时间长度
    float m_fFrameLen;
    int frameId = 0;
    //保存着所有帧的战斗数据
    List<FrameOpts> matchFrames;
    //下一帧的战斗数据
    FrameOpts nextFrameOpt;
    Timer timer;
    float currentTime;
    //玩家个数
    public List<GamePlayerInfo> players = new List<GamePlayerInfo>();

    public void Init()
    {
        m_fFrameLen = 0.066f;
        matchFrames = new List<FrameOpts>();
        nextFrameOpt = new FrameOpts();
    }

    public void AddPlayer(GamePlayerInfo player)
    {
        GamePlayerInfo ret = players.Find(p => p.SeatId == player.SeatId);
        if (ret != null)
        {
            players.Remove(ret);
        }
        players.Add(player);
        Console.WriteLine("player 个数: " + players.Count + " seatId:" + player.SeatId);
    }

    public void StartGame(EnterGame msg)
    {
        if (msg.IsStartGame > 0)
        {
            Console.WriteLine("StartGame");
            //开启逻辑帧事件
            timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(OnLogicFrame);
            timer.Interval = m_fFrameLen * 1000;
            //执行一次 false，一直执行true  
            timer.AutoReset = true;
            timer.Enabled = true;
        }
        
    }

    /// <summary>
    /// 开启逻辑帧事件
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    public void OnLogicFrame(object source, ElapsedEventArgs e)
    {
        currentTime += m_fFrameLen * 1000;
        //5秒后执行事件
        if (currentTime > 1000 + m_fFrameLen * 1000)
        {
            //保存上一帧的数据
            matchFrames.Add(nextFrameOpt);
            //发送当前帧的数据给所有玩家
            for (int i = 0; i < players.Count; i++ )
            {
                SendUnsyncFrames(players[i]);
            }

            frameId++;
            //设置下一帧，并等待客户端发来的帧数据
            nextFrameOpt = new FrameOpts();
        }
    }

    /// <summary>
    /// 发送未同步的帧
    /// </summary>
    /// <param name="player"></param>
    public void SendUnsyncFrames(GamePlayerInfo player)
    {
        //发送消息给客户端
        LogicFrame logicFrame = new LogicFrame();
        logicFrame.SetFrameId(frameId);
       
        for (int i = player.SyncFrameId + 1; i < matchFrames.Count; i++)
        {
            logicFrame.AddUnSyncFrames(matchFrames[i]);
        }


        //TODO
        //UDP发送消息给客户端
        //upd_send_cmd(Stype.Logic,Cmd.eLogicFrame,body)
        Program.SendMessage(MessageID.LogicFrame,logicFrame);

    }

    /// <summary>
    /// 客户端发送给服务器 同步玩家帧信息，如 player.syncFrameId
    /// </summary>
    public void OnNextFrameEvent(NextFrameOpts _nextFrameOpts)
    {
        int seatId = _nextFrameOpts.SeatId;
        //同步player信息
        GamePlayerInfo player = players.Find(p => p.SeatId == seatId);
        if (player == null)
        {
            return;
        }
      
        //同步客户端已同步帧id
        if (player.SyncFrameId < _nextFrameOpts.FrameId - 1)
        {
            player.SetSyncFrameId(_nextFrameOpts.FrameId - 1);
        }
        //客户端发送的帧id未达到最新帧，丢弃
        if (_nextFrameOpts.FrameId != frameId)
        {
            return;
        }       
        nextFrameOpt.SetFrameId(_nextFrameOpts.FrameId);
        
        for (int i = 0; i < _nextFrameOpts.optsCount; i++)
        {
            //Console.WriteLine("收到:..." + _nextFrameOpts.GetOpts(i).SeatId);
            nextFrameOpt.AddOpts(_nextFrameOpts.GetOpts(i));
        }    
    }

}
