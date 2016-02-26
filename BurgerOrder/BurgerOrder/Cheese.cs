using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Order;

namespace BurgerOrder
{
    class Cheese
    {
        static public string createCheese(string _cheeseType)
        {
            var cheese = new Order();
            cheese.optionsArray[1] = _cheeseType;

            var cheeseType = _cheeseType;
            return cheeseType;
        }

    }
}
