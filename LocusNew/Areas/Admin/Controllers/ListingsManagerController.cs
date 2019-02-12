using AutoMapper;
using LocusNew.Core.AdminViewModels;
using LocusNew.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using System.IO;
using LocusNew.Core;

namespace LocusNew.Areas.Admin.Controllers
{
    [Authorize]
    public class ListingsManagerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ListingsManagerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index(string sortOrder, string listingNumber, string agent, int? page, int? cityPartId = 0, int? propertyType = 0, int? adType = 0, int? beds = 0, int? floor = -1, decimal? minPrice = 0, decimal? maxPrice = 0)
        {
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            var model = new AdminSearchListingsViewModel()
            {
                ListingsList = Mapper.Map<IEnumerable<AdminListingsListViewModel>>(
                    _unitOfWork.Listings.SearchListings(sortOrder, null, listingNumber, agent, true, false, false, cityPartId, propertyType, adType, beds, floor, minPrice, maxPrice))
                    .ToPagedList(pageNumber, pageSize),
                SearchForm = new AdminSearchFormViewModel()
                {
                    PropertyTypes = _unitOfWork.PropertyTypes.GetPropertyTypes().AsEnumerable(),
                    AdTypes = _unitOfWork.AdTypes.GetAdTypes(),
                    CityParts = _unitOfWork.CityParts.GetCityParts(),
                    selectedListingNumber = listingNumber,
                    Agents = _unitOfWork.Users.GetActiveAgents(),
                    AdTypeId = (int)adType,
                    CityPartId = cityPartId,
                    AgentId = agent,
                    selectedBeds = beds,
                    selectedFloor = floor,
                    selectedListingType = propertyType,
                    selectedMaxPrice = maxPrice,
                    selectedMinPrice = minPrice,
                    selectedSaleLease = adType,
                    selectedSortOrder = sortOrder
                }
            };

            ViewData["ResultNumber"] = model.ListingsList.TotalItemCount;

            return View(model);
        }

        public ActionResult InactiveListings(string sortOrder, string listingNumber, string agent, int? page, int? cityPartId = 0, int? propertyType = 0, int? adType = 0, int? beds = 0, int? floor = -1, decimal? minPrice = 0, decimal? maxPrice = 0)
        {
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            var model = new AdminSearchListingsViewModel()
            {
                ListingsList = Mapper.Map<IEnumerable<AdminListingsListViewModel>>(
                    _unitOfWork.Listings.SearchListings(sortOrder, null, listingNumber, agent, false, false, false, cityPartId, propertyType, adType, beds, floor, minPrice, maxPrice))
                    .ToPagedList(pageNumber, pageSize),
                SearchForm = new AdminSearchFormViewModel()
                {
                    PropertyTypes = _unitOfWork.PropertyTypes.GetPropertyTypes().AsEnumerable(),
                    AdTypes = _unitOfWork.AdTypes.GetAdTypes(),
                    CityParts = _unitOfWork.CityParts.GetCityParts(),
                    selectedListingNumber = listingNumber,
                    Agents = _unitOfWork.Users.GetActiveAgents(),
                    AdTypeId = (int)adType,
                    CityPartId = cityPartId,
                    AgentId = agent,
                    selectedBeds = beds,
                    selectedFloor = floor,
                    selectedListingType = propertyType,
                    selectedMaxPrice = maxPrice,
                    selectedMinPrice = minPrice,
                    selectedSaleLease = adType,
                    selectedSortOrder = sortOrder
                }
            };

            ViewData["ResultNumber"] = model.ListingsList.TotalItemCount;

            return View(model);
        }

        public ActionResult SoldListings(string sortOrder, string listingNumber, string agent, int? page, int? cityPartId = 0, int? propertyType = 0, int? adType = 0, int? beds = 0, int? floor = -1, decimal? minPrice = 0, decimal? maxPrice = 0)
        {
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            var model = new AdminSearchListingsViewModel()
            {
                ListingsList = Mapper.Map<IEnumerable<AdminListingsListViewModel>>(
                    _unitOfWork.Listings.SearchListings(sortOrder, null, listingNumber, agent, true, true, false, cityPartId, propertyType, adType, beds, floor, minPrice, maxPrice))
                    .ToPagedList(pageNumber, pageSize),
                SearchForm = new AdminSearchFormViewModel()
                {
                    PropertyTypes = _unitOfWork.PropertyTypes.GetPropertyTypes().AsEnumerable(),
                    AdTypes = _unitOfWork.AdTypes.GetAdTypes(),
                    CityParts = _unitOfWork.CityParts.GetCityParts(),
                    selectedListingNumber = listingNumber,
                    Agents = _unitOfWork.Users.GetActiveAgents(),
                    AdTypeId = (int)adType,
                    CityPartId = cityPartId,
                    AgentId = agent,
                    selectedBeds = beds,
                    selectedFloor = floor,
                    selectedListingType = propertyType,
                    selectedMaxPrice = maxPrice,
                    selectedMinPrice = minPrice,
                    selectedSaleLease = adType,
                    selectedSortOrder = sortOrder
                }
            };

            ViewData["ResultNumber"] = model.ListingsList.TotalItemCount;

            return View(model);
        }

