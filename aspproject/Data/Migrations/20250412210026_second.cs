using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspproject.Data.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "assure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroAssure = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assure", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "branche",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreContrat = table.Column<int>(type: "int", nullable: false),
                    NombreAvenants = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_branche", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "crma",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_crma", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "detail_ontrat",
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
                    table.PrimaryKey("PK_detail_ontrat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "detail_sinistre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DetailContratId = table.Column<int>(type: "int", nullable: false),
                    NumeroSinistre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateSinistre = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EtatDossier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MontantReserve = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontantReglement = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontantEncaisse = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detail_sinistre", x => x.Id);
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
                });

            migrationBuilder.CreateTable(
                name: "synthese_contrat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrmaId = table.Column<int>(type: "int", nullable: false),
                    BrancheId = table.Column<int>(type: "int", nullable: false),
                    Exercice = table.Column<int>(type: "int", nullable: false),
                    PrimeCommerciale = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Creances = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CapitalAssure = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CotisationNette = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_synthese_contrat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "synthese_volet_sinistre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrmaId = table.Column<int>(type: "int", nullable: false),
                    NumeroSinistre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroDossiersOuverts = table.Column<int>(type: "int", nullable: false),
                    NombreReserve = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MontantReserve = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NombreReglement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MontantReglement = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NombreSap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MontantSap = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_synthese_volet_sinistre", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "assure");

            migrationBuilder.DropTable(
                name: "branche");

            migrationBuilder.DropTable(
                name: "crma");

            migrationBuilder.DropTable(
                name: "detail_ontrat");

            migrationBuilder.DropTable(
                name: "detail_sinistre");

            migrationBuilder.DropTable(
                name: "garantie");

            migrationBuilder.DropTable(
                name: "synthese_contrat");

            migrationBuilder.DropTable(
                name: "synthese_volet_sinistre");
        }
    }
}
