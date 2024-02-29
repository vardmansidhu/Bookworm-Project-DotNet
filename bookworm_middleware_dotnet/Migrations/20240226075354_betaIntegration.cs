using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookworm_cs.Migrations
{
    /// <inheritdoc />
    public partial class betaIntegration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Languages_ProductTypes_ProductTypeTypeId",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Languages_ProductTypeTypeId",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "ProductTypeTypeId",
                table: "Languages");

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.AddColumn<int>(
                name: "ProductTypeTypeId",
                table: "Languages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Languages_ProductTypeTypeId",
                table: "Languages",
                column: "ProductTypeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_ProductTypes_ProductTypeTypeId",
                table: "Languages",
                column: "ProductTypeTypeId",
                principalTable: "ProductTypes",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
