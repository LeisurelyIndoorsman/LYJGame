using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

namespace LWSocket
{
    public class SocketTest
    {

        static Socket client;
        // static Socket client;
        //delegate float DFloatVoidFunc(int val1, float val2);

        private void Awake()
        {
            //DontDestroyOnLoad(this.gameObject);
            AsynConnect();
        }

        static void Main(string[] args)
        {


            
            //int port = 5099;
            //string host = "192.168.0.75";//服务器端ip地址

            //IPAddress ip = IPAddress.Parse(host);
            //IPEndPoint ipe = new IPEndPoint(ip, port);

            //Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ////clientSocket.Listen(20);
            //clientSocket.Connect(ipe);



            ////send message
            //string sendStr = "lue lue lue";
            //byte[] sendBytes = Encoding.ASCII.GetBytes(sendStr);
            //clientSocket.Send(sendBytes);

            ////receive message
            //string recStr = "";
            //byte[] recBytes = new byte[4096];
            //int bytes = clientSocket.Receive(recBytes, recBytes.Length, 0);
            //recStr += Encoding.ASCII.GetString(recBytes, 0, bytes);
            //Console.WriteLine(recStr);

            //clientSocket.Close();

            //Console.ReadLine();
        }
        /// <summary>  
        /// 连接到服务器  
        /// </summary>  
        public static void AsynConnect()
        {
            //端口及IP  
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse("192.168.0.75"), 5099);
            //创建套接字  
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //开始连接到服务器  
            client.BeginConnect(ipe, asyncResult =>
            {

                client.EndConnect(asyncResult);
            //向服务器发送消息  
            //AsynSend(client, "hello I am hahaha\n");
            //AsynSend(client, "第一条消息\n");
            //AsynSend(client, "第二条消息\n");
            AsynRecive(client);


            //Console.ReadKey();

            //接受消息  



            //Console.ReadLine();
        }, null);

            //输入
            //string str = "";
            //while ((str = Console.ReadLine()) != "quit")
            //{
            //    if (client.Connected)
            //        AsynSend(client, str);
            //}

            //Console.ReadLine();
        }



       public void SendDate(string str)
        {
            AsynSend(client,str);
        }

        /// <summary>  
        /// 发送消息  
        /// </summary>  
        /// <param name="socket"></param>  
        /// <param name="message"></param>  
        static void AsynSend(Socket socket, string message)
        {
            //socket = client;
            if (socket == null || message == string.Empty)return;
             
            //编码  
            byte[] data = Encoding.UTF8.GetBytes(message);

            try
            {
                socket.BeginSend(data, 0, data.Length, SocketFlags.None, asyncResult =>
                {
                //完成发送消息  
                int length = socket.EndSend(asyncResult);
                //Console.WriteLine(string.Format("客户端发送消息:{0}", message));
            }, null);
            }
            catch (Exception ex)
            {
                
                    LoginCtr.Instance.TishiShow("无法连接服务器");
                
                Debug.Log(String.Format("异常信息：{0}", ex.Message));
            }
        }

        /// <summary>  
        /// 接收消息  
        /// </summary>  
        /// <param name="socket"></param>  
        static void AsynRecive(Socket socket)
        {
            byte[] data = new byte[1024];
            try
            {
                //开始接收数据  
                socket.BeginReceive(data, 0, data.Length, SocketFlags.None, asyncResult =>
                {
                    int length = socket.EndReceive(asyncResult);

                    Debug.Log(string.Format("收到服务器消息:{0}", Encoding.UTF8.GetString(data)));
                    AsynRecive(socket);
                }, null);
            }
            catch (Exception ex)
            {
                Debug.Log(string.Format("异常信息：{0}", ex.Message));
            }
        }

        //void LWSockt()
        //{
        //    int port = 5099;
        //    string host = "192.168.0.75";//服务器端ip地址

        //    IPAddress ip = IPAddress.Parse(host);
        //    IPEndPoint ipe = new IPEndPoint(ip, port);

        //    Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //    clientSocket.Connect(ipe);

        //    //send message
        //    string sendStr = "send to server : hello,ni hao";
        //    byte[] sendBytes = Encoding.ASCII.GetBytes(sendStr);
        //    clientSocket.Send(sendBytes);

        //    //receive message
        //    string recStr = "";
        //    byte[] recBytes = new byte[4096];
        //    int bytes = clientSocket.Receive(recBytes, recBytes.Length, 0);
        //    recStr += Encoding.ASCII.GetString(recBytes, 0, bytes);
        //    Debug.Log(recStr);

        //    clientSocket.Close();
        //}

    }
}
