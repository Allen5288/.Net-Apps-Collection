//++ after
int number = 10;
number++;
Console.WriteLine(number);
Console.ReadKey();

//++ before
int number2 = 10;
++number2;
Console.WriteLine(number2);
Console.ReadKey();

//Put in result, post-increment
int number3 = 10;
int result3 = 10 + number3++;
Console.WriteLine(number3);
Console.WriteLine(result3);
Console.ReadKey();

//Put in result, pre-increment
int number4 = 10;
int result4 = 10 + ++number4;
Console.WriteLine(number4);
Console.WriteLine(result4);
Console.ReadKey();


//Relational operators
int a1 = 10;
int b1 = 5;
bool result = (a1 > b1);  // true
Console.WriteLine(result);
Console.ReadKey();

//Elephant's weight(1500) > Mouse's weight(1)
bool b = 1500 > 1;
Console.WriteLine(b);
Console.ReadKey();

//Logical operators
int age = 20;
bool isAdult = (age >= 18) && (age < 60);  // true
Console.WriteLine(isAdult);
Console.ReadKey();

//Compound assignment operators
int num = 20;
//Shorthand for an expression
num += 20;
num = num + 20;