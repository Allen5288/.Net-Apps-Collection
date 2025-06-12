using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CollectionsBasic.Yield
{
    ///     该方法"按需"返回数据，而不是一次提供所有的数据 - 外部在使用调用该方法的时候 遍历该迭代器方法的返回值时 数据是 one by one return的
    ///     在返回很大的数据集合的时候 yield return 是比较有效的方式 避免了将成千上万条数据一次性load到内存中 所有数据都是 load on the fly
    ///     在某些情况下 外部方法 可能在获取到一定数量的数据后 就不需要了 这时 按需返回的优势  就更加明显了 它不会load后续不需要的数据 
    public class YieldProuct_BigData
    {
        /// <summary>
        /// The Fibonacci sequence is created dynamically during iteration, 
        /// without the need to store all values in memory
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public IEnumerable<int> GenerateFibonacci(int count)
        {
            int a = 0, b = 1;
            for (int i = 0; i < count; i++)
            {
                yield return a;
                int temp = a;
                a = b;
                b += temp;
            }
        }

        /// <summary>
        /// read a large file line by line. 
        /// The code iterates through the file’s contents, generating each line only when it’s requested
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public IEnumerable<string> ReadLargeFileLineByLine(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }

        /// <summary>
        /// create an infinite sequence of integers.
        /// The sequence is generated on-the-fly, consuming minimal resources
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> GenerateInfiniteSequence()
        {
            int max = int.MaxValue;
            int min = int.MinValue;
            while (true)
            {
                yield return new Random().Next(min, max);
            }
        }
    }
}
