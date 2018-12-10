using com.mile.common.message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        public static string battleRecord = "";
        //private static ServerDataParse dataParse;
        private static BattleMgr battleMgr;

        static Thread threadWatch = null; // 负责监听客户端连接请求的 线程；
        static Socket socketWatch = null;
        static Dictionary<string, Socket> dict = new Dictionary<string, Socket>();//存放套接字
        static Dictionary<string, ServerSocketAnalyze> serverSocketAnalyzes = new Dictionary<string, ServerSocketAnalyze>();//存放线程
       
        static void Main(string[] args)
        {
            //dataParse = ServerDataParse.Instance;
            battleMgr = new BattleMgr();
            battleMgr.Init();
            //InitServer();
            InitServer();
            Console.ReadLine();
        }

        static void InitServer()
        {
            // 创建负责监听的套接字，注意其中的参数；
            socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // 获得文本框中的IP对象；
            IPAddress address = IPAddress.Parse("192.168.1.8");
            // 创建包含ip和端口号的网络节点对象；
            IPEndPoint endPoint = new IPEndPoint(address, 2233);
            try
            {
                // 将负责监听的套接字绑定到唯一的ip和端口上；
                socketWatch.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                socketWatch.Bind(endPoint);
            }
            catch (SocketException se)
            {
                Console.WriteLine("异常：" + se.Message);
                return;
            }
            // 设置监听队列的长度；
            socketWatch.Listen(10000);
            // 创建负责监听的线程；
            threadWatch = new Thread(WatchConnecting);
            threadWatch.IsBackground = true;
            threadWatch.Start();
        }

        /// <summary>
        /// 监听客户端请求的方法；
        /// </summary>
        static void WatchConnecting()
        {
            Console.WriteLine("开始监听客户端！");
            while (true)  // 持续不断的监听客户端的连接请求；
            {
                // 开始监听客户端连接请求，Accept方法会阻断当前的线程；
                Socket sokConnection = socketWatch.Accept(); // 一旦监听到一个客户端的请求，就返回一个与该客户端通信的 套接字；
                // 将与客户端连接的 套接字 对象添加到集合中；
                if (dict.ContainsKey(sokConnection.RemoteEndPoint.ToString()))
                {
                    dict.Remove(sokConnection.RemoteEndPoint.ToString());
                    serverSocketAnalyzes.Remove(sokConnection.RemoteEndPoint.ToString());
                }
                dict.Add(sokConnection.RemoteEndPoint.ToString(), sokConnection);
                serverSocketAnalyzes.Add(sokConnection.RemoteEndPoint.ToString(), new ServerSocketAnalyze(sokConnection));

            }
        }

        public static void SendMessage(MessageID msgID, PacketDistributed msgData)
        {
            foreach (ServerSocketAnalyze socketAnalyze in serverSocketAnalyzes.Values)
            {
                socketAnalyze.SendMsg(msgID,msgData);
            }
        }


        /// <summary>
        /// 接收发送给本机ip对应端口号的数据报
        /// </summary>
        //static void ReciveMsg()
        //{
        //    while (true)
        //    {
        //        EndPoint point = new IPEndPoint(IPAddress.Any, 0);//用来保存发送方的ip和端口号
        //        clientPoint = point;
        //        byte[] buffer = new byte[1024 * 10];
        //        int length = server.ReceiveFrom(buffer, ref point);//接收数据报
        //        string message = Encoding.UTF8.GetString(buffer, 0, length);
        //        dataParse.ParseData(message);
        //    }
        //}


        //////////////////////////游戏功能 start//////////////////////////////////


        //进入房间
        public static void EnterRoom(GamePlayerInfo p)
        {
            battleMgr.AddPlayer(p);
        }

        //进入游戏
        public static void EnterGame(EnterGame msg)
        {
            battleMgr.StartGame(msg);
        }

        public static void OnNextFrameEvent(NextFrameOpts opts)
        {
            battleMgr.OnNextFrameEvent(opts);
        }
        /////////////////////////////游戏功能 end/////////////////////////////////

    }
}
