using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Order;

namespace BurgerOrder
{
    class Bun
    {
       static public string createBun(string _bunType)
       {
           var burger = new Order();
           burger.optionsArray[0] = _bunType;
       
           var bunType = _bunType;
           return bunType;
        }

    }
}
