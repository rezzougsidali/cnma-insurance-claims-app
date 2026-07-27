using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspproject.Migrations
{
    /// <inheritdoc />
    public partial class eleven : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "detail_contrat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrmaId = table.Column<int>(type: "int", nullable: false),
                    Exercice = table.Column<int>(type: "int", nullable: false),
                    AssureId = table.Column<int>(type: "int", nullable: false),
                    NumeroPolice = table.Column<int>(type: "int", nullable: false),
                    DatePolice = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroContrat = table.Column<int>(type: "int", nullable: false),
                    DateEffet = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateExpiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrimeNette = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Complement = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Taxes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Timbres = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontantNetAPayer = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detail_contrat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "garantie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContratId = table.Column<int>(type: "int", nullable: false),
                    CodeGarantie = table.Column<int>(type: "int", nullable: false),
                    Capital = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Majoration = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Reduction = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrimeNette = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_garantie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_garantie_detail_contrat_ContratId",
                        column: x => x.ContratId,
                        principalTable: "detail_contrat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_garantie_ContratId",
                table: "garantie",
                column: "ContratId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "garantie");

            migrationBuilder.DropTable(
                name: "detail_contrat");
        }
    }
}
