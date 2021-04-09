using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;
using Videop.Models;

namespace Videop.ViewModels
{
    public class CustomerFormViewModel
    {
        // We want to pass a view model contain information about customer and membership types
        // so we pass a list here, now if we just want to loop on the list use IEnumerable<>,
        //however if we want to access by index for add, count, edit, we must use List<>
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        // Here we have choose if we want to get model member by ref like this way or to get all of them and put them here

        // If you want to use domai fields and in addition another ones for view you must seperate the domain model from view model and put the props here
        // If not you can use domain model ref here like this way because we dont have deferences in view (the same fields)
        //public Customer Customer { get; set; }

        public int? Id { get; set; }        

        // To override the validation message
        [Required(ErrorMessage = "Please enter Customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public bool IsSubscribedToNewsletters { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMemeber]
        // If select membership type that not 'PayAsYouGo' you must be 18 or more years old
        public DateTime? Birthdate { get; set; }


        [Display(Name = "Membership Type")]
        [Required]
        public byte? MembershipTypeId { get; set; }
        
        public string Title
        {
            get
            {
                return (Id != 0) ? "Edit Customer" : "New Customer";
            }
        }

        public CustomerFormViewModel()
        {
            Id = 0;
        }

        public CustomerFormViewModel(Customer customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            IsSubscribedToNewsletters = customer.IsSubscribedToNewsletters;
            Birthdate = customer.Birthdate;
            MembershipTypeId = customer.MembershipTypeId;
        }
    }
}