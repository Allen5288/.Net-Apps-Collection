namespace WhyUseOut_Ref
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region only use return
            // Call method, receive return value
            int sum = CalculateSum(10, 20);

            // Output result
            Console.WriteLine($"Sum: {sum}");

            #endregion

            #region use out
            // Use out to return multiple values
            int sum01, difference, product;
            Calculate(10, 20, out sum01, out difference, out product);

            // Output results
            Console.WriteLine($"Sum: {sum01}, Difference: {difference}, Product: {product}");
            #endregion

            #region use ref

            // Use ref to return multiple values
            int sum02 = 0, difference02 = 0, product02 = 0;
            Calculate01(10, 20, ref sum02, ref difference02, ref product02);

            // Output results
            Console.WriteLine($"Sum: {sum02}, Difference: {difference02}, Product: {product02}");

            #endregion

        }

        // Use return to return only one value
        static int CalculateSum(int a, int b)
        {
            return a + b;  // Only return the sum of two numbers
        }

        // Use out parameters to return multiple values
        static void Calculate(int a, int b, out int sum, out int difference, out int product)
        {
            sum = a + b;
            difference = a - b;
            product = a * b;
        }

        // Use ref parameters to return multiple values
        static void Calculate01(int a, int b, ref int sum, ref int difference, ref int product)
        {
            sum = a + b;
            difference = a - b;
            product = a * b;
        }
    }
}