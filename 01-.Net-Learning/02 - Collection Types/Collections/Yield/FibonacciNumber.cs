using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CollectionsBasic.Yield
{
    public class FibonacciNumber_2
    {
        public void ReturnFibonacci()
        {
            int count = 10;
            //Instead of generating all 10 numbers at once, they are computed on demand,
            //which can save memory in case of large or infinite sequences


            //Thinking about Infinite Sequences
            //Sequences like the Fibonacci sequence or generating numbers infinitely (e.g., counting) are ideal use cases for yield return.
            //You can keep generating values on demand without worrying about memory usage.
            count = int.MaxValue;
            foreach (int number in GetFibonacciSequence(count))
            {
                Console.WriteLine(number);
            }
        }

        //Lazy Evaluation Only one Fibonacci number is generated and returned at a time using yield return        
        private IEnumerable<int> GetFibonacciSequence(int count)
        {
            int previous = 0, current = 1;

            for (int i = 0; i < count; i++)
            {
                yield return previous;

                int next = previous + current;
                previous = current;
                current = next;
            }
        }
    }
}
