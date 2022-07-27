using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSL.Business.Interfaces;
using PSL.Entities.Concrete.Locations;
using PSL.Entities.Dtos.Location;

namespace PSL.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/room")]
    [ApiController]
    public class RoomController : BaseController
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService, IAuthService authService) : base(authService)
        {
            _roomService = roomService;
        }

        [HttpGet("{id}")]
        public async Task<Room> Get(int id)
        {
            return await _roomService.GetRoom(x => x.Id == id);
        }

        [HttpGet]
        public async Task<ICollection<Room>> Get()
        {
            return await _roomService.GetRoomList(null);
        }

        [HttpPost]
        public async Task<IActionResult> Add(RoomDto room)
        {
            //var loggedUser = await base.GetLoggedUserInformation();
            var result = await _roomService.AddRoom(room, 4);// loggedUser.Id);
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> Update(RoomDto room)
        {
            //var loggedUser = await base.GetLoggedUserInformation();
            var result = _roomService.UpdateRoom(room, 4);// loggedUser.Id);
            return Ok(result);
        }


        [HttpDelete("{roomId}")]
        public async Task<IActionResult> Delete(int roomId)
        {
            var result = await _roomService.DeleteRoom(roomId);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }
    }
}
