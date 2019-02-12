using AutoMapper;
using LocusNew.Helpers;
using LocusNew.Core.Models;
using LocusNew.Core.ViewModels;
using System.Web.Mvc;
using System.Web.SessionState;
using LocusNew.Core;

namespace LocusNew.Controllers
{
    [SessionState(SessionStateBehavior.Disabled)]
    public class SellingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SellingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var model = new SellerLeadViewModel
            {
                IsSelling = true,
                PropertyTypes = _unitOfWork.PropertyTypes.GetPropertyTypes()
            };

            return View(model);
        }

        public ActionResult Repurchase()
        {
            var model = new SellerLeadViewModel
            {
                IsRepurchasing = true,
                PropertyTypes = _unitOfWork.PropertyTypes.GetPropertyTypes()
            };

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public string Submit(SellerLeadViewModel model)
        {
            var heDb = Mapper.Map<SellerLead>(model);

            _unitOfWork.SellerLeads.AddSellerLead(heDb);
            _unitOfWork.Complete();

            string SellOrRepuchase = model.IsRepurchasing ? "otkup" : model.IsSelling ? "prodaju" : "";

            string listType = _unitOfWork.PropertyTypes.GetPropertyType(model.PropertyTypeId).Name;

            EmailSender.SendEmail(null, model, null, SellOrRepuchase, listType, "");

            string message = "Uskoro ćete biti kontaktirani od strane našeg agenta.";

            return message;
        }
    }
}