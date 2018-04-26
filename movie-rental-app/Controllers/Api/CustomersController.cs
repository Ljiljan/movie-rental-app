using movie_rental_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace movie_rental_app.Controllers.Api
{
    public class CustomersController : ApiController
    {
        // Connection to database
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/customers
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        // GET /api/customers/:id
        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return customer;
        }

        // POST /api/customers/
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        // PUT /api/customers/:id
        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var existingCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (existingCustomer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            existingCustomer.Name = customer.Name;
            existingCustomer.Dob = customer.Dob;
            existingCustomer.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            existingCustomer.MembershipTypeId = customer.MembershipTypeId;

            _context.SaveChanges();
        }

        // DELETE /api/customers/:id
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var existingCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (existingCustomer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(existingCustomer);
            _context.SaveChanges();
        }
    }
}
