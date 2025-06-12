using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CollectionsBasic.Collections
{
    /// <summary>
    /// 3. 队列和栈 - 就是链表的形式 典型的消息队列 (先进先出) 栈(先进后出)
    /// 使用场景 任务或者消息队列 --> 多个线程 写入日志, 一个线程专门处理日志
    /// </summary>
    public class QueueStack_3
    {
        Queue<string> numbers = new Queue<string>();
        public void QueueMethod()
        {
            numbers.Enqueue("111");
            numbers.Enqueue("222");
            numbers.Enqueue("333");

            foreach (string number in numbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine($"Dequeuing {numbers.Dequeue()}");
            Console.WriteLine($"Peek {numbers.Peek()}");

            numbers.Clear();
        }

        //3.1 栈的使用场景 -- 先产生的数据后使用 表达式解析(例如数学表达式的解析 就是一个很好的应用例子)
        //3.1.1 试试看(建议在纸上动手画一画 pop 和 push的过程来加深理解) 如何使用栈来进行 数学表达式的解析 (3+4*5)  (3+4*5-6) {定义两个栈 一个保存数字 一个保存操作符; 定义运算符优先顺序}
        //      https://www.geeksforgeeks.org/expression-evaluation/
        Stack<string> stackNumbers = new Stack<string>();
        public void StackMethod()
        {
            stackNumbers.Push("111");
            stackNumbers.Push("222");
            stackNumbers.Push("333");

            foreach (string number in stackNumbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine($"Pop {stackNumbers.Pop()}");
            Console.WriteLine($"Peek {stackNumbers.Peek()}");
            stackNumbers.Clear();
        }

        //End - 课后作业 思考下 可不可以自己根据LinkedList来写一个 Queue/Stack? - 主要就是实现 Pop/Push Enqueue/Dequeue Peek方法
    }
}
