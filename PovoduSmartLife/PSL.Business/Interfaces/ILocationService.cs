using PSL.Entities.Concrete.Locations;
using PSL.Entities.Dtos.Location;
using System.Linq.Expressions;

namespace PSL.Business.Interfaces
{
    public interface ILocationService
    {
        public Task AddLocationAsync(LocationDto location);
        public Task<Location> GetLocationAsync(Expression<Func<Location, bool>> filter);
        public Task<ICollection<Location>> GetLocationListAsync(Expression<Func<Location, bool>> filter);
        public Task UpdateLocationAsync(LocationDto location);
        public Task DeleteLocationAsync(int locationId);
    }
}
