using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using movie_rental_app.Models;

namespace movie_rental_app.ViewModels
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
        public string WebsiteTitle { get; set; }
    }
}