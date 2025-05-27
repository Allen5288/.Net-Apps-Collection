//Implicit conversion
int a = 10;
double b = a;  // int automatically converts to double
Console.WriteLine(b);

//Explicit conversion one
decimal dec = 123.456m;
int i = (int)dec;  // Result is 123
Console.WriteLine(i);

//Explicit conversion two - convert
string str = "123";
int num = Convert.ToInt32(str);  // Result is 123
Console.WriteLine(num);

//Explicit conversion three
//Example
string str1 = "123";
int num1 = int.Parse(str1);  // Result is 123
Console.WriteLine(num1);

//Will throw exception
string str2 = "123abc";
int num2 = int.Parse(str2);  // Throws FormatException
Console.WriteLine(num2);

//Explicit conversion four
string str3 = "123";
int result;
// success is true, result is 123
bool success = int.TryParse(str3, out result);
Console.WriteLine($"Success: {success}, Result: {result}");

string invalidStr = "abc";
int invalidStrresult;
// success is false, result is 0
bool fail = int.TryParse(invalidStr, out invalidStrresult);
Console.WriteLine($"Success: {fail}, Result: {invalidStrresult}");