using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Core.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure.Data.Config
{
    public class DeliveryMethodConfiguration : IEntityTypeConfiguration<DeliveryMethod>
    {
        public void Configure(EntityTypeBuilder<DeliveryMethod> builder)
        {
            builder.Property(x => x.Price).HasColumnType("decimal(18,2)");
            builder.HasData(
                new DeliveryMethod { Id = 1, ShortName = "DHL", DeliveryTime = "", Description = "最快的送貨方式", Price = 50 },
                new DeliveryMethod { Id = 2, ShortName = "Aramex", DeliveryTime = "", Description = "3天內送達", Price = 30 },
                new DeliveryMethod { Id = 3, ShortName = "Fedex", DeliveryTime = "", Description = "速度較慢但便宜", Price = 20 },
                new DeliveryMethod { Id = 4, ShortName = "Jumia", DeliveryTime = "", Description = "免費送貨", Price = 0 }
                );
        }
    }
}
