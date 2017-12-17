using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkUDPReceive
{
    public partial class Form1 : Form
    {
        private const int BufferSize = 1024;
        public string Status = string.Empty;
        public Thread T = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Server is Running...";
            ThreadStart Ts = new ThreadStart(StartReceiving);
            T = new Thread(Ts);
            T.Start();


        }
        public void StartReceiving()
        {
            ReceiveTCP(29250);
        }


        public void ReceiveTCP(int portN)
        {
            UdpClient udpClient = new UdpClient(8080);
            while (true)
            {
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
                string returnData = Encoding.ASCII.GetString(receiveBytes);
            }
          
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            T.Abort();
            this.Close();
        }


    }
}