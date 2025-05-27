namespace _08EscapeCharacters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("The weather is nice and sunny today\nBeautiful scenery everywhere");
            //Console.WriteLine("I want to output a \"\" English double quote in this sentence");
            //string path = @"C:\Program Files\MyApp";  // Use @ symbol to cancel escape effect of backslash
            //Console.WriteLine(path);
            Console.WriteLine(@"The weather is nice and sunny today
                Beautiful scenery everywhere");
            Console.ReadKey();
        }
    }
}
