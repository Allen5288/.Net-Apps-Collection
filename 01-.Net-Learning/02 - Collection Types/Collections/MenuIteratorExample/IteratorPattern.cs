using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CollectionsBasic.MenuIteratorExample
{
    /// <summary>
    /// 6. IEnumerable 为所有的数据集合 提供了统一的数据访问方式
    ///    所以实现了IEnumerable的类 都可以通过foreach来访问    
    /// </summary>
    public class IteratorPattern
    {
        KFCMenu kFCMenu = new KFCMenu();
        MacDonaldMenu macDonaldMenu = new MacDonaldMenu();
        KFCMenu_In_Tree_Structure kFCMenuAdvance = new KFCMenu_In_Tree_Structure();

        public void TestKFC()
        {
            Food[] foods = kFCMenu.GetFoods();
            //6.1 当需要遍历时 假设如果Array没有实现 IEnumerable 接口
            //需要下面的代码 去for循环 通过比较 数组Length属性
            for (int i = 0; i < foods.Length; i++) { }
        }

        public void TestMacDonald()
        {
            List<Food> foods = macDonaldMenu.GetFoods();
            //6.1 当需要遍历时 假设如果List 没有实现 IEnumerable 接口
            //需要下面的代码 去for循环 通过比较 List的Count属性
            for (int i = 0; i < foods.Count; i++) 
            {
                Food f = foods[i];
                Console.WriteLine($"Macdonald {f.Id} {f.Name} {f.Price}");
            }
        }

        public void TestKFC_TreeMenu()
        {
            BinaryTree foods = kFCMenuAdvance.GetFoods();
            //以Tree的形式保存 没有Length也没有Count 就要根据保存的结构 自己写遍历的方法
            foods.PreOrderTraversal();
        }

        //6.2 上面由于列表类型的不同 产生了不同的代码实现 不知道是Count还是Length?
        //如果有统一的访问方式 ---> 岂不是很好? 
        public void TestIterator()
        {
            //6.2.1 通过实现相同的接口 KFC和Macdonald屏蔽了 一个是Length 另一个是Count的差异 

            KFCMenuIterator kfcmenuIterator = new KFCMenuIterator(kFCMenu);
            MacdonalMenuIterator macdonaldmenuIterator = new MacdonalMenuIterator(macDonaldMenu);
            KFCTreeMenuIterator kFCTreeMenuIterator = new KFCTreeMenuIterator(kFCMenuAdvance);

            //大家可以通过相同的方式来遍历了
            while (kfcmenuIterator.MoveNext())
            {
                Food f = kfcmenuIterator.Current;
                Console.WriteLine($"KFC {f.Id} {f.Name} {f.Price}");
            }

            while (macdonaldmenuIterator.MoveNext())
            {
                Food f = macdonaldmenuIterator.Current;
                Console.WriteLine($"Macdonald {f.Id} {f.Name} {f.Price}");
            }

            while (kFCTreeMenuIterator.MoveNext())
            {
                Food f = kFCTreeMenuIterator.Current;
                Console.WriteLine($"Tree KFC: {f.Id} {f.Name} {f.Price}");
            }

            //6.2.2 在原来的KFCMenu 和 MacDonaldMenu 新增两个 方法返回Enumerator
            IIterator<Food> kIterator = kFCMenu.GetEnumerator();
            IIterator<Food> mIterator = macDonaldMenu.GetEnumerator();
            IIterator<Food> kfcTreeIterator = kFCMenuAdvance.GetEnumerator();

            while (kIterator.MoveNext())
            {
                Food f = kIterator.Current;
                Console.WriteLine($"KFC {f.Id} {f.Name} {f.Price}");
            }

            while (mIterator.MoveNext())
            {
                Food f = mIterator.Current;
                Console.WriteLine($"Macdonald {f.Id} {f.Name} {f.Price}");
            }

            while (kfcTreeIterator.MoveNext())
            {
                Food f = kfcTreeIterator.Current;
                Console.WriteLine($"Tree KFC {f.Id} {f.Name} {f.Price}");
            }

            //6.2.3 使用for each来遍历 因为有GetEnumerator()方法 --
            //注意在C#中 IEnumerable接口定义了这个方法 所有实现了IEenumerable接口的类 一定能for each遍历
            //但是 并不是说 只有实现了IEnumerable 接口得类才能for each, 只要类有GetEnumerator() 方法就可以for each

            // 要想foreach 需要实现 IEnumerable接口  ==> 只要有GetEnumerator()方法
            // 只要有GetEnumerator()方法就能foreach
            foreach (var s in kFCMenu)
            {
                Console.WriteLine($"{s.Id} - {s.Name}: {s.Price}");
            }

            foreach (var t in macDonaldMenu)
            {
                Console.WriteLine($"{t.Id} - {t.Name}: {t.Price}");
            }

            foreach (var f in kFCMenuAdvance)
            {
                Console.WriteLine($"Tree KFC {f.Id} - {f.Name}: {f.Price}");
            }
        }

        //6.3 看看C# 自己定义的 类 它们都实现了自己的GetEnumerator方法 
        public void CSharpIterator()
        {
            //C# 的IEnmerator 就是我们自己定义的 IIterator
            IEnumerator i = kFCMenu.GetFoods().GetEnumerator();

            //下面的例子都实现了自己的IEnumerable.GetEnmerator方法
            ArrayList s = new ArrayList();
            List<int> t = new List<int>();
            SortedList<string, string> ss = new System.Collections.Generic.SortedList<string, string>();
        }

        //那么C# 中各种各样的 List, HashSet, Array ArrayList, Dictionary 等等 它们都有自己的GetEnumerator()的实现，
        //实现这些不同的Enumerator 就是实现 IEnumerator 接口 F12看这个接口 它的方法跟我们自己定义的IIterator是一样的

        //6.5 yield -  状态机返回 并不是所有数据一起返回 而是在遍历中 一个个数据返回
        //            记住了上次执行的位置

        public void UsingEnumeratorIterator()
        {
            IList<string> list = new List<string>
            {
                "This",
                "is",
                "test",
                "custom iterator"
            };

            // list.Where
            var result = list.Where(x =>
            {
                Console.WriteLine($"checking {x}");
                return x.Length > 2;
            });

            foreach (var item in result)
            {
                Console.WriteLine($"filtered result {item}");
            }
        }
    }
}
