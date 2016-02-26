using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Order;

namespace BurgerOrder
{
    class Toppings
    {

        string[] toppings = new string[] { };


        static public string createToppings(string _toppings)
        { 
            var toppings = new Order();
            toppings.optionsArray[1] = _toppings;

            var topping = _toppings;

            //string topping[].push(_toppings);

            return topping;
        }
    }
}
