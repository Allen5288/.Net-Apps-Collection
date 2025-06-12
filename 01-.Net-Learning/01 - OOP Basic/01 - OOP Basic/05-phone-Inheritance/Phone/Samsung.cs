using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01___OOP_Basic._05_phone_Inheritance.Phone
{
    public class Samsung : BasePhone
    {
        public void SystemInfo()
        {
            Console.WriteLine($"{GetType().Name} system is Android");
        }
    }
}
