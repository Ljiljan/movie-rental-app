﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using movie_rental_app.Models;

namespace movie_rental_app.ViewModels
{
    public class RandomMovieVM
    {
        public List<Movie> Movies { get; set; }
        public List<Customer> Customers { get; set; }
    }
}