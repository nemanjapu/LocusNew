using LocusNew.Core;
using LocusNew.Core.Models;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace LocusNew.Areas.Admin.Controllers.ApiControllers
{
    [Authorize]
    public class CityPartsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public CityPartsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IQueryable<CityPart> GetCityParts()
        {
            return _unitOfWork.CityParts.GetCityParts();
        }

        [ResponseType(typeof(CityPart))]
        public IHttpActionResult GetCityPart(int id)
        {
            CityPart cityPart = _unitOfWork.CityParts.GetCityPart(id);
            if (cityPart == null)
            {
                return NotFound();
            }

            return Ok(cityPart);
        }

        [ResponseType(typeof(CityPart))]
        public IHttpActionResult AddNewCityPart(CityPart cityPart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.CityParts.AddCityPart(cityPart);
            _unitOfWork.Complete();

            return CreatedAtRoute("DefaultApi", new { id = cityPart.Id }, cityPart);
        }

        [HttpPost]
        public IHttpActionResult DeleteCityPart(int id)
        {
            if (!_unitOfWork.CityParts.RemoveCityPart(id))
            {
                return BadRequest();
            }
            _unitOfWork.Complete();

            return Ok();
        }
    }
}