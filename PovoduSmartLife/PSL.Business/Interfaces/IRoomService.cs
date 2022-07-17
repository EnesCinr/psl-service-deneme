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
        public Task AddRoomAsync(RoomDto room);
        public Task<Room> GetRoomAsync(Expression<Func<Room, bool>> filter);
        public Task<ICollection<Room>> GetRoomListAsync(Expression<Func<Room, bool>> filter);
        public Task UpdateRoomAsync(RoomDto room);
        public Task DeleteRoomAsync(int roomId);
    }
}
