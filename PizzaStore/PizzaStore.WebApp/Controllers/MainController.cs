using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaStore.Library.Repositories;
using PizzaStore.WebApp.Models;

namespace PizzaStore.WebApp.Controllers
{
    public class MainController : Controller
    {
        public PizzaStoreRepository Repo { get; }

        public MainController(PizzaStoreRepository repo)
        {
            Repo = repo;
        }
        // GET: Main
        public ActionResult Index(PizzaStoreView psv)
        {
            if (Repo.UserExists(psv.FirstName, psv.LastName))
            {
                var libUser = Repo.GetUser(psv.FirstName, psv.LastName);
                var webUser = new User
                {
                    Id = libUser.Id,
                    FirstName = libUser.FirstName,
                    LastName = libUser.LastName,
                    DefaultLocation = libUser.DefaultLocation
                };
                psv.Id = libUser.Id;
                return View("ContinueOrder", psv);
            }
            else
            {
                var NewWebUser = new Library.User
                {
                    FirstName = psv.FirstName,
                    LastName = psv.LastName,
                    DefaultLocation = psv.DefaultLocation
                };

                Repo.AddUser(NewWebUser);
                Repo.Save();
                psv.Id = Repo.GetUserID(NewWebUser);
                return View("ContinueOrder", psv);
            }
        }

        public ActionResult StartOrder()
        {
            return View();
        }

        public ActionResult FinishOrder(PizzaStoreView psv)
        {
            var newWebOrder = new Library.Order
            {
                LocationID = psv.DefaultLocation,
                UserID = psv.Id,
                OrderTime = DateTime.Now,
                Price = 0
            };
            var newWebPizza = new Library.Pizza
            {
                OrderID = Repo.GetMostRecentOrderID() + 1,
                PizzaSize = psv.PizzaSize,
                Toppings = new Dictionary<string, bool>()
                {
                        { "Pepperoni", psv.Pepperoni },
                        { "Chicken", psv.Chicken },
                        { "Ham", psv.Ham },
                        { "Sausage", psv.Sausage },
                        { "Mushroom", psv.Mushroom },
                        { "Onion", psv.Onion },
                        { "Pineapple", psv.Pineapple },
                        { "Jalapeno", psv.Jalapeno },
                        { "Olive", psv.Olive },
                        { "Tomato", psv.Tomato }
                }
            };
            psv.Price = Repo.AddPrice(newWebPizza) * psv.NumPizza;
            newWebOrder.Price = psv.Price;
            Repo.AddOrder(newWebOrder);
            Repo.AddPizza(newWebPizza);
            Repo.Save();
            return View("FinishOrder", psv);
        }
    }
}