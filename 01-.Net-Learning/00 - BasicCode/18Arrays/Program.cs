namespace _18Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int[] nums = new int[3];
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = i;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine(nums[i]);
            }
            Console.ReadKey();
           
        }
    }
}
