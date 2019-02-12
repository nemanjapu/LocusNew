using LocusNew.Core.Models;
using System.Collections.Generic;
using System.Web.Http;
using LocusNew.Core;

namespace LocusNew.Areas.Admin.Controllers.ApiControllers
{
    [Authorize]
    public class ListingImagesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ListingImagesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IHttpActionResult SetImagesOrder(IEnumerable<ListingImage> images)
        {
            _unitOfWork.ListingImages.SetImagesOrder(images);
            _unitOfWork.Complete();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult DeleteListingImage(int id)
        {
            if (!_unitOfWork.ListingImages.DeleteListingImage(id))
            {
                return BadRequest();
            }
            _unitOfWork.Complete();

            return Ok();
        }
    }
}
