using Microsoft.AspNetCore.Mvc;
using PSL.Business.Interfaces;
using PSL.Entities.Concrete.Devices;
using PSL.Entities.Dtos.Device;

namespace PSL.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/device")]
    [ApiController]
    public class DeviceController : BaseController
    {

        private readonly IDeviceService _deviceService;

        public DeviceController(
            IDeviceService deviceService,
            IAuthService authService)
            : base(authService)
        {
            _deviceService = deviceService;

        }

        [HttpPost("create-device")]
        public async Task<IActionResult> CheckThenCreateDevice(CheckThenCreateDeviceDto checkThenCreateDeviceDto)
        {
            var loggedUser = await base.GetLoggedUserInformation();
            var result = await _deviceService.CreateDeviceAsync(checkThenCreateDeviceDto, loggedUser.Id);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [HttpGet("is-added")]
        public async Task<IActionResult> IsAddedDevice(string macAddress)
        {
            //TODO böyle kod olmaz. Düzelt burayı!!!!
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
