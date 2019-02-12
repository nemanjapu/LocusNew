using LocusNew.Persistence;
using LocusNew.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LocusNew.Core.Repositories;

namespace LocusNew.Persistence.Repositories
{
    public class CityPartsRepository : ICityPartsRepository
    {
        private readonly ApplicationDbContext _ctx;

        public CityPartsRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IQueryable<CityPart> GetCityParts()
        {
            return _ctx.CityPart;
        }

        public CityPart GetCityPart(int id)
        {
            return _ctx.CityPart.Find(id);
        }

        public object GetCityPartAutocomplete(string term)
        {
            return _ctx.CityPart.Where(b => b.Name.ToUpper().Contains(term.ToUpper()))
                .Select(b => new { Name = b.Name, Id = b.Id })
                .Distinct().ToList();
        }

        public void AddCityPart(CityPart cityPart)
        {
            _ctx.CityPart.Add(cityPart);
        }

        public bool RemoveCityPart(int id)
        {
            if (_ctx.Listing.Any(l => l.CityPartId == id))
            {
                return false;
            }

            _ctx.CityPart.Remove(GetCityPart(id));
            return true;
        }
    }
}