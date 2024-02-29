using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookworm_cs.Migrations
{
    /// <inheritdoc />
    public partial class alpha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductBeneficiaries_Beneficiaries_BeneficiaryBenId",
                table: "ProductBeneficiaries");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductBeneficiaries_Products_ProductId",
                table: "ProductBeneficiaries");

            migrationBuilder.DropForeignKey(
                name: "FK_RoyaltyCalculations_Beneficiaries_BeneficiaryBenId",
                table: "RoyaltyCalculations");

            migrationBuilder.DropForeignKey(
                name: "FK_RoyaltyCalculations_Invoices_InvoiceId",
                table: "RoyaltyCalculations");

            migrationBuilder.DropIndex(
                name: "IX_RoyaltyCalculations_BeneficiaryBenId",
                table: "RoyaltyCalculations");

            migrationBuilder.DropIndex(
                name: "IX_RoyaltyCalculations_InvoiceId",
                table: "RoyaltyCalculations");

            migrationBuilder.DropIndex(
                name: "IX_ProductBeneficiaries_BeneficiaryBenId",
                table: "ProductBeneficiaries");

            migrationBuilder.DropIndex(
                name: "IX_ProductBeneficiaries_ProductId",
                table: "ProductBeneficiaries");

            migrationBuilder.DropColumn(
                name: "BeneficiaryBenId",
                table: "RoyaltyCalculations");

            migrationBuilder.DropColumn(
                name: "BeneficiaryBenId",
                table: "ProductBeneficiaries");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shelfs_Products_ProductId",
                table: "Shelfs");

            migrationBuilder.DropIndex(
                name: "IX_Shelfs_ProductId",
                table: "Shelfs");

            migrationBuilder.AddColumn<int>(
                name: "BeneficiaryBenId",
                table: "RoyaltyCalculations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BeneficiaryBenId",
                table: "ProductBeneficiaries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RoyaltyCalculations_BeneficiaryBenId",
                table: "RoyaltyCalculations",
                column: "BeneficiaryBenId");

            migrationBuilder.CreateIndex(
                name: "IX_RoyaltyCalculations_InvoiceId",
                table: "RoyaltyCalculations",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBeneficiaries_BeneficiaryBenId",
                table: "ProductBeneficiaries",
                column: "BeneficiaryBenId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBeneficiaries_ProductId",
                table: "ProductBeneficiaries",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBeneficiaries_Beneficiaries_BeneficiaryBenId",
                table: "ProductBeneficiaries",
                column: "BeneficiaryBenId",
                principalTable: "Beneficiaries",
                principalColumn: "BenId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBeneficiaries_Products_ProductId",
                table: "ProductBeneficiaries",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoyaltyCalculations_Beneficiaries_BeneficiaryBenId",
                table: "RoyaltyCalculations",
                column: "BeneficiaryBenId",
                principalTable: "Beneficiaries",
                principalColumn: "BenId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoyaltyCalculations_Invoices_InvoiceId",
                table: "RoyaltyCalculations",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "InvoiceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
