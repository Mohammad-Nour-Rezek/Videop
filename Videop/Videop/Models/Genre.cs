using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Videop.Models
{
    public class Genre
    {
        public byte Id { get; set; }
        public string GenreType { get; set; }        
    }
}

// You must add Genre Data using SQL() in migration and cant be added usin table in server exp.
// like MembershipType cuz it's not table in DbSet<>, it generated via ef migrations