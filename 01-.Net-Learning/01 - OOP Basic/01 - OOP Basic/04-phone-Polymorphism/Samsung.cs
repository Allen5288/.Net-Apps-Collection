using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01___OOP_Basic._04_phone
{
    public class Samsung : BasePhoneWithPolymorphism
    {
        public override void SystemInfo()
        {
            Console.WriteLine($"{GetType().Name} system is Android");
        }
    }
}
