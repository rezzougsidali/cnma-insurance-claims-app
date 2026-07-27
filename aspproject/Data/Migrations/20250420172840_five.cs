using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspproject.Data.Migrations
{
    /// <inheritdoc />
    public partial class five : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_garantie_detail_contrat_detail_contratId",
                table: "garantie");

            migrationBuilder.AlterColumn<int>(
                name: "detail_contratId",
                table: "garantie",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_garantie_detail_contrat_detail_contratId",
                table: "garantie",
                column: "detail_contratId",
                principalTable: "detail_contrat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_garantie_detail_contrat_detail_contratId",
                table: "garantie");

            migrationBuilder.AlterColumn<int>(
                name: "detail_contratId",
                table: "garantie",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_garantie_detail_contrat_detail_contratId",
                table: "garantie",
                column: "detail_contratId",
                principalTable: "detail_contrat",
                principalColumn: "Id");
        }
    }
}
