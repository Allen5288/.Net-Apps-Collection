using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01___OOP_Basic._04_phone
{
    public class Huawei : BasePhoneWithPolymorphism, IExtend
    {
        public int this[int index] => throw new NotImplementedException();

        public event IExtend.Action ActionHandler;

        public override void SystemInfo()
        {
            Console.WriteLine($"{GetType().Name} system is Huawei");
        }

        /// <summary>
        /// 子类定义了和父类同名的方法 将hide掉父类的方法 
        /// </summary>
        public new void Call()
        {
            Console.WriteLine($"From Huawei {GetType().Name} calling");
        }

        public void Video(int i)
        {
            Console.WriteLine($"Video from Huawei {i}");

        }

        public void Video() { }

        //C# 8.0 引入了 接口默认实现后
        //有需要的类 可以实现自己的NewVideo2方法 而其它类不需要修改 也不会报错
        public void NewVideoV2()
        {
            Console.WriteLine($"This is Huawei NewVideo2 method.");
        }

        //public void Video()
        //{
        //    Console.WriteLine($"Video from Huawei");
        //}
    }
}
