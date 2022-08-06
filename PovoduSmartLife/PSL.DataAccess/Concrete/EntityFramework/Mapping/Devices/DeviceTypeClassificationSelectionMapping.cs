using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSL.Entities.Concrete.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.DataAccess.Concrete.EntityFramework.Mapping.Devices
{
    public class DeviceTypeClassificationSelectionMapping : IEntityTypeConfiguration<DeviceTypeClassificationSelection>
    {
        public void Configure(EntityTypeBuilder<DeviceTypeClassificationSelection> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).UseIdentityColumn();
        }
    }
}
