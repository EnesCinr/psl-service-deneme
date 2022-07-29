using PSL.Core.DataAccess.EF;
using PSL.DataAccess.Concrete.EntityFramework.Context;
using PSL.DataAccess.Interfaces.Rooms;

namespace PSL.DataAccess.Concrete.EntityFramework.Dal.Room
{
    public class EFRoomDal : EFEntityRepositoryBase<Entities.Concrete.Places.Room>, IRoomDal
    {
        public EFRoomDal(SmartHomeManagementContext dbContext) : base(dbContext)
        {
        }
    }
}
