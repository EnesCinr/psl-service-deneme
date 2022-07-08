using PSL.Core.DataAccess.EF;
using PSL.DataAccess.Concrete.EntityFramework.Context;
using PSL.DataAccess.Interfaces.Users;
using PSL.Entities.Concrete.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.DataAccess.Concrete.EntityFramework.Dal.Users
{
    public class EFUserDeviceDal : EFEntityRepositoryBase<UserDevice>, IUserDeviceDal
    {
        public EFUserDeviceDal(SmartHomeManagementContext dbContext) : base(dbContext)
        {
        }
    }
}
