using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspproject.Migrations
{
    /// <inheritdoc />
    public partial class garantieerrorfixed2 : Migration
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

            migrationBuilder.RenameColumn(
                name: "detail_contratId1",
                table: "garantie",
                newName: "ContratId1");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_garantie_detail_contrat_ContratId1",
                table: "garantie");

            migrationBuilder.DropIndex(
                name: "IX_garantie_ContratId1",
                table: "garantie");

            migrationBuilder.RenameColumn(
                name: "ContratId1",
                table: "garantie",
                newName: "detail_contratId1");

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
