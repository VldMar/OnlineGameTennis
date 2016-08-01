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

namespace Game_version_1
{
    public partial class FormServer : Form
    {
        const int port = 8005;
        public const int bufferSize = 1024;
        TcpListener listener;
        static TcpClient client;
        NetworkStream stream;

        // Server s = new Server();

        public FormServer()
        {
            InitializeComponent();
                 
        }

        private void btnStartServ_Click(object sender, EventArgs e)
        {
            rtbServ.Text = "Server is started...  \n";
            Thread tcpStartservThread = new Thread(new ThreadStart(Startserv));
            tcpStartservThread.Start();
        }

        private void Startserv()
        {
            FormMenu fm = new FormMenu();
            fm.ShowDialog();
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            rtbServ.Text = "Waiting for connect..\n";
            try
            {
                while(true)
                {
                    client = listener.AcceptTcpClient();//принимаем новых клиентов
                    rtbServ.Text = "Сlient accept\n";
                    Thread tcpHadlerThread = new Thread(new ParameterizedThreadStart(Handler));
                    tcpHadlerThread.Start(client);
                   
                }
            }
            catch
            {
                stream.Close();
                client.Close();
            }

            

        }

        private void Handler(object client)
        {
            TcpClient myClient = (TcpClient)client;
            stream = myClient.GetStream();
        }
    }
}
