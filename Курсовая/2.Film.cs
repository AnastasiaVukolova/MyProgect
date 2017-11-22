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
    public partial class Film : Form
    {
        public Disk Disk {
            get
            {
                try
                {
                    return new Disk(textBox1.Text, textBox2.Text, int.Parse(textBox3.Text), int.Parse(textBox4.Text), double.Parse(textBox5.Text));
                }
                catch
                {
                    MessageBox.Show(this, "Ошибка ввода!", Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                return null;
            }
            set
            {
                textBox1.Text = value.Name;
                textBox2.Text = value.Genre;
                textBox3.Text = value.Year.ToString();
                textBox4.Text = value.Count.ToString();
                textBox5.Text = value.Price.ToString();
            }
        }
        public Film()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Disk == null) return;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
