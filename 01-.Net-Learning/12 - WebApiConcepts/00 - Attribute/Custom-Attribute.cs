using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00___Attribute
{
    [AttributeUsage(AttributeTargets.Method|AttributeTargets.Class|AttributeTargets.Property)]
    public class CustomAttribute : Attribute
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public CustomAttribute(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public CustomAttribute(string name)
        {
            Name = name;
        }
    }
}
