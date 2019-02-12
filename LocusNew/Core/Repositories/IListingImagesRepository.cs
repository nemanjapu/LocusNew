using System.Collections.Generic;
using System.Linq;
using LocusNew.Core.Models;

namespace LocusNew.Core.Repositories
{
    public interface IListingImagesRepository
    {
        bool DeleteListingImage(int id);
        ListingImage GetListingImageByListingId(int listingId);
        IQueryable<ListingImage> GetListingImages();
        void SetImagesOrder(IEnumerable<ListingImage> images);
    }
}