using System.Linq;
using LocusNew.Core.Models;

namespace LocusNew.Core.Repositories
{
    public interface IAdTypesRepository
    {
        IQueryable<AdType> GetAdTypes();
    }
}