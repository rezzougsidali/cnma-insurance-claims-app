using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspproject.Data.Migrations
{
    /// <inheritdoc />
    public partial class fourth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "detail_contratId",
                table: "garantie",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_garantie_detail_contratId",
                table: "garantie",
                column: "detail_contratId");

            migrationBuilder.AddForeignKey(
                name: "FK_garantie_detail_contrat_detail_contratId",
                table: "garantie",
                column: "detail_contratId",
                principalTable: "detail_contrat",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_garantie_detail_contrat_detail_contratId",
                table: "garantie");

            migrationBuilder.DropIndex(
                name: "IX_garantie_detail_contratId",
                table: "garantie");

            migrationBuilder.DropColumn(
                name: "detail_contratId",
                table: "garantie");
        }
    }
}
