using LocusNew.Core.Models;

namespace LocusNew.Core.ViewModels
{
    public class ListingsListViewModel
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public decimal? Price { get; set; }
        public bool isSold { get; set; }
        public PropertyType PropertyType { get; set; }
        public int? Bedrooms { get; set; }
        public int? Bathrooms { get; set; }
        public int? SquareMeters { get; set; }
        public ListingImage Image { get; set; }
        public int LotSquareMeters { get; set; }
        public CityPart CityPart { get; set; }
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
        public AdType AdType { get; set; }
    }
}