using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library
{
    public class User
    {
        public string Name;
        public User(string name)
        {
            Name = name;
        }
        public int SelectedLocation { get; set; } = 0;
        public int DefaultLocation { get; set; } = 0;

    }
}
