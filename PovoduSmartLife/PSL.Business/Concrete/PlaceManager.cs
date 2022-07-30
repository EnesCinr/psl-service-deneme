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
        public PlaceManager(IPlaceDal placeDal)
        {
            _placeDal = placeDal;
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
                return new ErrorResult(Messages.Failure_Added);
            }

            return new SuccessResult(Messages.Success_Added);
        }

        public async Task<IResult> DeletePlace(int placeId)
        {
            try
            {
                await _placeDal.Delete(new Place { Id = placeId });
            }
            catch (Exception ex)
            {
                return new ErrorResult(Messages.Failure_Deleted);
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
                Place updated = await _placeDal.GetByIdAsync(place.Id);
                if (updated.Name != place.Name) updated.Name = place.Name;
                if (updated.Icon != place.Icon) updated.Icon = place.Icon;
                if (updated.Latitude != place.Latitude) updated.Latitude = place.Latitude;
                if (updated.Longitude != place.Longitude) updated.Longitude = place.Longitude;
                updated.UpdatedDate = DateTime.Now;
                updated.UpdatedUser = userId;
                await _placeDal.Update(updated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(Messages.Failure_Updated);
            }
            return new SuccessResult(Messages.Success_Updated);
        }
    }
}
