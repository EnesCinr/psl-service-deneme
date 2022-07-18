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
    public class LocationController : BaseController
    {
        private readonly ILocationService _locationService;
        public LocationController(ILocationService locationService, IAuthService authService) : base(authService)
        {
            _locationService = locationService;
        }

        [HttpGet("{id}")]
        public Task<Location> Get(int id)
        {
            return _locationService.GetLocation(x => x.Id == id);
        }

        [HttpGet]
        public async Task<ICollection<Location>> Get()
        {
            return await _locationService.GetLocationList(null);
        }

        [HttpPost]
        public async Task<IActionResult> Add(LocationDto location)
        {
            var loggedUser = await base.GetLoggedUserInformation();
            var result = await _locationService.AddLocation(location, loggedUser.Id);
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> Update(LocationDto location)
        {
            var loggedUser = await base.GetLoggedUserInformation();
            var result = await _locationService.UpdateLocation(location, loggedUser.Id);
            return Ok(result);
        }


        [HttpDelete("{locationId}")]
        public async Task<IActionResult> Delete(int locationId)
        {
            var result = await _locationService.DeleteLocation(locationId);
            return Ok(result);
        }
    }
}
