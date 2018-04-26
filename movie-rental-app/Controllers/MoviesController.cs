using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using movie_rental_app.Models;
using movie_rental_app.ViewModels;
using System.Data.Entity.Validation; // Add validation exception

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

            var movies = _context.Movies.OrderByDescending(m => m.Quantity).ToList();

            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movies = _context.Movies.SingleOrDefault(c => c.Id == id);
            return View(movies);
        }

        public ActionResult New()
        {
            var movies = _context.Movies.ToList();
            var genres = new List<string>
            {
                "Romance",
                "Action",
                "War"
            };

            var viewModel = new MovieViewModel
            {
                Genres = genres,
                WebsiteTitle = "Add New Movie"
            };

            return View("New", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movies = _context.Movies.Single(c => c.Id == id);

            var moviesList = _context.Movies.ToList();
            var genres = new List<string>
            {
                "Romance",
                "Action",
                "War"
            };

            var viewModel = new MovieViewModel(movies)
            {
                Genres = genres,
                WebsiteTitle = "Edit " + movies.Name + " Movie",
            };

            return View("New", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now.ToUniversalTime();
                _context.Movies.Add(movie);
            }
            else
            {
                var existingMovie = _context.Movies.Single(c => c.Id == movie.Id);

                existingMovie.Name = movie.Name;
                existingMovie.Image = movie.Image;
                existingMovie.Quantity = movie.Quantity;
                existingMovie.ReleaseDate = movie.ReleaseDate;
                existingMovie.DateAdded = DateTime.Now.ToUniversalTime();
                existingMovie.Genre = movie.Genre;
            }

            // Using the try-catch we can catch the exception
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException err)
            {
                Console.WriteLine(err);
            }

            return RedirectToAction("Index", "Movies");
        }

        [Route("movies/release/{yr:regex(\\d{4}):min(1900)}/{mon:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ReleaseDateSort(int yr, int mon)
        {
            return Content(yr + "/" + mon);
        }
    }
}