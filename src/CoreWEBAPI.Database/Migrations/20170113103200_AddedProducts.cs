using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreWEBAPI.Database.Migrations
{
    public partial class AddedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductModel_Bills_BillId",
                table: "ProductModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductModel",
                table: "ProductModel");

            migrationBuilder.RenameTable(
                name: "ProductModel",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_ProductModel_BillId",
                table: "Products",
                newName: "IX_Products_BillId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Bills_BillId",
                table: "Products",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Bills_BillId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "ProductModel");

            migrationBuilder.RenameIndex(
                name: "IX_Products_BillId",
                table: "ProductModel",
                newName: "IX_ProductModel_BillId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductModel",
                table: "ProductModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductModel_Bills_BillId",
                table: "ProductModel",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}