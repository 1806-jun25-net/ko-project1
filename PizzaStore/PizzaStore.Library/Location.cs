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
        }

        // An inventory of the store
        public Dictionary<string, int> Inventory = new Dictionary<string, int>();

        // A history of orders
        public static List<Order> OrderHistory = new List<Order>();

        // A dictionary of users based on the key value name
        public Dictionary<string, User> UserDict = new Dictionary<string, User>();



        //Helper Method
        public static List<Order> OrderHistoryByUser(List<Order> orderhist, string name)
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
        public static List<Order> SortOrderHistory(List<Order> orderhist, string whichsort)
        {
            if (whichsort == "most expensive")
            {
                return (from item in orderhist
                        orderby item.price descending
                        select item).ToList();
            }
            else if (whichsort == "least expensive")
            {
                return (from item in orderhist
                        orderby item.price ascending
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



        //If the LINQ doesn't work - A modified version of the Quick Sort algorithm to sort the Order History
        public List<Order> QuickSortForOrderHistory(List<Order> orderhistory, string condition)
        {
            return orderhistory;
        }



    }

}
