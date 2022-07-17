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
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet("{id}")]
        public Task<Room> Get(int id)
        {
            return _roomService.GetRoomAsync(x => x.Id == id);
        }

        [HttpGet]
        public Task<ICollection<Room>> Get()
        {
            return _roomService.GetRoomListAsync(null);
        }

        [HttpPost]
        public void Add(RoomDto room)
        {
            _roomService.AddRoomAsync(room);
        }


        [HttpPut]
        public void Update(RoomDto room)
        {
            _roomService.UpdateRoomAsync(room);
        }


        [HttpDelete("{id}")]
        public void Delete(int roomId)
        {
            _roomService.DeleteRoomAsync(roomId);
        }
    }
}
