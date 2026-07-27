using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspproject.Migrations
{
    /// <inheritdoc />
    public partial class garantieerrorfixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_garantie_detail_contrat_ContratId",
                table: "garantie");

            migrationBuilder.RenameColumn(
                name: "PrimeNette",
                table: "garantie",
                newName: "prime_nette");

            migrationBuilder.RenameColumn(
                name: "ContratId",
                table: "garantie",
                newName: "contrat_id");

            migrationBuilder.RenameColumn(
                name: "CodeGarantie",
                table: "garantie",
                newName: "code_garantie");

            migrationBuilder.RenameIndex(
                name: "IX_garantie_ContratId",
                table: "garantie",
                newName: "IX_garantie_contrat_id");

            migrationBuilder.AddForeignKey(
                name: "FK_garantie_detail_contrat_contrat_id",
                table: "garantie",
                column: "contrat_id",
                principalTable: "detail_contrat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_garantie_detail_contrat_contrat_id",
                table: "garantie");

            migrationBuilder.RenameColumn(
                name: "prime_nette",
                table: "garantie",
                newName: "PrimeNette");

            migrationBuilder.RenameColumn(
                name: "contrat_id",
                table: "garantie",
                newName: "ContratId");

            migrationBuilder.RenameColumn(
                name: "code_garantie",
                table: "garantie",
                newName: "CodeGarantie");

            migrationBuilder.RenameIndex(
                name: "IX_garantie_contrat_id",
                table: "garantie",
                newName: "IX_garantie_ContratId");

            migrationBuilder.AddForeignKey(
                name: "FK_garantie_detail_contrat_ContratId",
                table: "garantie",
                column: "ContratId",
                principalTable: "detail_contrat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
