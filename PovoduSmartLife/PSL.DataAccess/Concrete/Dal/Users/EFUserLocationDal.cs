using Microsoft.EntityFrameworkCore;
using PSL.Core.DataAccess.EF;
using PSL.DataAccess.Concrete.EntityFramework.Context;
using PSL.DataAccess.Interfaces.Users;
using PSL.Entities.Concrete.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.DataAccess.Concrete.Dal.Users
{
    public class EFUserLocationDal : EFEntityRepositoryBase<UserLocation>, IUserLocationDal
    {
        public EFUserLocationDal(SmartHomeManagementContext dbContext) : base(dbContext)
        {
        }
    }
}
