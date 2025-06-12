using _03___DependencyInjection.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace _03___DependencyInjection
{
    internal class Customer
    {
        Driver _driver;
        string _firstName;
        #region - 多个构造函数 Unity容器"尽力"去寻找它能理解的那个方法 为你创建实例对象, 如果它不能决定, 那就调用无参构造函数

        public Customer() { }
        public Customer(Driver driver)
        {
            _driver = driver;
        }

        [InjectionConstructor()]
        public Customer(Driver driver, ICar car)
        {
            _driver = driver;
        }

        // Unity容器的自动寻找功能 并不是你想要的 那么可以显示使用下面的 特性 来告诉它 就用这个构造函数
        [InjectionConstructor()]
        //如果有两个构造函数都有这个特性设置 调用先申明的那个(即上面的构造函数)
        //如果下面的构造函数先定义, 这里会报错 不知道如何构造string类型的实例
        public Customer(Driver driver, string i)
        {
            _driver = driver;
            _firstName = i;
        }

        public Customer(Driver driver, string i, string j)
        {
            _driver = driver;
            _firstName = i;
        }
        #endregion


        public void CallDriver()
        {
            _driver.RunCar();
        }
    }
}
