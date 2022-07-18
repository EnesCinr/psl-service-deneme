using Newtonsoft.Json;
using PSL.Core.Models.Interface;
using PSL.Core.Rest;
using PSL.Entities.Dtos.ExternalService.MasterService;
using PSL.MasterService.Business.Interface;

namespace PSL.MasterService.Business.Concrete
{
    public class MasterServiceManager : IMasterServiceService
    {
        private readonly IMasterServiceAccessSettings _masterServiceAccessSettings;

        public MasterServiceManager(IMasterServiceAccessSettings masterServiceAccessSettings)
        {
            _masterServiceAccessSettings = masterServiceAccessSettings;
        }

        public async Task<MasterDeviceDto> GetDevice(string deviceId, string macAddress)
        {
            var url = $"{_masterServiceAccessSettings.Url}/device?deviceId={deviceId}&macAddress={macAddress}";
            var response = await RestApiHelper.Get(url);

            return JsonConvert.DeserializeObject<MasterDeviceDto>(response);
        }
    }
}
