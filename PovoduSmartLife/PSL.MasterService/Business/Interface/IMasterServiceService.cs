using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.MasterService.Business.Interface
{
    public interface IMasterServiceService
    {
        Task<string> GetDevice(string macAddress);
    }
}
