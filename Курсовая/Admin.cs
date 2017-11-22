using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Курсовая
{
    [Serializable]
    public class Admin
    {
        public string FIO { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        
        public Admin (string fio, string login, string password)
        {
            FIO = fio;
            Login = login;
            Password = password;
        }
    }
}
