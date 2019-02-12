using LocusNew.Persistence;
using LocusNew.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LocusNew.Core.Repositories;

namespace LocusNew.Persistence.Repositories
{
    public class ListingImagesRepository : IListingImagesRepository
    {
        private readonly ApplicationDbContext _ctx;

        public ListingImagesRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public ListingImage GetListingImageByListingId(int listingId)
        {
            return _ctx.ListingImage.Where(limg => limg.ListingId == listingId).FirstOrDefault();
        }

        public IQueryable<ListingImage> GetListingImages()
        {
            return _ctx.ListingImage;
        }

        public void SetImagesOrder(IEnumerable<ListingImage> images)
        {
            foreach (var img in images)
            {
                var DbImage = _ctx.ListingImage.Find(img.Id);
                DbImage.SortOrder = img.SortOrder;
            }
        }

        public bool DeleteListingImage(int id)
        {
            ListingImage listingImage = _ctx.ListingImage.Find(id);
            if (_ctx.ListingImage.Where(limg => limg.ListingId == listingImage.ListingId).ToList().Count() > 1)
            {
                string fullPath = System.Web.Hosting.HostingEnvironment.MapPath("~/" + listingImage.FilePath + "/" + listingImage.FileName);
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }

                _ctx.ListingImage.Remove(listingImage);

                return true;
            }
            return false;
        }
    }
}