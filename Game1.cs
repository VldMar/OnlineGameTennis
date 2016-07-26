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
        private bool status = true; // не помню нах эта хрень, но чо-то с ограничением движения ракеток
        private int score1 = 0;// счет первого игока, а след строка второго
        private int score2 = 0;

        public static bool FlagStart = false; // нужна для запуска таймера
        public static int id = 0;// отпределить за какую ракетку играть(1 - первая, 2- вторая)
        public static Thread th;// поток для запуска игры, сам не понял, нахер нужно

        public static int Player1_racket1, Player2_racket2; //определяют координаты ракетки

        public static string ip = null, port = null, nickname = null; //пока не нужны и не важно, беруться из другой формы,

        public static TcpClient client;// ну здесь все понятно
        public static NetworkStream stream;
        Clinentt clie;

        public Game1()
        {
            FormUnderMenu fum = new FormUnderMenu();
            fum.ShowDialog();// ничего не вводи, все равно я пока не использую эти значения, потом пригодиться, когда с ракетками разберусь

            clie = new Clinentt();
            th = new Thread(new ThreadStart(clie.Start));// запускаем поток, то бишь игру в качестве клиента

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

        //делаем шар круглым при помощи события paint
        private void ball_paint(object sender, PaintEventArgs e)
        {
            GraphicsPath shape = new GraphicsPath();
            shape.AddEllipse(0, 0, ball.Width, ball.Height);
            ball.Region = new Region(shape);
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


        //здесь просто обрабатываются нажатия разных клавиш
        // а как нажали, изменились координаты и мы их сразу отправляем серваку
        private void Game1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape) { this.Close(); th.Abort(); }

            // задаем движение первой ракетки по столу
            //c использованием кнопок W и S
            if (id == 1)
            {

                racket2.Top = Player2_racket2;
                if (e.KeyData == Keys.W && status)
                { racket1.Top -= (racket1.Height / 2 + 5); Player1_racket1 = racket1.Top; clie.SendMessage(Player1_racket1.ToString()); }
                //ставим ограничение на передвижение ракетки по верхнему краю стола
                if (racket1.Top <= panel1.Top - 5)
                {
                    status = false;
                    if (e.KeyData == Keys.S)
                    { status = true; racket1.Top += (racket1.Height / 2 + 5); Player1_racket1 = racket1.Top; clie.SendMessage(Player1_racket1.ToString()); }

                }
                if (e.KeyData == Keys.S && status)
                { racket1.Top += (racket1.Height / 2 + 5); Player1_racket1 = racket1.Top; clie.SendMessage(Player1_racket1.ToString()); }



                //аналогично ставим ограничение по нижнему краю стола
                if (racket1.Bottom >= panel1.Bottom + 5)
                {
                    status = false;
                    if (e.KeyData == Keys.W)
                    { status = true; racket1.Top -= (racket2.Height / 2 + 5); Player1_racket1 = racket1.Top; clie.SendMessage(Player1_racket1.ToString()); }
                }

            }

            // здесь та же хрень, только о другой ракетке отправляем инфу

            // аналогично задаем движение второй ракетки по столу
            //с использованием кнопок Up и Down

            if (id == 2)
            {
                racket1.Top = Player1_racket1; //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1


                if (e.KeyData == Keys.Up && status)
                { racket2.Top -= racket2.Height / 2; Player2_racket2 = racket2.Top; clie.SendMessage((Player2_racket2 + 34).ToString()); }

                if (racket2.Top <= panel1.Top - 5)
                {
                    status = false;
                    if (e.KeyData == Keys.Down)
                    { status = true; racket2.Top += racket2.Height / 2; Player2_racket2 = racket2.Top; clie.SendMessage((Player2_racket2 + 34).ToString()); }
                }
                if (e.KeyData == Keys.Down && status)
                { racket2.Top += racket2.Height / 2; Player2_racket2 = racket2.Top; clie.SendMessage((Player2_racket2 + 34).ToString()); }

                if (racket2.Bottom >= panel1.Bottom + 5)
                {
                    status = false;
                    if (e.KeyData == Keys.Up) { status = true; racket2.Top -= racket2.Height / 2; Player2_racket2 = racket2.Top; clie.SendMessage((Player2_racket2 + 34).ToString()); }

                }
            }
        }

        // рисуем на панели: 
        // границы и перерисовыавем ракетки, если меняются координаты
        // так должно быть в идеале, но чет так не выходит


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


        // просто запускаем мяч, даже можешь не читать, здесь все норм
        // не запускаю, чтобы мяч не мешался
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
                WinOrLose();


                if (ball.Top <= panel1.Top + 10)
                    speed_of_ballY = -speed_of_ballY;
                if (ball.Bottom <= panel1.Bottom - 10)
                    speed_of_ballY = -speed_of_ballY;

            }


        }


        //как нажимаем клавишу подлкючиться, запускаемся как клиент
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            th.Start();
            menuStrip1.Enabled = false;
        }



        private void WinOrLose()
        {
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
                    MessageBox.Show(label1.Text + "isWinner!");
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
                    MessageBox.Show(label2.Text + "isWinner!");
                }

            }
        }
        //------------------------------------------------ столкновение со столом мяча
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


        //столкновение с ракеткой мяча
        private void CollisionRacket()
        {

            if (ball.Right >= racket2.Left - 3 && ball.Right <= racket2.Right && ball.Bottom <= racket2.Bottom && ball.Top >= racket2.Top)
                speed_of_ballX = -speed_of_ballX;
            if (ball.Left <= racket1.Right && ball.Right >= racket1.Left && ball.Bottom <= racket1.Bottom && ball.Top >= racket1.Top)
                speed_of_ballX = -speed_of_ballX;
        }

        //нах не нужно, убирать так лень, что просто жесть
        private void racket2_LocationChanged(object sender, EventArgs e)
        {
        }
    }
}