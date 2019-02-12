using LocusNew.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocusNew.Core.ViewModels
{
    public class ListingViewModel
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public decimal? Price { get; set; }
        public string Details { get; set; }
        public AdType AdType { get; set; }
        public bool isActive { get; set; }
        public bool isSold { get; set; }
        public bool isRented { get; set; }
        public PropertyType PropertyType { get; set; }
        public DateTime Published { get; set; }
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
        public List<ListingImage> Images { get; set; }
        public string ImagePreview { get; set; }
        public string ImagePreviewPath { get; set; }
        public int Toilete { get; set; }
        public CityPart CityPart { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string ListingUniqueCode { get; set; }
        public string MetaKeywords { get; set; }
        public bool Videophone { get; set; }
        public bool Interphone { get; set; }
        public bool PrivateParking { get; set; }
        public bool Garage { get; set; }
        public bool ArmoredDoor { get; set; }
        public string Heading { get; set; }
        public bool AirConditioner { get; set; }
        public string Joinery { get; set; }
        public bool NewKitchen { get; set; }
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
        public decimal? MultiPriceFrom { get; set; }
        public decimal? MultiPriceTo { get; set; }
        public string ApplicationUserId { get; internal set; }
    }
}