using LocusNew.Persistence;
using LocusNew.Core.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using LocusNew.Core.Repositories;

namespace LocusNew.Persistence.Repositories
{
    public class ShowingsRepository : IShowingsRepository
    {
        private readonly ApplicationDbContext _ctx;

        public ShowingsRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public BookAShowing GetShowing(int id)
        {
            return _ctx.BookAShowing.Find(id);
        }

        public IEnumerable<BookAShowing> GetShowings()
        {
            return _ctx.BookAShowing.Include(m => m.Listing).Include(m => m.ApplicationUser).Include(m => m.Listing.CityPart).AsEnumerable();
        }

        public void AddShowing(BookAShowing bas)
        {
            _ctx.BookAShowing.Add(bas);
        }

        public void RemoveShowing(int id)
        {
            _ctx.BookAShowing.Remove(GetShowing(id));
        }
    }
}