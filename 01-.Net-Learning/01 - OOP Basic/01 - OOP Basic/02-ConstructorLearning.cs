using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01___OOP_Basic
{
    // sequence: constructor -> field initialization -> property initialization -> constructor body
    internal class ConstructorLearning
    {
        // fields
        int _age = 11;
        string _name = "sss";
        string _city = "kkk";
        // we can not call methods for field initialization

        // properties
        public int Number { get; set; } = 25;
        public string Address { get; set; }

        private string _complexValue = "Private Field Value";
        public string ComplexValueFromAPI
        {
            get
            {
                // DB or API call to get complex value
                // return MockAPIReturn();
                return $"Complex Value from API + {_complexValue}";
            }
            set
            {
                _complexValue = value;
            }
        }

        // compiler will automatically create a default constructor if no constructors are defined
        public ConstructorLearning() { }

        // overloading constructors(重载) allows you to create multiple constructors with different parameters
        public ConstructorLearning(string name)
        {
            _name = name;
        }
        public ConstructorLearning(int age)
        {
            Console.WriteLine($"Age: {age}");
            _age = age;
        }
        public ConstructorLearning(string name, int age) : this(name)
        {
            Console.WriteLine($"Name: {name}");
            _name = name;
        }

        // this() -> constructor chaining(构造函数链)
        // allows you to call another constructor from within a constructor (call 2 param constructor before this one)
        public ConstructorLearning(string name, int age, string city) : this(name, age)
        {
            Console.WriteLine($"City: {city}");
            _city = city; // Assuming you have a _city field
        }
    }
}
