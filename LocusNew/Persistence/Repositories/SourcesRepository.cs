using LocusNew.Core.Models;
using LocusNew.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocusNew.Persistence.Repositories
{
    public class SourcesRepository : ISourcesRepository
    {
        private readonly ApplicationDbContext _ctx;

        public SourcesRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IQueryable<Source> GetSources()
        {
            return _ctx.Source;
        }
    }
}