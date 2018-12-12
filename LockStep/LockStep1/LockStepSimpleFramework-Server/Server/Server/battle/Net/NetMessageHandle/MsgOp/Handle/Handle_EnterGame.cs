


using com.mile.common.message;
using Server;

public class Handle_EnterGame : HandleNetMessageBase
{
    public override bool HandleMessage()
    {
        EnterGame msg = GetParam<EnterGame>(0);
        Program.EnterGame(msg);
        return true;
    }
}
