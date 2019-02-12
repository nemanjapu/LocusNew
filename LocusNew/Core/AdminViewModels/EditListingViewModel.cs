using LocusNew.Helpers;
using LocusNew.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocusNew.Core.AdminViewModels
{
    public class EditListingViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Adresa je obavezno polje!")]
        [DisplayName("Adresa")]
        public string Address { get; set; }
        [DataType(DataType.Currency)]
        public decimal? Price { get; set; }
        [Required(ErrorMessage = "Opis je obavezno polje!")]
        [DisplayName("Opis")]
        [AllowHtml]
        public string Details { get; set; }
        public IEnumerable<AdType> AdTypes { get; set; }
        [Required(ErrorMessage = "Prodaja je obavezno polje!")]
        [DisplayName("Prodaja")]
        public int AdTypeId { get; set; }
        public bool isActive { get; set; }
        public bool isSold { get; set; }
        public bool isRented { get; set; }
        [Required(ErrorMessage = "Tip nekretnine je obavezno polje!")]
        [DisplayName("Tip nekretine")]
        public int PropertyTypeId { get; set; }
        public IEnumerable<PropertyType> PropertyTypes { get; set; }
        public int? Rooms { get; set; }
        public int? Bedrooms { get; set; }
        public int? Bathrooms { get; set; }
        public int Floor { get; set; }
        public int TotalFloorNumber { get; set; }
        public int? SquareMeters { get; set; }
        public int LotSquareMeters { get; set; }
        public int YardSquareMeters { get; set; }
        public int YearBuilt { get; set; }
        public int YearOfLastAdaptation { get; set; }
        public bool Elevator { get; set; }
        public bool Balcony { get; set; }
        public bool Terrace { get; set; }
        public bool Loggia { get; set; }
        public bool Attic { get; set; }
        public bool Basement { get; set; }
        public bool Pantry { get; set; }
        public bool Water { get; set; }
        public bool Gas { get; set; }
        public string Canalization { get; set; }
        public bool TelephoneConnection { get; set; }
        public bool Electricity { get; set; }
        public bool CentralHeatingToplane { get; set; }
        public string CentralHeatingEtazno { get; set; }
        public bool CableTV { get; set; }
        public bool Internet { get; set; }
        public bool Furniture { get; set; }
        public string Latidute { get; set; }
        public string Longitude { get; set; }
        public virtual ICollection<ListingImage> Images { get; set; }
        public IEnumerable<ApplicationUser> Agents { get; set; }
        [Required(ErrorMessage = "Agent je obavezno polje!")]
        [DisplayName("Agent")]
        public string ApplicationUserId { get; set; }
        public int Toilete { get; set; }
        [Required(ErrorMessage = "Vlasnik je obavezno polje! Molimo odaberite vlasnika iz liste ili dodajte novog.")]
        [DisplayName("Vlasnik")]
        public int PropertyOwnerId { get; set; }
        public IEnumerable<PropertyOwner> PropertyOwners { get; set; }
        public IEnumerable<ListingImage> EditImagesList { get; set; }
        [Required(ErrorMessage = "Broj ugovora je obavezno polje!")]
        public string ListingUniqueCode { get; set; }
        public string MetaKeyWords { get; set; }
        [AllowHtml]
        public string NotesForAgents { get; set; }
        public string Published { get; set; }
        public IEnumerable<Source> Sources { get; set; }
        public int? SourceId { get; set; }
        public decimal CommissionFee { get; set; }
        public decimal SellingPrice { get; set; }
        public string FinanceType { get; set; }
        public bool Videophone { get; set; }
        public bool Interphone { get; set; }
        public bool PrivateParking { get; set; }
        public bool Garage { get; set; }
        public bool ArmoredDoor { get; set; }
        [AllowHtml]
        public string Heading { get; set; }
        public decimal ClientPrice { get; set; }
        public bool AirConditioner { get; set; }
        public string Joinery { get; set; }
        public bool NewKitchen { get; set; }
        public string ContractFrom { get; set; }
        public string ContractTo { get; set; }
        public string FloorText { get; set; }
        public string AlternativeHeating { get; set; }
        public bool isReserved { get; set; }
        public bool MultiRooms { get; set; }
        public bool MultiBedrooms { get; set; }
        public bool MultiBathrooms { get; set; }
        public bool MultiSquareMeters { get; set; }
        public int? MultiRoomsFrom { get; set; }
        public int? MultiRoomsTo { get; set; }
        public int? MultiBedroomsFrom { get; set; }
        public int? MultiBedroomsTo { get; set; }
        public int? MultiBathFrom { get; set; }
        public int? MultiBathTo { get; set; }
        public int? MultiSquareMetersFrom { get; set; }
        public int? MultiSquareMetersTo { get; set; }
        public bool MultiPrice { get; set; }
        [DataType(DataType.Currency)]
        public decimal? MultiPriceFrom { get; set; }
        [DataType(DataType.Currency)]
        public decimal? MultiPriceTo { get; set; }
        public IEnumerable<CityPart> CityParts { get; set; }
        [Required(ErrorMessage = "Dio grada je obavezno polje!")]
        public int CityPartId { get; set; }
        public string CityPartName { get; set; }

        public List<SelectListItem> FinanceTypeDropDown { get; set; }
        public List<SelectListItem> CentralHeatingEtaznoDropDown { get; set; }
        public List<SelectListItem> JoineryDropDown { get; set; }
        public List<SelectListItem> AlternativeHeatingDropDown { get; set; }
        public List<SelectListItem> CanalizationDropDown { get; set; }

        public EditListingViewModel()
        {
            FinanceTypeDropDown = DropdownHelper.GetFinanceType();
            CentralHeatingEtaznoDropDown = DropdownHelper.GetCentralHeatingEtazno();
            JoineryDropDown = DropdownHelper.GetJoinary();
            AlternativeHeatingDropDown = DropdownHelper.GetAlternativeHeating();
            CanalizationDropDown = DropdownHelper.GetCanalization();
        }
    }
}