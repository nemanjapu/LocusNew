using LocusNew.Persistence;
using LocusNew.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LocusNew.Core.Repositories;

namespace LocusNew.Persistence.Repositories
{
    public class PropertyOwnersRepository : IPropertyOwnersRepository
    {
        private readonly ApplicationDbContext _ctx;

        public PropertyOwnersRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public PropertyOwner GetPropertyOwner(int sellerId)
        {
            return _ctx.PropertyOwner.Find(sellerId);
        }

        public IEnumerable<PropertyOwner> GetPropertyOwners()
        {
            return _ctx.PropertyOwner.AsEnumerable();
        }

        public int GetSellersNumber()
        {
            return _ctx.PropertyOwner.Count();
        }

        public void AddPropertyOwner(PropertyOwner propertyOwner)
        {
            _ctx.PropertyOwner.Add(propertyOwner);
        }

        public void RemovePropertyOwner(int id)
        {
            if (!_ctx.Listing.Any(l => l.PropertyOwnerId == id))
            {
                _ctx.PropertyOwner.Remove(GetPropertyOwner(id));
            }
        }
    }
}