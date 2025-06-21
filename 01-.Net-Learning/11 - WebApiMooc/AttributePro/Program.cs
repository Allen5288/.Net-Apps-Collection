namespace AttributePro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Hello, World!");
        }

        [Obsolete("", true)]
        // this is old and should not be used, true means it will throw an exception if used, false means it will just warn
        // "" is the message that will be shown in the warning or exception
        private static void Test()
        {

        }
    }
}
