namespace Break_Contiue_Return
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //while break
            WhileBreak();
            SwitchBreak();
            Contiue();
            ReturnEg(10);
            int sum = AddNumbers(3, 4);  // sum is 7

            int[] myNumbers = { 10, -5, 50, 120, 30 };
            ProcessNumbers(myNumbers);  // Output 10 (then because of 50, directly return to exit method)

        }

        private static void WhileBreak()
        {
            for (int i = 0; i < 10; i++)
            {
                if (i == 5)
                {
                    break;  // When i is 5, exit the loop
                }
                Console.WriteLine(i);  // Output 0, 1, 2, 3, 4
            }
        }

        private static void SwitchBreak()
        {
            int x = 2;
            switch (x)
            {
                case 1:
                    Console.WriteLine("One");
                    break;  // Terminate this branch
                case 2:
                    Console.WriteLine("Two");
                    break;  // Terminate this branch
                default:
                    Console.WriteLine("Other");
                    break;
            }

        }

        private static void Contiue()
        {
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    continue;  // If i is even, skip this iteration, proceed to next iteration
                }
                Console.WriteLine(i);  // Output 1, 3, 5, 7, 9
            }

        }

        //Using return in void method
        private static void ReturnEg(int max)
        {
            for (int i = 0; i < max; i++)
            {
                if (i == 5)
                {
                    return;  // Exit method, no longer continue execution
                }
                Console.WriteLine(i);  // Output 0, 1, 2, 3, 4
            }

        }

        //Using return in method with return value

        static int AddNumbers(int a, int b)
        {
            return a + b;  // Return sum of two numbers and exit method
        }

        static void ProcessNumbers(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                {
                    continue;  // Skip negative numbers, continue to next iteration
                }

                if (numbers[i] > 100)
                {
                    break;  // If encounter number greater than 100, exit loop
                }

                if (numbers[i] == 50)
                {
                    return;  // If encounter 50, immediately exit method
                }

                Console.WriteLine(numbers[i]);  // Normally output positive numbers less than 100
            }
        }
    }
}
