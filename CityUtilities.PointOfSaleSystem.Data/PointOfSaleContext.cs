using CityUtilities.PointOfSaleSystem.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityUtilities.PointOfSaleSystem.Data
{
    public class PointOfSaleContext : DbContext
    {
        public PointOfSaleContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<SalesOrder> SalesOrder { get; set; }
        public DbSet<StoreLocation> StoreLocation {  get; set; }
        public DbSet<SalesOrderProduct> SalesOrderProduct { get; set; }
        public DbSet<ProductStoreLocation> ProductStoreLocation { get; set; }
    }

    public class PointOfSaleContextFactory : IDesignTimeDbContextFactory<PointOfSaleContext>
    {
        public PointOfSaleContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PointOfSaleContext>()
                .UseSqlServer(@"Server=localhost;Database=PointOfSale;Trusted_Connection=True;")
                .EnableSensitiveDataLogging();

            return new PointOfSaleContext(optionsBuilder.Options);
        }
    }
}
