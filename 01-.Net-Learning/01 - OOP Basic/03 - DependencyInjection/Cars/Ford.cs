using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03___DependencyInjection.Cars
{
    public class Ford : ICar
    {
        private int _miles = 0;

        public int Run()
        {
            return ++_miles;
        }
    }
}
