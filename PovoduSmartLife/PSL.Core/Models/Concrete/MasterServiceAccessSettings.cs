using PSL.Core.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Core.Models.Concrete
{
    public class MasterServiceAccessSettings : IMasterServiceAccessSettings
    {
        public string Url { get; set; }
    }
}
