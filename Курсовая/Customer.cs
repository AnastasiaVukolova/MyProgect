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
    public class Customer
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public List<RentalDisk> RentalDisks { get; set; }
        public int usingCount { get; set; }
        public string phonen;
        public string emailc;

        public Customer(string login, string password, string phone, string email)
        {
            Login = login;
            Password = password;
            RentalDisks = new List<RentalDisk>();
            usingCount = 0;
            phonen = phone;
            emailc = email;

        }
    }
}
