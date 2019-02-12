using LocusNew.Core.Models;
using LocusNew.Core.Repositories;
using LocusNew.Persistence;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LocusNew.Persistence.Repositories
{
    public class SellerLeadsRepository : ISellerLeadsRepository
    {
        private readonly ApplicationDbContext _ctx;

        public SellerLeadsRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<SellerLead> GetSellerLeadsWithPropertyType()
        {
            return _ctx.SellerLead.Include(sl => sl.PropertyType).AsEnumerable();
        }

        public SellerLead GetSellerLead(int id)
        {
            return _ctx.SellerLead.Find(id);
        }

        public void AddSellerLead(SellerLead lead)
        {
            _ctx.SellerLead.Add(lead);
        }

        public void RemoveSellerLead(int id)
        {
            _ctx.SellerLead.Remove(GetSellerLead(id));
        }
    }
}