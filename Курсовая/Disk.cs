using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//https://itvdn.com/ru/blog/article/using-git-in-visual-studio-enterprise-2015
namespace Курсовая
{
    [Serializable]
    public class Disk
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }

        public Disk(string name, string genre, int year, int count, double price)
        {
            Name = name;
            Genre = genre;
            Year = year;
            Count = count;
            Price = price;
        }
        //public override string ToString()
        //{
        //    return Name + "\t" + Genre + "\t" + Year + "\t" + Count + "\t" + Price;
        //}
        //public override bool Equals(object obj)//
        //{
        //    if (obj == null) return false;
        //    if (obj.GetType() != this.GetType()) return false;
        //    Disk disk = (Disk)obj;
        //    return DiskName == disk.DiskName && Gener == disk.Gener && Date == disk.Date && Price == disk.Price;
        //}
    }
}

     

