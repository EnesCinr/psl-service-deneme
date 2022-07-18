using Microsoft.AspNetCore.Mvc;
using PSL.Business.Interfaces;
using PSL.Entities.Concrete.Devices;
using PSL.Entities.Dtos.Device;
using PSL.Entities.Dtos.ExternalService.MasterService;
using PSL.MasterService.Business.Interface;

namespace PSL.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/device")]
    [ApiController]
    public class DeviceController : BaseController
    {
        private readonly IMasterServiceService _masterServiceService;
        private readonly IDeviceService _deviceService;

        public DeviceController(
            IMasterServiceService masterServiceService,
            IDeviceService deviceService,
            IAuthService authService)
            : base(authService)
        {
            TempHelper.Initialize();
            _masterServiceService = masterServiceService;
            _deviceService = deviceService;
        }

        [HttpGet("check")]
        public async Task<IActionResult> CheckThenCreateDevice(string deviceId, string macAddress)
        {
            MasterDeviceDto masterDevice = await _masterServiceService.GetDevice(deviceId, macAddress);
            if (masterDevice == null)
                return NotFound();
            else
            {
                await _deviceService.AddDeviceAsync(new DeviceDto
                {
                    DeviceId = deviceId,
                    MacAddress = macAddress,
                    HomeKitPairNumber = masterDevice.HomeKitPairNumber,
                    IsHomeKitDevice = !string.IsNullOrEmpty(masterDevice.HomeKitPairNumber),
                    HomeKitSetupID = masterDevice.HomeKitSetupID,
                    SerialNumber = masterDevice.SerialNumber,
                });
                return Ok(true);
            }
        }

        [HttpGet("isAdded")]
        public async Task<IActionResult> IsAddedDevice(string macAddress)
        {
            Device device = null;

            int counter = 0;
            while (device == null || counter > 10)
            {
                device = await _deviceService.GetDeviceAsync(x => x.MacAddress == macAddress);
                Thread.Sleep(1000);
            }

            if (counter > 10 && device == null)
                return NotFound();
            else
                return Ok(device.Id);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDevice(DeviceDto deviceDto)
        {
            await _deviceService.UpdateDeviceAsync(deviceDto);
            return Ok();
        }
    }
}
