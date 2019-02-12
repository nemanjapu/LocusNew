using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocusNew.Core.AdminViewModels
{
    public class DashboardViewModel
    {
        public int ListingsNumber { get; set; }
        public int BuyersNumber { get; set; }
        public int SellersNumber { get; set; }
        public int EmployeesNumber { get; set; }
        public int ActiveListings { get; set; }
        public int InactiveListings { get; set; }
        public int ReservedListings { get; set; }
        public int SoldListings { get; set; }
        public IEnumerable<AgentsDashboardViewModel> Agents { get; set; }
    }
}