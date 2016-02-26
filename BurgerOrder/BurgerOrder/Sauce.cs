using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Order;

namespace BurgerOrder
{
    class Sauce
    {
        static public string createSauce(string _sauce)
        {
            var sauce = new Order();
            sauce.optionsArray[3] = _sauce;

            var getSauce = _sauce;
            return getSauce;
        }



    }
}
