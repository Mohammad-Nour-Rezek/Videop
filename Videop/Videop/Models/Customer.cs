using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Videop.Models
{
    public class Customer
    {
        public int Id { get; set; }

        // Type of validations those not used here:
        // [Range(1, 10)], [Compare("OtherProperty")], [Phone], [EmailAddress], [Url], [RegularExpression("...")]

        // In mvc the validation attributes used in both server and client side validation
        // In sever side on all prop of obj type that come to action
        // In client side applied usin jQuery validation when writ front end using @Html helpers cuz it create a bunch of validation props

        // To override the validation message
        [Required(ErrorMessage = "Please enter Customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletters { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMemeber]
        // If select membership type that not 'PayAsYouGo' you must be 18 or more years old
        public DateTime? Birthdate { get; set; }

        // Many to One relation from customer to it's membership type
        // One customer has only one membership type AND one membership type have meny customers shared it       
        public MembershipType MembershipType { get; set; }

        // FK by convention to get just id rather than all object
        [Display(Name = "Membership Type")]
        [Required]
        // If this field is not [Required] it will get message validation required and it will be req.
        // cus it's type is byte if it's byte? then it will be optional so it's implicitly required
        // And the value of option element in the list is empty string and asp.net doesn't know how to translater it to byte
        public byte MembershipTypeId { get; set; }
    }
}