using PSL.Core.Utilities.Results;
using PSL.Entities.Concrete.Places;
using PSL.Entities.Dtos.Place;
using System.Linq.Expressions;

namespace PSL.Business.Interfaces
{
    public interface IPlaceService
    {
        Task<IResult> AddPlace(PlaceDto place, int userId);
        Task<Place> GetPlace(int placeId, int userId);
        Task<ICollection<Place>> GetPlaceList(int userId);
        Task<IResult> UpdatePlace(PlaceDto place, int userId);
        Task<IResult> DeletePlace(int placeId, int userId);
        Task<IResult> AddPlaceWithRoomsForDefaultValue(PlaceWithRoomsForDefaultValueDto placeWithRoomsForDefaultValueDto, int userId);
    }
}
