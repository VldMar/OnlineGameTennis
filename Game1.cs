using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_version_1
{
    public partial class Game1 : Form
    {
        private int speed_of_ballX = 4;
        private int speed_of_ballY = 4;
        private int y2 = 4;
        private bool status=true;
        private int score1 = 0;
        private int score2 = 0;

        public Game1()
        {
            InitializeComponent();
            panel1.BackColor = Color.Blue;
            ball.Height = 25;
            ball.Width = 25;
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DrawAxes(g);
        }

        private void Game1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData==Keys.Escape) {this.Close(); }

            // задаем движение первой ракетки по столу
            //c использованием кнопок W и S
            if (e.KeyData == Keys.W && status) { racket1.Top -= racket1.Height / 2; }
            //ставим ограничение на передвижение ракетки по верхнему краю стола
            if (racket1.Top <= panel1.Top - 5)
            {
                status = false;
                if (e.KeyData == Keys.S) { status = true; racket1.Top += racket1.Height / 2; }
            }
            if (e.KeyData == Keys.S && status) { racket1.Top += racket1.Height / 2; }
            //аналогично ставим ограничение по нижнему раю стола
            if (racket1.Bottom >= panel1.Bottom + 5)
            {
                status = false;
                if (e.KeyData == Keys.W) { status = true; racket1.Top -= racket2.Height / 2; }
            }


            // аналогично задаем движение второй ракетки по столу
            //с использованием кнопок Up и Down

            if (e.KeyData == Keys.Up && status) { racket2.Top -= racket2.Height / 2; }
            if (racket2.Top <= panel1.Top - 5)
            {
                status = false;
                if (e.KeyData == Keys.Down) { status = true; racket2.Top += racket2.Height / 2; }
            }
            if (e.KeyData == Keys.Down && status) { racket2.Top += racket2.Height / 2; }

            if(racket2.Bottom>=panel1.Bottom+5)
            {
                status = false;
                if(e.KeyData==Keys.Up) { status = true; racket2.Top -= racket2.Height / 2; }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            //движение мяча
            ball.Top += speed_of_ballY;//speed_of_ballY;
            ball.Left += speed_of_ballX;//speed_of_ballX;

            //обработка столкновений мяча со столом
            if (ball.Bottom <= panel1.Bottom)
            {
                speed_of_ballY = -speed_of_ballY;
            }
            if (ball.Top <= panel1.Top)
            {
                speed_of_ballY = -speed_of_ballY;
            }

            string rcData = racket1.Location.ToString();
            // обработка столкновений с ракетками

              if (ball.Right >= racket2.Left-3 && ball.Right<=racket2.Right && ball.Bottom<=racket2.Bottom && ball.Top>=racket2.Top)
                  speed_of_ballX = -speed_of_ballX;
              if (ball.Left <= racket1.Right && ball.Right >= racket1.Left && ball.Bottom <= racket1.Bottom && ball.Top >= racket1.Top)
                speed_of_ballX = -speed_of_ballX;

            // проверяем на проигрышь
            if (ball.Right >= panel1.Right - 5)
            {
                if (score1 < 11)
                {
                    score1 += 1;
                    lblscore.Text = score1.ToString();
                    ball.Location = new Point(475,125);
                }
                else
                {
                    timer1.Enabled = false;
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
                { timer1.Enabled = false; }
                
            }


            if (ball.Top <= panel1.Top+10)
                speed_of_ballY = -speed_of_ballY;
            if (ball.Bottom <= panel1.Bottom-10)
                speed_of_ballY = -speed_of_ballY;

           
        }

        private void racket2_LocationChanged(object sender, EventArgs e)
        {
        }
    }
}
