using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CollectionsBasic.Collections
{
    #region 4. 集合 Set
    public class HashCollection_4
    {
        #region 4.1 HashSet 元素间的存放位置没有关系 既不是连续分配 又不是链表方式
        //    特点 动态增加 去重 元素间没有关系 hash方式存放

        HashSet<string> stringHashSet = new HashSet<string>();
        public void TestHashCollection()
        {
            stringHashSet.Add("123");
            stringHashSet.Add("456");
            stringHashSet.Add("789");
            stringHashSet.Add("1234");
            stringHashSet.Add("456");
            stringHashSet.Add("789");

            //下面的代码演示HashSet它不是链表结构的 所以它没有First/Last属性 - 与LinkedList不同
            //如果你看到First()方法 - 它是IEnumerable的扩展方法 不是HashSet自己的
            //stringHashSet.First();


            //4.1.1 因为它不是连续分布的 所以不能通过索引坐标访问
            //stringHashSet[0];

            //4.1.2 自带去重功能 - 下面的代码只会输出4个items.
            foreach (string s in stringHashSet)
            {
                Console.WriteLine(s);
            }
        }


        #region 4.1.2 介绍一下 HashSet 的使用场景 -- 需要自动去重的情况(投票 - 根据不同的IP地址来 统计投票数)
        //    为什么HashSet会自带去重功能呢? - HashSet自身有一个HashMap 通过计算元素的哈希值 如果Map中已经有了同样的Hash值 那就不会放入
        //    注意 - 不同对象的Hash值是不同的
        class Person
        {
            public string Name { get; set; }
        }
        public void TestObjectHash()
        {
            HashSet<Person> hashSetObjects = new HashSet<Person>();
            hashSetObjects.Add(new Person { Name = "P1" });
            hashSetObjects.Add(new Person { Name = "P1" });

            foreach (var item in hashSetObjects)
            {
                Console.WriteLine(item.Name);
            }
        }
        #endregion

        #region 4.1.3 交差并补 操作
        //4.1.3.1 除了常规的 Add Remove Clean Contains HashSet有几个特别的操作方法

        #region 4.1.3.1 ExceptWith - 差(从当前HashSet中删除掉所有包含在指定HashSet中的元素)
        // ExceptWith(System.Collections.Generic.IEnumerable<T> other)
        public void ExceptWith_Demo()
        {
            HashSet<int> lowNumbers = new HashSet<int>();
            HashSet<int> highNumbers = new HashSet<int>();

            for (int i = 0; i < 6; i++)
            {
                //0,1,2,3,4,5
                lowNumbers.Add(i);
            }

            for (int i = 3; i < 10; i++)
            {
                //3,4,5,6,7,8,9,10
                highNumbers.Add(i);
            }

            Console.Write("lowNumbers contains {0} elements: ", lowNumbers.Count);
            DisplaySet(lowNumbers);

            Console.Write("highNumbers contains {0} elements: ", highNumbers.Count);
            DisplaySet(highNumbers);

            Console.WriteLine("highNumbers ExceptWith lowNumbers...");
            highNumbers.ExceptWith(lowNumbers);

            Console.Write("highNumbers contains {0} elements: ", highNumbers.Count);
            DisplaySet(highNumbers);
        }
        #endregion

        #region IntersectWith - 交集 - 修改当前的HashSet集合 使其仅仅包含另一个集合中存在的元素
        public void IntersectWith_Demo()
        {
            HashSet<int> lowNumbers = new HashSet<int>();
            HashSet<int> highNumbers = new HashSet<int>();

            for (int i = 0; i < 6; i++)
            {
                lowNumbers.Add(i);
            }

            for (int i = 3; i < 10; i++)
            {
                highNumbers.Add(i);
            }

            Console.Write("lowNumbers contains {0} elements: ", lowNumbers.Count);
            DisplaySet(lowNumbers);

            Console.Write("highNumbers contains {0} elements: ", highNumbers.Count);
            DisplaySet(highNumbers);

            highNumbers.IntersectWith(lowNumbers);
            Console.Write("highNumbers contains {0} elements: ", highNumbers.Count);
            DisplaySet(highNumbers);
        }
        #endregion

        #region UnionWith - 并集 两个集合合并
        public void UnionWith_Demo()
        {
            HashSet<int> evenNumbers = new HashSet<int>();
            HashSet<int> oddNumbers = new HashSet<int>();

            for (int i = 0; i < 5; i++)
            {
                // Populate numbers with just even numbers.
                evenNumbers.Add(i * 2);

                // Populate oddNumbers with just odd numbers.
                oddNumbers.Add((i * 2) + 1);
            }

            Console.Write("evenNumbers contains {0} elements: ", evenNumbers.Count);
            DisplaySet(evenNumbers);

            Console.Write("oddNumbers contains {0} elements: ", oddNumbers.Count);
            DisplaySet(oddNumbers);

            // Create a new HashSet populated with even numbers.
            HashSet<int> numbers = new HashSet<int>(evenNumbers);
            Console.WriteLine("numbers UnionWith oddNumbers...");
            numbers.UnionWith(oddNumbers);

            Console.Write("numbers contains {0} elements: ", numbers.Count);
            DisplaySet(numbers);
        }
        #endregion

        #region SymmetricExcept - 补集 将两个集合中 各自不在对方的元素合并返回
        public void SymmetricExcept_Demo()
        {
            HashSet<int> lowNumbers = new HashSet<int>();
            HashSet<int> highNumbers = new HashSet<int>();

            for (int i = 0; i < 6; i++)
            {
                lowNumbers.Add(i);
            }

            for (int i = 3; i < 10; i++)
            {
                highNumbers.Add(i);
            }

            Console.Write("lowNumbers contains {0} elements: ", lowNumbers.Count);
            DisplaySet(lowNumbers);

            Console.Write("highNumbers contains {0} elements: ", highNumbers.Count);
            DisplaySet(highNumbers);

            Console.WriteLine("lowNumbers SymmetricExceptWith highNumbers...");
            lowNumbers.SymmetricExceptWith(highNumbers);

            Console.Write("lowNumbers contains {0} elements: ", lowNumbers.Count);
            DisplaySet(lowNumbers);
        }
        #endregion

        void DisplaySet(HashSet<int> set)
        {
            Console.Write("{");
            foreach (int i in set)
            {
                Console.Write(" {0}", i);
            }
            Console.WriteLine(" }");
        }
        #endregion
        #endregion

        #region 4.2 SortedSet 基本和HashSet类似可以去重 加上自动排序 - 使用场景: 统计排名 在元素添加的时候就直接排好序了
        SortedSet<string> sortedSet = new SortedSet<string>();
        public void TestSortedSet()
        {
            sortedSet.Add("1233");
            sortedSet.Add("A233");
            sortedSet.Add("a233");
            sortedSet.Add("utk233");
            sortedSet.Min();
            sortedSet.Max();
            //sortedSet.GetViewBetween();

            //4.2.1 查看下面的 sortedSet 它是按照 string的顺序已经排好了
            foreach (var item in sortedSet)
            {
                Console.WriteLine(item);
            }
        }
        #endregion

        #region 4.3 Key-Value 形式 
        #region 4.3.1 HashTable -和上面的集合比较 不是单个的element 而是 key-value 形式的
        //          特点： 不限数量 动态增加
        //          在内存中的存储 地址是根据key计算出其hash值
        //          (注意: 在数据量足够大的情况下 有可能存在 不同的key得到了相同的地址 那就在原来地址上+1 往后放； 当读取的时候 比较地址对应的Key 如果Key不对 就地址+1 继续查找直到找到相同的Key)
        //          所以需要一个额外的数组(空间)来保存 计算出来的数值,
        //              这个额外数组的好处 既提高了查询的速度 但是当查找的时候, 性能就得到了提高,
        //              1. 因为根据 给定的key计算出对应的 Hash值 在这个数组中查找(之前说过数组的特点是查找快速)
        //              2. 又提高了增删的速度 - 当新增或者删除的时候 计算出对应key的hash值 就行了 对内存内其他数据没有影响 没有针对内存内数据的的移动
        Hashtable table = new Hashtable();
        public void TestHashtable()
        {
            table.Add("123", 123); //123 => 0f98797978 (hash algorithm address )
            table.Add("233", 223); //233 => 0f98797978 (address 0f98797979)


            //0f98797978 ("123", 123)
            //0f98797979 ("233", 223)
            //0f98797980 ("abc", 32323)

            table[12323] = "sss";
            table["db"] = 133;
            table.Add("dkdkdk", null);

            //How to loop throught the elements in the HashTable?
            //1. Get the keys firstly
            //2. Loop through according to the key to get the value. 
            foreach (var s in table.Keys)
            {
                Console.WriteLine($"Key: {s}, Value: {table[s]}");
            }

            //保存在HashTable中的每个元素是什么类型呢? 是DictionaryEntry类型的
            //它与KeyValuePair的区别是什么呢 - KeyValuePair<T,T> 是泛型类型, 而DictionaryEntry是不支持泛型类型的，为什么：因为HashTable没有泛型类型
            //所以在遍历HashTable的时候，需要使用DictionaryEntry 类型来遍历
            //下面的会报错
            foreach (KeyValuePair s in table)
            {
                //Console.WriteLine($"Key: {s.Key}");
                //Console.WriteLine($"Value: {s.Value?.ToString()}");
            }

            foreach (DictionaryEntry item in table)
            {
                Console.WriteLine($"Key: {item.Key.ToString()}");
                //4.3.1.1 - 下面的warning提示 Value可能是空 也就是意味着我们可以将HashTable中的Value定义为空 table.Add("dkdkdk", null)                
                //Console.WriteLine($"Value: {item.Value.ToString()}");
                Console.WriteLine($"Value: {item.Value?.ToString()}");
            }
            //4.3.1.2 线程安全的HashTable - 支持同一时间只有一个线程能够修改数据
            var safeTable = Hashtable.Synchronized(table);
        }
        #endregion

        #region 4.3.2 Dictionary - 字典：也是key-value类型的 和上面的HashTable类似 性能优
        //          与HashTable的差别 ： 泛型 类型安全 且遍历时候 按照添加顺序
        Dictionary<int, string> dictionary = new Dictionary<int, string>();
        public void TestDictionary()
        {
            dictionary.Add(3, "ssslkadsjfadf");
            dictionary.Add(5, "aaalkadsjfadf");
            dictionary.Add(1, "lkadsjfadf");
            dictionary.Add(2, "dddlkad");

            foreach (KeyValuePair<int, string> s in dictionary)
            {
                Console.WriteLine($"Key {s.Key}, Value {s.Value}");
            }
        }

        //4.3.3 - 排序字典 自动按照key的顺序来排序 稍微性能差一点 因为需要排序
        SortedDictionary<int, string> sortedDictionary = new SortedDictionary<int, string>();
        //4.3.4  - 排序列表 
        //稍微提一下 SortedDictionary 和 SortedList 的区别 - 主要实在性能和内存使用方面
        // 1. 查询 二者性能差不多 都是O(logN)
        // 2. 增删 SortedDictionary 更加快 O(logN)， 而SortedList O(n)
        // 3. 内存的使用 SortedList 更较少 但是内存碎片较多
        // 4. 在内存的存储结构上 SortedDictionary使用的是 binary search tree(BST) 二叉查询树
        //    而SortedList使用的是类似 数组的方式, 根据微软官方文档 自.net Framework 4, SortedList使用了自平衡树 self-balance tree （AVL）
        SortedList<int, string> sortedList = new SortedList<int, string>();

        #endregion
        #endregion
    }
    #endregion
}
