using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PSL.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/master")]
    [ApiController]
    public class MasterDeviceController : ControllerBase
    {
        public MasterDeviceController()
        {
            TempHelper.Initialize();
        }

        [HttpGet("device")]
        public async Task<IActionResult> GetDeviceByMacAddressAsync(string macAddress)
        {
            using (HttpResponseMessage response = await TempHelper.ApiClient.GetAsync("/device?macAddress=" + macAddress))
            {
                if (response.IsSuccessStatusCode)
                {
                    string generatedDevice = await response.Content.ReadAsStringAsync();
                    return Ok(generatedDevice);
                }
                else
                {
                    return BadRequest("çalışmadı");
                }
            }
        }
    }
}
