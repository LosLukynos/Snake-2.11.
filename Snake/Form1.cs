using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        bool a, d, j, k;
        Timer timer;
        Snake snake1;
        Snake snake2;
        PictureBox player1;
        List<PictureBox> player1tail;
        PictureBox player2;
        List<PictureBox> player2tail;
        Point startPoint1;
        Point startPoint2;
        bool gameStarted;

        public Form1()
        {
            
             timer = new Timer();
            timer.Interval = 50;
            timer.Tick += Timer_Tick;
            snake1 = new Snake(startPoint1);
            snake1.Speed = 3;
            snake1.Direction = -Math.PI / 2;
            player1tail = new List<PictureBox>();
            player1 = snake1.GetHead(Color.Blue, 10);
            snake2 = new Snake(startPoint2);
            snake2.Speed = 3;
            snake2.Direction = Math.PI / 2;
            player2tail = new List<PictureBox>();
            player2 = snake2.GetHead(Color.Red, 10);
            this.Controls.Add(player1);
            this.Controls.Add(player2);
            InitializeComponent();
            CenterMenu();
           
        }

        private void CenterMenu()
        {
            Point centerForm = new Point(ClientSize.Width / 2, ClientSize.Height / 2);
            panel1.Top = 0;
            panel1.Left = centerForm.X - panel1.Width / 2;
            startPoint1 = new Point(centerForm.X - 15, centerForm.Y-5);
            startPoint2 = new Point(centerForm.X + 5, centerForm.Y - 5);
            if (!gameStarted)
            {
                player1.Location = startPoint1;
                snake1.Head = startPoint1;
                player2.Location = startPoint2;
                snake2.Head = startPoint2;
            }
        }

        private void Form1_ClientSizeChanged(object sender, EventArgs e)
        {
            CenterMenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer.Enabled = !timer.Enabled;
            if (timer.Enabled)
            {
                gameStarted = true;
                button1.BackgroundImage = Properties.Resources.pause;
            }
            else
            {
                button1.BackgroundImage = Properties.Resources.play;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (a)
            {
                snake1.TurnLeft();
            }
            if (d)
            {
                snake1.TurnRight();
            }
            if (j)
            {
                snake2.TurnLeft();
            }
            if (k)
            {
                snake2.TurnRight();
            }

            player1tail.Add(player1);
            snake1.Forward();
            player1 = snake1.GetHead(Color.Blue, 10);
            this.Controls.Add(player1);
            player2tail.Add(player2);
            snake2.Forward();
            player2 = snake2.GetHead(Color.Red, 10);
            this.Controls.Add(player2);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                a = false;
            }
            else if (e.KeyCode == Keys.D)
            {
                d = false;
            }
            else if (e.KeyCode == Keys.J)
            {
                j = false;
            }
            else if (e.KeyCode == Keys.K)
            {
                k = false;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                a = true;
            }
            else if (e.KeyCode == Keys.D)
            {
                d = true;
            }
            else if (e.KeyCode == Keys.J)
            {
                j = true;
            }
            else if (e.KeyCode == Keys.K)
            {
                k = true;
            }
        }
    }
}
