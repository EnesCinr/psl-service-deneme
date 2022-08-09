using PSL.Core.Utilities.Results;
using PSL.Entities.Concrete.Places;
using PSL.Entities.Dtos.Place;
using System.Linq.Expressions;

namespace PSL.Business.Interfaces
{
    public interface IRoomService
    {
        Task<IResult> AddRoom(RoomDto room, int userId);
        Task<IResult> AddRooms(List<RoomDto> rooms, int userId);
        Task<Room> GetRoom(int roomId, int userId);
        Task<ICollection<Room>> GetRoomListByUserId(int userId, int placeId);
        Task<IResult> UpdateRoom(RoomDto room, int userId);
        Task<IResult> DeleteRoom(int roomId, int userId);
    }
}
