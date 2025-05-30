Console.WriteLine("Please enter a number");
int num = 0;
try
{
    num = Convert.ToInt32(Console.ReadLine());
}
catch (Exception)
{
    Console.WriteLine("The input content cannot be converted to a number");
}
finally
{
    
    Console.WriteLine("Exiting the program. Please try again.");
}
Console.WriteLine("Final Result: " + (num * 2));
Console.ReadKey();