using PSL.Core.DataAccess.EF;
using PSL.DataAccess.Concrete.EntityFramework.Context;
using PSL.DataAccess.Interfaces.Places;
using PSL.Entities.Concrete.Places;

namespace PSL.DataAccess.Concrete.EntityFramework.Dal.Place
{
    public class EFPlaceDal : EFEntityRepositoryBase<Entities.Concrete.Places.Place>, IPlaceDal
    {
        public EFPlaceDal(SmartHomeManagementContext dbContext) : base(dbContext)
        {
        }
    }
}
