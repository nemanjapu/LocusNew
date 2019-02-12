using System.Collections.Generic;
using System.Linq;
using LocusNew.Core.Models;
using LocusNew.Core.ViewModels;

namespace LocusNew.Core.Repositories
{
    public interface IListingsRepository
    {
        void AddListing(Listing listing);
        bool CheckListingUniqueCode(string code);
        Listing GetListing(int id);
        IQueryable<Listing> GetListings();
        int GetListingsNumber();
        int GetListingsNumberByStatus(bool isActive, bool isReserved, bool isSold);
        int GetListingsNumberForAgent(string userId);
        IQueryable<Listing> GetListingsWithCityAndAdType();
        void RemoveListing(int id);
        IEnumerable<Listing> SearchListings(string sortOrder, string cityPart, string listingNumber, string agent, bool isActive, bool isSold, bool isReserved, int? cityPartId = 0, int? propertyType = 0, int? adType = 0, int? beds = 0, int? floor = -1, decimal? minPrice = 0, decimal? maxPrice = 0);
        object MapSearchAutocomplete(string term);
    }
}