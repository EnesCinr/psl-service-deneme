using PSL.Core.DataAccess;
using PSL.Entities.Concrete.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.DataAccess.Interfaces.Locations
{
    public interface ILocationDal : IEntityRepository<Location>
    {
    }
}
