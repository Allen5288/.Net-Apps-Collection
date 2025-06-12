using _03___DependencyInjection.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03___DependencyInjection
{
    public class Driver
    {
        private ICar _car = null;
        private string _name = string.Empty;

        //none carries the InjectionConstructor attribute, Unity will use the constructor with the most parameters
        //仅仅针对Unity container已知的 它能resolve的
        public Driver(ICar car, ICar car2, string s)
        {
            _car = car;
            _name = s;
        }
        public Driver(ICar car, ICar car1)
        {
            _car = car;
        }

        //[InjectionConstructor]
        public Driver(ICar car)
        {
            _car = car;
        }

        public Driver() { }


        public void RunCar()
        {
            Console.WriteLine("Running {0} - {1} mile ", _car.GetType().Name, _car.Run());
        }
    }
}
