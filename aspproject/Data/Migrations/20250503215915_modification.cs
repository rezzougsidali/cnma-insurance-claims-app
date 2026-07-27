using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspproject.Data.Migrations
{
    /// <inheritdoc />
    public partial class modification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "garantie");

            migrationBuilder.DropTable(
                name: "detail_contrat");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "detail_contrat",
                columns: table => new
                {
                    Id = table.Column<double>(type: "float", nullable: false),
                    assure_id = table.Column<int>(type: "int", nullable: false),
                    complement = table.Column<double>(type: "float", nullable: false),
                    crma_id = table.Column<int>(type: "int", nullable: false),
                    date_effet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_expiration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_police = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    exercice = table.Column<int>(type: "int", nullable: false),
                    montant_net_a_payer = table.Column<double>(type: "float", nullable: false),
                    numero_contrat = table.Column<double>(type: "float", nullable: false),
                    numero_police = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prime_nette = table.Column<double>(type: "float", nullable: false),
                    taxes = table.Column<double>(type: "float", nullable: false),
                    timbres = table.Column<double>(type: "float", nullable: false)
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
                    ContratId = table.Column<double>(type: "float", nullable: false),
                    Capital = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CodeGarantie = table.Column<int>(type: "int", nullable: false),
                    Majoration = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimeNette = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Reduction = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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
    }
}
