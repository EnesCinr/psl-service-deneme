using PSL.Core.Utilities.Results;
using PSL.Entities.Concrete.Locations;
using PSL.Entities.Dtos.Location;
using System.Linq.Expressions;

namespace PSL.Business.Interfaces
{
    public interface ILocationService
    {
        Task<IResult> AddLocation(LocationDto location, int userId);
        Task<Location> GetLocation(Expression<Func<Location, bool>> filter);
        Task<ICollection<Location>> GetLocationList(Expression<Func<Location, bool>> filter);
        Task<IResult> UpdateLocation(LocationDto location, int userId);
        Task<IResult> DeleteLocation(int locationId);
    }
}
