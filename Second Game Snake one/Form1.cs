using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Second_Game_Snake_one
{

    public partial class Form1 : Form
    {
        public enum Direction
        {
            Right=0,
            Left=1,
            Up=2,
            Down=3
        }

        int Length =1;
        Point[] mas; 
        Direction MoveTurn;
        Point apple;
        
        public Form1()
        {
            mas = new Point[64];
            InitializeComponent();
            MoveTurn = 0;
            mas[0] = new Point(150,150);
            Random rnd = new Random();
            apple.X = rnd.Next(0, 7) * 50;
            apple.Y = rnd.Next(0, 7) * 50;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {                             
            var colorApple = new SolidBrush(Color.Red);
            e.Graphics.FillEllipse(colorApple, apple.X, apple.Y, 50, 50);

            for (var i = Length; i > 0; i--)
                mas[i] = mas[i-1];

            if (MoveTurn == 0)
                mas[0].X += 50;
            if (MoveTurn == Direction.Left)
                mas[0].X -= 50;
            if (MoveTurn == Direction.Up)
                mas[0].Y -= 50;
            if (MoveTurn == Direction.Down)
                mas[0].Y += 50;

            var colorSnake = new SolidBrush(Color.Black);
            for (var i = 0; i < Length; i++)
            {
                e.Graphics.FillEllipse(colorSnake, mas[i].X, mas[i].Y, 50, 50);
            }

            if (mas[0].Y < 0 || mas[0].X < 0 || mas[0].Y >= 350 || mas[0].X >= 350)
            {
                GameOver();
            }

            for (var i = 1; i<Length;i++)
            {
                if (mas[0] == mas[i])
                    GameOver();
            }

            if (apple.X == mas[0].X && mas[0].Y == apple.Y)
            {
                Length++;
                Random rnd = new Random();
                apple.X = rnd.Next(0, 7) * 50;
                apple.Y = rnd.Next(0, 7) * 50;
                //if (Length > 10)
                //    timer1.Interval = 300;
                //if (Length > 20)
                //    timer1.Interval = 150;
            }
        }

        private void GameOver()
        {
            mas[0].X = 150;
            mas[0].Y = 150;
            Length = 1;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
           switch (e.KeyCode)
           {
                case Keys.W:
                    MoveTurn = Direction.Up;
                    break;
                case Keys.S:
                    MoveTurn = Direction.Down;
                    break;
                case Keys.D:
                    MoveTurn = Direction.Right;
                    break;
                case Keys.A:
                    MoveTurn = Direction.Left;
                    break;
           }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }
    }
}
