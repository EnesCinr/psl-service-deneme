using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSL.Business.Interfaces;
using PSL.DataAccess.Interfaces.Places;
using PSL.Entities.Concrete.Places;
using PSL.Entities.Dtos.Place;

namespace PSL.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/place")]
    [ApiController]
    public class PlaceController : BaseController
    {
        private readonly IPlaceService _placeService;
        public PlaceController(IPlaceService placeService, IAuthService authService) : base(authService)
        {
            _placeService = placeService;
        }

        [HttpGet("{id}")]
        public async Task<Place> Get(int id)
        {
            var loggedUser = await base.GetLoggedUserInformation();
            return await _placeService.GetPlace(id, loggedUser.Id);
        }

        [HttpGet]
        public async Task<ICollection<Place>> Get()
        {
            var loggedUser = await base.GetLoggedUserInformation();
            return await _placeService.GetPlaceList(loggedUser.Id);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PlaceDto place)
        {
            var loggedUser = await base.GetLoggedUserInformation();
            var result = await _placeService.AddPlace(place, loggedUser.Id);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }


        [HttpPut]
        public async Task<IActionResult> Update(PlaceDto place)
        {
            var loggedUser = await base.GetLoggedUserInformation();
            var result = await _placeService.UpdatePlace(place, loggedUser.Id);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }


        [HttpDelete("{placeId}")]
        public async Task<IActionResult> Delete(int placeId)
        {
            var loggedUser = await base.GetLoggedUserInformation();
            var result = await _placeService.DeletePlace(placeId, loggedUser.Id);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [HttpPost("add-default-values")]
        public async Task<IActionResult> AddPlaceWithRoomsForDefaultValue(PlaceWithRoomsForDefaultValueDto placeWithRoomsForDefaultValueDto)
        {
            var loggedUser = await base.GetLoggedUserInformation();
            var result = await _placeService.AddPlaceWithRoomsForDefaultValue(placeWithRoomsForDefaultValueDto, loggedUser.Id);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }
    }
}
