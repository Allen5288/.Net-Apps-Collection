using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01___OOP_Basic._05_phone_Inheritance.Phone
{
    public class BasePhone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int VersionNo { get; set; }

        public void Call()
        {
            Console.WriteLine($"{GetType().Name} calling");
        }

        public void Text()
        {
            Console.WriteLine($"{GetType().Name} messaging");
        }

        public void PlayGame(Game game)
        {
            game.Start();
        }
    }
}
