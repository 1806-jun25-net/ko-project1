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
    public class UserController : Controller
    {

        public PizzaStoreRepository Repo { get; }

        public UserController(PizzaStoreRepository repo)
        {
            Repo = repo;
        }
        // GET: User
        public ActionResult Index([FromQuery]string search = null)
        {
            var libUsers = Repo.GetUsers(search);
            var webUsers = libUsers.Select(x => new User
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                DefaultLocation = x.DefaultLocation
            });
            return View(webUsers);
        }

        public ActionResult OrderHistory(int id)
        {
            var libUsers = Repo.SortByLatest(Repo.GetOrdersByUserID(id));
            var webUsers = libUsers.Select(x => new Order
            {
                Id = x.Id,
                LocationID = x.LocationID,
                UserID = x.UserID,
                OrderTime = x.OrderTime,
                PizzaList = x.PizzaList,
                Price = x.Price,
                NumPizza = x.NumPizza
            });
            return View(webUsers);
        }

            // GET: User/Details/5
            public ActionResult Details(int id)
        {
            var libUser = Repo.GetUser(id);
            var webUser  = new User
            {
                Id = libUser.Id,
                FirstName = libUser.FirstName,
                LastName = libUser.LastName,
                DefaultLocation = libUser.DefaultLocation
            };
            return View(webUser);
        }

        public ActionResult OrderDetails(int orderid)
        {
            var libPizza = Repo.GetPizzasByOrderId(orderid);
            var webPizza = libPizza.Select(x => new Pizza
            {
                Id = x.Id,
                OrderID = x.OrderID,
                PizzaSize = x.PizzaSize,
                Pepperoni = x.Toppings["Pepperoni"],
                Chicken = x.Toppings["Chicken"],
                Ham = x.Toppings["Ham"],
                Sausage = x.Toppings["Sausage"],
                Mushroom = x.Toppings["Mushroom"],
                Onion = x.Toppings["Onion"],
                Pineapple = x.Toppings["Pineapple"],
                Jalapeno = x.Toppings["Jalapeno"],
                Olive = x.Toppings["Olive"],
                Tomato = x.Toppings["Tomato"],
            });
            return View(webPizza);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Repo.AddUser(new Library.User
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        DefaultLocation = user.DefaultLocation
                    });
                    Repo.Save();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var libUser = Repo.GetUser(id);
            var webUser = new User
            {
                Id = libUser.Id,
                FirstName = libUser.FirstName,
                LastName = libUser.LastName,
                DefaultLocation = libUser.DefaultLocation
            };
            return View(webUser);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var libUser = new Library.User
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        DefaultLocation = user.DefaultLocation
                    };
                    Repo.UpdateUser(libUser);
                    Repo.Save();
                    return RedirectToAction(nameof(Index));
                }

                return View(user);
            }
            catch
            {
                return View(user);
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var libUser = Repo.GetUser(id);
            var webUser = new User
            {
                Id = libUser.Id,
                FirstName = libUser.FirstName,
                LastName = libUser.LastName,
                DefaultLocation = libUser.DefaultLocation
            };
            return View(webUser);
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}