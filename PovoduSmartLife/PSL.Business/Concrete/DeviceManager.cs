using AutoMapper;
using PSL.Business.Constants;
using PSL.Business.Interfaces;
using PSL.Core.Utilities.Results;
using PSL.DataAccess.Interfaces.Devices;
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
        private readonly IMapper _mapper;
        private readonly IDeviceDal _deviceDal;

        public DeviceManager(IMapper mapper, IDeviceDal deviceDal)
        {
            _mapper = mapper;
            _deviceDal = deviceDal;
        }

        public async Task<IResult> AddDeviceAsync(DeviceDto device, int userId)
        {
            try
            {
                var mappedDevice = _mapper.Map<Device>(device);
                mappedDevice.CreatedDate = DateTime.Now;
                mappedDevice.CreatedUser = userId;
                await _deviceDal.Add(mappedDevice);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }

            return new SuccessResult(Messages.Success_Added);
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
