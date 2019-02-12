using LocusNew.Core.Models;
using LocusNew.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocusNew.Core.AdminViewModels
{
    public class AdminSearchFormViewModel
    {
        public IEnumerable<AdType> AdTypes { get; set; }
        public int AdTypeId { get; set; }
        public IEnumerable<PropertyType> PropertyTypes { get; set; }
        public IEnumerable<ApplicationUser> Agents { get; set; }
        public string AgentId { get; set; }
        public int PropertyTypeId { get; set; }
        public int? CityPartId { get; set; }
        public IEnumerable<CityPart> CityParts { get; set; }
        public int? selectedSaleLease { get; set; }
        public int? selectedListingType { get; set; }
        public int? selectedBeds { get; set; }
        public int? selectedFloor { get; set; }
        public List<SelectListItem> BathsBeds { get; set; }
        public List<SelectListItem> ListFloors { get; set; }
        public decimal? selectedMinPrice { get; set; }
        public decimal? selectedMaxPrice { get; set; }
        public string selectedListingNumber { get; set; }
        public List<SelectListItem> SortOrder { get; set; }
        public string selectedSortOrder { get; set; }

        public AdminSearchFormViewModel()
        {
            BathsBeds = DropdownHelper.GetBedBathList();
            ListFloors = DropdownHelper.GetFloorsList();
            SortOrder = DropdownHelper.ListingsSortOrder();
            selectedSortOrder = "published_desc";
        }
    }
}