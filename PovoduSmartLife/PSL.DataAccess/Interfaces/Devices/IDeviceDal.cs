using PSL.Core.DataAccess;
using PSL.DataAccess;
using PSL.Entities.Concrete.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.DataAccess.Interfaces.Devices
{
    public interface IDeviceDal: IEntityRepository<Device>
    {
    }
}
