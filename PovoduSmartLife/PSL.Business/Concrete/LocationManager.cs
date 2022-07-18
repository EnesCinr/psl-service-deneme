using Microsoft.EntityFrameworkCore;
using PSL.Business.Constants;
using PSL.Business.Interfaces;
using PSL.Core.DataAccess.EF;
using PSL.Core.Utilities.Results;
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

        public async Task<IResult> AddLocation(LocationDto location, int userId)
        {
            try
            {
                await _locationDal.Add(new Location
                {
                    Name = location.Name,
                    Icon = location.Icon,
                    Latitude = location.Latitude,
                    Longitude = location.Longitude,
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

        public async Task<IResult> DeleteLocation(int locationId)
        {
            try
            {
                await _locationDal.Delete(new Location { Id = locationId });
            }
            catch (Exception ex)
            {
                return new ErrorResult(Messages.Failure_Deleted);
            }
            return new SuccessResult(Messages.Success_Deleted);
        }

        public async Task<Location> GetLocation(Expression<Func<Location, bool>> filter = null)
        {
            return await _locationDal.GetAsync(filter);
        }

        public async Task<ICollection<Location>> GetLocationList(Expression<Func<Location, bool>> filter = null)
        {
            return await _locationDal.GetListAsync(filter);
        }

        public async Task<IResult> UpdateLocation(LocationDto location, int userId)
        {
            try
            {
                await _locationDal.Update(new Location
                {
                    Name = location.Name,
                    Icon = location.Icon,
                    Latitude = location.Latitude,
                    Longitude = location.Longitude,
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
