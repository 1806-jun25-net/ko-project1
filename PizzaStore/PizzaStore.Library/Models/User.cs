using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public int DefaultLocation { get; set; }

        //First name + Last name to make it into full name
        public static string FirstandLastName(string fn, string ln)
        {
            return fn + " " + ln;
        }

        public User()
        {

        }

        public User(string name)
        {
            Name = name;
        }

    }
}
