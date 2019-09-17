using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreConsultorio.Data.Migrations
{
    public partial class AddTablaTurnos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DniPaciente = table.Column<int>(nullable: false),
                    IdEspecialidad = table.Column<int>(nullable: false),
                    IdProfesional = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTimeOffset>(nullable: false),
                    Observaciones = table.Column<string>(nullable: true),
                    Realizado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Turnos");
        }
    }
}
