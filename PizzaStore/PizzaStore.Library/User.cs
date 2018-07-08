using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public Location DefaultLocation { get; set; }
        public Location SelectedLocation { get; set; } = 0;

        //First name + Last name to make it into full name
        public static string FirstandLastName(string fn, string ln)
        {
            return fn + " " + ln;
        }

        public User(string name)
        {
            Name = name;
        }

    }
}
