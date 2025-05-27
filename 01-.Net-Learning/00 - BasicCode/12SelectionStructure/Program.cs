namespace _12SelectionStructure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Li Si's year-end work evaluation, if rated A level, then salary increases by 500 yuan,
            //if rated B level, then salary increases by 200 yuan,
            //if rated C level, salary remains unchanged,
            //if rated D level salary decreases by 200 yuan,
            //if rated E level salary decreases by 500 yuan.
            //Set Li Si's original salary as 5000, ask user to input Li Si's rating, then display Li Si's next year salary

            bool b = true;
            double salary = 5000;
            Console.WriteLine("Please enter Li Si's year-end evaluation");//a b c d e 
            string level = Console.ReadLine();

            switch (level)
            {
                case "A":
                    salary += 500;
                    break;
                case "B":
                    salary += 200;
                    break;
                case "C": break;
                case "D":
                    salary -= 200;
                    break;
                case "E":
                    salary -= 500;
                    break;
                default:
                    Console.WriteLine("Input error, program exit");
                    b = false;
                    break;
            }
            if (b)
            {
                Console.WriteLine("Li Si's next year salary is {0} yuan", salary);
            }
            Console.ReadKey();


            #region if else-if approach
            //if (level == "A")
            //{
            //    salary += 500;//salary=salary+500;
            //}
            //else if (level == "B")
            //{
            //    salary += 200;
            //}
            //else if (level == "C")
            //{

            //}
            //else if (level == "D")
            //{
            //    salary -= 200;
            //}
            //else if (level == "E")
            //{
            //    salary -= 500;
            //}
            //else//Input is not one of ABCDE
            //{
            //    Console.WriteLine("Input error, program exit");
            //    b = false;
            //}
            //if (b)
            //{
            //    Console.WriteLine("Li Si's next year salary is {0}", salary);
            //} 
            #endregion


            Console.ReadKey();

        }
    }
}
