using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01___OOP_Basic._04_phone
{
    public interface IExtend
    {

        //1. 接口不能有实现 - 但是自C#8.0后引入了接口默认方法 并且允许 delegate class inside interface 如下所示：(但是从面向对象角度和接口的用处 不推荐)
        delegate void Action();
        class NestedClass { }
        //接口不能有field(字段)
        //public string s;
        //但是接口可以有属性 - 所有实现该接口的class要实现该属性
        //public string s2 { get; set; }

        //2. 接口可以定义event 索引器
        event Action ActionHandler;
        int this[int index] { get; }

        //3. 自从C# 8.0后 接口可以有默认方法实现
        public void Video()
        {
            Console.WriteLine($"Interface video");
            NestedClass c = new NestedClass();
        }

        void Video(int i);

        //下面如果在接口类新增一个方法 如果没有默认实现 所有实现该接口的类都会编译出错
        //如果有了默认实现 就不会报错
        public void NewVideoV2()
        {
            Console.WriteLine($"This is new version 2 method.");
        }
    }
}
