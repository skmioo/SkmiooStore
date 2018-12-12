using com.mile.common.message;

public class Factory_CreateMessage : CSharpSingletion<Factory_CreateMessage>
{
    public NetMessageBase CreateNetMessage(MessageID msgID)
    {
        switch (msgID)
        {
            //心跳
            case MessageID.CGheartbeatClientSend:
                return CreateClass<Handle_HeartbeatClientSend>();
            case MessageID.GCheartbeatServerBack:
                return CreateClass<Send_HeartbeatServerBack>();
            case MessageID.GamePlayerInfo:
                return CreateClass<Handle_GamePlayerInfo>();
            case MessageID.EnterGame:
                return CreateClass<Handle_EnterGame>();
            case MessageID.NextFrameOpts:
                return CreateClass<Handle_NextFrameOpts>();
        }

        return null;
    }

    private T CreateClass<T>() where T : new()
    {
        return new T();
    }
}
