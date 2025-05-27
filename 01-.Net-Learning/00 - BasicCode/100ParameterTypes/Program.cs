using System.Globalization;

namespace _100ParameterTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Without ref, out
            int age = 10;
            string name = "lily";
            var result = Test1(name, age);
            //lily_100, age is 10
            Console.WriteLine($"result is {result},age is {age}");

            #endregion

            #region Using out
            //Using out
            //int age1 = 10;
            //string name1 = "lily";
            //var result1 = Test2(name1, out age1);
            ////result is lily _ 100,age is 100
            //Console.WriteLine($"result is {result1},age is {age1}");
            #endregion

            //#region Using ref
            int age2 = 10;
            string name2 = "lily1";
            var result2 = Test3(ref name2, ref age2);
            Console.WriteLine($"result is {result2},age is {age2}, name is {name2}");
            Console.ReadKey();

            //#endregion


            //#region Variable parameters
            //var total1 = TestParam(1, 1, 3);
            //Console.WriteLine(total1);

            ////total2 = TestParam(1);
            ////Console.WriteLine(total2);

            ////total3 = TestParam();
            ////Console.WriteLine(total3);

            //#endregion
        }

        /// <summary>
        /// normal method
        /// </summary>
        /// <param name="name">normal name</param>
        /// <param name="age">normal age</param>
        /// <returns></returns>
        private static string Test1(string name, int age)
        {
            age = 100;
            return name + " _ " + age;
        }

        private static string Test2(string name, out int age)
        {
            age = 100;
            return name + " _ " + age;
        }

        private static string Test3(ref string name, ref int age)
        {
            age = 100;
            name = "Tom";
            return name + " _ " + age;
        }
        private static int TestParam(params int[] nums)
        {
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];

            }

            return sum;
        }


    }
}
