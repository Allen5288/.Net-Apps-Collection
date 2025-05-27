namespace _14NestedLoops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Suppose we want to print "Outer task" once, then print "Inner task" 3 times:

            int N = 3; // Number of times inner loop executes

            for (int i = 0; i < 1; i++) // Outer loop executes only once
            {
                Console.WriteLine("Outer task: Execute once");

                for (int j = 0; j < N; j++) // Inner loop executes N times
                {
                    Console.WriteLine($"Inner task: Execute {j + 1} time(s)");
                }
            }

            Console.ReadKey();

        }
    }
}
