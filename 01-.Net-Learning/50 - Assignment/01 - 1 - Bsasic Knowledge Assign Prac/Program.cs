using System;

namespace BasicKnowledgeAssignmentPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n=== C# Basic Knowledge Practice Exercises ===");
                Console.WriteLine("1. Variable Practice");
                Console.WriteLine("2. Arithmetic Operators");
                Console.WriteLine("3. Placeholder Practice");
                Console.WriteLine("4. String Interpolation ($)");
                Console.WriteLine("5. If Statement Practice");
                Console.WriteLine("6. Switch Case Practice");
                Console.WriteLine("7. Leap Year and Days in Month");
                Console.WriteLine("8. While Loop Practice");
                Console.WriteLine("9. Do-While Loop Practice");
                Console.WriteLine("10. For Loop Practice (Narcissistic Numbers)");
                Console.WriteLine("11. Nested Loop (Multiplication Table)");
                Console.WriteLine("12. Array Sorting");
                Console.WriteLine("13. Method Practice (Max Value)");
                Console.WriteLine("14. Array Sum Method");
                Console.WriteLine("15. Out Parameter Method");
                Console.WriteLine("16. Ref Parameter Method");
                Console.WriteLine("0. Exit");
                Console.Write("Please select an exercise (0-16): ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 0: return;
                        case 1: Exercise1_Variables(); break;
                        case 2: Exercise2_ArithmeticOperators(); break;
                        case 3: Exercise3_Placeholder(); break;
                        case 4: Exercise4_StringInterpolation(); break;
                        case 5: Exercise5_IfStatement(); break;
                        case 6: Exercise6_SwitchCase(); break;
                        case 7: Exercise7_LeapYearAndDays(); break;
                        case 8: Exercise8_WhileLoop(); break;
                        case 9: Exercise9_DoWhileLoop(); break;
                        case 10: Exercise10_ForLoop(); break;
                        case 11: Exercise11_NestedLoop(); break;
                        case 12: Exercise12_ArraySorting(); break;
                        case 13: Exercise13_MethodPractice(); break;
                        case 14: Exercise14_ArraySum(); break;
                        case 15: Exercise15_OutParameter(); break;
                        case 16: Exercise16_RefParameter(); break;
                        default: Console.WriteLine("Invalid selection!"); break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number!");
                }
            }
        }

        // Exercise 1: Variable Practice
        static void Exercise1_Variables()
        {
            Console.WriteLine("\n--- Exercise 1: Variable Practice ---");
            string name = "John";
            string gender = "Male";
            int age = 25;
            string telephoneNumber = "010-12345";

            Console.WriteLine($"My name is {name}, I am {age} years old, I am {gender}, my phone number is {telephoneNumber}");
        }

        // Exercise 2: Arithmetic Operators Practice
        static void Exercise2_ArithmeticOperators()
        {
            Console.WriteLine("\n--- Exercise 2: Arithmetic Operators ---");
            int tShirtPrice = 35;
            int trousersPrice = 120;
            int tShirtQuantity = 3;
            int trousersQuantity = 2;

            int totalCost = (tShirtPrice * tShirtQuantity) + (trousersPrice * trousersQuantity);
            Console.WriteLine($"T-shirt price: {tShirtPrice} yuan/piece");
            Console.WriteLine($"Trousers price: {trousersPrice} yuan/piece");
            Console.WriteLine($"Xiaoming bought {tShirtQuantity} T-shirts and {trousersQuantity} trousers");
            Console.WriteLine($"Total cost: {totalCost} yuan");
        }

        // Exercise 3: Placeholder Practice
        static void Exercise3_Placeholder()
        {
            Console.WriteLine("\n--- Exercise 3: Placeholder Practice ---");
            int totalDays = 46;
            int weeks = totalDays / 7;
            int remainingDays = totalDays % 7;

            Console.WriteLine("{0} days equals {1} weeks and {2} days", totalDays, weeks, remainingDays);
        }

        // Exercise 4: String Interpolation Practice
        static void Exercise4_StringInterpolation()
        {
            Console.WriteLine("\n--- Exercise 4: String Interpolation ($) ---");
            int totalSeconds = 107653;
            
            int days = totalSeconds / (24 * 3600);
            int remainingAfterDays = totalSeconds % (24 * 3600);
            
            int hours = remainingAfterDays / 3600;
            int remainingAfterHours = remainingAfterDays % 3600;
            
            int minutes = remainingAfterHours / 60;
            int seconds = remainingAfterHours % 60;

            Console.WriteLine($"{totalSeconds} seconds equals {days} days, {hours} hours, {minutes} minutes, and {seconds} seconds");
        }

        // Exercise 5: If Statement Practice
        static void Exercise5_IfStatement()
        {
            Console.WriteLine("\n--- Exercise 5: If Statement Practice ---");
            Console.Write("Please enter username: ");
            string username = Console.ReadLine();
            Console.Write("Please enter password: ");
            string password = Console.ReadLine();

            if (username == "admin" && password == "88888")
            {
                Console.WriteLine("Login successful!");
            }
            else if (username != "admin")
            {
                Console.WriteLine("Username does not exist!");
            }
            else
            {
                Console.WriteLine("Password is incorrect!");
            }
        }

        // Exercise 6: Switch Case Practice
        static void Exercise6_SwitchCase()
        {
            Console.WriteLine("\n--- Exercise 6: Switch Case Practice ---");
            int originalSalary = 5000;
            Console.Write("Please enter Li Si's performance rating (A/B/C/D/E): ");
            string rating = Console.ReadLine().ToUpper();

            int newSalary = originalSalary;
            switch (rating)
            {
                case "A":
                    newSalary += 500;
                    break;
                case "B":
                    newSalary += 200;
                    break;
                case "C":
                    // No change
                    break;
                case "D":
                    newSalary -= 200;
                    break;
                case "E":
                    newSalary -= 500;
                    break;
                default:
                    Console.WriteLine("Invalid rating!");
                    return;
            }

            Console.WriteLine($"Li Si's original salary: {originalSalary} yuan");
            Console.WriteLine($"Li Si's new salary: {newSalary} yuan");
        }

        // Exercise 7: Leap Year and Days in Month
        static void Exercise7_LeapYearAndDays()
        {
            Console.WriteLine("\n--- Exercise 7: Leap Year and Days in Month ---");
            Console.Write("Please enter year: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Please enter month: ");
            int month = int.Parse(Console.ReadLine());

            bool isLeapYear = (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
            Console.WriteLine($"Year {year} is {(isLeapYear ? "" : "not ")}a leap year");

            int daysInMonth = month switch
            {
                1 or 3 or 5 or 7 or 8 or 10 or 12 => 31,
                4 or 6 or 9 or 11 => 30,
                2 => isLeapYear ? 29 : 28,
                _ => 0
            };

            if (daysInMonth > 0)
                Console.WriteLine($"Month {month} in year {year} has {daysInMonth} days");
            else
                Console.WriteLine("Invalid month!");
        }

        // Exercise 8: While Loop Practice
        static void Exercise8_WhileLoop()
        {
            Console.WriteLine("\n--- Exercise 8: While Loop Practice ---");
            int attemptCount = 0;
            string answer;

            do
            {
                attemptCount++;
                Console.Write($"Attempt {attemptCount}: Do you understand this problem? (y/n): ");
                answer = Console.ReadLine().ToLower();

                if (answer == "n")
                {
                    Console.WriteLine("Teacher explains again...");
                }
            }
            while (answer != "y" && attemptCount < 10);

            if (answer == "y")
                Console.WriteLine("Great! You can go home now!");
            else
                Console.WriteLine("Teacher has explained 10 times. You can go home anyway!");
        }

        // Exercise 9: Do-While Loop Practice
        static void Exercise9_DoWhileLoop()
        {
            Console.WriteLine("\n--- Exercise 9: Do-While Loop Practice ---");
            string studentName;

            do
            {
                Console.Write("Please enter student name (enter 'q' to quit): ");
                studentName = Console.ReadLine();

                if (studentName != "q")
                {
                    Console.WriteLine($"Student name entered: {studentName}");
                }
            }
            while (studentName != "q");

            Console.WriteLine("Input ended.");
        }

        // Exercise 10: For Loop Practice (Narcissistic Numbers)
        static void Exercise10_ForLoop()
        {
            Console.WriteLine("\n--- Exercise 10: For Loop Practice (Narcissistic Numbers) ---");
            Console.WriteLine("Narcissistic numbers between 100-999:");

            for (int i = 100; i <= 999; i++)
            {
                int hundreds = i / 100;
                int tens = (i / 10) % 10;
                int units = i % 10;

                int sum = (hundreds * hundreds * hundreds) + (tens * tens * tens) + (units * units * units);

                if (sum == i)
                {
                    Console.WriteLine(i);
                }
            }
        }

        // Exercise 11: Nested Loop (Multiplication Table)
        static void Exercise11_NestedLoop()
        {
            Console.WriteLine("\n--- Exercise 11: Nested Loop (Multiplication Table) ---");

            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write($"{j}×{i}={i * j}\t");
                }
                Console.WriteLine();
            }
        }

        // Exercise 12: Array Sorting
        static void Exercise12_ArraySorting()
        {
            Console.WriteLine("\n--- Exercise 12: Array Sorting ---");
            int[] nums = { 1, 4, 3, 9, 6, 8, 11 };

            Console.WriteLine("Original array: " + string.Join(", ", nums));

            // Bubble sort
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = 0; j < nums.Length - 1 - i; j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        int temp = nums[j];
                        nums[j] = nums[j + 1];
                        nums[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine("Sorted array: " + string.Join(", ", nums));
        }

        // Exercise 13: Method Practice (Max Value)
        static void Exercise13_MethodPractice()
        {
            Console.WriteLine("\n--- Exercise 13: Method Practice (Max Value) ---");
            Console.Write("Enter first integer: ");
            int num1 = int.Parse(Console.ReadLine());
            Console.Write("Enter second integer: ");
            int num2 = int.Parse(Console.ReadLine());

            int maxValue = GetMaxValue(num1, num2);
            Console.WriteLine($"The maximum value between {num1} and {num2} is: {maxValue}");
        }

        static int GetMaxValue(int a, int b)
        {
            return a > b ? a : b;
        }

        // Exercise 14: Array Sum Method
        static void Exercise14_ArraySum()
        {
            Console.WriteLine("\n--- Exercise 14: Array Sum Method ---");
            int[] numbers = { 10, 20, 30, 40, 50 };

            Console.WriteLine("Array: " + string.Join(", ", numbers));
            int sum = CalculateArraySum(numbers);
            Console.WriteLine($"Sum of array elements: {sum}");
        }

        static int CalculateArraySum(int[] array)
        {
            int sum = 0;
            foreach (int num in array)
            {
                sum += num;
            }
            return sum;
        }

        // Exercise 15: Out Parameter Method
        static void Exercise15_OutParameter()
        {
            Console.WriteLine("\n--- Exercise 15: Out Parameter Method ---");
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            bool loginResult = ValidateLogin(username, password, out string message);
            Console.WriteLine($"Login result: {(loginResult ? "Success" : "Failed")}");
            Console.WriteLine($"Message: {message}");
        }

        static bool ValidateLogin(string username, string password, out string message)
        {
            if (username != "admin")
            {
                message = "Username error";
                return false;
            }
            else if (password != "88888")
            {
                message = "Password error";
                return false;
            }
            else
            {
                message = "Login successful";
                return true;
            }
        }

        // Exercise 16: Ref Parameter Method
        static void Exercise16_RefParameter()
        {
            Console.WriteLine("\n--- Exercise 16: Ref Parameter Method ---");
            Console.Write("Enter first integer: ");
            int num1 = int.Parse(Console.ReadLine());
            Console.Write("Enter second integer: ");
            int num2 = int.Parse(Console.ReadLine());

            Console.WriteLine($"Before swap: num1 = {num1}, num2 = {num2}");
            SwapNumbers(ref num1, ref num2);
            Console.WriteLine($"After swap: num1 = {num1}, num2 = {num2}");
        }

        static void SwapNumbers(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
