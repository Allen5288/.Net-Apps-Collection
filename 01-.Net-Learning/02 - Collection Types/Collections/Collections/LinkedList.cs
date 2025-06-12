using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CollectionsBasic.Collections
{
    internal class LinkedList
    {
        #region Doubly Linked List
        // 2. LinkedList<T> is stored non-sequentially in memory, fast insertion/deletion, slow search
        // Each element records previous and next nodes - LinkedListNode type
        // 2.1 Can we access by index? - Q: Understand why not - because it's not sequential/continuous storage, so index position is unknown
        // var s = values[0];
        LinkedList<string> values = new LinkedList<string>();

        public void LinedListMethod()
        {
            //2.2 It doesn't have Add method because it doesn't know where to add, you need to tell it where you want to add. See main methods for adding nodes at head and tail
            values.AddFirst("sss");
            values.AddLast("bbb");


            //2.3 The following methods directly return the stored value
            var t = values.First();
            var t1 = values.First(x => x == "sss");

            //2.4 Note that the First property and Find method below return a LinkedListNode type variable which has previous and next pointers to adjacent nodes (this is why it's called a doubly linked list)
            var foundNode = values.Find("sss");
            var firstNode = values.First;

            //2.5 Some Add* methods also have return values, type is also LinkedListNode
            var addedNode = values.AddFirst("1111");
            LinkedListNode<string> t2 = values.AddLast("aaa");

            //2.6 The Add methods above have another overload form that directly takes a LinkedListNode variable, then there's no return value
            values.AddFirst(new LinkedListNode<string>("2222"));

            foreach (var s in values)
            {
                Console.WriteLine(s);
            }

            values.Remove("1111");
            values.RemoveFirst();
            values.RemoveLast();
            //The Remove method below will throw an exception because the RemoveLast() above already deleted the "aaa" Node
            //values.Remove(t2);
        }
        #endregion
    }
}
