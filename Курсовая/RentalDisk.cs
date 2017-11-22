using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая
{
    [Serializable]
    public class RentalDisk
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public DateTime BringBackDate { get; set; }

        public RentalDisk(string name, string genre, int year, DateTime bbd)
        {
            Name = name;
            Genre = genre;
            Year = year;
            BringBackDate = bbd;
        }
    }
}
