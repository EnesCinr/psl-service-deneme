﻿using PSL.Business.Constants;
using PSL.Business.Interfaces;
using PSL.Core.Utilities.Results;
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

        public async Task<IResult> AddRoom(RoomDto room, int userId)
        {
            try
            {
                await _roomDal.Add(new Room
                {
                    Name = room.Name,
                    Icon = room.Icon,
                    LocationId = room.LocationId,
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
                await _roomDal.Update(new Room
                {
                    Name = room.Name,
                    Icon = room.Icon,
                    LocationId = room.LocationId,
                    BackgroundImage = room.BackgroundImage,
                    UpdatedUser = userId,
                    UpdatedDate = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                return new ErrorResult(Messages.Failure_Updated);
            }
            return new SuccessResult(Messages.Success_Updated);
        }
    }
}
