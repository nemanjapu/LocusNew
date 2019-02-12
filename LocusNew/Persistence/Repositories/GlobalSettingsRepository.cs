using LocusNew.Persistence;
using LocusNew.Core.Models;
using System.Linq;
using LocusNew.Core.Repositories;

namespace LocusNew.Persistence.Repositories
{
    public class GlobalSettingsRepository : IGlobalSettingsRepository
    {
        private readonly ApplicationDbContext _ctx;

        public GlobalSettingsRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public GlobalSettings GetGlobalSettings()
        {
            return _ctx.GlobalSettings.FirstOrDefault();
        }
    }
}