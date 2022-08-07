using AutoMapper;
using PSL.Business.Constants;
using PSL.Business.Interfaces;
using PSL.Core.Utilities.Results;
using PSL.DataAccess.Interfaces.Devices;
using PSL.Entities.Concrete.Devices;
using PSL.Entities.Dtos.Device;
using PSL.Entities.Dtos.ExternalService.MasterService;
using PSL.MasterService.Business.Interface;
using System.Linq.Expressions;

namespace PSL.Business.Concrete
{
    public class DeviceManager : IDeviceService
    {
        private readonly IMapper _mapper;
        private readonly IDeviceDal _deviceDal;
        private readonly IMasterServiceService _masterServiceService;
        private readonly IDeviceTypeDal _deviceTypeDal;

        public DeviceManager(IMapper mapper, IDeviceDal deviceDal, IMasterServiceService masterServiceService, IDeviceTypeDal deviceTypeDal)
        {
            _mapper = mapper;
            _deviceDal = deviceDal;
            _masterServiceService = masterServiceService;
            _deviceTypeDal = deviceTypeDal;
        }

        public async Task<IResult> AddDeviceAsync(DeviceDto device, int userId)
        {
            try
            {
                var mappedDevice = _mapper.Map<Device>(device);
                mappedDevice.CreatedDate = DateTime.Now;
                mappedDevice.CreatedUser = mappedDevice.UserId = userId;
                await _deviceDal.Add(mappedDevice);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }

            return new SuccessResult(Messages.Success_Added);
        }

        public async Task<IResult> CreateDeviceAsync(CheckThenCreateDeviceDto checkThenCreateDeviceDto, int userId)
        {
            try
            {
                MasterDeviceDto masterDevice = await _masterServiceService.GetDevice(checkThenCreateDeviceDto.deviceId, checkThenCreateDeviceDto.macAddress);
                if (masterDevice == null)
                    return new ErrorResult(Messages.DeviceNotExists);
                else
                {
                    var deviceType = _deviceTypeDal.Queryable().SingleOrDefault(r => r.DeviceTypeCode == checkThenCreateDeviceDto.deviceTypeCode);
                    var deviceTypeId = 0;
                    if (deviceType != null)
                        deviceTypeId = deviceType.Id;
                    else
                        return new ErrorResult(Messages.DeviceTypeCodeNotMatch);

                    var deviceDto = new DeviceDto
                    {
                        DeviceId = checkThenCreateDeviceDto.deviceId,
                        MacAddress = checkThenCreateDeviceDto.macAddress,
                        HomeKitPairNumber = masterDevice.HomeKitPairNumber,
                        IsHomeKitDevice = !string.IsNullOrEmpty(masterDevice.HomeKitPairNumber),
                        HomeKitSetupId = masterDevice.HomeKitSetupID,
                        SerialNumber = masterDevice.SerialNumber,
                        DeviceTypeId = deviceTypeId,
                        RoomId = null,

                    };

                    var result = await AddDeviceAsync(deviceDto, userId);

                    if (result.Success)
                        return new SuccessResult(result.Message);
                    else
                        return new ErrorResult(Messages.Failure_Added);
                }
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
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
