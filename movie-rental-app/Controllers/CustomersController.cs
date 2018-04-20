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
        // Database Integration
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.ToList();

            var viewModel = new RandomMovieVM()
            {
                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var customers = _context.Customers.SingleOrDefault(c => c.Id == id);

            return View(customers);
        }
    }
}