
using com.mile.common.message;
using Server;
using System;

public class Handle_NextFrameOpts : HandleNetMessageBase
{
    public override bool HandleMessage()
    {
        NextFrameOpts msg = GetParam<NextFrameOpts>(0);
        Program.OnNextFrameEvent(msg);
        return true;
    }

}
