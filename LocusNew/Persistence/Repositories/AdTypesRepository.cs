using LocusNew.Core.Models;
using LocusNew.Core.Repositories;
using System.Linq;

namespace LocusNew.Persistence.Repositories
{
    public class AdTypesRepository : IAdTypesRepository
    {
        private readonly ApplicationDbContext _ctx;

        public AdTypesRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IQueryable<AdType> GetAdTypes()
        {
            return _ctx.AdType;
        }
    }
}