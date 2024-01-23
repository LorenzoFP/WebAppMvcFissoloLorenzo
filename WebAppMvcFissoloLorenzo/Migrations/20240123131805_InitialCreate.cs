using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppMvcFissoloLorenzo.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RichiestaRimboso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Cognome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    DataRichiesta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PartitaIva = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Richiesta = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Importo = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RichiestaRimboso", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RichiestaRimboso");
        }
    }
}
