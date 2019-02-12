using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocusNew.Core.ViewModels
{
    public class SearchViewModel
    {
        public IPagedList<ListingsListViewModel> Listings { get; set; }
        public SearchFormViewModel SearchForm { get; set; }
    }
}