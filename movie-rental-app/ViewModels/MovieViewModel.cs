using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using movie_rental_app.Models;

namespace movie_rental_app.ViewModels
{
    public class MovieViewModel
    {

        [Required]
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Cover image URL")]
        public string Image { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        public DateTime? DateAdded { get; set; }

        [Required]
        [Display(Name = "Movie Quantity")]
        [Range(1,50)]
        public int? Quantity { get; set; }

        public Customer Customers { get; set; }
        public List<string> Genres { get; set; }
        public string WebsiteTitle { get; set; }

        public MovieViewModel()
        {
            Id = 0;
        }

        public MovieViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            Image = movie.Image;
            Genre = movie.Genre;
            ReleaseDate = movie.ReleaseDate;
            Quantity = movie.Quantity;
            DateAdded = movie.DateAdded;
        }
    }
}