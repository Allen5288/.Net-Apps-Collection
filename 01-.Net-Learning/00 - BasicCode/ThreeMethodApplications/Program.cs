namespace ThreeMethodApplications
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the first number:");
            string input1 = Console.ReadLine();
            Console.WriteLine("Please enter the second number:");
            string input2 = Console.ReadLine();

            int number1 = int.Parse(input1);
            int number2 = int.Parse(input2);

            int sum = number1 + number2;
            Console.WriteLine("The sum of the two numbers is: " + sum);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

        }
    }
}
