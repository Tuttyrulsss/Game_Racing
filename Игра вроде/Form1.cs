using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Игра_вроде
{
    public partial class Form1 : Form
    {

        private Point pos;
        private bool dragging, lase = false; 
        private int many = 0;
        Thread a;
        public Form1()
        {
            InitializeComponent();

            zhol2.MouseDown += MouseClickDown;
            zhol2.MouseUp += MouseClickUp;
            zhol2.MouseMove += MouseClickMove;

            pictureBox3.MouseDown += MouseClickDown;
            pictureBox3.MouseUp += MouseClickUp;
            pictureBox3.MouseMove += MouseClickMove;

            zhol1.MouseDown += MouseClickDown;
            zhol1.MouseUp += MouseClickUp;
            zhol1.MouseMove += MouseClickMove;

            label1.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            KeyPreview = true;
        }
        private void MouseClickDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            pos.X = e.X;
            pos.Y = e.Y;
        }
        private void MouseClickUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
        private void MouseClickMove(object sender, MouseEventArgs e)
        {
            Point currPoint = PointToScreen(new Point(e.X, e.Y));
         // this.Location = new Point(currPoint.X - pos.X, currPoint.Y - pos.Y + pictureBox1.Top);
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                this.Close();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int speed = 15;
            zhol2.Top += speed;
            zhol4.Top += speed;
            zhol1.Top += speed;

            int Carspeed = 7;
            ma1.Top += Carspeed;
            ma2.Top += Carspeed;
            ma3.Top += Carspeed;

            int Manycpeed = 4;
            tenge.Top += Manycpeed;

            if (zhol2.Top >= 650)
            {
                zhol2.Top = 0;
                zhol4.Top = -300;
                zhol1.Top = -650;
            }

            if (tenge.Top >= 650)
            {
                tenge.Top = -100;
                Random rand = new Random();
                tenge.Left = rand.Next(0, 500);
            }

            if (ma1.Top >= 650)
            {
                ma1.Top = -130;
                Random rand = new Random();
                ma1.Left = rand.Next(0, 251);
            }
            if (ma2.Top >= 650) 
            { 
                ma2.Top = -200;
                Random rand = new Random();
                ma2.Left = rand.Next(260, 450);
            }
            if (ma3.Top >= 650)
            { 
                ma3.Top = -230;
                Random rand = new Random();
                ma3.Left = rand.Next(450, 540);
            }
            if (pictureBox2.Bounds.IntersectsWith(ma1.Bounds) ||
               (pictureBox2.Bounds.IntersectsWith(ma2.Bounds)))
            {
                timer1.Enabled = false;
                label1.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                lase = true;
            }
            if(pictureBox2.Bounds.IntersectsWith(tenge.Bounds))
            {
                many++;
                label2.Text = "Тенге: " + many.ToString();
                tenge.Top = -100;
                Random rand = new Random();
                tenge.Left = rand.Next(0, 500);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (lase) return;
            int speed = 10;
            if((e.KeyCode == Keys.Left) && pictureBox2.Left > 10)
                pictureBox2.Left -= speed;
                else if ((e.KeyCode == Keys.Right) && pictureBox2.Right < 560)
                
                    pictureBox2.Left += speed;
                
        }

        private void car1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            a = new Thread(open);
            a.TrySetApartmentState(ApartmentState.STA);
            a.Start();
        }
        public void open(object obj)
        {
            Application.Run(new Form2());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ma1.Top = -200;
            ma2.Top = -250;
            ma3.Top = -400;
            button1.Visible = false;
            button2.Visible = false;
            timer1.Enabled = true; 
            label1.Visible = false;
            lase = false;
            many = 0;
            label2.Text = "Тенге: 0";
            tenge.Top = -100;
        }
    }
}
