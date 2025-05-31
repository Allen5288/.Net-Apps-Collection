using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01___OOP_Basic
{
    internal class PropertyLearning
    {
        private int _age;
        public string Name { get; set; }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        // Auto-implemented property with a default value
        public string FirstName { get; set; } = "Jack";
        // init accessor allows setting the property only during object initialization
        public string LastName { get; init; }
        // private set allows setting the property only within the class
        public string MiddleName { get; private set; }

        public void TestMethod()
        {
            MiddleName = "Smith"; // Can set value here because it's within the class
            Console.WriteLine($"The Name is: {FirstName} {MiddleName} and {LastName}");
        }

    }
}
