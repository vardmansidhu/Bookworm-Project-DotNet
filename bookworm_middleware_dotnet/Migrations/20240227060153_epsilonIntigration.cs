using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookworm_cs.Migrations
{
    /// <inheritdoc />
    public partial class epsilonIntigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Languages_LanguageId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Shelfs_Customers_CustomerId",
                table: "Shelfs");

            migrationBuilder.DropForeignKey(
                name: "FK_Shelfs_Products_ProductId",
                table: "Shelfs");

            migrationBuilder.DropForeignKey(
                name: "FK_Shelfs_TransactionType_TransactionTypeId",
                table: "Shelfs");

            migrationBuilder.DropIndex(
                name: "IX_Shelfs_CustomerId",
                table: "Shelfs");

            migrationBuilder.DropIndex(
                name: "IX_Shelfs_ProductId",
                table: "Shelfs");

            migrationBuilder.DropIndex(
                name: "IX_Shelfs_TransactionTypeId",
                table: "Shelfs");

            migrationBuilder.DropIndex(
                name: "IX_Products_LanguageId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductTypeId",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Shelfs_CustomerId",
                table: "Shelfs",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Shelfs_ProductId",
                table: "Shelfs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Shelfs_TransactionTypeId",
                table: "Shelfs",
                column: "TransactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_LanguageId",
                table: "Products",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeId",
                table: "Products",
                column: "ProductTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Languages_LanguageId",
                table: "Products",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeId",
                table: "Products",
                column: "ProductTypeId",
                principalTable: "ProductTypes",
                principalColumn: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shelfs_Customers_CustomerId",
                table: "Shelfs",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shelfs_Products_ProductId",
                table: "Shelfs",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shelfs_TransactionType_TransactionTypeId",
                table: "Shelfs",
                column: "TransactionTypeId",
                principalTable: "TransactionType",
                principalColumn: "TransactionTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
