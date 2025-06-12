using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CollectionsBasic.MenuIteratorExample
{
        //public class CustomColleciton : IEnumerable //约束 contract
        //{
        //    public IEnumerator GetEnumerator()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void Method() { }
        //}

        public class KFCTreeMenuIterator : IIterator<Food>
    {
        private BinaryTree foods = null;

        private Food _current;

        public KFCTreeMenuIterator(KFCMenu_In_Tree_Structure kfcMenu)
        {
            foods = kfcMenu.GetFoods();
        }

        public Food Current
        {
            get
            {
                return _current;
            }
        }

        public bool MoveNext()
        {
            if (foods._stack.Any())
            {
                _current = foods._stack.Pop().Value;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            _current = foods.Root.Value;
        }
    }

    public class KFCMenuIterator : IIterator<Food>
    {
        private Food[] foods = null;

        //
        //public void Method()
        //{
        //    CustomColleciton customColleciton = new CustomColleciton();
        //    foreach (var s in customColleciton)
        //    {

        //    }
        //}
        public KFCMenuIterator(KFCMenu kFCMenu)
        {
            foods = kFCMenu.GetFoods();
        }

        private int _currentIndex = -1;

        public Food Current
        {
            get
            {
                return foods[_currentIndex];
            }
        }

        public bool MoveNext()
        {
            return foods.Length > ++_currentIndex;
        }

        public void Reset()
        {
            _currentIndex = -1;
        }
    }

    public class MacdonalMenuIterator : IIterator<Food>
    {
        private List<Food> foods = new List<Food>();
        private int _currentIndex = -1;

        public MacdonalMenuIterator(MacDonaldMenu macDonaldMenu)
        {
            foods = macDonaldMenu.GetFoods();
        }

        public Food Current
        {
            get
            {
                return foods[_currentIndex];
            }
        }

        public bool MoveNext()
        {
            return foods.Count > ++_currentIndex;
        }

        public void Reset()
        {
            _currentIndex = -1;
        }
    }
}
