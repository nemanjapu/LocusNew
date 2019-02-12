using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocusNew.Core.Models
{
    public class BookAShowing
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateSubmited { get; set; }
        public DateTime DateForShowing { get; set; }
        public Listing Listing { get; set; }
        public int ListingId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }
    }
}