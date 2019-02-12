using LocusNew.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocusNew.Controllers
{
    public class MapSearchController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MapSearchController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetListings()
        {
            var listings = _unitOfWork.Listings.GetListings().Select(l => new
            {
                Id = l.Id,
                Address = l.Address,
                CityPart = l.CityPart.Name,
                Longitude = l.Longitude,
                Latitude = l.Latidute
            }).ToList();

            return Json(listings, JsonRequestBehavior.AllowGet);
        }

        public ActionResult MapSearchAutoComplete(string term = "")
        {
            var CityPartsList = _unitOfWork.Listings.MapSearchAutocomplete(term);

            return Json(CityPartsList, JsonRequestBehavior.AllowGet);
        }
    }
}