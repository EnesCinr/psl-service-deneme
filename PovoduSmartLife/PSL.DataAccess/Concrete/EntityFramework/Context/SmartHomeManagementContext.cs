using Microsoft.EntityFrameworkCore;
using PSL.Core.DbContexts;
using PSL.DataAccess.Concrete.EntityFramework.Mapping.Devices;
using PSL.DataAccess.Concrete.EntityFramework.Mapping.Users;
using PSL.Entities.Concrete.Devices;
using PSL.Entities.Concrete.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.DataAccess.Concrete.EntityFramework.Context
{
    public partial class SmartHomeManagementContext : DbContext, IDbContext
    {
        public SmartHomeManagementContext(DbContextOptions<SmartHomeManagementContext> options)
            : base(options)
        { }

        #region DbSets
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<DeviceType> DeviceTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserLocation> UserLocations { get; set; }
        public virtual DbSet<UserRoom> UserRooms { get; set; }
        public virtual DbSet<UserDevice> UserDevices { get; set; }
        public virtual DbSet<UserRelation> UserRelations { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DeviceMapping());
            modelBuilder.ApplyConfiguration(new DeviceTypeMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new UserLocationMapping());
            modelBuilder.ApplyConfiguration(new UserRoomMapping());
            modelBuilder.ApplyConfiguration(new UserDeviceMapping());
            modelBuilder.ApplyConfiguration(new UserRelationMapping());
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
