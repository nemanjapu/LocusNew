using System.Collections.Generic;
using LocusNew.Core.Models;

namespace LocusNew.Core.Repositories
{
    public interface IPropertyBuyersRepository
    {
        void AddPropertyBuyer(PropertyBuyer propertyBuyer);
        int GetBuyersNumber();
        PropertyBuyer GetPropertyBuyer(int buyerId);
        IEnumerable<PropertyBuyer> GetPropertyBuyers();
        void RemovePropertyBuyer(int id);
    }
}