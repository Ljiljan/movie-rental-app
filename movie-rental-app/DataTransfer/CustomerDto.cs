using movie_rental_app.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace movie_rental_app.DataTransfer
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your name!")]
        [StringLength(maximumLength: 100, MinimumLength = 3, ErrorMessage = "Name length is not valid")]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public byte MembershipTypeId { get; set; }

        // [AdultCheckVal]
        public DateTime? Dob { get; set; }
    }
}