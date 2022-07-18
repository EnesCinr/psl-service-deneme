using PSL.Entities.Dtos.ExternalService.MasterService;

namespace PSL.MasterService.Business.Interface
{
    public interface IMasterServiceService
    {
        Task<MasterDeviceDto> GetDevice(string deviceId,string macAddress);
    }
}
