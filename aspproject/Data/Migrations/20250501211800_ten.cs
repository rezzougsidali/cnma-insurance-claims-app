using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspproject.Data.Migrations
{
    /// <inheritdoc />
    public partial class ten : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "branche");

            migrationBuilder.DropTable(
                name: "crma");

            migrationBuilder.DropTable(
                name: "synthese_contrat");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "branche",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreAvenants = table.Column<int>(type: "int", nullable: false),
                    NombreContrat = table.Column<int>(type: "int", nullable: false)
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
                name: "synthese_contrat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrancheId = table.Column<int>(type: "int", nullable: false),
                    CapitalAssure = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CotisationNette = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Creances = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CrmaId = table.Column<int>(type: "int", nullable: false),
                    Exercice = table.Column<int>(type: "int", nullable: false),
                    PrimeCommerciale = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_synthese_contrat", x => x.Id);
                });
        }
    }
}
