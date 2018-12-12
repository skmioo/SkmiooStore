
/**********************************************
* @说明: 检查网络状态
* @作者：ZHM --- 海鸣不骑猪 
* @版本号：V1.00
**********************************************/
using System;

public class CheckNet
{ 
    /// <summary>
    /// 检查网络状态
    /// </summary>
    /// <param name="netState"></param>
    public static void CheckNetTick(NetState netState)
    {
		if (netState != NetState.Connected)
			Console.WriteLine("网络连接状态：" + netState + "   " + GameNet.Instance.IP + ":" + GameNet.Instance.PORT); 
        switch (netState)
        {
            case NetState.Disconnect:
                NetworkManager.Reconnnect();
                break;
            case NetState.NotConnect:
                break;
            case NetState.Exception:
				NetworkManager.Reconnnect();
                break;
            case NetState.Unsteadiness:
                break;
            case NetState.TimeOut:
                NetworkManager.Reconnnect(); 
                break;
            default:
                return ;
        }
    }
}
