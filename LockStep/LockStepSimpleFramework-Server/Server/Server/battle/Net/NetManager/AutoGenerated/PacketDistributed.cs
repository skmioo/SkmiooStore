//Auto Generate File, Do NOT Modify!!!!!!!!!!!!!!!

using System.IO;
using System;
using System.Net.Sockets;
using Google.ProtocolBuffers;
using com.mile.common.message;

	public abstract class PacketDistributed

	{

		public static PacketDistributed CreatePacket(MessageID packetID)
		{
			PacketDistributed packet = null;
			switch (packetID)
			{
			case MessageID.GCErrorBack: { packet = new GCErrorBack();}break;
			case MessageID.CGheartbeatClientSend: { packet = new CGheartbeatClientSend();}break;
			case MessageID.GCheartbeatServerBack: { packet = new GCheartbeatServerBack();}break;
			case MessageID.GCServerMsg: { packet = new GCServerMsg();}break;
			case MessageID.OptionEvent: { packet = new OptionEvent();}break;
			case MessageID.FrameOpts: { packet = new FrameOpts();}break;
			case MessageID.LogicFrame: { packet = new LogicFrame();}break;
			case MessageID.NextFrameOpts: { packet = new NextFrameOpts();}break;
			case MessageID.GamePlayerInfo: { packet = new GamePlayerInfo();}break;
			case MessageID.EnterGame: { packet = new EnterGame();}break;

		}
		if (null != packet)
		{
			packet.packetID = packetID;
		}
		//netActionTime = DateTime.Now.ToFileTimeUtc();
		return packet;
	}
   
	public byte[] ToByteArray()
	{
		//Check must init
		if (!IsInitialized())
		{
			throw InvalidProtocolBufferException.ErrorMsg("Request data have not set");
		}
		byte[] data = new byte[SerializedSize()];
		CodedOutputStream output = CodedOutputStream.CreateInstance(data);
		WriteTo(output);
		output.CheckNoSpaceLeft();
		return data;
	}
	public PacketDistributed ParseFrom(byte[] data)
	{
		CodedInputStream input = CodedInputStream.CreateInstance(data);
		PacketDistributed inst = MergeFrom(input,this);
		input.CheckLastTagWas(0);
		return inst;
	}

	public abstract int SerializedSize();
	public abstract void WriteTo(CodedOutputStream data);
	public abstract PacketDistributed MergeFrom(CodedInputStream input,PacketDistributed _Inst);
	public abstract bool IsInitialized();

	protected MessageID packetID;

	public MessageID getMessageID()
	{ 
		return packetID;
	}
}
