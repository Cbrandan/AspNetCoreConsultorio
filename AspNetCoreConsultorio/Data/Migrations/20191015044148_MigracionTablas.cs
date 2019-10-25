using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreConsultorio.Data.Migrations
{
    public partial class MigracionTablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TablaSexos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TablaSexos", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    DNI = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Apellido = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    SexoId = table.Column<Guid>(nullable: false),
                    Fecha_Nacimiento = table.Column<DateTimeOffset>(nullable: false),
                    Fecha_Alta = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.DNI);
                    table.ForeignKey(
                        name: "FK_Pacientes_TablaSexos_SexoId",
                        column: x => x.SexoId,
                        principalTable: "TablaSexos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TablaSexos",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("5155da31-fc90-4eeb-9b19-696a282396d2"), "Masculino" });

            migrationBuilder.InsertData(
                table: "TablaSexos",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("2ecdcb42-d337-4e1c-9922-10d83dc120ce"), "Femenino" });

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_SexoId",
                table: "Pacientes",
                column: "SexoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Turnos");

            migrationBuilder.DropTable(
                name: "TablaSexos");
        }
    }
}
