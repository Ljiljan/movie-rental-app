using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using movie_rental_app.Models;
using movie_rental_app.ViewModels;
using System.Data.Entity; // Include() function support

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

        // Customers Form Start
        public ActionResult New()
        {
            var membershipTypes = _context.Memberships.ToList();
            var ViewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View(ViewModel);
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.Membership).ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customers = _context.Customers.Include(c => c.Membership).SingleOrDefault(c => c.Id == id);

            if (customers == null)
            {
                return HttpNotFound();
            }

            return View(customers);
        }
    }
}