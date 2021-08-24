using Microsoft.EntityFrameworkCore.Migrations;

namespace CityUtilities.PointOfSaleSystem.Data.Migrations
{
    public partial class TestingSeededEnumWithNewProductLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductStoreLocation");

            migrationBuilder.DropTable(
                name: "StoreLocation");

            migrationBuilder.CreateTable(
                name: "Aisle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aisle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductLocation",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    AisleId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLocation", x => new { x.ProductId, x.AisleId });
                    table.ForeignKey(
                        name: "FK_ProductLocation_Aisle_AisleId",
                        column: x => x.AisleId,
                        principalTable: "Aisle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductLocation_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Aisle",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "A" },
                    { 2, "B" },
                    { 3, "C" },
                    { 4, "D" },
                    { 5, "E" },
                    { 6, "F" },
                    { 7, "G" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductLocation_AisleId",
                table: "ProductLocation",
                column: "AisleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductLocation");

            migrationBuilder.DropTable(
                name: "Aisle");

            migrationBuilder.CreateTable(
                name: "StoreLocation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AisleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreLocation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductStoreLocation",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    StoreLocationId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStoreLocation", x => new { x.ProductId, x.StoreLocationId });
                    table.ForeignKey(
                        name: "FK_ProductStoreLocation_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductStoreLocation_StoreLocation_StoreLocationId",
                        column: x => x.StoreLocationId,
                        principalTable: "StoreLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductStoreLocation_StoreLocationId",
                table: "ProductStoreLocation",
                column: "StoreLocationId");
        }
    }
}
