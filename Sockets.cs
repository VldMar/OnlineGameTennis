using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.IO;
//"178.45.251.29"
namespace Game_version_1
{
   public class SocketManagment
    {
        //создаем адрес и порт сервера, к которому будем подключаться
        private int port;//порт
        private string adress;//адрес ip
        private TcpListener _tcpList;
        private TcpClient _client;
        private NetworkStream _stream;

        public SocketManagment(String ip, int _port)
        {
            adress = ip;
            port = _port;
        }

        public bool StartAsServer()
        {
            /*  IPEndPoint ip_end = new IPEndPoint(IPAddress.Parse(adress), port);

              Socket listenSocket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,  ProtocolType.Tcp);


              try
              {
                  listenSocket.Bind(ip_end);
                  listenSocket.Listen(10);
                  MessageBox.Show("Сервер запущен... ");

                 while(true)
                  {
                      MessageBox.Show("Ожидаем подключение через порт 11000 ...");

                      Socket handler = listenSocket.Accept();

                      string ball_data = null;
                      string racket1_data = null;
                      string racket2_data = null;

                      byte[] bytes = new byte[1024];
                      int bytesRec = handler.Receive(bytes);



                     // handler.Shutdown(SocketShutdown.Both);

                      //handler.Close();
                  }*/
            try
            { 
                _tcpList = new TcpListener(IPAddress.Parse(adress),port);
                _tcpList.Start();
                MessageBox.Show("waiting for connection");
                _client = _tcpList.AcceptTcpClient();
                MessageBox.Show("connected");
                _stream = _client.GetStream();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            /*listenSocket.Shutdown(SocketShutdown.Both);
            listenSocket.Close();*/
            return true;
        }


        public bool StartAsClient()
        {
            /* try
             {
                 IPEndPoint ip_end_client = new IPEndPoint(IPAddress.Parse(adress), port);

                 Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                 sock.Connect(ip_end_client);


                 sock.Shutdown(SocketShutdown.Both);
                 sock.Close();*/
            try
            { 
               _client = new TcpClient();
                _client.Connect(IPAddress.Parse(adress),port);
                _stream = _client.GetStream();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return true;
        }

        public void sendData(string dataBall, string dataRacket1, string dataRacket2)
        {
            try
            {
                byte[] bytes = new byte[255];
              //  byte[] bytes1 = new byte[255];
               // byte[] bytes2 = new byte[255];
                bytes = new ASCIIEncoding().GetBytes(dataBall);
               // bytes1 = new ASCIIEncoding().GetBytes(dataRacket1);
               // bytes2 = new ASCIIEncoding().GetBytes(dataRacket2);

                _stream.Write(bytes,0,bytes.Length);
              //  _stream.Write(bytes1, 0, bytes1.Length);
              //  _stream.Write(bytes2, 0, bytes2.Length);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void getData()
        {

        }

    }
}
