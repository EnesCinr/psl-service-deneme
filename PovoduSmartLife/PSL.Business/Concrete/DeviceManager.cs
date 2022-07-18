using PSL.Business.Interfaces;
using PSL.Entities.Concrete.Devices;
using PSL.Entities.Dtos.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Business.Concrete
{
    public class DeviceManager : IDeviceService
    {
        public Task AddDeviceAsync(DeviceDto device)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDeviceAsync(int deviceId)
        {
            throw new NotImplementedException();
        }

        public Task<Device> GetDeviceAsync(Expression<Func<Device, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Device>> GetDeviceListAsync(Expression<Func<Device, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDeviceAsync(DeviceDto device)
        {
            throw new NotImplementedException();
        }
    }
}
