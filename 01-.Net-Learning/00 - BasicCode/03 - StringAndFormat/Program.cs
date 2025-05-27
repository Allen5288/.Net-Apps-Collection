// See https://aka.ms/new-console-template for more information

Console.WriteLine("pls input your name");
string? name = Console.ReadLine(); // Allow 'name' to be nullable
if (string.IsNullOrWhiteSpace(name))
{
    name = "Guest"; // Provide a default value if 'name' is null or empty
}

string subject = ".Net";

string result = "hello " + name + ", welcome to " + subject + "!";
Console.WriteLine("by using direct +" + result);

string msg = string.Format("hello {0}, welcome to {1}!", name, subject);
Console.WriteLine("by using string.format" + msg);

string message = $"hello {name}, welcome to {subject}!";
Console.WriteLine("by using interpolated string: " + message);
