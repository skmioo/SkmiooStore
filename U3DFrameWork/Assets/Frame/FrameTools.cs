using UnityEngine;
using System.Collections;

public enum MessageID
{
	GameManager = 0,
	UIManager = FrameTools.MsgSpan,
	AudioManager = FrameTools.MsgSpan * 2,
	NPCManager = FrameTools.MsgSpan * 3,
	CharactorManager = FrameTools.MsgSpan * 4,
	AssetManager = FrameTools.MsgSpan * 5,
	NetManager = FrameTools.MsgSpan * 6,
	UIManagerTwo = FrameTools.MsgSpan * 7
}

/// <summary>
/// Frame Tool
/// </summary>
public class FrameTools 
{
	//表示 消息主类大小
	public const int MsgSpan = 3000;



}

