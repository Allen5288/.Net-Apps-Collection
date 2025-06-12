using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01___OOP_Basic._04_phone
{
    public class iPhone : BasePhoneWithPolymorphism, IExtend
    {
        public int this[int index] => throw new NotImplementedException();

        public event IExtend.Action ActionHandler;

        public override void SystemInfo()
        {
            Console.WriteLine($"{GetType().Name} system is iOS");
        }

        public override void VirtualCall()
        {
            //base.VirtualCall();
            Console.WriteLine($"{GetType().Name} VirtualCall");
        }

        public void Video()
        {
            Console.WriteLine($"Video from iPhone");
        }

        public void Video(int i)
        {
            Console.WriteLine($"Video from iPhone {i}");
        }
    }
}
