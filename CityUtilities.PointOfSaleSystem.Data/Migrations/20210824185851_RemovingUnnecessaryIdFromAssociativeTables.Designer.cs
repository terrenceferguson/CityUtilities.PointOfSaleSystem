// <auto-generated />
using System;
using CityUtilities.PointOfSaleSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CityUtilities.PointOfSaleSystem.Data.Migrations
{
    [DbContext(typeof(PointOfSaleContext))]
    [Migration("20210824185851_RemovingUnnecessaryIdFromAssociativeTables")]
    partial class RemovingUnnecessaryIdFromAssociativeTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CityUtilities.PointOfSaleSystem.Core.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("StockNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("CityUtilities.PointOfSaleSystem.Core.ProductStoreLocation", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("StoreLocationId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "StoreLocationId");

                    b.HasIndex("StoreLocationId");

                    b.ToTable("ProductStoreLocation");
                });

            modelBuilder.Entity("CityUtilities.PointOfSaleSystem.Core.SalesOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("SaleDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("SalesOrder");
                });

            modelBuilder.Entity("CityUtilities.PointOfSaleSystem.Core.SalesOrderProduct", b =>
                {
                    b.Property<int>("SalesOrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("SalesOrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("SalesOrderProduct");
                });

            modelBuilder.Entity("CityUtilities.PointOfSaleSystem.Core.StoreLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AisleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("StoreLocation");
                });

            modelBuilder.Entity("CityUtilities.PointOfSaleSystem.Core.ProductStoreLocation", b =>
                {
                    b.HasOne("CityUtilities.PointOfSaleSystem.Core.Product", "Product")
                        .WithMany("StoreLocations")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CityUtilities.PointOfSaleSystem.Core.StoreLocation", "StoreLocation")
                        .WithMany("Products")
                        .HasForeignKey("StoreLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("StoreLocation");
                });

            modelBuilder.Entity("CityUtilities.PointOfSaleSystem.Core.SalesOrderProduct", b =>
                {
                    b.HasOne("CityUtilities.PointOfSaleSystem.Core.Product", "Product")
                        .WithMany("SalesOrders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CityUtilities.PointOfSaleSystem.Core.SalesOrder", "SalesOrder")
                        .WithMany("Products")
                        .HasForeignKey("SalesOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("SalesOrder");
                });

            modelBuilder.Entity("CityUtilities.PointOfSaleSystem.Core.Product", b =>
                {
                    b.Navigation("SalesOrders");

                    b.Navigation("StoreLocations");
                });

            modelBuilder.Entity("CityUtilities.PointOfSaleSystem.Core.SalesOrder", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("CityUtilities.PointOfSaleSystem.Core.StoreLocation", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
