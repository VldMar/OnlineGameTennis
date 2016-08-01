using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Game_version_1
{
    class Clinentt
    {
        public static TcpClient client;// ну здесь все понятно
        public static NetworkStream stream;

        private int ReceiveNumb() // получаем значение: каким клиентом являюсь-> какой ракеткой буду играть, а сервак отправляет только 1 или 2
        {
            byte[] data = new byte[32];
            stream.Read(data, 0, data.Length);
            string rec = Encoding.Unicode.GetString(data);
            int number = int.Parse(rec);
            return number;
        }
        public void Start()
        {
            // Коннектимся к серверу
            client = new TcpClient();
            client.Connect(IPAddress.Parse("192.168.0.2"), 8005);
            stream = client.GetStream();
            int number = ReceiveNumb();
            if (number == 1)
            {
                Game1.id = 1;
            }
            else if (number == 2)
            {
                Game1.id = 2;
            }
            if (client.Connected)
            {
                
                try
                {
                    Game1.FlagStart = true;//а вот и флаг
                    if (Game1.id == 1) //тип если первая ракетка, отправляем координаты серверу о первой ракетке
                    {
                        SendRequest((Game1.Player1_racket1).ToString());
                        ReceiveLocRacket2();//получаем координаты второй ракетки


                    }
                    else if (Game1.id == 2) // здесь также, только наоборот
                    {

                        SendRequest((Game1.Player2_racket2).ToString());
                        ReceiveLocRacket1();
                    }
                }
                catch (Exception ex)
                {
                    Disconnect();
                    Console.WriteLine(ex.Message + "\n\n" + ex.InnerException + "\n\n" + ex.Source, "Client error");
                }
            }
            else
            {
                Console.WriteLine("Невозможно подлкючиться");
            }
        }


        // отправка координат серваку
        public void SendRequest(string mess)
        {
            byte[] data = Encoding.Unicode.GetBytes(mess);
            stream.Write(data, 0, data.Length);
        }


        public void SendLocationBallX(string x)
        {
            SendRequest(x);
        }

        public void SendLocationBallY(string y)
        {
            SendRequest(y);
        }

        //получение координат от сервера первой ракетки
        public void ReceiveLocRacket1()
        {
            while (true)
            {
                byte[] data = new byte[128];
                stream.Read(data, 0, data.Length);
                string rec = Encoding.Unicode.GetString(data);
                Game1.Player1_racket1 = Convert.ToInt16(rec);
            }

        }

        //получение координат от сервера второй ракетки
        public void ReceiveLocRacket2()
        {
            while (true)
            {
                byte[] data = new byte[128];
                stream.Read(data, 0, data.Length);
                string rec = Encoding.Unicode.GetString(data);
                Game1.Player2_racket2 = Convert.ToInt16(rec);
            }

        }

        //тип обрываем соединение
        private static void Disconnect()
        {
            if (stream != null)
                stream.Close();
            if (client != null)
                client.Close();
        }
    }
}
