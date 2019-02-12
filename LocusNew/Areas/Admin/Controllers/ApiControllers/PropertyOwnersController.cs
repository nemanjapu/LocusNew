using LocusNew.Core.DTOs;
using LocusNew.Core.Models;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using LocusNew.Core;

namespace LocusNew.Areas.Admin.Controllers.ApiControllers
{
    [Authorize]
    public class PropertyOwnersController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public PropertyOwnersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IQueryable<GetHouseOwnersDTO> GetHouseOwners()
        {
            var houseOwners = _unitOfWork.PropertyOwners.GetPropertyOwners().Select(ho => new GetHouseOwnersDTO()
            {
                Id = ho.Id,
                FullName = ho.FirstName + " " + ho.LastName
            }).AsQueryable();

            return houseOwners;
        }

        [ResponseType(typeof(PropertyOwner))]
        public IHttpActionResult GetHouseOwner(int id)
        {
            PropertyOwner houseOwner = _unitOfWork.PropertyOwners.GetPropertyOwner(id);

            return Ok(houseOwner);
        }

        [ResponseType(typeof(PropertyOwner))]
        public IHttpActionResult AddNewHouseOwner(PropertyOwner propertyOwner)
        {
            _unitOfWork.PropertyOwners.AddPropertyOwner(propertyOwner);
            _unitOfWork.Complete();

            return CreatedAtRoute("DefaultApi", new { id = propertyOwner.Id }, propertyOwner);
        }
    }
}
