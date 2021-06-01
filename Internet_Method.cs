using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace WindowsFormsApplication_TCPSOCKET
{
    public class Internet_Method
    {
        /// <summary>
        /// 返回类型
        /// </summary>
        public class CommandResult
        {
            public bool result { get; set; }
            public string message { get; set; }
            public object data { get; set; }
        }
        /// <summary>
        /// 检查IP及端口号
        /// </summary>
        public static CommandResult Check_IPEndPort(string ip, string port)
        {
            CommandResult res = new CommandResult() { result = true, message = "" };
            IPAddress ip_tmp;
            ushort socket_tmp;
            if ((IPAddress.TryParse(ip, out ip_tmp)) && (ushort.TryParse(port, out socket_tmp))
                    && (socket_tmp >= 1))
            {
                res.result = true;
                res.message = "检查IP及端口号成功";             
            }
            else
            {
                res.result = false;
                if (string.IsNullOrEmpty(ip))
                    res.message = "IP地址必填"; 
                else if (! (IPAddress.TryParse(ip, out ip_tmp)))
                    res.message = "IP地址不合法";
                 
                if (string.IsNullOrEmpty(port))
                    res.message += "端口号必填"; 
                else if (!(ushort.TryParse(port, out socket_tmp)))
                    res.message += "端口号不合法";
            }
            return res;
        }
        
        /// <summary>
        /// 客户端连接
        /// </summary>
        public static CommandResult Client_Connect(Socket socket, IPEndPoint ip)
        {
            CommandResult res = new CommandResult();
            try
            {
                //socket.Blocking = true;//不可设置为非阻塞模式
                socket.Connect(ip);
                res.result = socket.Connected;
                res.message = "客户端连接成功";
            }
            catch (Exception ex)
            {
                res.result = false;
                res.message = "客户端连接失败:" + ex.Message;                   
                //MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //socket.Close();
                //throw;
            }
            return res;
        }
        
        /// <summary>
        /// 服务端监听至链接成功
        /// </summary>
        public static CommandResult Server_Accept(Socket socket)
        {            
                CommandResult res = new CommandResult();
                Socket Acceptsocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    Acceptsocket.Blocking = true;
                    Acceptsocket = socket.Accept();
                    res.result = Acceptsocket.Connected;
                    res.data = Acceptsocket;
                    res.message = "服务端连接成功";
                }
                catch (Exception ex)
                {
                    res.result = false;
                    res.message = "服务端连接失败:" + ex.Message;
                    //MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Acceptsocket.Close();
                    //throw;
                }
                return res;
        }
        
        /// <summary>
        /// 发送数据
        /// </summary>
        public static CommandResult SendMessage(Socket socket, string send_data)
        {
            Func<CommandResult> fun_sned = () => {
                CommandResult res = new CommandResult();
                try
                {
                    if ((socket != null) && (socket.Connected))//&& (socket.Connected) 
                    {
                        if (send_data != "")
                        {
                            byte[] bytearry = Encoding.UTF8.GetBytes(send_data);
                            socket.Send(bytearry, bytearry.Length, 0);
                            res.result = true;
                            res.message = "传送成功";
                        }
                        else
                        {
                            res.result = false;
                            res.message = "传送内容为空";
                        }
                    }
                    else
                    {
                        res.result = false;
                        res.message = "发送失败:Socket未连接";
                        //MessageBox.Show(res.message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    res.result = false;
                    res.message = "发送失败:" + ex.Message;
                    //MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //throw;
                }             
                return res;
            };
            return fun_sned.Invoke();
        }
        /// <summary>
        /// 接收数据
        /// </summary>
        public static CommandResult ReceiveMessage(Socket socket)
        {
            CommandResult res = new CommandResult() { result = false, message = "" };
            try
            {
                if ((socket != null) && (socket.Connected))//&& (socket.Connected)
                {
                    string recvStr = "";
                    byte[] recvBytes = new byte[2048];
                    int recvCount;
                    recvCount = socket.Receive(recvBytes, recvBytes.Length, 0); //从客户端接受消息
                    recvStr += Encoding.UTF8.GetString(recvBytes, 0, recvCount);
                    if (!string.IsNullOrEmpty(recvStr.Trim()))
                    {
                        res.result = true;
                        res.message = recvStr;
                    }
                }
                else
                {
                    res.result = false;
                    res.message = "接收错误:Socket未连接";// + socket.Connected.ToString();
                }
            }
            catch (Exception ex)
            {
                res.result = false;
                res.message = "接收错误:" + ex.Message;
                //throw;
            }
            return res;
        }

    }
}
