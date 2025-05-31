using _01___OOP_Basic.Inheri_MediaLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01___OOP_Basic._03_Inheri_MediaLibrary
{
    public class MediaDatabase
    {
        private List<CD> cds = new List<CD>();
        private List<DVD> dvds = new List<DVD>();
        public void AddCD(CD cd)
        {
            cds.Add(cd);
        }
        public void AddDVD(DVD dvd)
        {
            dvds.Add(dvd);
        }
        public void PrintAllMedia()
        {
            Console.WriteLine("CDs:");
            foreach (var cd in cds)
            {
                cd.Print();
            }
            Console.WriteLine("DVDs:");
            foreach (var dvd in dvds)
            {
                dvd.Print();
            }
        }
    }
}
