using LocusNew.Core;
using System.Web.Mvc;

namespace LocusNew.Areas.Admin.Controllers
{
    [Authorize]
    public class ShowingsManagerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShowingsManagerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var model = _unitOfWork.Showing.GetShowings();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteShowing(int id)
        {
            _unitOfWork.Showing.RemoveShowing(id);
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }
    }
}