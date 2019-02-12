using System.Linq;
using LocusNew.Core.Models;

namespace LocusNew.Core.Repositories
{
    public interface IUsersRepository
    {
        IQueryable<ApplicationUser> GetActiveAgents();
        ApplicationUser GetApplicationUser(string id);
        IQueryable<ApplicationUser> GetUsersByActivity(bool isActive);
    }
}