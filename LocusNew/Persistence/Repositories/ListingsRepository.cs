using LocusNew.Persistence;
using LocusNew.Core.Models;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using System.IO;
using System.Web;
using LocusNew.Core.Repositories;
using LocusNew.Core.ViewModels;

namespace LocusNew.Persistence.Repositories
{
    public class ListingsRepository : IListingsRepository
    {
        private readonly ApplicationDbContext _ctx;

        public ListingsRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IQueryable<Listing> GetListings()
        {
            return _ctx.Listing.AsQueryable();
        }

        public IQueryable<Listing> GetListingsWithCityAndAdType()
        {
            return _ctx.Listing.Include(l => l.PropertyType).Include(l => l.CityPart).Include(l => l.AdType);
        }

        public IEnumerable<Listing> SearchListings(string sortOrder, string cityPart, string listingNumber, string agent, bool isActive, bool isSold, bool isReserved, int? cityPartId = 0, int? propertyType = 0, int? adType = 0, int? beds = 0, int? floor = -1, decimal? minPrice = 0, decimal? maxPrice = 0)
        {
            var listings = _ctx.Listing
                .Include(l => l.PropertyType)
                .Include(l => l.CityPart)
                .Include(l => l.AdType)
                .Include(l => l.ApplicationUser)
                .Where(l => cityPartId == 0 && !string.IsNullOrEmpty(cityPart) ? l.CityPart.Name.ToLower().Contains(cityPart.ToLower()) : cityPartId > 0 ? l.CityPartId == cityPartId : l.CityPartId > 0)
                .Where(l => propertyType > 0 ? l.PropertyTypeId == propertyType : l.PropertyTypeId > 0)
                .Where(l => adType > 0 ? l.AdTypeId == adType : l.AdTypeId > 0)
                .Where(l => beds > 0 ? l.Bedrooms >= beds : l.Bedrooms >= 0)
                .Where(l => floor >= 0 ? l.Floor == floor : floor == 6 ? l.Floor >= floor && l.Floor < 50 : l.Floor >= 0)
                .Where(l => minPrice >= 0 && maxPrice == 0 ? l.Price >= minPrice : maxPrice > 0 ? l.Price >= minPrice && l.Price <= maxPrice : l.Price >= 0)
                .Where(l => !string.IsNullOrEmpty(listingNumber) ? l.ListingUniqueCode.ToLower().Contains(listingNumber.ToLower()) : l.ListingUniqueCode != null)
                .Where(l => isReserved ? l.isReserved && l.isActive && !l.isSold : isSold ? l.isSold : l.isActive == isActive && !l.isSold)
                .Where(l => !string.IsNullOrEmpty(agent) ? string.Equals(l.ApplicationUserId, agent) : l.ApplicationUserId != null)
                .AsNoTracking()
                .OrderByDescending(l => l.Published)
                .AsEnumerable();

            switch (sortOrder)
            {
                case "published_acs":
                    listings = listings.OrderBy(l => l.Published);
                    break;
                case "published_desc":
                    listings = listings.OrderByDescending(l => l.Published);
                    break;
                case "price_acs":
                    listings = listings.OrderBy(l => l.Price);
                    break;
                case "price_desc":
                    listings = listings.OrderByDescending(l => l.Price);
                    break;
            }

            return listings;
        }

        public int GetListingsNumber()
        {
            return _ctx.Listing.Count();
        }
        
        public int GetListingsNumberByStatus(bool isActive, bool isReserved, bool isSold)
        {
            return _ctx.Listing.Where(
                l => isSold && isActive && !isReserved ? l.isSold && l.isActive : 
                isReserved && isActive && !isSold ? l.isReserved && !l.isSold && l.isActive : 
                !isActive && !isReserved && !isSold ? !l.isActive : 
                l.isActive && !l.isSold && !l.isReserved).Count();
        }

        public int GetListingsNumberForAgent(string userId)
        {
            return _ctx.Listing.Where(ul => ul.ApplicationUserId == userId).Count();
        }

        public Listing GetListing(int id)
        {
            return _ctx.Listing.Find(id);
        }

        public bool CheckListingUniqueCode(string code)
        {
            return _ctx.Listing.Any(x => x.ListingUniqueCode.Equals(code.Trim()));
        }

        public object MapSearchAutocomplete(string term)
        {
            var addressList = _ctx.Listing.Where(l => l.Address.ToUpper().Contains(term.ToUpper()))
                .Select(b => new { Name = b.Address })
                .Distinct().ToList();

            var cityPartsList = _ctx.CityPart.Where(b => b.Name.ToUpper().Contains(term.ToUpper()))
                .Select(b => new { Name = b.Name })
                .Distinct().ToList();

            return addressList.Union(cityPartsList);
        }

        public void AddListing(Listing listing)
        {
            _ctx.Listing.Add(listing);
        }

        public void RemoveListing(int id)
        {
            _ctx.BookAShowing.RemoveRange(_ctx.BookAShowing.Where(b => b.ListingId == id));
            _ctx.PropertyBuyer.RemoveRange(_ctx.PropertyBuyer.Where(b => b.ListingId == id));
            _ctx.ListingImage.RemoveRange(_ctx.ListingImage.Where(b => b.ListingId == id));

            var listing = GetListing(id);
            string mappedPath = HttpContext.Current.Server.MapPath(@"~/DynamicContent/ListingImages/Listing" + listing.ListingUniqueCode);

            Directory.Delete(mappedPath, true);

            _ctx.Listing.Remove(listing);
        }
    }
}