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

        public bool AddLocation(LocationDto location)
        {
            _locationDal.Add(new Location
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

            return true;
        }
    }
}
