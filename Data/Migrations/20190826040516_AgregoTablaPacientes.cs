using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreConsultorio.Data.Migrations
{
    public partial class AgregoTablaPacientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    DNI = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Apellido = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Sexo = table.Column<char>(nullable: false),
                    Fecha_Nacimiento = table.Column<DateTimeOffset>(nullable: false),
                    Fecha_Alta = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.DNI);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}
