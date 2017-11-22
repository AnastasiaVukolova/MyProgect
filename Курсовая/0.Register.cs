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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        private bool isClosed = true;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 0 || textBox2.TextLength == 0 || textBox3.TextLength == 0)
            {
                MessageBox.Show("Неправильный ввод данных администратора!");
                return;
            }
            string login = textBox2.Text;
            Admin admin = Program.AdminList.Find(adm => adm.Login == login);
            if (admin != null)
            {
                MessageBox.Show("Такой администратор уже существует!");
                return;
            }
            Program.AdminList.Add(new Admin(textBox1.Text, textBox2.Text, textBox3.Text));
            isClosed = false;
            AdminFeatures frm = new AdminFeatures();
            Close();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isClosed)
                Program.startPage.Visible = true;
        }
    }
}
