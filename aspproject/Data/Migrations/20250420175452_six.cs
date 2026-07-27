using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspproject.Data.Migrations
{
    /// <inheritdoc />
    public partial class six : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_garantie_ContratId",
                table: "garantie",
                column: "ContratId");

            migrationBuilder.AddForeignKey(
                name: "FK_garantie_detail_contrat_ContratId",
                table: "garantie",
                column: "ContratId",
                principalTable: "detail_contrat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_garantie_detail_contrat_ContratId",
                table: "garantie");

            migrationBuilder.DropIndex(
                name: "IX_garantie_ContratId",
                table: "garantie");

            migrationBuilder.AddColumn<int>(
                name: "detail_contratId",
                table: "garantie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_garantie_detail_contratId",
                table: "garantie",
                column: "detail_contratId");

            migrationBuilder.AddForeignKey(
                name: "FK_garantie_detail_contrat_detail_contratId",
                table: "garantie",
                column: "detail_contratId",
                principalTable: "detail_contrat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
