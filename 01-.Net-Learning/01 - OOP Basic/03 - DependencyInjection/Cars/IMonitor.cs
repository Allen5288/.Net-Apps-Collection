using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03___DependencyInjection.Cars
{
    public interface IMonitor
    {
        public void Monitor();
    }

    public class VideoMonitor : IMonitor
    {
        public void Monitor()
        {
            Console.WriteLine($"Video monitor starts.....");
        }
    }

    public class AlarmMonitor : IMonitor
    {
        public AlarmMonitor()
        {
            Console.WriteLine($"Alarm monitor");
        }
        public void Monitor()
        {
            Console.WriteLine($"Alarm monitor starts...");
        }
    }
}
