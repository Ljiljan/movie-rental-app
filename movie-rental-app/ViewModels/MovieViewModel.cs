using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using movie_rental_app.Models;

namespace movie_rental_app.ViewModels
{
    public class MovieViewModel
    {
        public Movie Movies { get; set; }
        public Customer Customers { get; set; }
        public List<string> Genres { get; set; }
        public string WebsiteTitle { get; set; }
    }
}