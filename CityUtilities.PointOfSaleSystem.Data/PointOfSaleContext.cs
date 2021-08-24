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
        public DbSet<ProductLocation> ProductLocation { get; set; }
        public DbSet<SalesOrder> SalesOrder { get; set; }
        public DbSet<SalesOrderProduct> SalesOrderProduct { get; set; }
        public DbSet<Aisle> Aisle { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductLocation>().HasKey(e => new 
            { 
                e.ProductId, 
                e.AisleId
            });
            modelBuilder.Entity<SalesOrderProduct>().HasKey(e => new 
            { 
                e.SalesOrderId, 
                e.ProductId 
            });

            modelBuilder.Entity<Aisle>()
                .Property(a => a.Id)
                .ValueGeneratedNever();

            modelBuilder.Entity<Aisle>()
                .HasData(Enum.GetValues(typeof(AisleEnum))
                .OfType<AisleEnum>()
                .Select(x => new Aisle
                {
                    Id = x,
                    Title = x.ToString()
                }));
        }
    }

    // This needs to be defined to allow migrations to occur against the .Data project.
    // Alternative design-time migration options can be found here:
    // https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli
    // -TF
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
