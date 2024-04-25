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
    public partial class Form2 : Form
    {
        
      
        Thread s,x;
        public Form2()
        {
            InitializeComponent();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            x = new Thread(opi);
            x.TrySetApartmentState(ApartmentState.STA);
            x.Start();
            
        }

        public void opi(object obj)
        {
            Application.Run(new Form1());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void op(object obj)
        {
            Application.Run(new Form3());
        }



        private void Form2_Load(object sender, EventArgs e)
        {
         
        }
        public void nas(object obj)
        {
            Application.Run(new Form4());
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            s = new Thread(nas);
            s.TrySetApartmentState(ApartmentState.STA);
            s.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Close();
            s = new Thread(op);
            s.TrySetApartmentState(ApartmentState.STA);
            s.Start();
        }
    }
}
