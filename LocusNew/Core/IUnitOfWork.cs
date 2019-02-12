using LocusNew.Core.Repositories;


namespace LocusNew.Core
{
    public interface IUnitOfWork
    {
        IAdTypesRepository AdTypes { get; }
        ICityPartsRepository CityParts { get; }
        IGlobalSettingsRepository GlobalSettings { get; }
        ILeadsRepository Leads { get; }
        IListingImagesRepository ListingImages { get; }
        IListingsRepository Listings { get; }
        IPropertyBuyersRepository PropertyBuyers { get; }
        IPropertyOwnersRepository PropertyOwners { get; }
        IPropertyTypesRepository PropertyTypes { get; }
        ISellerLeadsRepository SellerLeads { get; }
        IShowingsRepository Showing { get; }
        ISourcesRepository Sources { get; }
        IUsersRepository Users { get; }

        void Complete();
    }
}