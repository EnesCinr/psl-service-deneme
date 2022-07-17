using PSL.Business.Interfaces;
using PSL.DataAccess.Interfaces.Rooms;
using PSL.Entities.Concrete.Locations;
using PSL.Entities.Dtos.Location;
using System.Linq.Expressions;

namespace PSL.Business.Concrete
{
    public class RoomManager : IRoomService
    {
        private readonly IRoomDal _roomDal;
        public RoomManager(IRoomDal roomDal)
        {
            _roomDal = roomDal;
        }

        public Task AddRoomAsync(RoomDto room)
        {
            return _roomDal.Add(new Room
            {
                Name = room.Name,
                Icon = room.Icon,
                LocationId = room.LocationId,
                BackgroundImage = room.BackgroundImageUrl,
                CreatedUser = 4,
                CreatedDate = DateTime.Now,
                UpdatedUser = 4,
                UpdatedDate = DateTime.Now
            });
        }

        public Task DeleteRoomAsync(int roomId)
        {
            return _roomDal.Delete(new Room { Id = roomId });
        }

        public Task<Room> GetRoomAsync(Expression<Func<Room, bool>> filter = null)
        {
            return _roomDal.GetAsync(filter);
        }

        public Task<ICollection<Room>> GetRoomListAsync(Expression<Func<Room, bool>> filter = null)
        {
            return _roomDal.GetListAsync(filter);
        }

        public Task UpdateRoomAsync(RoomDto room)
        {
            return _roomDal.Update(new Room
            {
                Name = room.Name,
                Icon = room.Icon,
                LocationId = room.LocationId,
                BackgroundImage = room.BackgroundImageUrl,
                CreatedUser = 4,
                CreatedDate = DateTime.Now,
                UpdatedUser = 4,
                UpdatedDate = DateTime.Now
            });
        }
    }
}
