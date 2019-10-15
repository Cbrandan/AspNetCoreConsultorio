using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreConsultorio.Data.Migrations
{
    public partial class AddRegistrysTablaSexos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TablaSexos",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("f5e2ac48-537e-49f2-8ab9-9b807f465ada"), "Masculino" });

            migrationBuilder.InsertData(
                table: "TablaSexos",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("e669d6ec-7157-49b8-8720-3c1a6227a201"), "Femenino" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TablaSexos",
                keyColumn: "Id",
                keyValue: new Guid("e669d6ec-7157-49b8-8720-3c1a6227a201"));

            migrationBuilder.DeleteData(
                table: "TablaSexos",
                keyColumn: "Id",
                keyValue: new Guid("f5e2ac48-537e-49f2-8ab9-9b807f465ada"));
        }
    }
}
