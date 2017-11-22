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
    public partial class AdminFeatures : Form
    {
        private bool isClosed = true;
        public AdminFeatures()
        {
            InitializeComponent();
            foreach (Disk disk in Program.DiskList)
            {
                ListViewItem item = new ListViewItem(
                    new string[] { disk.Name, disk.Genre, disk.Year.ToString(), disk.Count.ToString(), disk.Price.ToString() });
                listView1.Items.Add(item);
            }
            foreach (string request in Program.RequestList)
                listView2.Items.Add(request);
            foreach (Customer customer in Program.CustomerList)
            {
                ListViewItem item = new ListViewItem(
                    new string[] { customer.Login, customer.usingCount.ToString(), customer.phonen, customer.emailc});
                listView3.Items.Add(item);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
            Program.startPage.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 0 || textBox2.TextLength == 0)
            {
                MessageBox.Show("Неправильный ввод данных клиента!");
                return;
            }
            string login = textBox1.Text, password = textBox2.Text, phone = textBox3.Text, email = textBox4.Text ;
            Customer customer;
            if (!checkBox1.Checked)
            {
                textBox4.Visible = false;
                textBox3.Visible = false;
                customer = Program.CustomerList.Find(cust => cust.Login == login && cust.Password == password);
                if (customer == null)
                {
                    MessageBox.Show("Неправильный ввод данных клиента!");
                    return;
                }
            }
            else
            {
                for (int i = 0; i < Program.CustomerList.Count; i++)
                {
                    if (String.Equals(Program.CustomerList[i].Login, textBox1.Text))
                    {
                        MessageBox.Show("Такой пользователь уже существует!");
                        return;
                    }
                }
                customer = new Customer(login, password, phone, email);
                Program.CustomerList.Add(customer);
            }
            isClosed = false;
            ChooseFilm frm = new ChooseFilm();
            frm.Customer = customer;
            Close();
            frm.Show();
        }

        private void AdminFeatures_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isClosed)
                Program.startPage.Visible = true;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button10.Enabled = listView1.SelectedIndices.Count != 0;
            button11.Enabled = listView1.SelectedIndices.Count != 0;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Film formFilm = new Film();
            if (formFilm.ShowDialog() == DialogResult.OK)
            {
                listView1.Select();
                Disk disk = formFilm.Disk;
                Program.DiskList.Add(disk);
                ListViewItem item = new ListViewItem(
                    new string[] { disk.Name, disk.Genre, disk.Year.ToString(), disk.Count.ToString(), disk.Price.ToString() });
               
                //контроль повторения фильма в списке
                for (int i = 0; i < listView1.Items.Count; i++)
                {

                    if (String.Equals(listView1.Items[i].SubItems[0].Text, disk.Name) & String.Equals(listView1.Items[i].SubItems[1].Text, disk.Genre)
                        & String.Equals(listView1.Items[i].SubItems[2].Text, disk.Year.ToString()))
                    {
                        MessageBox.Show("Фильм уже существует!");
                        return;
                    }

                }
                
                listView1.Items.Add(item);
                item.Selected = true;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Film formFilm = new Film();
            int index = listView1.SelectedIndices[0];
            Disk disk = new Disk(listView1.Items[index].SubItems[0].Text, listView1.Items[index].SubItems[1].Text,
                int.Parse(listView1.Items[index].SubItems[2].Text), int.Parse(listView1.Items[index].SubItems[3].Text),
                double.Parse(listView1.Items[index].SubItems[4].Text));
            formFilm.Disk = disk;
            if (formFilm.ShowDialog() == DialogResult.OK)
            {
                listView1.Select();
                disk = formFilm.Disk;
                Program.DiskList[index] = disk;
                ListViewItem item = new ListViewItem(
                    new string[] { disk.Name, disk.Genre, disk.Year.ToString(), disk.Count.ToString(), disk.Price.ToString() });
                listView1.Items[index] = item;
                item.Selected = true;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int index = listView1.SelectedIndices[0];
            Program.DiskList.RemoveAt(index);
            listView1.Items[index].Remove();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            button6.Enabled = listView2.SelectedIndices.Count != 0;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int index = listView2.SelectedIndices[0];
            Program.RequestList.RemoveAt(index);
            listView2.Items[index].Remove();
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            button20.Enabled = listView3.SelectedIndices.Count != 0;
            listView4.Items.Clear();
            if (listView3.SelectedIndices.Count != 0)
            {
                int index = listView3.SelectedIndices[0];
                foreach (RentalDisk rDisk in Program.CustomerList[index].RentalDisks)
                {
                    ListViewItem item = new ListViewItem(new string[] { rDisk.Name, rDisk.Genre,
                        rDisk.Year.ToString(), rDisk.BringBackDate.ToString() });
                    listView4.Items.Add(item);
                }
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            int index = listView3.SelectedIndices[0];
            Program.CustomerList.RemoveAt(index);
            listView3.Items[index].Remove();
        }

    }
}
