using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Videop.DTO
{
    public class MovieDTO
    {
        //public IEnumerable<Genre> Genre { get; set; }

        // Now we will make this view model a 'Pure View Model'
        // and this way we will remove Movie object and pass just the properties we want to use in the view
        // and give them default value and make them nullable
        //public Movie Movie { get; set; }

        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }
        
        [Range(1, 20)]
        [Required]
        public short NumberInStock { get; set; }

        [Required]
        public byte GenreId { get; set; }
    }
}