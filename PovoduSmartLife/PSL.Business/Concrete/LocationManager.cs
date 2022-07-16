using Microsoft.EntityFrameworkCore;
using PSL.Business.Interfaces;
using PSL.Core.DataAccess.EF;
using PSL.DataAccess.Concrete.EntityFramework.Context;
using PSL.DataAccess.Concrete.EntityFramework.Dal.Location;
using PSL.DataAccess.Interfaces.Locations;
using PSL.Entities.Concrete.Locations;
using PSL.Entities.Dtos.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Business.Concrete
{
    public class LocationManager : ILocationService
    {
        private readonly ILocationDal _locationDal;
        public LocationManager(ILocationDal locationDal)
        {
            _locationDal = locationDal;
        }

        public Task AddLocationAsync(LocationDto location)
        {
           return _locationDal.Add(new Location
            {
                Name = location.Name,
                Icon = location.Icon,
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                CreatedUser = 4,
                CreatedDate = DateTime.Now,
                UpdatedUser = 4,
                UpdatedDate = DateTime.Now
            });
        }

        public Task DeleteLocationAsync(int locationId)
        {
            return _locationDal.Delete(new Location { Id = locationId });
        }

        public Task<Location> GetLocationAsync(Expression<Func<Location, bool>> filter = null)
        {
            return _locationDal.GetAsync(filter);
        }

        public Task<ICollection<Location>> GetLocationListAsync(Expression<Func<Location, bool>> filter = null)
        {
            return _locationDal.GetListAsync(filter);
        }

        public Task UpdateLocationAsync(LocationDto location)
        {
            return _locationDal.Update(new Location
            {
                Name = location.Name,
                Icon = location.Icon,
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                CreatedUser = 4,
                CreatedDate = DateTime.Now,
                UpdatedUser = 4,
                UpdatedDate = DateTime.Now
            });
        }
    }
}
