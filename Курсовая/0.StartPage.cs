using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Курсовая
{
    public partial class StartPage : Form
    {
        public StartPage()
        {
            InitializeComponent();
            try
            {
                if (File.Exists("Course"))
                    Program.LoadFromFile("Course");
            }
            catch
            {
                MessageBox.Show(this, "Ошибка десериализации!", Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Register frm = new Register();
            Visible = false;
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text, password = textBox2.Text;
            Admin admin = Program.AdminList.Find(adm => adm.Login == login && adm.Password == password);
            if (admin == null)
            {
                MessageBox.Show("Неправильный ввод данных администратора!");
                return;
            }
           AdminFeatures frm = new AdminFeatures();
           Visible = false;
           frm.Show();
            
        }

        private void StartPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.SaveToFile("Course");
        }

        private void StartPage_VisibleChanged(object sender, EventArgs e)
        {
            textBox2.Clear();
        }
    }
}
