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
    public partial class ChooseFilm : Form
    {
        public Customer Customer { get; set; }
        public ChooseFilm()
        {
            InitializeComponent();
        }

        private void ChooseFilm_Load(object sender, EventArgs e)
        {
            foreach (Disk disk in Program.DiskList)
            {
                double price = disk.Price;
                if (Customer.usingCount >= 5)
                    price -= price * 0.25;
                ListViewItem item = new ListViewItem(
                    new string[] { disk.Name, disk.Genre, disk.Year.ToString(), disk.Count.ToString(), price.ToString() });
                listView1.Items.Add(item);
            }
            foreach (RentalDisk rDisk in Customer.RentalDisks)
            {
                ListViewItem item = new ListViewItem(new string[] { rDisk.Name, rDisk.Genre,
                        rDisk.Year.ToString(), rDisk.BringBackDate.ToShortDateString() });
                listView2.Items.Add(item);
            }
        }

        private void button4_Click(object sender, EventArgs e)// add film
        {
            if (textBox1.TextLength == 0)
            {
                MessageBox.Show("Неправильный ввод названия фильма!");
                return;
            }
            Program.RequestList.Add(textBox1.Text);
            MessageBox.Show("Фильм " + textBox1.Text + " добавлен в заявки!");
        }

        private void button3_Click(object sender, EventArgs e) // exit profile
        {
            Close();
        }

        private void ChooseFilm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AdminFeatures frm = new AdminFeatures();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = listView1.SelectedIndices[0];
            Rent.incrPrice = Double.Parse((listView1.Items[index].SubItems[4].Text));
            Rent formRent = new Rent();
            formRent.textBox1.Text = listView1.Items[index].SubItems[0].Text;
            //.Replace('.',','));
            //formRent.textBox2.Text = listView1.Items[index].SubItems[4].Text;
            if (formRent.ShowDialog() == DialogResult.OK)
            {
                listView2.Select();
                int countFilm = Convert.ToInt32(listView1.Items[index].SubItems[3].Text);
                countFilm--;
                if (countFilm >= 0)
                {
                    listView1.Items[index].SubItems[3].Text = Convert.ToString(countFilm);
                    Program.DiskList[index].Count = countFilm;
                }
                else
                {
                    MessageBox.Show("Нет в наличии!");
                    countFilm = 0;
                    return;
                }
                RentalDisk rDisk = new RentalDisk(listView1.Items[index].SubItems[0].Text, listView1.Items[index].SubItems[1].Text,
                    int.Parse(listView1.Items[index].SubItems[2].Text), DateTime.Now.AddDays((double)formRent.numericUpDown1.Value));
                Customer.RentalDisks.Add(rDisk);
                Customer.usingCount++;
                ListViewItem item = new ListViewItem(new string[] { rDisk.Name, rDisk.Genre,
                        rDisk.Year.ToString(), rDisk.BringBackDate.ToShortDateString() });
                listView2.Items.Add(item);
                item.Selected = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int indexFilm = 0;
            int index = listView2.SelectedIndices[0];
            //вывод информационного сообщения 
            for (int i = 0; i<listView1.Items.Count; i++)
            {
                if (String.Equals(listView2.Items[index].SubItems[0].Text, listView1.Items[i].SubItems[0].Text) && String.Equals(listView2.Items[index].SubItems[1].Text, listView1.Items[i].SubItems[1].Text) && String.Equals(listView2.Items[index].SubItems[2].Text, listView1.Items[i].SubItems[2].Text))
                {
                    indexFilm = i;
                }
            }

            int countFilm = Convert.ToInt32(listView1.Items[indexFilm].SubItems[3].Text);
            countFilm++;
            listView1.Items[indexFilm].SubItems[3].Text = Convert.ToString(countFilm);
            Program.DiskList[indexFilm].Count = countFilm;


            MessageBox.Show("Верните клиенту " + listView1.Items[indexFilm].SubItems[4].Text + " грн. и выдайте чек");
            Customer.RentalDisks.RemoveAt(index);
            listView2.Items[index].Remove();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = listView1.SelectedIndices.Count != 0;
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Enabled = listView2.SelectedIndices.Count != 0;
        }

    }
}
