using PSL.Core.DataAccess;
using PSL.DataAccess;
using PSL.Entities.Concrete.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.DataAccess.Interfaces.Users
{
    public interface IUserRoomDal : IEntityRepository<UserRoom>
    {
    }
}
