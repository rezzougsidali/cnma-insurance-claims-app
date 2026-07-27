using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspproject.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_garantie_detail_contrat_ContratId1",
                table: "garantie");

            migrationBuilder.DropIndex(
                name: "IX_garantie_ContratId1",
                table: "garantie");

            migrationBuilder.DropColumn(
                name: "ContratId1",
                table: "garantie");

            migrationBuilder.DropColumn(
                name: "detail_contratId",
                table: "garantie");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ContratId1",
                table: "garantie",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "detail_contratId",
                table: "garantie",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_garantie_ContratId1",
                table: "garantie",
                column: "ContratId1");

            migrationBuilder.AddForeignKey(
                name: "FK_garantie_detail_contrat_ContratId1",
                table: "garantie",
                column: "ContratId1",
                principalTable: "detail_contrat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
