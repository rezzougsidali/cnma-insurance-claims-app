using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspproject.Data.Migrations
{
    /// <inheritdoc />
    public partial class detailsinistree : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detail_sinistre");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "detail_sinistre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateSinistre = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DetailContratId = table.Column<int>(type: "int", nullable: false),
                    EtatDossier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MontantEncaisse = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontantReglement = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontantReserve = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NumeroSinistre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detail_sinistre", x => x.Id);
                });
        }
    }
}
