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
        public Task<Place> Get(int id)
        {
            return _placeService.GetPlace(x => x.Id == id);
        }

        [HttpGet]
        public async Task<ICollection<Place>> Get()
        {
            return await _placeService.GetPlaceList(null);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PlaceDto place)
        {
            //var loggedUser = await base.GetLoggedUserInformation();
            var result = await _placeService.AddPlace(place, 4);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }


        [HttpPut]
        public async Task<IActionResult> Update(PlaceDto place)
        {
            //var loggedUser = await base.GetLoggedUserInformation();
            var result = await _placeService.UpdatePlace(place, 4);// loggedUser.Id);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }


        [HttpDelete("{placeId}")]
        public async Task<IActionResult> Delete(int placeId)
        {
            var result = await _placeService.DeletePlace(placeId);
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
