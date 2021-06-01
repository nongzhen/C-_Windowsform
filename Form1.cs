using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace WindowsFormsApplication_TCPSOCKET
{    
    public partial class Form_socket : Form
    {
        /// <summary>
        /// socket标号
        /// </summary>
        Socket Client_Socket, Server_Socket, Server_ConnectSocket, UDP_Socket;
        /// <summary>
        /// 监听状态
        /// </summary>
        bool isServerListen = false;
        /// <summary>
        /// 监听按键状态
        /// </summary>
        bool ServerListenClick = false;
        /// /// <summary>
        /// 连接状态
        /// </summary>
        bool isClientConnect = false;
        /// /// <summary>
        /// 连接按键状态
        /// </summary>
        bool ClientConnectClick = false;
        /// /// <summary>
        /// UDP连接状态
        /// </summary>
        bool isUDPConnect = false;       
        /// /// <summary>
        /// UDP本地及目标IP-Port
        /// </summary>
        IPEndPoint UDPLocal_IPEndPoint, UDPRemote_IPEndPoint;
        public Form_socket()
        {
            InitializeComponent();
        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            if (ClientConnectClick == false)//未连接
            {
                isClientConnect = true;
                ClientConnectClick = true;
                StartTCPClent(); 
                textBox_RemoteIP.Enabled = false;
                textBox_RemotePort.Enabled = false;
                button_Connect.Text = "disconnect";
            }
            else//已连接
            {
                isClientConnect = false;
                ClientConnectClick = false;
                StopTCPClent();
                textBox_RemoteIP.Enabled = true;
                textBox_RemotePort.Enabled = true; 
                button_Connect.Text = "connect";
                textBox_ClientMessage.Text = "已关闭连接";
            }            
        }

        private void StartTCPClent()
        {
            string Remote_IP = textBox_RemoteIP.Text.Trim();
            string Remote_Port = textBox_RemotePort.Text.Trim();
            //检查IP及端口号
            var check_ip_port = Internet_Method.Check_IPEndPort(Remote_IP, Remote_Port);
            textBox_ClientMessage.Text = check_ip_port.message;
            if (check_ip_port.result)
            {
                IPEndPoint Remote_IPEndPoint = new IPEndPoint(IPAddress.Parse(Remote_IP), ushort.Parse(Remote_Port));
                Client_Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Thread Thread_ClientConnect = new Thread(new ParameterizedThreadStart(Client_Connectwait));//连接线程
                Thread_ClientConnect.IsBackground = true;
                Thread_ClientConnect.Start(Remote_IPEndPoint);//添加传递参数
                Thread.Sleep(100);
                for (int i = 0; i < 2000; i++)//连接等待时间2.5s
                {
                    if (Client_Socket.Connected == true)
                    {
                        break;
                    }
                }
                if (Client_Socket.Connected == false)
                {
                    Client_Socket.Close();
                }  
            }
        }

        private void Client_Connectwait(object Parameter)
        {
            IPEndPoint Remote_IPEndPoint = (IPEndPoint)Parameter;//传递参数
            try
            {
                Internet_Method.CommandResult connect_res = Internet_Method.Client_Connect(Client_Socket, Remote_IPEndPoint);
                this.Invoke(new Action(() => {  textBox_ClientMessage.Text = connect_res.message;   }));
                if (connect_res.result)
                {
                    Thread Thread_ClientReceive = new Thread(new ParameterizedThreadStart(Client_Receive));
                    Thread_ClientReceive.IsBackground = true;
                    Thread_ClientReceive.Start(Client_Socket);//添加传递参数，实际未用
                    while (true)
                    {
                        try
                        {
                            if (Client_Socket.Poll(-1, SelectMode.SelectRead))//检测连接状态
                            {
                                byte[] recvBytes = new byte[2048];
                                int recvCount = Client_Socket.Receive(recvBytes, recvBytes.Length, 0); //从客户端接受消息 
                                if (recvCount == 0)
                                {
                                    this.Invoke(new Action(() => {   textBox_ClientMessage.Text = "连接断开";    }));
                                    isClientConnect = false;//关接收线程
                                    break;//连接断开后，终止线程      
                                }
                            }
                        }
                        catch
                        {
                            isClientConnect = false;//关接收线程
                            break;//终止线程,连接后主动关闭错误触发地
                        }

                    }
                }
                
            }
            catch (Exception ex)
            {
                this.Invoke(new Action(() => {  textBox_ClientMessage.Text = "连接等待错误:" + ex.Message;    })); 
            }
            
        }

        private void StopTCPClent()
        {
            if (Client_Socket != null)
            {
                Client_Socket.Close();
                Client_Socket = null;
            }  
        }

        private void Client_Receive(object Parameter)
        {
            Internet_Method.CommandResult res;
            while (true)
            {
                if (isClientConnect == true)
                {
                    res = Internet_Method.ReceiveMessage(Client_Socket);
                    if (res.result == true)
                    {
                        this.Invoke(new Action(() =>
                        {
                            //textBox_Client.Text += res.message;
                            textBox_Client.AppendText(res.message);
                            if (textBox_Client.Text.Length >= 100 * 1024 * 1024)//大于100M,清显示缓存
                            {
                                textBox_Client.Text = "";
                                textBox_Client.Text = res.message;
                            }
                            //textBox_Client.SelectionStart = textBox_Client.Text.Length;
                            //textBox_Client.ScrollToCaret();
                        }));
                    }                    
                }
                else
                {
                    //Thread.Sleep(100);
                    break;//终止线程
                }     
            }           
        }

        private void button_TCPClientSend_Click(object sender, EventArgs e)
        {
            textBox_ClientMessage.Text = "";
            Internet_Method.CommandResult connect_res = Internet_Method.SendMessage(Client_Socket, textBox_ClientSendData.Text);
            textBox_ClientMessage.Text = connect_res.message;           
        }

        private void button_listen_Click(object sender, EventArgs e)
        {
            if (ServerListenClick == false)//未连接
            {
                isServerListen = true;
                ServerListenClick = true;
                StartTCPServer();
                comboBox_LocalIP.Enabled = false;
                textBox_LocalPort.Enabled = false; 
                button_Listen.Text = "disconnect";
            }
            else//已连接
            {
                isServerListen = false;
                ServerListenClick = false;
                StopTCPServer();
                comboBox_LocalIP.Enabled = true;
                textBox_LocalPort.Enabled = true;          
                button_Listen.Text = "listen";
                textBox_ServerMessage.Text = "已关闭监听";
            }
        }

        private void StartTCPServer()
        {            
            string Local_IP = comboBox_LocalIP.Text.Trim();
            string Local_Port = textBox_LocalPort.Text.Trim();
            //检查IP及端口号
            var check_ip_port = Internet_Method.Check_IPEndPort(Local_IP, Local_Port);
            textBox_ServerMessage.Text = check_ip_port.message;
            if (check_ip_port.result)
            {
                try
                {
                    IPEndPoint Local_IPEndPoint = new IPEndPoint(IPAddress.Parse(Local_IP), ushort.Parse(Local_Port));
                    Server_Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    Server_Socket.Bind(Local_IPEndPoint);
                    Server_Socket.Listen(100);
                    Thread Thread_ServerListenAccept = new Thread(new ParameterizedThreadStart(Server_ListenAccept));//监听线程
                    Thread_ServerListenAccept.IsBackground = true;
                    Thread_ServerListenAccept.Start(Server_Socket);//添加传递参数，实际未用
                }
                catch (Exception ex)
                {
                    textBox_ServerMessage.Text = "监听错误:"+ ex.Message;
                }
                
            }
        }

        private void Server_ListenAccept(object Parameter)
        {
            Internet_Method.CommandResult connect_res;
            Server_ConnectSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            connect_res = Internet_Method.Server_Accept(Server_Socket);
            this.Invoke(new Action(() => {  textBox_ServerMessage.Text = connect_res.message;   }));
            if (connect_res.result)
            {    
                Server_ConnectSocket = (Socket)connect_res.data;
                Thread Thread_ServerReceive = new Thread(new ParameterizedThreadStart(Server_Receive));
                Thread_ServerReceive.IsBackground = true;
                Thread_ServerReceive.Start(Server_ConnectSocket);//添加传递参数，实际未用
                while (true)
                {
                    try
                    {
                        if (Server_ConnectSocket.Poll(-1, SelectMode.SelectRead))//检测连接状态
                        {
                            byte[] recvBytes = new byte[2048];
                            int recvCount = Server_ConnectSocket.Receive(recvBytes, recvBytes.Length, 0); //从客户端接受消息 
                            if (recvCount == 0)
                            {
                                this.Invoke(new Action(() => {  textBox_ServerMessage.Text = "连接断开";    }));
                                isServerListen = false;//关接收线程
                                if (ServerListenClick == true)
                                {
                                    connect_res = Internet_Method.Server_Accept(Server_Socket);
                                    if (connect_res.result)
                                    {
                                        isServerListen = true;//接收线程可循环
                                        Server_ConnectSocket = (Socket)connect_res.data;
                                        Thread_ServerReceive = new Thread(new ParameterizedThreadStart(Server_Receive));//重新开接收线程
                                        Thread_ServerReceive.IsBackground = true;
                                        Thread_ServerReceive.Start(Server_ConnectSocket);//添加传递参数，实际未用
                                        this.Invoke(new Action(() => {  textBox_ServerMessage.Text = "重新连接成功";  }));
                                    }
                                }
                                else//一般不会运行到此处
                                {
                                    break;//连接断开后未在Listen状态，终止线程
                                }
                            }
                        }
                    }
                    catch
                    {
                        isServerListen = false;//关接收线程
                        break;//终止线程,连接后及断开连接后，主动关闭监听错误触发地
                    }

                }
            }
                       
        }

        private void button_TCPServerSend_Click(object sender, EventArgs e)
        {
            textBox_ServerMessage.Text = "";
            Internet_Method.CommandResult connect_res = Internet_Method.SendMessage(Server_ConnectSocket, textBox_ServerSendData.Text);
            textBox_ServerMessage.Text = connect_res.message;
        }

        private void comboBox_LocalIP_Click(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                try
                {
                    comboBox_LocalIP.Items.Clear();
                    IPHostEntry Host_IP = Dns.GetHostEntry(Dns.GetHostName());
                    foreach (IPAddress ip in Host_IP.AddressList)
                    {
                        if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {// InterNetwork 筛选IPV4
                            comboBox_LocalIP.Items.Add(ip.ToString());
                        }
                    }
                    //comboBox_LocalIP.SelectedIndex = 0;//
                }
                catch (Exception ex)
                {
                    textBox_ServerMessage.Text = ex.Message;
                }
            }));
        }

        private void button_TCPClientClear_Click(object sender, EventArgs e)
        {
            textBox_Client.Text = "";
            textBox_ClientMessage.Text = "";
        }

        private void button_TCPServerClear_Click(object sender, EventArgs e)
        {
            textBox_Server.Text = "";
            textBox_ServerMessage.Text = "";
        }

        private void button_UDPconnect_Click(object sender, EventArgs e)
        {
            if (isUDPConnect == false)//未连接
            {
                isUDPConnect = true;
                StartUDP();
                comboBox_UDPLocalIP.Enabled = false;
                textBox_UDPLocalPort.Enabled = false;
                textBox_UDPRemoteIP.Enabled = false;
                textBox_UDPRemotePort.Enabled = false;                
                button_UDPConnect.Text = "disconnect";                
            }
            else//已连接
            {
                isUDPConnect = false;
                StopUDP();                
                comboBox_UDPLocalIP.Enabled = true;
                textBox_UDPLocalPort.Enabled = true;
                textBox_UDPRemoteIP.Enabled = true;
                textBox_UDPRemotePort.Enabled = true;               
                button_UDPConnect.Text = "connect";
                textBox_UDPMessage.Text = "已关闭连接";
            }
        }

        private void button_UDPClear_Click(object sender, EventArgs e)
        {
            textBox_UDP.Text = "";
            textBox_UDPMessage.Text = "";
        }

        private void button_UDPSend_Click(object sender, EventArgs e)
        {
            textBox_UDPMessage.Text = "";
            try
            {
                this.Invoke(new Action(() =>
                {
                    string msg = textBox_UDPSendData.Text;
                    if((msg == null) || (msg == ""))
                    {
                        textBox_UDPMessage.Text = "传送内容为空";
                        return;
                    }
                    if (UDP_Socket != null)
                    {
                        EndPoint point = UDPRemote_IPEndPoint;
                        UDP_Socket.SendTo(Encoding.UTF8.GetBytes(msg), point);
                        textBox_UDPMessage.Text = "传送成功";
                    }
                    else
                    {
                        textBox_UDPMessage.Text = "发送失败：Socket未连接";
                    }
                }));
            }
            catch (Exception ex)
            {
                textBox_UDPMessage.Text = "发送失败:" + ex.Message;
            }

        }

        private void comboBox_UDPLocalIP_Click(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                try
                {
                    comboBox_UDPLocalIP.Items.Clear();
                    IPHostEntry Host_IP = Dns.GetHostEntry(Dns.GetHostName());
                    foreach (IPAddress ip in Host_IP.AddressList)
                    {
                        if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {// InterNetwork 筛选IPV4
                            comboBox_UDPLocalIP.Items.Add(ip.ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    textBox_UDPMessage.Text = ex.Message;
                }
            }));
        }

        private void StopTCPServer()
        {
            if(Server_ConnectSocket != null)
            {
                Server_ConnectSocket.Close();
                Server_ConnectSocket = null;
                //Thread_ServerListenAccept.Abort();
            }
            if (Server_Socket != null)
            {
                Server_Socket.Close();
                Server_Socket = null;
            }
            
        }

        private void Server_Receive(object Parameter)
        {
            Internet_Method.CommandResult res;
            while (true)
            {
                if (isServerListen == true)
                {
                    res = Internet_Method.ReceiveMessage(Server_ConnectSocket);
                    if (res.result == true)
                    {
                        this.Invoke(new Action(() =>
                        {
                            //textBox_Server.Text += res.message;
                            textBox_Server.AppendText(res.message);
                            if (textBox_Server.Text.Length >= 100 * 1024 * 1024)//大于100M,清显示缓存
                            {
                                textBox_Server.Text = "";
                                textBox_Server.Text = res.message;
                            }
                            //textBox_Server.SelectionStart = textBox_Server.Text.Length;
                            //textBox_Server.ScrollToCaret();
                        }));
                    }

                }
                else
                {
                    //Thread.Sleep(100);
                    break;//终止线程
                }
            }

        }

        private void StartUDP()
        {
            string UDPRemote_IP = textBox_UDPRemoteIP.Text.Trim();
            string UDPRemote_Port = textBox_UDPRemotePort.Text.Trim();
            string UDPLocal_IP = comboBox_UDPLocalIP.Text.Trim();
            string UDPLocal_Port = textBox_UDPLocalPort.Text.Trim();
            //检查IP及端口号
            var check_local_ip_port = Internet_Method.Check_IPEndPort(UDPLocal_IP, UDPLocal_Port);
            textBox_UDPMessage.Text = ("本地:" + check_local_ip_port.message +" ");
            var check_remote_ip_port = Internet_Method.Check_IPEndPort(UDPRemote_IP, UDPRemote_Port);
            textBox_UDPMessage.Text += ("目标:" + check_remote_ip_port.message);
            if ((check_remote_ip_port.result) && (check_local_ip_port.result))
            {
                try
                {
                    UDPLocal_IPEndPoint = new IPEndPoint(IPAddress.Parse(UDPLocal_IP), ushort.Parse(UDPLocal_Port));
                    UDPRemote_IPEndPoint = new IPEndPoint(IPAddress.Parse(UDPRemote_IP), ushort.Parse(UDPRemote_Port));
                    UDP_Socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                    UDP_Socket.Bind(UDPLocal_IPEndPoint);
                    Thread Thread_UDPReceive = new Thread(new ParameterizedThreadStart(UDP_Receive));
                    Thread_UDPReceive.IsBackground = true;
                    Thread_UDPReceive.Start(UDP_Socket);//添加传递参数，实际未用
                    textBox_UDPMessage.Text = "UDP已启动";
                }
                catch (Exception ex)
                {
                    textBox_UDPMessage.Text = "连接失败:" + ex.Message;
                }
                
            }
            
        }

        private void StopUDP()
        {
            if (UDP_Socket != null)
            {
                UDP_Socket.Close();
                UDP_Socket = null;
                //Thread_UDPReceive.Abort();
            }
        }

        private void UDP_Receive(object Parameter)
        {
            while (true)
            {
                if (isUDPConnect == true)
                {
                    try
                    {
                        EndPoint point = new IPEndPoint(IPAddress.Any, 0);//用来保存发送方的ip和端口号
                        byte[] buffer = new byte[2048];
                        int length = UDP_Socket.ReceiveFrom(buffer, ref point);//接收数据报
                        string recvStr = Encoding.UTF8.GetString(buffer, 0, length);
                        if (!string.IsNullOrEmpty(recvStr.Trim()))
                        {
                            this.Invoke(new Action(() =>
                            {
                                textBox_UDP.AppendText(recvStr);
                                if (textBox_UDP.Text.Length >= 100 * 1024 * 1024)//大于100M,清显示缓存
                                {
                                    textBox_UDP.Text = "";
                                    textBox_UDP.Text = recvStr;
                                }
                            }));
                        } 
                    }
                    catch
                    {
                        ; //此处错误无需处理
                    }

                }
                else
                {
                    //Thread.Sleep(100);
                    break;//终止线程
                }
            }
        }
    }
}
