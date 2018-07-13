using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library
{
    public class Order
    {
        public int Id { get; set; }
        public int LocationID { get; set; }
        public User User { get; set; }
        public int UserID { get; set; }
        public DateTime OrderTime { get; set; }
        public List<Pizza> PizzaList { get; set; } = new List<Pizza>();
        public decimal Price { get; set; } = 0;
        public int NumPizza { get; set; } = 0;
    }

}
