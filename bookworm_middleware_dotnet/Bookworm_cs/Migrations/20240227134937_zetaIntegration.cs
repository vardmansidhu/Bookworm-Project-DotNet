using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookworm_cs.Migrations
{
    /// <inheritdoc />
    public partial class zetaIntegration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shelfs_Products_ProductId",
                table: "Shelfs");

            migrationBuilder.DropIndex(
                name: "IX_Shelfs_ProductId",
                table: "Shelfs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Shelfs_ProductId",
                table: "Shelfs",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shelfs_Products_ProductId",
                table: "Shelfs",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
