using LocusNew.Core.Models;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using LocusNew.Core;

namespace LocusNew.Areas.Admin.Controllers.ApiControllers
{
    [Authorize]
    public class PropertyTypesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public PropertyTypesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IQueryable<PropertyType> GetPropertyTypes()
        {
            return _unitOfWork.PropertyTypes.GetPropertyTypes();
        }

        [ResponseType(typeof(PropertyType))]
        public IHttpActionResult GetPropertyType(int id)
        {
            PropertyType propertyType = _unitOfWork.PropertyTypes.GetPropertyType(id);
            if (propertyType == null)
            {
                return NotFound();
            }

            return Ok(propertyType);
        }

        [ResponseType(typeof(PropertyType))]
        public IHttpActionResult AddNewPropertyType(PropertyType propertyType)
        {
            _unitOfWork.PropertyTypes.AddPropertyType(propertyType);
            _unitOfWork.Complete();

            return CreatedAtRoute("DefaultApi", new { id = propertyType.Id }, propertyType);
        }

        [HttpPost]
        public IHttpActionResult DeletePropertyType(int id)
        {
            if (!_unitOfWork.PropertyTypes.RemovePropertyType(id))
            {
                return BadRequest();
            }
            _unitOfWork.Complete();

            return Ok();
        }
    }
}
