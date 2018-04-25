using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; // To use Required annotation

namespace movie_rental_app.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your name!")]
        [StringLength(maximumLength: 100, MinimumLength = 3)]
        [Display(Name = "Enter your name")]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType Membership { get; set; }

        [Display(Name = "Your Membership")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of birth!")]
        public DateTime? Dob { get; set; }
    }
}