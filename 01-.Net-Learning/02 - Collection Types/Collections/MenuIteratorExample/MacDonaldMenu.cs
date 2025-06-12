using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CollectionsBasic.MenuIteratorExample
{
    public class MacDonaldMenu
    {
        //用List来保存麦当劳提供的Menu
        private List<Food> foods = new List<Food>();

        public MacDonaldMenu()
        {
            foods.Add(new Food { Id = 1, Name = "Chicken", Price = 10.00 });
            foods.Add(new Food { Id = 2, Name = "Beef", Price = 20.00 });
            foods.Add(new Food { Id = 3, Name = "Seafood", Price = 30.00 });
        }

        public List<Food> GetFoods() { return foods; }

        public IIterator<Food> GetEnumerator()
        {
            return new MacdonalMenuIterator(this);
        }
    }
}
