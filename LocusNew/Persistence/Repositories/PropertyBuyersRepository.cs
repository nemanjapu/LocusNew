using LocusNew.Persistence;
using LocusNew.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LocusNew.Core.Repositories;

namespace LocusNew.Persistence.Repositories
{
    public class PropertyBuyersRepository : IPropertyBuyersRepository
    {
        private readonly ApplicationDbContext _ctx;

        public PropertyBuyersRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public PropertyBuyer GetPropertyBuyer(int buyerId)
        {
            return _ctx.PropertyBuyer.Find(buyerId);
        }

        public IEnumerable<PropertyBuyer> GetPropertyBuyers()
        {
            return _ctx.PropertyBuyer.AsEnumerable();
        }

        public int GetBuyersNumber()
        {
            return _ctx.PropertyBuyer.Count();
        }

        public void AddPropertyBuyer(PropertyBuyer propertyBuyer)
        {
            _ctx.PropertyBuyer.Add(propertyBuyer);
        }

        public void RemovePropertyBuyer(int id)
        {
            _ctx.PropertyBuyer.Remove(GetPropertyBuyer(id));
        }
    }
}