        public ActionResult ReservedListings(string sortOrder, string listingNumber, string agent, int? page, int? cityPartId = 0, int? propertyType = 0, int? adType = 0, int? beds = 0, int? floor = -1, decimal? minPrice = 0, decimal? maxPrice = 0)
        {
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            var model = new AdminSearchListingsViewModel()
            {
                ListingsList = Mapper.Map<IEnumerable<AdminListingsListViewModel>>(
                    _unitOfWork.Listings.SearchListings(sortOrder, null, listingNumber, agent, true, false, true, cityPartId, propertyType, adType, beds, floor, minPrice, maxPrice))
                    .ToPagedList(pageNumber, pageSize),
                SearchForm = new AdminSearchFormViewModel()
                {
                    PropertyTypes = _unitOfWork.PropertyTypes.GetPropertyTypes().AsEnumerable(),
                    AdTypes = _unitOfWork.AdTypes.GetAdTypes(),
                    CityParts = _unitOfWork.CityParts.GetCityParts(),
                    selectedListingNumber = listingNumber,
                    Agents = _unitOfWork.Users.GetActiveAgents(),
                    AdTypeId = (int)adType,
                    CityPartId = cityPartId,
                    AgentId = agent,
                    selectedBeds = beds,
                    selectedFloor = floor,
                    selectedListingType = propertyType,
                    selectedMaxPrice = maxPrice,
                    selectedMinPrice = minPrice,
                    selectedSaleLease = adType,
                    selectedSortOrder = sortOrder
                }
            };

            ViewData["ResultNumber"] = model.ListingsList.TotalItemCount;

            return View(model);
        }

        public ActionResult AddListing()
        {
            var model = new AddListingViewModel()
            {
                AdTypes = _unitOfWork.AdTypes.GetAdTypes(),
                PropertyTypes = _unitOfWork.PropertyTypes.GetPropertyTypes().AsEnumerable(),
                Agents = _unitOfWork.Users.GetActiveAgents().AsEnumerable(),
                PropertyOwners = _unitOfWork.PropertyOwners.GetPropertyOwners(),
                CityParts = _unitOfWork.CityParts.GetCityParts().AsEnumerable(),
                Sources = _unitOfWork.Sources.GetSources().AsEnumerable(),
            };

            return View(model);
        }

        public ActionResult EditListing(int id)
        {
            var model = Mapper.Map<EditListingViewModel>(_unitOfWork.Listings.GetListing(id));

            model.AdTypes = _unitOfWork.AdTypes.GetAdTypes();
            model.PropertyTypes = _unitOfWork.PropertyTypes.GetPropertyTypes().AsEnumerable();
            model.Agents = _unitOfWork.Users.GetActiveAgents().AsEnumerable();
            model.PropertyOwners = _unitOfWork.PropertyOwners.GetPropertyOwners();
            model.CityParts = _unitOfWork.CityParts.GetCityParts().AsEnumerable();
            model.Sources = _unitOfWork.Sources.GetSources().AsEnumerable();

            return View("EditListing", model);
        }

        public JsonResult checkListinUniqueCode(string ListingUniqueCode)
        {
            return Json(!_unitOfWork.Listings.CheckListingUniqueCode(ListingUniqueCode), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveNewListing(AddListingViewModel listing)
        {
            List<ListingImage> images = new List<ListingImage>();
            Directory.CreateDirectory(Server.MapPath("~/DynamicContent/ListingImages/Listing" + listing.ListingUniqueCode.Trim()));
            var path = "~/DynamicContent/ListingImages/Listing" + listing.ListingUniqueCode.Trim();
            var pathToSave = "DynamicContent/ListingImages/Listing" + listing.ListingUniqueCode.Trim();
            var imgPath = "";
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    ListingImage fileDetail = new ListingImage()
                    {
                        FileName = fileName,
                        Extension = Path.GetExtension(fileName),
                        FileNameNoExt = Path.GetFileNameWithoutExtension(fileName),
                        FilePath = pathToSave
                    };
                    images.Add(fileDetail);

                    imgPath = Path.Combine(Server.MapPath(path), fileDetail.FileName);
                    file.SaveAs(imgPath);
                }
            }

            var dbListing = Mapper.Map<Listing>(listing);

            dbListing.Images = images;

            _unitOfWork.Listings.AddListing(dbListing);
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveEditedListing(EditListingViewModel listing)
        {
            var lisDb = Mapper.Map(listing, _unitOfWork.Listings.GetListing(listing.Id));

            List<ListingImage> images = new List<ListingImage>();
            var pathToSave = _unitOfWork.ListingImages.GetListingImageByListingId(listing.Id).FilePath;
            var path = "~/" + pathToSave;
            var imgPath = "";
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    ListingImage fileDetail = new ListingImage()
                    {
                        FileName = fileName,
                        Extension = Path.GetExtension(fileName),
                        FileNameNoExt = Path.GetFileNameWithoutExtension(fileName),
                        FilePath = pathToSave
                    };
                    images.Add(fileDetail);

                    imgPath = Path.Combine(Server.MapPath(path), fileDetail.FileName);
                    file.SaveAs(imgPath);
                }
            }
            var newImages = lisDb.Images.Concat(images).ToList();
            lisDb.Images = newImages;

            _unitOfWork.Complete();

            //Clear OutupCache for that listing after changed
            ClearCache(lisDb.Id);

            return RedirectToAction("EditListing", new { id = listing.Id });

        }

        public ActionResult SetAsSold(int id)
        {
            var model = new AddAsSoldViewModel
            {
                ListingId = id
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveAsSold(AddAsSoldViewModel sold)
        {
            var newBuyer = Mapper.Map<PropertyBuyer>(sold);

            var listing = _unitOfWork.Listings.GetListing(sold.Id);
            listing.isSold = true;
            listing.isReserved = false;

            _unitOfWork.PropertyBuyers.AddPropertyBuyer(newBuyer);
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteListing(int id)
        {
            _unitOfWork.Listings.RemoveListing(id);
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }

        public void ClearCache(int id)
        {
            Response.RemoveOutputCacheItem(Url.Action("Listing", "Search", new { id, area = "" }));
        }
    }
}