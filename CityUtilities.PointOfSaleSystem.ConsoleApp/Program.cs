using CityUtilities.PointOfSaleSystem.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace CityUtilities.PointOfSaleSystem.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class ConsolePointOfSaleContext : PointOfSaleContext
    {
        public ConsolePointOfSaleContext(DbContextOptions<PointOfSaleContext> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=PointOfSale;Trusted_Connection=True;");
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
