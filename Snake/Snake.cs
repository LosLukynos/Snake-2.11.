using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Snake
{
    public class Snake
    {
        public double Speed { get; set; }
        public double Direction { get; set; }
        public Point Head { get; set; }
        public List<Point> Tail { get; set; }
        public double TurnSpeed { get; set; } = 0.2;

        public Snake()
        {
            Head = new Point();
            Tail = new List<Point>();
        }

        public Snake(Point head)
        {
            Head = head;
            Tail = new List<Point>();
        }

        public void TurnLeft()
        {
            Direction += TurnSpeed;
        }

        public void TurnRight()
        {
            Direction -= TurnSpeed;
        }

        public void Forward()
        {
            var x = Math.Sin(Direction) * Speed;
            var y = Math.Cos(Direction) * Speed;
            Tail.Add(Head);            
            Head = new Point(Tail[Tail.Count - 1].X + Convert.ToInt32(Math.Round(x))
                           , Tail[Tail.Count - 1].Y + Convert.ToInt32(Math.Round(y)));
        }

        public PictureBox GetHead(Color color, int size)
        {
            var pBox = new PictureBox();
            pBox.Width = size;
            pBox.Height = size;
            pBox.Location = Head;
            pBox.BackColor = color;
            return pBox;
        }
    }
}
