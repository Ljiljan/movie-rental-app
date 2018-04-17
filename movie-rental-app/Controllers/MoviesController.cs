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
            Decimal price = 1.2457m;

            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            return Content(String.Format("Page index is {0} and sortby value is {1} and price is {2:C2}", pageIndex, sortBy, price));
        }

        public ViewResult Random()
        {
            var Movie = new Movie() {
                Name = "Goodfather"
            };

            var customers = new List<Customer>
            {
                new Customer { Name = "John" },
                new Customer { Name = "Angela" },
                new Customer { Name = "Max" },
            };

            var viewModel = new RandomMovieVM
            {
                Movie = Movie,
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