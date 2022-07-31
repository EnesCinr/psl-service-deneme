using PSL.Core.Utilities.Results;
using PSL.Entities.Concrete.Places;
using PSL.Entities.Dtos.Place;
using System.Linq.Expressions;

namespace PSL.Business.Interfaces
{
    public interface IPlaceService
    {
        Task<IResult> AddPlace(PlaceDto location, int userId);
        Task<Place> GetPlace(Expression<Func<Place, bool>> filter);
        Task<ICollection<Place>> GetPlaceList(Expression<Func<Place, bool>> filter);
        Task<IResult> UpdatePlace(PlaceDto location, int userId);
        Task<IResult> DeletePlace(int locationId);
        Task<IResult> AddPlaceWithRoomsForDefaultValue(PlaceWithRoomsForDefaultValueDto placeWithRoomsForDefaultValueDto, int userId);
    }
}
