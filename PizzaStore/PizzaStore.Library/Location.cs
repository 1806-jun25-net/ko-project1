using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaStore.Library
{
    public class Location
    {
        // Location ID - an int between 1 to 5
        public int LocationID;
        public Location(int i)
        {
            LocationID = i;
            Inventory.Add("Pepperoni", 1);
            Inventory.Add("Chicken", 7);
            Inventory.Add("Ham", 7);
            Inventory.Add("Sausage", 7);
            Inventory.Add("Mushroom", 7);
            Inventory.Add("Onion", 7);
            Inventory.Add("Pineapple", 7);
            Inventory.Add("Jalapeno", 7);
            Inventory.Add("Olive", 7);
            Inventory.Add("Tomato", 7);
        }

        public List<string> Toppings = new List<string> { "Pepperoni", "Chicken", "Ham", "Sausage", "Mushroom", "Onion", "Pineapple", "Jalapeno", "Olive", "Tomato" };

        // An inventory of the store
        public Dictionary<string, int> Inventory { get; set; } = new Dictionary<string, int>();

        // A history of orders
        public List<Order> OrderHistory { get; set; } = new List<Order>();



        //Helper Method
        public bool UserExistInOrderHistory(List<Order> orderhistory, string name)
        {
            if (orderhistory == null)
            {
                return false;
            }
            else
            {
                for (var i = 0; i < orderhistory.Count; i++)
                {
                    if (orderhistory[i].User.Name == name)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        //Helper Method
        public List<Order> OrderHistoryByUser(List<Order> orderhist, string name)
        {
            //Looping through the list and inserting orders by the user into the new list and outputting that
            List<Order> result = new List<Order>();
            for (var i = 0; i < orderhist.Count; i++)
            {
                if (orderhist[i].User.Name == name)
                {
                    result.Add(orderhist[i]);
                }
            }
            return result;
        }



        //Using LINQ to sort??
        public List<Order> SortOrderHistory(List<Order> orderhist, string whichsort)
        {
            if (whichsort == "most expensive")
            {
                return (from item in orderhist
                        orderby item.Price descending
                        select item).ToList();
            }
            else if (whichsort == "least expensive")
            {
                return (from item in orderhist
                        orderby item.Price ascending
                        select item).ToList();
            }
            else if (whichsort == "earliest")
            {
                return (from item in orderhist
                        orderby item.OrderTime ascending
                        select item).ToList();
            }
            else if (whichsort == "latest")
            {
                return (from item in orderhist
                        orderby item.OrderTime descending
                        select item).ToList();
            }
            else
            {
                return null;
            }
        }
    }

}
