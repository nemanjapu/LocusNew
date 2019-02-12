using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocusNew.Core.Models
{
    public class PropertyBuyer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public Listing Listing { get; set; }
        public int? ListingId { get; set; }
        public string IdNumber { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}