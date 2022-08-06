using PSL.Core.DataAccess.EF;
using PSL.DataAccess.Concrete.EntityFramework.Context;
using PSL.DataAccess.Interfaces.Devices;
using PSL.Entities.Concrete.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.DataAccess.Concrete.EntityFramework.Dal.Devices
{
    public class EFDeviceTypeClassificationDal : EFEntityRepositoryBase<DeviceTypeClassification>, IDeviceTypeClassificationDal
    {
        public EFDeviceTypeClassificationDal(SmartHomeManagementContext dbContext) : base(dbContext)
        {
        }
    }
}
