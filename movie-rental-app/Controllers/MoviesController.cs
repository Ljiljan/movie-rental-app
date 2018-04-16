using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using movie_rental_app.Models;

namespace movie_rental_app.Controllers
{
    public class MoviesController : Controller
    {
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
            var Movies = new Movie() {
                Name = "Goodfather"
            };

            return View(Movies);
        }

        public ActionResult Edit(int id)
        {
            return Content("Edit id is " + id);
        }
    }
}