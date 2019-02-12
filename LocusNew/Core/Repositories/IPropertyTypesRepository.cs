using System.Linq;
using LocusNew.Core.Models;

namespace LocusNew.Core.Repositories
{
    public interface IPropertyTypesRepository
    {
        void AddPropertyType(PropertyType type);
        PropertyType GetPropertyType(int id);
        IQueryable<PropertyType> GetPropertyTypes();
        bool RemovePropertyType(int id);
    }
}