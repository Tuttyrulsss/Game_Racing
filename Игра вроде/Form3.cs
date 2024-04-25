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
    public partial class Form3 : Form
    {
        Thread f;
        public Form3()
        {
            InitializeComponent();
        }
        public void we(object obj)
        {
            Application.Run(new Form2());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            f = new Thread(we);
            f.TrySetApartmentState(ApartmentState.STA);
            f.Start();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
