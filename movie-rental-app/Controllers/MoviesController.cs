using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using movie_rental_app.Models;
using movie_rental_app.ViewModels;

namespace movie_rental_app.Controllers
{
    public class MoviesController : Controller
    {
        private string year = DateTime.Now.Year.ToString();
        // GET: Movies
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            // Decimal price = 1.2457m;

            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            var Movies = new List<Movie>
            {
                new Movie { Id = 1, Name = "Goodfellas", Image = "https://images-na.ssl-images-amazon.com/images/I/516I8K7xlsL.jpg" },
                new Movie { Id = 1, Name = "Lord of War", Image = "https://i.pinimg.com/736x/20/78/32/20783281d5c9213f2d7c75cfc438f0ab--lord-of-war-the-lord.jpg" },
                new Movie { Id = 1, Name = "Goodfather II", Image = "http://movies.reyfernandes.com.br/capas/4312.jpg" }
            };

            var viewModel = new RandomMovieVM
            {
                Movies = Movies
            };


            return View(viewModel);
            // return Content(String.Format("Page index is {0} and sortby value is {1} and price is {2:C2}", pageIndex, sortBy, price));
        }

        public ViewResult Random()
        {
            var Movie = new List<Movie>
            {
                new Movie { Id = 1, Name = "Goodfather", Image = "http://www.jposter.net/images/products/godfather.jpg" }
            };

            var customers = new List<Customer>
            {
                new Customer { Name = "John" },
                new Customer { Name = "Angela" },
                //new Customer { Name = "Max" },
            };

            var viewModel = new RandomMovieVM
            {
                Movies = Movie,
                Customers = customers,
            };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content("Edit id is " + id);
        }

        [Route("movies/release/{yr:regex(\\d{4}):min(1900)}/{mon:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ReleaseDateSort(int yr, int mon)
        {
            return Content(yr + "/" + mon);
        }
    }
}