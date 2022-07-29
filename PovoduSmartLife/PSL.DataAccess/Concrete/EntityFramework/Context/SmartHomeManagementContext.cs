using Microsoft.EntityFrameworkCore;
using PSL.Core.DbContexts;
using PSL.DataAccess.Concrete.EntityFramework.Mapping.Devices;
using PSL.DataAccess.Concrete.EntityFramework.Mapping.Locations;
using PSL.DataAccess.Concrete.EntityFramework.Mapping.Users;
using PSL.Entities.Concrete.Devices;
using PSL.Entities.Concrete.Places;
using PSL.Entities.Concrete.Users;

namespace PSL.DataAccess.Concrete.EntityFramework.Context
{
    public partial class SmartHomeManagementContext : DbContext, IDbContext
    {
        public SmartHomeManagementContext(DbContextOptions<SmartHomeManagementContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        #region DbSets
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserLocation> UserLocations { get; set; }
        public virtual DbSet<UserRoom> UserRooms { get; set; }
        public virtual DbSet<UserDevice> UserDevices { get; set; }
        public virtual DbSet<UserRelation> UserRelations { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DeviceMapping());
            modelBuilder.ApplyConfiguration(new PlaceMapping());
            modelBuilder.ApplyConfiguration(new RoomMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new UserLocationMapping());
            modelBuilder.ApplyConfiguration(new UserRoomMapping());
            modelBuilder.ApplyConfiguration(new UserDeviceMapping());
            modelBuilder.ApplyConfiguration(new UserRelationMapping());
        }
    }
}
