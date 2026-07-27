using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspproject.Migrations
{
    /// <inheritdoc />
    public partial class detailsinistre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "detail_sinistre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero_police = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero_sinistre = table.Column<double>(type: "float", nullable: false),
                    Date_Sinistre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Etat_Dossier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Montant_Reserve = table.Column<double>(type: "float", nullable: false),
                    Montant_Reglement = table.Column<double>(type: "float", nullable: false),
                    Montant_Encaisse = table.Column<double>(type: "float", nullable: false),
                    crma_id = table.Column<long>(type: "bigint", nullable: false),
                    assure_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detail_sinistre", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detail_sinistre");
        }
    }
}
