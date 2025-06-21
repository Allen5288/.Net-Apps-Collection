using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00___Attribute
{
    public class User
    {
        [ModelCustom(10, true)]
        public string Name { get; set; }

        [ModelCustom(20, true)]
        public string Email { get; set; }
    }
}
