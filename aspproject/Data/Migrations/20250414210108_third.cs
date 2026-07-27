using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspproject.Data.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_detail_ontrat",
                table: "detail_ontrat");

            migrationBuilder.RenameTable(
                name: "detail_ontrat",
                newName: "detail_contrat");

            migrationBuilder.AddPrimaryKey(
                name: "PK_detail_contrat",
                table: "detail_contrat",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_detail_contrat",
                table: "detail_contrat");

            migrationBuilder.RenameTable(
                name: "detail_contrat",
                newName: "detail_ontrat");

            migrationBuilder.AddPrimaryKey(
                name: "PK_detail_ontrat",
                table: "detail_ontrat",
                column: "Id");
        }
    }
}
