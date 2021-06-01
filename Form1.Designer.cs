namespace WindowsFormsApplication_TCPSOCKET
{
    partial class Form_socket
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.TCP_Server = new System.Windows.Forms.TabPage();
            this.button_ServerClear = new System.Windows.Forms.Button();
            this.textBox_ServerMessage = new System.Windows.Forms.TextBox();
            this.textBox_ServerSendData = new System.Windows.Forms.TextBox();
            this.textBox_Server = new System.Windows.Forms.TextBox();
            this.textBox_LocalPort = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button_ServerSend = new System.Windows.Forms.Button();
            this.button_Listen = new System.Windows.Forms.Button();
            this.comboBox_LocalIP = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TCP_Client = new System.Windows.Forms.TabPage();
            this.button_ClinetClear = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_ClientMessage = new System.Windows.Forms.TextBox();
            this.textBox_ClientSendData = new System.Windows.Forms.TextBox();
            this.textBox_Client = new System.Windows.Forms.TextBox();
            this.textBox_RemotePort = new System.Windows.Forms.TextBox();
            this.textBox_RemoteIP = new System.Windows.Forms.TextBox();
            this.button_ClinetSend = new System.Windows.Forms.Button();
            this.button_Connect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TabControl_socke = new System.Windows.Forms.TabControl();
            this.UDP_Tab = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox_UDPLocalIP = new System.Windows.Forms.ComboBox();
            this.textBox_UDPLocalPort = new System.Windows.Forms.TextBox();
            this.textBox_UDPRemoteIP = new System.Windows.Forms.TextBox();
            this.textBox_UDPRemotePort = new System.Windows.Forms.TextBox();
            this.textBox_UDP = new System.Windows.Forms.TextBox();
            this.button_UDPClear = new System.Windows.Forms.Button();
            this.button_UDPConnect = new System.Windows.Forms.Button();
            this.button_UDPSend = new System.Windows.Forms.Button();
            this.textBox_UDPSendData = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_UDPMessage = new System.Windows.Forms.TextBox();
            this.TCP_Server.SuspendLayout();
            this.TCP_Client.SuspendLayout();
            this.TabControl_socke.SuspendLayout();
            this.UDP_Tab.SuspendLayout();
            this.SuspendLayout();
            // 
            // TCP_Server
            // 
            this.TCP_Server.Controls.Add(this.button_ServerClear);
            this.TCP_Server.Controls.Add(this.textBox_ServerMessage);
            this.TCP_Server.Controls.Add(this.textBox_ServerSendData);
            this.TCP_Server.Controls.Add(this.textBox_Server);
            this.TCP_Server.Controls.Add(this.textBox_LocalPort);
            this.TCP_Server.Controls.Add(this.label6);
            this.TCP_Server.Controls.Add(this.button_ServerSend);
            this.TCP_Server.Controls.Add(this.button_Listen);
            this.TCP_Server.Controls.Add(this.comboBox_LocalIP);
            this.TCP_Server.Controls.Add(this.label4);
            this.TCP_Server.Controls.Add(this.label3);
            this.TCP_Server.Location = new System.Drawing.Point(4, 22);
            this.TCP_Server.Name = "TCP_Server";
            this.TCP_Server.Padding = new System.Windows.Forms.Padding(3);
            this.TCP_Server.Size = new System.Drawing.Size(604, 254);
            this.TCP_Server.TabIndex = 1;
            this.TCP_Server.Text = "TCP Server";
            this.TCP_Server.UseVisualStyleBackColor = true;
            // 
            // button_ServerClear
            // 
            this.button_ServerClear.Location = new System.Drawing.Point(112, 157);
            this.button_ServerClear.Name = "button_ServerClear";
            this.button_ServerClear.Size = new System.Drawing.Size(75, 23);
            this.button_ServerClear.TabIndex = 10;
            this.button_ServerClear.Text = "clear";
            this.button_ServerClear.UseVisualStyleBackColor = true;
            this.button_ServerClear.Click += new System.EventHandler(this.button_TCPServerClear_Click);
            // 
            // textBox_ServerMessage
            // 
            this.textBox_ServerMessage.Location = new System.Drawing.Point(193, 230);
            this.textBox_ServerMessage.Name = "textBox_ServerMessage";
            this.textBox_ServerMessage.ReadOnly = true;
            this.textBox_ServerMessage.Size = new System.Drawing.Size(405, 21);
            this.textBox_ServerMessage.TabIndex = 9;
            // 
            // textBox_ServerSendData
            // 
            this.textBox_ServerSendData.Location = new System.Drawing.Point(193, 183);
            this.textBox_ServerSendData.Multiline = true;
            this.textBox_ServerSendData.Name = "textBox_ServerSendData";
            this.textBox_ServerSendData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_ServerSendData.Size = new System.Drawing.Size(405, 44);
            this.textBox_ServerSendData.TabIndex = 7;
            // 
            // textBox_Server
            // 
            this.textBox_Server.Location = new System.Drawing.Point(193, 4);
            this.textBox_Server.Multiline = true;
            this.textBox_Server.Name = "textBox_Server";
            this.textBox_Server.ReadOnly = true;
            this.textBox_Server.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Server.Size = new System.Drawing.Size(405, 175);
            this.textBox_Server.TabIndex = 5;
            // 
            // textBox_LocalPort
            // 
            this.textBox_LocalPort.Location = new System.Drawing.Point(66, 32);
            this.textBox_LocalPort.Name = "textBox_LocalPort";
            this.textBox_LocalPort.Size = new System.Drawing.Size(100, 21);
            this.textBox_LocalPort.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(132, 235);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "message：";
            // 
            // button_ServerSend
            // 
            this.button_ServerSend.Location = new System.Drawing.Point(112, 194);
            this.button_ServerSend.Name = "button_ServerSend";
            this.button_ServerSend.Size = new System.Drawing.Size(75, 23);
            this.button_ServerSend.TabIndex = 6;
            this.button_ServerSend.Text = "send";
            this.button_ServerSend.UseVisualStyleBackColor = true;
            this.button_ServerSend.Click += new System.EventHandler(this.button_TCPServerSend_Click);
            // 
            // button_Listen
            // 
            this.button_Listen.Location = new System.Drawing.Point(11, 194);
            this.button_Listen.Name = "button_Listen";
            this.button_Listen.Size = new System.Drawing.Size(75, 23);
            this.button_Listen.TabIndex = 4;
            this.button_Listen.Text = "listen";
            this.button_Listen.UseVisualStyleBackColor = true;
            this.button_Listen.Click += new System.EventHandler(this.button_listen_Click);
            // 
            // comboBox_LocalIP
            // 
            this.comboBox_LocalIP.FormattingEnabled = true;
            this.comboBox_LocalIP.Location = new System.Drawing.Point(66, 4);
            this.comboBox_LocalIP.Name = "comboBox_LocalIP";
            this.comboBox_LocalIP.Size = new System.Drawing.Size(120, 20);
            this.comboBox_LocalIP.TabIndex = 2;
            this.comboBox_LocalIP.Click += new System.EventHandler(this.comboBox_LocalIP_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "端口号：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "本地IP：";
            // 
            // TCP_Client
            // 
            this.TCP_Client.Controls.Add(this.button_ClinetClear);
            this.TCP_Client.Controls.Add(this.label5);
            this.TCP_Client.Controls.Add(this.textBox_ClientMessage);
            this.TCP_Client.Controls.Add(this.textBox_ClientSendData);
            this.TCP_Client.Controls.Add(this.textBox_Client);
            this.TCP_Client.Controls.Add(this.textBox_RemotePort);
            this.TCP_Client.Controls.Add(this.textBox_RemoteIP);
            this.TCP_Client.Controls.Add(this.button_ClinetSend);
            this.TCP_Client.Controls.Add(this.button_Connect);
            this.TCP_Client.Controls.Add(this.label2);
            this.TCP_Client.Controls.Add(this.label1);
            this.TCP_Client.Location = new System.Drawing.Point(4, 22);
            this.TCP_Client.Name = "TCP_Client";
            this.TCP_Client.Padding = new System.Windows.Forms.Padding(3);
            this.TCP_Client.Size = new System.Drawing.Size(604, 254);
            this.TCP_Client.TabIndex = 0;
            this.TCP_Client.Text = "TCP Client";
            this.TCP_Client.UseVisualStyleBackColor = true;
            // 
            // button_ClinetClear
            // 
            this.button_ClinetClear.Location = new System.Drawing.Point(112, 157);
            this.button_ClinetClear.Name = "button_ClinetClear";
            this.button_ClinetClear.Size = new System.Drawing.Size(75, 23);
            this.button_ClinetClear.TabIndex = 10;
            this.button_ClinetClear.Text = "clear";
            this.button_ClinetClear.UseVisualStyleBackColor = true;
            this.button_ClinetClear.Click += new System.EventHandler(this.button_TCPClientClear_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(132, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "message：";
            // 
            // textBox_ClientMessage
            // 
            this.textBox_ClientMessage.Location = new System.Drawing.Point(193, 230);
            this.textBox_ClientMessage.Name = "textBox_ClientMessage";
            this.textBox_ClientMessage.ReadOnly = true;
            this.textBox_ClientMessage.Size = new System.Drawing.Size(405, 21);
            this.textBox_ClientMessage.TabIndex = 8;
            // 
            // textBox_ClientSendData
            // 
            this.textBox_ClientSendData.Location = new System.Drawing.Point(193, 183);
            this.textBox_ClientSendData.Multiline = true;
            this.textBox_ClientSendData.Name = "textBox_ClientSendData";
            this.textBox_ClientSendData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_ClientSendData.Size = new System.Drawing.Size(405, 44);
            this.textBox_ClientSendData.TabIndex = 7;
            // 
            // textBox_Client
            // 
            this.textBox_Client.Location = new System.Drawing.Point(193, 4);
            this.textBox_Client.Multiline = true;
            this.textBox_Client.Name = "textBox_Client";
            this.textBox_Client.ReadOnly = true;
            this.textBox_Client.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Client.Size = new System.Drawing.Size(405, 175);
            this.textBox_Client.TabIndex = 5;
            // 
            // textBox_RemotePort
            // 
            this.textBox_RemotePort.Location = new System.Drawing.Point(66, 32);
            this.textBox_RemotePort.Name = "textBox_RemotePort";
            this.textBox_RemotePort.Size = new System.Drawing.Size(100, 21);
            this.textBox_RemotePort.TabIndex = 3;
            // 
            // textBox_RemoteIP
            // 
            this.textBox_RemoteIP.Location = new System.Drawing.Point(66, 4);
            this.textBox_RemoteIP.Name = "textBox_RemoteIP";
            this.textBox_RemoteIP.Size = new System.Drawing.Size(100, 21);
            this.textBox_RemoteIP.TabIndex = 2;
            // 
            // button_ClinetSend
            // 
            this.button_ClinetSend.Location = new System.Drawing.Point(112, 194);
            this.button_ClinetSend.Name = "button_ClinetSend";
            this.button_ClinetSend.Size = new System.Drawing.Size(75, 23);
            this.button_ClinetSend.TabIndex = 6;
            this.button_ClinetSend.Text = "send";
            this.button_ClinetSend.UseVisualStyleBackColor = true;
            this.button_ClinetSend.Click += new System.EventHandler(this.button_TCPClientSend_Click);
            // 
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(11, 194);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(75, 23);
            this.button_Connect.TabIndex = 4;
            this.button_Connect.Text = "connect";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "端口号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "目标IP：";
            // 
            // TabControl_socke
            // 
            this.TabControl_socke.Controls.Add(this.TCP_Client);
            this.TabControl_socke.Controls.Add(this.TCP_Server);
            this.TabControl_socke.Controls.Add(this.UDP_Tab);
            this.TabControl_socke.Location = new System.Drawing.Point(13, 13);
            this.TabControl_socke.Name = "TabControl_socke";
            this.TabControl_socke.SelectedIndex = 0;
            this.TabControl_socke.Size = new System.Drawing.Size(612, 280);
            this.TabControl_socke.TabIndex = 0;
            // 
            // UDP_Tab
            // 
            this.UDP_Tab.Controls.Add(this.textBox_UDPMessage);
            this.UDP_Tab.Controls.Add(this.label11);
            this.UDP_Tab.Controls.Add(this.textBox_UDPSendData);
            this.UDP_Tab.Controls.Add(this.button_UDPSend);
            this.UDP_Tab.Controls.Add(this.button_UDPConnect);
            this.UDP_Tab.Controls.Add(this.button_UDPClear);
            this.UDP_Tab.Controls.Add(this.textBox_UDP);
            this.UDP_Tab.Controls.Add(this.textBox_UDPRemotePort);
            this.UDP_Tab.Controls.Add(this.textBox_UDPRemoteIP);
            this.UDP_Tab.Controls.Add(this.textBox_UDPLocalPort);
            this.UDP_Tab.Controls.Add(this.comboBox_UDPLocalIP);
            this.UDP_Tab.Controls.Add(this.label10);
            this.UDP_Tab.Controls.Add(this.label9);
            this.UDP_Tab.Controls.Add(this.label8);
            this.UDP_Tab.Controls.Add(this.label7);
            this.UDP_Tab.Location = new System.Drawing.Point(4, 22);
            this.UDP_Tab.Name = "UDP_Tab";
            this.UDP_Tab.Padding = new System.Windows.Forms.Padding(3);
            this.UDP_Tab.Size = new System.Drawing.Size(604, 254);
            this.UDP_Tab.TabIndex = 2;
            this.UDP_Tab.Text = "UDP";
            this.UDP_Tab.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "本地IP：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "本地端口号：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 3;
            this.label9.Text = "目标IP：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 4;
            this.label10.Text = "目标端口号：";
            // 
            // comboBox_UDPLocalIP
            // 
            this.comboBox_UDPLocalIP.FormattingEnabled = true;
            this.comboBox_UDPLocalIP.Location = new System.Drawing.Point(66, 4);
            this.comboBox_UDPLocalIP.Name = "comboBox_UDPLocalIP";
            this.comboBox_UDPLocalIP.Size = new System.Drawing.Size(120, 20);
            this.comboBox_UDPLocalIP.TabIndex = 5;
            this.comboBox_UDPLocalIP.Click += new System.EventHandler(this.comboBox_UDPLocalIP_Click);
            // 
            // textBox_UDPLocalPort
            // 
            this.textBox_UDPLocalPort.Location = new System.Drawing.Point(86, 32);
            this.textBox_UDPLocalPort.Name = "textBox_UDPLocalPort";
            this.textBox_UDPLocalPort.Size = new System.Drawing.Size(100, 21);
            this.textBox_UDPLocalPort.TabIndex = 6;
            this.textBox_UDPLocalPort.Text = "10000";
            // 
            // textBox_UDPRemoteIP
            // 
            this.textBox_UDPRemoteIP.Location = new System.Drawing.Point(86, 61);
            this.textBox_UDPRemoteIP.Name = "textBox_UDPRemoteIP";
            this.textBox_UDPRemoteIP.Size = new System.Drawing.Size(100, 21);
            this.textBox_UDPRemoteIP.TabIndex = 7;
            // 
            // textBox_UDPRemotePort
            // 
            this.textBox_UDPRemotePort.Location = new System.Drawing.Point(86, 90);
            this.textBox_UDPRemotePort.Name = "textBox_UDPRemotePort";
            this.textBox_UDPRemotePort.Size = new System.Drawing.Size(100, 21);
            this.textBox_UDPRemotePort.TabIndex = 8;
            // 
            // textBox_UDP
            // 
            this.textBox_UDP.Location = new System.Drawing.Point(193, 4);
            this.textBox_UDP.Multiline = true;
            this.textBox_UDP.Name = "textBox_UDP";
            this.textBox_UDP.ReadOnly = true;
            this.textBox_UDP.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_UDP.Size = new System.Drawing.Size(405, 175);
            this.textBox_UDP.TabIndex = 9;
            // 
            // button_UDPClear
            // 
            this.button_UDPClear.Location = new System.Drawing.Point(112, 157);
            this.button_UDPClear.Name = "button_UDPClear";
            this.button_UDPClear.Size = new System.Drawing.Size(75, 23);
            this.button_UDPClear.TabIndex = 11;
            this.button_UDPClear.Text = "clear";
            this.button_UDPClear.UseVisualStyleBackColor = true;
            this.button_UDPClear.Click += new System.EventHandler(this.button_UDPClear_Click);
            // 
            // button_UDPConnect
            // 
            this.button_UDPConnect.Location = new System.Drawing.Point(11, 194);
            this.button_UDPConnect.Name = "button_UDPConnect";
            this.button_UDPConnect.Size = new System.Drawing.Size(75, 23);
            this.button_UDPConnect.TabIndex = 12;
            this.button_UDPConnect.Text = "connect";
            this.button_UDPConnect.UseVisualStyleBackColor = true;
            this.button_UDPConnect.Click += new System.EventHandler(this.button_UDPconnect_Click);
            // 
            // button_UDPSend
            // 
            this.button_UDPSend.Location = new System.Drawing.Point(112, 194);
            this.button_UDPSend.Name = "button_UDPSend";
            this.button_UDPSend.Size = new System.Drawing.Size(75, 23);
            this.button_UDPSend.TabIndex = 13;
            this.button_UDPSend.Text = "send";
            this.button_UDPSend.UseVisualStyleBackColor = true;
            this.button_UDPSend.Click += new System.EventHandler(this.button_UDPSend_Click);
            // 
            // textBox_UDPSendData
            // 
            this.textBox_UDPSendData.Location = new System.Drawing.Point(193, 183);
            this.textBox_UDPSendData.Multiline = true;
            this.textBox_UDPSendData.Name = "textBox_UDPSendData";
            this.textBox_UDPSendData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_UDPSendData.Size = new System.Drawing.Size(405, 44);
            this.textBox_UDPSendData.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(132, 235);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 12);
            this.label11.TabIndex = 15;
            this.label11.Text = "message：";
            // 
            // textBox_UDPMessage
            // 
            this.textBox_UDPMessage.Location = new System.Drawing.Point(193, 230);
            this.textBox_UDPMessage.Name = "textBox_UDPMessage";
            this.textBox_UDPMessage.ReadOnly = true;
            this.textBox_UDPMessage.Size = new System.Drawing.Size(405, 21);
            this.textBox_UDPMessage.TabIndex = 16;
            // 
            // Form_socket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 305);
            this.Controls.Add(this.TabControl_socke);
            this.Name = "Form_socket";
            this.Text = "Form socket";
            this.TCP_Server.ResumeLayout(false);
            this.TCP_Server.PerformLayout();
            this.TCP_Client.ResumeLayout(false);
            this.TCP_Client.PerformLayout();
            this.TabControl_socke.ResumeLayout(false);
            this.UDP_Tab.ResumeLayout(false);
            this.UDP_Tab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage TCP_Server;
        private System.Windows.Forms.TextBox textBox_ServerMessage;
        private System.Windows.Forms.TextBox textBox_ServerSendData;
        private System.Windows.Forms.TextBox textBox_Server;
        private System.Windows.Forms.TextBox textBox_LocalPort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_ServerSend;
        private System.Windows.Forms.Button button_Listen;
        private System.Windows.Forms.ComboBox comboBox_LocalIP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage TCP_Client;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_ClientMessage;
        private System.Windows.Forms.TextBox textBox_ClientSendData;
        private System.Windows.Forms.TextBox textBox_Client;
        private System.Windows.Forms.TextBox textBox_RemotePort;
        private System.Windows.Forms.TextBox textBox_RemoteIP;
        private System.Windows.Forms.Button button_ClinetSend;
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl TabControl_socke;
        private System.Windows.Forms.Button button_ClinetClear;
        private System.Windows.Forms.Button button_ServerClear;
        private System.Windows.Forms.TabPage UDP_Tab;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_UDPLocalPort;
        private System.Windows.Forms.ComboBox comboBox_UDPLocalIP;
        private System.Windows.Forms.TextBox textBox_UDPRemoteIP;
        private System.Windows.Forms.TextBox textBox_UDPRemotePort;
        private System.Windows.Forms.TextBox textBox_UDP;
        private System.Windows.Forms.Button button_UDPClear;
        private System.Windows.Forms.Button button_UDPConnect;
        private System.Windows.Forms.Button button_UDPSend;
        private System.Windows.Forms.TextBox textBox_UDPSendData;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox_UDPMessage;
    }
}

