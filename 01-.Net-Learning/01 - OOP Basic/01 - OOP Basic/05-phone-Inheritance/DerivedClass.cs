using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01___OOP_Basic._05_phone_Inheritance
{
    class DerivedClass : BaseClass
    {

        public override void Method1()
        {
            Console.WriteLine("Derived - Method1");
        }

        public new void Method2()
        {
            base.Method2();
            Console.WriteLine("Derived - Method2");
        }
    }
}
