using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using movie_rental_app.Models;
using movie_rental_app.ViewModels;

namespace movie_rental_app.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "John" },
                new Customer { Id = 2, Name = "Angela" },
                new Customer { Id = 3, Name = "Max" },
            };

            var viewModel = new RandomMovieVM()
            {
                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult Details(int? id)
        {
            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "John" },
                new Customer { Id = 2, Name = "Angela" },
                new Customer { Id = 3, Name = "Max" },
            };

            var viewModel = new RandomMovieVM()
            {
                Customers = customers
            };

            if (id > 0 && id <= customers.Count)
            {
                return View(viewModel);
            } else
            {
                return RedirectToAction("Index");
            }
        }
    }
}