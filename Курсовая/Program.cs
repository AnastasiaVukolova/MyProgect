using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Курсовая
{
    static class Program
    {
        public static List<Disk> DiskList = new List<Disk>();
        public static List<string> RequestList = new List<string>();
        public static List<Customer> CustomerList = new List<Customer>();
        public static List<Admin> AdminList = new List<Admin>();
        public static StartPage startPage;

        public static void LoadFromFile(string filename)
        {
            try
            {
                FileStream fileStream = new FileStream(filename, FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                try
                {
                    object[] Lists = (object[])formatter.Deserialize(fileStream);
                    DiskList = (List<Disk>)Lists[0];
                    RequestList = (List<string>)Lists[1];
                    CustomerList = (List<Customer>)Lists[2];
                    AdminList = (List<Admin>)Lists[3];
                }
                finally
                {
                    fileStream.Close();
                }
            }
            catch
            {
                throw new Exception();
            }
        }
        public static void SaveToFile(string filename)
        {
            try
            {
                FileStream fileStream = new FileStream(filename, FileMode.OpenOrCreate);
                BinaryFormatter formatter = new BinaryFormatter();
                try
                {
                    formatter.Serialize(fileStream, new object[] { DiskList, RequestList, CustomerList, AdminList });
                }
                finally
                {
                    fileStream.Close();
                }
            }
            catch
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
           // MessageBox.Show(this, "Error! Incorrect input!", Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            startPage = new StartPage();
            Application.Run(startPage);
        }
    }

}
