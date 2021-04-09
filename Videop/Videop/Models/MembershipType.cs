using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Videop.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        // Task 1: add Name and migration then call eager loading and get this name
        // add another migration to update database with names for each row
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonth { get; set; }
        public byte DiscountRate { get; set; }

        // If readonly changed throught application it will give compilation error
        // We define this to be reference to dropdown items insted of using [0, 1, ...]
        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
    }
}