using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace _03___DependencyInjection.Cars
{
    public class BMW : ICar
    {
        private int _miles = 0;

        //[Dependency]
        public IMonitor Monitor { get; set; }
        [InjectionConstructor]
        public BMW() { }

        public BMW(IMonitor monitor)
        {
            Monitor = monitor;
        }
        public int Run()
        {
            return ++_miles;
        }
    }
}
