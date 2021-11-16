using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SupMark.Core.Entities;
using SupMark.Core.Entities.Common;
using SupMark.Core.Entities.Partials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupMark.Infrastructure.DataAccess
{
    public class SupMarkDbContext : DbContext
    {
        public SupMarkDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<List> Lists { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region ProductTypes
            modelBuilder.Entity<ProductType>().HasKey(x => x.Label);
            #endregion

            #region Product
            modelBuilder.Entity<Product>().HasIndex(u => u.Name).IsUnique();
            #endregion

            #region Users
            modelBuilder.Entity<User>().Ignore(x => x.SupMarkUser).HasKey(x => x.SupMarkUserId);
            #endregion
        }
    }
}
