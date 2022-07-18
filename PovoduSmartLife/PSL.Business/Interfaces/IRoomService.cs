using PSL.Core.Utilities.Results;
using PSL.Entities.Concrete.Locations;
using PSL.Entities.Dtos.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Business.Interfaces
{
    public interface IRoomService
    {
        Task<IResult> AddRoom(RoomDto room, int userId);
        Task<Room> GetRoom(Expression<Func<Room, bool>> filter);
        Task<ICollection<Room>> GetRoomList(Expression<Func<Room, bool>> filter);
        Task<IResult> UpdateRoom(RoomDto room, int userId);
        Task<IResult> DeleteRoom(int roomId);
    }
}
