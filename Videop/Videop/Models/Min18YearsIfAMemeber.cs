using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Videop.Models
{
    // Create custom validation to ensure a clinet is 18 years old or more
    public class Min18YearsIfAMemeber : ValidationAttribute
    {
        // Must override to implement validation, and the best choice is the second overload
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Check the selected Membership type
            // this give us access to the containig class [this case Customer]
            // And cuz it's an object we nee to cast it to customer
            var customer = (Customer)validationContext.ObjectInstance;
            // Check the selected membership type
            // We want avoid using mafic numbers [0, 1] so add static fields in MembershipTyp
            //Another approach we can use Enum, but it need cast to byte on every use here
            // Or we can define Enum list in customer, but this approach is better
            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo) // Empty(for UX) or PayAsYouGo
            {
                // We dont care about birthdate value
                return ValidationResult.Success; // No problem
            }

            if (customer.Birthdate == null)
            {
                return new ValidationResult("Birthdate is required.");
            }

            // .value used --> nullable
            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be at least 18 years old to go on a membership.");
        }
    }
}