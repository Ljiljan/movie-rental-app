using AutoMapper;
using movie_rental_app.DataTransfer;
using movie_rental_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace movie_rental_app.Controllers.Api
{
    public class MoviesController : ApiController
    {
        // Db Connection
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/movies
        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
        }

        // GET /api/movies/:id
        public IHttpActionResult GetModie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(mov => mov.Id == id);
            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        // POST /api/movies/:id
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movie)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var newmovie = Mapper.Map<MovieDto, Movie>(movie);

            _context.Movies.Add(newmovie);
            _context.SaveChanges();

            // Created returns created API request with code 201
            return Created(new Uri(Request.RequestUri + "/" + newmovie.Id), newmovie);
        }

        // Put /api/movies/:id
        // Updates movie with selected ID
        [HttpPut]
        public void UpdateMovie(int id, MovieDto movie)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var Movie = _context.Movies.SingleOrDefault(mov => mov.Id == id);

            if (Movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            new Movie();
            Mapper.Map(movie, Movie);

            _context.SaveChanges();
        }
    }
}
