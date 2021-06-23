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

        int Length;
        Point[] mas = new Point[64];
        Direction MoveTurn;
        Point head = new Point(150,150);
        Point apple;
        bool AppleEat = true;

        public Form1()
        {
            InitializeComponent();
            MoveTurn = 0;
            Length = 1;
            mas[0] = head;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (AppleEat)
            {
                Random rnd = new Random();
                var x = rnd.Next(0, 7)*50;
                var y = rnd.Next(0, 7)*50;
                apple.X = x;
                apple.Y = y;
                AppleEat = false;
            }


            if (MoveTurn == 0)
                head.X+=50;
            if (MoveTurn == Direction.Left)
                head.X -= 50;
            if (MoveTurn == Direction.Up)
                head.Y -= 50;
            if (MoveTurn == Direction.Down)
                head.Y += 50;

            if (head.Y<0 || head.X <0 || head.Y>=400 || head.X >= 400)
            {
                head.X = 150;
                head.Y = 150;                
            }

            if (!AppleEat && apple.X == head.X && head.Y == apple.Y)
            {
                AppleEat = true;
                Length++;
            }
            else
            {
                var colorApple = new SolidBrush(Color.Red);
                e.Graphics.FillEllipse(colorApple, apple.X, apple.Y, 50, 50);
            }
            var colorSnake = new SolidBrush(Color.Blue);
            e.Graphics.FillRectangle(colorSnake,head.X,head.Y,50,50);
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
