namespace _12LoopPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Teacher asks student, do you understand this problem now? If student answers "yes",
            //then can go home. If student doesn't understand (no), then teacher explains again, asks student again......
            //Until student understands, then can go home.
            //Until student understands or teacher has explained 10 times and still doesn't understand, both can go home

            string answer = "";
            int i = 0;
            while (answer != "yes" && i < 10)
            {
                Console.WriteLine("This is the {0}th time I'm explaining to you, do you understand now? yes/no", i + 1);
                answer = Console.ReadLine();//yes no
                //If student answers that they understand, should break out of loop at this time
                if (answer == "yes")
                {
                    Console.WriteLine("If you understand then go home!!!");
                    break;
                }
                i++;
            }
        }
    }
}
