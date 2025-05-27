// Please type userName
Console.WriteLine("Please type userName");
string name = Console.ReadLine();
// Please type password
Console.WriteLine("Please type password");
string pwd = Console.ReadLine();

// Case 1: Both username and password are correct
if (name == "admin" && pwd == "888888")
{
    Console.WriteLine("Login successful");
}
// Case 2: Password is incorrect
else if (name == "admin")
{
    Console.WriteLine("Password is incorrect, program exits");
}
// Case 3: Username is incorrect
else if (pwd == "888888")
{
    Console.WriteLine("Username is incorrect, program exits");
}
// Case 4: Both username and password are incorrect
else
{
    Console.WriteLine("Both username and password are incorrect, program exits");
}

// Ternary expression
// Prompt the user to enter a name. As long as the input is not lily, it is a bad person.
Console.WriteLine("Please enter a name");
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