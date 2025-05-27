namespace _21Methods_FindMaxOfTwoIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Find maximum of two integers
            int max=GetMax(5, 6);
            Console.WriteLine(max);
            Console.ReadKey();
        }

        public static int GetMax(int n1,int n2)
        {
            return n1>n2 ? n1 : n2;
        }
    }
}
