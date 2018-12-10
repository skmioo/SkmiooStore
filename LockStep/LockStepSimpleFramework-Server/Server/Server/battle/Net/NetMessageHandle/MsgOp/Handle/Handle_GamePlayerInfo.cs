
using com.mile.common.message;
using Server;

public class Handle_GamePlayerInfo : HandleNetMessageBase
{
    public override bool HandleMessage()
    {
        GamePlayerInfo msg = GetParam<GamePlayerInfo>(0);
        Program.EnterRoom(msg);
        return true;
    }
}
