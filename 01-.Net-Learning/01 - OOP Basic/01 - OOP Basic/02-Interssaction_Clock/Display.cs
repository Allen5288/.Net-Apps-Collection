using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01___OOP_Basic.Interssaction_Clock
{
    public class Display
    {
        private int _value = 0;
        private int _limit = 0;

        public Display(int limit)
        {
            _limit = limit;
        }

        public void Increment()
        {
            _value++;
            if (_value >= _limit)
            {
                _value = 0;
            }
        }

        public int DisplayValue()
        {
            return _value;
        }
    }
}
