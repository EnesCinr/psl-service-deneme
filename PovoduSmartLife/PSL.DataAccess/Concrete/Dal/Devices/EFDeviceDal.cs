using PSL.Core.DataAccess.EF;
using PSL.DataAccess.Concrete.EntityFramework.Context;
using PSL.DataAccess.Interfaces.Devices;
using PSL.Entities.Concrete.Devices;

namespace PSL.DataAccess.Concrete.Dal.Devices
{
    public class EFDeviceDal : EFEntityRepositoryBase<Device>, IDeviceDal
    {
        public EFDeviceDal(SmartHomeManagementContext dbContext) : base(dbContext)
        {
        }
    }
}
