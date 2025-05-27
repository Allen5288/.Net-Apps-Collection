namespace _09ComplexOperators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //++ after
            //int number = 10;
            //number++;
            //Console.WriteLine(number);
            //Console.ReadKey();

            //++ before
            //int number = 10;
            //++number;
            //Console.WriteLine(number);
            //Console.ReadKey();

            //Put in result, post-increment
            //int number = 10;
            //int result = 10 + number++;
            //Console.WriteLine(number);
            //Console.WriteLine(result);
            //Console.ReadKey();

            //Put in result, pre-increment
            int number = 10;
            int result = 10 + ++number;
            Console.WriteLine(number);
            Console.WriteLine(result);
            Console.ReadKey();

        }
    }
}
