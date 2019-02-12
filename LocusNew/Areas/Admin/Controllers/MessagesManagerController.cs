using LocusNew.Core;
using System.Web.Mvc;

namespace LocusNew.Areas.Admin.Controllers
{
    [Authorize]
    public class MessagesManagerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MessagesManagerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var model = _unitOfWork.Leads.GetLeadsList();

            return View(model);
        }

        public ActionResult ViewMessage(int id)
        {
            var model = _unitOfWork.Leads.GetMessage(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMessage(int id)
        {
            _unitOfWork.Leads.RemoveLead(id);
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }
    }
}