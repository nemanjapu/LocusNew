using LocusNew.Core.Models;
using LocusNew.Helpers;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LocusNew.Core.ViewModels
{
    public class SearchFormViewModel
    {
        public IEnumerable<AdType> AdTypes { get; set; }
        public int AdTypeId { get; set; }
        public IEnumerable<PropertyType> PropertyTypes { get; set; }
        public int PropertyTypeId { get; set; }
        public int? selectedCityPart { get; set; }
        public string selectedCityPartName { get; set; }
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

        public SearchFormViewModel()
        {
            BathsBeds = DropdownHelper.GetBedBathList();
            ListFloors = DropdownHelper.GetFloorsList();
            SortOrder = DropdownHelper.ListingsSortOrder();
            selectedSortOrder = "published_desc";
        }
    }
}