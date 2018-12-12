using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpPro;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using com.mile.qmqj.common.message;
public enum MessageID
{
    CS10002 = 10002,
    CS10012 = 10012,
}

namespace CSharpExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //链接网络
            string errorlog="";
            Socket clientsocket = SocketAPI.ConnectToServer("127.0.0.1", 9999, ref errorlog);
          //  if (clientsocket != null)
            {
                CS10002 data = (CS10002)PacketDistributed.CreatePacket(MessageID.CS10002);
                data.SetUserName("zhuzhu");
                data.SetPassword("Mini");
                data.SetVersion("10.0");

                data.SendPacket(clientsocket);
                while (true)
                {
                    
                    Thread.Sleep(500); 
                }
            }
        }
    }
}
