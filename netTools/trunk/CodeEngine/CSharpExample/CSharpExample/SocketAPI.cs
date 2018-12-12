using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace CSharpPro
{
  public  class SocketAPI
  {
      #region 连接到服务器
    
      public static Socket ConnectToServer(string szServerAddr, int nServerPort, ref string errorInfo,
          SocketType streamType =SocketType.Stream, ProtocolType eType = ProtocolType.Tcp)
      {
          IPAddress ServerIPAdd = null;
          IPEndPoint ServerEndPoint = null;
         
          try
          {
              if (!IPAddress.TryParse(szServerAddr, out ServerIPAdd))
              {
                  return null;
              }
              ServerEndPoint = new IPEndPoint(ServerIPAdd, nServerPort);
          }
          catch (System.ArgumentException ex) { errorInfo = ex.ToString(); }       
          catch (System.Exception ex) { errorInfo = ex.ToString(); }

          Socket ClientSocket = null;
          try
          {
              //客户端SOCKET
              ClientSocket = new Socket(AddressFamily.InterNetwork, streamType, eType);
              //建立与服务器端的连接
              ClientSocket.Connect(ServerEndPoint);

              return ClientSocket;
          }
          catch (SocketException ex) { errorInfo = ex.ToString(); }        
          catch (System.Exception ex) { errorInfo = ex.ToString(); }
         
          return null;
      }
#endregion

#region 收发送数据
      public static int SendData(Socket clientSocket, byte[] data)
      {
          if (clientSocket != null && data.Length >0)
          {
              return clientSocket.Send(data);
          }
          return -1;
      }

      public static byte[] Reveive(Socket clientSocket)
      {
          if (clientSocket == null) return null;

          if (clientSocket.Available > 0)          
          {
              byte[] datas = new byte[clientSocket.Available];
              clientSocket.Receive(datas);
              return datas;
          }
          return null;
      }

      public static bool IsConnected(Socket clientSocket)
      {
          return clientSocket != null;
      }
      public static void Close(Socket clientSocket)
      {
          if (clientSocket != null)
          {
              clientSocket.Shutdown(SocketShutdown.Both);
              clientSocket.Close();
              clientSocket = null;
          }
          
      }
#endregion
    }
}
