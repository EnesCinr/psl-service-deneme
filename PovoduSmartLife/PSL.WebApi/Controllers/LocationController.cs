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

        [HttpGet("{id}")]
        public Task<Location> Get(int id)
        {
            return _locationService.GetLocationAsync(x => x.Id == id);
        }

        [HttpGet]
        public Task<ICollection<Location>> Get()
        {
            return _locationService.GetLocationListAsync(null);
        }

        [HttpPost]
        public void Add(LocationDto location)
        {
            _locationService.AddLocationAsync(location);
        }


        [HttpPut]
        public void Update(LocationDto location)
        {
            _locationService.UpdateLocationAsync(location);
        }


        [HttpDelete("{locationId}")]
        public void Delete(int locationId)
        {
            _locationService.DeleteLocationAsync(locationId);
        }
    }
}
