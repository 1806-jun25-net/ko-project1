using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library
{
    class Pizza
    {
        public string CrustStyle { get; set; }
        public string PizzaSize { get; set; }
        public string Sauce { get; set; }
        public string Cheese { get; set; }
        public string[] Toppings { get; set; }
    }
}
