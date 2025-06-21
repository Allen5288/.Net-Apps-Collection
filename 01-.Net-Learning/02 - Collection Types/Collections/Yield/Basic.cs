using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CollectionsBasic.Yield
{
    public class Basic_1
    {
        //https://medium.com/@zaynt.dev/understanding-yield-return-in-c-a-deep-dive-into-lazy-iteration-7cedc2ecfc1b
        //https://medium.com/@stitti/mastering-ienumerable-in-c-unraveling-the-intricacies-of-deferred-execution-performance-5f50e23ec18c
        //foreach loop iterates over the numbers,
        //requesting one at a time, and the method pauses after each yield return until the next value is needed
        public void ReturnNumbers()
        {
            //ToList() method 已经将所有元素都取出来了 
            //IList<int> t = GenerateNumbers().ToList();
            IEnumerable<int> t = GenerateNumbers();

            foreach (int number in t)
            {
                Console.WriteLine(number);
            }
        }

        //GenerateNumbers() method uses yield return to return each number in sequence
        private IEnumerable<int> GenerateNumbers()
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }
    }
}
