using PSL.Core.DataAccess.EF;
using PSL.DataAccess.Concrete.EntityFramework.Context;
using PSL.DataAccess.Interfaces.Locations;
using PSL.Entities.Concrete.Locations;

namespace PSL.DataAccess.Concrete.EntityFramework.Dal.Location
{
    public class EFLocationDal : EFEntityRepositoryBase<Entities.Concrete.Locations.Location>, ILocationDal
    {
        public EFLocationDal(SmartHomeManagementContext dbContext) : base(dbContext)
        {
        }
    }
}
