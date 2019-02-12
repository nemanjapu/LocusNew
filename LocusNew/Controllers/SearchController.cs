using AutoMapper;
using LocusNew.Helpers;
using LocusNew.Core.Models;
using LocusNew.Core.ViewModels;
using PagedList;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.SessionState;
using System.Data.Entity;
using System.Globalization;
using LocusNew.Core;
using System.Collections.Generic;

namespace LocusNew.Controllers
{
    [SessionState(SessionStateBehavior.Disabled)]
    public class SearchController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SearchController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index(string sortOrder, string cityPart, string listingNumber, int? page, int? cityPartId = 0, int? propertyType = 0, int? adType = 0, int? beds = 0, int? floor = -1, decimal? minPrice = 0, decimal? maxPrice = 0)
        {
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            var model = new SearchViewModel()
            {
                Listings = Mapper.Map<IEnumerable<ListingsListViewModel>>(
                    _unitOfWork.Listings.SearchListings(sortOrder, cityPart, listingNumber, null, true, false, false, cityPartId, propertyType, adType, beds, floor, minPrice, maxPrice))
                    .ToPagedList(pageNumber, pageSize),
                SearchForm = new SearchFormViewModel()
                {
                    selectedCityPart = cityPartId,
                    selectedSaleLease = adType,
                    selectedListingType = propertyType,
                    selectedCityPartName = cityPart,
                    selectedFloor = floor - 1,
                    selectedBeds = beds,
                    selectedMinPrice = minPrice,
                    selectedMaxPrice = maxPrice,
                    selectedListingNumber = listingNumber,
                    PropertyTypes = _unitOfWork.PropertyTypes.GetPropertyTypes().AsEnumerable(),
                    AdTypes = _unitOfWork.AdTypes.GetAdTypes()
                }
            };

            ViewData["ResultNumber"] = model.Listings.TotalItemCount;

            return View(model);
        }

        [OutputCache(Duration = 604800, VaryByParam = "term")]
        public ActionResult CitiesAutoComplete(string term = "")
        {
            var CityPartsList = _unitOfWork.CityParts.GetCityPartAutocomplete(term);

            return Json(CityPartsList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Sold(int? page)
        {
            var model = _unitOfWork.Listings.GetListingsWithCityAndAdType()
                .AsNoTracking().Where(l => l.isSold == true && l.isActive == true)
                .OrderByDescending(l => l.Published)
                .Select(Mapper.Map<Listing, ListingsListViewModel>).AsQueryable();

            int pageSize = 8;
            int pageNumber = (page ?? 1);

            return View(model.ToPagedList(pageNumber, pageSize));
        }

        [OutputCache(Location = System.Web.UI.OutputCacheLocation.Server, Duration = 86400, VaryByParam = "id")]
        public ActionResult Listing(int id)
        {
            var listing = _unitOfWork.Listings.GetListingsWithCityAndAdType()
                .Include(l => l.ApplicationUser)
                .Where(l => l.Id == id).FirstOrDefault();

            if (listing.isActive == true)
            {
                if (listing.AdType.Name == "Oglas")
                {
                    var modelOglas = new ListingDetailsViewModel
                    {
                        Listing = Mapper.Map<ListingViewModel>(listing),
                        BookAShowing = null
                    };

                    return View("Ad", modelOglas);
                }

                var model = new ListingDetailsViewModel
                {
                    Listing = Mapper.Map<ListingViewModel>(listing),
                    BookAShowing = new BookAShowingViewModel
                    {
                        ListingId = listing.Id,
                        ApplicationUserId = listing.ApplicationUserId
                    }
                };

                return View(model);
            }

            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public string BookAShowing(ListingDetailsViewModel model)
        {
            var m = new BookAShowing
            {
                DateForShowing = DateTime.ParseExact(model.BookAShowing.DateForShowing, "dd.MM.yyyy", new CultureInfo("bs")),
                DateSubmited = DateTime.Now,
                Email = model.BookAShowing.Email,
                FirstName = model.BookAShowing.FirstName,
                LastName = model.BookAShowing.LastName,
                ListingId = model.BookAShowing.ListingId,
                Phone = model.BookAShowing.Phone,
                ApplicationUserId = model.BookAShowing.ApplicationUserId
            };

            _unitOfWork.Showing.AddShowing(m);
            _unitOfWork.Complete();

            var bookedListing = _unitOfWork.Listings.GetListing(model.BookAShowing.ListingId).Address + ", " + _unitOfWork.Listings.GetListing(model.BookAShowing.ListingId).ListingUniqueCode;
            
            EmailSender.SendEmail(null, null, model.BookAShowing, "", "", bookedListing);

            string message = "Ubrzo ćete biti kontaktirani od strane našeg agenta.";

            return message;
        }
    }
}