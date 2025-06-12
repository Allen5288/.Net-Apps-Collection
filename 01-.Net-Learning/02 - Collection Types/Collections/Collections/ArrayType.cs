using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CollectionsBasic.Collections
{
    public class ArrayType
    {
        // 1. Sequential storage types include Array, ArrayList, List, List<T>
        // Characteristics: Can be accessed via index, fast read access, slow insertion and deletion

        public ArrayType() { }

        #region 1.1 Array definitions must be fixed-length and consistent in type
        //1.1.1 - Several ways to define arrays, regardless of which method, the length is fixed
        private int[] ints = new int[10];
        private int[] ints2 = new int[] { 2, 3, 4, 5 };
        private int[] ints3 = new int[] { 1, 2, 3, 4, 5 };
        //1.1.2 - Cannot assign values beyond the bounds
        public void ArrayShow()
        {
            ints[9] = 1;
            //1.1.2 - The following code will throw an exception: System.IndexOutOfRangeException: 'Index was outside the bounds of the array.
            try
            {
                ints[10] = 2;
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}");
            }
        }

        //1.1.3 - Explanation of how arrays are allocated in memory: contiguous allocation makes reading fast but insertion and deletion slow
        //      Based on its memory allocation method, arrays are suitable for scenarios where data needs to be frequently read but rarely modified
        #endregion

        #region 1.2 ArrayList - Addressing the fixed-length limitation of arrays, it supports variable length while still being contiguously allocated in memory
        //1.2.1 ArrayList has no length limit
        //1.2.2 Can store any type - all types are boxed as objects, so boxing operations occur
        private ArrayList arrayList = new ArrayList();
        public void ArrayListShow()
        {
            arrayList.Add(1);
            arrayList.Add("abc");
            arrayList.Add(new object());

            //1.2.3 ArrayList has no length limit and can continuously add items using the .Add method, but accessing non-existent indices will throw errors similar to Array. The code below will throw an exception - exceeding length
            try
            {
                arrayList[3] = 33;
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}");
            }
            //1.2.4 When retrieving values, all stored values are treated as object type, which is the boxing operation (all data types are converted to object when stored). Check the type of t below.
            var t = arrayList[0];
            //1.2.5 You know that the retrieved value is an integer, so you use unboxing to assign it to an integer variable
            int s = (int)t;
        }
        #endregion

        #region 1.3 Generic List: ArrayList solves Array's fixed-length limitation but introduces type-unsafe boxing and unboxing performance loss. So is there a data type that has no length restriction and is type-safe?
        //1.3.1 The answer is generic List<T>, which is also stored contiguously in memory. It can be accessed via index
        //This corresponds to generics we discussed earlier
        //In actual development work, we may use List type more often than Array and ArrayList types
        //Type safe, no boxing and unboxing               
        private List<string> stringList = new List<string>();
        public void StringListShow()
        {
            //1.3.2 Accessing a non-existent index will throw an exception like above

            //var s = stringList[0];
            //stringList[0] = "s";

            stringList.Add("sss");
            List<int> intList = new List<int>();
            intList.Add(1);
            intList.Add(2);
            intList.Add(4);

            //1.3.3 Items can be deleted by value or by index position
            intList.RemoveAt(0);
            intList.Remove(2);

            //1.3.3 The deletion operation below will not throw an exception if the value 40 does not exist
            intList.Remove(40);
        }
        #endregion
    }
}
