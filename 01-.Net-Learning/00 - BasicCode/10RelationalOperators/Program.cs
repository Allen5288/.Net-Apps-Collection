namespace _10RelationalOperators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Relational operators
            int a1 = 10;
            int b1 = 5;
            bool result = (a1 > b1);  // true
            Console.WriteLine(result);
            Console.ReadKey();

            //Elephant's weight(1500) > Mouse's weight(1)
            bool b = 1500 > 1;
            Console.WriteLine(b);
            Console.ReadKey();

            //Logical operators
            int age = 20;
            bool isAdult = (age >= 18) && (age < 60);  // true
            Console.WriteLine(isAdult);
            Console.ReadKey();

            //Compound assignment operators
            int num = 20;
            //Shorthand for an expression
            num += 20;
            num = num + 20;

        }
    }
}
