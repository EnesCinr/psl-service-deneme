using PSL.Core.DataAccess.EF;
using PSL.DataAccess.Concrete.EntityFramework.Context;
using PSL.DataAccess.Interfaces.Devices;
using PSL.Entities.Concrete.Devices;

namespace PSL.DataAccess.Concrete.Dal.Devices
{
    public class EFDeviceTypeDal : EFEntityRepositoryBase<DeviceType>, IDeviceTypeDal
    {
        public EFDeviceTypeDal(SmartHomeManagementContext dbContext) : base(dbContext)
        {
        }
    }
}
