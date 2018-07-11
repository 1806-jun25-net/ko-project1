using System;
using System.Collections.Generic;

namespace PizzaStore.Data
{
    public partial class Pizzas
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string PizzaSize { get; set; }
        public bool Pepperoni { get; set; }
        public bool Chicken { get; set; }
        public bool Ham { get; set; }
        public bool Sausage { get; set; }
        public bool Mushroom { get; set; }
        public bool Onion { get; set; }
        public bool Pineapple { get; set; }
        public bool Jalapeno { get; set; }
        public bool Olive { get; set; }
        public bool Tomato { get; set; }

        public Orders Order { get; set; }
    }
}
