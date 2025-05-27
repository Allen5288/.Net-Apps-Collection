namespace NamingConvention0210
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Must assign value to variable before outputting variable
            //string name;
            //Console.WriteLine(name);

            //Cannot assign value directly without declaration
            //name = "lily";

            //Green wavy line, although declared and assigned, but not used
            //string name = "lucy";

            string address = "Brisbane";
            String city = "Sydney";

            //Meaningless
            int a = 1;
            int b = 2;

            //num and NUM are completely different areas in memory
            int num = 10;
            int NUM = 10;

            //Variables cannot be repeatedly declared and defined
            //int number = 100;
            //int number = 200;

            
        }
    }
}
