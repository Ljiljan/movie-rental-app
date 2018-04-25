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

        public ActionResult Details(int id)
        {
            var movies = _context.Movies.SingleOrDefault(c => c.Id == id);
            return View(movies);
        }

        public ActionResult New()
        {
            var movies = _context.Movies.ToList();
            var genres = new List<string>();

            foreach (var mov in movies)
            {
                genres.Add(mov.Genre);
            }

            var viewModel = new MovieViewModel
            {
                Genres = genres,
            };

            return View("New", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movies = _context.Movies.Single(c => c.Id == id);

            var moviesList = _context.Movies.ToList();
            var genres = new List<string>();

            foreach (var mov in moviesList)
            {
                genres.Add(mov.Genre);
            }

            var viewModel = new MovieViewModel
            {
                Movies = movies,
                Genres = genres
            };

            return View("New", viewModel);
        }

        [Route("movies/release/{yr:regex(\\d{4}):min(1900)}/{mon:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ReleaseDateSort(int yr, int mon)
        {
            return Content(yr + "/" + mon);
        }
    }
}