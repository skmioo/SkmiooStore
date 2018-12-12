using com.mile.common.message;


public class Send_BeforeLogin : SendNetMessageBase
{
    public override bool SendMessage()
    {
        return true;
    }
}