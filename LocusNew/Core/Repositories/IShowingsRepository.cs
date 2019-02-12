using System.Collections.Generic;
using LocusNew.Core.Models;

namespace LocusNew.Core.Repositories
{
    public interface IShowingsRepository
    {
        void AddShowing(BookAShowing bas);
        BookAShowing GetShowing(int id);
        IEnumerable<BookAShowing> GetShowings();
        void RemoveShowing(int id);
    }
}