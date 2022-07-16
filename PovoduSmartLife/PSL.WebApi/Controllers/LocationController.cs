using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSL.Business.Interfaces;
using PSL.DataAccess.Interfaces.Locations;
using PSL.Entities.Concrete.Locations;
using PSL.Entities.Dtos.Location;

namespace PSL.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/location")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        //private readonly ILocationDal _locationDal;
        //public LocationController(ILocationDal locationDal)
        //{
        //    _locationDal = locationDal;
        //}

        [HttpGet("{id}")]
        public Location Get(int id)
        {
            return new Location();
        }

        [HttpGet]
        public List<Location> Get()
        {
            return new List<Location>();
        }

        [HttpPost]
        public void Add(LocationDto location)
        {
            _locationService.AddLocation(location);
        }


        [HttpPut]
        public void Update(LocationDto location)
        {

        }


        [HttpDelete]
        public void Delete(int locationId)
        {

        }
    }
}
