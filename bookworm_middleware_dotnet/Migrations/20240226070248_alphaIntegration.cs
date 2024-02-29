using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookworm_cs.Migrations
{
    /// <inheritdoc />
    public partial class alphaIntegration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "BasePrice",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ISBN",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsLibrary",
                table: "Products",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRentable",
                table: "Products",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LongDesc",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinRentDays",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OfferExpDate",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "OfferPrice",
                table: "Products",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductEngName",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProductTypeTypeId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Publisher",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "RentPerDay",
                table: "Products",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortDesc",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SpecialCost",
                table: "Products",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Beneficiaries",
                columns: table => new
                {
                    BenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BenName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankBranch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IFSC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PAN = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficiaries", x => x.BenId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeDesc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "TransactionType",
                columns: table => new
                {
                    TransactionTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionDesc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionType", x => x.TransactionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ProductBeneficiaries",
                columns: table => new
                {
                    ProdBenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BenId = table.Column<int>(type: "int", nullable: false),
                    BeneficiaryBenId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Percentage = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBeneficiaries", x => x.ProdBenId);
                    table.ForeignKey(
                        name: "FK_ProductBeneficiaries_Beneficiaries_BeneficiaryBenId",
                        column: x => x.BeneficiaryBenId,
                        principalTable: "Beneficiaries",
                        principalColumn: "BenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductBeneficiaries_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    InvoiceAmount = table.Column<float>(type: "real", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Invoices_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    ProductTypeTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.LanguageId);
                    table.ForeignKey(
                        name: "FK_Languages_ProductTypes_ProductTypeTypeId",
                        column: x => x.ProductTypeTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shelfs",
                columns: table => new
                {
                    ShelfId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    TransactionTypeId = table.Column<int>(type: "int", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelfs", x => x.ShelfId);
                    table.ForeignKey(
                        name: "FK_Shelfs_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shelfs_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shelfs_TransactionType_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalTable: "TransactionType",
                        principalColumn: "TransactionTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetails",
                columns: table => new
                {
                    InvDtlId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    BasePrice = table.Column<double>(type: "float", nullable: true),
                    SellingPrice = table.Column<double>(type: "float", nullable: true),
                    TransactionTypeId = table.Column<int>(type: "int", nullable: true),
                    RentingDays = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetails", x => x.InvDtlId);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceId");
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_TransactionType_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalTable: "TransactionType",
                        principalColumn: "TransactionTypeId");
                });

            migrationBuilder.CreateTable(
                name: "RoyaltyCalculations",
                columns: table => new
                {
                    RoycalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    BenId = table.Column<int>(type: "int", nullable: false),
                    BeneficiaryBenId = table.Column<int>(type: "int", nullable: false),
                    RoycalTrandate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProdId = table.Column<int>(type: "int", nullable: false),
                    Trantype = table.Column<int>(type: "int", nullable: false),
                    Saleprice = table.Column<double>(type: "float", nullable: false),
                    Baseprice = table.Column<double>(type: "float", nullable: false),
                    RoyaltyOnBasePrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoyaltyCalculations", x => x.RoycalId);
                    table.ForeignKey(
                        name: "FK_RoyaltyCalculations_Beneficiaries_BeneficiaryBenId",
                        column: x => x.BeneficiaryBenId,
                        principalTable: "Beneficiaries",
                        principalColumn: "BenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoyaltyCalculations_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_LanguageId",
                table: "Products",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeTypeId",
                table: "Products",
                column: "ProductTypeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_InvoiceId",
                table: "InvoiceDetails",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_ProductId",
                table: "InvoiceDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_TransactionTypeId",
                table: "InvoiceDetails",
                column: "TransactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomerId",
                table: "Invoices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_ProductTypeTypeId",
                table: "Languages",
                column: "ProductTypeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBeneficiaries_BeneficiaryBenId",
                table: "ProductBeneficiaries",
                column: "BeneficiaryBenId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBeneficiaries_ProductId",
                table: "ProductBeneficiaries",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_RoyaltyCalculations_BeneficiaryBenId",
                table: "RoyaltyCalculations",
                column: "BeneficiaryBenId");

            migrationBuilder.CreateIndex(
                name: "IX_RoyaltyCalculations_InvoiceId",
                table: "RoyaltyCalculations",
                column: "InvoiceId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Languages_LanguageId",
                table: "Products",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeTypeId",
                table: "Products",
                column: "ProductTypeTypeId",
                principalTable: "ProductTypes",
                principalColumn: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Languages_LanguageId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeTypeId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "InvoiceDetails");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "ProductBeneficiaries");

            migrationBuilder.DropTable(
                name: "RoyaltyCalculations");

            migrationBuilder.DropTable(
                name: "Shelfs");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "Beneficiaries");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "TransactionType");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Products_LanguageId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductTypeTypeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BasePrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ISBN",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsLibrary",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsRentable",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LongDesc",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MinRentDays",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OfferExpDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OfferPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductEngName",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductTypeTypeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Publisher",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RentPerDay",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShortDesc",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SpecialCost",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Products");
        }
    }
}
