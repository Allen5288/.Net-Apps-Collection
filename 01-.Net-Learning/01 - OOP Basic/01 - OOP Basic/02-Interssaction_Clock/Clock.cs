using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01___OOP_Basic.Interssaction_Clock
{
    internal class Clock
    {

        private Display _hour = new Display(24);
        private Display _minute = new Display(60);

        public void Start()
        {
            while (true)
            {
                _minute.Increment();
                if (_minute.DisplayValue() == 0)
                {
                    _hour.Increment();
                }

                Console.WriteLine($"Current Time: {_hour.DisplayValue():D2}:{_minute.DisplayValue():D2}");
                
                System.Threading.Thread.Sleep(10); // Sleep for 10 milliseconds

            }
        }
    }
}