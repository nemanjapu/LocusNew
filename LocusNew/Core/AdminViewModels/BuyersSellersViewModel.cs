using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocusNew.Core.AdminViewModels
{
    public class BuyersSellersViewModel
    {
        public IEnumerable<BuyersViewModel> BuyersList { get; set; }
        public IEnumerable<SellersViewModel> SellersList { get; set; }
    }
}