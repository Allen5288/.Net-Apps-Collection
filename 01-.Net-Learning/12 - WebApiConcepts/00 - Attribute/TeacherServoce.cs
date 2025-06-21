using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00___Attribute
{
    public class TeacherServoce
    {
        [Custom("John Doe", 30)]
        public void Teach()
        {
            Console.WriteLine("Teaching...");
        }
        [Custom("Jane Smith")]
        public void GradePapers()
        {
            Console.WriteLine("Grading papers...");
        }
    }
}
