using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CollectionsBasic.MenuIteratorExample
{
    public class KFCMenu
    {
        //用数组保存KFC的Menu
        private Food[] foods = new Food[7];
        public KFCMenu()
        {
            foods[0] = new Food { Id = 1, Name = "Chicken", Price = 10.00 };
            foods[1] = new Food { Id = 2, Name = "Beef", Price = 20.00 };
            foods[2] = new Food { Id = 3, Name = "Seafood", Price = 30.00 };
            foods[3] = new Food { Id = 4, Name = "Fiery Zinger", Price = 20.00 };
            foods[4] = new Food { Id = 5, Name = "Giant Snack", Price = 40.00 };
            foods[5] = new Food { Id = 6, Name = "Supercharged Zinger", Price = 60.00 };
            foods[6] = new Food { Id = 7, Name = "Original Crispy Burger", Price = 80.00 };
        }

        public Food[] GetFoods() { return foods; }

        public IIterator<Food> GetEnumerator()
        {
            return new KFCMenuIterator(this);
        }
    }
}
