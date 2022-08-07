using AutoMapper;
using PSL.Business.Constants;
using PSL.Business.Interfaces;
using PSL.Core.Utilities.Results;
using PSL.DataAccess.Interfaces.Places;
using PSL.Entities.Concrete.Places;
using PSL.Entities.Dtos.Place;
using System.Linq.Expressions;

namespace PSL.Business.Concrete
{
    public class PlaceManager : IPlaceService
    {
        private readonly IPlaceDal _placeDal;
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;
        public PlaceManager(IPlaceDal placeDal, IMapper mapper, IRoomService roomService)
        {
            _placeDal = placeDal;
            _mapper = mapper;
            _roomService = roomService;
        }

        public async Task<IResult> AddPlace(PlaceDto place, int userId)
        {
            try
            {
                var mappedPlace = _mapper.Map<Place>(place);
                mappedPlace.CreatedDate = DateTime.Now;
                mappedPlace.CreatedUser = mappedPlace.UserId = userId;
                await _placeDal.Add(mappedPlace);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }

            return new SuccessResult(Messages.Success_Added);
        }

        public async Task<IResult> AddPlaceWithRoomsForDefaultValue(PlaceWithRoomsForDefaultValueDto placeWithRoomsForDefaultValueDto, int userId)
        {
            try
            {
                var datetimeNow = DateTime.Now;

                var mappedPlace = _mapper.Map<Place>(placeWithRoomsForDefaultValueDto.Place);
                mappedPlace.CreatedDate = datetimeNow;
                mappedPlace.CreatedUser = mappedPlace.UserId = userId;

                mappedPlace.Rooms = _mapper.Map<List<Room>>(placeWithRoomsForDefaultValueDto.Rooms);
                var mappedRoomList = mappedPlace.Rooms.ToList();
                mappedRoomList.ForEach(f => f.CreatedDate = datetimeNow);
                mappedRoomList.ForEach(f => f.CreatedUser = userId);
                mappedRoomList.ForEach(f => f.UserId = userId);

                await _placeDal.Add(mappedPlace);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
            return new SuccessResult(Messages.Success);
        }

        public async Task<IResult> DeletePlace(int placeId, int userId)
        {
            try
            {
                var deletePlace = await _placeDal.GetAsync(t => t.Id == placeId && t.UserId == userId);
                if (deletePlace == null)
                    throw new Exception(Messages.DataNotExists);
                await _placeDal.Delete(deletePlace);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
            return new SuccessResult(Messages.Success_Deleted);
        }

        public async Task<Place> GetPlace(int placeId, int userId)
        {
            return await _placeDal.GetAsync(t => t.UserId == userId && t.Id == placeId);
        }

        public async Task<ICollection<Place>> GetPlaceList(int userId)
        {
            return await _placeDal.GetListAsync(r => r.UserId == userId);
        }

        public async Task<IResult> UpdatePlace(PlaceDto place, int userId)
        {
            try
            {
                var getPlace = await _placeDal.GetAsync(g => g.Id == place.Id && g.UserId == userId);
                if (getPlace == null)
                    return new ErrorResult(Messages.DataNotExists);

                var updated = _mapper.Map<Place>(place);
                updated.UpdatedDate = DateTime.Now;
                updated.UpdatedUser = updated.UserId = userId;
                await _placeDal.Update(updated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
            return new SuccessResult(Messages.Success_Updated);
        }
    }
}
