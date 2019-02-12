using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocusNew.Core.Models
{
    public class Listing
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Details { get; set; }
        public AdType AdType { get; set; }
        public int AdTypeId { get; set; }
        public bool isActive { get; set; }
        public bool isSold { get; set; }
        public PropertyType PropertyType { get; set; }
        public int PropertyTypeId { get; set; }
        public DateTime Published { get; set; }
        public int Floor { get; set; }
        public int TotalFloorNumber { get; set; }
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
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }
        public CityPart CityPart { get; set; }
        public int CityPartId { get; set; }
        public virtual ICollection<ListingImage> Images { get; set; }
        public int Toilete { get; set; }
        public int PropertyOwnerId { get; set; }
        public PropertyOwner PropertyOwner { get; set; }
        public string ListingUniqueCode { get; set; }
        public string MetaKeyWords { get; set; }
        public string NotesForAgents { get; set; }
        public Source Source { get; set; }
        public int? SourceId { get; set; }
        public decimal CommissionFee { get; set; }
        public decimal SellingPrice { get; set; }
        public string FinanceType { get; set; }
        public bool Videophone { get; set; }
        public bool Interphone { get; set; }
        public bool PrivateParking { get; set; }
        public bool Garage { get; set; }
        public bool ArmoredDoor { get; set; }
        public decimal ClientPrice { get; set; }
        public string Heading { get; set; }
        public bool AirConditioner { get; set; }
        public string Joinery { get; set; }
        public bool NewKitchen { get; set; }
        public DateTime ContractFrom { get; set; }
        public DateTime ContractTo { get; set; }
        public string FloorText { get; set; }
        public string AlternativeHeating { get; set; }
        public bool isReserved { get; set; }
        public bool MultiBedrooms { get; set; }
        public bool MultiBathrooms { get; set; }
        public bool MultiSquareMeters { get; set; }
        public int? MultiBedroomsFrom { get; set; }
        public int? MultiBedroomsTo { get; set; }
        public int? MultiBathFrom { get; set; }
        public int? MultiBathTo { get; set; }
        public int? MultiSquareMetersFrom { get; set; }
        public int? MultiSquareMetersTo { get; set; }
        public bool MultiPrice { get; set; }
        public decimal? MultiPriceFrom { get; set; }
        public decimal? MultiPriceTo { get; set; }
        public bool MultiRooms { get; set; }
        public int? MultiRoomsFrom { get; set; }
        public int? MultiRoomsTo { get; set; }
        private int? _rooms;
        public int? Rooms
        {
            get
            {
                return _rooms;
            }
            set
            {
                if (MultiRooms)
                {
                    _rooms = MultiRoomsTo;
                }
                else { _rooms = value; }
            }
        }
        private int? _bedrooms;
        public int? Bedrooms
        {
            get
            {
                return _bedrooms;
            }
            set
            {
                if (MultiBedrooms)
                {
                    _bedrooms = MultiBedroomsTo;
                }
                else { _bedrooms = value; }
            }
        }
        private int? _bathrooms;
        public int? Bathrooms
        {
            get
            {
                return _bathrooms;
            }
            set
            {
                if (MultiBathrooms)
                {
                    _bathrooms = MultiBathTo;
                }
                else { _bathrooms = value; }
            }
        }
        public int? _squareMeters;
        public int? SquareMeters
        {
            get
            {
                return _squareMeters;
            }
            set
            {
                if (MultiSquareMeters)
                {
                    _squareMeters = MultiSquareMetersTo;
                }
                else { _squareMeters = value; }
            }
        }
        private decimal? _price;
        public decimal? Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (MultiPrice)
                {
                    _price = MultiPriceTo;
                }
                else { _price = value; }
            }
        }
    }
}