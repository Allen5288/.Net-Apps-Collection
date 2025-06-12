using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01___OOP_Basic._05_phone_Inheritance.Phone
{
    public class Huawei : BasePhone
    {
        public void SystemInfo()
        {
            Console.WriteLine($"{GetType().Name} system is Huawei");
        }

        /// <summary>
        /// 子类定义了和父类同名的方法 将hide掉父类的方法 
        /// 编译器会有一个warning 提示你
        /// </summary>
        public void Call()
        {
            Console.WriteLine($"From Huwwei {GetType().Name} calling");
        }
        //用new 关键字隐藏掉父类中的同名方法
        //public new void Call()
        //{
        //    Console.WriteLine($"From Huawei {GetType().Name} calling");
        //}        
    }
}
