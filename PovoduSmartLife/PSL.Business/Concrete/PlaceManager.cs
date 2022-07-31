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
        private readonly IMapper _mapper;
        public PlaceManager(IPlaceDal placeDal, IMapper mapper)
        {
            _placeDal = placeDal;
            _mapper = mapper;
        }

        public async Task<IResult> AddPlace(PlaceDto place, int userId)
        {
            try
            {
                await _placeDal.Add(new Place
                {
                    Name = place.Name,
                    Icon = place.Icon,
                    Latitude = place.Latitude,
                    Longitude = place.Longitude,
                    CreatedUser = userId,
                    CreatedDate = DateTime.Now,
                    UpdatedUser = userId,
                    UpdatedDate = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }

            return new SuccessResult(Messages.Success_Added);
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
