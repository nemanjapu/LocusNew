using System.Linq;
using LocusNew.Core.Models;

namespace LocusNew.Core.Repositories
{
    public interface ICityPartsRepository
    {
        void AddCityPart(CityPart cityPart);
        CityPart GetCityPart(int id);
        object GetCityPartAutocomplete(string term);
        IQueryable<CityPart> GetCityParts();
        bool RemoveCityPart(int id);
    }
}