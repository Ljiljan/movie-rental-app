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
                MembershipTypes = membershipTypes,
            };

            return View("New", ViewModel);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var ViewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.Memberships.ToList(),
                WebsiteTitle = "Editing customer " + customer.Name,
            };

            return View("New", ViewModel);
        }

        // Create Customers Request usind Model binding
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            // Validation example
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.Memberships.ToList()
                };

                return View("New", viewModel);
            };

            if (customer.Id == 0)
            {
                // Adds customer request to our dbcontext
                _context.Customers.Add(customer);
            } else
            {
                var existingCustomer = _context.Customers.Single(c => c.Id == customer.Id);

                existingCustomer.Name = customer.Name;
                existingCustomer.Dob = customer.Dob;
                existingCustomer.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                existingCustomer.MembershipTypeId = customer.MembershipTypeId;
            }

            // Using save function it will save our data to db
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
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