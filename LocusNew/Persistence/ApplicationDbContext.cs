using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using LocusNew.Core.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LocusNew.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<AdType> AdType { get; set; }
        public DbSet<Listing> Listing { get; set; }
        public DbSet<ListingImage> ListingImage { get; set; }
        public DbSet<PropertyType> PropertyType { get; set; }
        public DbSet<CityPart> CityPart { get; set; }
        public DbSet<PropertyOwner> PropertyOwner { get; set; }
        public DbSet<PropertyBuyer> PropertyBuyer { get; set; }
        public DbSet<GlobalSettings> GlobalSettings { get; set; }
        public DbSet<BookAShowing> BookAShowing { get; set; }
        public DbSet<Lead> Lead { get; set; }
        public DbSet<SellerLead> SellerLead { get; set; }
        public DbSet<Source> Source { get; set; }
    }
}