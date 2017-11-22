using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовая
{
    public partial class Rent : Form
    {
       // public event EventHandler KeyPress;
        public Rent()
        {
            InitializeComponent();
        }

        private void numericUpDown1_TextChanged(object sender, EventArgs e)
        {
          
            textBox2.Text = (Convert.ToInt32(numericUpDown1.Value) * (rentPrice) +  Rent.incrPrice).ToString();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Rent_Load(object sender, EventArgs e)
        {

        }


    }
}
