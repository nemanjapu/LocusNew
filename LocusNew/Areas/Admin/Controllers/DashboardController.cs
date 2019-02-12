using LocusNew.Core.AdminViewModels;
using LocusNew.Core;
using System.Linq;
using System.Web.Mvc;

namespace LocusNew.Areas.Admin.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DashboardController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var model = new DashboardViewModel()
            {
                ListingsNumber = _unitOfWork.Listings.GetListingsNumber(),
                ActiveListings = _unitOfWork.Listings.GetListingsNumberByStatus(true, false, false),
                InactiveListings = _unitOfWork.Listings.GetListingsNumberByStatus(false, false, false),
                SoldListings = _unitOfWork.Listings.GetListingsNumberByStatus(true, false, true),
                ReservedListings = _unitOfWork.Listings.GetListingsNumberByStatus(true, true, false),
                Agents = _unitOfWork.Users.GetActiveAgents().ToList().Select(u => new AgentsDashboardViewModel()
                {
                    Name = u.FirstName + " " + u.LastName,
                    NumberOfListings = _unitOfWork.Listings.GetListingsNumberForAgent(u.Id)
                }),
                BuyersNumber = _unitOfWork.PropertyBuyers.GetBuyersNumber(),
                SellersNumber = _unitOfWork.PropertyOwners.GetSellersNumber(),
                EmployeesNumber = _unitOfWork.Users.GetUsersByActivity(true).Count()
            };

            return View(model);
        }
    }
}