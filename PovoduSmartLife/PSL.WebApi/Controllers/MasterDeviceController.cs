using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSL.Business.Interfaces;
using PSL.MasterService.Business.Interface;

namespace PSL.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/master")]
    [ApiController]
    public class MasterDeviceController : BaseController
    {
        private readonly IMasterServiceService _masterServiceService;
        public MasterDeviceController(IMasterServiceService masterServiceService,
            IAuthService authService) : base(authService)
        {
            TempHelper.Initialize();
            _masterServiceService = masterServiceService;
        }

        [HttpGet("device")]
        public async Task<IActionResult> GetDeviceByMacAddressAsync(string macAddress)
        {
            var response = await _masterServiceService.GetDevice(macAddress);

            return Ok(response);
            //using (HttpResponseMessage response = await TempHelper.ApiClient.GetAsync("/device?macAddress=" + macAddress))
            //{
            //    if (response.IsSuccessStatusCode)
            //    {
            //        string generatedDevice = await response.Content.ReadAsStringAsync();
            //        return Ok(generatedDevice);
            //    }
            //    else
            //    {
            //        return BadRequest("çalışmadı");
            //    }
            //}
        }
    }
}
