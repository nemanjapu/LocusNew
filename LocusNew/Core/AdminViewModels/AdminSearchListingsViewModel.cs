using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocusNew.Core.AdminViewModels
{
    public class AdminSearchListingsViewModel
    {
        public IPagedList<AdminListingsListViewModel> ListingsList { get; set; }
        public AdminSearchFormViewModel SearchForm { get; set; }
    }
}