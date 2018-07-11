using System;
using System.Collections.Generic;

namespace PizzaStore.Data
{
    public partial class Users
    {
        public Users()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DefaultLocation { get; set; }

        public Locations DefaultLocationNavigation { get; set; }
        public ICollection<Orders> Orders { get; set; }
    }
}
