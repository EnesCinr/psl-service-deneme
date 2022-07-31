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
                mappedPlace.CreatedUser = userId;
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
                mappedPlace.CreatedUser = userId;

                mappedPlace.Rooms = _mapper.Map<List<Room>>(placeWithRoomsForDefaultValueDto.Rooms);
                var mappedPlaceList = mappedPlace.Rooms.ToList();
                mappedPlaceList.ForEach(f => f.CreatedDate = datetimeNow);
                mappedPlaceList.ForEach(f => f.CreatedUser = userId);

                await _placeDal.Add(mappedPlace);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
            return new SuccessResult(Messages.Success);
        }

        public async Task<IResult> DeletePlace(int placeId)
        {
            try
            {
                var deletePlace = await _placeDal.GetByIdAsync(placeId);
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

        public async Task<Place> GetPlace(Expression<Func<Place, bool>> filter = null)
        {
            return await _placeDal.GetAsync(filter);
        }

        public async Task<ICollection<Place>> GetPlaceList(Expression<Func<Place, bool>> filter = null)
        {
            return await _placeDal.GetListAsync(filter);
        }

        public async Task<IResult> UpdatePlace(PlaceDto place, int userId)
        {
            try
            {
                var updated = _mapper.Map<Place>(place);
                updated.UpdatedDate = DateTime.Now;
                updated.UpdatedUser = userId;
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
