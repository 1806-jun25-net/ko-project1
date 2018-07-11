using System;
using System.Collections.Generic;

namespace PizzaStore.Data
{
    public partial class Orders
    {
        public Orders()
        {
            Pizzas = new HashSet<Pizzas>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderTime { get; set; }
        public int LocationId { get; set; }
        public decimal Price { get; set; }

        public Locations Location { get; set; }
        public Users User { get; set; }
        public ICollection<Pizzas> Pizzas { get; set; }
    }
}
