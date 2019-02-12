using LocusNew.Core;
using LocusNew.Core.Repositories;
using LocusNew.Persistence.Repositories;

namespace LocusNew.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _ctx;

        public IUsersRepository Users { get; private set; }
        public IGlobalSettingsRepository GlobalSettings { get; private set; }
        public IListingsRepository Listings { get; private set; }
        public ILeadsRepository Leads { get; private set; }
        public ISellerLeadsRepository SellerLeads { get; private set; }
        public IShowingsRepository Showing { get; private set; }
        public IPropertyTypesRepository PropertyTypes { get; private set; }
        public ICityPartsRepository CityParts { get; private set; }
        public IPropertyBuyersRepository PropertyBuyers { get; private set; }
        public IPropertyOwnersRepository PropertyOwners { get; private set; }
        public IListingImagesRepository ListingImages { get; private set; }
        public IAdTypesRepository AdTypes { get; private set; }
        public ISourcesRepository Sources { get; private set; }

        public UnitOfWork(ApplicationDbContext ctx)
        {
            _ctx = ctx;
            Users = new UsersRepository(ctx);
            GlobalSettings = new GlobalSettingsRepository(ctx);
            Listings = new ListingsRepository(ctx);
            Leads = new LeadsRepository(ctx);
            SellerLeads = new SellerLeadsRepository(ctx);
            Showing = new ShowingsRepository(ctx);
            PropertyTypes = new PropertyTypesRepository(ctx);
            CityParts = new CityPartsRepository(ctx);
            PropertyBuyers = new PropertyBuyersRepository(ctx);
            PropertyOwners = new PropertyOwnersRepository(ctx);
            ListingImages = new ListingImagesRepository(ctx);
            AdTypes = new AdTypesRepository(ctx);
            Sources = new SourcesRepository(ctx);
        }

        public void Complete()
        {
            _ctx.SaveChanges();
        }

    }
}