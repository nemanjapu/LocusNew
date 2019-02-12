using LocusNew.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocusNew.Core.AdminViewModels
{
    public class AdminListingsListViewModel
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public decimal? Price { get; set; }
        public string LeaseSale { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public string CityPart { get; set; }
        public bool isSold { get; set; }
        public string ListingUniqueCode { get; set; }
        public bool isReserved { get; set; }
        public string ApplicationUserId { get; set; }
        public string AgentName { get; set; }
        public string PropertyType { get; set; }
    }
}