using System.Linq;
using LocusNew.Core.Models;

namespace LocusNew.Core.Repositories
{
    public interface ISourcesRepository
    {
        IQueryable<Source> GetSources();
    }
}