using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocusNew.Core.ViewModels
{
    public class ListingDetailsViewModel
    {
        public ListingViewModel Listing { get; set; }
        public BookAShowingViewModel BookAShowing { get; set; }
    }
}