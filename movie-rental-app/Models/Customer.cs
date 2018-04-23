using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; // Ro use Required annotation

namespace movie_rental_app.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType Membership { get; set; }
        public byte MembershipTypeId { get; set; }

        public DateTime? Dob { get; set; }
    }
}