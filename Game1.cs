;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.Threading;

//192.168.0.4

namespace Game_version_1
{
    public partial class Game1 : Form
    {
        private int speed_of_ballX = 4;
        private int speed_of_ballY = 4;
        private bool status = true;
        private int score1 = 0;
        private int score2 = 0;

        private bool isServ;
        private static bool FlagStart = false;
        public static int id = 0;
        public static Thread th;

        private static int Player1_racket1, Player2_racket2;

        public static string ip = null, port = null, nickname = null;

        public static TcpClient client;
        public static NetworkStream stream;


        public Game1()
        {
            FormUnderMenu fum = new FormUnderMenu();
            fum.ShowDialog();

            th = new Thread(new ThreadStart(StartAsClient));

            InitializeComponent();

            panel1.BackColor = Color.Blue;
            ball.Height = 25;
            ball.Width = 25;
            label1.Text = "Server";
            label2.Text = nickname;

            ball.Paint += new PaintEventHandler(ball_paint);
            Player1_racket1 = racket1.Top;
            Player2_racket2 = racket2.Top;

        }

        public static int ReceiveNumb()
        {
            byte[] data = new byte[32];
            stream.Read(data, 0, data.Length);
            string rec = Encoding.Unicode.GetString(data);
            int number = int.Parse(rec);
            return number;

        }

        //делаем шар круглым при помощи события paint
        private void ball_paint(object sender, PaintEventArgs e)
        {
            GraphicsPath shape = new GraphicsPath();
            shape.AddEllipse(0, 0, ball.Width, ball.Height);
            ball.Region = new Region(shape);
        }



        public static void StartAsClient()
        {
            client = new TcpClient();
            client.Connect(IPAddress.Parse("192.168.0.2"), 8005);//пока так, чтобы не терять время и сразу проверять работу программы
            stream = client.GetStream();
            int number = ReceiveNumb();
            if (number == 1)
            {
                id = 1;
            }
            else if (number == 2)
            {
                id = 2;
            }
            if (client.Connected)
            {
                FlagStart = true;
                try
                {
                    if (id == 1)
                    {
                        SendMessage((Player1_racket1).ToString());
                        ReceiveMess2();

                    }
                    else if (id == 2)
                    {
                        SendMessage((Player2_racket2).ToString());
                        ReceiveMess1();
                    }
                }
                catch (Exception ex)
                {
                    Disconnect();
                    MessageBox.Show(ex.Message + "\n\n" + ex.InnerException + "\n\n" + ex.Source, "Client error");
                    Application.Exit();
                }
            }
            else
            {
                MessageBox.Show("Невозможно подлкючиться");
            }

        }


        private static void SendMessage(string mess)
        {
            byte[] data = Encoding.Unicode.GetBytes(mess);
            stream.Write(data, 0, data.Length);


        }

        private static void ReceiveMess1()
        {
            while (true)
            {
                byte[] data = new byte[128];
                stream.Read(data, 0, data.Length);
                string rec = Encoding.Unicode.GetString(data);
                Player1_racket1 = Convert.ToInt16(rec);
            }

        }

        private static void ReceiveMess2()
        {
            while (true)
            {
                byte[] data = new byte[128];
                stream.Read(data, 0, data.Length);
                string rec = Encoding.Unicode.GetString(data);
                Player2_racket2 = Convert.ToInt16(rec);
            }

        }

        private static void Disconnect()
        {
            if (stream != null)
                stream.Close();
            if (client != null)
                client.Close();
        }



        //метод для рисования границ стола и сетки
        private void DrawAxes(Graphics g)
        {
            //используем два пера толщиной 2 и 5 пикселей
            //для отрисовки границ стола и сетки
            Pen pen1 = new Pen(Color.White, 2);
            Pen pen2 = new Pen(Color.White, 7);
            //проводим линию по указанным координатам
            // g.DrawLine(pen1, 0, 240, 785, 240);
            g.DrawLine(pen2, 395, 0, 395, 460);

            //выводим границы стола
            Rectangle rect = ClientRectangle;
            g.DrawRectangle(pen2, rect);

            pen1.Dispose();
            pen2.Dispose();

        }


        private void Game1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape) { this.Close(); th.Abort(); }

