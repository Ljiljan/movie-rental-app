using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace movie_rental_app.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}