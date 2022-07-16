using PSL.Entities.Dtos.Location;

namespace PSL.Business.Interfaces
{
    public interface ILocationService
    {
        public bool AddLocation(LocationDto location);
    }
}
