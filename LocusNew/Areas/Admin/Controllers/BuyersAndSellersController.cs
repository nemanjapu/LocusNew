using AutoMapper;
using LocusNew.Core.AdminViewModels;
using System.Collections.Generic;
using System.Web.Mvc;
using LocusNew.Core.Models;
using LocusNew.Core;

namespace LocusNew.Areas.Admin.Controllers
{
    [Authorize]
    public class BuyersAndSellersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BuyersAndSellersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var model = new BuyersSellersViewModel
            {
                BuyersList = Mapper.Map<IEnumerable<BuyersViewModel>>(_unitOfWork.PropertyBuyers.GetPropertyBuyers()),
                SellersList = Mapper.Map<IEnumerable<SellersViewModel>>(_unitOfWork.PropertyOwners.GetPropertyOwners())
            };

            return View(model);
        }

        public ActionResult DeleteSeller(int id)
        {
            _unitOfWork.PropertyOwners.RemovePropertyOwner(id);
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }

        public ActionResult DeleteBuyer(int id)
        {
            _unitOfWork.PropertyBuyers.RemovePropertyBuyer(id);
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }

        public ActionResult EditBuyer(int id)
        {
            var model = Mapper.Map<BuyersViewModel>(_unitOfWork.PropertyBuyers.GetPropertyBuyer(id));

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveEditedBuyer(BuyersViewModel buyer)
        {
            Mapper.Map(buyer, _unitOfWork.PropertyBuyers.GetPropertyBuyer(buyer.Id));
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }

        public ActionResult EditSeller(int id)
        {
            var model = Mapper.Map<SellersViewModel>(_unitOfWork.PropertyOwners.GetPropertyOwner(id));

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveEditedSeller(SellersViewModel seller)
        {
            Mapper.Map(seller, _unitOfWork.PropertyOwners.GetPropertyOwner(seller.Id));
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }
    }
}