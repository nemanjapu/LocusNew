using LocusNew.Core.ViewModels;
using System.Web.Mvc;
using System.Web.SessionState;
using LocusNew.Core;

namespace LocusNew.Controllers
{
    [SessionState(SessionStateBehavior.Disabled)]
    public class AboutUsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AboutUsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var model = new AboutUsViewModel()
            {
                Agents = _unitOfWork.Users.GetUsersByActivity(true),
                Global = _unitOfWork.GlobalSettings.GetGlobalSettings()
            };

            return View(model);
        }
    }
}