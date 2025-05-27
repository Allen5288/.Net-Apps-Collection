using System;

namespace _15ExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //No syntax errors
            //Console.WriteLine("Please enter a number");
            //int num=Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine(num*2);
            //Console.ReadKey();

            //Using try catch
            Console.WriteLine("Please enter a number");
           int num=0;
            try
            {
                num = Convert.ToInt32(Console.ReadLine());

            }
            catch (Exception)
            {
                Console.WriteLine("The input content cannot be converted to a number");
            }
            finally { 

            }
            Console.WriteLine(num * 2);
            Console.ReadKey();


        }
    }
}
