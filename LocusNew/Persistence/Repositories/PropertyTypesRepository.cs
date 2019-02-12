using LocusNew.Persistence;
using LocusNew.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LocusNew.Core.Repositories;

namespace LocusNew.Persistence.Repositories
{
    public class PropertyTypesRepository : IPropertyTypesRepository
    {
        private readonly ApplicationDbContext _ctx;

        public PropertyTypesRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IQueryable<PropertyType> GetPropertyTypes()
        {
            return _ctx.PropertyType;
        }

        public PropertyType GetPropertyType(int id)
        {
            return _ctx.PropertyType.Find(id);
        }
        
        public void AddPropertyType(PropertyType type)
        {
            _ctx.PropertyType.Add(type);
        }

        public bool RemovePropertyType(int id)
        {
            if(_ctx.Listing.Any(l => l.PropertyTypeId == id))
            {
                return false;
            }

            _ctx.PropertyType.Remove(GetPropertyType(id));
            return true;
        }
    }
}