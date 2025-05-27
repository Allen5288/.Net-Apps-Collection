namespace _07PlaceHolder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n1 = 10;
            int n2 = 20;
            int n3 = 30;
            Console.WriteLine("第一个数字是:" + n1 + "，第二个数字是：" + n2 + ",第三个数字是：" + n3);
            //占位符
            Console.WriteLine("第一个数字是 {0}，第二个数字是{1}，第三个数字是{2}", n1,n2,n3);

            Console.WriteLine($"第一个数字是 {n1}，第二个数字是{n2}，第三个数字是{n3}");
        }
    }
}
