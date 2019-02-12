using LocusNew.Persistence;
using LocusNew.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LocusNew.Core.Repositories;

namespace LocusNew.Persistence.Repositories
{
    public class LeadsRepository : ILeadsRepository
    {
        private readonly ApplicationDbContext _ctx;

        public LeadsRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public Lead GetMessage(int id)
        {
            return _ctx.Lead.Find(id);
        }

        public IEnumerable<Lead> GetLeadsList()
        {
            return _ctx.Lead.ToList();
        }

        public void AddLead(Lead lead)
        {
            _ctx.Lead.Add(lead);
        }

        public void RemoveLead(int id)
        {
            _ctx.Lead.Remove(GetMessage(id));
        }
    }
}