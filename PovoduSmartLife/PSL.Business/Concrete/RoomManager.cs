using AutoMapper;
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
        private readonly IMapper _mapper;
        public RoomManager(IRoomDal roomDal, IMapper mapper)
        {
            _roomDal = roomDal;
            _mapper = mapper;
        }

        public async Task<IResult> AddRoom(RoomDto room, int userId)
        {
            try
            {
                var mappedRoom = _mapper.Map<Room>(room);
                mappedRoom.CreatedDate = DateTime.Now;
                mappedRoom.CreatedUser = userId;
                await _roomDal.Add(mappedRoom);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }

            return new SuccessResult(Messages.Success_Added);
        }

        public async Task<IResult> AddRooms(List<RoomDto> rooms, int userId)
        {
            try
            {
                var mappedRooms = _mapper.Map<List<Room>>(rooms);
                var datetimeNow = DateTime.Now;
                mappedRooms.ForEach(f => f.CreatedDate = datetimeNow);
                mappedRooms.ForEach(f => f.CreatedUser = userId);

                await _roomDal.AddRangeAsync(mappedRooms);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }

            return new SuccessResult(Messages.Success_Added);
        }

        public async Task<IResult> DeleteRoom(int roomId)
        {
            try
            {
                var deleteRoom = await _roomDal.GetByIdAsync(roomId);
                if (deleteRoom == null)
                    throw new Exception(Messages.DataNotExists);
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
                var updated = _mapper.Map<Room>(room);
                updated.UpdatedDate = DateTime.Now;
                updated.UpdatedUser = userId;
                await _roomDal.Update(updated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
            return new SuccessResult(Messages.Success_Updated);
        }
    }
}
