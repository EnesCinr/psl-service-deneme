using PSL.Core.DataAccess.EF;
using PSL.DataAccess.Concrete.EntityFramework.Context;
using PSL.DataAccess.Interfaces.Users;
using PSL.Entities.Concrete.Users;

namespace PSL.DataAccess.Concrete.EntityFramework.Dal.Users
{
    public class EFUserDal : EFEntityRepositoryBase<User>, IUserDal
    {
        public EFUserDal(SmartHomeManagementContext dbContext) : base(dbContext)
        {
        }
    }
}
