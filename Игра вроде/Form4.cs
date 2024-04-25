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
    public partial class Form4 : Form
    {
        Thread w;
        public Form4()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            w = new Thread(open);
            w.TrySetApartmentState(ApartmentState.STA);
            w.Start();
        }
        public void open(object obj)
        {
            Application.Run(new Form2());
        }
    }
}
