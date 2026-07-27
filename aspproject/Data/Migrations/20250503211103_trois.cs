using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspproject.Data.Migrations
{
    /// <inheritdoc />
    public partial class trois : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssureId",
                table: "detail_contrat");

            migrationBuilder.DropColumn(
                name: "CrmaId",
                table: "detail_contrat");

            migrationBuilder.DropColumn(
                name: "DateEffet",
                table: "detail_contrat");

            migrationBuilder.DropColumn(
                name: "DateExpiration",
                table: "detail_contrat");

            migrationBuilder.DropColumn(
                name: "DatePolice",
                table: "detail_contrat");

            migrationBuilder.DropColumn(
                name: "MontantNetAPayer",
                table: "detail_contrat");

            migrationBuilder.DropColumn(
                name: "PrimeNette",
                table: "detail_contrat");

            migrationBuilder.RenameColumn(
                name: "Timbres",
                table: "detail_contrat",
                newName: "timbres");

            migrationBuilder.RenameColumn(
                name: "Taxes",
                table: "detail_contrat",
                newName: "taxes");

            migrationBuilder.RenameColumn(
                name: "Exercice",
                table: "detail_contrat",
                newName: "exercice");

            migrationBuilder.RenameColumn(
                name: "Complement",
                table: "detail_contrat",
                newName: "complement");

            migrationBuilder.RenameColumn(
                name: "NumeroPolice",
                table: "detail_contrat",
                newName: "crma_id");

            migrationBuilder.RenameColumn(
                name: "NumeroContrat",
                table: "detail_contrat",
                newName: "assure_id");

            migrationBuilder.AlterColumn<float>(
                name: "ContratId",
                table: "garantie",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "timbres",
                table: "detail_contrat",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<float>(
                name: "taxes",
                table: "detail_contrat",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<float>(
                name: "complement",
                table: "detail_contrat",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<float>(
                name: "Id",
                table: "detail_contrat",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "date_effet",
                table: "detail_contrat",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "date_expiration",
                table: "detail_contrat",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "date_police",
                table: "detail_contrat",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "montant_net_a_payer",
                table: "detail_contrat",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "numero_contrat",
                table: "detail_contrat",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "numero_police",
                table: "detail_contrat",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "prime_nette",
                table: "detail_contrat",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "date_effet",
                table: "detail_contrat");

            migrationBuilder.DropColumn(
                name: "date_expiration",
                table: "detail_contrat");

            migrationBuilder.DropColumn(
                name: "date_police",
                table: "detail_contrat");

            migrationBuilder.DropColumn(
                name: "montant_net_a_payer",
                table: "detail_contrat");

            migrationBuilder.DropColumn(
                name: "numero_contrat",
                table: "detail_contrat");

            migrationBuilder.DropColumn(
                name: "numero_police",
                table: "detail_contrat");

            migrationBuilder.DropColumn(
                name: "prime_nette",
                table: "detail_contrat");

            migrationBuilder.RenameColumn(
                name: "timbres",
                table: "detail_contrat",
                newName: "Timbres");

            migrationBuilder.RenameColumn(
                name: "taxes",
                table: "detail_contrat",
                newName: "Taxes");

            migrationBuilder.RenameColumn(
                name: "exercice",
                table: "detail_contrat",
                newName: "Exercice");

            migrationBuilder.RenameColumn(
                name: "complement",
                table: "detail_contrat",
                newName: "Complement");

            migrationBuilder.RenameColumn(
                name: "crma_id",
                table: "detail_contrat",
                newName: "NumeroPolice");

            migrationBuilder.RenameColumn(
                name: "assure_id",
                table: "detail_contrat",
                newName: "NumeroContrat");

            migrationBuilder.AlterColumn<int>(
                name: "ContratId",
                table: "garantie",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "Timbres",
                table: "detail_contrat",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "Taxes",
                table: "detail_contrat",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "Complement",
                table: "detail_contrat",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "detail_contrat",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "AssureId",
                table: "detail_contrat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CrmaId",
                table: "detail_contrat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEffet",
                table: "detail_contrat",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateExpiration",
                table: "detail_contrat",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DatePolice",
                table: "detail_contrat",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "MontantNetAPayer",
                table: "detail_contrat",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PrimeNette",
                table: "detail_contrat",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
