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


// change to do while loop
i = 0;
answer = "";
do
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
} while (answer != "yes" && i < 10);


// change to for loop
i = 0;
answer = "";
for (int j = 0; j < 10; j++)
{
    
    Console.WriteLine("This is the {0}th time I'm explaining to you, do you understand now? yes/no", j + 1);
    answer = Console.ReadLine();//yes no
    if (answer == "yes")
    {
        Console.WriteLine("If you understand then go home!!!");
        break;
    }
}


// nested loop example, using for loop
// I want to write code that prints “Outer task” once and “Inner task” three times right after it
// So that I can practice nested loop (or sequential) logic and console output formatting.
i = 0;
for (int j = 0; j < 1; j++)
{
    Console.WriteLine("Outer task");
    for (i = 0; i < 3; i++)
    {
        Console.WriteLine("Inner task {0}", i + 1);
    }
}
