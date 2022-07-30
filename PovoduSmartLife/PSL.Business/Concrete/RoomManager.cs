using PSL.Business.Constants;
using PSL.Business.Interfaces;
using PSL.Core.Utilities.Results;
using PSL.DataAccess.Interfaces.Rooms;
using PSL.Entities.Concrete.Places;
using PSL.Entities.Dtos.Place;
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

        public async Task<IResult> AddRoom(RoomDto room, int userId)
        {
            try
            {
                await _roomDal.Add(new Room
                {
                    Name = room.Name,
                    Icon = room.Icon,
                    PlaceId = room.PlaceId,
                    BackgroundImage = room.BackgroundImage,
                    CreatedUser = userId,
                    CreatedDate = DateTime.Now,
                    UpdatedUser = userId,
                    UpdatedDate = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                return new ErrorResult(Messages.Failure_Added);
            }

            return new SuccessResult(Messages.Success_Added);
        }

        public async Task<IResult> DeleteRoom(int roomId)
        {
            try
            {
                var deleteRoom = await _roomDal.GetByIdAsync(roomId);
                if (deleteRoom == null)
                    throw new Exception(Messages.Failure_Deleted);
                await _roomDal.Delete(deleteRoom);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
            return new SuccessResult(Messages.Success_Deleted);
        }

        public async Task<Room> GetRoom(Expression<Func<Room, bool>> filter = null)
        {
            return await _roomDal.GetAsync(filter);
        }

        public async Task<ICollection<Room>> GetRoomList(Expression<Func<Room, bool>> filter = null)
        {
            return await _roomDal.GetListAsync(filter);
        }

        public async Task<IResult> UpdateRoom(RoomDto room, int userId)
        {
            try
            {
                Room updated = await _roomDal.GetAsync(x => x.Id == room.Id);
                if (updated.Name != room.Name) updated.Name = room.Name;
                if (updated.Icon != room.Icon) updated.Icon = room.Icon;
                if (updated.BackgroundImage != room.BackgroundImage) updated.BackgroundImage = room.BackgroundImage;
                if (updated.PlaceId != room.PlaceId) updated.PlaceId = room.PlaceId;
                updated.UpdatedDate = DateTime.Now;
                updated.UpdatedUser = userId;
                await _roomDal.Update(updated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(Messages.Failure_Updated);
            }
            return new SuccessResult(Messages.Success_Updated);
        }
    }
}
