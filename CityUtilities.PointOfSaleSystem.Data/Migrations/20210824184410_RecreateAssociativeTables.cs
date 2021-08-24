using Microsoft.EntityFrameworkCore.Migrations;

namespace CityUtilities.PointOfSaleSystem.Data.Migrations
{
    public partial class RecreateAssociativeTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductStoreLocation_StoreLocation_StoreLocationsId",
                table: "ProductStoreLocation");

            migrationBuilder.DropTable(
                name: "ProductSalesOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductStoreLocation",
                table: "ProductStoreLocation");

            migrationBuilder.RenameColumn(
                name: "CurrentAisle",
                table: "StoreLocation",
                newName: "AisleId");

            migrationBuilder.RenameColumn(
                name: "StoreLocationsId",
                table: "ProductStoreLocation",
                newName: "StoreLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductStoreLocation_StoreLocationsId",
                table: "ProductStoreLocation",
                newName: "IX_ProductStoreLocation_StoreLocationId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProductStoreLocation",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ProductStoreLocation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductStoreLocation",
                table: "ProductStoreLocation",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SalesOrderProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SalesOrderId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesOrderProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesOrderProduct_SalesOrder_SalesOrderId",
                        column: x => x.SalesOrderId,
                        principalTable: "SalesOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductStoreLocation_ProductId",
                table: "ProductStoreLocation",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderProduct_ProductId",
                table: "SalesOrderProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderProduct_SalesOrderId",
                table: "SalesOrderProduct",
                column: "SalesOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductStoreLocation_StoreLocation_StoreLocationId",
                table: "ProductStoreLocation",
                column: "StoreLocationId",
                principalTable: "StoreLocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductStoreLocation_StoreLocation_StoreLocationId",
                table: "ProductStoreLocation");

            migrationBuilder.DropTable(
                name: "SalesOrderProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductStoreLocation",
                table: "ProductStoreLocation");

            migrationBuilder.DropIndex(
                name: "IX_ProductStoreLocation_ProductId",
                table: "ProductStoreLocation");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductStoreLocation");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ProductStoreLocation");

            migrationBuilder.RenameColumn(
                name: "AisleId",
                table: "StoreLocation",
                newName: "CurrentAisle");

            migrationBuilder.RenameColumn(
                name: "StoreLocationId",
                table: "ProductStoreLocation",
                newName: "StoreLocationsId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductStoreLocation_StoreLocationId",
                table: "ProductStoreLocation",
                newName: "IX_ProductStoreLocation_StoreLocationsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductStoreLocation",
                table: "ProductStoreLocation",
                columns: new[] { "ProductId", "StoreLocationsId" });

            migrationBuilder.CreateTable(
                name: "ProductSalesOrder",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    SalesOrdersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSalesOrder", x => new { x.ProductsId, x.SalesOrdersId });
                    table.ForeignKey(
                        name: "FK_ProductSalesOrder_Product_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSalesOrder_SalesOrder_SalesOrdersId",
                        column: x => x.SalesOrdersId,
                        principalTable: "SalesOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSalesOrder_SalesOrdersId",
                table: "ProductSalesOrder",
                column: "SalesOrdersId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductStoreLocation_StoreLocation_StoreLocationsId",
                table: "ProductStoreLocation",
                column: "StoreLocationsId",
                principalTable: "StoreLocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
