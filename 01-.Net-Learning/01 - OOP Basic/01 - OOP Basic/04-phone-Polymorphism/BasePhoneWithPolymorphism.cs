using _01___OOP_Basic._05_phone_Inheritance.Phone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01___OOP_Basic._04_phone
{
    public abstract class BasePhoneWithPolymorphism
    {
        #region 无条件被迫继承的属性和方法
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int VersionNo { get; set; }

        public void Call()
        {
            Console.WriteLine($"{GetType().Name} calling");
        }

        public void Text()
        {
            Console.WriteLine($"{GetType().Name} messaging");
        }

        public virtual void VirtualCall()
        {
            Console.WriteLine($"{GetType().Name} VirtualCall");
        }

        protected virtual void ProtectedMethod()
        {
            Console.WriteLine($"{GetType().Name} ProtectedMethod");
        }

        public void PlayGame(Game game)
        {
            game.Start();
        }
        #endregion

        #region 允许差异化的方法 定义为抽象的
        //要注意抽象方法必须定义在抽象类中 所以必须将类定义为abstract的
        public abstract void SystemInfo();
        #endregion
    }
}
