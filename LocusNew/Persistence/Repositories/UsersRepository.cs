using LocusNew.Persistence;
using LocusNew.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LocusNew.Core.Repositories;

namespace LocusNew.Persistence.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext _ctx;

        public UsersRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public ApplicationUser GetApplicationUser(string id)
        {
            return _ctx.Users.Find(id);
        }

        public IQueryable<ApplicationUser> GetUsersByActivity(bool isActive)
        {
            return _ctx.Users.Where(u => !u.isDev && u.isActive == isActive).AsQueryable();
        }

        public IQueryable<ApplicationUser> GetActiveAgents()
        {
            return _ctx.Users.Where(u => !u.isDev && u.isActive && u.isAgent).AsQueryable();
        }
    }
}