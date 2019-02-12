using LocusNew.Core.Models;
using System.Linq;

namespace LocusNew.Core.ViewModels
{
    public class AboutUsViewModel
    {
        public IQueryable<ApplicationUser> Agents { get; set; }
        public GlobalSettings Global { get; set; }
    }
}