using com.mile.common.message;


public class Handle_BeforeLoginBack : HandleNetMessageBase
{
    public override bool HandleMessage()
    {
        if (!CheckParamsValid(1))
        {
            return false;
        }
        return true;
    }

  
}
