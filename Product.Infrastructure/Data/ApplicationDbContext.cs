using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Product.Core.Entities;
using Product.Core.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUsers>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        { 
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public DbSet<Address> Address { get; set; }
        public virtual DbSet<Order> Orders { set; get; }
        public virtual DbSet<OrderItems> OrderItems { set; get; }
        public virtual DbSet<DeliveryMethod> DeliveryMethods { set; get; }

        /// <summary>
        /// 配置模型的建構。
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            base.OnModelCreating(modelBuilder);
            // 應用當前組件中的所有模型配置
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