            // задаем движение первой ракетки по столу
            //c использованием кнопок W и S
            if (id == 1)
            {

                racket2.Top = Player2_racket2;
                if (e.KeyData == Keys.W && status)
                { racket1.Top -= (racket1.Height / 2 + 5); Player1_racket1 = racket1.Top; SendMessage(Player1_racket1.ToString()); }
                //ставим ограничение на передвижение ракетки по верхнему краю стола
                if (racket1.Top <= panel1.Top - 5)
                {
                    status = false;
                    if (e.KeyData == Keys.S)
                    { status = true; racket1.Top += (racket1.Height / 2 + 5); Player1_racket1 = racket1.Top; SendMessage(Player1_racket1.ToString()); }

                }
                if (e.KeyData == Keys.S && status)
                { racket1.Top += (racket1.Height / 2 + 5); Player1_racket1 = racket1.Top; SendMessage(Player1_racket1.ToString()); }



                //аналогично ставим ограничение по нижнему краю стола
                if (racket1.Bottom >= panel1.Bottom + 5)
                {
                    status = false;
                    if (e.KeyData == Keys.W)
                    { status = true; racket1.Top -= (racket2.Height / 2 + 5); Player1_racket1 = racket1.Top; SendMessage(Player1_racket1.ToString()); }
                }

            }


            // аналогично задаем движение второй ракетки по столу
            //с использованием кнопок Up и Down

            if (id == 2)
            {
                racket1.Top = Player1_racket1; //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1


                if (e.KeyData == Keys.Up && status)
                { racket2.Top -= racket2.Height / 2; Player2_racket2 = racket2.Top; SendMessage((Player2_racket2 + 34).ToString()); }

                if (racket2.Top <= panel1.Top - 5)
                {
                    status = false;
                    if (e.KeyData == Keys.Down)
                    { status = true; racket2.Top += racket2.Height / 2; Player2_racket2 = racket2.Top; SendMessage((Player2_racket2 + 34).ToString()); }
                }
                if (e.KeyData == Keys.Down && status)
                { racket2.Top += racket2.Height / 2; Player2_racket2 = racket2.Top; SendMessage((Player2_racket2 + 34).ToString()); }

                if (racket2.Bottom >= panel1.Bottom + 5)
                {
                    status = false;
                    if (e.KeyData == Keys.Up) { status = true; racket2.Top -= racket2.Height / 2; Player2_racket2 = racket2.Top; SendMessage((Player2_racket2 + 34).ToString()); }

                }
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DrawAxes(g);
            if (FlagStart && id == 1)
            {
                racket1.Top = Player1_racket1;
                Invalidate();
            }
            else if (FlagStart && id == 2)
            {
                racket2.Top = Player2_racket2;
                Invalidate();
            }
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (FlagStart)
            {
                timer1.Enabled = true;
                //движение мяча
                ball.Top += speed_of_ballY;//speed_of_ballY;
                ball.Left += speed_of_ballX;//speed_of_ballX;

                //обработка столкновений мяча со столом
                CollisionTable();

                // обработка столкновений с ракетками
                CollisionRacket();

                // проверяем на проигрышь
                if (ball.Right >= panel1.Right - 5)
                {
                    if (score1 < 11)
                    {
                        score1 += 1;
                        lblscore.Text = score1.ToString();
                        ball.Location = new Point(475, 125);
                    }
                    else
                    {
                        timer1.Enabled = false;
                        MessageBox.Show("Player1 isWinner!");

                    }

                }

                if (ball.Left <= panel1.Left + 5)
                {
                    if (score2 < 11)
                    {
                        score2 += 1;
                        lbl2_score.Text = score2.ToString();
                        ball.Location = new Point(475, 125);
                    }
                    else
                    {
                        timer1.Enabled = false;
                        MessageBox.Show("Player2 isWinner!");
                    }

                }


                if (ball.Top <= panel1.Top + 10)
                    speed_of_ballY = -speed_of_ballY;
                if (ball.Bottom <= panel1.Bottom - 10)
                    speed_of_ballY = -speed_of_ballY;

            }


        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            th.Start();
            menuStrip1.Enabled = false;
        }

        //------------------------------------------------
        private void CollisionTable()
        {
            if (ball.Bottom <= panel1.Bottom)
            {
                speed_of_ballY = -speed_of_ballY;
            }
            if (ball.Top <= panel1.Top)
            {
                speed_of_ballY = -speed_of_ballY;
            }
        }

        private void CollisionRacket()
        {

            if (ball.Right >= racket2.Left - 3 && ball.Right <= racket2.Right && ball.Bottom <= racket2.Bottom && ball.Top >= racket2.Top)
                speed_of_ballX = -speed_of_ballX;
            if (ball.Left <= racket1.Right && ball.Right >= racket1.Left && ball.Bottom <= racket1.Bottom && ball.Top >= racket1.Top)
                speed_of_ballX = -speed_of_ballX;
        }
        private void racket2_LocationChanged(object sender, EventArgs e)
        {
        }
    }
}