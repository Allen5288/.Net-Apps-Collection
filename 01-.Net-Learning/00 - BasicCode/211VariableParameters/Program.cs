namespace _211VariableParameters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Call method with variable parameters
            PrintNumbers(1, 2, 3, 4, 5);
            PrintNumbers(10, 20);
            PrintNumbers();  // Can pass no parameters

            #region If parameter types are inconsistent
            PrintObjects(1, "hello", 3.14, true);
            #endregion

            //Directly pass array
            int[] numbers = { 1, 2, 3, 4, 5 };
            PrintNumbers(numbers);  // Can directly pass array
        }

        // Define method with variable parameters
        static void PrintNumbers(params int[] numbers)
        {
            // Check if any parameters were passed
            if (numbers.Length == 0)
            {
                Console.WriteLine("No parameters passed");
            }
            else
            {
                Console.WriteLine("The passed numbers are:");
                foreach (int number in numbers)
                {
                    Console.WriteLine(number);
                }
            }
        }

        static void PrintObjects(params object[] items)
        {
            foreach (var item in items)
            {

            }
        }
    }
}

      