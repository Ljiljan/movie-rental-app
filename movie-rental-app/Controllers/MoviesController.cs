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
        // DbContext init
        public ApplicationDbContext _context;

        // Constructor
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

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

            var movies = _context.Movies.ToList();

            return View(movies);
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