using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace movie_rental_app.Models
{
    public class AdultCheckVal : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // We need to cast our customer Class (Customer) to validation context because it is an object instance
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unknown || 
                customer.MembershipTypeId == MembershipType.PayAsGo)
                return ValidationResult.Success;

            if (customer.Dob == null)
                return new ValidationResult("You need to enter your date of birth!");

            var customerAge = DateTime.Today.Year - customer.Dob.Value.Year;

            return (customerAge >= 18)
                ? ValidationResult.Success
                : new ValidationResult("You need to have 18 years or more to purchase this plan!");
        }
    }
}