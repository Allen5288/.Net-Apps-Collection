using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01___OOP_Basic._06_PolymorphismExmaple
{
    class A
    {
        public virtual void Foo()
        {
            Console.WriteLine("A's method");
        }
    }

    class B : A
    {
        public override void Foo()
        {
            Console.WriteLine("B's method");
        }
    }

    class C : B
    {
        // new 和 override不能同时用作方法中
        //public new override void Foo()
        //{

        //}

        //不能同时override基类的方法 又以隐藏new的方式定义一个同名的自己的方法
        //public override void Foo() { }

        //下面的方法hide了基类的Foo()方法, 推荐显示使用new
        //定义为virtual 的表示C的子类可以override它 提供自己的实现
        public virtual void Foo()
        {
            base.Foo();
            Console.WriteLine("C's method");
        }
        //public new virtual void Foo()
        //{
        //    base.Foo();
        //    Console.WriteLine("C's method");
        //}

    }

    class D : C
    {
        public override void Foo()
        {
            base.Foo();//这里的基类的Foo()方法 是C中的New的方法
            Console.WriteLine("D's method");
        }
    }

    //为了调用D自己的Foo方法-直接将D继承于B
    //class D : B
    //{
    //    public override void Foo()
    //    {
    //        Console.WriteLine("D's method");
    //    }
    //}

    class E : B
    {
        public override void Foo()
        {
            Console.WriteLine("E's method");
        }
    }
}
