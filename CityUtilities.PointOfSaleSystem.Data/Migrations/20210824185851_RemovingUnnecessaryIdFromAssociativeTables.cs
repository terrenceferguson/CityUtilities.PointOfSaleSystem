using Microsoft.EntityFrameworkCore.Migrations;

namespace CityUtilities.PointOfSaleSystem.Data.Migrations
{
    public partial class RemovingUnnecessaryIdFromAssociativeTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderProduct_SalesOrder_SalesOrderId",
                table: "SalesOrderProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesOrderProduct",
                table: "SalesOrderProduct");

            migrationBuilder.DropIndex(
                name: "IX_SalesOrderProduct_SalesOrderId",
                table: "SalesOrderProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductStoreLocation",
                table: "ProductStoreLocation");

            migrationBuilder.DropIndex(
                name: "IX_ProductStoreLocation_ProductId",
                table: "ProductStoreLocation");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SalesOrderProduct");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "SalesOrderProduct");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductStoreLocation");

            migrationBuilder.AlterColumn<int>(
                name: "SalesOrderId",
                table: "SalesOrderProduct",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesOrderProduct",
                table: "SalesOrderProduct",
                columns: new[] { "SalesOrderId", "ProductId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductStoreLocation",
                table: "ProductStoreLocation",
                columns: new[] { "ProductId", "StoreLocationId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderProduct_SalesOrder_SalesOrderId",
                table: "SalesOrderProduct",
                column: "SalesOrderId",
                principalTable: "SalesOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderProduct_SalesOrder_SalesOrderId",
                table: "SalesOrderProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesOrderProduct",
                table: "SalesOrderProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductStoreLocation",
                table: "ProductStoreLocation");

            migrationBuilder.AlterColumn<int>(
                name: "SalesOrderId",
                table: "SalesOrderProduct",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SalesOrderProduct",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "SalesOrderProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProductStoreLocation",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesOrderProduct",
                table: "SalesOrderProduct",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductStoreLocation",
                table: "ProductStoreLocation",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderProduct_SalesOrderId",
                table: "SalesOrderProduct",
                column: "SalesOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStoreLocation_ProductId",
                table: "ProductStoreLocation",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderProduct_SalesOrder_SalesOrderId",
                table: "SalesOrderProduct",
                column: "SalesOrderId",
                principalTable: "SalesOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
