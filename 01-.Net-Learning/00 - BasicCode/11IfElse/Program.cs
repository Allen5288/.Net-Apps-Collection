namespace _11IfElse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //提示用户输入用户名，然后再提示输入密码，
            //如果用户名是“admin”并且密码是“88888”，则提示正确
            //否则，如果用户名不是admin还提示用户 用户名不存在,
            //如果用户名是admin则提示密码错误.

            Console.WriteLine("请输入用户名");
            string name = Console.ReadLine();
            Console.WriteLine("请输入密码");
            string pwd = Console.ReadLine();


            //第一种情况：用户名和密码全部输入正确
            if (name == "admin" && pwd == "888888")
            {
                Console.WriteLine("登陆成功");
            }
            //第二种情况：密码错误
            else if (name == "admin")
            {
                Console.WriteLine("密码输入错误，程序退出");
            }
            //第三种情况：用户名错误
            else if (pwd == "888888")
            {
                Console.WriteLine("用户名错误，程序退出");
            }
            //第四种情况：用户名和密码全部错误
            else
            {
                Console.WriteLine("用户名和密码全部错误，程序退出");
            }

            //三元表达式
            //提示用户输入一个姓名 只要输入的不是lily  就全是bad person
            Console.WriteLine("请输入姓名");
            string name01 = Console.ReadLine();

            string result = name == "lily" ? "good person" : "bad person";
            Console.WriteLine(result);
            Console.ReadKey();

            //if (name == "lily")
            //{
            //    Console.WriteLine("good person");
            //}
            //else
            //{
            //    Console.WriteLine("bad person");
            //}
            Console.ReadKey();

        }
    }
}
