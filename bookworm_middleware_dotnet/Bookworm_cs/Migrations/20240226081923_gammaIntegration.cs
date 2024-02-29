using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookworm_cs.Migrations
{
    /// <inheritdoc />
    public partial class gammaIntegration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeTypeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductTypeTypeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductTypeTypeId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Products",
                newName: "ProductTypeId");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Languages",
                newName: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeId",
                table: "Products",
                column: "ProductTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeId",
                table: "Products",
                column: "ProductTypeId",
                principalTable: "ProductTypes",
                principalColumn: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductTypeId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductTypeId",
                table: "Products",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "ProductTypeId",
                table: "Languages",
                newName: "TypeId");

            migrationBuilder.AddColumn<int>(
                name: "ProductTypeTypeId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeTypeId",
                table: "Products",
                column: "ProductTypeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeTypeId",
                table: "Products",
                column: "ProductTypeTypeId",
                principalTable: "ProductTypes",
                principalColumn: "TypeId");
        }
    }
}
