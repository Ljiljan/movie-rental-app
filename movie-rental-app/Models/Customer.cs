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

        [Required]
        [StringLength(100)]
        [Display(Name = "Your Full Name")]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType Membership { get; set; }
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of birth!")]
        public DateTime? Dob { get; set; }
    }
}