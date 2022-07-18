using PSL.Core.Models.Interface;
using PSL.Core.Rest;
using PSL.MasterService.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.MasterService.Business.Concrete
{
    public class MasterServiceManager : IMasterServiceService
    {
        private readonly IMasterServiceAccessSettings _masterServiceAccessSettings;

        public MasterServiceManager(IMasterServiceAccessSettings masterServiceAccessSettings)
        {
            _masterServiceAccessSettings = masterServiceAccessSettings;
        }

        public async Task<string> GetDevice(string macAddress)
        {
            var url = $"{_masterServiceAccessSettings.Url}/device?macAddress={macAddress}";
            var response = await RestApiHelper.Get(url);

            return response;
        }
    }
}
