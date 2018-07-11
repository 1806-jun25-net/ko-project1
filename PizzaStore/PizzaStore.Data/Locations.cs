using System;
using System.Collections.Generic;

namespace PizzaStore.Data
{
    public partial class Locations
    {
        public Locations()
        {
            Orders = new HashSet<Orders>();
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public int Pepperoni { get; set; }
        public int Chicken { get; set; }
        public int Ham { get; set; }
        public int Sausage { get; set; }
        public int Mushroom { get; set; }
        public int Onion { get; set; }
        public int Pineapple { get; set; }
        public int Jalapeno { get; set; }
        public int Olive { get; set; }
        public int Tomato { get; set; }

        public ICollection<Orders> Orders { get; set; }
        public ICollection<Users> Users { get; set; }
    }
}
