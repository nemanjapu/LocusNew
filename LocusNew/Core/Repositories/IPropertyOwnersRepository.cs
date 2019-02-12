using System.Collections.Generic;
using LocusNew.Core.Models;

namespace LocusNew.Core.Repositories
{
    public interface IPropertyOwnersRepository
    {
        void AddPropertyOwner(PropertyOwner propertyOwner);
        PropertyOwner GetPropertyOwner(int sellerId);
        IEnumerable<PropertyOwner> GetPropertyOwners();
        int GetSellersNumber();
        void RemovePropertyOwner(int id);
    }
}