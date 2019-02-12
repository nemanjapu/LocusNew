using AutoMapper;
using LocusNew.Core.AdminViewModels;
using System.Web.Mvc;
using System.Collections.Generic;
using LocusNew.Core;

namespace LocusNew.Areas.Admin.Controllers
{
    [Authorize]
    public class SellerLeadsManagerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SellerLeadsManagerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var model = Mapper.Map<IEnumerable<SellerLeadsViewModel>>(_unitOfWork.SellerLeads.GetSellerLeadsWithPropertyType());

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSellerLead(int id)
        {
            _unitOfWork.SellerLeads.RemoveSellerLead(id);
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }
    }
}