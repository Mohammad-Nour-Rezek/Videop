using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Videop.Models;

namespace Videop.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genre { get; set; }

        // Now we will make this view model a 'Pure View Model'
        // and this way we will remove Movie object and pass just the properties we want to use in the view
        // and give them default value and make them nullable
        //public Movie Movie { get; set; }

        public int? Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number In Stock")]
        [Range(1, 20)]
        [Required]
        public short? NumberInStock { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }

        public string Title
        {
            get
            {
                return (Id != 0) ? "Edit Movie" : "New Movie";
            }
        }

        // A default constructor for initialize a new movie
        public MovieFormViewModel()
        {
            // This is for give the hidden field default value 0 cuz here we used the constructor
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }
    }
}