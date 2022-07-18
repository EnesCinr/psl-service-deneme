﻿using PSL.Entities.Concrete.Devices;
using PSL.Entities.Dtos.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Business.Interfaces
{
    internal interface IDeviceService
    {
        public Task AddDeviceAsync(DeviceDto device);
        public Task<Device> GetDeviceAsync(Expression<Func<Device, bool>> filter);
        public Task<ICollection<Device>> GetDeviceListAsync(Expression<Func<Device, bool>> filter);
        public Task UpdateDeviceAsync(DeviceDto device);
        public Task DeleteDeviceAsync(int deviceId);
    }
}
